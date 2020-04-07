using System;
using System.Drawing;
using System.Windows.Forms;

namespace WF_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Text = "Task # 2 -> Catch button ";

            Button button = new Button();
            button.Text = "Click me";
            button.Size = new Size(100, 40);
            button.Top = 10;

            form.Controls.Add(button);

            button.MouseHover += Button_MouseHover;
            button.MouseClick += Button_MouseClick;

            form.ShowDialog();
        }

        private static void Button_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("You WIN !");
            ((sender as Button).Parent as Form).Close();
        }

        private static void Button_MouseHover(object sender, EventArgs e)
        {
            Random rand = new Random();
            (sender as Button).Top = rand.Next(((sender as Button).Parent as Form).Width / 2);
            (sender as Button).Left = rand.Next(((sender as Button).Parent as Form).Height / 2);
        }
    }
}
