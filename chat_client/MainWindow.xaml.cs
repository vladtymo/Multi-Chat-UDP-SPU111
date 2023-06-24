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

namespace chat_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UdpClient client = new();
        private bool isListening = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Listen()
        {
            while (isListening)
            {
                var res = await client.ReceiveAsync();
                string message = Encoding.UTF8.GetString(res.Buffer);
                msgList.Items.Add(message);
            }
        }

        private void SendMessageBtnClick(object sender, RoutedEventArgs e)
        {
            string message = msgTxtBox.Text;
            SendMessage(message);
        }

        private void JoinBtnClick(object sender, RoutedEventArgs e)
        {
            SendMessage("<join>");
            isListening = true;
            Listen();
        }

        private void LeaveBtnClick(object sender, RoutedEventArgs e)
        {
            SendMessage("<leave>");
            isListening = false;
        }

        private async void SendMessage(string text)
        {
            IPEndPoint serverIp = new IPEndPoint(IPAddress.Parse(ipTxtBox.Text), int.Parse(portTxtBox.Text));

            byte[] data = Encoding.UTF8.GetBytes(text);

 
            await client.SendAsync(data, serverIp);
        }
    }
}
