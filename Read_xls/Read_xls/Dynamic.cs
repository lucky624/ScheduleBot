using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;


namespace Read_xls
{
    class Dynamic
    {

        #region Время

        public static Thread Time = new Thread(time_update);

        public static DateTime time = DateTime.Now;
        public static void time_update()
        {
            while (true)
            {
                time = DateTime.UtcNow.AddHours(6);
                Thread.Sleep(1000);
            }
        }
        #endregion

        //определить 



        #region Вспомогательные функции

        public static string Sheet_name_to_date(string sheet_name)
        {
            //Console.WriteLine("Сегодняшнее число: " + time.Day);
            //Console.WriteLine("Текущий месяц: " + time.Month);
            //Console.WriteLine("Текущий год: " + time.Year);


            //////////////////////////////

            string first_date_value = String.Empty;
            string second_date_value = String.Empty;

            string done_date = String.Empty;

            char[] buf = sheet_name.ToCharArray();

            bool have_dot = false;
            //проверка на точку
            for (int i = 1; i < buf.Length - 1; i++)
            {
                if (buf[i] == '.') have_dot = true;
            }

            if (have_dot == true)
            {
                //Console.WriteLine("have dot");
                for (int i = 0; i < buf.Length; i++)
                {
                    if (buf[i] == '.') break;
                    first_date_value = first_date_value + buf[i];
                }

                for (int i = buf.Length - 1; i >= 0; i--)
                {
                    if (buf[i] == '.') break;
                    second_date_value = second_date_value + buf[i];
                }
                second_date_value = ReverseString(second_date_value);

                //Console.WriteLine(first_date_value);
                //Console.WriteLine(second_date_value);

                string day = String.Empty;
                string month = String.Empty;

                switch (first_date_value)
                {
                    case "1":
                        day = "01";
                        break;
                    case "2":
                        day = "02";
                        break;
                    case "3":
                        day = "03";
                        break;
                    case "4":
                        day = "04";
                        break;
                    case "5":
                        day = "05";
                        break;
                    case "6":
                        day = "06";
                        break;
                    case "7":
                        day = "07";
                        break;
                    case "8":
                        day = "08";
                        break;
                    case "9":
                        day = "09";
                        break;
                    case "01":
                        day = "01";
                        break;
                    case "02":
                        day = "02";
                        break;
                    case "03":
                        day = "03";
                        break;
                    case "04":
                        day = "04";
                        break;
                    case "05":
                        day = "05";
                        break;
                    case "06":
                        day = "06";
                        break;
                    case "07":
                        day = "07";
                        break;
                    case "08":
                        day = "08";
                        break;
                    case "09":
                        day = "09";
                        break;
                    case "10":
                        day = "10";
                        break;
                    case "11":
                        day = "11";
                        break;
                    case "12":
                        day = "12";
                        break;
                    case "13":
                        day = "13";
                        break;
                    case "14":
                        day = "14";
                        break;
                    case "15":
                        day = "15";
                        break;
                    case "16":
                        day = "16";
                        break;
                    case "17":
                        day = "17";
                        break;
                    case "18":
                        day = "18";
                        break;
                    case "19":
                        day = "19";
                        break;
                    case "20":
                        day = "20";
                        break;
                    case "21":
                        day = "21";
                        break;
                    case "22":
                        day = "22";
                        break;
                    case "23":
                        day = "23";
                        break;
                    case "24":
                        day = "24";
                        break;
                    case "25":
                        day = "25";
                        break;
                    case "26":
                        day = "26";
                        break;
                    case "27":
                        day = "27";
                        break;
                    case "28":
                        day = "28";
                        break;
                    case "29":
                        day = "29";
                        break;
                    case "30":
                        day = "30";
                        break;
                    case "31":
                        day = "31";
                        break;
                    default:
                        day = "error";
                        break;
                }

                switch (second_date_value)
                {
                    case "1":
                        month = "01";
                        break;
                    case "2":
                        month = "02";
                        break;
                    case "3":
                        month = "03";
                        break;
                    case "4":
                        month = "04";
                        break;
                    case "5":
                        month = "05";
                        break;
                    case "6":
                        month = "06";
                        break;
                    case "7":
                        month = "07";
                        break;
                    case "8":
                        month = "08";
                        break;
                    case "9":
                        month = "09";
                        break;
                    case "01":
                        month = "01";
                        break;
                    case "02":
                        month = "02";
                        break;
                    case "03":
                        month = "03";
                        break;
                    case "04":
                        month = "04";
                        break;
                    case "05":
                        month = "05";
                        break;
                    case "06":
                        month = "06";
                        break;
                    case "07":
                        month = "07";
                        break;
                    case "08":
                        month = "08";
                        break;
                    case "09":
                        month = "09";
                        break;
                    case "10":
                        month = "10";
                        break;
                    case "11":
                        month = "11";
                        break;
                    case "12":
                        month = "12";
                        break;
                    default:
                        month = "error";
                        break;
                }

                if (day != "error" && month != "error")
                {
                    //здесь day = xx и month = xx
                    done_date = time.Year + "-" + month + "-" + day + " 00:00:00";

                }
                else done_date = "parse_error : " + sheet_name;

            }
            else done_date = "parse_error : " + sheet_name;


            return done_date;
        }
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        #endregion
    }
}
