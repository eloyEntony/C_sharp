using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_skreen_client
{    
    class Program
    {
        const int port = 2021;
        static UdpClient client = new UdpClient(port);
        static List<byte[]> list = new List<byte[]>();
        static void Main(string[] args)
        {
            int partSize = 8192;
            string path = ReceiveInfo();

            int count = int.Parse(path);
            int x = 0;
            while (x!=count)
            {
                Receive();
                x++;
            }

            byte[] data = new byte[list.Count* partSize];

            for (int i = 0; i < list.Count; i++)            
                list[i].CopyTo(data, i* partSize);
            

            File.WriteAllBytes("1.jpeg", data);
            Console.WriteLine("Ok");
            Console.ReadLine();
        }
        private static string ReceiveInfo()
        {
            IPEndPoint ip = null;
            var data = client.Receive(ref ip);
            string path = Encoding.UTF8.GetString(data);
            Console.WriteLine(path);
            return path;
        }
        private static void Receive()
        {
            IPEndPoint ip = null;
            byte[] data = client.Receive(ref ip);
            list.Add(data);
        }
    }
}
