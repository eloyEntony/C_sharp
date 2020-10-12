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

namespace Client_MiniChat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int size = 1024;
        Socket client;
        public MainWindow()
        {
            InitializeComponent();
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }
        
        private void Button_Connect_click(object sender, RoutedEventArgs e)
        {           
            try
            {
                client.Connect(IPAddress.Parse(tbIP.Text), int.Parse(tbPort.Text));
                if (client.Connected)
                {
                    string text = Tabs.SelectedItem.ToString() ;
                    byte[] data = Encoding.UTF8.GetBytes(text);
                    client.Send(data);

                    byte[] buffer = new byte[size];
                    client.Receive(buffer);
                    lbChat.Items.Add(Encoding.UTF8.GetString(buffer));
                }
            }
            catch { }
         //   finally { client.Close(); }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (client.Connected)
            {
                string text = tbMsg.Text;
                byte[] data = Encoding.UTF8.GetBytes(text);
                client.Send(data);

                byte[] buffer = new byte[size];
                client.Receive(buffer);
                lbChat.Items.Add(Encoding.UTF8.GetString(buffer));
            }
        }
    }
}
