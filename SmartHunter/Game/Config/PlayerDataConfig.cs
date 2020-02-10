namespace SmartHunter.Game.Config
{
    public class PlayerDataConfig
    {
        private static string indexToHexStr(int index, ulong baseOffset)
        {
            ulong multiplier = 0x4;
            string prefix = "";
            if (index < 0)
            {
                index = (-1) * index;
                prefix = "-";
            }
            ulong hex = baseOffset + multiplier * (ulong)index;
            return $"{prefix}{hex.ToString("X")}";
        }

        private static string indexToHexStrMantles(int index)
        {
            return indexToHexStr(index, 0xEFC);
        }

        private static string indexToHexStrMantlesRecharging(int index)
        {
            return indexToHexStr(index, 0xEAC);
        }

        private static string indexToHexStrNoOffset(int index)
        {
            return indexToHexStr(index, 0x0);
        }

        public StatusEffectConfig[] StatusEffects =
        {














            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_SELF_IMPROVEMENT", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(14)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ATTACK_UP_S", StatusEffectConfig.MemorySource.Base,indexToHexStrNoOffset(15)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ATTACK_UP_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(16)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_HEALTH_BOOST_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(17)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_HEALTH_BOOST_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(18)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_STAMINA_USE_REDUCED_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(19)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_STAMINA_USE_REDUCED_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(20)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_WIND_PRESSURE_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(21)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ALL_WIND_PRESSURE_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(22)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DEFENSE_UP_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(23)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DEFENSE_UP_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(24)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_TOOL_USE_DRAIN_REDUCED_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(25)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_TOOL_USE_DRAIN_REDUCED_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(26)),





            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_HEALTH_RECOVERY_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(32)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_HEALTH_RECOVERY_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(33)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_EARPLUGS_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(34)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_EARPLUGS_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(35)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DIVINE_PROTECTION", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(36)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_SCOUTFLY_POWER_UP", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(37)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ENVIRONMENTAL_DAMAGE_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(38)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_STUN_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(39)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_PARALYSIS_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(40)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_TREMORS_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(41)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_MUCK_RESISTANCE", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(42)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_FIRE_RESISTANCE_BOOST_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(43)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_FIRE_RESISTANCE_BOOST_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(44)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_WATER_RESISTANCE_BOOST_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(45)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_WATER_RESISTANCE_BOOST_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(46)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_THUNDER_RESISTANCE_BOOST_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(47)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_THUNDER_RESISTANCE_BOOST_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(48)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ICE_RESISTANCE_BOOST_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(49)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ICE_RESISTANCE_BOOST_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(50)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DRAGON_RESISTANCE_BOOST_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(51)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_DRAGON_RESISTANCE_BOOST_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(52)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ELEMENTAL_ATTACK_BOOST", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(53)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_BLIGHT_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(54)),


            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_KNOCKBACKS_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(57)),

            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ELEMENTAL_RESISTANCE_UP", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(59)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_AFFINITY_UP", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(60)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ALL_AILMENTS_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(61)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_WIND_PRESSURE_NEGATED_AND_EARPLUGS_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(62)),
            new StatusEffectConfig("Horn", "LOC_STATUS_EFFECT_ABNORMAL_STATUS_ATTACK_INCREASED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(63)),

            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_ATTACK_UP_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(65)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_ATTACK_UP_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(66)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_DEFENSE_UP_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(67)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_DEFENSE_UP_L", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(68)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_AFFINITY_UP", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(69)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_HEALTH_RECOVERY", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(70)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_HEALTH_BOOST", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(71)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_STAMINA_USE_REDUCED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(72)),

            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_DIVINE_PROTECTION", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(74)),

            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_STUN_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(76)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_PARALYSIS_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(77)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_TREMORS_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(78)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_EARPLUGS_S", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(79)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_WIND_PRESSURE_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(80)),
            new StatusEffectConfig("Coral", "LOC_STATUS_EFFECT_ENVIRONMENTAL_DAMAGE_NEGATED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(81)),
            
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_POISON", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(375)),



            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_FIREBLIGHT", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(379)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_THUNDERBLIGHT", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(380)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_WATERBLIGHT", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(381)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_ICEBLIGHT", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(382)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_DRAGONBLIGHT", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(383)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_BLEEDING", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(384)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_BLEEDING_RECOVERY", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(385)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_EFFLUVIA", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(386)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_DEFENSE_DOWN", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(387)),

            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_ELEMENTAL_RESISTANCE_DOWN", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(389)),

            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_NO_ITEMS", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(391)),
            new StatusEffectConfig("Debuff", "LOC_STATUS_EFFECT_BLASTBLIGHT", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(392)),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_DASH_JUICE", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(421)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_WIGGLY_LITCHI", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(422)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_IMMUNIZER", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(423)),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_MIGHT_SEED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(425), new MemoryConditionConfig(0, indexToHexStrNoOffset(427))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_MIGHT_PILL", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(425), new MemoryConditionConfig(1, indexToHexStrNoOffset(427))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_ADAMANT_SEED", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(429), new MemoryConditionConfig(20, indexToHexStrNoOffset(430))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_ADAMANT_PILL", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(429), new MemoryConditionConfig(0, indexToHexStrNoOffset(430))),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_DEMON_POWDER", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(434)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_HARDSHELL_POWDER", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(435)),

            // Those unlocky ones are not divisible by 4 Q.Q

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_DEMONDRUG", StatusEffectConfig.MemorySource.Base, null, new MemoryConditionConfig(1, "6D8")),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_MEGA_DEMONDRUG", StatusEffectConfig.MemorySource.Base, null, new MemoryConditionConfig(2, "6D8")),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_ARMORSKIN", StatusEffectConfig.MemorySource.Base, null, new MemoryConditionConfig(1, "6DC")),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_MEGA_ARMORSKIN", StatusEffectConfig.MemorySource.Base, null, new MemoryConditionConfig(2, "6DC")),
            
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_COOL_DRINK", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(444)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_HOT_DRINK", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(445)),

            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_PROTECTIVE_POLISH", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(476)),
            new StatusEffectConfig("Buff", "LOC_STATUS_EFFECT_AFFINITY_SLIDING", StatusEffectConfig.MemorySource.Base, indexToHexStrNoOffset(477)),

            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_GHILLIE", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(0)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_TEMPORAL", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(1)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_HEALTH_BOOSTER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(2)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_ROCKSTEADY", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(3)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_CHALLENGER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(4)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_VITALITY", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(5)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_FIREPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(6)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_WATERPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(7)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_ICEPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(8)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_THUNDERPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(9)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_DRAGONPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(10)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_CLEANSER_BOOSTER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(11)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_GLIDER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(12)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_EVASION", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(13)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_IMPACT", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(14)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_APOTHECARY", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(15)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_IMMUNITY", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(16)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_AFFINITY_BOOSTER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(17)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_MANTLE_BANDIT", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(18)),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_ASSASSINS_HOOD", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantles(19)),

            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_GHILLIE", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(0), new MemoryConditionConfig(0, indexToHexStrMantles(0))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_TEMPORAL", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(1), new MemoryConditionConfig(0,indexToHexStrMantles(1))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_HEALTH_BOOSTER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(2), new MemoryConditionConfig(0, indexToHexStrMantles(2))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_ROCKSTEADY", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(3), new MemoryConditionConfig(0, indexToHexStrMantles(3))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_CHALLENGER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(4), new MemoryConditionConfig(0, indexToHexStrMantles(4))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_VITALITY", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(5), new MemoryConditionConfig(0, indexToHexStrMantles(5))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_FIREPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(6), new MemoryConditionConfig(0, indexToHexStrMantles(6))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_WATERPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(7), new MemoryConditionConfig(0, indexToHexStrMantles(7))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_ICEPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(8), new MemoryConditionConfig(0, indexToHexStrMantles(8))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_THUNDERPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(9), new MemoryConditionConfig(0, indexToHexStrMantles(9))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_DRAGONPROOF", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(10), new MemoryConditionConfig(0, indexToHexStrMantles(10))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_CLEANSER_BOOSTER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(11), new MemoryConditionConfig(0, indexToHexStrMantles(11))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_GLIDER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(12), new MemoryConditionConfig(0, indexToHexStrMantles(12))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_EVASION", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(13), new MemoryConditionConfig(0, indexToHexStrMantles(13))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_IMPACT", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(14), new MemoryConditionConfig(0, indexToHexStrMantles(14))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_APOTHECARY", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(15),  new MemoryConditionConfig(0, indexToHexStrMantles(15))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_IMMUNITY", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(16), new MemoryConditionConfig(0, indexToHexStrMantles(16))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_AFFINITY_BOOSTER", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(17), new MemoryConditionConfig(0, indexToHexStrMantles(17))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_MANTLE_BANDIT", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(18), new MemoryConditionConfig(0, indexToHexStrMantles(18))),
            new StatusEffectConfig("Equipment", "LOC_EQUIPMENT_RECHARGE_ASSASSINS_HOOD", StatusEffectConfig.MemorySource.Equipment, indexToHexStrMantlesRecharging(19), new MemoryConditionConfig(0, indexToHexStrMantles(19))),

            // Not working

            /*new StatusEffectConfig("Weapon", "LOC_WEAPON_INSECT_GLAIVE_ATTACK", StatusEffectConfig.MemorySource.Weapon, "1FE8", new MemoryConditionConfig(".*rod[0-9]", "290", "3E0", "10")),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_INSECT_GLAIVE_SPEED", StatusEffectConfig.MemorySource.Weapon, "1FEC", new MemoryConditionConfig(".*rod[0-9]", "290", "3E0", "10")),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_INSECT_GLAIVE_DEFENSE", StatusEffectConfig.MemorySource.Weapon, "1FF0", new MemoryConditionConfig(".*rod[0-9]", "290", "3E0", "10")),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_LONGSWORD_SPIRIT_GAUGE_REGEN", StatusEffectConfig.MemorySource.Weapon, "1FF8", new MemoryConditionConfig(".*swo[0-9]", "290", "3E0", "10")),*/
            new StatusEffectConfig("Weapon", "LOC_WEAPON_LONGSWORD_STEADY_SPIRIT_LEVEL", StatusEffectConfig.MemorySource.Weapon, indexToHexStrNoOffset(2408)),//, new MemoryConditionConfig(".*swo[0-9]", "4B8", "240", "A38", "328", "DF8", "50", "4D8", "C80")),
            /*new StatusEffectConfig("Weapon", "LOC_WEAPON_CHARGE_BLADE_SHIELD_CHARGE", StatusEffectConfig.MemorySource.Weapon, "1FF8", new MemoryConditionConfig(".*caxe[0-9]", "290", "3E0", "10")),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_CHARGE_BLADE_BLADE_CHARGE", StatusEffectConfig.MemorySource.Weapon, "1FFC", new MemoryConditionConfig(".*caxe[0-9]", "290", "3E0", "10")),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_SWITCH_AXE_AMPED_STATE", StatusEffectConfig.MemorySource.Weapon, "1FD4", new MemoryConditionConfig(".*saxe[0-9]", "290", "3E0", "10")),
            new StatusEffectConfig("Weapon", "LOC_WEAPON_HAMMER_POWER_CHARGE", StatusEffectConfig.MemorySource.Weapon, null, new MemoryConditionConfig((byte)1, "1FC4"), new MemoryConditionConfig(".*ham[0-9]", "290", "3E0", "10"))
            */
            };
    }
}
