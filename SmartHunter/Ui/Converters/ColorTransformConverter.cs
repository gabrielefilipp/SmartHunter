using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartHunter.Ui.Converters
{
    public class ColorTransformConverter : IValueConverter
    {
        public double SaturationAdjustment { get; set; } = 0f;
        public double BrightnessAdjustment { get; set; } = 0f;
        public double? OpacityOverride { get; set; } = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color? color = null;

            if (value is Color)
            {
                color = (Color)value;
            }
            else if (value is SolidColorBrush)
            {
                color = ((SolidColorBrush)value).Color;
            }

            if (color != null)
            {
                double hsvHue;
                double hsvSaturation;
                double hsvValue;
                ColorToHsv(color.Value, out hsvHue, out hsvSaturation, out hsvValue);

                double saturationDifference = hsvSaturation;
                if (SaturationAdjustment > 0)
                {
                    saturationDifference = 1 - hsvSaturation;
                }
                double newSaturation = hsvSaturation + SaturationAdjustment / (1 / saturationDifference);

                double valueDifference = hsvValue;
                if (BrightnessAdjustment > 0)
                {
                    saturationDifference = 1 - hsvSaturation;
                }
                double newValue = hsvValue + BrightnessAdjustment / (1 / valueDifference);

                var newColor = HsvToColor(hsvHue, newSaturation, newValue);

                if (OpacityOverride.HasValue)
                {
                    newColor.A = (byte)(255f * OpacityOverride.Value);
                }

                if (value is Color)
                {
                    return newColor;
                }
                else if (value is SolidColorBrush)
                {
                    return new SolidColorBrush(newColor);
                }

                return HsvToColor(hsvHue, newSaturation, newValue);
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        static Color HsvToColor(double hue, double saturation, double value)
        {
            if (hue < 0)
            {
                hue = 0;
            }
            else if (hue > 360)
            {
                hue = 360;
            }

            if (saturation < 0)
            {
                saturation = 0;
            }
            else if (saturation > 1)
            {
                saturation = 1;
            }

            if (value < 0)
            {
                value = 0;
            }
            else if (value > 1)
            {
                value = 1;
            }

            double hh, p, q, t, ff;
            long i;

            double r;
            double g;
            double b;
            
            hh = hue;

            if (hh >= 360.0)
            {
                hh = 0.0;
            }

            hh /= 60.0;

            i = (long)hh;

            ff = hh - i;

            p = value * (1.0 - saturation);
            q = value * (1.0 - (saturation * ff));
            t = value * (1.0 - (saturation * (1.0 - ff)));

            switch (i)
            {
                case 0:
                    r = value;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = value;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = value;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = value;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = value;
                    break;
                case 5:
                default:
                    r = value;
                    g = p;
                    b = q;
                    break;
            }

            return Color.FromRgb((byte)(r * 255f), (byte)(g * 255f), (byte)(b * 255f));
        }

        static void ColorToHsv(Color color, out double hue, out double saturation, out double value)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            double min = r < g ? r: g;
            min = min < b? min  : b;

            double max = r > g ? r: g;
            max = max > b? max : b;

            value = max;

            double delta = max - min;

            if (delta < 0.00001)
            {
                saturation = 0;
                hue = 0;
                return;
            }
            else if (max > 0)
            {
                saturation = delta / max;
            }
            else
            {
                saturation = 0;
                hue = double.NaN;
                return;
            }

            if (r >= max)
            {
                hue = (g - b) / delta;
            }
            else if (g >= max)
            {
                hue = 2.0 + (b - r) / delta;
            }
            else
            {
                hue = 4.0 + (r - g) / delta;
            }

            hue *= 60;
            if (hue < 0)
            {
                hue += 360;
            }
        }
    }
}
