using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server_MiniChat
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
                Console.Title = "Serber";
                while (true)
                {
                    var client = server.Accept();

                    byte[] buffer = new byte[size];
                    int count = 0;
                    string data = "";

                    do
                    {
                        int tempcount = client.Receive(buffer, count, size, SocketFlags.None);
                        data += Encoding.UTF8.GetString(buffer, 0, tempcount);
                        count += tempcount;
                    } 
                    while (client.Available > 0);

                    Console.WriteLine("GOT form {2} : {0}, count byte = {1} ", data, count, client.RemoteEndPoint);
                    client.Send(Encoding.UTF8.GetBytes("Hello BRO " + DateTime.Now.ToShortDateString()));
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
            catch { }
            finally { server.Close(); }
        }
    }
}
