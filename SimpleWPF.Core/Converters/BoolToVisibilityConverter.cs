using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SimpleWPF.Core.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a bool value to a Visibility value (true == Visible, false == Hidden)
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolVal = (bool)value;

            if (boolVal)
            {
                return Visibility.Visible;
            }

            return Visibility.Hidden;
        }

        /// <summary>
        /// Converts a Visibility value to a bool value (Visible == true, Hidden == false)
        /// </summary>
        /// <param name="value">Visibility value</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibilityVal = (Visibility)value;

            if (visibilityVal == Visibility.Visible)
                return true;

            return false;
        }
    }
}