using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTeknologi
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteClient();
        }
        static void ExecuteClient()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(localEndPoint);
            Console.WriteLine("Socket connected to -> {0} ", sender.RemoteEndPoint.ToString());
            Console.WriteLine("skriv exit anytime du vil quitte chatten");
            Console.WriteLine("Skriv dine beskeder her: ");
            bool stillActive = true;
            while (stillActive)
            {
                string result = Console.ReadLine();
                if(result.ToLower() != "exit")
                {
                    byte[] message = Encoding.ASCII.GetBytes(result);
                    sender.Send(message);
                }
                else
                {
                    stillActive = false;
                    byte[] message = Encoding.ASCII.GetBytes(result);
                    sender.Send(message);
                }

            }
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
