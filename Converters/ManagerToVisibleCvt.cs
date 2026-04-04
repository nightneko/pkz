using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace pkz.Converters
{
    public class ManagerToVisibleCvt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isWinget = value is string managerName && managerName == "winget";
            bool invert = parameter is string p && p == "Invert";

            if (invert) isWinget = !isWinget;

            return isWinget ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
