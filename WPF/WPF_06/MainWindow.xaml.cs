using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag = false;
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

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //tbColor.Background = myColor.newcolor;
            //CheckColor();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            colors.Add(new MyColor { Alfa = (byte)slider1.Value, Red = (byte)slider2.Value, Green = (byte)slider3.Value, Blue = (byte)slider4.Value });
            //btnAdd.IsEnabled = false;
        }

        private void Delete_button(object sender, RoutedEventArgs e)
        {
            colors.Remove((MyColor)(sender as Button).DataContext);
        }

        private void CheckColor()
        {
            for (int i = 0; i < colors.Count; i++)
            {
                if (tbColor.Background.ToString() == colors[i].Name)
                {
                    btnAdd.IsEnabled = false;
                    flag = true;
                }
            }

            if (!flag)
                btnAdd.IsEnabled = true;
        }
    }
}
