using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPF_08_ContactList.ViewModel.Convertors
{
    class ConvertorVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool colaps = System.Convert.ToBoolean(value);
            Visibility tmp = new Visibility();
            if (colaps)
                tmp = Visibility.Visible;
            else
                tmp = Visibility.Collapsed;

            return tmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
