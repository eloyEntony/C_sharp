using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_12
{
    public partial class Telefon_2 : Form
    {
        Contact contact;
        bool addNew = true;
        string phonePattern = @"(\s*)?(\+)?([-_():= +]?\d[-_():= +]?){10,14}(\s*)?";
        public Telefon_2(Contact cont, bool addNew)
        {
            InitializeComponent();
            this.contact = cont;
            this.addNew = addNew;

            if (!this.addNew)
            {
                tbName.Text = cont.Name;
                tbNumber.Text = cont.Number;
                pictureBox1.Image = cont.Image;
                this.Text = "Edit ...";
                this.btnAdd.Text = "Edit";
            }
            else
                this.Text = "Add new ...";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (contact == null)
                contact = new Contact();

            if(tbName.Text == string.Empty)
            {
                MessageBox.Show("Incorect name");
                tbName.Text = String.Empty;
                tbName.Focus();
                return;
            }

            contact.Name = tbName.Text;            
            contact.Image = pictureBox1.Image;

            if (Regex.IsMatch(tbNumber.Text, phonePattern, RegexOptions.IgnoreCase))
                contact.Number = tbNumber.Text;
            else
            {
                MessageBox.Show("Incorect number");
                tbNumber.Text = String.Empty;
                tbNumber.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG files (*.jpg)| *.jpg";
            ofd.FileName = "Type name here";
            ofd.InitialDirectory = @"C:\Users\Anton\Desktop";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                contact.Image = Image.FromFile(ofd.FileName);

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
            
        }
    }
}
