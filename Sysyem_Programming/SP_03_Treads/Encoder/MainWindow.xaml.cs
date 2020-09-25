using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Encoder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string text;
        int len;
        public MainWindow()
        {
            InitializeComponent();

            //String str = "7110110110711510211111471101101107115";
            //int len = str.Length;
            //asciiToSentence(str, len);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                tb.Text = openFileDialog.FileName;                
            }
            text = File.ReadAllText(tb.Text);
            len = text.Length;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rbY.IsChecked == true)
            {
                Encrypt(text, len);
            }
            else
            {
                Decipher(text, len);
            }
        }

        static void Decipher(String str, int len)
        {
            //int num = 0;
            //for (int i = 0; i < len; i++)
            //{
            //    // Append the current digit 
            //    num = num * 10 + (str[i] - '0');            
            //    // If num is within the required range 
            //    if (num >= 32 && num <= 122)
            //    {
            //        // Convert num to char 
            //        char ch = (char)num;
            //        Console.Write(ch);
            //        // Reset num to 0 
            //        num = 0;
            //    }
            //}

            for (int i = 0; i < len; i++)
            {

            }

        }

        static void Encrypt(String str, int len)
        {
            
        }
    }
}
