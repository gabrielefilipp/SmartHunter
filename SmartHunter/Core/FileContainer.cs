using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace SmartHunter.Core
{
    public class FileContainer
    {
        FileSystemWatcher m_FileWatcher = null;

        public string FileName { get; private set; }

        public string FullPath
        {
            get
            {
                return GetFullPath();
            }
        }

        public string FullPathFileName
        {
            get
            {
                return GetFullPathFileName(FileName);
            }
        }

        public event EventHandler Changed;

        public FileContainer(string fileName)
        {
            FileName = fileName;

            bool isDesignInstance = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            if (!isDesignInstance)
            {
                WatchFile(true);
            }
        }

        public void TryChangeFileName(string fileName)
        {
            if (FileName == fileName)
            {
                return;
            }

            bool watching = m_FileWatcher != null;
            if (watching)
            {
                WatchFile(false);
            }

            FileName = fileName;

            OnChanged();
            if (Changed != null)
            {
                Changed(this, new EventArgs());
            }

            if (watching)
            {
                WatchFile(true);
            }
        }

        void WatchFile(bool watch)
        {
            if (watch && m_FileWatcher == null)
            {
                if (!String.IsNullOrEmpty(FileName))
                {
                    m_FileWatcher = new FileSystemWatcher();
                    m_FileWatcher.Path = FullPath;
                    m_FileWatcher.NotifyFilter = NotifyFilters.LastWrite;
                    m_FileWatcher.Filter = FileName;
                    m_FileWatcher.Changed += FileWatcher_Changed;
                    m_FileWatcher.EnableRaisingEvents = true;
                }
            }
            else if (!watch && m_FileWatcher != null)
            {
                m_FileWatcher.Changed -= FileWatcher_Changed;
                m_FileWatcher.Dispose();
                m_FileWatcher = null;
            }
        }

        async void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            TryPauseWatching();

            await Task.Delay(100);

            Application.Current.Dispatcher.Invoke(delegate
            {
                OnChanged();
                if (Changed != null)
                {
                    Changed(this, new EventArgs());
                }
            });

            TryUnpauseWatching();
        }

        protected void TryPauseWatching()
        {
            if (m_FileWatcher != null)
            {
                m_FileWatcher.EnableRaisingEvents = false;
            }
        }

        protected void TryUnpauseWatching()
        {
            if (m_FileWatcher != null)
            {
                m_FileWatcher.EnableRaisingEvents = true;
            }
        }

        virtual protected void OnChanged() { }

        public static string GetFullPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "") + "\\";
        }

        public static string GetFullPathFileName(string fileName)
        {
            return GetFullPath() + fileName;
        }
    }
}
