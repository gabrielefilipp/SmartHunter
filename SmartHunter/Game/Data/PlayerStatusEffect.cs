using SmartHunter.Core.Data;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Game.Data
{
    public class PlayerStatusEffect : Bindable
    {
        int m_Index;
        public int Index
        {
            get { return m_Index; }
            set
            {
                if (SetProperty(ref m_Index, value))
                {
                    NotifyPropertyChanged(nameof(GroupId));
                    NotifyPropertyChanged(nameof(Name));
                    NotifyPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public Progress Time { get; private set; }

        bool m_IsConditionPassed;
        public bool IsConditionPassed
        {
            get { return m_IsConditionPassed; }
            set
            {
                if (SetProperty(ref m_IsConditionPassed, value))
                {
                    NotifyPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public string GroupId
        {
            get
            {
                return GetGroupIdFromIndex(Index);
            }
        }

        public string Name
        {
            get
            {
                return LocalizationHelper.GetPlayerStatusEffectName(Index);
            }
        }

        public bool IsVisible
        {
            get
            {
                return IsIncluded(GroupId) && IsConditionPassed;
            }
        }

        public PlayerStatusEffect(int index, float? maxTime, float? currentTime, bool isConditionPassed)
        {
            m_Index = index;

            if (maxTime.HasValue && currentTime.HasValue)
            {
                Time = new Progress(maxTime.Value, currentTime.Value);
            }

            m_IsConditionPassed = isConditionPassed;
        }

        public static string GetGroupIdFromIndex(int index)
        {
            return ConfigHelper.PlayerData.Values.StatusEffects[index].GroupId;
        }

        public static bool IsIncluded(string groupId)
        {
            return ConfigHelper.Main.Values.Overlay.PlayerWidget.MatchIncludeStatusEffectGroupIdRegex(groupId);
        }
    }
}
