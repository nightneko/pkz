using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace pkz.Converters
{
    class CntToVisibleCvt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count && count > 0) return Visibility.Visible;

            return Visibility.Collapsed;
        }
        // 사용자가 직접 수정하는 UI가 아니라 반대방향 바인딩을 안한다?
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
