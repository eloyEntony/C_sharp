using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_ImageInSql
{

    public partial class Form1 : Form
    {
        static string connectionStirng = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlCommandBuilder builder;
        DataSet set;
        SqlCommand command;
        Image image;
        Byte[] redyImage;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionStirng);
            adapter = new SqlDataAdapter("select * from Books", connection);
            builder = new SqlCommandBuilder(adapter);

            set = new DataSet();
            adapter.Fill(set);
            dataGridView1.DataSource = set.Tables[0];
            command = new SqlCommand($"update Books set Picture = @p1 where Id = @p2");

            
        }

        public byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
                image = Image.FromFile(dialog.FileName);
                redyImage = ImageToByteArray(image);
            }
            command.Parameters.AddWithValue("@p1", redyImage);
            command.Parameters.AddWithValue("@p2", Convert.ToInt32(textBox1.Text));

            /////////////////////перемальовую картинку на меншу
            //Image img = Image.FromFile(dialog.FileName);
            //int w = 200, h = 200;

            //Image newIMG = new Bitmap(w, h);
            //Graphics g = Graphics.FromImage(newIMG);
            //g.DrawImage(img, 0, 0, w, h);
            //newIMG.Save("temp.jpg");
            //////////////////////
            set.Tables[0].Rows[int.Parse(textBox1.Text)]["Picture"] = redyImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adapter.UpdateCommand = command;
            adapter.Update(set);
        }
    }
}
