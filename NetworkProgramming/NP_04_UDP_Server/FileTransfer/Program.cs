using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    class Program
    {
        const int port = 2020;
            const string ip = "127.0.0.1";
        static UdpClient server = new UdpClient();
        static void Main(string[] args)
        {
            string file = "text.txt";
            SendFile(file);
        }

        private static void SendFile(string file)
        {
            SendInfo(file);
            var data = File.ReadAllBytes(file);
            server.Send(data, data.Length,ip, port);
            Console.WriteLine("Send");
        }

        private static void SendInfo(string file)
        {
            string name = Path.GetFileName(file);

            var data = Encoding.UTF8.GetBytes(name);
            server.Send(data, data.Length, ip, port);
        }
    }
}
