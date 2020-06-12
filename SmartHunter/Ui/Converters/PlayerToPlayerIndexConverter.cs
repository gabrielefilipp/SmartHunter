using System;
using System.Globalization;
using System.Windows.Data;
using SmartHunter.Game.Data;
using SmartHunter.Game.Data.ViewModels;

namespace SmartHunter.Ui.Converters
{
    public class PlayerToPlayerIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var player = value as Player;

            if (OverlayViewModel.Instance.TeamWidget.Context.Players.Contains(player))
            {
                return OverlayViewModel.Instance.TeamWidget.Context.Players.IndexOf(player);
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
