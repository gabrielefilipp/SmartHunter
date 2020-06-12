using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using SmartHunter.Core;
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
                {
                    s_Instance = new SettingsViewModel();
                }

                return s_Instance;
            }
        }

        public List<Setting> Settings { get; }

        private void restartSmartHunter()
        {
            string exec = Assembly.GetEntryAssembly()?.Location;
            if (exec != null)
            {
                Process.Start("SmartHunter.exe");
            }
            Environment.Exit(0);
        }

        public SettingsViewModel()
        {
            Settings = new List<Setting>();

            Settings.Add(new Setting(ConfigHelper.Main.Values.ShutdownWhenProcessExits, "Shutdown when process exits", "Shutdown SmartHunter as soon as MonsterHunterWorld is killed", new Command(_ =>
            {
                ConfigHelper.Main.Values.ShutdownWhenProcessExits = !ConfigHelper.Main.Values.ShutdownWhenProcessExits;
                ConfigHelper.Main.Save();
            })));
            Settings.Add(new Setting(ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates, "Automatically check and download updates", "If enabled SmartHunter will automatically check and download new updates", new Command(_ =>
            {
                ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates = !ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates;
                ConfigHelper.Main.Save();
                if (!ConfigHelper.Main.Values.AutomaticallyCheckAndDownloadUpdates)
                {
                    var result = MessageBox.Show("This feature will work on the next open of Smarthunter. Would you like to reopen it now?", "Restart", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        restartSmartHunter();
                    }
                }
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive, "Hide when game window is inactive", "Automatically hide every SmartHunter window when MonsterHunterWorld it not top most application", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive = !ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible, "Team Widget", "Show/Hide Team Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone, "Dont show if alone", "Automatically hide Team Widget if you are alone in a mission", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone = !ConfigHelper.Main.Values.Overlay.TeamWidget.DontShowIfAlone;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars, "Team Widget show bars", "Show Bars inside Team Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowBars;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers, "Team Widget show numbers", "Show Numbers inside Team Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowNumbers;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents, "Team Widget show percents", "Show Percents inside Team Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents = !ConfigHelper.Main.Values.Overlay.TeamWidget.ShowPercents;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible, "Monster Widget", "Show/Hide Monsters Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters, "Show unchanged monsters", "Automatically hide monsters if they are not damaged", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedMonsters;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts, "Show unchanged parts", "Automatically hide monsters parts if they are not damaged", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedParts;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects, "Show unchanged status effects", "Automatically hide monsters status effects when there weren't any changes", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowUnchangedStatusEffects;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize, "Show monster size", "Show monster size hover its name", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowSize;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown, "Show monster crown", "Show monster crown image", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowCrown;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars, "Monster Widget show bars", "Show Bars inside Monster Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowBars;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers, "Monster Widget show numbers", "Show Numbers inside Monster Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowNumbers;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents, "Monster Widget show percents", "Show Percents inside Monster Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowPercents;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations, "Use animations", "Enable/Disable Animations for status effects", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations = !ConfigHelper.Main.Values.Overlay.MonsterWidget.UseAnimations;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster, "Show only selected monster", "Show only the monster that you selected for your hunt", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster = !ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible, "Player Widget", "Show/Hide Player Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible;
                ConfigHelper.Main.Save();
            })));

            Settings.Add(new Setting(ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible, "Debug Widget", "Show/Hide Debug Widget", new Command(_ =>
            {
                ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible = !ConfigHelper.Main.Values.Overlay.DebugWidget.IsVisible;
                ConfigHelper.Main.Save();
            })));
        }
    }
}
