using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SmartHunter.Core.Data;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Game.Data.ViewModels
{
    public class SettingsViewModel : Bindable
    {

        static SettingsViewModel s_Instance = null;
        public static SettingsViewModel Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new SettingsViewModel();

                return s_Instance;
            }
        }

        private bool m_ShutdownWhenProcessExits = ConfigHelper.Main.Values.ShutdownWhenProcessExits;
        public bool ShutdownWhenProcessExits
        {
            get { return m_ShutdownWhenProcessExits; }
            set {
                SetProperty(ref m_ShutdownWhenProcessExits, value);
                ConfigHelper.Main.Values.ShutdownWhenProcessExits = ShutdownWhenProcessExits;
            }
        }

        private bool m_AutomaticallyCheckAndDownloadUpdates = ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates;
        public bool AutomaticallyCheckAndDownloadUpdates
        {
            get { return m_AutomaticallyCheckAndDownloadUpdates; }
            set
            {
                SetProperty(ref m_AutomaticallyCheckAndDownloadUpdates, value);
                ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates = AutomaticallyCheckAndDownloadUpdates;
            }
        }

        private bool m_ShowMonsterPercents;
        public bool ShowMonsterPercents
        {
            get { return m_ShowMonsterPercents; }
            set
            {
                SetProperty(ref m_ShowMonsterPercents, value);
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents = ShowMonsterPercents;
            }
        }


        public ICommand SaveSettingsCommand { get; }

        public SettingsViewModel()
        {
            SaveSettingsCommand = new Command(_ => SaveSettings());
        }

        public void SaveSettings()
        {
            ConfigHelper.Main.Save();
            MessageBox.Show("Saved Changes in " + ConfigHelper.Main.FileName);
        }
    }

    public class Command : ICommand
    {

        private readonly Action<object> _action;

        public Command(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
