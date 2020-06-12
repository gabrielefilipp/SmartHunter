using System;
using System.Globalization;
using System.Windows.Data;
using SmartHunter.Core;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Ui.Converters
{
    public class LocalizerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringId = null;
            if (value != null && value is string)
            {
                stringId = value as string;
            }
            else if (parameter != null && parameter is string)
            {
                stringId = parameter as string;
            }
            else
            {
                Log.WriteLine($"Localization Error: No string id provided");
                return LocalizationHelper.MissingStringId;
            }

            return LocalizationHelper.GetString(stringId);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}