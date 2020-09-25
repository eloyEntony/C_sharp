using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Start_or_Stop_my_programs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> stopProc = new ObservableCollection<string>();
        ObservableCollection<string> startProc = new ObservableCollection<string>();
        ObservableCollection<Process> processes = new ObservableCollection<Process>();

        public MainWindow()
        {
            InitializeComponent();
            lbStop.ItemsSource = stopProc;
            lbRun.ItemsSource = startProc;

            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] Files = d.GetFiles("*.exe");            
            foreach (var item in Files)
            {
                stopProc.Add(item.Name);
                processes.Add(new Process { StartInfo = new ProcessStartInfo { FileName = item.Name} });
            }

        }
        Process tmp;
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbStop.SelectedItem.ToString() != null)
                {
                    string proc = lbStop.SelectedItem.ToString();
                    ChangeList(proc, stopProc, startProc);
                    tmp = processes.FirstOrDefault(x => x.StartInfo.FileName == proc);
                    SS(true, tmp);
                }
            }
            catch { }
            
        }
        private void Button_Stop(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbRun.SelectedItem.ToString() != null)
                {
                    string proc = lbRun.SelectedItem.ToString();
                    ChangeList(proc, startProc, stopProc);

                    tmp = processes.FirstOrDefault(x => x.StartInfo.FileName == proc);
                    SS(false, tmp);
                }
            }
            catch { }
            
        }
        private void SS(bool t, Process process)
        {
            if(t == true)
            {
                process.Start();
                return;
            }
            process.Kill();
        }

        static void ChangeList(string proc, ObservableCollection<string> from, ObservableCollection<string> to) 
        {
            var tmp = from.FirstOrDefault(x => x == proc).ToString();
            from.Remove(tmp);
            to.Add(tmp);
        }

       
    }
}
