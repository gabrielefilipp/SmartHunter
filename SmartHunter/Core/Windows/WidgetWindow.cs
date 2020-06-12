using System;
using System.Windows;
using System.Windows.Input;
using SmartHunter.Core.Data;

namespace SmartHunter.Core.Windows
{
    public abstract class WidgetWindow : Window
    {
        public Widget Widget { get; private set; }

        protected abstract float ScaleMax { get; }
        protected abstract float ScaleMin { get; }
        protected abstract float ScaleStep { get; }

        public WidgetWindow(Widget widget)
        {
            Widget = widget;
        }

        protected void WidgetWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        protected void WidgetWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            int direction = 0;
            if (e.Delta > 0)
            {
                direction = 1;
            }
            else if (e.Delta < 0)
            {
                direction = -1;
            }

            float currentScale = Widget.Scale;
            currentScale += ScaleStep * direction;
            Widget.Scale = Math.Min(Math.Max(currentScale, ScaleMin), ScaleMax);
        }
    }
}
