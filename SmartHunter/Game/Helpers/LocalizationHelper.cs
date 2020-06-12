using System.Linq;
using SmartHunter.Core;

namespace SmartHunter.Game.Helpers
{
    public static class LocalizationHelper
    {
        public static readonly string MissingStringId = "LOC_MISSING";
        public static readonly string UnknownMonsterStringId = "LOC_MONSTER_UKNOWN";
        public static readonly string UnknownPartStringId = "LOC_PART_UKNOWN";
        public static readonly string UnknownRemovablePartStringId = "LOC_REMOVABLE_PART_UKNOWN";
        public static readonly string UnknownMonsterStatusEffectStringId = "LOC_STATUS_EFFECT_UKNOWN";
        public static readonly string UnknownPlayerStatusEffectStringId = "LOC_STATUS_EFFECT_UKNOWN";
        public static readonly string UnknownPlayerStringId = "LOC_UNKNOWN_PLAYER";

        public static string GetString(string stringId)
        {
            if (ConfigHelper.Localization.Values.Strings.TryGetValue(stringId, out var value))
            {
                return value;
            }

            Log.WriteLine($"Localization: '{stringId}' does not exist in {ConfigHelper.Localization.FileName}");

            return stringId;
        }

        public static string GetMonsterName(string monsterId)
        {
            if (ConfigHelper.MonsterData.Values.Monsters.TryGetValue(monsterId, out var monsterConfig))
            {
                return GetString(monsterConfig.NameStringId);
            }

            Log.WriteLine($"Localization: Monster '{monsterId}' not found in {ConfigHelper.MonsterData.FileName}");

            return GetString(UnknownMonsterStringId);
        }

        public static string GetMonsterPartName(string monsterId, int partIndex, bool isRemovable)
        {
            if (ConfigHelper.MonsterData.Values.Monsters.TryGetValue(monsterId, out var monsterConfig))
            {
                var parts = monsterConfig.Parts.Where(part => part.IsRemovable == isRemovable);
                if (parts.Count() > partIndex)
                {
                    return GetString(parts.ElementAt(partIndex).StringId);
                }
                else if (!isRemovable)
                {
                    Log.WriteLine($"Localization: Monster '{monsterId}' part '{partIndex}' not found in {ConfigHelper.MonsterData.FileName}");
                }
                else
                {
                    Log.WriteLine($"Localization: Monster '{monsterId}' removable part '{partIndex}' not found in {ConfigHelper.MonsterData.FileName}");
                }
            }
            else
            {
                Log.WriteLine($"Localization: Monster '{monsterId}' not found in {ConfigHelper.MonsterData.FileName}");
            }

            if (!isRemovable)
            {
                return GetString(UnknownPartStringId);
            }

            return GetString(UnknownRemovablePartStringId);
        }

        public static string GetMonsterStatusEffectName(int index)
        {
            if (ConfigHelper.MonsterData.Values.StatusEffects.Length > index)
            {
                return GetString(ConfigHelper.MonsterData.Values.StatusEffects[index].NameStringId);
            }

            Log.WriteLine($"Localization: Monster status effect with index '{index}' not found in {ConfigHelper.MonsterData.FileName}");

            return GetString(UnknownMonsterStatusEffectStringId);
        }

        public static string GetPlayerStatusEffectName(int index)
        {
            if (ConfigHelper.PlayerData.Values.StatusEffects.Length > index)
            {
                return GetString(ConfigHelper.PlayerData.Values.StatusEffects[index].NameStringId);
            }

            Log.WriteLine($"Localization: Player status effect with index '{index}' not found in {ConfigHelper.PlayerData.FileName}");

            return GetString(UnknownPlayerStatusEffectStringId);
        }
    }
}