using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            
            //1 [1]
            //передали selectcommand
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from Student", connection);
            //2
            //SqlConnection conn = new SqlConnection(connection);
            //SqlDataAdapter adapter = new SqlDataAdapter($"select * from Student", conn);
            //[2]
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);//будує команди яких не вистачає insert update delete
            //[3]
            //для зберігання данних з бази
            DataSet set = new DataSet();
            //[4]
            adapter.Fill(set);

            Debug.WriteLine($"select com : {adapter.SelectCommand.CommandText}");
            Debug.WriteLine($"insert com : {builder.GetInsertCommand().CommandText}");
            Debug.WriteLine($"delete com : {builder.GetDeleteCommand().CommandText}");
            Debug.WriteLine($"update com : {builder.GetUpdateCommand().CommandText}");

            PrintDataSet(set);
            InsertData(set.Tables[0]);

            //[5]
            adapter.Update(set);


            set = new DataSet();
            Console.WriteLine();
            adapter.Fill(set);
            PrintDataSet(set);


            //TestRowState();
        }

        private static void TestRowState()
        {
            var table = new DataTable("test");
            table.Columns.Add("Name", typeof(string));
            var row = table.NewRow();
            Console.WriteLine($"After newRow(): state = {row.RowState}");//detached
            table.Rows.Add(row);
            Console.WriteLine($"After rowsAdd(): state = {row.RowState}");//added
            row["Name"] = "Hello";
            Console.WriteLine($"After assigement(): state = {row.RowState}");//added
            table.AcceptChanges();
            Console.WriteLine($"After change(): state = {row.RowState}");//unchanged
            row[0] = "Bob";
            Console.WriteLine($"After second assigment(): state = {row.RowState}");//modified
            table.Rows[0].Delete();
            Console.WriteLine($"After delete: state = {row.RowState}");//deleted
        }

        private static void InsertData(DataTable dataTable)
        {
            var row = dataTable.NewRow();
            row[1] = "Bob";
            row[2] = "Bob";
            row[3] = 1;

            dataTable.Rows.Add(row);

        }

        private static void PrintDataSet(DataSet set)
        {
            foreach (DataTable table in set.Tables)
            {
                Console.WriteLine($"===>{table.TableName}");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        Console.Write("{0, -15}", table.Rows[i][j]);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
}
