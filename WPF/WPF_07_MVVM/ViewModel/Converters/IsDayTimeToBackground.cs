using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_07_MVVM.ViewModel
{
    class IsDayTimeToBackground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brushes = new SolidColorBrush();
            bool dayTime = System.Convert.ToBoolean(value);
            switch (dayTime)
            {
                case false:
                    brushes = Brushes.Blue;
                    break;
                case true:
                    brushes = Brushes.Violet;
                    break;
            }
            return brushes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
