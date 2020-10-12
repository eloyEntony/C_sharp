using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncServer
{
    struct TansferData
    {
       public Socket Socket { get; set; }
       public byte[] Buffer { get; set; }

       public static readonly int size = 1024;
    }
    class Program
    {
        static AutoResetEvent done = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.Title = "Server";
            StartServer();
        }
        const int port = 2020;
        const int backlog = 100;
        

        private static void StartServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHost.AddressList[0];
            Socket server = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Bind(new IPEndPoint(ipAddress, port));
                server.Listen(backlog);

                while (true)
                {
                    Console.WriteLine("Wait Connection ...");
                    server.BeginAccept(AcceptCalback, server);
                    done.WaitOne();
                }
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Close();
            }
        }

        private static void AcceptCalback(IAsyncResult ar)
        {
            done.Set();

            Socket server = (Socket)ar.AsyncState;
            Socket client = server.EndAccept(ar);

            TansferData data = new TansferData { Socket = client, Buffer = new byte[TansferData.size] };

            client.BeginReceive(data.Buffer, 0 , TansferData.size, SocketFlags.None, ReceiveCallback, data);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            var data = (TansferData)ar.AsyncState;

            var client = (Socket)data.Socket;
            int countBytes = client.EndReceive(ar);

            string res = Encoding.UTF8.GetString(data.Buffer, 0, countBytes);

            Console.WriteLine("Got : {0} bytes : From client >> {1} ",res , client.RemoteEndPoint);

            Send(client);
       
        }

        private static void Send(Socket client)
        {
            byte[] responce = Encoding.UTF8.GetBytes("Server got" + DateTime.Now.ToLongDateString());
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
