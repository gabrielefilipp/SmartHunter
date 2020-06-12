using SmartHunter.Core.Windows;
using SmartHunter.Game.Data.ViewModels;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Ui.Windows
{
    public partial class DebugWidgetWindow : WidgetWindow
    {
        protected override float ScaleMax { get { return ConfigHelper.Main.Values.Overlay.ScaleMax; } }
        protected override float ScaleMin { get { return ConfigHelper.Main.Values.Overlay.ScaleMin; } }
        protected override float ScaleStep { get { return ConfigHelper.Main.Values.Overlay.ScaleStep; } }

        public DebugWidgetWindow() : base(OverlayViewModel.Instance.DebugWidget)
        {
            InitializeComponent();

            DataContext = OverlayViewModel.Instance;


        }
        /*
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Variable to hold the handle for the form
            var helper = new WindowInteropHelper(this).Handle;
            //Performing some magic to hide the form from Alt+Tab
            SetWindowLong(helper, GWL_EX_STYLE, (GetWindowLong(helper, GWL_EX_STYLE) | WS_EX_TOOLWINDOW) & ~WS_EX_APPWINDOW);
        }
        */

        
    }
}
