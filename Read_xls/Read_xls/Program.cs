using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using static Read_xls.Excel;
using static Read_xls.Databases;
using static Read_xls.Dynamic;
using OpenQA.Selenium;


namespace Read_xls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Xls reader");
            Console.ForegroundColor = ConsoleColor.Magenta;


            mysql_open();

            Time.Start();


            #region Зона тестов 

            #endregion

            #region Локальные переменные
            int first_sheet = 0;
            int second_sheet = 0;
            int third_sheet = 0;

            int total_sheets = 0;

            string path = @"C:\Users\schedule\Desktop\schedule.xls";
            #endregion

            #region скачивание расписания
            try
            {

                WebClient webload = new WebClient();
                string[] link = File.ReadAllLines(@"C:\Users\schedule\Desktop\Link.txt");
                bool ok_download = false;
                for (int i = 0; i < link.Length; i++)
                {
                    try
                    {
                        Console.WriteLine("Try download " + link[i]);
                        webload.DownloadFile(new Uri(link[i]), path);
                        ok_download = true;
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //if (ok_download == false) Environment.Exit(0);
            #endregion

            #region чистка Sheet'ов 
            Console.WriteLine("Clean tables");
            clean_table_first();

            clean_table_second();

            clean_table_third();
            #endregion

            #region определение кол-ва Sheet'ов 
            try
            {

                Excel try_excel = new Excel(path, 1);
                total_sheets = try_excel.count;

                Console.WriteLine("Sheet count : " + try_excel.count);

                try_excel.Quit();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            #endregion

            #region определение индексов Sheet'ов 
            try
            {

                if (total_sheets >= 3)
                {
                    first_sheet = total_sheets;
                    second_sheet = total_sheets - 1;
                    third_sheet = total_sheets - 2;
                }
                else if (total_sheets == 2)
                {
                    first_sheet = total_sheets;
                    second_sheet = total_sheets - 1;
                }
                else if (total_sheets == 1)
                {
                    first_sheet = total_sheets;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            #endregion

            try { 

            #region Первый Sheet
            if (first_sheet != 0)
            {
                Excel first_excel = new Excel(path, first_sheet);
                Console.WriteLine("Sheet name : " + first_excel.name);//записать в таблицу xls
                update_first_x_two(first_excel.name, 111);
                //Console.WriteLine(Sheet_name_to_date(first_excel.name));
                update_date_first_xls_table(Sheet_name_to_date(first_excel.name.Replace(" ", "")));

                for (int y = 2; y <= 110; y++)
                {
                    for (int x = 2; x <= 12; x++)
                    {
                        switch (x)
                        {
                            case 2:
                                update_first_x_two(first_excel.ReadCell(y, x), y);
                                break;
                            case 3:
                                update_first_x_three(first_excel.ReadCell(y, x), y);
                                break;
                            case 4:
                                update_first_x_four(first_excel.ReadCell(y, x), y);
                                break;
                            case 5:
                                update_first_x_five(first_excel.ReadCell(y, x), y);
                                break;
                            case 6:
                                update_first_x_six(first_excel.ReadCell(y, x), y);
                                break;
                            case 7:
                                update_first_x_seven(first_excel.ReadCell(y, x), y);
                                break;
                            case 8:
                                update_first_x_eight(first_excel.ReadCell(y, x), y);
                                break;
                            case 9:
                                update_first_x_nine(first_excel.ReadCell(y, x), y);
                                break;
                            case 10:
                                update_first_x_ten(first_excel.ReadCell(y, x), y);
                                break;
                            case 11:
                                update_first_x_eleven(first_excel.ReadCell(y, x), y);
                                break;
                            case 12:
                                update_first_x_twelve(first_excel.ReadCell(y, x), y);
                                break;

                        }
                        //Console.WriteLine("{0:0.##}%", (y / 110f * 100));
                    }

                }
                first_excel.Quit();
            }
            #endregion

            #region Второй Sheet
            if (second_sheet != 0)
            {
                Excel second_excel = new Excel(path, second_sheet);
                Console.WriteLine("Sheet name : " + second_excel.name);//записать в таблицу xls
                update_second_x_two(second_excel.name, 111);

                //Console.WriteLine(Sheet_name_to_date(second_excel.name));
                update_date_second_xls_table(Sheet_name_to_date(second_excel.name.Replace(" ", "")));

                for (int y = 2; y <= 110; y++)
                {
                    for (int x = 2; x <= 12; x++)
                    {
                        switch (x)
                        {
                            case 2:
                                update_second_x_two(second_excel.ReadCell(y, x), y);
                                break;
                            case 3:
                                update_second_x_three(second_excel.ReadCell(y, x), y);
                                break;
                            case 4:
                                update_second_x_four(second_excel.ReadCell(y, x), y);
                                break;
                            case 5:
                                update_second_x_five(second_excel.ReadCell(y, x), y);
                                break;
                            case 6:
                                update_second_x_six(second_excel.ReadCell(y, x), y);
                                break;
                            case 7:
                                update_second_x_seven(second_excel.ReadCell(y, x), y);
                                break;
                            case 8:
                                update_second_x_eight(second_excel.ReadCell(y, x), y);
                                break;
                            case 9:
                                update_second_x_nine(second_excel.ReadCell(y, x), y);
                                break;
                            case 10:
                                update_second_x_ten(second_excel.ReadCell(y, x), y);
                                break;
                            case 11:
                                update_second_x_eleven(second_excel.ReadCell(y, x), y);
                                break;
                            case 12:
                                update_second_x_twelve(second_excel.ReadCell(y, x), y);
                                break;

                        }
                        //Console.WriteLine("{0:0.##}%", (y / 110f * 100));
                    }

                }
                second_excel.Quit();
            }
            #endregion

            #region Третий Sheet
            if (third_sheet != 0)
            {
                Excel third_excel = new Excel(path, third_sheet);
                Console.WriteLine("Sheet name : " + third_excel.name);//записать в таблицу xls
                //Console.WriteLine(Sheet_name_to_date(third_excel.name));
                update_third_x_two(third_excel.name, 111);

                update_date_third_xls_table(Sheet_name_to_date(third_excel.name.Replace(" ", "")));

                for (int y = 2; y <= 110; y++)
                {
                    for (int x = 2; x <= 12; x++)
                    {
                        switch (x)
                        {
                            case 2:
                                update_third_x_two(third_excel.ReadCell(y, x), y);
                                break;
                            case 3:
                                update_third_x_three(third_excel.ReadCell(y, x), y);
                                break;
                            case 4:
                                update_third_x_four(third_excel.ReadCell(y, x), y);
                                break;
                            case 5:
                                update_third_x_five(third_excel.ReadCell(y, x), y);
                                break;
                            case 6:
                                update_third_x_six(third_excel.ReadCell(y, x), y);
                                break;
                            case 7:
                                update_third_x_seven(third_excel.ReadCell(y, x), y);
                                break;
                            case 8:
                                update_third_x_eight(third_excel.ReadCell(y, x), y);
                                break;
                            case 9:
                                update_third_x_nine(third_excel.ReadCell(y, x), y);
                                break;
                            case 10:
                                update_third_x_ten(third_excel.ReadCell(y, x), y);
                                break;
                            case 11:
                                update_third_x_eleven(third_excel.ReadCell(y, x), y);
                                break;
                            case 12:
                                update_third_x_twelve(third_excel.ReadCell(y, x), y);
                                break;

                        }
                        //Console.WriteLine("{0:0.##}%", (y / 110f * 100));
                    }

                }
                third_excel.Quit();
            }
            #endregion

            mysql_close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Environment.Exit(0);
        }
    }
}
