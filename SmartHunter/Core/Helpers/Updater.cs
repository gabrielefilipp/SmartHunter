using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Core.Helpers
{
    public class Updater
    {
        private readonly List<UpdateNode> _needUpdates = new List<UpdateNode>();
        private readonly string _apiEndpoint = "https://api.github.com/repos/gabrielefilipp/SmartHunter/commits?path=";
        private readonly string _apiRaw = "https://github.com/gabrielefilipp/SmartHunter/raw";
        private readonly string _dummyUserAgent = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        public bool CheckForUpdates(bool forceCheck = false)
        {
#if DEBUG

            return false;
#endif

            if (_needUpdates.Count == 0 || forceCheck == true)
            {
                try
                {
                    using var client = new WebClient();
                    using var stream = client.OpenRead("http://google.com/generate_204");// check connection (maybe pointless?)
                    var branch = "master";
                    //var files = new string[5] { "SmartHunter/Game/Config/MemoryConfig.cs", "SmartHunter/Game/Config/PlayerDataConfig.cs", "SmartHunter/Game/Config/MonsterDataConfig.cs", "SmartHunter/Game/Config/LocalizationConfig.cs", "SmartHunter/bin/Debug/SmartHunter.exe" };

                    UpdateNode[] nodes = new UpdateNode[5] { new UpdateNode("", "SmartHunter/Game/Config/MemoryConfig.cs", "Memory.json", "", false), new UpdateNode("", "SmartHunter/Game/Config/PlayerDataConfig.cs", "PlayerData.json", "", false), new UpdateNode("", "SmartHunter/Game/Config/MonsterDataConfig.cs", "MonsterData.json", "", false), new UpdateNode("", "SmartHunter/Game/Config/LocalizationConfig.cs", "en-US.json", "", false), new UpdateNode("", "SmartHunter/bin/Debug/SmartHunter.exe", "SmartHunter.exe", "", true)  };

                    foreach (UpdateNode node in nodes)
                    {
                        string apiUrl = $"{_apiEndpoint}{node.FilePath}";
                        client.Dispose();
                        client.Headers["User-Agent"] = _dummyUserAgent;

                        string apiResponseStr = client.DownloadString(apiUrl);
                        JArray json = JArray.Parse(apiResponseStr);
                        if (json.Count > 0)
                        {
                            JObject lastCommit = (JObject)json[0];
                            string hash = (string)lastCommit["sha"];
                            if (!ConfigHelper.Versions.Values.GetType().GetField(Path.GetFileNameWithoutExtension(node.FilePath)).GetValue(ConfigHelper.Versions.Values).Equals(hash))
                            {
                                Log.WriteLine($"Found a new version of '{Path.GetFileName(node.FileName)}'");
                                node.Hash = hash;
                                if (node.NeedDownload)
                                {
                                    node.DownloadUrl = $"{_apiRaw}/{branch}/{node.FilePath}";
                                }
                                _needUpdates.Add(node);
                            }
                        }
                    }
                }
                catch
                {
                    Log.WriteLine($"An error has occured while searching for updates... Resuming the normal flow of the application!");
                    return false;
                }
            }
            return _needUpdates.Count > 0;
        }

        public bool DownloadUpdates()
        {
            try
            {
                using var client = new WebClient();
                while (_needUpdates.Count > 0)
                {
                    UpdateNode node = _needUpdates.First();
                    string hash = node.Hash;
                    string filePath = node.FilePath;
                    string fileName = node.FileName;
                    string fileNamePath = Path.GetFileName(filePath);
                    string fileNamePathWithNoExtension = Path.GetFileNameWithoutExtension(filePath);
                    if (node.NeedDownload)
                    {
                        string url = node.DownloadUrl;
                        Log.WriteLine($"Downloading file '{fileNamePath}'");
                        client.Dispose();
                        client.Headers["User-Agent"] = _dummyUserAgent;
                        if (Path.GetExtension(fileNamePath).Equals(".exe"))
                        {
                            client.DownloadFile(url, $"{fileNamePathWithNoExtension}_NEW.exe");
                        }
                        else
                        {
                            client.DownloadFile(url, fileNamePath);
                        }
                    }
                    else
                    {
                        Log.WriteLine($"Deleting file '{fileName}'");
                        File.Delete(fileName);
                    }
                    ConfigHelper.Versions.Values.GetType().GetField(fileNamePathWithNoExtension).SetValue(ConfigHelper.Versions.Values, hash);
                    ConfigHelper.Versions.Save();
                    _needUpdates.Remove(node);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private class UpdateNode // TODO: Add a variable to contain a function pointer to execute a specific action if that Node needs to be updated
        {
            public string Hash { get; set; }
            public string FilePath { get; }
            public string FileName { get; set; }
            public string DownloadUrl { get; set; }
            public bool NeedDownload { get; }
            public UpdateNode(string h, string path, string name, string url, bool download = false)
            {
                Hash = h;
                FilePath = path;
                FileName = name;
                DownloadUrl = url;
                NeedDownload = download;
            }
        }
    }
}
