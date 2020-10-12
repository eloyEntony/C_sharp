using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyAutoRun
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RegistryKey registryKey = Registry.CurrentUser;
        RegistryKey run;
        ObservableCollection<MyApp> apps = new ObservableCollection<MyApp>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = apps;

            run = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            foreach (var item in run.GetValueNames())
            {
                apps.Add(new MyApp(item, run.GetValueKind(item).ToString(), run.GetValue(item).ToString()));
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "exe files (*.exe)|*.exe";
            if(openFileDialog.ShowDialog() == true)
            {
               var tmp = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                //DirectoryInfo info = new DirectoryInfo(openFileDialog.FileName);
               // var tmp = info.Name;
                run.SetValue(tmp, openFileDialog.FileName);
                apps.Add(new MyApp(tmp, run.GetValueKind(tmp).ToString(), run.GetValue(tmp).ToString()));
            }             
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    class MyApp
    {
        string name;
        string type;
        string value;
        public MyApp(string _name, string _type, string _value)
        {
            this.name = _name;
            this.type = _type;
            this.value = _value;
        }

        public override string ToString()
        {
            return $"{this.name, -50}{this.type, -15}{this.value, -25}";
        }
    }
}
