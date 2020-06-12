using System;
using SmartHunter.Config;
using SmartHunter.Core.Config;
using SmartHunter.Game.Config;

namespace SmartHunter.Game.Helpers
{
    public static class ConfigHelper
    {
        static readonly string s_MainFileName = "Config.json";

        static ConfigContainer<MainConfig> s_Main;
        static ConfigContainer<LocalizationConfig> s_Localization;
        static ConfigContainer<MonsterDataConfig> s_MonsterData;
        static ConfigContainer<PlayerDataConfig> s_PlayerData;
        static ConfigContainer<MemoryConfig> s_Memory;

        public static ConfigContainer<MainConfig> Main
        {
            get
            {
                if (s_Main == null)
                {
                    s_Main = new ConfigContainer<MainConfig>(s_MainFileName);
                    s_Main.Changed += Main_Loaded;
                }

                return s_Main;
            }
        }

        public static ConfigContainer<LocalizationConfig> Localization
        {
            get
            {
                if (s_Localization == null)
                {
                    s_Localization = new ConfigContainer<LocalizationConfig>(Main.Values.LocalizationFileName);
                }

                return s_Localization;
            }
        }

        public static ConfigContainer<MonsterDataConfig> MonsterData
        {
            get
            {
                if (s_MonsterData == null)
                {
                    s_MonsterData = new ConfigContainer<MonsterDataConfig>(Main.Values.MonsterDataFileName);
                }

                return s_MonsterData;
            }
        }

        public static ConfigContainer<PlayerDataConfig> PlayerData
        {
            get
            {
                if (s_PlayerData == null)
                {
                    s_PlayerData = new ConfigContainer<PlayerDataConfig>(Main.Values.PlayerDataFileName);
                }

                return s_PlayerData;
            }
        }

        public static ConfigContainer<MemoryConfig> Memory
        {
            get
            {
                if (s_Memory == null)
                {
                    s_Memory = new ConfigContainer<MemoryConfig>(Main.Values.MemoryFileName);
                }

                return s_Memory;
            }
        }

        // Ensures configs are loaded
        public static void EnsureConfigs()
        {
            _ = Main;
            _ = Localization;
            _ = MonsterData;
            _ = PlayerData;
            _ = Memory;
        }

        static void Main_Loaded(object sender, EventArgs e)
        {
            Localization.TryChangeFileName(Main.Values.LocalizationFileName);
            MonsterData.TryChangeFileName(Main.Values.MonsterDataFileName);
            PlayerData.TryChangeFileName(Main.Values.PlayerDataFileName);
            Memory.TryChangeFileName(Main.Values.MemoryFileName);
        }
    }
}
