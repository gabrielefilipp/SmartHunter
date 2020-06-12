using System.ComponentModel;

namespace SmartHunter.Game.Config
{
    public class MonsterCrownConfig
    {
        public float Mini;
        public float Silver;
        public float Gold;

        public MonsterCrownConfig(CrownPreset crownPreset)
        {
            switch (crownPreset)
            {
                case CrownPreset.Standard:
                    Mini = 0.9f;
                    Silver = 1.15f;
                    Gold = 1.23f;
                    break;
                case CrownPreset.Alternate:
                    Mini = 0.9f;
                    Silver = 1.1f;
                    Gold = 1.2f;
                    break;
                case CrownPreset.Savage:
                    Mini = 0.99f;
                    Silver = 1.14f;
                    Gold = 1.2f;
                    break;
                case CrownPreset.Rajang:
                    Mini = 0.9f;
                    Silver = 1.11f;
                    Gold = 1.18f;
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(crownPreset), (int)crownPreset, typeof(CrownPreset));
            }
        }
    }
}
