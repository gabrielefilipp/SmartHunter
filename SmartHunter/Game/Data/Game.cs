using SmartHunter.Core.Data;

namespace SmartHunter.Game.Data
{
    public class Game : Bindable
    {
        public bool IsValid = false;

        string m_SessionHostPlayerName = "";
        public string SessionHostPlayerName
        {
            get { return m_SessionHostPlayerName; }
            set
            {
                if (SetProperty(ref m_SessionHostPlayerName, value))
                {
                    NotifyPropertyChanged(nameof(SessionHostPlayerName));
                }
            }
        }

        string m_LobbyHostPlayerName = "";
        public string LobbyHostPlayerName
        {
            get { return m_LobbyHostPlayerName; }
            set
            {
                if (SetProperty(ref m_LobbyHostPlayerName, value))
                {
                    NotifyPropertyChanged(nameof(LobbyHostPlayerName));
                }
            }
        }

        string m_SessionID = "";
        public string SessionID
        {
            get { return m_SessionID; }
            set
            {
                if (SetProperty(ref m_SessionID, value))
                {
                    NotifyPropertyChanged(nameof(SessionID));
                }
            }
        }

        string m_LobbyID = "";
        public string LobbyID
        {
            get { return m_LobbyID; }
            set
            {
                if (SetProperty(ref m_LobbyID, value))
                {
                    NotifyPropertyChanged(nameof(LobbyID));
                }
            }
        }

        string m_CurrentPlayerName = "";
        public string CurrentPlayerName
        {
            get { return m_CurrentPlayerName; }
            set
            {
                if (SetProperty(ref m_CurrentPlayerName, value))
                {
                    NotifyPropertyChanged(nameof(CurrentPlayerName));
                }
            }
        }

        string m_CurrentWeaponString = "";
        public string CurrentWeaponString
        {
            get { return m_CurrentWeaponString; }
            set
            {
                if (SetProperty(ref m_CurrentWeaponString, value))
                {
                    NotifyPropertyChanged(nameof(CurrentWeaponString));
                    NotifyPropertyChanged(nameof(EquippedWeaponType));
                }
            }
        }
        public WeaponType EquippedWeaponType
        {
            get
            {
                return CurrentEquippedWeaponType();
            }
        }

        public int LobbyPlayerCount
        {
            get
            {
                return ViewModels.OverlayViewModel.Instance.TeamWidget.Context.Players.Count;
            }
        }

        public bool IsPlayerOnline()
        {
            return SessionID.Length > 0;
        }

        public bool IsPlayerInLobby()
        {
            return LobbyID.Length > 0;
        }

        public bool IsCurrentPlayerSessionHost()
        {
            return CurrentPlayerName.Equals(SessionHostPlayerName) || SessionHostPlayerName.Length == 0 || CurrentPlayerName.Length == 0;
        }

        public bool IsCurrentPlayerLobbyHost()
        {
            return CurrentPlayerName.Equals(LobbyHostPlayerName) || LobbyHostPlayerName.Length == 0 || CurrentPlayerName.Length == 0;
        }

        public bool IsPlayerAlone()
        {
            return LobbyPlayerCount == 1 || !IsPlayerOnline();
        }

        public WeaponType CurrentEquippedWeaponType()
        {
            if (CurrentWeaponString.Equals(""))
            {
                return WeaponType.NO_WEAPON;
            }
            if (CurrentWeaponString.Contains("wp11") || CurrentWeaponString.Contains("bow"))
            {
                return WeaponType.BOW;
            }
            if (CurrentWeaponString.Contains("wp09") || CurrentWeaponString.Contains("caxe"))
            {
                return WeaponType.CHARGE_BLADE;
            }
            if (CurrentWeaponString.Contains("wp07") || CurrentWeaponString.Contains("gun"))
            {
                return WeaponType.GUNLANCE;
            }
            if (CurrentWeaponString.Contains("wp04") || CurrentWeaponString.Contains("ham"))
            {
                return WeaponType.HAMMER;
            }
            if (CurrentWeaponString.Contains("wp12") || CurrentWeaponString.Contains("hbg"))
            {
                return WeaponType.HEAVY_BOWGUN;
            }
            if (CurrentWeaponString.Contains("wp05") || CurrentWeaponString.Contains("hue"))
            {
                return WeaponType.HUNTING_HORN;
            }
            if (CurrentWeaponString.Contains("wp06") || CurrentWeaponString.Contains("lan"))
            {
                return WeaponType.LANCE;
            }
            if (CurrentWeaponString.Contains("wp13") || CurrentWeaponString.Contains("lbg"))
            {
                return WeaponType.LIGHT_BOWGUN;
            }
            if (CurrentWeaponString.Contains("wp10") || CurrentWeaponString.Contains("rod"))
            {
                return WeaponType.INSECT_GLAIVE;
            }
            if (CurrentWeaponString.Contains("mus"))
            {
                return WeaponType.KINSECT;
            }
            if (CurrentWeaponString.Contains("wp01") || CurrentWeaponString.Contains("one"))
            {
                return WeaponType.SWORD_AND_SHIELD;
            }
            if (CurrentWeaponString.Contains("wp08") || CurrentWeaponString.Contains("saxe"))
            {
                return WeaponType.SWITCH_AXE;
            }
            if (CurrentWeaponString.Contains("wp02") || CurrentWeaponString.Contains("sou"))
            {
                return WeaponType.DUAL_BLADES;
            }
            if (CurrentWeaponString.Contains("wp03") || CurrentWeaponString.Contains("swo"))
            {
                return WeaponType.LONG_SWORD;
            }
            if (CurrentWeaponString.Contains("wp00") || CurrentWeaponString.Contains("two"))
            {
                return WeaponType.GREAT_SWORD;
            }
            if (CurrentWeaponString.Contains("slg"))
            {
                return WeaponType.SLINGER;
            }
            return WeaponType.WEAPON_UNKNOWN;
        }
    }
}
