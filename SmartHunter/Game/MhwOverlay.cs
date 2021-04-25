using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using SmartHunter.Core;
using SmartHunter.Core.Helpers;
using SmartHunter.Core.Windows;
using SmartHunter.Game.Data;
using SmartHunter.Game.Data.ViewModels;
using SmartHunter.Game.Data.WidgetContexts;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Game
{
    public class MhwOverlay : Overlay
    {
        MhwMemoryUpdater m_MemoryUpdater;
        bool HideWidgets
        {
            get;
            set;
        }

        public MhwOverlay(Window mainWindow, params WidgetWindow[] widgetWindows) : base(mainWindow, widgetWindows)
        {
            ConfigHelper.Main.Loaded += (s, e) => { UpdateWidgetsFromConfig(); };
            ConfigHelper.Localization.Loaded += (s, e) => { RefreshWidgetsLayout(); };
            ConfigHelper.MonsterData.Loaded += (s, e) => { RefreshWidgetsLayout(); };
            ConfigHelper.PlayerData.Loaded += (s, e) => { RefreshWidgetsLayout(); };

            HideWidgets = false;

            if (!ConfigHelper.Main.Values.Debug.UseSampleData)
            {
                m_MemoryUpdater = new MhwMemoryUpdater();
            }
        }

        protected override void InputReceived(Key key, bool isDown)
        {
            foreach (var controlKeyPair in ConfigHelper.Main.Values.Keybinds.Where(keybind => keybind.Value == key))
            {
                HandleControl(controlKeyPair.Key, isDown);
            }
        }

        private void HandleControl(InputControl control, bool isDown)
        {
            if (control == InputControl.ManipulateWidget && isDown && !OverlayViewModel.Instance.CanManipulateWindows)
            {
                OverlayViewModel.Instance.CanManipulateWindows = true;

                // Make all the windows selectable
                foreach (var widgetWindow in WidgetWindows)
                {
                    WindowHelper.SetTopMostSelectable(widgetWindow as Window);
                }
            }
            else if (control == InputControl.ManipulateWidget && !isDown && OverlayViewModel.Instance.CanManipulateWindows)
            {
                OverlayViewModel.Instance.CanManipulateWindows = false;

                bool canSaveConfig = false;

                // Return all windows to their click through state
                foreach (var widgetWindow in WidgetWindows)
                {
                    WindowHelper.SetTopMostTransparent(widgetWindow as Window);

                    if (widgetWindow.Widget.CanSaveConfig)
                    {
                        canSaveConfig = true;
                        widgetWindow.Widget.CanSaveConfig = false;
                    }
                }

                if (canSaveConfig)
                {
                    ConfigHelper.Main.Save();
                }
            }
            else if (control == InputControl.HideWidgets)
            {
                if (ConfigHelper.Main.Values.Overlay.HideOverlayToggle == true)
                {
                    if (isDown)
                    {
                        HideWidgets = !HideWidgets;
                    }
                    OverlayViewModel.Instance.HideWidgetsRequested = HideWidgets;
                }
                else
                {
                    OverlayViewModel.Instance.HideWidgetsRequested = isDown;
                }
            }
            else if (control == InputControl.CopyTeamDamage && isDown)
            {
                string str = "";
                List<Player> players = OverlayViewModel.Instance.TeamWidget.Context.Players.ToList();
                if (OverlayViewModel.Instance.TeamWidget.Context.Players.Count > 0)
                {
                    players.Sort();
                    foreach (var player in players)
                        str += String.Format("{0} {1}% ", player.Name.Length >= 3 ? player.Name.Substring(0, 3) : player.Name, (player.DamageFraction * 100).ToString("0.##"));
                }
                else
                    str = "No Team Damage";
                CopyToClipboard(str);
            }
            else if (control == InputControl.CopyPlayer1Damage && isDown)
            {
                GetPlayerDamage(OverlayViewModel.Instance.TeamWidget.Context.Players, 1);
            }
            else if (control == InputControl.CopyPlayer2Damage && isDown)
            {
                GetPlayerDamage(OverlayViewModel.Instance.TeamWidget.Context.Players, 2);
            }
            else if (control == InputControl.CopyPlayer3Damage && isDown)
            {
                GetPlayerDamage(OverlayViewModel.Instance.TeamWidget.Context.Players, 3);
            }
            else if (control == InputControl.CopyPlayer4Damage && isDown)
            {
                GetPlayerDamage(OverlayViewModel.Instance.TeamWidget.Context.Players, 4);
            }
        }

        private void GetPlayerDamage(Collection<Player> players, int index)
        {
            List<Player> mplayer = players.ToList();
            mplayer.Sort();
            if (mplayer.Count >= index)
                CopyToClipboard(mplayer[index - 1].ToString());
            else
                CopyToClipboard(String.Format("Player Not Found (Index: {0})", index));
        }

        private void CopyToClipboard(String str)
        {
            Clipboard.SetText(str);
            Log.WriteLine("Copy to clipboard > " + str);
        }
    }
}
