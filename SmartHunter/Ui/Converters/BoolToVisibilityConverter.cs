using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SmartHunter.Ui.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; } = Visibility.Visible;
        public Visibility FalseValue { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool invert = parameter != null;

            if (value is bool)
            {
                if ((bool)value)
                {
                    return !invert ? TrueValue : FalseValue;
                }
                else
                {
                    return !invert ? FalseValue : TrueValue;
                }
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
