// Monster Size Differences
// https://docs.google.com/spreadsheets/d/1zoRCvF4qKUZCgMGQw3vdtjVS-laX7-px6k1oPCJMg5E

// Monster Crown Sizes
// https://docs.google.com/spreadsheets/d/1w4puqT7mlzG-Zfh1Ztgk0a35vmba-h-HW2o1G00qFA8

namespace SmartHunter.Game.Config
{
    public class MonsterConfig
    {
        public string NameStringId;
        public MonsterPartConfig[] Parts;
        public float BaseSize;
        public float ScaleModifier = 1f;
        public MonsterCrownConfig Crowns;
        public bool isElder = false;

        public MonsterConfig(string nameStringId, MonsterPartConfig[] parts, float baseSize, MonsterCrownConfig crowns, bool elder = false)
        {
            NameStringId = nameStringId;
            Parts = parts;
            BaseSize = baseSize;
            Crowns = crowns;
            isElder = elder;
        }
    }
}
