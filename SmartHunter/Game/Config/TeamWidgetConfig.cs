using SmartHunter.Core.Config;

namespace SmartHunter.Game.Config
{
    public class TeamWidgetConfig : WidgetConfig
    {
        public bool DontShowIfAlone = false;
        public bool ShowBars = true;
        public bool ShowNumbers = true;
        public bool ShowPercents = true;

        public TeamWidgetConfig(float x, float y) : base(x, y)
        {
        }
    }
}
