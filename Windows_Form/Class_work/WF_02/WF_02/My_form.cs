using System;
using System.Drawing;
using System.Windows.Forms;

namespace WF_02
{
    public partial class My_form : Form
    {
        public My_form()
        {
            InitializeComponent();
        }

        int i = 0;        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = ++i + " s";
            int max_withs = this.ClientSize.Width;
            int max_heights = this.ClientSize.Height;
            Point point = lbl_time.Location;

            if (point.X < (max_withs - point.X / 9) && point.Y == 0)
                lbl_time.Location = new Point(point.X += 10, point.Y);

            else if (point.X > (max_withs - point.X / 9) && point.Y < (max_heights - point.Y / 1.6))
                lbl_time.Location = new Point(point.X, point.Y += 10);

            else if (point.Y >= (max_heights - point.Y / 1.6))
                lbl_time.Location = new Point(point.X -= 10, point.Y);

            if (point.X <= 0)
                lbl_time.Location = new Point(point.X, point.Y -= 10);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Пройшло : " + lbl_time.Text, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ((sender as Button).Parent as Form).Close();
        }
    }
}
