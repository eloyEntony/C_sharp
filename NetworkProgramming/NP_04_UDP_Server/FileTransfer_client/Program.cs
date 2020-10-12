using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer_client
{
    class Program
    {
        const int port = 2020;
            static UdpClient client = new UdpClient();
        static void Main(string[] args)
        {
            ReceiveInfo();
        }

        private static void ReceiveInfo()
        {
            IPEndPoint ip = null;
            var data = client.Receive(ref ip);
            string path = Encoding.UTF8.GetString(data);
            Receive(path);
        }

        private static void Receive(string path)
        {
            IPEndPoint ip = null;
            var data = client.Receive(ref ip);

            File.WriteAllBytes("text.txt", data);
            Console.WriteLine("OK");
        }
    }
}
