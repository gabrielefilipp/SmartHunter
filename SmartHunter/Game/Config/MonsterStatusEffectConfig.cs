namespace SmartHunter.Game.Config
{
    public class MonsterStatusEffectConfig
    {
        public string GroupId;
        public string NameStringId;

        public bool InvertBuildup;
        public bool InvertDuration;

        public MonsterStatusEffectConfig(string groupId, string nameStringId, bool invertBuildup = false, bool invertDuration = true)
        {
            GroupId = groupId;
            NameStringId = nameStringId;

            InvertBuildup = invertBuildup;
            InvertDuration = invertDuration;
        }
    }
}
