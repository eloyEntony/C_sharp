using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsyncClient
{
    struct TansferData
    {
        public Socket Socket { get; set; }
        public byte[] Buffer { get; set; }

        public static readonly int size = 1024;
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            //активні пасивні
            //синхронні асинхронні

            StartClient();

        }
        const int port = 2020;
        private static void StartClient()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHost.AddressList[0];
            Socket client = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.BeginConnect(new IPEndPoint(ipAddress, port), ConnectCallback, client);
                

            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            var client = (Socket)ar.AsyncState;
            client.EndConnect(ar);

            byte[] data = Encoding.UTF8.GetBytes(String.Format("Hello server " + client.LocalEndPoint));
            client.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            var client = (Socket)ar.AsyncState;
            int countBytes = client.EndSend(ar);

            Console.WriteLine("Send to server {0} bytes", countBytes);

            Receive(client);
        }

        private static void Receive(Socket client)
        {
            TansferData data = new TansferData { Buffer = new byte[TansferData.size], Socket = client };
            client.BeginReceive(data.Buffer, 0, TansferData.size, SocketFlags.None, ReceiveCallback, data);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            var data = (TansferData)ar.AsyncState;

            var client = (Socket)data.Socket;
            int countBytes = client.EndReceive(ar);

            string res = Encoding.UTF8.GetString(data.Buffer, 0, countBytes);

            Console.WriteLine("Got : {0} bytes : From server >> {1} ", res, client.RemoteEndPoint);

        }
    }
}
