using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace BookDB_table
{
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        DataTable table;
        DataSet set;
        TabItem item;
        DataGrid grid;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            connection = new SqlConnection(connectionString);
            table = new DataTable();
            set = new DataSet();
            connection.Open();
            CreateTabs(set);
        }
        private void CreateTabs(DataSet set)
        {
            using (SqlCommand cmd = new SqlCommand($"SELECT name FROM sys.tables", connection))//INFORMATION_SCHEMA.TABLES where TABLE_CATALOG = 'BooksDB'", connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            grid = new DataGrid();                           
                            item = new TabItem();
                            item.Header = reader.GetValue(i).ToString();
                            item.Content = grid;
                            TabControl.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            table = new DataTable();
            table.TableName = (TabControl.SelectedItem as TabItem).Header.ToString();
            using (SqlCommand command = new SqlCommand($"select * from {(TabControl.SelectedItem as TabItem).Header}", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    table.Clear();
                    if (reader.HasRows)
                    {
                        do
                        {
                            int line = 0;
                            while (reader.Read())
                            {
                                if (line == 0)
                                    for (int i = 0; i < reader.FieldCount; i++)                                    
                                        table.Columns.Add(reader.GetName(i));
                                
                                line++;

                                DataRow r = table.NewRow();

                                for (int i = 0; i < reader.FieldCount; i++)
                                    r[i] = reader[i];
                                
                                table.Rows.Add(r);
                            }
                        }
                        while (reader.NextResult());
                    }
                }
            }
            ((TabControl.SelectedItem as TabItem).Content as DataGrid).ItemsSource = table.DefaultView;
            ShowButons();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            table.WriteXml("DataBase.xml");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand($"delete Books where Id = {tbNum.Text}",connection))
            {
                cmd.ExecuteNonQuery();
                DataRow[] rows = table.Select($"Id = {int.Parse(tbNum.Text)}");

                if (rows.Length > 0)
                    rows[0].Delete();
            } 
        }

        private void ShowButons()
        {
            if ((TabControl.SelectedItem as TabItem).Header.ToString() == "Books")
                Butonss.Visibility = Visibility.Visible;    
            else
                Butonss.Visibility = Visibility.Collapsed;
        }      

        private void tbNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbNum.Text))
                btndel.Visibility = Visibility.Visible;            
            else
                btndel.Visibility = Visibility.Hidden;
        }
    }
}
