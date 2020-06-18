using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace schedule_alfa
{
    class ForHelper
    {
        static Random rand = new Random();

        public static Thread accepts_for_helper = new Thread(SendAccept);
        static void SendAccept()
        {
            while (true)
            {
                SendMessage("127.0.0.1", 5011,"accept");
                Thread.Sleep(1000*rand.Next(2,6));
            }
        }
        static void SendMessage(string ip, int port, string message)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                data = new byte[256];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                //Console.WriteLine("ответ : " + builder.ToString());

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
    }
}
