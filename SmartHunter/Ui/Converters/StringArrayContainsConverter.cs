using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace SmartHunter.Ui.Converters
{
    public class StringArrayContainsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string[])
            {
                var stringArray = (string[])value;
                return stringArray.Contains(parameter as string);
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
