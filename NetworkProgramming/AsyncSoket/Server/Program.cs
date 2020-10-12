using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.DataBase;
namespace Server
{
    struct TransferData
    {
        public Socket Socket { get; set; }
        public byte[] Buffer { get; set; }

        public static readonly int size = 1024;
    }
    class Program
    {
        static AutoResetEvent done = new AutoResetEvent(false);
        static DataBase.AppContext context; //= new DataBase.AppContext();
        const int backlog = 10;
        const int port = 2020;

        static void Main(string[] args)
        {
            Console.Title = "Server";
            context = new DataBase.AppContext();
            //int f = int.Parse(res);
            string tmp = context.Cities.FirstOrDefault(x => x.ID == 1).Name;
            StartServer();
        }

        private static void StartServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHost.AddressList[1];
            Socket server = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Bind(new IPEndPoint(ipAddress, port));
                server.Listen(backlog);

                while (true)
                {
                    Console.WriteLine("Wait....");
                    server.BeginAccept(AsseptCallback, server);
                    done.WaitOne();
                }
            }
            catch (SocketException ex) { Console.WriteLine(ex.Message); }
            finally { server.Close(); }
        }

        private static void AsseptCallback(IAsyncResult ar)
        {
            done.Set();

            Socket server = (Socket)ar.AsyncState;
            Socket client = server.EndAccept(ar);

            TransferData data = new TransferData { Socket = client, Buffer = new byte[TransferData.size] };

            client.BeginReceive(data.Buffer, 0, TransferData.size, SocketFlags.None, ReceiveCallback, data);
        }

        static string res ="";
        private static void ReceiveCallback(IAsyncResult ar)
        {
            var data = (TransferData)ar.AsyncState;

            var client = data.Socket;
            int countBytes = client.EndReceive(ar);

            res = Encoding.UTF8.GetString(data.Buffer, 0, countBytes);            

            Console.WriteLine("Got : {0} bytes : From client >> {1} ", res, client.RemoteEndPoint);

            Send(client);
        }

        private static void Send(Socket client)
        {
            int id = int.Parse(res);
            string cityName = context.Cities.FirstOrDefault(x => x.ID == id).Name;

            byte[] responce = Encoding.UTF8.GetBytes("City name >>> " + cityName);
            client.BeginSend(responce, 0, responce.Length, SocketFlags.None, SendCallback, client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                var client = (Socket)ar.AsyncState;
                int countBytes = client.EndSend(ar);

                Console.WriteLine("Send : {0} bytes  ", countBytes);
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch { }
        }
    }
}
