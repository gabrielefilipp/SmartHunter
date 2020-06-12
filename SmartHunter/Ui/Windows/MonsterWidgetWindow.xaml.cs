using SmartHunter.Core.Windows;
using SmartHunter.Game.Data.ViewModels;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Ui.Windows
{
    public partial class MonsterWidgetWindow : WidgetWindow
    {
        protected override float ScaleMax { get { return ConfigHelper.Main.Values.Overlay.ScaleMax; } }
        protected override float ScaleMin { get { return ConfigHelper.Main.Values.Overlay.ScaleMin; } }
        protected override float ScaleStep { get { return ConfigHelper.Main.Values.Overlay.ScaleStep; } }

        public MonsterWidgetWindow() : base(OverlayViewModel.Instance.MonsterWidget)
        {
            InitializeComponent();

            DataContext = OverlayViewModel.Instance;
        }
    }
}
