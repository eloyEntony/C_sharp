using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server_clock_date
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            const int port = 2020;
            const int size = 1024;
            try
            {
                server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
                server.Listen(10);

                while (true)
                {
                    var client = server.Accept();

                    byte[] buffer = new byte[size];
                    int count = 0;
                    string data = "";
                    string sendinfo = "";
                    do
                    {
                        count = client.Receive(buffer, count, size, SocketFlags.None);
                        data = Encoding.UTF8.GetString(buffer, 0, count);

                        if (data == "TIME")
                            sendinfo = DateTime.Now.ToLongTimeString();
                        else
                            sendinfo = DateTime.Now.ToShortDateString();
                    }
                    while (client.Available > 0);

                    client.Send(Encoding.UTF8.GetBytes(sendinfo));
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
            catch { }
            finally
            {
                server.Close();
            }
        }
    }
}
