using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static schedule_alfa.Database;
using static schedule_alfa.Control;
using static schedule_alfa.TelegramBot;
using static schedule_alfa.ForHelper;
using static schedule_alfa.Dynamic;
using static schedule_alfa.Parse_Static;
namespace schedule_alfa
{
    class Program
    {
        static void Main(string[] args)
        {
            
            mysql_client.Open();

            accepts_for_helper.Start();

            controller.Start();

            Start_Telegram_bot();

            Time.Start();

            Updater_Schedule_Changes.Start();


        }
    }
}
