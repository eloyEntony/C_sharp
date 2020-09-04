using CodeFirst_Shop;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace EF_CodeFirst_WPF_Shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ApplicationContext context = new ApplicationContext();

            context.Clients.Load();// загружаем данные
            DG_clients.ItemsSource = context.Clients.Local.ToBindingList();// устанавливаем привязку к кэшу

            context.Products.Load();
            DG_product.ItemsSource = context.Products.Local.ToBindingList();

            context.Orders.Load();
            DG_orders.ItemsSource = context.Orders.Local.ToBindingList();
        }
    }
}
