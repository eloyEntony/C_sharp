using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado_04_DataTable_DataSet_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();//empty

            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Surname");

            DataRow row = table.NewRow();

            row[0] = 1;
            row[1] = "Bob";
            row[2] = "Bob";  
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 2;
            row[1] = 2;
            row[2] = 2;

            table.Rows.Add(row);

            PrintTable(table);
        }

        private static void PrintTable(DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Console.Write("{0, -15}", table.Rows[i][j]);
                }
                
            }
            Console.ReadLine();
        }
    }
}
