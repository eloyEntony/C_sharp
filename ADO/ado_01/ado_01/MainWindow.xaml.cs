using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

//Приєднаний режим Ado.Net

//Вікно WPF

//Випадаючий список з вибором режиму аутентифікації (віндовс чи сервер)
//Якщо вибрали сервер - то ввести логін та пароль, а також адресу сервера

//Після того як натиснути кнопку Підключитись - у випадаючий список (ComboBox)
//на середню стек панель вивести перелік доступних БД (select * from sys.databases)

//Після вибору бази даних у випадайці - показати знизу таблиці, які доступні в обраній БД

//Після вибору таблиці - показати в третій стек-панелі вміст даної таблиці

namespace ado_01
{
    public partial class MainWindow : Window
    {
        string connectionStringToWindows = @"Data Source=(localdb)\MSSQLLocalDB;
                                                    Initial Catalog=master;
                                                    Integrated Security=True;";
        string connectionStringToServer = @"    Initial Catalog = master;
                                                Integrated Security=false;";


        List<string> list = new List<string>();
        ObservableCollection<string> database = new ObservableCollection<string>();
        int mode;
        SqlConnection connection = new SqlConnection();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mode = cbMode.SelectedIndex;
            List.Items.Clear();
            if (mode == 1)
                StackForServer.Visibility = Visibility.Visible;
            else
                StackForServer.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (mode)
            {
                case 0:
                    connection.ConnectionString = connectionStringToWindows;
                    AllDatabase(connection);
                    break;

                case 1:                    
                    connection.ConnectionString = $"Data Source={adress.Text};" + connectionStringToServer +
                        $"User ID= {name.Text}; Password={pass.Text};";
                    AllDatabase(connection);
                    break;
            }            
        }

        private void AllDatabase(SqlConnection connection)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", connection))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                cbDataBase.Items.Add(dr[0].ToString());
                            }
                            
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AllTables(string db)
        {
            using (connection)
            {
                try
                {
                    connection.ConnectionString = connectionStringToWindows;
                    connection.Open();
                    connection.ChangeDatabase(db);
                    using (SqlCommand com = new SqlCommand($"SELECT table_name FROM INFORMATION_SCHEMA.TABLES where TABLE_CATALOG = '{db}'", connection))
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            List.Items.Clear();
                            while (reader.Read())
                            {
                                List.Items.Add(reader[0].ToString());
                            }
                        }

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        string db;
        private void cbDataBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            db = cbDataBase.SelectedItem.ToString();
            AllTables(db);
        }


        private void GetData(string table)
        {
            using (connection)
            {
                try
                {
                    connection.ConnectionString = connectionStringToWindows;
                    connection.Open();
                    connection.ChangeDatabase(db);
                    string tmp = "";

                    using (SqlCommand command = new SqlCommand($"select * from {table}", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                do
                                {
                                    int line = 0;
                                    while (reader.Read())
                                    {
                                        if (line == 0)
                                        {
                                            for (int i = 0; i < reader.FieldCount; i++)
                                                tmp += $"[{reader.GetName(i)}]\t";                                            
                                            TableInfo.Items.Add(tmp);
                                        }
                                        line++;
                                        tmp = "";
                                        for (int i = 0; i < reader.FieldCount; i++)
                                            tmp += $"[{reader.GetValue(i)}]\t";
                                        TableInfo.Items.Add(tmp);
                                    }
                                }
                                while (reader.NextResult());
                            }
                        }
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TableInfo.Items.Clear();
            GetData(List.SelectedItem.ToString());
        }
    }    
}


