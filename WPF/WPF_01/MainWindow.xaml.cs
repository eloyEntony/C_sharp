using System;
using System.Collections.Generic;
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

namespace WPF_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num = 0;
        char sign = ' ';
        double result = 0;
        string tempString = "0",
               temp = "";
        bool flag = true,
             flagPoint = true,
             flagDivByZero = true,
             flagMinBtn = true;
        public MainWindow()
        {
            InitializeComponent();
            #region
            /////////////////////////////////////////////////////////////////////////////////
            //foreach (Button item in wPanel.Children)  Task#1
            //{
            //    if (item is Button)
            //    {
            //        try
            //        {
            //            item.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(item.Content.ToString());
            //            item.Margin = new Thickness(2);
            //        }
            //        catch { }
            //    }
            //}
            /////////////////////////////////////////////////////////////////////////////////
            #endregion

            btn0.Click += BtnCount_Click;
            btn1.Click += BtnCount_Click;
            btn2.Click += BtnCount_Click;
            btn3.Click += BtnCount_Click;
            btn4.Click += BtnCount_Click;
            btn5.Click += BtnCount_Click;
            btn6.Click += BtnCount_Click;
            btn7.Click += BtnCount_Click;
            btn8.Click += BtnCount_Click;
            btn9.Click += BtnCount_Click;
            btnMinus.Click += BtnSign_Click;
            btnPlus.Click += BtnSign_Click;
            btnDil.Click += BtnSign_Click;
            btnMnog.Click += BtnSign_Click;
            btnRes.Click += BtnRes_Click;
            btnC.Click += BtnC_Click;
            btnTochka.Click += BtnTochka_Click;
            btnCE.Click += BtnCE_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (count.Text.Length > 0 && flagMinBtn)
                {
                    count.Text = count.Text.Substring(0, count.Text.Length - 1);
                    tempString = tempString.Substring(0, tempString.Length - 1);
                    temp = count.Text;
                    if (count.Text.Length < 2)
                        flagPoint = true;
                }
                if (count.Text == "")
                    count.Text = "0";
            }
            catch { count.Text = "0"; }
           
        }
        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            tempString = count.Text = "0";
            result = 0;
            flagDivByZero = flagPoint = flagMinBtn = true;
        }
        private void BtnTochka_Click(object sender, RoutedEventArgs e)
        {
            if (!flagMinBtn)
                return;
            if (flagPoint || count.Text == "0" || !count.Text.Contains(","))
            {
                count.Text += ",";
                tempString += ",";
                temp += ",";
                flagPoint = false;
            }
            if (temp == ",")
            {
                temp = "0,";
                count.Text = "0,";
            }
        }
        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            expression.Text = temp = "";
            tempString = count.Text = "0";
            result = 0;
            flagDivByZero = flagPoint = flagMinBtn = true;
        }
        private void BtnRes_Click(object sender, RoutedEventArgs e)
        {
            if (count.Text == "Division 0")
            {
                count.Text = "0";
                sign = ' ';
                return;
            }
            expression.Text = "";
            temp = "";
            num = Double.Parse(count.Text);
            Calculation(num, sign);
            if (!flagDivByZero)
            {
                count.Text = "Division 0";
                tempString = "";
                flagDivByZero = true;
            }
            else
            {
                count.Text = result.ToString();
                tempString = result.ToString();
            }
            flagMinBtn = false;
        }
        private void BtnSign_Click(object sender, RoutedEventArgs e)
        {
            if (count.Text == "0")
                tempString = "0";
            if (count.Text == "Division 0")
            {
                count.Text = "0";
                sign = ' ';
                return;
            }
            Button b = sender as Button;
            flag = false;
            flagMinBtn = true;
            temp = "";
            if (tempString.EndsWith("+") || tempString.EndsWith("-") || tempString.EndsWith("*") || tempString.EndsWith("/"))
            {
                tempString = tempString.Remove(tempString.Length - 1, 1) + b.Content.ToString();
                sign = Char.Parse(b.Content.ToString());
                expression.Text = tempString;
                return;
            }

            tempString += b.Content.ToString();
            expression.Text = tempString;

            if (result == 0)
                result = Double.Parse(count.Text);
            else if (num == 0)
            {
                num = Double.Parse(count.Text);
                Calculation(num, sign);
                count.Text = result.ToString();
            }
            if (!flagDivByZero)
            {
                count.Text = "Division 0";
                expression.Text = "";
                tempString = "0";
                flagDivByZero = true;
            }
            sign = Char.Parse(b.Content.ToString());
        }
        private void BtnCount_Click(object sender, RoutedEventArgs e)
        {
            if (!flag)
            {
                count.Text = "";
                flag = true;
                num = 0;
            }
            if ((expression.Text == "" && !flagMinBtn) || (count.Text == "0" && expression.Text == "") || (tempString == "0"))
            {
                count.Text = "";
                result = 0;
                tempString = "";
            }

            Button b = sender as Button;
            temp += b.Content.ToString();

            if ((temp == $"0{b.Content}") && (temp != $"0,"))
            {
                tempString = b.Content.ToString();
                count.Text = b.Content.ToString();
                temp = b.Content.ToString();
                return;
            }
            tempString += b.Content.ToString();
            count.Text = temp;
            flagMinBtn = true;
        }
        private void Calculation(double a2, char ch)
        {
            if (a2 == 0 && result == 0)
                return;
            if (ch == '+')
                result += a2;
            else if (ch == '-')
                result -= a2;
            else if (ch == '*')
                result *= a2;
            else if (ch == '/')
            {
                if (a2 == 0)
                {
                    result = 0;
                    flagDivByZero = false;
                }
                else result /= a2;
            }
        }
    }
}
