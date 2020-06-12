using System.ComponentModel;
using System.Linq;
using SmartHunter.Core.Data;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Game.Data
{
    public class MonsterPart : TimedVisibility
    {
        Monster m_Owner;
        public ulong Address { get; private set; }

        bool m_IsRemovable;
        public bool IsRemovable
        {
            get { return m_IsRemovable; }
            set { SetProperty(ref m_IsRemovable, value); }
        }

        public Progress Health { get; private set; }

        int m_TimesBrokenCount;
        public int TimesBrokenCount
        {
            get { return m_TimesBrokenCount; }
            set { SetProperty(ref m_TimesBrokenCount, value); }
        }

        public string Name
        {
            get
            {
                return LocalizationHelper.GetMonsterPartName(m_Owner.Id, m_Owner.Parts.Where(part => part.IsRemovable == IsRemovable).ToList().IndexOf(this), IsRemovable);
            }
        }

        public string GroupId
        {
            get
            {
                return GetGroupIdFromIndex(m_Owner.Id, m_Owner.Parts.Where(part => part.IsRemovable == IsRemovable).ToList().IndexOf(this), IsRemovable);
            }
        }

        public bool IsVisible
        {
            get
            {
                return IsIncluded(GroupId) && IsTimeVisible(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts, ConfigHelper.Main.Values.Overlay.MonsterWidget.HidePartsAfterSeconds);
            }
        }

        public MonsterPart(Monster owner, ulong address, bool isRemovable, float maxHealth, float currentHealth, int timesBrokenCount)
        {
            m_Owner = owner;
            Address = address;
            m_IsRemovable = isRemovable;
            Health = new Progress(maxHealth, currentHealth);
            m_TimesBrokenCount = timesBrokenCount;

            PropertyChanged += MonsterPart_PropertyChanged;
            Health.PropertyChanged += Health_PropertyChanged;
        }

        private void MonsterPart_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TimesBrokenCount))
            {
                UpdateLastChangedTime();
            }
        }

        private void Health_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Progress.Current))
            {
                UpdateLastChangedTime();
            }
        }

        public static string GetGroupIdFromIndex(string monsterId, int index, bool isRemovable)
        {
            if (ConfigHelper.MonsterData.Values.Monsters.TryGetValue(monsterId, out var monsterConfig))
            {
                var parts = monsterConfig.Parts.Where(part => part.IsRemovable == isRemovable);
                if (parts.Count() > index)
                {
                    return parts.ElementAt(index).GroupId;
                }
            }

            return "";
        }

        public static bool IsIncluded(string groupId)
        {
            return ConfigHelper.Main.Values.Overlay.MonsterWidget.MatchIncludePartGroupIdRegex(groupId);
        }
    }
}
