using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartHunter.Core.Helpers;

namespace SmartHunter.Core
{
    public class ThreadedMemoryScan
    {
        public class Result
        {
            public AddressRange AddressRange { get; private set; }
            public List<ulong> Matches { get; private set; }
            public float ExecutionMilliseconds { get { return m_Stopwatch.ElapsedMilliseconds; } }

            Stopwatch m_Stopwatch;

            public Result(AddressRange addressRange)
            {
                AddressRange = addressRange;
                Matches = new List<ulong>();

                m_Stopwatch = new Stopwatch();
                m_Stopwatch.Start();
            }

            public void Complete()
            {
                m_Stopwatch.Stop();
            }
        }

        public class CompletedEventArgs : EventArgs
        {
            public List<Result> Results { get; private set; }

            public ulong FirstMatch
            {
                get
                {
                    return Results.OrderBy(result => result.AddressRange.Start).SelectMany(result => result.Matches).FirstOrDefault();
                }
            }

            public CompletedEventArgs(List<Result> results)
            {
                Results = results;
            }
        }

        class TaskData
        {
            public CancellationTokenSource CancellationTokenSource { get; private set; }
            public Result Result { get; private set; }

            public TaskData(CancellationTokenSource cancellationTokenSource, AddressRange addressRange)
            {
                CancellationTokenSource = cancellationTokenSource;
                Result = new Result(addressRange);
            }
        }

        public event EventHandler<CompletedEventArgs> Completed;

        ConcurrentDictionary<Task<List<ulong>>, TaskData> m_Tasks;
        Stopwatch m_Stopwatch;

        public Process Process { get; private set; }
        public BytePattern Pattern { get; private set; }
        public bool StopAfterFirst { get; private set; }

        public bool HasCompleted { get; private set; }
        public float ExecutionMilliseconds { get { return m_Stopwatch.ElapsedMilliseconds; } }

        public List<Result> Results
        {
            get
            {
                List<Result> results = new List<Result>();
                lock (m_Tasks)
                {
                    results = m_Tasks.Select(task => task.Value.Result).ToList();
                }

                return results;
            }
        }

        public ThreadedMemoryScan(Process process, BytePattern pattern, AddressRange addressRange, bool stopAfterFirst, int threads = 2)
        {
            Process = process;
            Pattern = pattern;
            StopAfterFirst = stopAfterFirst;

            m_Tasks = new ConcurrentDictionary<Task<List<ulong>>, TaskData>();

            m_Stopwatch = new Stopwatch();
            m_Stopwatch.Start();

            var addressRangeDivisions = MemoryHelper.DivideAddressRange(addressRange, threads);
            foreach (var addressRangeDivision in addressRangeDivisions)
            {
                AddScanTask(addressRangeDivision);
            }
        }

        void AddScanTask(AddressRange addressRange)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            Task<List<ulong>> task = Task.Run(() =>
            {
                try
                {
                    return MemoryHelper.FindPatternAddresses(Process, addressRange, Pattern, StopAfterFirst);
                }
                catch (TaskCanceledException)
                {
                }
                catch (Exception ex)
                {
                    Log.WriteException(ex);
                }

                return null as List<ulong>;
            }, cancellationTokenSource.Token);

            task.ContinueWith((continuingTask) =>
            {
                try
                {
                    TaskData data = null;
                    lock (m_Tasks)
                    {
                        m_Tasks.TryGetValue(continuingTask, out data);
                    }

                    if (data == null)
                    {
                        return;
                    }

                    data.Result.Complete();

                    if (HasCompleted)
                    {
                        return;
                    }

                    if (continuingTask.Result != null && continuingTask.Result.Any())
                    {           
                        Pattern.MatchedAddresses.AddRange(continuingTask.Result.Select(address => address));
                        data.Result.Matches.AddRange(continuingTask.Result);

                        // Cancel all other threads and complete the scan because we needed only 1 result
                        if (StopAfterFirst)
                        {
                            TryCancel();
                        }
                    }

                    // Complete the scan if this is the last thread to finish
                    if (!HasCompleted)
                    {
                        int completedTaskCount = 0;
                        lock (m_Tasks)
                        {
                            completedTaskCount = m_Tasks.Select(t => t.Key).Where(thisTask => thisTask.IsCompleted).Count();
                        }

                        if (completedTaskCount == m_Tasks.Count)
                        {
                            TryComplete();
                        }
                    }
                }
                catch (TaskCanceledException)
                {
                }
                catch (Exception ex)
                {
                    Log.WriteException(ex);
                }
            });

            lock (m_Tasks)
            {
                m_Tasks.TryAdd(task, new TaskData(cancellationTokenSource, addressRange));
            }
        }

        public void TryCancel()
        {
            foreach (var memoryTaskData in m_Tasks.Values.ToList())
            {
                memoryTaskData.CancellationTokenSource.Cancel();
            }

            TryComplete();
        }

        void TryComplete()
        {
            m_Stopwatch.Stop();

            if (!HasCompleted)
            {
                HasCompleted = true;

                if (Completed != null)
                {
                    Completed(this, new CompletedEventArgs(Results));
                }
            }
        }
    }
}
