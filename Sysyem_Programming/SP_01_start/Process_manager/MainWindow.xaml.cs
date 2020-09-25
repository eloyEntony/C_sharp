using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Process_manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> processes = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();            
            Update();
            lb.ItemsSource = processes;
        }

        private void Update()
        {
            processes.Clear();
            try
            {
                foreach (var item in Process.GetProcesses())
                {

                    processes.Add(item.ProcessName);

                }
            }
            catch { }
        }    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(tbProc.Text + ".exe");
            }
            catch { MessageBox.Show("Invalid process"); }
        }
        string proc;
        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            proc = lb.SelectedItem.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Process killProc = Process.GetProcessesByName(proc).FirstOrDefault();
                killProc.Kill();
                
                processes.Remove(proc);
            }
            catch { }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Update();
        }

       
    }
}
