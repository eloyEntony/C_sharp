using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_skreen
{
    class Program
    {
        const int port = 2021;
        const string ip = "127.0.0.1";
        static UdpClient server = new UdpClient();
        static void Main(string[] args)
        {
            Console.WriteLine("Wait...");
            Thread.Sleep(1000);
            //GetSkreen();
            SendFile();
        }

        private static void SendFile()
        {
            var data = File.ReadAllBytes("1.jpeg");
            int partSize = 8192;
            try
            {
                if (data.Length > partSize)
                {
                    int offset = 0;
                    int parts = data.Length / partSize + 1;


                    byte[] size = Encoding.UTF8.GetBytes(parts.ToString());
                    server.Send(size,size.Length , ip, port);
                    Console.WriteLine("Part count : " + size.Length);


                    int last = data.Length - (parts-1) * partSize;
                    byte[] lastbytes = new byte[last];

                    byte[][] arr = new byte[parts][];

                    for (int i = 0; i < parts-1; i++)
                    {
                        arr[i] = new byte[partSize];

                        for (int j = 0; j < partSize; j++)                        
                            arr[i][j] = data[j + offset];
                        
                        offset += partSize;
                    }
                    //last part

                    for (int i = parts-1; i < parts; i++)
                    {
                        arr[i] = new byte[lastbytes.Length];
                        for (int j = 0; j < lastbytes.Length; j++)                        
                            arr[i][j] = data[j + offset];
                        
                        offset += lastbytes.Length;
                    }

                    //send all part
                    for (int i = 0; i < parts; i++)
                    {
                        byte[] datas = arr[i];
                        server.Send(datas, arr[i].Length, ip, port);
                        Console.WriteLine(1);
                    }
                }
                Console.WriteLine("Send");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                server.Close();
            }

            Console.WriteLine("Send ok");
            Console.Read();
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
