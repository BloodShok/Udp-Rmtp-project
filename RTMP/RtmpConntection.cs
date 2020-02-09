using System;
using System.Net;
using System.Net.Sockets;

namespace Rtmp
{
    public class RtmpConnection
    {
        readonly int port;
        readonly string ip;

        private IPEndPoint ipPoint;
        private Socket listenSocket;
        private Socket handler;

        public RtmpConnection(int port, string ip)
        {
            this.port = port;
            this.ip = ip;

            IPAddress IpAddres = IPAddress.Parse("127.0.0.1");
            ipPoint = new IPEndPoint(IpAddres, port);
        }

        public void Connect()
        {
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listenSocket.Bind(ipPoint);
            listenSocket.Listen(10);
            System.Console.WriteLine("Server started");


            byte[] C0 = new byte[256];
            handler = listenSocket.Accept();
            handler.Receive(C0, C0.Length, 0);

            byte[] C1 = new byte[256];
            handler = listenSocket.Accept();
            handler.Receive(C1, C1.Length, 0);

            handler.Send(C0);
            handler.Send(C1);

            byte[] C2 = new byte[256];
            handler = listenSocket.Accept();
            handler.Receive(C2, C2.Length, 0);

            handler.Send(C1);
        }
    }
}