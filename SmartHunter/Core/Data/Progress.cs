using System;
using System.Drawing;

namespace SmartHunter.Core.Data
{
    public class Progress : Bindable, IComparable
    {
        private float _max;
        private float _current;
        private readonly bool _shouldCapCurrent;

        public Progress(float max, float current, bool shouldCapCurrent = false)
        {
            _shouldCapCurrent = shouldCapCurrent;

            Max = max;
            Current = current;
        }

        public float Max
        {
            get => _max;
            set => SetProperty(ref _max, value);
        }

        public float Current
        {
            get => _current;
            set
            {
                if (_shouldCapCurrent)
                {
                    value = Cap(value, _max);
                }

                if (SetProperty(ref _current, value))
                {
                    if (_current > _max)
                    {
                        Max = _current;
                    }

                    NotifyPropertyChanged(nameof(Fraction));
                    NotifyPropertyChanged(nameof(Angle));
                    NotifyPropertyChanged(nameof(Color));
                }
            }
        }

        public string Color
        {
            get
            {
                Color c;
                if (Fraction > 0.5f)
                {
                    var red = (int)(255f * 2 * (1 -  Fraction));
                    c = System.Drawing.Color.FromArgb(255, red, 255, 0);
                }
                else
                {
                    var green = (int)(255f * 2 * Fraction);
                    c = System.Drawing.Color.FromArgb(255, 255, green, 0);
                }
                return "#" + c.R.ToString("X2") + c.G.ToString("X2") + "00";
            }
        }

        public float Fraction => _current / _max;
        public float Angle => Fraction * 359.999f;

        // We only really want the default compare to compare nulls.
        // We can then compare by Current in a separate pass for better control.
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            return 0;
        }

        private float Cap(float value, float max)
        {
            if (value < 0)
            {
                value = 0;
            }

            if (value > max)
            {
                value = max;
            }

            return value;
        }
    }
}
