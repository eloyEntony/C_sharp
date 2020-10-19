using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace NP_Exam
{
    public class Client
    {
        private IPAddress _ipAddress;
        private ushort _port;
        TcpClient client;
        NetworkStream stream;
        public static MainWindow _Instance { get; private set; }

        public Client(MainWindow Instance)
        {
            _ipAddress = IPAddress.Parse("127.0.0.1");
            _port = 2020;
            client = new TcpClient();
            _Instance = Instance;
        }

        public void Connect(string userLogin)
        {
            try
            {
                client.Connect(_ipAddress, _port);
                stream = client.GetStream();
                Thread thread = new Thread(x => this.ReceiveData((TcpClient)x));
                thread.Start(client);
                this.SendMessageTo(userLogin);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void ReceiveData(TcpClient client)
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[1024];
                    StringBuilder builder = new StringBuilder();
                    int count = 0;
                    do
                    {
                        count = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.UTF8.GetString(data, 0, count));
                    }
                    while (stream.DataAvailable);
                    _Instance.Dispatcher.Invoke(() => { _Instance.lbChat.Items.Add(builder); });
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        public void SendMessageTo(/*string user,*/ string msg)
        {    
            byte[] data = Encoding.UTF8.GetBytes(msg);
            stream.Write(data, 0, data.Length);
        }
    }
}
