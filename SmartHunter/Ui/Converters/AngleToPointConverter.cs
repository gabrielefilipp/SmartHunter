using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmartHunter.Ui.Converters
{
    public class AngleToPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (float.TryParse(parameter as string, out var radius))
            {
                float angle = (float)value;

                float radians = angle * (float)Math.PI / 180;

                float px = (float)Math.Sin(radians) * radius + radius;
                float py = (float)-Math.Cos(radians) * radius + radius;

                return new Point(px, py);
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
