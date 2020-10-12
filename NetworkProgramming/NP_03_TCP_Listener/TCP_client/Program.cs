using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_client
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 2020;

            TcpClient client = new TcpClient();
            NetworkStream stream = null ;
            try
            {
                bool flag = true;
                while (flag)
                {
                    client= new TcpClient("127.0.0.1", port);
                    Console.WriteLine("Connected to server {0}", client.Client.RemoteEndPoint);
                    stream = client.GetStream();
                    Console.WriteLine("Enter message to send : ");
                    string msg = Console.ReadLine();

                    stream.Write(Encoding.UTF8.GetBytes(msg), 0, msg.Length);

                    if (msg.Equals("Bye"))
                        flag = false;

                    byte[] responce = new byte[client.ReceiveBufferSize];
                    int count = stream.Read(responce, 0, responce.Length);
                    Console.WriteLine("Received : {0}", Encoding.UTF8.GetString(responce, 0, count)) ;

                    
                }
                stream.Close();
                client.Close();
            }
            catch (SocketException ex) { Console.WriteLine(ex.Message); }
            //finally {  client.Close(); }
        }
    }
}
