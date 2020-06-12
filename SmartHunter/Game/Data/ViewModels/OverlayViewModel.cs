using System.ComponentModel;
using SmartHunter.Core.Data;
using SmartHunter.Game.Data.WidgetContexts;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Game.Data.ViewModels
{
    public class OverlayViewModel : Bindable
    {
        static OverlayViewModel s_Instance = null;
        public static OverlayViewModel Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new OverlayViewModel();

                    bool isDesignInstance = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
                    if (isDesignInstance || ConfigHelper.Main.Values.Debug.UseSampleData)
                    {
                        s_Instance.GenerateSampleData();
                    }
                }

                return s_Instance;
            }
        }

        public ContextualWidget<TeamWidgetContext> TeamWidget { get; private set; }
        public ContextualWidget<MonsterWidgetContext> MonsterWidget { get; private set; }
        public ContextualWidget<PlayerWidgetContext> PlayerWidget { get; private set; }
        public ContextualWidget<DebugWidgetContext> DebugWidget { get; private set; }

        bool m_CanManipulateWindows;
        public bool CanManipulateWindows
        {
            get { return m_CanManipulateWindows; }
            set { SetProperty(ref m_CanManipulateWindows, value); }
        }

        bool m_HideWidgetsRequested;
        public bool HideWidgetsRequested
        {
            get { return m_HideWidgetsRequested; }
            set
            {
                if (SetProperty(ref m_HideWidgetsRequested, value))
                {
                    NotifyPropertyChanged(nameof(IsVisible));
                }
            }
        }

        bool m_IsGameActive = false;
        public bool IsGameActive
        {
            get { return m_IsGameActive; }
            set
            {
                if (SetProperty(ref m_IsGameActive, value))
                {
                    NotifyPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public bool IsVisible
        {
            get
            {
                return IsGameActive && !HideWidgetsRequested;
            }
        }

        public OverlayViewModel()
        {
            TeamWidget = new ContextualWidget<TeamWidgetContext>(ConfigHelper.Main.Values.Overlay.TeamWidget, new TeamWidgetContext());
            MonsterWidget = new ContextualWidget<MonsterWidgetContext>(ConfigHelper.Main.Values.Overlay.MonsterWidget, new MonsterWidgetContext());
            PlayerWidget = new ContextualWidget<PlayerWidgetContext>(ConfigHelper.Main.Values.Overlay.PlayerWidget, new PlayerWidgetContext());
            DebugWidget = new ContextualWidget<DebugWidgetContext>(ConfigHelper.Main.Values.Overlay.DebugWidget, new DebugWidgetContext());
        }

        void GenerateSampleData()
        {
            /*
            TeamWidget.Context.UpdateAndGetPlayer(0, "Jade", 3244);
            TeamWidget.Context.UpdateAndGetPlayer(1, "Kabuto", 2182);
            TeamWidget.Context.UpdateAndGetPlayer(2, "mike the father", 569);
            TeamWidget.Context.UpdateAndGetPlayer(3, "SlashMaster", 2966);

            TeamWidget.Context.UpdateFractions();

            var monster1 = MonsterWidget.Context.UpdateAndGetMonster(0, "em113_00", 6150, 6150, 1.25f);
            MonsterWidget.Context.UpdateAndGetMonster(0, "em113_00", 6150, 2733, 1.45f);
            MonsterWidget.Context.UpdateAndGetMonster(1, "em114_00", 5700, 5700, 0.45f);
            MonsterWidget.Context.UpdateAndGetMonster(2, "em118_00", 9191, 9191, 1.35f);

            monster1.UpdateAndGetPart(0, false, 480, 480, 3);
            monster1.UpdateAndGetPart(0, false, 480, 109, 3);

            monster1.UpdateAndGetPart(1, false, 100, 100, 2);

            monster1.UpdateAndGetPart(2, false, 384, 384, 1);
            monster1.UpdateAndGetPart(2, false, 384, 322, 1);

            monster1.UpdateAndGetPart(3, false, 432, 432, 0);
            monster1.UpdateAndGetPart(3, false, 432, 419, 0);

            monster1.UpdateAndGetPart(4, false, 150, 150, 1);
            monster1.UpdateAndGetPart(4, false, 150, 100, 1);

            monster1.UpdateAndGetPart(4, false, 432, 432, 1);
            monster1.UpdateAndGetPart(4, false, 432, 403, 1);

            monster1.UpdateAndGetPart(0, true, 864, 864, 0);
            monster1.UpdateAndGetPart(0, true, 864, 811, 0);

            monster1.UpdateAndGetStatusEffect(5, 50, 50, 50, 0, 1);
            monster1.UpdateAndGetStatusEffect(5, 50, 40, 50, 0, 1);

            monster1.UpdateAndGetStatusEffect(2, 100, 100, 7, 0, 0);
            monster1.UpdateAndGetStatusEffect(2, 100, 0, 7, 3, 0);

            monster1.UpdateAndGetStatusEffect(13, 50, 50, 50, 0, 1);
            monster1.UpdateAndGetStatusEffect(13, 50, 30, 50, 20, 1);

            monster1.UpdateAndGetStatusEffect(10, 50, 50, 50, 0, 1);
            monster1.UpdateAndGetStatusEffect(10, 50, 30, 50, 20, 1);

            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(1, 20, true);
            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(1, 15.5f, true);

            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(45, 120, true);
            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(45, 33.43f, true);

            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(80, null, true);
            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(82, null, true);
            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(83, 40, true);
            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(83, 30, true);

            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(69, 20, true);
            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(69, 11.98f, true);

            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(90, 120, true);
            PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(90, 111.5f, true);

            //// PROMO DATA
            //TeamWidget.Context.UpdateAndGetPlayer(0, "Jade", 1185);
            //TeamWidget.Context.UpdateAndGetPlayer(1, "Kabuto", 838);
            //TeamWidget.Context.UpdateAndGetPlayer(2, "mike the father", 632);
            //TeamWidget.Context.UpdateAndGetPlayer(3, "SlashMaster", 134);
            //TeamWidget.Context.UpdateFractions();

            //// Legiana
            //var monster1 = MonsterWidget.Context.UpdateAndGetMonster(0, "em111_00", 6060, 6060, 1.25f);
            //MonsterWidget.Context.UpdateAndGetMonster(0, "em111_00", 6060, 3271, 1.25f);

            //monster1.UpdateAndGetPart(0, false, 480, 208, 3);
            //monster1.UpdateAndGetPart(0, false, 480, 207, 3);

            //monster1.UpdateAndGetPart(1, false, 480, 154, 1);
            //monster1.UpdateAndGetPart(1, false, 480, 153, 1);

            //monster1.UpdateAndGetPart(2, false, 384, 323, 0);
            //monster1.UpdateAndGetPart(2, false, 384, 322, 0);

            //monster1.UpdateAndGetStatusEffect(4, 110, 57, 50, 0, 0);
            //monster1.UpdateAndGetStatusEffect(4, 110, 55, 50, 0, 0);

            //monster1.UpdateAndGetStatusEffect(13, 50, 31, 100, 68, 1);
            //monster1.UpdateAndGetStatusEffect(13, 50, 30, 100, 68, 1);

            //// Iceblight
            //PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(61, 60, true);
            //PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(61, 20, true);

            //// Might Seed
            //PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(74, 180, true);
            //PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(74, 97, true);

            //// Mega Armorskin
            //PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(82, null, true);

            //// Mega Demondrug
            //PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(80, null, true);
            */
        }
    }    
}
