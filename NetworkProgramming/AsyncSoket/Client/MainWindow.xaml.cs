using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        const int port = 2020;
        struct TransferData
        {
            public Socket Socket { get; set; }
            public byte[] Buffer { get; set; }

            public static readonly int size = 1024;
        }
        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartClient();
        }
        private void StartClient()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHost.AddressList[1];
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

            string tmp = "";
                 Instance.Dispatcher.Invoke(() => {tmp = Instance.tbSend.Text; });

            byte[] data = Encoding.UTF8.GetBytes(tmp);
            client.BeginSend(data, 0, data.Length, SocketFlags.None, SendCallback, client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            var client = (Socket)ar.AsyncState;
            int countBytes = client.EndSend(ar);

            //Console.WriteLine("Send to server {0} bytes", countBytes);

            Receive(client);
        }

        private static void Receive(Socket client)
        {
            TransferData data = new TransferData { Buffer = new byte[TransferData.size], Socket = client };
            client.BeginReceive(data.Buffer, 0, TransferData.size, SocketFlags.None, ReceiveCallback, data);
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            var data = (TransferData)ar.AsyncState;

            var client = (Socket)data.Socket;
            int countBytes = client.EndReceive(ar);

            string res = Encoding.UTF8.GetString(data.Buffer, 0, countBytes);

            Instance.Dispatcher.Invoke(()=> { Instance.lbRes.Content = res; });
            
            //Console.WriteLine("Got : {0} bytes : From server >> {1} ", res, client.RemoteEndPoint);

        }

        
    }
}
