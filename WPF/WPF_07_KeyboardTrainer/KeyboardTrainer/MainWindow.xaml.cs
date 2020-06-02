using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace KeyboardTrainer
{
    internal sealed partial class MainWindow : Window
    {
        int tempTimer = 0;
        int fails = 0;
        Random rendChar = new Random();
        string baceString = "QWERTYUIOPASDFGHJKLZXCVBNM~!@#$%^&*()_+{}|:\"<>?1234567890[],./\\`-=;'qwertyuiopasdfghjklzxcvbnm";
        bool flagCapsLock = true;
        bool flagBackspase = true;
        bool mesStop = true;
        DispatcherTimer timer = null;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    if ((it as Grid).Name == "keys")
                    {
                        foreach (var item in (it as Grid).Children)
                        {
                            if (item is StackPanel)
                            {
                                if ((item as StackPanel).Name =="lowerKeys" || (item as StackPanel).Name == "upperKeys")
                                {
                                    foreach (var j in (item as StackPanel).Children)
                                    {
                                        foreach (var h in (j as StackPanel).Children)
                                        {
                                            if (h is Grid)
                                            {
                                                foreach (var i in (h as Grid).Children)
                                                {
                                                    if ((i as Border).Child is TextBlock)
                                                    {
                                                        TextBlock tb = (TextBlock)(i as Border).Child;                                                       
                                                        if (tb.Name == e.Key.ToString())
                                                        {                                                         
                                                            (i as Border).CornerRadius = new CornerRadius(30);
                                                            //tb.Opacity = 0.1;
                                                            (i as Border).Child = tb;
                                                        }

                                                        if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                                        {
                                                            Upper();
                                                            if (flagCapsLock)
                                                                Upper();
                                                            else
                                                                Lower();
                                                        }
                                                        if (e.Key.ToString() == "Capital" && flagCapsLock == true)
                                                        {
                                                            Upper();     
                                                            //flagCapsLock = false;
                                                        }
                                                        else if (e.Key.ToString() == "Capital" && flagCapsLock == false)
                                                        {
                                                            Lower();
                                                            flagCapsLock = true;
                                                        }
                                                        else if (e.Key.ToString() == "Back")
                                                            flagBackspase = false;                                                        
                                                        else
                                                            flagBackspase = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Lower()
        {
            upperKeys.Visibility = Visibility.Collapsed;
            lowerKeys.Visibility = Visibility.Visible;
        }
        private void Upper()
        {
            upperKeys.Visibility = Visibility.Visible;
            lowerKeys.Visibility = Visibility.Collapsed;           
        }
        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    if ((it as Grid).Name == "keys")
                    {
                        foreach (var item in (it as Grid).Children)
                        {
                            if (item is StackPanel)
                            {
                                if ((item as StackPanel).Name == "lowerKeys" || (item as StackPanel).Name == "upperKeys")
                                {
                                    foreach (var j in (item as StackPanel).Children)
                                    {
                                        foreach (var h in (j as StackPanel).Children)
                                        {
                                            if (h is Grid)
                                            {
                                                foreach (var i in (h as Grid).Children)
                                                {
                                                    if ((i as Border).Child is TextBlock)
                                                    {
                                                        TextBlock tb = (TextBlock)(i as Border).Child;
                                                       
                                                        if (tb.Name == e.Key.ToString())
                                                        {
                                                           // tb.Opacity = 1; 
                                                            (i as Border).CornerRadius = new CornerRadius(10);
                                                            (i as Border).Child = tb;
                                                        }

                                                        if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                                        {
                                                            Lower();
                                                            if (!flagCapsLock)
                                                                Upper();

                                                            else
                                                                Lower();

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!mesStop)
            {
                MessageBox.Show($"Задание завершенно!\n Коилчество символов {linePrograms.Text.Length}.\n Коилчество ошибок {Fails.Content}.\nДля завершения задания нажмите Stop.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                mesStop = true;
            }
        }
        private void lineUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = linePrograms.Text.Substring(0, lineUser.Text.Length);
            if (lineUser.Text.Equals(str))
            {
                if (flagBackspase)
                    Speed();
                
                lineUser.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                if (flagBackspase)
                    fails++;
                
                lineUser.Foreground = new SolidColorBrush(Colors.Red);
                Fails.Content = fails;
            }
            if (lineUser.Text.Length == linePrograms.Text.Length)
            {
                timer.Stop();
                Speed();
                lineUser.IsReadOnly = true;
                mesStop = false;
            }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false;
            SliderDifficulty.IsEnabled = false;
            CaseSensitive.IsEnabled = false;
            Stop.IsEnabled = true;
            tempTimer = 0;
            timer.Start();
            CollectString(Convert.ToInt32(Difficulty.Content), baceString, !(bool)CaseSensitive.IsChecked);
            lineUser.IsReadOnly = false;
            lineUser.IsEnabled = true;
            lineUser.Focus();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            tempTimer++;
            Speed();
        }
        private void CollectString(int countChar, string baceString, bool flagSensitive)
        {
            string carhs = "";
            int sensitive = (flagSensitive) ? 47 : 0;
            for (int i = 0; i < countChar; i++)
            {
                carhs += baceString[rendChar.Next(sensitive, baceString.Length)];
            }
            carhs += " ";
            int countString = (flagSensitive) ? 55 : 60;
            for (int i = 0; i < countString; i++)
            {
                linePrograms.Text += carhs[rendChar.Next(0, carhs.Length)];
            }
        }
        private void SliderDifficulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int num = 0;
            Slider s = sender as Slider;
            num = (int)s.Value;
            Difficulty.Content = num.ToString();
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = true;
            SliderDifficulty.IsEnabled = true;
            CaseSensitive.IsEnabled = true;
            Stop.IsEnabled = false;
            lineUser.Text = "";
            linePrograms.Text = "";
            Fails.Content = 0;
            SpeedChar.Content = 0;
            lineUser.IsReadOnly = true;
            lineUser.IsEnabled = false;
            timer.Stop();
            tempTimer = 0;
            fails = 0;
        }      
        private void CaseSensitive_Checked(object sender, RoutedEventArgs e)
        {
            SliderDifficulty.Maximum = 94;
        }
        private void CaseSensitive_Unchecked(object sender, RoutedEventArgs e)
        {
            SliderDifficulty.Maximum = 47;
        }
        void Speed()
        {
            SpeedChar.Content = Math.Round(((double)lineUser.Text.Length / tempTimer) * 60).ToString();
        }
    }
}