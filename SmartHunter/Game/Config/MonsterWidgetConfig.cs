using SmartHunter.Core.Config;
using System.Text.RegularExpressions;

namespace SmartHunter.Game.Config
{
    public class MonsterWidgetConfig : WidgetConfig
    {
        // em[0-9]|ems[0-9]|gm[0-9]
        public string IncludeMonsterIdRegex = "em[0-9]";
        public string IncludePartGroupIdRegex = ".*";
        public string IncludeStatusEffectGroupIdRegex = ".*";
        public bool ShowUnchangedMonsters = true;
        public float HideMonstersAfterSeconds = 999f;
        public bool ShowUnchangedParts = false;
        public float HidePartsAfterSeconds = 12f;
        public bool ShowUnchangedStatusEffects = false;
        public float HideStatusEffectsAfterSeconds = 12f;

        public bool ShowCrown = true;
        public bool ShowBars = true;
        public bool ShowNumbers = true;
        public bool ShowPercents = false;

        public MonsterWidgetConfig(float x, float y) : base(x, y)
        {
        }

        public bool MatchIncludeMonsterIdRegex(string monsterId)
        {
            return new Regex(IncludeMonsterIdRegex).IsMatch(monsterId);
        }

        public bool MatchIncludePartGroupIdRegex(string groupId)
        {
            return new Regex(IncludePartGroupIdRegex).IsMatch(groupId);
        }

        public bool MatchIncludeStatusEffectGroupIdRegex(string groupId)
        {
            return new Regex(IncludeStatusEffectGroupIdRegex).IsMatch(groupId);
        }
    }
}
