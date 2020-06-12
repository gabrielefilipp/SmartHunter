using SmartHunter.Core;

namespace SmartHunter.Game.Config
{
    public class BytePatternConfig
    {
        public string Name;
        public string PatternString;
        public string LastResultAddress;

        public BytePatternConfig(string name, string patternString, string lastResultAddress = "")
        {
            Name = name;
            PatternString = patternString;
            LastResultAddress = lastResultAddress;
        }
    }
}
