using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Core.Helpers
{

    public class UpdateNode
    {
        public string hash;
        public string fileName;
        public string downloadUrl;

        public UpdateNode(string h, string name, string url)
        {
            hash = h;
            fileName = name;
            downloadUrl = url;
        }
    }
    public class Updater
    {
        private List<UpdateNode> NeedUpdates = new List<UpdateNode>();
        private string ApiEndpoint = "https://api.github.com/repos/gabrielefilipp/SmartHunter/commits?path=";
        private string ApiRaw = "https://github.com/gabrielefilipp/SmartHunter/raw";
        private string dummyUserAgent = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        public bool CheckForUpdates(bool forceCheck = false)
        {
            if (NeedUpdates.Count == 0 || forceCheck == true)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        using (client.OpenRead("http://google.com/generate_204")) // check connection (maybe pointless?)
                        {
                            string branch = "master";
                            string[] files = new string[5] { "SmartHunter/Game/Config/MemoryConfig.cs", "SmartHunter/Game/Config/PlayerDataConfig.cs", "SmartHunter/Game/Config/MonsterDataConfig.cs", "SmartHunter/Game/Config/LocalizationConfig.cs", "SmartHunter/bin/x64/Debug/SmartHunter.exe" };
                            foreach (string file in files)
                            {
                                string apiUrl = $"{ApiEndpoint}{file}";
                                string name = Path.GetFileName(file);
                                string nameWithNoExtension = Path.GetFileNameWithoutExtension(name);

                                client.Dispose();
                                client.Headers["User-Agent"] = dummyUserAgent;

                                string apiResponseStr = client.DownloadString(apiUrl);
                                JArray json = JArray.Parse(apiResponseStr);
                                if (json.Count > 0)
                                {
                                    JObject lastCommit = (JObject)json[0];
                                    string hash = (string)lastCommit["sha"];
                                    if (!ConfigHelper.Versions.Values.GetType().GetField(nameWithNoExtension).GetValue(ConfigHelper.Versions.Values).Equals(hash))
                                    {
                                        Log.WriteLine($"Found a new version of '{name}'");
                                        NeedUpdates.Add(new UpdateNode(hash, name, $"{ApiRaw}/{branch}/{file}"));
                                    }
                                }
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
            return NeedUpdates.Count > 0;
        }

        public bool DownloadUpdates()
        {
            try
            {
                using (var client = new WebClient())
                {
                    while (NeedUpdates.Count > 0)
                    {
                        UpdateNode node = NeedUpdates.First();
                        string hash = node.hash;
                        string name = node.fileName;
                        string url = node.downloadUrl;
                        string nameWithNoExtension = Path.GetFileNameWithoutExtension(name);
                        Log.WriteLine($"Downloading file '{name}'");
                        client.Dispose();
                        client.Headers["User-Agent"] = dummyUserAgent;
                        if (Path.GetExtension(name).Equals(".exe"))
                        {
                            client.DownloadFile(url, $"{nameWithNoExtension}_{hash}.exe");
                        }
                        else
                        {
                            client.DownloadFile(url, name);
                        }
                        ConfigHelper.Versions.Values.GetType().GetField(nameWithNoExtension).SetValue(ConfigHelper.Versions.Values, hash);
                        ConfigHelper.Versions.Save();
                        NeedUpdates.Remove(node);
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
