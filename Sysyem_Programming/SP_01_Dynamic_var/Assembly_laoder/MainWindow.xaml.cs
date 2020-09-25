using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assembly_laoder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> dlls = new ObservableCollection<string>();
        ObservableCollection<string> metods = new ObservableCollection<string>();
        string assembly;
        public MainWindow()
        {
            InitializeComponent();
            lbDLL.ItemsSource = dlls;
            lbMetod.ItemsSource = metods;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                DirectoryInfo d = new DirectoryInfo(dialog.SelectedPath);
                FileInfo[] Files = d.GetFiles("*.dll");  
                foreach (var item in Files)
                {
                    dlls.Add(item.Name);
                }
            }
        }

        private void Load_Metod(string assembly)
        {
            AppDomain test = AppDomain.CreateDomain("Test");
            Assembly a = test.Load(AssemblyName.GetAssemblyName(assembly));
            Type[] types = a.GetTypes();
            foreach (Type type in types)
            {    
                MemberInfo[] members = type.GetMembers();

                foreach (MemberInfo member in members)
                {
                    metods.Add(member.Name);
                }
            }
        }
        
        private void lbDLL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            assembly = lbDLL.SelectedItem.ToString();
            Load_Metod(assembly);
        }

        private void lbMetod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbMetod.SelectedItem.ToString() == "Add")
            {
                stMetod.Visibility = Visibility.Visible;
            }
        }

        private void tbRes_Click(object sender, RoutedEventArgs e)
        {
            if((string.IsNullOrEmpty(tb1.Text) != true) && (string.IsNullOrEmpty(tb2.Text) != true))
            {
                AppDomain app = AppDomain.CreateDomain("aa");
                var asm = app.Load(AssemblyName.GetAssemblyName(assembly));
                var type = asm.GetType("MathLibrary.MathLibrary");
                var obj = Activator.CreateInstance(type);
                var res = type.GetMethod("Add").Invoke(obj, new object[] { int.Parse(tb1.Text), int.Parse(tb2.Text) });
                lbRes.Content = res.ToString();
            }
        }
    }
}
