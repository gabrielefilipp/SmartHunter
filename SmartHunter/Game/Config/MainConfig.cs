using SmartHunter.Core.Config;
using System.Collections.Generic;
using System.Windows.Input;

namespace SmartHunter.Game.Config
{
    public class MainConfig
    {
        public string VersionsFileName = "Versions.json";
        public string LocalizationFileName = "en-US.json";
        public string SkinFileName = "Default.xaml";
        public string MonsterDataFileName = "MonsterData.json";
        public string PlayerDataFileName = "PlayerData.json";
        public string MemoryFileName = "Memory.json";

        public bool ShutdownWhenProcessExits = false;
        public bool AutomaticallyCheckAndDownloadUpdates = true; // TODO: Rimetti a true

        public OverlayConfig Overlay = new OverlayConfig();

        [PreserveCollectionIntegrity]
        public Dictionary<InputControl, Key> Keybinds = new Dictionary<InputControl, Key>()
        {
            { InputControl.ManipulateWidget, Key.LeftAlt },
            { InputControl.HideWidgets, Key.F1 }
        };

        public DebugConfig Debug = new DebugConfig();
    }
}