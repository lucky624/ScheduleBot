using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InlineQueryResults;
using System.Runtime;
using MySql.Data.MySqlClient;
using Leaf.xNet;
using static schedule_alfa.Interface;


namespace schedule_alfa
{
    class TelegramBot
    {


        //глобальные переменные

        public static TelegramBotClient Bot = null;
        public static ReplyKeyboardMarkup menu = new ReplyKeyboardMarkup();



        public static long cid_own = 0;
        public static string msg = "";

        //public static string path = @"C:\Users\schedule\Desktop\Stable\schedule_alfa\bin\Debug\schedule_alfa.exe";

        static string token = "secret";

        //функции и переменные proxy_checker
        static IPEndPoint ipPointer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
        static Socket listenSocketer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static Thread proxy_checker_thread = new Thread(proxy_checker);

        public static string main_proxy = "";

        public static bool Check_IP(string ip)
        {
            try
            {
                Ping ping = new System.Net.NetworkInformation.Ping();
                PingReply pingReply = null;
                pingReply = ping.Send(ip);
                if (pingReply.Status.ToString() == "Success") return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public static string Get_IP(string proxy)
        {
            char[] array = proxy.ToCharArray();

            string ip = "";

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == ':') break;
                ip = ip + array[i];
            }

            return ip;
        }

        public static string Get_Port(string proxy)
        {
            char[] array = proxy.ToCharArray();

            string port = "";

            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] == ':') break;
                port = port + array[i];
            }

            return ReverseString(port);
        }

        public static bool Check_Proxy(string proxy)
        {

            string ip = Get_IP(proxy);

            int port = 0;

            try
            {
                port = Convert.ToInt32(Get_Port(proxy));
            }
            catch
            {
                return false;
            }

            if (port == 0 || port > 65536) return false;
            else if (Check_IP(ip) == false) return false;
            else
            {
                try
                {

                    using (var request = new HttpRequest())
                    {
                        request.Proxy = Socks5ProxyClient.Parse(ip + ':' + port);
                        request.Get("https://core.telegram.org/");

                    }

                }
                catch
                {
                    return false;
                }

                return true;
            }

        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static int unwork_try = 0;
        static void proxy_checker()
        {
            while (true)
            {
                if (Check_Proxy(main_proxy) == false)
                {
                    unwork_try++;
                }
                else
                {
                    unwork_try = 0;
                }

                if (unwork_try >= 10)
                {
                    //Process.Start(path);
                    //Environment.Exit(0);
                }

                Thread.Sleep(1000 * 10);
            }
        }

        //функции телеграмного бота

        public static void Start_Telegram_bot()
        {
            Console.WriteLine("\n\n      Schedule - telegram bot\n");

            Bot = new TelegramBotClient(token);


            Bot.StartReceiving();
            Bot.OnMessage +=  Bot_OnMessage;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            Bot.OnReceiveError += BotOnReceiveError;
        }



        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            try
            {
                Console.WriteLine("Received error: {0} — {1}",
                    receiveErrorEventArgs.ApiRequestException.ErrorCode,
                    receiveErrorEventArgs.ApiRequestException.Message);
                //Process.Start(path);
                //Environment.Exit(0);
            }
            catch
            {
                //Process.Start(path);
                //Environment.Exit(0);
            }
        }
        private static void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
        {
            try
            {
                Console.WriteLine($"Received inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
                //Process.Start(path);
                //Environment.Exit(0);
            }
            catch
            {
                //Process.Start(path);
                //Environment.Exit(0);
            }
        }
    }
}
