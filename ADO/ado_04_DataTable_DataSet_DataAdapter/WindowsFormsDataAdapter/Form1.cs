using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDataAdapter
{
    public partial class Form1 : Form
    {
        static string connString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommandBuilder builder;
        DataSet set;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connString);
            adapter = new SqlDataAdapter(textBox1.Text, connection);
            builder = new SqlCommandBuilder(adapter);

            set = new DataSet();
            adapter.Fill(set);
            dataGridView1.DataSource = set.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adapter.Update(set);
        }
    }
}
