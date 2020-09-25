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

namespace ado_08_Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MyShop context = new MyShop();
            DataGrid dataGrid = new DataGrid();
            TabItem tab = new TabItem();

            var tmp = context.Orders.Where(x => x.Client_ID == 1).ToList();            
            dataGrid.ItemsSource = tmp;
            tab.Header = "1";
            tab.Content = dataGrid; 
            tb.Items.Add(tab);

            //Показати історію замовлень певного користувача за певний період
            var firtsdate = DateTime.Parse("04.09.2018");
            var seconddate = DateTime.Parse("05.02.2020");
            var tmp2 = context.Orders.Where(x => x.Client_ID == 1 && ((x.Date > firtsdate) || (x.Date < seconddate)) ).ToList();
            DataGrid dataGrid2 = new DataGrid { ItemsSource = tmp2};
            TabItem tab2 = new TabItem { Header = "2" , Content = dataGrid2 };            
            tb.Items.Add(tab2);



            //вивести всі замовлення за вчора
            var date = DateTime.Parse("2018-05-12");
            var tmp3 = context.Orders.Where(x => x.Date == date).ToList();
            DataGrid dataGrid3 = new DataGrid {ItemsSource = tmp3 };
            TabItem tab3 = new TabItem { Header = "3" , Content = dataGrid3 };            
            tb.Items.Add(tab3);



            //вивести всі замовлення до Барселони

            var tmp4 = context.Orders.Where(x => x.Addresses.Country == "Ukraine").ToList();
            DataGrid dataGrid4 = new DataGrid { ItemsSource = tmp4 };
            TabItem tab4 = new TabItem { Header = "4", Content = dataGrid4 };
            tb.Items.Add(tab4);

            //вивести всі продукти американських виробників
            // TODO: migration

            //var tmp5 = context.Products.Where(x => x.Manufactures.Contains
            //                                    (context.Manufactures.Where(z => z.Addresses.Contains
            //                                    (context.Addresses.Where(f => f.Country == "Ukraine").ToList())).ToList())).ToList();
            //DataGrid dataGrid5 = new DataGrid { ItemsSource = tmp5 };
            //TabItem tab5 = new TabItem { Header = "5", Content = dataGrid5 };
            //tb.Items.Add(tab5);
            //вивести всі адреси потужностей виробника конкретного товару


            //Вивести всі країни виробників і без повторів.

            var tmp7 = context.Addresses.Where(x => x.Manufacture_ID != null).Select(x=>x.Country).ToList();
            DataGrid dataGrid7 = new DataGrid { ItemsSource = tmp7 };
            TabItem tab7 = new TabItem { Header = "7", Content = dataGrid7 };
            tb.Items.Add(tab7);

            //Вивести користувачів з максимальною сумою замовлення.

            var max = context.Orders.Max(x => x.TotalPrice);
            var client = context.Orders.Where(x => x.TotalPrice == max).Select(x => x.Client_ID).FirstOrDefault();            
            var tmp8 = context.Clients.Where(x => x.ID == client).ToList() ;

            DataGrid dataGrid8 = new DataGrid { ItemsSource = tmp8 };
            TabItem tab8 = new TabItem { Header = "8", Content = dataGrid8 };
            tb.Items.Add(tab8);

            //Вивести емейл користувачів, що замовляли illegal продукти
            

            //var legal = context.Orders.Where(z => z.Products.Equals(context.Products.Where(x=>x.IsLegal == true))).ToList();
            //var tmp9 = context.Clients.Where(x => x.Orders.Equals(legal));

            //DataGrid dataGrid9 = new DataGrid { ItemsSource = tmp9 };
            //TabItem tab9 = new TabItem { Header = "9", Content = dataGrid9 };
            //tb.Items.Add(tab9);
            //Вивести перелік замовлень, які необхідно доставити по адресах, які містять к - сть літер 
            //більше 1 в додатковому полі Коментар таблиці адреса


            //Вивести перелік користувачів, які отримають продукти, термін придатності яких закінчиться 1.04.19
        }
    }
}
