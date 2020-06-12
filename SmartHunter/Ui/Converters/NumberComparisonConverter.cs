using System;
using System.Globalization;
using System.Windows.Data;

namespace SmartHunter.Ui.Converters
{
    public class NumberComparisonConverter : IValueConverter
    {
        public enum NumberComparison
        {
            Equal,
            Less,
            LessOrEqual,
            Greater,
            GreaterOrEqual,
            NotEqual
        }

        public bool Invert { get; set; } = false;
        public NumberComparison Comparison { get; set; } = NumberComparison.Equal;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;

            if (value is int)
            {
                int first = (int)value;
                int second = 0;

                if (parameter != null)
                {
                    var str = parameter as string;
                    if (!int.TryParse(str, out second))
                    {
                        return Binding.DoNothing;
                    }
                }

                if (Comparison == NumberComparison.Equal && first == second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.Less && first < second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.LessOrEqual && first <= second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.Greater && first > second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.GreaterOrEqual && first >= second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.NotEqual && first != second)
                {
                    result = true;
                }

                if (Invert)
                {
                    result = !result;
                }
            }
            else if (value is float)
            {
                float first = (float)value;
                float second = 0;

                if (parameter != null)
                {
                    var str = parameter as string;
                    if (!float.TryParse(str, out second))
                    {
                        return Binding.DoNothing;
                    }
                }

                if (Comparison == NumberComparison.Equal && first == second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.Less && first < second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.LessOrEqual && first <= second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.Greater && first > second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.GreaterOrEqual && first >= second)
                {
                    result = true;
                }
                else if (Comparison == NumberComparison.NotEqual && first != second)
                {
                    result = true;
                }

                if (Invert)
                {
                    result = !result;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}