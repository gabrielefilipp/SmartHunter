using System;
using System.Globalization;
using System.Windows.Data;

namespace SmartHunter.Ui.Converters
{
    public class FractionToPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float)
            {
                var f = (float)value;
                return string.Format("{0:0}%", f * 100);
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
