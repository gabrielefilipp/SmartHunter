using System.Collections.Generic;
using System.Windows.Input;
using SmartHunter.Core.Config;

namespace SmartHunter.Game.Config
{
    public class MainConfig
    {
        public string LocalizationFileName = "en-US.json";
        public string SkinFileName = "Default.xaml";
        public string MonsterDataFileName = "MonsterData.json";
        public string PlayerDataFileName = "PlayerData.json";
        public string MemoryFileName = "Memory.json";

        public bool ShutdownWhenProcessExits = false;
        public bool UseCustomData = false;
        public bool AutomaticallyCheckAndDownloadUpdates = true;

        public OverlayConfig Overlay = new OverlayConfig();

        [PreserveCollectionIntegrity]
        public Dictionary<InputControl, Key> Keybinds = new Dictionary<InputControl, Key>()
        {
            { InputControl.ManipulateWidget, Key.LeftAlt },
            { InputControl.HideWidgets, Key.F1 },
            { InputControl.ToggleWidgests, Key.RightCtrl },
        };

        public DebugConfig Debug = new DebugConfig();
    }
}
