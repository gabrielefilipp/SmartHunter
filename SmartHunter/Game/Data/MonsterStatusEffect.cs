using System.ComponentModel;
using SmartHunter.Core.Data;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Game.Data
{
    public class MonsterStatusEffect : TimedVisibility
    {
        Monster m_Owner;

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

        public ulong Address;

        public string GroupId
        {
            get
            {
                return GetGroupIdFromIndex(Index);
            }
        }

        public Progress Buildup { get; private set; }
        public Progress Duration { get; private set; }

        int m_TimesActivatedCount;
        public int TimesActivatedCount
        {
            get { return m_TimesActivatedCount; }
            set { SetProperty(ref m_TimesActivatedCount, value); }
        }

        public string Name
        {
            get
            {
                return LocalizationHelper.GetMonsterStatusEffectName(Index);
            }
        }

        public bool IsVisible
        {
            get
            {
                return IsIncluded(GroupId) && IsTimeVisible(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects, ConfigHelper.Main.Values.Overlay.MonsterWidget.HideStatusEffectsAfterSeconds);
            }
        }

        public MonsterStatusEffect(Monster owner, ulong address, int index, float maxBuildup, float currentBuildup, float maxDuration, float currentDuration, int timesActivatedCount)
        {
            m_Owner = owner;
            Address = address;
            m_Index = index;
            Buildup = new Progress(maxBuildup, currentBuildup, true);
            Duration = new Progress(maxDuration, currentDuration, true);
            m_TimesActivatedCount = timesActivatedCount;

            PropertyChanged += MonsterStatusEffect_PropertyChanged;
            Buildup.PropertyChanged += Bar_PropertyChanged;
            Duration.PropertyChanged += Bar_PropertyChanged;
        }

        private void MonsterStatusEffect_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TimesActivatedCount))
            {
                UpdateLastChangedTime();
            }
        }

        private void Bar_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateLastChangedTime();
        }

        public static string GetGroupIdFromIndex(int index)
        {
            return ConfigHelper.MonsterData.Values.StatusEffects[index].GroupId;
        }

        public static bool IsIncluded(string groupId)
        {
            return ConfigHelper.Main.Values.Overlay.MonsterWidget.MatchIncludeStatusEffectGroupIdRegex(groupId);
        }
    }
}
