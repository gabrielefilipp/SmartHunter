using SmartHunter.Core.Config;

namespace SmartHunter.Game.Config
{
    public class DebugWidgetConfig : WidgetConfig
    {
        public DebugWidgetConfig(float x, float y) : base(x, y)
        {
            IsVisible = false;
        }
    }
}
