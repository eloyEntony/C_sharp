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

//клієнт - серверний додаток

//1) клієнт посилає серверу запити з індексом міста
//сервер ПЕРЕВІРЯЄ по базі даних, і відправляє у відповідь назву міста

//2) клієнт посилає серверу запити з назвою міста
//сервер ПЕРЕВІРЯЄ по базі даних, і відправляє у відповідь масив індексів

//сервер асинхронний. клієнт - вікно. БД - ENTITY FRAMEWORK

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

        static string res = "";
        private static void ReceiveCallback(IAsyncResult ar)
        {
            var data = (TransferData)ar.AsyncState;

            var client = data.Socket;
            int countBytes = client.EndReceive(ar);

            res = Encoding.UTF8.GetString(data.Buffer, 0, countBytes);

            Console.WriteLine("Got : {0} bytes : From client >> {1} ", res, client.RemoteEndPoint);

            if (int.TryParse(res, out int n))
                SendName(client);
            else
                SendId(client);
        }

        private static void SendId(Socket client)
        {
            string tmp = "";
            try
            {
                string cityName = res;
                var ids = context.Cities.Where(x => x.Name == cityName).Select(x => x.ID);
                foreach (var item in ids)
                    tmp += item + ", ";
            }
            catch { }
            byte[] responce;

            if (string.IsNullOrEmpty(tmp))
                responce = Encoding.UTF8.GetBytes("There is no such city");
            else
                responce = Encoding.UTF8.GetBytes("City ID >>> " + tmp);

            client.BeginSend(responce, 0, responce.Length, SocketFlags.None, SendCallback, client);
        }

        private static void SendName(Socket client)
        {
            byte[] responce; string cityName = "";
            try
            {
                int id = int.Parse(res);
                cityName = context.Cities.FirstOrDefault(x => x.ID == id).Name;
            }
            catch { }


            if (string.IsNullOrEmpty(cityName))
                responce = Encoding.UTF8.GetBytes("There is no such city");
            else
                responce = Encoding.UTF8.GetBytes("City name >>> " + cityName);
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
