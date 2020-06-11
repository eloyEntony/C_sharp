using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_07_MVVM.ViewModel
{
    class HasPresipitationToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            bool presipitations = System.Convert.ToBoolean(value);
            switch (presipitations)
            {
                case false:
                    result = "Precipitation: no";
                    break;
                case true:
                    result = "Precipitation: yes";
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
