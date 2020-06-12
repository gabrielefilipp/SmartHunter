using System;
using System.Globalization;
using System.Windows.Data;

namespace SmartHunter.Ui.Converters
{
    class AngleToIsLargeArcConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (float)value > 180;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
