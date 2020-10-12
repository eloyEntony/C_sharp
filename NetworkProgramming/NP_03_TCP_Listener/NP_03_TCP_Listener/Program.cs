using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NP_03_TCP_Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            //tcpClient
            //tcpLisener 

            const int port = 2020;
            var ip = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(ip, port);
            try
            {
                server.Start();
                while (true)
                {
                    Console.WriteLine("WAIT...");
                    try
                    {
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Connected : {0}", client.Client.LocalEndPoint);
                        NetworkStream stream = client.GetStream();

                        byte[] buffer = new byte[client.SendBufferSize];
                        int count = 0;

                        do{ count += stream.Read(buffer, 0, buffer.Length);  }
                        while (stream.DataAvailable);

                        string data = Encoding.UTF8.GetString(buffer, 0, count);
                        Console.WriteLine("GOT : {0} bytes , data {1}", count, data);
                        data = String.Format("Responce : got {0} bytes", count);
                        stream.Write(Encoding.UTF8.GetBytes(data), 0, data.Length);

                        stream.Close();
                        client.Close();
                    }
                    catch (SocketException ex) { Console.WriteLine(ex.Message); }
                }
            }
            catch (SocketException ex) { Console.WriteLine(ex.Message); }
            finally { server.Stop(); }


        }
    }
}
