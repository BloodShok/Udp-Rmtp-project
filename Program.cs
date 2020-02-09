using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FluorineFX.Serialization;

namespace Tcp_Udp_server
{
    class Program
    {

        const int PORT = 8080;
        static IPAddress IpAddres = IPAddress.Parse("127.0.0.1");

        static void Main(string[] args)
        {

            IPEndPoint ipPoint = new IPEndPoint(IpAddres, PORT);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listenSocket.Bind(ipPoint);
            listenSocket.Listen(10);
            System.Console.WriteLine("Server started");

            while (true)
            {
                Socket handler = listenSocket.Accept();
                System.Console.WriteLine(handler.Connected);
                StringBuilder strBuilder = new StringBuilder();


                var c0 = new byte[1];
                var c1 = new byte[1536];
                var c2 = new byte[1536];
                var res = new byte[187];





                var c0bytes = handler.Receive(c0);
                var c1bytes = handler.Receive(c1);
                handler.Send(c0);
                handler.Send(c1);

                var c2bytes = handler.Receive(c2);
                handler.Send(c1);

                var resbytes = handler.Receive(res);
               
                System.Console.WriteLine(Encoding.UTF8.GetString(res));

                var bytes = Encoding.UTF8.GetBytes(" { 'code', 'NetConnection.Connect.Success' }");
                 handler.Send(bytes);
                var AvailableBytes = handler.Available;

                


                



                //System.Console.WriteLine(strBuilder.ToString());
            }


        }
    }
}
