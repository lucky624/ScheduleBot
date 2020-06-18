using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Helper.Control;
namespace Helper
{
    class Program
    {
        public static DateTime last_accept_time = DateTime.UtcNow;
        public static DateTime current_time = DateTime.UtcNow;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("          Helper\n\n");

            controller.Start();
            timer.Start();

            

            

            Console.ReadKey();
        }
    }
}
