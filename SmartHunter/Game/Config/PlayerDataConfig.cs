using SmartHunter.Game.Data;

namespace SmartHunter.Game.Config
{
    public class PlayerDataConfig
    {
        private static string indexToHexStr(int index, ulong baseOffset)
        {
            var prefix = "";
            if (index < 0)
            {
                index = (-1) * index;
                prefix = "-";
            }
            ulong multiplier = 0x4;
            var hex = baseOffset + (multiplier * (ulong)index);
            return $"{prefix}{hex.ToString("X")}";
        }

        private static string indexToHexStrMantles(int index) => indexToHexStr(index, 0xEFC);
        private static string indexToHexStrMantlesRecharging(int index) => indexToHexStr(index, 0xEAC);
        private static string indexToHexStrNoOffset(int index) => indexToHexStr(index, 0x0);

        public StatusEffectConfig[] StatusEffects =
        {
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_SELF_IMPROVEMENT", MemorySource.Base, indexToHexStrNoOffset(14)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ATTACK_UP_S", MemorySource.Base,indexToHexStrNoOffset(15)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ATTACK_UP_L", MemorySource.Base, indexToHexStrNoOffset(16)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_HEALTH_BOOST_S", MemorySource.Base, indexToHexStrNoOffset(17)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_HEALTH_BOOST_L", MemorySource.Base, indexToHexStrNoOffset(18)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_STAMINA_USE_REDUCED_S", MemorySource.Base, indexToHexStrNoOffset(19)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_STAMINA_USE_REDUCED_L", MemorySource.Base, indexToHexStrNoOffset(20)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_WIND_PRESSURE_NEGATED", MemorySource.Base, indexToHexStrNoOffset(21)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ALL_WIND_PRESSURE_NEGATED", MemorySource.Base, indexToHexStrNoOffset(22)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DEFENSE_UP_S", MemorySource.Base, indexToHexStrNoOffset(23)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DEFENSE_UP_L", MemorySource.Base, indexToHexStrNoOffset(24)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_TOOL_USE_DRAIN_REDUCED_S", MemorySource.Base, indexToHexStrNoOffset(25)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_TOOL_USE_DRAIN_REDUCED_L", MemorySource.Base, indexToHexStrNoOffset(26)),

            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_HEALTH_RECOVERY_S", MemorySource.Base, indexToHexStrNoOffset(32)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_HEALTH_RECOVERY_L", MemorySource.Base, indexToHexStrNoOffset(33)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_EARPLUGS_S", MemorySource.Base, indexToHexStrNoOffset(34)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_EARPLUGS_L", MemorySource.Base, indexToHexStrNoOffset(35)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DIVINE_PROTECTION", MemorySource.Base, indexToHexStrNoOffset(36)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_SCOUTFLY_POWER_UP", MemorySource.Base, indexToHexStrNoOffset(37)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ENVIRONMENTAL_DAMAGE_NEGATED", MemorySource.Base, indexToHexStrNoOffset(38)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_STUN_NEGATED", MemorySource.Base, indexToHexStrNoOffset(39)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_PARALYSIS_NEGATED", MemorySource.Base, indexToHexStrNoOffset(40)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_TREMORS_NEGATED", MemorySource.Base, indexToHexStrNoOffset(41)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_MUCK_RESISTANCE", MemorySource.Base, indexToHexStrNoOffset(42)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_FIRE_RESISTANCE_BOOST_S", MemorySource.Base, indexToHexStrNoOffset(43)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_FIRE_RESISTANCE_BOOST_L", MemorySource.Base, indexToHexStrNoOffset(44)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_WATER_RESISTANCE_BOOST_S", MemorySource.Base, indexToHexStrNoOffset(45)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_WATER_RESISTANCE_BOOST_L", MemorySource.Base, indexToHexStrNoOffset(46)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_THUNDER_RESISTANCE_BOOST_S", MemorySource.Base, indexToHexStrNoOffset(47)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_THUNDER_RESISTANCE_BOOST_L", MemorySource.Base, indexToHexStrNoOffset(48)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ICE_RESISTANCE_BOOST_S", MemorySource.Base, indexToHexStrNoOffset(49)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ICE_RESISTANCE_BOOST_L", MemorySource.Base, indexToHexStrNoOffset(50)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DRAGON_RESISTANCE_BOOST_S", MemorySource.Base, indexToHexStrNoOffset(51)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DRAGON_RESISTANCE_BOOST_L", MemorySource.Base, indexToHexStrNoOffset(52)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ELEMENTAL_ATTACK_BOOST", MemorySource.Base, indexToHexStrNoOffset(53)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_BLIGHT_NEGATED", MemorySource.Base, indexToHexStrNoOffset(54)),

            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_KNOCKBACKS_NEGATED", MemorySource.Base, indexToHexStrNoOffset(57)),

            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_BLIGHT_RESISTANCE_UP", MemorySource.Base, indexToHexStrNoOffset(59)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_AFFINITY_UP", MemorySource.Base, indexToHexStrNoOffset(60)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ALL_AILMENTS_NEGATED", MemorySource.Base, indexToHexStrNoOffset(61)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_WIND_PRESSURE_NEGATED_AND_EARPLUGS_S", MemorySource.Base, indexToHexStrNoOffset(62)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ABNORMAL_STATUS_ATTACK_INCREASED", MemorySource.Base, indexToHexStrNoOffset(63)),

            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_MAX_STAM_UP_REC",  MemorySource.Base, indexToHexStrNoOffset(67)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_EXT_HEALTH_REC", MemorySource.Base, indexToHexStrNoOffset(68)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_SPEED_BOOST_EVADE_UP", MemorySource.Base, indexToHexStrNoOffset(69)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ELE_EFF_UP", MemorySource.Base, indexToHexStrNoOffset(70)),

            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_RESUSCITATE", MemorySource.Base, indexToHexStrNoOffset(71)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_ATTACK_UP_S", MemorySource.Base, indexToHexStrNoOffset(72)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_ATTACK_UP_L", MemorySource.Base, indexToHexStrNoOffset(73)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_DEFENSE_UP_S", MemorySource.Base, indexToHexStrNoOffset(74)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_DEFENSE_UP_L", MemorySource.Base, indexToHexStrNoOffset(75)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_AFFINITY_UP", MemorySource.Base, indexToHexStrNoOffset(76)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_HEALTH_RECOVERY", MemorySource.Base, indexToHexStrNoOffset(77)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_HEALTH_BOOST", MemorySource.Base, indexToHexStrNoOffset(78)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_STAMINA_USE_REDUCED", MemorySource.Base, indexToHexStrNoOffset(79)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_DIVINE_PROTECTION", MemorySource.Base, indexToHexStrNoOffset(82)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_STUN_NEGATED", MemorySource.Base, indexToHexStrNoOffset(83)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_PARALYSIS_NEGATED", MemorySource.Base, indexToHexStrNoOffset(84)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_TREMORS_NEGATED", MemorySource.Base, indexToHexStrNoOffset(85)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_EARPLUGS_S", MemorySource.Base, indexToHexStrNoOffset(86)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_WIND_PRESSURE_NEGATED", MemorySource.Base, indexToHexStrNoOffset(87)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_ENVIRONMENTAL_DAMAGE_NEGATED", MemorySource.Base, indexToHexStrNoOffset(88)),

            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_POISON", MemorySource.Base, indexToHexStrNoOffset(375)),

            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_NOXIOUS_POISON", MemorySource.Base, indexToHexStrNoOffset(376)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_FIREBLIGHT", MemorySource.Base, indexToHexStrNoOffset(379)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_THUNDERBLIGHT", MemorySource.Base, indexToHexStrNoOffset(380)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_WATERBLIGHT", MemorySource.Base, indexToHexStrNoOffset(381)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_ICEBLIGHT", MemorySource.Base, indexToHexStrNoOffset(382)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_DRAGONBLIGHT", MemorySource.Base, indexToHexStrNoOffset(383)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_BLEEDING", MemorySource.Base, indexToHexStrNoOffset(384)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_BLEEDING_RECOVERY", MemorySource.Base, indexToHexStrNoOffset(385)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_EFFLUVIA", MemorySource.Base, indexToHexStrNoOffset(386)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_DEFENSE_DOWN", MemorySource.Base, indexToHexStrNoOffset(387)),

            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_ELEMENTAL_RESISTANCE_DOWN", MemorySource.Base, indexToHexStrNoOffset(389)),

            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_NO_ITEMS", MemorySource.Base, indexToHexStrNoOffset(391)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_BLASTBLIGHT", MemorySource.Base, indexToHexStrNoOffset(392)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_BLASTSCOURGE", MemorySource.Base, indexToHexStrNoOffset(432)),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_DASH_JUICE", MemorySource.Base, indexToHexStrNoOffset(420)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_WIGGLY_LITCHI", MemorySource.Base, indexToHexStrNoOffset(421)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_IMMUNIZER", MemorySource.Base, indexToHexStrNoOffset(422)),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_DEMON_POWDER", MemorySource.Base, indexToHexStrNoOffset(433)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_HARDSHELL_POWDER", MemorySource.Base, indexToHexStrNoOffset(434)),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_MIGHT_SEED", MemorySource.Base, indexToHexStrNoOffset(424), new MemoryConditionConfig(10, indexToHexStrNoOffset(425))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_MIGHT_PILL", MemorySource.Base, indexToHexStrNoOffset(424), new MemoryConditionConfig(25, indexToHexStrNoOffset(425))),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_ADAMANT_SEED", MemorySource.Base, indexToHexStrNoOffset(428), new MemoryConditionConfig(20, indexToHexStrNoOffset(429))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_ADAMANT_PILL", MemorySource.Base, indexToHexStrNoOffset(428), new MemoryConditionConfig(0, indexToHexStrNoOffset(429))),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_DEMONDRUG", MemorySource.Base, null, new MemoryConditionConfig(1, indexToHexStrNoOffset(437))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_MEGA_DEMONDRUG", MemorySource.Base, null, new MemoryConditionConfig(2, indexToHexStrNoOffset(437))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_ARMORSKIN", MemorySource.Base, null, new MemoryConditionConfig(1, indexToHexStrNoOffset(438))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_MEGA_ARMORSKIN", MemorySource.Base, null, new MemoryConditionConfig(2, indexToHexStrNoOffset(438))),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_HOT_SPRING_HEALTH_RECOVERY", MemorySource.Base, indexToHexStrNoOffset(446)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_HOT_SPRING_CLODPROOF", MemorySource.Base, indexToHexStrNoOffset(447)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_POWERCONE_ATTACK_UP", MemorySource.Base, indexToHexStrNoOffset(454)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_THAWPUFFS_ICEPROOF", MemorySource.Base, indexToHexStrNoOffset(455)),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_COOL_DRINK", MemorySource.Base, indexToHexStrNoOffset(443)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_HOT_DRINK", MemorySource.Base, indexToHexStrNoOffset(444)),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_PROTECTIVE_POLISH", MemorySource.Base, indexToHexStrNoOffset(475)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_AFFINITY_SLIDING", MemorySource.Base, indexToHexStrNoOffset(476)),

            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_GHILLIE", MemorySource.Equipment, indexToHexStrMantles(0)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_TEMPORAL", MemorySource.Equipment, indexToHexStrMantles(1)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_HEALTH_BOOSTER", MemorySource.Equipment, indexToHexStrMantles(2)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_ROCKSTEADY", MemorySource.Equipment, indexToHexStrMantles(3)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_CHALLENGER", MemorySource.Equipment, indexToHexStrMantles(4)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_VITALITY", MemorySource.Equipment, indexToHexStrMantles(5)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_FIREPROOF", MemorySource.Equipment, indexToHexStrMantles(6)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_WATERPROOF", MemorySource.Equipment, indexToHexStrMantles(7)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_ICEPROOF", MemorySource.Equipment, indexToHexStrMantles(8)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_THUNDERPROOF", MemorySource.Equipment, indexToHexStrMantles(9)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_DRAGONPROOF", MemorySource.Equipment, indexToHexStrMantles(10)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_CLEANSER_BOOSTER", MemorySource.Equipment, indexToHexStrMantles(11)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_GLIDER", MemorySource.Equipment, indexToHexStrMantles(12)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_EVASION", MemorySource.Equipment, indexToHexStrMantles(13)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_IMPACT", MemorySource.Equipment, indexToHexStrMantles(14)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_APOTHECARY", MemorySource.Equipment, indexToHexStrMantles(15)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_IMMUNITY", MemorySource.Equipment, indexToHexStrMantles(16)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_AFFINITY_BOOSTER", MemorySource.Equipment, indexToHexStrMantles(17)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_BANDIT", MemorySource.Equipment, indexToHexStrMantles(18)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_ASSASSINS_HOOD", MemorySource.Equipment, indexToHexStrMantles(19)),

            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_GHILLIE", MemorySource.Equipment, indexToHexStrMantlesRecharging(0), new MemoryConditionConfig(0, indexToHexStrMantles(0))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_TEMPORAL", MemorySource.Equipment, indexToHexStrMantlesRecharging(1), new MemoryConditionConfig(0,indexToHexStrMantles(1))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_HEALTH_BOOSTER", MemorySource.Equipment, indexToHexStrMantlesRecharging(2), new MemoryConditionConfig(0, indexToHexStrMantles(2))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_ROCKSTEADY", MemorySource.Equipment, indexToHexStrMantlesRecharging(3), new MemoryConditionConfig(0, indexToHexStrMantles(3))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_CHALLENGER", MemorySource.Equipment, indexToHexStrMantlesRecharging(4), new MemoryConditionConfig(0, indexToHexStrMantles(4))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_VITALITY", MemorySource.Equipment, indexToHexStrMantlesRecharging(5), new MemoryConditionConfig(0, indexToHexStrMantles(5))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_FIREPROOF", MemorySource.Equipment, indexToHexStrMantlesRecharging(6), new MemoryConditionConfig(0, indexToHexStrMantles(6))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_WATERPROOF", MemorySource.Equipment, indexToHexStrMantlesRecharging(7), new MemoryConditionConfig(0, indexToHexStrMantles(7))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_ICEPROOF", MemorySource.Equipment, indexToHexStrMantlesRecharging(8), new MemoryConditionConfig(0, indexToHexStrMantles(8))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_THUNDERPROOF", MemorySource.Equipment, indexToHexStrMantlesRecharging(9), new MemoryConditionConfig(0, indexToHexStrMantles(9))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_DRAGONPROOF", MemorySource.Equipment, indexToHexStrMantlesRecharging(10), new MemoryConditionConfig(0, indexToHexStrMantles(10))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_CLEANSER_BOOSTER", MemorySource.Equipment, indexToHexStrMantlesRecharging(11), new MemoryConditionConfig(0, indexToHexStrMantles(11))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_GLIDER", MemorySource.Equipment, indexToHexStrMantlesRecharging(12), new MemoryConditionConfig(0, indexToHexStrMantles(12))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_EVASION", MemorySource.Equipment, indexToHexStrMantlesRecharging(13), new MemoryConditionConfig(0, indexToHexStrMantles(13))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_IMPACT", MemorySource.Equipment, indexToHexStrMantlesRecharging(14), new MemoryConditionConfig(0, indexToHexStrMantles(14))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_APOTHECARY", MemorySource.Equipment, indexToHexStrMantlesRecharging(15),  new MemoryConditionConfig(0, indexToHexStrMantles(15))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_IMMUNITY", MemorySource.Equipment, indexToHexStrMantlesRecharging(16), new MemoryConditionConfig(0, indexToHexStrMantles(16))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_AFFINITY_BOOSTER", MemorySource.Equipment, indexToHexStrMantlesRecharging(17), new MemoryConditionConfig(0, indexToHexStrMantles(17))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_BANDIT", MemorySource.Equipment, indexToHexStrMantlesRecharging(18), new MemoryConditionConfig(0, indexToHexStrMantles(18))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_ASSASSINS_HOOD", MemorySource.Equipment, indexToHexStrMantlesRecharging(19), new MemoryConditionConfig(0, indexToHexStrMantles(19))),

            new StatusEffectConfig("Weapon", "LOC_WEAPON_CHARGE_BLADE_SHIELD_CHARGE", MemorySource.Weapon, indexToHexStrNoOffset(2270), WeaponType.CHARGE_BLADE),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_CHARGE_BLADE_BLADE_CHARGE", MemorySource.Weapon, indexToHexStrNoOffset(2271), WeaponType.CHARGE_BLADE),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_CHARGE_BLADE_PHIAL_EXPIRES", MemorySource.Weapon, indexToHexStrNoOffset(2332), WeaponType.CHARGE_BLADE),

            //unverified
            //new StatusEffectConfig("Weapon", "LOC_WEAPON_LONGSWORD_SPIRIT_GAUGE_REGEN_HELM_BREAKER", MemorySource.Weapon, indexToHexStrNoOffset(2402), WeaponType.LONG_SWORD),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_LONGSWORD_SPIRIT_GAUGE_REGEN_LAI_SLASH", MemorySource.Weapon, indexToHexStrNoOffset(2269), WeaponType.LONG_SWORD),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_LONGSWORD_STEADY_SPIRIT_LEVEL", MemorySource.Weapon, indexToHexStrNoOffset(2268), WeaponType.LONG_SWORD),

            new StatusEffectConfig("Weapon", "LOC_WEAPON_INSECT_GLAIVE_ATTACK", MemorySource.Weapon, indexToHexStrNoOffset(2266), WeaponType.INSECT_GLAIVE),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_INSECT_GLAIVE_SPEED", MemorySource.Weapon, indexToHexStrNoOffset(2267), WeaponType.INSECT_GLAIVE),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_INSECT_GLAIVE_DEFENSE", MemorySource.Weapon, indexToHexStrNoOffset(2268), WeaponType.INSECT_GLAIVE),

            new StatusEffectConfig("Weapon", "LOC_WEAPON_SWITCH_AXE_AMPED_STATE", MemorySource.Weapon, indexToHexStrNoOffset(2260), WeaponType.SWITCH_AXE),

            //new StatusEffectConfig("Weapon", "LOC_WEAPON_HAMMER_POWER_CHARGE", MemorySource.Weapon, null, WeaponType.HAMMER, new MemoryConditionConfig((byte)1, "1FC4"))

            };
    }
}
