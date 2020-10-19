using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ChatServer3._0
{
    public class ChatServer
    {
        private Dispatcher _dispather { get; set; }
        public string Username { get; private set; }

        static TcpListener tcpListener;
        List<Client> clients = new List<Client>();

        private int clientIdCounter;
        private Thread thread;
        private IPAddress ipAddress;
        private int port;

        public ChatServer()
        {
            clientIdCounter = 0;
            ipAddress = IPAddress.Parse("127.0.0.1");
            port = 2020;
        }

        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 2020);
                tcpListener.Start();
                Console.WriteLine("Server start...");

                while (true)
                {
                    TcpClient tcp = tcpListener.AcceptTcpClient();
                    Client client = new Client(tcp, this);
                    Thread thread = new Thread(new ThreadStart(client.Process));
                    thread.Start();
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }            
        }

       public void AddConnect(Client client)
       {
            clients.Add(client);
       }

        public void Brodcast(string msg, string id)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id)
                    clients[i].Stream.Write(data, 0, data.Length);
            }
        }

        public void SendMessage(Client from, string toUsername, string messageContent)
        {
            string message = from.Username + ": " + messageContent;

            foreach (Client c in clients)            
                if (c.Username == toUsername)                
                    c.SendMessage(message); 
        }
        public void Disconnect()
        {
            tcpListener.Stop(); 
            for (int i = 0; i < clients.Count; i++)            
                clients[i].Close();
            
            Environment.Exit(0);
        }
    }
}
