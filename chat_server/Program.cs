// -------------- Chat Server --------------

using System.Net;
using System.Net.Sockets;
using System.Text;

const int port = 3737;

UdpClient server = new(port);

while (true)
{
    IPEndPoint clientIp = null;

    // waiting for a client message
    byte[] data = server.Receive(ref clientIp);
    string message = Encoding.UTF8.GetString(data);

    Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] - {message} | from {clientIp}");
}
