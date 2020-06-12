using SmartHunter.Core.Config;

namespace SmartHunter.Core.Data
{
    public class Widget : Bindable
    {
        readonly WidgetConfig _widgetConfig;
        private float _x;
        private float _y;
        private float _scale = 1;
        private bool _isVisible = true;

        public Widget(WidgetConfig widgetConfig)
        {
            _widgetConfig = widgetConfig;
            UpdateFromConfig();
        }

        public float X
        {
            get => _x;
            set
            {
                if (SetProperty(ref _x, value) && _x != _widgetConfig.X)
                {
                    UpdateConfig();
                }
            }
        }

        public float Y
        {
            get => _y;
            set
            {
                if (SetProperty(ref _y, value) && _y != _widgetConfig.Y)
                {
                    UpdateConfig();
                }
            }
        }

        public float Scale
        {
            get => _scale;
            set
            {
                if (SetProperty(ref _scale, value) && _scale != _widgetConfig.Scale)
                {
                    UpdateConfig();
                }
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (SetProperty(ref _isVisible, value) && _isVisible != _widgetConfig.IsVisible)
                {
                    UpdateConfig();
                }
            }
        }

        public bool CanSaveConfig { get; set; }

        public virtual void UpdateFromConfig()
        {
            X = _widgetConfig.X;
            Y = _widgetConfig.Y;
            Scale = _widgetConfig.Scale;
            IsVisible = _widgetConfig.IsVisible;
        }

        private void UpdateConfig()
        {
            _widgetConfig.X = _x;
            _widgetConfig.Y = _y;
            _widgetConfig.Scale = _scale;
            _widgetConfig.IsVisible = _isVisible;

            CanSaveConfig = true;
        }
    }
}
