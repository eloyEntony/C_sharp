using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPF_06
{
    public partial class MainWindow : Window
    {
        ObservableCollection<MyColor> colors = new ObservableCollection<MyColor>();
        MyColor myColor;
        public MainWindow()
        {
            InitializeComponent();

            myColor = new MyColor { Alfa = (byte)slider1.Value, Red = (byte)slider2.Value, Green = (byte)slider3.Value, Blue = (byte)slider4.Value };
            slider1.Value = 255;
            list.ItemsSource = colors;
            this.DataContext = myColor;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            colors.Add(new MyColor { Alfa = (byte)slider1.Value, Red = (byte)slider2.Value, Green = (byte)slider3.Value, Blue = (byte)slider4.Value });
            btnAdd.IsEnabled = CheckColor();
        }

        private void Delete_button(object sender, RoutedEventArgs e)
        {
            colors.Remove((MyColor)(sender as Button).DataContext);
        }

        private bool CheckColor()
        {
            foreach (var item in colors)
            {
                if (item.newcolor.ToString() == tbColor.Background.ToString())
                    return false;
            }
            return true;
        }
        private void ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            btnAdd.IsEnabled = CheckColor();
        }
    }
}
