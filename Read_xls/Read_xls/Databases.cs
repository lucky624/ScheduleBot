using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Read_xls
{
    class Databases
    {
        public static MySqlConnection mysql_client = new MySqlConnection("server=127.0.0.1;user=;database=schedule;password=;SslMode = none;charset=utf8");

        public static void mysql_open()
        {
            mysql_client.Open();
        }

        public static void mysql_close()
        {
            mysql_client.Close();
        }


        #region инициализация y - координат в first_xls_table
        public static void insert_first_xls_table_y(int  y)
        {
            MySqlCommand insert_xls_table_y = new MySqlCommand("INSERT INTO `schedule`.`first_xls_table` (`y`) VALUES ('" + y.ToString() + "');", mysql_client);

            try
            {
                insert_xls_table_y.ExecuteNonQuery();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void initialization_first_raw_y()
        {
            for (int i = 2; i <= 110; i++)
            {
                insert_first_xls_table_y(i);
                Console.WriteLine(i/110f*100f + "%");
            }
        }

        #endregion 

        #region инициализация y - координат в second_xls_table
        public static void insert_second_xls_table_y(int y)
        {
            MySqlCommand insert_xls_table_y = new MySqlCommand("INSERT INTO `schedule`.`second_xls_table` (`y`) VALUES ('" + y.ToString() + "');", mysql_client);

            try
            {
                insert_xls_table_y.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void initialization_second_raw_y()
        {
            for (int i = 2; i <= 110; i++)
            {
                insert_second_xls_table_y(i);
                Console.WriteLine(i / 110f * 100f + "%");
            }
        }

        #endregion 

        #region инициализация y - координат в third_xls_table
        public static void insert_third_xls_table_y(int y)
        {
            MySqlCommand insert_xls_table_y = new MySqlCommand("INSERT INTO `schedule`.`third_xls_table` (`y`) VALUES ('" + y.ToString() + "');", mysql_client);

            try
            {
                insert_xls_table_y.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void initialization_third_raw_y()
        {
            for (int i = 2; i <= 110; i++)
            {
                insert_third_xls_table_y(i);
                Console.WriteLine(i / 110f * 100f + "%");
            }
        }

        #endregion


        #region чистка таблиц
        public static void clean_table_first()
        {
            for (int y = 2; y <= 111; y++)
            {
                for (int x = 2; x <= 12; x++)
                {
                    switch (x)
                    {
                        case 2:
                            update_first_x_two("", y);
                            break;
                        case 3:
                            update_first_x_three("", y);
                            break;
                        case 4:
                            update_first_x_four("", y);
                            break;
                        case 5:
                            update_first_x_five("", y);
                            break;
                        case 6:
                            update_first_x_six("", y);
                            break;
                        case 7:
                            update_first_x_seven("", y);
                            break;
                        case 8:
                            update_first_x_eight("", y);
                            break;
                        case 9:
                            update_first_x_nine("", y);
                            break;
                        case 10:
                            update_first_x_ten("", y);
                            break;
                        case 11:
                            update_first_x_eleven("", y);
                            break;
                        case 12:
                            update_first_x_twelve("", y);
                            break;

                    }
                    //Console.WriteLine(y/110f*100 + "%");
                }

            }
        }

        public static void clean_table_second()
        {
            for (int y = 2; y <= 111; y++)
            {
                for (int x = 2; x <= 12; x++)
                {
                    switch (x)
                    {
                        case 2:
                            update_second_x_two("", y);
                            break;
                        case 3:
                            update_second_x_three("", y);
                            break;
                        case 4:
                            update_second_x_four("", y);
                            break;
                        case 5:
                            update_second_x_five("", y);
                            break;
                        case 6:
                            update_second_x_six("", y);
                            break;
                        case 7:
                            update_second_x_seven("", y);
                            break;
                        case 8:
                            update_second_x_eight("", y);
                            break;
                        case 9:
                            update_second_x_nine("", y);
                            break;
                        case 10:
                            update_second_x_ten("", y);
                            break;
                        case 11:
                            update_second_x_eleven("", y);
                            break;
                        case 12:
                            update_second_x_twelve("", y);
                            break;

                    }
                    //Console.WriteLine(y / 110f * 100 + "%");
                }

            }
        }

        public static void clean_table_third()
        {
            for (int y = 2; y <= 111; y++)
            {
                for (int x = 2; x <= 12; x++)
                {
                    switch (x)
                    {
                        case 2:
                            update_third_x_two("", y);
                            break;
                        case 3:
                            update_third_x_three("", y);
                            break;
                        case 4:
                            update_third_x_four("", y);
                            break;
                        case 5:
                            update_third_x_five("", y);
                            break;
                        case 6:
                            update_third_x_six("", y);
                            break;
                        case 7:
                            update_third_x_seven("", y);
                            break;
                        case 8:
                            update_third_x_eight("", y);
                            break;
                        case 9:
                            update_third_x_nine("", y);
                            break;
                        case 10:
                            update_third_x_ten("", y);
                            break;
                        case 11:
                            update_third_x_eleven("", y);
                            break;
                        case 12:
                            update_third_x_twelve("", y);
                            break;

                    }
                    //Console.WriteLine(y / 110f * 100 + "%");
                }

            }
        }
        #endregion 



        #region Апдейты иксов в first_xls_table
        public static void update_first_x_two(string text, int y)
        {
            MySqlCommand update_x_two = new MySqlCommand("UPDATE schedule.first_xls_table SET x_two='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_two.ExecuteNonQuery();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_three(string text, int y)
        {
            MySqlCommand update_x_three = new MySqlCommand("UPDATE schedule.first_xls_table SET x_three='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_three.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_four(string text, int y)
        {
            MySqlCommand update_x_four = new MySqlCommand("UPDATE schedule.first_xls_table SET x_four='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_four.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_five(string text, int y)
        {
            MySqlCommand update_x_five = new MySqlCommand("UPDATE schedule.first_xls_table SET x_five='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_five.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_six(string text, int y)
        {
            MySqlCommand update_x_six = new MySqlCommand("UPDATE schedule.first_xls_table SET x_six='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_six.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_seven(string text, int y)
        {
            MySqlCommand update_x_seven = new MySqlCommand("UPDATE schedule.first_xls_table SET x_seven='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_seven.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_eight(string text, int y)
        {
            MySqlCommand update_x_eight = new MySqlCommand("UPDATE schedule.first_xls_table SET x_eight='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_eight.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_nine(string text, int y)
        {
            MySqlCommand update_x_nine = new MySqlCommand("UPDATE schedule.first_xls_table SET x_nine='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_nine.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_ten(string text, int y)
        {
            MySqlCommand update_x_ten = new MySqlCommand("UPDATE schedule.first_xls_table SET x_ten='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_ten.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_eleven(string text, int y)
        {
            MySqlCommand update_x_eleven = new MySqlCommand("UPDATE schedule.first_xls_table SET x_eleven='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_eleven.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_first_x_twelve(string text, int y)
        {
            MySqlCommand update_x_twelve = new MySqlCommand("UPDATE schedule.first_xls_table SET x_twelve='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_twelve.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        #endregion


        #region Апдейты иксов в second_xls_table
        public static void update_second_x_two(string text, int y)
        {
            MySqlCommand update_x_two = new MySqlCommand("UPDATE schedule.second_xls_table SET x_two='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_two.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_three(string text, int y)
        {
            MySqlCommand update_x_three = new MySqlCommand("UPDATE schedule.second_xls_table SET x_three='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_three.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_four(string text, int y)
        {
            MySqlCommand update_x_four = new MySqlCommand("UPDATE schedule.second_xls_table SET x_four='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_four.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_five(string text, int y)
        {
            MySqlCommand update_x_five = new MySqlCommand("UPDATE schedule.second_xls_table SET x_five='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_five.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_six(string text, int y)
        {
            MySqlCommand update_x_six = new MySqlCommand("UPDATE schedule.second_xls_table SET x_six='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_six.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_seven(string text, int y)
        {
            MySqlCommand update_x_seven = new MySqlCommand("UPDATE schedule.second_xls_table SET x_seven='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_seven.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_eight(string text, int y)
        {
            MySqlCommand update_x_eight = new MySqlCommand("UPDATE schedule.second_xls_table SET x_eight='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_eight.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_nine(string text, int y)
        {
            MySqlCommand update_x_nine = new MySqlCommand("UPDATE schedule.second_xls_table SET x_nine='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_nine.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_ten(string text, int y)
        {
            MySqlCommand update_x_ten = new MySqlCommand("UPDATE schedule.second_xls_table SET x_ten='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_ten.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_eleven(string text, int y)
        {
            MySqlCommand update_x_eleven = new MySqlCommand("UPDATE schedule.second_xls_table SET x_eleven='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_eleven.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_second_x_twelve(string text, int y)
        {
            MySqlCommand update_x_twelve = new MySqlCommand("UPDATE schedule.second_xls_table SET x_twelve='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_twelve.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        #endregion


        #region Апдейты иксов в third_xls_table
        public static void update_third_x_two(string text, int y)
        {
            MySqlCommand update_x_two = new MySqlCommand("UPDATE schedule.third_xls_table SET x_two='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_two.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_three(string text, int y)
        {
            MySqlCommand update_x_three = new MySqlCommand("UPDATE schedule.third_xls_table SET x_three='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_three.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_four(string text, int y)
        {
            MySqlCommand update_x_four = new MySqlCommand("UPDATE schedule.third_xls_table SET x_four='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_four.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_five(string text, int y)
        {
            MySqlCommand update_x_five = new MySqlCommand("UPDATE schedule.third_xls_table SET x_five='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_five.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_six(string text, int y)
        {
            MySqlCommand update_x_six = new MySqlCommand("UPDATE schedule.third_xls_table SET x_six='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_six.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_seven(string text, int y)
        {
            MySqlCommand update_x_seven = new MySqlCommand("UPDATE schedule.third_xls_table SET x_seven='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_seven.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_eight(string text, int y)
        {
            MySqlCommand update_x_eight = new MySqlCommand("UPDATE schedule.third_xls_table SET x_eight='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_eight.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_nine(string text, int y)
        {
            MySqlCommand update_x_nine = new MySqlCommand("UPDATE schedule.third_xls_table SET x_nine='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_nine.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_ten(string text, int y)
        {
            MySqlCommand update_x_ten = new MySqlCommand("UPDATE schedule.third_xls_table SET x_ten='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_ten.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_eleven(string text, int y)
        {
            MySqlCommand update_x_eleven = new MySqlCommand("UPDATE schedule.third_xls_table SET x_eleven='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_eleven.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_third_x_twelve(string text, int y)
        {
            MySqlCommand update_x_twelve = new MySqlCommand("UPDATE schedule.third_xls_table SET x_twelve='" + text + "' WHERE y='" + y.ToString() + "'", mysql_client);

            try
            {
                update_x_twelve.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        #endregion


        #region Апдейты дат в date_tables


        public static void update_date_first_xls_table(string date)
        {
            MySqlCommand update = new MySqlCommand("UPDATE `schedule`.`date_tables` SET `date` = '" + date +"' WHERE (`table_name` = 'first_xls_table');", mysql_client);

            try
            {
                update.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_date_second_xls_table(string date)
        {
            MySqlCommand update = new MySqlCommand("UPDATE `schedule`.`date_tables` SET `date` = '" + date + "' WHERE (`table_name` = 'second_xls_table');", mysql_client);

            try
            {
                update.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void update_date_third_xls_table(string date)
        {
            MySqlCommand update = new MySqlCommand("UPDATE `schedule`.`date_tables` SET `date` = '" + date + "' WHERE (`table_name` = 'third_xls_table');", mysql_client);

            try
            {
                update.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        #endregion




    }
}
