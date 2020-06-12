using System;
using System.IO;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;

namespace SmartHunter.Core.Helpers
{
    public class Updater
    {
        private readonly string _apiEndpoint = "https://api.github.com/repos/sir-wilhelm/SmartHunter/releases/latest";
        private readonly string _userAgent = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        public bool CheckForUpdates()
        {
            try
            {
                var latestRelease = GetLatestRelease();
                var needsUpdates = new Version(latestRelease.tag_name) > Assembly.GetExecutingAssembly().GetName().Version;
                if (!needsUpdates)
                {
                    Log.WriteLine("No updates found.");
                }
                return needsUpdates;
            }
            catch (Exception e)
            {
                Log.WriteLine($"An error has occured while searching for updates:{Environment.NewLine}{e}");
                Log.WriteLine("Resuming the normal flow of the application.");
                return false;
            }
        }

        private LatestRelease GetLatestRelease()
        {
            var request = WebRequest.CreateHttp(_apiEndpoint);
            request.ContentType = "application/json";
            request.UserAgent = _userAgent;
            using var stream = request.GetResponse().GetResponseStream();
            using var reader = new StreamReader(stream);
            var latestReleaseAsJson = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<LatestRelease>(latestReleaseAsJson);
        }

        public bool DownloadUpdates()
        {
            try
            {
                var latestRelease = GetLatestRelease();

                using var client = new WebClient();
                var releaseZip = latestRelease.assets[0];
                Log.WriteLine("Deleting older update.");
                File.Delete(releaseZip.name);
                client.DownloadFile(releaseZip.browser_download_url, releaseZip.name);
                return true;
            }
            catch (Exception e)
            {
                Log.WriteLine($"An error has occured while downloading update:{Environment.NewLine}{e}");
                return false;
            }
        }

        internal class LatestRelease
        {
            public string tag_name { get; set; }
            public Asset[] assets { get; set; }
        }
        internal class Asset
        {
            public string name { get; set; }
            public string browser_download_url { get; set; }
        }
    }
}
