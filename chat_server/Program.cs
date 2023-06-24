﻿// -------------- Chat Server --------------

using System.Net;
using System.Net.Sockets;
using System.Text;

const int port = 3737;
const string JOIN_CMD = "<join>";
const string LEAVE_CMD = "<leave>";

UdpClient server = new(port);

// can not store dublicators
HashSet<IPEndPoint> members = new();

while (true)
{
    IPEndPoint clientIp = null;

    // waiting for a client message
    byte[] data = server.Receive(ref clientIp);
    string message = Encoding.UTF8.GetString(data);

    Console.WriteLine($"[{DateTime.Now.ToShortTimeString()}] - {message} | from {clientIp}");

    switch (message)
    {
        case JOIN_CMD:
            members.Add(clientIp);
            break;
        case LEAVE_CMD:
            members.Remove(clientIp);
            break;
        default:
            foreach (IPEndPoint ip in members)
                server.Send(data, ip);
            break;
    }
}
