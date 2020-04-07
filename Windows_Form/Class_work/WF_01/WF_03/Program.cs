using System;
using System.Drawing;
using System.Windows.Forms;

namespace WF_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            Console.WriteLine("Enter width");
            int width = int.Parse(Console.ReadLine());
            form.Width = width;

            Console.WriteLine("Enter height");
            int height = int.Parse(Console.ReadLine());
            form.Height = height;

            Console.WriteLine("Enter Text");
            string text = (Console.ReadLine());
            form.Text = text;

            Console.WriteLine("Enter color");
            string color = Console.ReadLine();
            form.BackColor = Color.FromName(color);

            form.ShowDialog();
        }
    }
}
