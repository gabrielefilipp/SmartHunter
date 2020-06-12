using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using SmartHunter.Core.Helpers;
using SmartHunter.Game.Data.ViewModels;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Core
{
    public abstract class MemoryUpdater
    {
        enum State
        {
            None,
            DeleteOldFiles,
            CheckingForUpdates,
            DownloadingUpdates,
            Restarting,
            WaitingForProcess,
            ProcessFound,
            FastPatternScanning,
            PatternScanning,
            PatternScanFailed,
            Working
        }

        StateMachine<State> m_StateMachine;
        List<ThreadedMemoryScan> m_MemoryScans;
        List<ThreadedMemoryScan> m_FastMemoryScans;
        DispatcherTimer m_DispatcherTimer;

        protected abstract string ProcessName { get; }
        protected abstract BytePattern[] Patterns { get; }

        protected virtual int ThreadsPerScan { get { return 2; } }
        protected virtual int UpdatesPerSecond { get { return 20; } }
        protected virtual bool ShutdownWhenProcessExits { get { return false; } }

        protected Process Process { get; private set; }

        public MemoryUpdater()
        {
            CreateStateMachine();

            Initialize();

            m_DispatcherTimer = new DispatcherTimer();
            m_DispatcherTimer.Tick += Update;
            TryUpdateTimerInterval();
            m_DispatcherTimer.Start();
        }

        void CreateStateMachine()
        {
            var updater = new Updater();

            m_StateMachine = new StateMachine<State>();

            m_StateMachine.Add(State.None, new StateMachine<State>.StateData(
                null,
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.DeleteOldFiles,
                        () => true,
                        () =>
                        {
                            var oldFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "OLD_*", SearchOption.TopDirectoryOnly);
                            if (oldFiles.Any())
                            {
                                Log.WriteLine("Deleting old update files.");
                                foreach (var oldFile in oldFiles)
                                {
                                    Log.WriteLine($"Deleting old file: {oldFile.Substring(oldFile.LastIndexOf('\\') + 1)}");
                                    File.Delete(oldFile);
                                }
	                        }
                        })
                }));

            m_StateMachine.Add(State.DeleteOldFiles, new StateMachine<State>.StateData(
                null,
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.CheckingForUpdates,
                        () => ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates,
                        () =>
                        {
                            Log.WriteLine("Searching for updates...");
                            Log.WriteLine("This can be disabled by setting [\"AutomaticallyCheckAndDownloadUpdates\": true,] in Config.json.");
                        }),
                    new StateMachine<State>.Transition(
                        State.WaitingForProcess,
                        () => !ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates,
                        () =>
                        {
                            Initialize();
                        })
                }));

            m_StateMachine.Add(State.CheckingForUpdates, new StateMachine<State>.StateData(
                null,
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.WaitingForProcess,
                        () => !updater.CheckForUpdates(),
                        () =>
                        {
                            Initialize();
                        }),
                    new StateMachine<State>.Transition(
                        State.DownloadingUpdates,
                        () => updater.CheckForUpdates(),
                        () =>
                        {
                            Log.WriteLine("Starting to download Updates.");
                        })
                }));

            m_StateMachine.Add(State.DownloadingUpdates, new StateMachine<State>.StateData(
                null,
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.Restarting,
                        () => updater.DownloadUpdates(),
                        () =>
                        {
                            Log.WriteLine("Successfully downloaded all files.");
                        }),
                    new StateMachine<State>.Transition(
                        State.WaitingForProcess,
                        () => !updater.DownloadUpdates(),
                        () =>
                        {
                            Log.WriteLine("Failed to download Updates... Resuming the normal flow of the application.");
                            Initialize();
                        })
                }));

            m_StateMachine.Add(State.Restarting, new StateMachine<State>.StateData(
               null,
               new StateMachine<State>.Transition[]
               {
                    new StateMachine<State>.Transition(
                        State.Restarting,
                        () => true,
                        () =>
                        {
                            Log.WriteLine("Renaming files that will be replaced");
                            using var archive = ZipFile.OpenRead("SmartHunter.zip");
                            foreach (var entry in archive.Entries)
                            {
                                if (File.Exists(entry.Name))
                                {
                                    File.Move(entry.Name, $"OLD_{entry.Name}");
                                }
                            }

                            Log.WriteLine("Extracting new files.");
                            archive.ExtractToDirectory(Directory.GetCurrentDirectory());

                            Log.WriteLine("Update complete, Starting new SmartHunter, and exiting");
                            Process.Start("SmartHunter.exe");
                            Environment.Exit(1);
                        })
               }));

            m_StateMachine.Add(State.WaitingForProcess, new StateMachine<State>.StateData(
                null,
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.ProcessFound,
                        () =>
                        {
                            var processes = Process.GetProcesses();
                            foreach (var p in processes)
                            {
                                try
                                {
                                    if (p != null && p.ProcessName.Equals(ProcessName) && !p.HasExited)
                                    {
                                        Process = p;
                                        return true;
                                    }
                                }
                                catch
                                {
                                    // nothing here
                                }
                            }
                            return false;
                        },
                        null)
                }));

            m_StateMachine.Add(State.ProcessFound, new StateMachine<State>.StateData(
                null,
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.FastPatternScanning,
                        () => true,
                        () =>
                        {
                            foreach (var pattern in Patterns)
                            {
                                if (pattern.Config.LastResultAddress.Length > 0)
                                {
                                    if (MhwHelper.TryParseHex(pattern.Config.LastResultAddress, out var address))
                                    {
                                        var memoryScan = new ThreadedMemoryScan(Process, pattern, new AddressRange((ulong)address, (ulong)pattern.Bytes.Length), true, ThreadsPerScan);
                                        m_FastMemoryScans.Add(memoryScan);
                                    }
                                }
                            }
                        })
                }));

            m_StateMachine.Add(State.FastPatternScanning, new StateMachine<State>.StateData(
                null,
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.PatternScanning,
                        () =>
                        {
                            var completedScans = m_FastMemoryScans.Where(memoryScan => memoryScan.HasCompleted);
                            return completedScans.Count() == m_FastMemoryScans.Count();
                        },
                        () =>
                        {
                            var subPatterns = Patterns.Where(p => p.MatchedAddresses.Count() == 0);
                            if (subPatterns.Count() > 0)
                            {
                                AddressRange addressRange = new AddressRange((ulong)Process.MainModule.BaseAddress.ToInt64(), (ulong)Process.MainModule.ModuleMemorySize);
                                Log.WriteLine($"Base: 0x{addressRange.Start.ToString("X")}, End: 0x{addressRange.End.ToString("X")}, Size: 0x{addressRange.Size.ToString("X")}");

                                foreach (var pattern in subPatterns)
                                {
                                    var memoryScan = new ThreadedMemoryScan(Process, pattern, addressRange, true, ThreadsPerScan);
                                    m_MemoryScans.Add(memoryScan);
                                }
                            }
                        })
                }));

            m_StateMachine.Add(State.PatternScanning, new StateMachine<State>.StateData(
                null,
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.Working,
                        () =>
                        {
                            var completedScans = m_MemoryScans.Where(memoryScan => memoryScan.HasCompleted);
                            if (completedScans.Count() == m_MemoryScans.Count())
                            {
                                var finishedWithResults = m_MemoryScans.Where(memoryScan => memoryScan.HasCompleted && memoryScan.Results.SelectMany(result => result.Matches).Any());
                                return finishedWithResults.Any() || m_MemoryScans.Count() == 0 || m_FastMemoryScans.Where(memoryScan => memoryScan.HasCompleted && memoryScan.Results.SelectMany(result => result.Matches).Any()).Any();
                            }

                            return false;
                        },
                        () =>
                        {
                            var failedMemoryScans = m_MemoryScans.Where(memoryScan => !memoryScan.Results.SelectMany(result => result.Matches).Any());
                            if (failedMemoryScans.Any())
                            {
                                var failedPatterns = string.Join(" ", failedMemoryScans.Select(failedMemoryScan => failedMemoryScan.Pattern.Config.Name));
                                Log.WriteLine($"Failed Patterns [{failedMemoryScans.Count()}/{m_MemoryScans.Count()}]: {failedPatterns}");
                                Log.WriteLine($"The application will continue to work but with limited functionalities...");
                                m_MemoryScans.RemoveAll(scan => failedMemoryScans.Contains(scan));
                            }
                            ConfigHelper.Memory.Save(false);
                            m_MemoryScans.AddRange(m_FastMemoryScans.Where(f => f.Results.Where(r => r.Matches.Any()).Any()));
                            var orderedMatches = m_MemoryScans.Select(memoryScan => memoryScan.Results.Where(result => result.Matches.Any()).First().Matches.First()).OrderBy(match => match);
                            Log.WriteLine($"Match Range: {orderedMatches.First():X} - {orderedMatches.Last():X}");
                        }),
                    new StateMachine<State>.Transition(
                        State.PatternScanFailed,
                        () =>
                        {
                            var completedScans = m_MemoryScans.Where(memoryScan => memoryScan.HasCompleted);
                            if (completedScans.Count() == m_MemoryScans.Count())
                            {
                                var finishedWithoutResults = m_MemoryScans.Where(memoryScan => !memoryScan.Results.SelectMany(result => result.Matches).Any());
                                return (finishedWithoutResults.Count() == m_MemoryScans.Count()) && m_FastMemoryScans.Where(memoryScan => memoryScan.HasCompleted && memoryScan.Results.SelectMany(result => result.Matches).Any()).Count() == 0;
                            }

                            return false;
                        },
                        () =>
                        {
                            Log.WriteLine($"All pattern failed... Aborting.");
                        }),
                    new StateMachine<State>.Transition(
                        State.WaitingForProcess,
                        () =>
                        {
                            return Process.HasExited;
                        },
                        () =>
                        {
                            Initialize(true);
                        })
                }));

            m_StateMachine.Add(State.Working, new StateMachine<State>.StateData(
                () =>
                {
                    try
                    {
                        UpdateMemory();
                    }
                    catch (Exception ex)
                    {
                        Log.WriteException(ex);
                    }
                },
                new StateMachine<State>.Transition[]
                {
                    new StateMachine<State>.Transition(
                        State.WaitingForProcess,
                        () =>
                        {
                            return Process.HasExited;
                        },
                        () =>
                        {
                            Initialize(true);
                        })
                }));
        }

        private void Initialize(bool processExited = false)
        {
            Process = null;

            if (m_MemoryScans != null)
            {
                foreach (var memoryScan in m_MemoryScans)
                {
                    memoryScan.TryCancel();
                }
            }

            m_FastMemoryScans = new List<ThreadedMemoryScan>();
            m_MemoryScans = new List<ThreadedMemoryScan>();

            OverlayViewModel.Instance.IsGameActive = false;

            if (processExited && ShutdownWhenProcessExits)
            {
                Log.WriteLine("Process exited. Shutting down.");
                Application.Current.Shutdown();
            }
        }

        private void Update(object sender, EventArgs e)
        {
            try
            {
                m_StateMachine.Update();
            }
            catch (Exception ex)
            {
                m_DispatcherTimer.IsEnabled = false;
                Log.WriteException(ex);
            }
        }

        abstract protected void UpdateMemory();

        protected void TryUpdateTimerInterval()
        {
            const int max = 60;
            const int min = 1;
            int clampedUpdatesPerSecond = Math.Min(Math.Max(UpdatesPerSecond, min), max); // TODO: Dynamic updates per second number based on game perfomance

            int targetMilliseconds = (int)(1000f / clampedUpdatesPerSecond);
            if (m_DispatcherTimer != null && m_DispatcherTimer.Interval.TotalMilliseconds != targetMilliseconds)
            {
                m_DispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, targetMilliseconds);
            }
        }
    }
}
