using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_skreen
{
    class Program
    {
            const int port = 2020;
           static  UdpClient server = new UdpClient(port);
        static void Main(string[] args)
        {
            Console.WriteLine("Wait...");

            GetSkreen();
            SendFile();
        }

        private static void SendFile()
        {
            var data = File.ReadAllBytes("1.jpeg");

           
        }

        private static void GetSkreen()
        {
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            printscreen.Save("1.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
