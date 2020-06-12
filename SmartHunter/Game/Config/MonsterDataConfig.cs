using System.Collections.Generic;

namespace SmartHunter.Game.Config
{
    public class MonsterDataConfig
    {
        public Dictionary<string, MonsterConfig> Monsters = new Dictionary<string, MonsterConfig>()
        {
            {
                "em001_00", // true
                new MonsterConfig("LOC_MONSTER_RATHIAN",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1754.37f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em001_01", // true
                new MonsterConfig("LOC_MONSTER_PINK_RATHIAN",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1754.37f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
			{
                "em001_02", // true
                new MonsterConfig("LOC_MONSTER_GOLD_RATHIAN",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1754.37f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em002_00", // true
                new MonsterConfig("LOC_MONSTER_RATHALOS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1704.22f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em002_01", // true
                new MonsterConfig("LOC_MONSTER_AZURE_RATHALOS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1704.22f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
			{
                "em002_02", // true
                new MonsterConfig("LOC_MONSTER_SILVER_RATHALOS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1704.22f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em007_00", // true
                new MonsterConfig("LOC_MONSTER_DIABLOS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2096.25f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em007_01", // true
                new MonsterConfig("LOC_MONSTER_BLACK_DIABLOS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2096.25f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em011_00", // true
                new MonsterConfig("LOC_MONSTER_KIRIN",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS")
                    },
                    536.26f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            { // true
                "em018_00",
                new MonsterConfig("LOC_MONSTER_YIAN_GARUGA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1389.01f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em018_05",
                new MonsterConfig("LOC_MONSTER_SCARRED_YIAN_GARUGA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1389.01f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em023_00",
                new MonsterConfig("LOC_MONSTER_RAJANG",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Removable", "LOC_PART_UKNOWN", true),
                    },
                    829.11f,
                    new MonsterCrownConfig(CrownPreset.Rajang)
                )
            },
            {
                "em023_05",
                new MonsterConfig("LOC_MONSTER_FURIOUS_RAJANG",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS_2", true),
                        new MonsterPartConfig("Removable", "LOC_PART_UKNOWN", true),
                    },
                    829.11f,
                    new MonsterCrownConfig(CrownPreset.Rajang)
                )
            },
            { // true
                "em024_00",
                new MonsterConfig("LOC_MONSTER_KUSHALA_DAORA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_LIMBS_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LIMBS_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WINGS")
                    },
                    1913.13f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            { // true
                "em026_00",
                new MonsterConfig("LOC_MONSTER_LUNASTRA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LIMBS"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1828.69f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            { // true
                "em027_00",
                new MonsterConfig("LOC_MONSTER_TEOSTRA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_WINGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1790.15f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            {
                "em032_00",
                new MonsterConfig("LOC_MONSTER_TIGREX",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1943.2f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em032_01",
                new MonsterConfig("LOC_MONSTER_BRUTE_TIGREX",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1943.2f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em036_00",
                new MonsterConfig("LOC_MONSTER_LAVASIOTH",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ABDOMEN"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1797.24f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em037_00",
                new MonsterConfig("LOC_MONSTER_NARGACUGA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1914.74f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em042_00",
                new MonsterConfig("LOC_MONSTER_BARIOTH",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2098.3f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em043_00",
                new MonsterConfig("LOC_MONSTER_DEVILJHO",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST"),
                        new MonsterPartConfig("Part", "LOC_PART_REAR"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2063.82f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em043_05",
                new MonsterConfig("LOC_MONSTER_SAVAGE_DEVILJHO",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST"),
                        new MonsterPartConfig("Part", "LOC_PART_REAR"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2063.82f,
                    new MonsterCrownConfig(CrownPreset.Savage)
                )
            },
            { // true
                "em044_00",
                new MonsterConfig("LOC_MONSTER_BARROTH",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HEAD", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL_MUD")
                    },
                    1383.07f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em045_00",
                new MonsterConfig("LOC_MONSTER_URAGAAN",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_JAW"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2058.63f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em057_00",
                new MonsterConfig("LOC_MONSTER_ZINOGRE",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1743.49f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em063_00",
                new MonsterConfig("LOC_MONSTER_BRACHYDIOS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1630.55f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em063_05",
                new MonsterConfig("LOC_MONSTER_RAGING_BRACHYDIOS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                    },
                    2282.77f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            {
                "em057_01",
                new MonsterConfig("LOC_MONSTER_STYGIAN_ZINOGRE",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1743.49f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em080_00",
                new MonsterConfig("LOC_MONSTER_GLAVENUS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_FIN"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2461.5f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em080_01",
                new MonsterConfig("LOC_MONSTER_ACIDIC_GLAVENUS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_FIN"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2372.44f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em100_00",
                new MonsterConfig("LOC_MONSTER_ANJANATH",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1646.46f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em100_01",
                new MonsterConfig("LOC_MONSTER_ANJANATH_FULGUR",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1646.46f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em101_00",
                new MonsterConfig("LOC_MONSTER_GREAT_JAGRAS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_ABDOMEN")
                    },
                    1109.66f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em102_00",
                new MonsterConfig("LOC_MONSTER_PUKEI_PUKEI",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1102.45f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em102_01",
                new MonsterConfig("LOC_MONSTER_PUKEI_PUKEI_CORAL",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1102.45f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em103_00",
                new MonsterConfig("LOC_MONSTER_NERGIGANTE",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HORNS"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1848.12f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            { // true
                "em103_05",
                new MonsterConfig("LOC_MONSTER_RUINER_NERGIGANTE",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HORNS"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1848.12f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            {
                "em104_00",
                new MonsterConfig("LOC_MONSTER_SAFI_JIIVA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ABDOMEN"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_NECK"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                    },
                    4799.78f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em105_00",
                new MonsterConfig("LOC_MONSTER_XENO_JIIVA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_NECK"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST"),
                        new MonsterPartConfig("Part", "LOC_PART_HAND_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_HAND_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_FOOT_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_FOOT_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WINGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    4509.1f,
                    null,
                    true
                )
            },
            { // true
                "em106_00",
                new MonsterConfig("LOC_MONSTER_ZORAH_MAGDAROS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_SHELL"),
                        new MonsterPartConfig("Part", "LOC_PART_EXHAUST_ORGAN_CENTRAL"),
                        new MonsterPartConfig("Part", "LOC_PART_EXHAUST_ORGAN_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_EXHAUST_ORGAN_CRATER"),
                        new MonsterPartConfig("Part", "LOC_PART_EXHAUST_ORGAN_REAR"),
                        new MonsterPartConfig("Part", "LOC_PART_WEAK_SHELL_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WEAK_SHELL_RIGHT")
                    },
                    25764.59f,
                    null,
                    true
                )
            },
            { // true
                "em107_00",
                new MonsterConfig("LOC_MONSTER_KULU_YA_KU",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_ROCK")
                    },
                    901.24f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em108_00",
                new MonsterConfig("LOC_MONSTER_JYURATODUS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT_MUD"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL_MUD")
                    },
                    1508.71f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em109_00",
                new MonsterConfig("LOC_MONSTER_TOBI_KADACHI",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_MANE"),
                        new MonsterPartConfig("Part", "LOC_PART_ABDOMEN"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1300.52f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em109_01",
                new MonsterConfig("LOC_MONSTER_VIPER_TOBI_KADACHI",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_MANE"),
                        new MonsterPartConfig("Part", "LOC_PART_ABDOMEN"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1300.52f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em110_00",
                new MonsterConfig("LOC_MONSTER_PAOLUMU",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_BALOON", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BALLOON"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1143.36f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em110_01",
                new MonsterConfig("LOC_MONSTER_PAOLUMU_NIGHTSHADE",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_BALOON", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BALLOON"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1143.36f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em111_00",
                new MonsterConfig("LOC_MONSTER_LEGIANA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1699.75f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em111_05",
                new MonsterConfig("LOC_MONSTER_SHRIEKING_LEGIANA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1831.69f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em112_00",
                new MonsterConfig("LOC_MONSTER_GREAT_GIRROS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1053.15f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em113_00",
                new MonsterConfig("LOC_MONSTER_ODOGARON",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1388.75f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em113_01",
                new MonsterConfig("LOC_MONSTER_EBONY_ODOGARON",
                    new MonsterPartConfig[]
                    {
                       new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1388.75f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em114_00",
                new MonsterConfig("LOC_MONSTER_RADOBAAN",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_JAW"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_BONE_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_BONE_RIGHT")
                    },
                    1803.47f,
                    new MonsterCrownConfig(CrownPreset.Alternate)
                )
            },
            { // true
                "em115_00",
                new MonsterConfig("LOC_MONSTER_VAAL_HAZAK",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WINGS")
                    },
                    2095.4f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            { // true
                "em115_05",
                new MonsterConfig("LOC_MONSTER_BLACKVEIL_VAAL_HAZAK",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_WINGS")
                    },
                    2095.4f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            { // true
                "em116_00",
                new MonsterConfig("LOC_MONSTER_DODOGAMA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1111.11f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em117_00",
                new MonsterConfig("LOC_MONSTER_KULVE_TAROTH",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS_2", true),
                        new MonsterPartConfig("Part", "LOC_PART_HORNS"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LIMBS_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LIMBS_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_HORNS_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_MANE_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST_LEFT_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_CHEST_RIGHT_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL_LEFT_GOLD"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL_RIGHT_GOLD")
                    },
                    4573.25f,
                    null,
                    true
                )
            },
            { // true
                "em118_00",
                new MonsterConfig("LOC_MONSTER_BAZELGEUSE",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1928.38f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em118_05",
                new MonsterConfig("LOC_MONSTER_SEETHING_BAZELGEUSE",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    1928.38f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em120_00",
                new MonsterConfig("LOC_MONSTER_TZITZI_YA_KU",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    894.04f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em121_00",
                new MonsterConfig("LOC_MONSTER_BEHEMOTH",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HORNS"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    3423.65f,
                    null,
                    true
                )
            },
            { // true
                "em122_00",
                new MonsterConfig("LOC_MONSTER_BEOTODUS",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD_SNOW"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY_SNOW"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL_SNOW")
                    },
                    1661.99f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em123_00",
                new MonsterConfig("LOC_MONSTER_BANBARO",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HORNS", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HORNS"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_LEG_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2404.84f,
                    new MonsterCrownConfig(CrownPreset.Standard)
                )
            },
            { // true
                "em124_00",
                new MonsterConfig("LOC_MONSTER_VELKHANA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD_ICE"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY_ICE"),
                        new MonsterPartConfig("Part", "LOC_PART_WINGS"),
                        new MonsterPartConfig("Part", "LOC_PART_WINGS_ICE"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS_ICE"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS_ICE"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL_ICE")
                    },
                    2596.05f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            { // true
                "em125_00",
                new MonsterConfig("LOC_MONSTER_NAMIELLE",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_TAIL", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BACK"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_WINGS")
                    },
                    2048.25f,
                    new MonsterCrownConfig(CrownPreset.Standard),
                    true
                )
            },
            { // true
                "em126_00",
                new MonsterConfig("LOC_MONSTER_SHARA_ISHVALDA",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_HEAD", true),
                        new MonsterPartConfig("Part", "LOC_PART_NECK_LEFT_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_NECK_RIGHT_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS_ROCK"),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_WING_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_LEFT"),
                        new MonsterPartConfig("Part", "LOC_PART_ARM_RIGHT"),
                        new MonsterPartConfig("Part", "LOC_PART_TAIL")
                    },
                    2910.91f,
                    null,
                    true
                )
            },
            { // true
                "em127_00",
                new MonsterConfig("LOC_MONSTER_LESHEN",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_ANTLER_LEFT", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_ANTLER_RIGHT", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_4"),
                        new MonsterPartConfig("Part", "LOC_5"),
                        new MonsterPartConfig("Part", "LOC_JAGRAS_SUMMONER")
                    },
                    549.70f,
                    null,
                    true
                )
            },
            { // true
                "em127_01",
                new MonsterConfig("LOC_MONSTER_ANCIENT_LESHEN",
                    new MonsterPartConfig[]
                    {
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_ANTLER_LEFT", true),
                        new MonsterPartConfig("Removable", "LOC_REMOVABLE_PART_ANTLER_RIGHT", true),
                        new MonsterPartConfig("Part", "LOC_PART_HEAD"),
                        new MonsterPartConfig("Part", "LOC_PART_BODY"),
                        new MonsterPartConfig("Part", "LOC_PART_LEGS"),
                        new MonsterPartConfig("Part", "LOC_PART_ARMS"),
                        new MonsterPartConfig("Part", "LOC_4"),
                        new MonsterPartConfig("Part", "LOC_5"),
                        new MonsterPartConfig("Part", "LOC_JAGRAS_SUMMONER")
                    },
                    633.81f,
                    null,
                    true
                )
            }
        };
        /*
        public MonsterStatusEffectConfig[] StatusEffects =
        {
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_POISON",       "08", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_PARALYSIS",    "10", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_SLEEP",        "18", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_BLAST",        "20", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_MOUNT",        "28", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_EXHAUST",      "30", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_STUN",         "38", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_TRANQUILIZE",  "40", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_FLASH",        "48", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_KNOW_DOWN",    "48", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_DUNG",         "58", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_SHOCK_TRAP",   "68", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_PITFALL_TRAP", "70", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_ELDERSEAL",    "88", "15C", "178", "17C", "1A4", "1A8"),
            new MonsterStatusEffectConfig("Rage",         "LOC_STATUS_EFFECT_RAGE",         null, "190", "180", "1A0", "18C", "198"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_FATIGUE",      null, "42C", "420", "424", "430",  null, true)
        };
        */

        public MonsterStatusEffectConfig[] StatusEffects =
        {
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_0"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_POISON"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_PARALYSIS"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_SLEEP"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_BLAST"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_MOUNT"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_EXHAUST"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_STUN"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_TRANQUILIZE"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_FLASH"), // 9
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_FLASH"), // 10
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_KNOW_DOWN"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_DUNG"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_13"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_SHOCK_TRAP"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_PITFALL_TRAP"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_16"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_17"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_ELDERSEAL"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_SMOKING"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_20"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_FELVYNE_KNOCK_DOWN_TRAP"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_CLAW_ATTACK", true),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_STATUS_EFFECT_VIOLATED"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_24"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_25"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_26"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_27"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_28"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_29"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_30"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_31"),
            new MonsterStatusEffectConfig("StatusEffect", "LOC_PART_32"),

            new MonsterStatusEffectConfig("Rage", "LOC_STATUS_EFFECT_RAGE"),
            new MonsterStatusEffectConfig("Stamina", "LOC_STATUS_EFFECT_STAMINA"),
            new MonsterStatusEffectConfig("Fatigue", "LOC_STATUS_EFFECT_FATIGUE"),
        };
    }
}
