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
using static Helper.Program;

namespace Helper
{
    class Control
    {
        static int controller_port = 5011;
        static string controller_ip = "127.0.0.1";

        public static Thread controller = new Thread(Controller);
        public static Thread timer = new Thread(Timer);

        static void Controller()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(controller_ip), controller_port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);

                Console.WriteLine("\nHelper controller start on 127.0.0.1 5011");

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
                    last_accept_time = DateTime.UtcNow;
                    Console.WriteLine(last_accept_time.ToLongTimeString() + " "+ builder.ToString());

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
                foreach (var process in Process.GetProcessesByName("schedule_alfa"))
                {
                    process.Kill();
                }
            }
            catch { }
            try
            {
                foreach (var process in Process.GetProcessesByName("schedule_alfa"))
                {
                    process.Kill();
                }
            }
            catch { }

            try
            {
                foreach (var process in Process.GetProcessesByName("WerFault"))
                {
                    process.Kill();
                }
            }
            catch { }

            try
            {
                foreach (var process in Process.GetProcessesByName("WerFault"))
                {
                    process.Kill();
                }
            }
            catch { }
        }

        public static void UP()
        {
            Process.Start(@"C:\Users\schedule\Desktop\Stable\schedule_alfa\bin\Debug\schedule_alfa.exe");
        }

        public static void Timer()
        {
            while (true)
            {
                Thread.Sleep(1000 * 3);
                Console.WriteLine(current_time.ToLongTimeString() + "  " + (current_time - last_accept_time).TotalSeconds);
                if((current_time - last_accept_time).TotalSeconds >= 10)
                {
                    Kill();
                    UP();
                    Console.WriteLine("Kill and start schedule_stable");
                    //Process.Start(@"C:\Windows\system32\config\systemprofile\Desktop\Stable\Helper\Helper\bin\Debug\Helper.exe");
                    //Environment.Exit(0);
                }

                current_time = DateTime.UtcNow;
            }
        }

    }
}
