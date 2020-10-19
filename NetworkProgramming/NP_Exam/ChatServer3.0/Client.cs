using System;
using System.Net.Sockets;
using System.Text;

namespace ChatServer3._0
{
    public class Client
    {
        public string Id { get; set; }
        public NetworkStream Stream { get; set; }
        string userName;
        TcpClient client;
        ChatServer server;
        internal string Username;

        public Client(TcpClient _client, ChatServer _server)
        {
            Id = Guid.NewGuid().ToString();
            client = _client;
            server = _server;
            server.AddConnect(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                string msg = GetMessage();
                userName = msg;
                msg = userName + "  connected...";
                Console.WriteLine(msg);

                while (true)
                {
                    try
                    {
                        msg = GetMessage();
                        msg = String.Format("{0}:   {1}", userName, msg);
                        Console.WriteLine(msg);
                        server.Brodcast(msg, this.Id);

                    }
                    catch
                    {
                        msg = String.Format("{0}: покинул чат", userName);
                        Console.WriteLine(msg);
                        server.Brodcast(msg, this.Id);
                        break;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {

            }

        }

        private string GetMessage()
        {
            byte[] data = new byte[1024];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);
            return builder.ToString();
        }

        public void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }

        public void SendMessage(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            Stream.Write(data, 0, data.Length);
        }
    }
}
