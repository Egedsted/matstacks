using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteServer();
        }
        public static void ExecuteServer()
        {

            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

            Socket listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(localEndPoint);
            listener.Listen(10);
            Console.WriteLine("Waiting connection ... ");
            Console.WriteLine("Got a connection");
            Socket clientSocket;
            bool serverActive = true;
            while (serverActive)
            {
                Thread t = new Thread(() => HandleConnection(clientSocket = listener.Accept()));
                t.Start();
            }

            //HandleConnection(clientSocket);
            /*
            string result = "";
            do
            {
                byte[] messageRecieved = new byte[1024];
                int byteNumber = clientSocket.Receive(messageRecieved);
                result = Encoding.ASCII.GetString(messageRecieved, 0, byteNumber);
                if (result != "exit")
                    Console.WriteLine(result);
            } while (result != "exit");
            Console.WriteLine("Connection terminated, shutting down");
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            */
        }
        public static void HandleConnection(Socket s)
        {
            string result = "";
            do
            {
                byte[] messageRecieved = new byte[1024];
                int byteNumber = s.Receive(messageRecieved);
                result = Encoding.ASCII.GetString(messageRecieved, 0, byteNumber);
                if (result != "exit")
                    Console.WriteLine(result);
            } while (result != "exit");
            Console.WriteLine("Connection terminated with {0}, shutting down", s.ToString());
            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }
    }
}
