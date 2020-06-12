namespace SmartHunter.Game.Config
{
    public class MonsterPartConfig
    {
        public string GroupId;
        public string StringId;
        public bool IsRemovable;

        public MonsterPartConfig(string groupId, string stringId, bool isRemovable = false)
        {
            GroupId = groupId;
            StringId = stringId;
            IsRemovable = isRemovable;
        }
    }
}
