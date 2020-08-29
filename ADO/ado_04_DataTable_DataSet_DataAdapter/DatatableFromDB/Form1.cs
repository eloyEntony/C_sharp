using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatatableFromDB
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        DataTable table;
        DataSet set;
        TabPage page;

        public Form1()
        {
            InitializeComponent();

            string connectS = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            connection = new SqlConnection(connectS);
            table = new DataTable();
            set = new DataSet();
            FillTabControl(set, connection);
            tabControl1_SelectedIndexChanged(null, null);
            connection.Open();

        }
        private void FillTabControl(DataSet set, SqlConnection connection)
        {
            try
            {
                using (SqlCommand com = new SqlCommand($"SELECT table_name FROM INFORMATION_SCHEMA.TABLES where TABLE_CATALOG = 'University'", connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int line = 0;
                            if(line == 0)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    page = new TabPage();
                                    page.Text = reader.GetValue(i).ToString();
                                    page.Controls.Add(new DataGridView() { Dock= DockStyle.Fill});
                                    tabControl1.TabPages.Add(page);
                                }                                
                                line++;
                            }                            
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void FillTable(DataTable table, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("select * from Sudent", connection);

            try
            {
                connection.Open();

                using (SqlDataReader rd = command.ExecuteReader())
                {
                    if (rd.HasRows)
                    {
                        int line = 0;
                        while (rd.Read())
                        {
                            if(line == 0)
                            {
                                for (int i = 0; i < rd.FieldCount; i++)
                                {
                                    table.Columns.Add(rd.GetName(i));
                                }
                                line++;
                            }

                            DataRow r = table.NewRow();

                            for (int i = 0; i < rd.FieldCount; i++)
                            {
                                r[i] = rd[i];
                            }
                            table.Rows.Add(r);
                        }
                    }
                }
                connection.Close();
            }catch(SqlException ex)
            {
                
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            table = new DataTable();
            using (SqlCommand command = new SqlCommand($"select * from {tabControl1.SelectedTab.Text}", connection))
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
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        table.Columns.Add(reader.GetName(i));
                                    }
                                }
                                line++;

                                DataRow r = table.NewRow();

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    r[i] = reader[i];
                                }
                                table.Rows.Add(r);
                            }
                        }
                        while (reader.NextResult());
                    }
                }
            }
            (tabControl1.SelectedTab.Controls[0] as DataGridView).DataSource = table;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }
    }
    
}
