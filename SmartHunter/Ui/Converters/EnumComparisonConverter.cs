using System;
using System.Globalization;
using System.Windows.Data;

namespace SmartHunter.Ui.Converters
{
    public class EnumComparisonConverter : IValueConverter
    {
        public bool Invert { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;

            if (value == null && parameter != null)
            {
                result = false;
            }
            else if (value != null && parameter == null)
            {
                result = false;
            }
            else if (value == null && parameter == null)
            {
                result = true;
            }
            else if (value.GetType().IsEnum && value.GetType() == parameter.GetType())
            {
                result = (int)value == (int)parameter;
            }
            else
            {
                result = (int)value == (int)parameter;
            }

            if (Invert)
            {
                result = !result;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}