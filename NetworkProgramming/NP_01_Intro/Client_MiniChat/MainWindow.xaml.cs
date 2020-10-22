using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace Client_MiniChat
{
    public partial class MainWindow : Window
    {
        const int size = 1024;
        Socket client;
        Thread thread;
        public MainWindow()
        {
            InitializeComponent();
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void Button_Connect_click(object sender, RoutedEventArgs e)
        {           
            try
            {
                client.Connect(IPAddress.Parse("127.0.0.1"), int.Parse("2020"));
                if (client.Connected)
                {                    
                    string text = "Hello server, I am client";
                    byte[] data = Encoding.UTF8.GetBytes(text);
                    client.Send(data);

                    thread = new Thread(Receive);
                    thread.Start();                   
                }
            }
            catch { }
        }
        

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {            
            if (client.Connected)
            {
                string text = tbMsg.Text;
                lbChat.Items.Add(text);
                byte[] data = Encoding.UTF8.GetBytes(text);
                client.Send(data);
            }
        }

        private void Receive()
        {
            while (true)
            {
                byte[] buffer = new byte[size];
                client.Receive(buffer);
                this.Dispatcher.Invoke(() =>
                {
                    lbChat.Items.Add(Encoding.UTF8.GetString(buffer));
                });
            }            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Close();
        }
    }
}
