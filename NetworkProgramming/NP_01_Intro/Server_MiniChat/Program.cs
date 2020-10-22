using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server_MiniChat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            const int port = 2020;
            Thread thread = new Thread(Listen);

            try
            {
                server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
                server.Listen(10);
                var client = server.Accept();
                thread.Start(client);
                while (true)
                {
                    Console.WriteLine("Enter message : ");
                    string input = Console.ReadLine();
                    Console.WriteLine("You : " + input);
                    client.Send(Encoding.UTF8.GetBytes(input));
                }
            }
            catch { }
            finally { server.Close(); }
        }
        public static void Listen(object client)
        {
            while (true)
            {
                byte[] data = new byte[1024];
                int recv = (client as Socket).Receive(data);
                Console.WriteLine("Client : " + Encoding.UTF8.GetString(data, 0, recv));
            }
        }
    }
}
