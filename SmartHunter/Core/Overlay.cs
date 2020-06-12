using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using SmartHunter.Core.Helpers;
using SmartHunter.Core.Windows;

namespace SmartHunter.Core
{
    public abstract class Overlay
    {
        KeyboardInput m_KeyboardInput;

        Window m_MainWindow;
        protected WidgetWindow[] WidgetWindows { get; private set; }

        public Overlay(Window mainWindow, params WidgetWindow[] widgetWindows)
        {
            m_MainWindow = mainWindow;
            WidgetWindows = widgetWindows;

            m_MainWindow.Loaded += MainWindow_Loaded;
            m_MainWindow.Closing += MainWindow_Closing;

            m_KeyboardInput = new KeyboardInput();
            m_KeyboardInput.InputReceived += KeyboardInput_InputReceived;

            m_MainWindow.Show();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWidgetsFromConfig();
            /*
            foreach (var widgetWindow in WidgetWindows)
            {
                if (!widgetWindow.IsVisible)
                {
                    widgetWindow.Owner = m_MainWindow;
                    widgetWindow.Opacity = 0.0f;
                    widgetWindow.Hide();
                }
            }
            */
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            foreach (var widgetWindow in WidgetWindows)
            {
                widgetWindow.Close();
            }
        }

        private void ToggleWidgetWindow(WidgetWindow widgetWindow)
        {
            /*
            widgetWindow.Owner = m_MainWindow;
            if (widgetWindow.Visibility != Visibility.Visible)
            {
                widgetWindow.Opacity = 1.0f;
                widgetWindow.Show();

                WindowHelper.SetTopMostTransparent(widgetWindow);
            }
            else
            {
                widgetWindow.Opacity = 0.0f;
                widgetWindow.Hide();
            }
            */
            
            if (widgetWindow.Visibility != Visibility.Visible)
            {
                widgetWindow.Owner = m_MainWindow;
                widgetWindow.Show();
                widgetWindow.Owner = null;

                WindowHelper.SetTopMostTransparent(widgetWindow);
            }
            else
            {
                widgetWindow.Hide();
            }
        }

        public void UpdateWidgetsFromConfig()
        {
            foreach (var widgetWindow in WidgetWindows)
            {
                widgetWindow.Widget.UpdateFromConfig();

                if ((widgetWindow.Widget.IsVisible && widgetWindow.Visibility != Visibility.Visible) ||
                    (!widgetWindow.Widget.IsVisible && widgetWindow.Visibility == Visibility.Visible))
                {
                    ToggleWidgetWindow(widgetWindow);
                }
            }
        }

        public void RefreshWidgetsLayout()
        {
            foreach (var widgetWindow in WidgetWindows)
            {
                var dataContext = widgetWindow.DataContext;
                widgetWindow.DataContext = null;
                widgetWindow.DataContext = dataContext;
            }
        }

        private void KeyboardInput_InputReceived(object sender, KeyboardInputEventArgs e)
        {
            InputReceived(e.Key, e.IsDown);
        }

        abstract protected void InputReceived(Key key, bool down);
    }
}
