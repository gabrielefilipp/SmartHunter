using System;
using System.ComponentModel;
using System.IO;
using System.Security.AccessControl;

namespace SmartHunter.Core
{
    public static class Log
    {
        static string s_FileName = "Log.txt";

        public static event EventHandler<GenericEventArgs<string>> LineReceived;

        public static void WriteLine(string message)
        {
            var line = string.Format("[{0:yyyy-MM-dd HH:mm:ss}] {1}", DateTimeOffset.Now.ToUniversalTime(), message);
            Console.WriteLine(line);

            LineReceived?.Invoke(null, new GenericEventArgs<string>(line));

            bool isDesignInstance = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            if (!isDesignInstance)
            {
                try
                {
                    using var fileStream = new FileStream(s_FileName, FileMode.OpenOrCreate, FileSystemRights.AppendData, FileShare.Write, 4096, FileOptions.None);
                    using var streamWriter = new StreamWriter(fileStream);
                    streamWriter.AutoFlush = true;
                    streamWriter.WriteLine(line);
                }
                catch (Exception) { }
            }
        }

        public static void WriteException(Exception exception) => WriteLine($"{exception.GetType().Name}: {exception.Message}\r\n{exception.StackTrace}");

        public static void WriteWarning(string warning) =>
            // prep for adding support for colored messages to ConsoleWindow.
            WriteLine(warning);
    }
}
