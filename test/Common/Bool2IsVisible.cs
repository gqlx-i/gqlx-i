using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace test.Common
{
    class Bool2IsVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Visible" : "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {        
            if ((string)value == "Hidden" || (string)value == "Collapsed")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
