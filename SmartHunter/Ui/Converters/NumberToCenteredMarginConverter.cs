using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmartHunter.Ui.Converters
{
    public class NumberToCenteredMarginConverter : IValueConverter
    {
        public static int Width { get { return 300; } }
        public static int Spacing { get { return 46; } }
        public static int MaxMonstersCount { get { return 3; } }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                if ((int)value <= MaxMonstersCount)
                {
                    return new Thickness(((Width + Spacing) * (MaxMonstersCount - (int)value)) / ((int)value + 1), 0, Spacing, 0);
                }
            }
            return new Thickness(0, 0, Spacing, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
