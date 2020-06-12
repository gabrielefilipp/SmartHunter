using SmartHunter.Game.Data;

namespace SmartHunter.Game.Config
{
    public partial class StatusEffectConfig
    {

        public string GroupId;
        public string NameStringId;
        public string TimerOffset;
        public MemorySource Source;
        public MemoryConditionConfig[] Conditions;
        public WeaponType WeaponType;

        public StatusEffectConfig() { }

        public StatusEffectConfig(string groupId, string nameStringId, MemorySource source, string timerOffset, params MemoryConditionConfig[] conditions)
        {
            GroupId = groupId;
            NameStringId = nameStringId;
            Source = source;
            TimerOffset = timerOffset;
            Conditions = conditions;
        }

        public StatusEffectConfig(string groupId, string nameStringId, MemorySource source, string timerOffset, WeaponType weaponType)
        {
            GroupId = groupId;
            NameStringId = nameStringId;
            Source = source;
            TimerOffset = timerOffset;
            WeaponType = weaponType;
        }
    }
}
