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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendMessageBtnClick(object sender, RoutedEventArgs e)
        {
            IPEndPoint serverIp = new IPEndPoint(IPAddress.Parse(ipTxtBox.Text), int.Parse(portTxtBox.Text));

            string message = msgTxtBox.Text;
            byte[] data = Encoding.UTF8.GetBytes(message);

            // TODO: rewrite to async 
            client.Send(data, serverIp);
        }

        private void JoinBtnClick(object sender, RoutedEventArgs e)
        {
            IPEndPoint serverIp = new IPEndPoint(IPAddress.Parse(ipTxtBox.Text), int.Parse(portTxtBox.Text));

            byte[] data = Encoding.UTF8.GetBytes("<join>");

            // TODO: rewrite to async 
            client.Send(data, serverIp);
        }

        private void LeaveBtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
