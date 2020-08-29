using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

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
        string connectionStringToServer = @"Initial Catalog = master; Integrated Security=false;";
        string db;

        ObservableCollection<string> list = new ObservableCollection<string>();
        ObservableCollection<string> database = new ObservableCollection<string>();
        ObservableCollection<string> listInfo = new ObservableCollection<string>();
        int mode;
        SqlConnection connection = new SqlConnection();
        public MainWindow()
        {
            InitializeComponent();
            List.ItemsSource = list;
            TableInfo.ItemsSource = listInfo;
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mode = cbMode.SelectedIndex;
            list.Clear();
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
                    break;

                case 1:
                    connection.ConnectionString = $"Data Source={adress.Text};" + connectionStringToServer +
                        $"User ID= {name.Text}; Password={pass.Text};";
                    break;
            }
            connection.Open();
            AllDatabase();
        }

        private void AllDatabase()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", connection))
                {
                    IAsyncResult res = cmd.BeginExecuteReader(DataBaseCallBack, cmd);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DataBaseCallBack(IAsyncResult ar)
        {
            var res = (SqlCommand)ar.AsyncState;
            var reader = res.EndExecuteReader(ar);
            while (reader.Read())
                Dispatcher.Invoke(() => { cbDataBase.Items.Add(reader[0].ToString()); });
            reader.Close();
        }

        private void AllTables(string db)
        {
            try
            {
                connection.ChangeDatabase(db);
                using (SqlCommand com = new SqlCommand($"SELECT table_name FROM INFORMATION_SCHEMA.TABLES where TABLE_CATALOG = '{db}'", connection))
                {
                    list.Clear();
                    IAsyncResult res = com.BeginExecuteReader(ReaderCallBack, com);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReaderCallBack(IAsyncResult ar)
        {
            try
            {
                var res = (SqlCommand)ar.AsyncState;
                var rd = res.EndExecuteReader(ar);
                Thread.Sleep(3000);
                if (rd.HasRows)
                    while (rd.Read())
                        Dispatcher.Invoke(() => { list.Add(rd[0].ToString()); });
                rd.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbDataBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            db = cbDataBase.SelectedItem.ToString();
            AllTables(db);
        }
        private void GetData(string table)
        {
            try
            {
                using (SqlCommand command = new SqlCommand($"select * from {table}", connection))
                {
                    IAsyncResult res = command.BeginExecuteReader(GetDataCallBack, command);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GetDataCallBack(IAsyncResult ar)
        {
            string tmp = "";
            var res = (SqlCommand)ar.AsyncState;
            var rd = res.EndExecuteReader(ar);

            if (rd.HasRows)
            {
                do
                {
                    int line = 0;
                    while (rd.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < rd.FieldCount; i++)
                                tmp += $"[{rd.GetName(i)}]\t";
                            Dispatcher.Invoke(() => { listInfo.Add(tmp); });
                        }
                        line++;
                        tmp = "";
                        for (int i = 0; i < rd.FieldCount; i++)
                            tmp += $"[{rd.GetValue(i)}]\t";
                        Dispatcher.Invoke(() => { listInfo.Add(tmp); });
                    }
                }
                while (rd.NextResult());
            }
            rd.Close();
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                listInfo.Clear();
                GetData(List.SelectedItem.ToString());
            }
            catch (Exception ex)
            { }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connection.Close();
        }
    }
}


