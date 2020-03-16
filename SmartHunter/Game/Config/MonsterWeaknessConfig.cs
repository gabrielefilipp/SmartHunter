using SmartHunter.Core;

namespace SmartHunter.Game.Config
{
    public enum WeaknessPreset
    {
Dragon,
Fire,
Ice,
Thunder,
Water
    }

    public class MonsterWeaknessConfig
    {
        public string Weakness = "";

        public MonsterWeaknessConfig()
        {
        }

        public MonsterWeaknessConfig(WeaknessPreset WeaknessPreset)
        {
            if (WeaknessPreset == WeaknessPreset.Dragon)
            {
                Weakness = Weakness + "Dragon ";
            }
            else if (WeaknessPreset == WeaknessPreset.Fire)
            {
                Weakness = Weakness + "Fire ";
            }
            else if (WeaknessPreset == WeaknessPreset.Ice)
            {
                Weakness = Weakness + "Ice ";
            }
            else if (WeaknessPreset == WeaknessPreset.Thunder)
            {
                Weakness = Weakness + "Thunder ";
            }
            else if (WeaknessPreset == WeaknessPreset.Water)
            {
                Weakness = Weakness + "Water ";
            }
        }

        public MonsterWeaknessConfig(string weakness)
        {
            Weakness = weakness;
        }
    }
}
