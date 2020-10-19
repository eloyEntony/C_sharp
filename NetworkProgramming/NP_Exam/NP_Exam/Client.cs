using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NP_Exam
{
    public class Client
    {
        private IPAddress _ipAddress;
        private ushort _port;
        public TcpClient client { get; private set; }
        public Thread thread { get; private set; }
        public NetworkStream stream { get; private set; }
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
                thread = new Thread(x => this.ReceiveData((TcpClient)x));
                thread.Start(client);
                this.SendMessageTo(userLogin);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
        public void Disconnect()
        {
            SendMessageTo("exit");
            if (stream != null)
            {
                stream.Close();//отключение потока
                stream.Dispose();
            }
            if (client != null)
            {
                client.Close();//отключение клиента
                client.Dispose();
            }
            Environment.Exit(0); //завершение процесса.
            thread.Abort();
        }
    }
}
