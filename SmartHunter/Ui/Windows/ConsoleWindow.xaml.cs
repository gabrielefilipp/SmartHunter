using System.Windows;
using SmartHunter.Game.Data.ViewModels;

namespace SmartHunter.Ui.Windows
{
    public partial class ConsoleWindow : Window
    {
        public ConsoleWindow()
        {
            InitializeComponent();

            LogsTab.DataContext = ConsoleViewModel.Instance;
            SettingsTab.DataContext = SettingsViewModel.Instance;
        }
    }
}
