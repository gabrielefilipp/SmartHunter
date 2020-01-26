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

        public MonsterConfig(string nameStringId, MonsterPartConfig[] parts, float baseSize, float scaleModifier, MonsterCrownConfig crowns)
        {
            NameStringId = nameStringId;
            //Parts = parts;
            /*
            parts = new MonsterPartConfig[16];

            for (int i = 0; i < 16; i++)
            {
                parts[i] = new MonsterPartConfig("Part", $"LOC_PART_{i}");
            }
            */
            Parts = parts;


            BaseSize = baseSize;
            ScaleModifier = scaleModifier;
            Crowns = crowns;
        }
    }
}
