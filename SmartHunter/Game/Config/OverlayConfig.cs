namespace SmartHunter.Game.Config
{
    public class OverlayConfig
    {
        public float ScaleMin = 0.5f;
        public float ScaleMax = 2f;
        public float ScaleStep = 0.1f;
        public bool HideWhenGameWindowIsInactive = false;
        public int UpdatesPerSecond = 20;

        public TeamWidgetConfig TeamWidget = new TeamWidgetConfig(220, 220);
        public MonsterWidgetConfig MonsterWidget = new MonsterWidgetConfig(320, 120);
        public PlayerWidgetConfig PlayerWidget = new PlayerWidgetConfig(120, 320);
        public DebugWidgetConfig DebugWidget = new DebugWidgetConfig(120, 320);
    }
}
