using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using static schedule_alfa.Parse_Static;

namespace schedule_alfa
{
    class Control
    {
        static int controller_port = 5010;
        static string controller_ip = "157.230.97.165";
        public static Thread controller = new Thread(Controller);

        static void Controller()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(controller_ip), controller_port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);

                Console.WriteLine("\nMain controller start on 157.230.97.165 5010");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];
                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);


                    string message = "ok";


                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Process.Start(path);
            Environment.Exit(0);
        }

        public static void Kill()
        {
            try
            {
                driver.Close();
            }
            catch { }
            try
            {
                driver.Quit();
            }
            catch { }
            try
            {
                foreach (var process in Process.GetProcessesByName("chromedriver"))
                {
                    process.Kill();
                }
            }
            catch { }
            try
            {
                foreach (var process in Process.GetProcessesByName("chrome"))
                {
                    process.Kill();
                }
            }
            catch { }
        }


    }
}
