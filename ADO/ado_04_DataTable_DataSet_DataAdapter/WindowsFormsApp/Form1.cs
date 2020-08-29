using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        DataSet set;
        public Form1()
        {
            InitializeComponent();
            set = new DataSet();
          //  FillDataSet(set);
            dataGridView1.DataSource = set.Tables[0];
            LoadXML(set);
        }

        private void LoadXML(DataSet set)
        {
            set.ReadXml("car.xml");
        }

        private void FillDataSet(DataSet set)
        {
            DataTable table = new DataTable("tblCars");
            DataColumn col = new DataColumn("ID")
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                Caption = "Car ID",
                DataType = typeof(int),
                Unique = true
            };

            DataColumn mark = new DataColumn("Brand", typeof(string)) { Caption = "Brand" };
            DataColumn model = new DataColumn("Model", typeof(string));
            DataColumn year = new DataColumn("Year", typeof(int));
            DataColumn price = new DataColumn("Price", typeof(double));

            table.Columns.AddRange(new[] { col, mark, model, year, price });

            DataRow row = table.NewRow();
            //row["ID"] = 1;
            row["Brand"] = "Audi";
            row["Model"] = "A8";
            row["Year"] = 2018;
            row["Price"] = 17000;
            table.Rows.Add(row);

            row = table.NewRow();
            row["Brand"] = "BMW";
            row["Model"] = "X8";
            row["Year"] = 2018;
            row["Price"] = 30000;
            table.Rows.Add(row);

            set.Tables.Add(table);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search
            DataRow[] rows = set.Tables[0].Select($"ID = {Int32.Parse (textBox1.Text)}");
            if (rows.Length != 0)
            {
                rows[0].Delete();
                //set.Tables[0].AcceptChanges();
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("NO");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow[] rows = set.Tables[0].Select($"ID = {Int32.Parse(textBox2.Text)}");
            rows[0]["Price"] = Convert.ToDouble(textBox3.Text);
            //set.Tables[0].AcceptChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            set.WriteXml("car.xml");
        }
    }
}
