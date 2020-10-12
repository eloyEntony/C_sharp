using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace MyRegister
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<RegistryKey> keys = new List<RegistryKey>();
        List<TreeViewItem> Trees = new List<TreeViewItem>();
        static RegistryKey key1;
        static RegistryKey key2;
        static RegistryKey key3;
        static RegistryKey key4;
        static RegistryKey key5;
        public MainWindow()
        {
            InitializeComponent();

            key1 = Registry.LocalMachine;
            key2 = Registry.CurrentUser;
            key3 = Registry.ClassesRoot;
            key4 = Registry.CurrentConfig;
            key5 = Registry.Users;

            keys.AddRange(new List<RegistryKey> { key1, key2, key3, key4, key5 });

            foreach (var item in keys)
                Trees.Add(new TreeViewItem() { Header = item.Name, Tag = item.Name });

            foreach (var item in Trees)
                tv.Items.Add(item);

            for (int i = 0; i < keys.Count; i++)
            {
                GetSubTree(keys[i], Trees[i]);
            }


            foreach (var item in keys)
                item.Close();

        }
        int h = 0;

        TreeViewItem tmp;
        private void GetSubTree(RegistryKey key, TreeViewItem viewItem)
        {
            //try
            //{
            //    for (int i = 0; i < tv.Items.Count; i++)
            //    {
            //        foreach (var item in Trees)
            //        {
            //            for (int k = 0; k < item.Items.Count; k++)
            //            {
            //                if (viewItem.Header.Equals(item.Items[i]))
            //                    return;
            //            }
            //        }
            //    }
            //}
            //catch { }
           

            if (h > 4)
                return;

            h++;
            
            foreach (var i in key.GetSubKeyNames())
            {
                try
                {
                    tmp = new TreeViewItem();
                    tmp.Items.Add(new TreeViewItem());
                    tmp.Header = i;
                    tmp.Expanded += TreeViewItem_Expanded;
                    tmp.Tag = key.Name + "\\" + i;
                    viewItem.Items.Add(tmp);

                }
                catch { }                
            }
            h = 0;

        }
        int i = 0;
        private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem viewItem = sender as TreeViewItem;
            RegistryKey key = key1;//.OpenSubKey(viewItem.Header.ToString());
            if (i == 0)
            {
                key = key.OpenSubKey(viewItem.Header.ToString());
            }
            else
            {
                string tag = viewItem.Tag.ToString();
                string res = tag.Substring(key.Name.Length + 1, tag.Length - (key.Name.Length + 1));
                key = key.OpenSubKey(res);
            }
            i++;
            
            GetSubTree(key, viewItem);
        }
    }
}
