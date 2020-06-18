using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static schedule_alfa.Dynamic;

namespace schedule_alfa
{
    class Database
    {
        #region mysql_client и rand
        public static MySqlConnection mysql_client = new MySqlConnection("server=;user=;database=schedule;password=;SslMode = none;charset=utf8");

        static Random rand = new Random();
        #endregion

        #region Работа с юзерами группами и днями
        public static void update_tag(string tag, int group_id)
        {
            MySqlCommand update = new MySqlCommand("UPDATE schedule.groups SET tag = '" + tag + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

            try
            {
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } // изменить group_id через tag

        public static int select_group_id(string tag)
        {

            MySqlCommand select = new MySqlCommand("SELECT group_id FROM schedule.groups WHERE tag='" + tag + "'", mysql_client);

            int group_id = 0;

            try
            {
                group_id = Convert.ToInt32(select.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return group_id;
        } //вернуть group_id через tag

        public static void initialization_days()
        {

            int group_id = 1;

            int value = 1;
            Console.WriteLine("Инициализация group_days_id");
            for (int i = 1; i <= 90; i++)
            {
                MySqlCommand update = new MySqlCommand("UPDATE schedule.group_days_id SET first_monday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET first_tuesday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET first_wednesday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET first_thursday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET first_friday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET first_saturday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET second_monday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET second_tuesday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET second_wednesday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET second_thursday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET second_friday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;

                update = new MySqlCommand("UPDATE schedule.group_days_id SET second_saturday = '" + value.ToString() + "' WHERE(`group_id` = '" + group_id.ToString() + "')", mysql_client);

                try
                {
                    update.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                value++;
                group_id++;
                Console.WriteLine("{0:00.00}%", (i / 90f * 100f));
            }





        }// инициализировать day_id

        public static void insert_day_id_in_days()
        {
            MySqlCommand insert = new MySqlCommand("INSERT INTO `schedule`.`days` (`day_id`) VALUES ('1');", mysql_client);
            Console.WriteLine("Инициализация days");

            for (int i = 1; i < 1081; i++)
            {
                insert = new MySqlCommand("INSERT INTO `schedule`.`days` (`day_id`) VALUES ('" + i.ToString() + "');", mysql_client);
                try
                {
                    insert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("{0:00.00}%", (i / 1080f * 100f));
            }

        }

        #region update day
        public static void update_day(
            int day_id,
            string one_lesson_name,
            string one_lesson_teacher,
            string one_lesson_class,
            string one_lesson_teacher_2,
            string one_lesson_class_2,
            string two_lesson_name,
            string two_lesson_teacher,
            string two_lesson_class,
            string two_lesson_teacher_2,
            string two_lesson_class_2,
            string three_lesson_name,
            string three_lesson_teacher,
            string three_lesson_class,
            string three_lesson_teacher_2,
            string three_lesson_class_2,
            string four_lesson_name,
            string four_lesson_teacher,
            string four_lesson_class,
            string four_lesson_teacher_2,
            string four_lesson_class_2,
            string five_lesson_name,
            string five_lesson_teacher,
            string five_lesson_class,
            string five_lesson_teacher_2,
            string five_lesson_class_2,
            string six_lesson_name,
            string six_lesson_teacher,
            string six_lesson_class,
            string six_lesson_teacher_2,
            string six_lesson_class_2)
        {
            MySqlCommand update = new MySqlCommand("UPDATE `schedule`.`days` SET `one_lesson_name` = '" + one_lesson_name + "', `one_lesson_teacher` = '" + one_lesson_teacher + "', `one_lesson_teacher_2` = '" + one_lesson_teacher_2 + "', `one_lesson_class` = '" + one_lesson_class + "', `one_lesson_class_2` = '" + one_lesson_class_2 + "', `two_lesson_name` = '" + two_lesson_name + "', `two_lesson_teacher` = '" + two_lesson_teacher + "', `two_lesson_teacher_2` = '" + two_lesson_teacher_2 + "', `two_lesson_class` = '" + two_lesson_class + "', `two_lesson_class_2` = '" + two_lesson_class_2 + "', `three_lesson_name` = '" + three_lesson_name + "', `three_lesson_teacher` = '" + three_lesson_teacher + "', `three_lesson_teacher_2` = '" + three_lesson_teacher_2 + "', `three_lesson_class` = '" + three_lesson_class + "', `three_lesson_class_2` = '" + three_lesson_class_2 + "', `four_lesson_name` = '" + four_lesson_name + "', `four_lesson_teacher` = '" + four_lesson_teacher + "', `four_lesson_teacher_2` = '" + four_lesson_teacher_2 + "', `four_lesson_class` = '" + four_lesson_class + "', `four_lesson_class_2` = '" + four_lesson_class_2 + "', `five_lesson_name` = '" + five_lesson_name + "', `five_lesson_teacher` = '" + five_lesson_teacher + "', `five_lesson_teacher_2` = '" + five_lesson_teacher_2 + "', `five_lesson_class` = '" + five_lesson_class + "', `five_lesson_class_2` = '" + five_lesson_class_2 + "', `six_lesson_name` = '" + six_lesson_name + "', `six_lesson_teacher` = '" + six_lesson_teacher + "', `six_lesson_teacher_2` = '" + six_lesson_teacher_2 + "', `six_lesson_class` = '" + six_lesson_class + "', `six_lesson_class_2` = '" + six_lesson_class_2 + "' WHERE (`day_id` = '" + day_id + "');", mysql_client);

            try
            {
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        public static int select_group_day_id(int group_id, string day)
        {

            MySqlCommand select = new MySqlCommand("SELECT " + day + " FROM schedule.group_days_id WHERE group_id='" + group_id + "'", mysql_client);

            int group_day_id = 0;

            try
            {
                group_day_id = Convert.ToInt32(select.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return group_day_id;
        }

        public static string select_tag(int group_id)
        {
            MySqlCommand select = new MySqlCommand("SELECT tag FROM schedule.groups WHERE group_id='" + group_id + "'", mysql_client);

            string tag = "";

            try
            {
                tag = select.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tag;
        }

        public static List<string> return_groups(int course)
        {
            List<string> groups = new List<string>() { };

            for (int count = 1; count < 92; count++)
            {
                MySqlCommand select = new MySqlCommand("SELECT tag FROM schedule.groups WHERE course='" + course.ToString() + "' and group_id='" + count.ToString() + "'", mysql_client);
                if (select.ExecuteScalar() != null)
                {
                    if (select.ExecuteScalar().ToString() != "") groups.Add(select.ExecuteScalar().ToString());
                }
            }

            return groups;
        }

        public static string return_schedule_in_day(int group_id, string day)
        {
            string done_string = "";

            MySqlCommand select_day_id = new MySqlCommand("SELECT " + day + " FROM schedule.group_days_id WHERE group_id='" + group_id.ToString() + "'", mysql_client);

            int day_id = 0;

            if (select_day_id.ExecuteScalar() != null) day_id = Convert.ToInt32(select_day_id.ExecuteScalar().ToString());
            else return "день не найден";

            MySqlCommand select_one_lesson_name = new MySqlCommand("SELECT one_lesson_name FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_one_lesson_teacher = new MySqlCommand("SELECT one_lesson_teacher FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_one_lesson_teacher_2 = new MySqlCommand("SELECT one_lesson_teacher_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_one_lesson_class = new MySqlCommand("SELECT one_lesson_class FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_one_lesson_class_2 = new MySqlCommand("SELECT one_lesson_class_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);

            MySqlCommand select_two_lesson_name = new MySqlCommand("SELECT two_lesson_name FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_two_lesson_teacher = new MySqlCommand("SELECT two_lesson_teacher FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_two_lesson_teacher_2 = new MySqlCommand("SELECT two_lesson_teacher_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_two_lesson_class = new MySqlCommand("SELECT two_lesson_class FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_two_lesson_class_2 = new MySqlCommand("SELECT two_lesson_class_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);

            MySqlCommand select_three_lesson_name = new MySqlCommand("SELECT three_lesson_name FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_three_lesson_teacher = new MySqlCommand("SELECT three_lesson_teacher FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_three_lesson_teacher_2 = new MySqlCommand("SELECT three_lesson_teacher_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_three_lesson_class = new MySqlCommand("SELECT three_lesson_class FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_three_lesson_class_2 = new MySqlCommand("SELECT three_lesson_class_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);

            MySqlCommand select_four_lesson_name = new MySqlCommand("SELECT four_lesson_name FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_four_lesson_teacher = new MySqlCommand("SELECT four_lesson_teacher FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_four_lesson_teacher_2 = new MySqlCommand("SELECT four_lesson_teacher_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_four_lesson_class = new MySqlCommand("SELECT four_lesson_class FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_four_lesson_class_2 = new MySqlCommand("SELECT four_lesson_class_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);

            MySqlCommand select_five_lesson_name = new MySqlCommand("SELECT five_lesson_name FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_five_lesson_teacher = new MySqlCommand("SELECT five_lesson_teacher FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_five_lesson_teacher_2 = new MySqlCommand("SELECT five_lesson_teacher_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_five_lesson_class = new MySqlCommand("SELECT five_lesson_class FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_five_lesson_class_2 = new MySqlCommand("SELECT five_lesson_class_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);

            MySqlCommand select_six_lesson_name = new MySqlCommand("SELECT six_lesson_name FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_six_lesson_teacher = new MySqlCommand("SELECT six_lesson_teacher FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_six_lesson_teacher_2 = new MySqlCommand("SELECT six_lesson_teacher_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_six_lesson_class = new MySqlCommand("SELECT six_lesson_class FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);
            MySqlCommand select_six_lesson_class_2 = new MySqlCommand("SELECT six_lesson_class_2 FROM schedule.days WHERE day_id='" + day_id.ToString() + "'", mysql_client);


            string one_lesson_name = String.Empty;
            string one_lesson_teacher = String.Empty;
            string one_lesson_teacher_2 = String.Empty;
            string one_lesson_class = String.Empty;
            string one_lesson_class_2 = String.Empty;

            string two_lesson_name = String.Empty;
            string two_lesson_teacher = String.Empty;
            string two_lesson_teacher_2 = String.Empty;
            string two_lesson_class = String.Empty;
            string two_lesson_class_2 = String.Empty;

            string three_lesson_name = String.Empty;
            string three_lesson_teacher = String.Empty;
            string three_lesson_teacher_2 = String.Empty;
            string three_lesson_class = String.Empty;
            string three_lesson_class_2 = String.Empty;

            string four_lesson_name = String.Empty;
            string four_lesson_teacher = String.Empty;
            string four_lesson_teacher_2 = String.Empty;
            string four_lesson_class = String.Empty;
            string four_lesson_class_2 = String.Empty;

            string five_lesson_name = String.Empty;
            string five_lesson_teacher = String.Empty;
            string five_lesson_teacher_2 = String.Empty;
            string five_lesson_class = String.Empty;
            string five_lesson_class_2 = String.Empty;

            string six_lesson_name = String.Empty;
            string six_lesson_teacher = String.Empty;
            string six_lesson_teacher_2 = String.Empty;
            string six_lesson_class = String.Empty;
            string six_lesson_class_2 = String.Empty;

            int count = 0;

            while (true)
            {
                if (count >= 3) return "Ошибка базы данных";
                try
                {
                    if (select_one_lesson_name.ExecuteScalar() != null) one_lesson_name = select_one_lesson_name.ExecuteScalar().ToString();
                    if (select_one_lesson_teacher.ExecuteScalar() != null) one_lesson_teacher = select_one_lesson_teacher.ExecuteScalar().ToString();
                    if (select_one_lesson_teacher_2.ExecuteScalar() != null) one_lesson_teacher_2 = select_one_lesson_teacher_2.ExecuteScalar().ToString();
                    if (select_one_lesson_class.ExecuteScalar() != null) one_lesson_class = select_one_lesson_class.ExecuteScalar().ToString();
                    if (select_one_lesson_class_2.ExecuteScalar() != null) one_lesson_class_2 = select_one_lesson_class_2.ExecuteScalar().ToString();

                    if (select_two_lesson_name.ExecuteScalar() != null) two_lesson_name = select_two_lesson_name.ExecuteScalar().ToString();
                    if (select_two_lesson_teacher.ExecuteScalar() != null) two_lesson_teacher = select_two_lesson_teacher.ExecuteScalar().ToString();
                    if (select_two_lesson_teacher_2.ExecuteScalar() != null) two_lesson_teacher_2 = select_two_lesson_teacher_2.ExecuteScalar().ToString();
                    if (select_two_lesson_class.ExecuteScalar() != null) two_lesson_class = select_two_lesson_class.ExecuteScalar().ToString();
                    if (select_two_lesson_class_2.ExecuteScalar() != null) two_lesson_class_2 = select_two_lesson_class_2.ExecuteScalar().ToString();

                    if (select_three_lesson_name.ExecuteScalar() != null) three_lesson_name = select_three_lesson_name.ExecuteScalar().ToString(); ;
                    if (select_three_lesson_teacher.ExecuteScalar() != null) three_lesson_teacher = select_three_lesson_teacher.ExecuteScalar().ToString();
                    if (select_three_lesson_teacher_2.ExecuteScalar() != null) three_lesson_teacher_2 = select_three_lesson_teacher_2.ExecuteScalar().ToString();
                    if (select_three_lesson_class.ExecuteScalar() != null) three_lesson_class = select_three_lesson_class.ExecuteScalar().ToString();
                    if (select_three_lesson_class_2.ExecuteScalar() != null) three_lesson_class_2 = select_three_lesson_class_2.ExecuteScalar().ToString();

                    if (select_four_lesson_name.ExecuteScalar() != null) four_lesson_name = select_four_lesson_name.ExecuteScalar().ToString();
                    if (select_four_lesson_teacher.ExecuteScalar() != null) four_lesson_teacher = select_four_lesson_teacher.ExecuteScalar().ToString();
                    if (select_four_lesson_teacher_2.ExecuteScalar() != null) four_lesson_teacher_2 = select_four_lesson_teacher_2.ExecuteScalar().ToString();
                    if (select_four_lesson_class.ExecuteScalar() != null) four_lesson_class = select_four_lesson_class.ExecuteScalar().ToString();
                    if (select_four_lesson_class_2.ExecuteScalar() != null) four_lesson_class_2 = select_four_lesson_class_2.ExecuteScalar().ToString(); ;

                    if (select_five_lesson_name.ExecuteScalar() != null) five_lesson_name = select_five_lesson_name.ExecuteScalar().ToString();
                    if (select_five_lesson_teacher.ExecuteScalar() != null) five_lesson_teacher = select_five_lesson_teacher.ExecuteScalar().ToString();
                    if (select_five_lesson_teacher_2.ExecuteScalar() != null) five_lesson_teacher_2 = select_five_lesson_teacher_2.ExecuteScalar().ToString();
                    if (select_five_lesson_class.ExecuteScalar() != null) five_lesson_class = select_five_lesson_class.ExecuteScalar().ToString();
                    if (select_five_lesson_class_2.ExecuteScalar() != null) five_lesson_class_2 = select_five_lesson_class_2.ExecuteScalar().ToString();

                    if (select_six_lesson_name.ExecuteScalar() != null) six_lesson_name = select_six_lesson_name.ExecuteScalar().ToString();
                    if (select_six_lesson_teacher.ExecuteScalar() != null) six_lesson_teacher = select_six_lesson_teacher.ExecuteScalar().ToString();
                    if (select_six_lesson_teacher_2.ExecuteScalar() != null) six_lesson_teacher_2 = select_six_lesson_teacher_2.ExecuteScalar().ToString();
                    if (select_six_lesson_class.ExecuteScalar() != null) six_lesson_class = select_six_lesson_class.ExecuteScalar().ToString();
                    if (select_six_lesson_class_2.ExecuteScalar() != null) six_lesson_class_2 = select_six_lesson_class_2.ExecuteScalar().ToString();


                    if (one_lesson_name != String.Empty || one_lesson_name != "") done_string = "<b>1 пара :</b> " + one_lesson_name + "\n";
                    if (one_lesson_teacher != String.Empty || one_lesson_teacher != "") done_string = done_string + "препод : " + one_lesson_teacher + "\n";
                    if (one_lesson_class != String.Empty || one_lesson_class != "") done_string = done_string + "кабинет : " + one_lesson_class + "\n";
                    if (one_lesson_teacher_2 != String.Empty || one_lesson_teacher_2 != "") done_string = done_string + "препод : " + one_lesson_teacher_2 + "\n";
                    if (one_lesson_class_2 != String.Empty || one_lesson_class_2 != "") done_string = done_string + "кабинет : " + one_lesson_class_2 + "\n";
                    if (one_lesson_name != String.Empty || one_lesson_name != "") done_string = done_string + "\n";


                    if (two_lesson_name != String.Empty || two_lesson_name != "") done_string = done_string + "<b>2 пара :</b> " + two_lesson_name + "\n";
                    if (two_lesson_teacher != String.Empty || two_lesson_teacher != "") done_string = done_string + "препод : " + two_lesson_teacher + "\n";
                    if (two_lesson_class != String.Empty || two_lesson_class != "") done_string = done_string + "кабинет : " + two_lesson_class + "\n";
                    if (two_lesson_teacher_2 != String.Empty || two_lesson_teacher_2 != "") done_string = done_string + "препод : " + two_lesson_teacher_2 + "\n";
                    if (two_lesson_class_2 != String.Empty || two_lesson_class_2 != "") done_string = done_string + "кабинет : " + two_lesson_class_2 + "\n";
                    if (two_lesson_name != String.Empty || two_lesson_name != "") done_string = done_string + "\n";

                    if (three_lesson_name != String.Empty || three_lesson_name != "") done_string = done_string + "<b>3 пара :</b> " + three_lesson_name + "\n";
                    if (three_lesson_teacher != String.Empty || three_lesson_teacher != "") done_string = done_string + "препод : " + three_lesson_teacher + "\n";
                    if (three_lesson_class != String.Empty || three_lesson_class != "") done_string = done_string + "кабинет : " + three_lesson_class + "\n";
                    if (three_lesson_teacher_2 != String.Empty || three_lesson_teacher_2 != "") done_string = done_string + "препод : " + three_lesson_teacher_2 + "\n";
                    if (three_lesson_class_2 != String.Empty || three_lesson_class_2 != "") done_string = done_string + "кабинет : " + three_lesson_class_2 + "\n";
                    if (three_lesson_name != String.Empty || three_lesson_name != "") done_string = done_string + "\n";

                    if (four_lesson_name != String.Empty || four_lesson_name != "") done_string = done_string + "<b>4 пара :</b> " + four_lesson_name + "\n";
                    if (four_lesson_teacher != String.Empty || four_lesson_teacher != "") done_string = done_string + "препод : " + four_lesson_teacher + "\n";
                    if (four_lesson_class != String.Empty || four_lesson_class != "") done_string = done_string + "кабинет : " + four_lesson_class + "\n";
                    if (four_lesson_teacher_2 != String.Empty || four_lesson_teacher_2 != "") done_string = done_string + "препод : " + four_lesson_teacher_2 + "\n";
                    if (four_lesson_class_2 != String.Empty || four_lesson_class_2 != "") done_string = done_string + "кабинет : " + four_lesson_class_2 + "\n";
                    if (four_lesson_name != String.Empty || four_lesson_name != "") done_string = done_string + "\n";

                    if (five_lesson_name != String.Empty || five_lesson_name != "") done_string = done_string + "<b>5 пара :</b> " + five_lesson_name + "\n";
                    if (five_lesson_teacher != String.Empty || five_lesson_teacher != "") done_string = done_string + "препод : " + five_lesson_teacher + "\n";
                    if (five_lesson_class != String.Empty || five_lesson_class != "") done_string = done_string + "кабинет : " + five_lesson_class + "\n";
                    if (five_lesson_teacher_2 != String.Empty || five_lesson_teacher_2 != "") done_string = done_string + "препод : " + five_lesson_teacher_2 + "\n";
                    if (five_lesson_class_2 != String.Empty || five_lesson_class_2 != "") done_string = done_string + "кабинет : " + five_lesson_class_2 + "\n";
                    if (five_lesson_name != String.Empty || five_lesson_name != "") done_string = done_string + "\n";

                    if (six_lesson_name != String.Empty || six_lesson_name != "") done_string = done_string + "<b>6 пара :</b> " + six_lesson_name + "\n";
                    if (six_lesson_teacher != String.Empty || six_lesson_teacher != "") done_string = done_string + "препод : " + six_lesson_teacher + "\n";
                    if (six_lesson_class != String.Empty || six_lesson_class != "") done_string = done_string + "кабинет : " + six_lesson_class + "\n";
                    if (six_lesson_teacher_2 != String.Empty || six_lesson_teacher_2 != "") done_string = done_string + "препод : " + six_lesson_teacher_2 + "\n";
                    if (six_lesson_class_2 != String.Empty || six_lesson_class_2 != "") done_string = done_string + "кабинет : " + six_lesson_class_2 + "\n";
                    if (six_lesson_name != String.Empty || six_lesson_name != "") done_string = done_string + "\n";

                    return done_string;
                }
                catch
                {
                    Thread.Sleep(1000 * rand.Next(1, 5));
                    count++;
                    continue;
                }
            }


        }

        public static List<int> select_users_chat_id_by_group_id(int group_id)
        {
            List<int> users_chat_id = new List<int>() { };

            for (int count = 1; count < 600; count++)
            {
                MySqlCommand select = new MySqlCommand("SELECT chat_id FROM schedule.users where group_id = " + group_id.ToString() + " and user_id =" + count.ToString() + ';', mysql_client);
                if (select.ExecuteScalar() != null)
                {
                    if (select.ExecuteScalar().ToString() != "") users_chat_id.Add(Convert.ToInt32(select.ExecuteScalar()));
                }
            }

            return users_chat_id;
        }

        public static string select_username_by_chat_id(int chat_id)
        {
            MySqlCommand select = new MySqlCommand("SELECT name FROM schedule.users WHERE chat_id='" + chat_id + "'", mysql_client);

            string name = "";

            try
            {
                name = select.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return name;
        }

        public static int select_group_id_by_user(string name)
        {
            MySqlCommand select = new MySqlCommand("SELECT group_id FROM schedule.users WHERE name='" + Escape_String(name) + "'", mysql_client);

            int group_id = 0;

            try
            {
                group_id = Convert.ToInt32(select.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return group_id;
        }

        public static void register_user(string chat_id, string name, int course, string tag)
        {
            //а есть ли такой юзер в БД ?
            MySqlCommand have_user = new MySqlCommand("SELECT user_id FROM schedule.users WHERE name='" + Escape_String(name) + "'", mysql_client);
            //если такого нет то добавить

            if (have_user.ExecuteScalar() == null)
            {
                MySqlCommand insert_user = new MySqlCommand("INSERT INTO `schedule`.`users` (`group_id`, `chat_id`, `name`, `course`) VALUES ('" + select_group_id(tag).ToString() + "', '" + chat_id.ToString() + "', '" + Escape_String(name) + "', '" + course.ToString() + "');", mysql_client);
                try
                {
                    insert_user.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            else//если такой есть то изменить данные
            {
                MySqlCommand update_user = new MySqlCommand("UPDATE `schedule`.`users` SET `group_id` = '" + select_group_id(tag).ToString() + "', `chat_id` = '" + chat_id.ToString() + "', `course` = '" + course.ToString() + "' WHERE (`name` = '" + Escape_String(name) + "')", mysql_client);
                try
                {
                    update_user.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

        }
        #endregion

        #region Работа с днями
        public static void initialization_dates_in_work_days()
        {
            DateTime dt = DateTime.UtcNow;
            DateTime new_dt = dt;
            MySqlCommand insert = new MySqlCommand("", mysql_client);

            string sql_format_date = dt.Year + "-" + dt.Month + "-" + dt.Day + " 00:00:00";
            Console.WriteLine("initialization");



            for (int i = 1; i < 366; i++)
            {
                insert = new MySqlCommand("INSERT INTO `schedule`.`work_days` (`date_key`) VALUES ('" + sql_format_date + "');", mysql_client);
                try
                {
                    insert.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

                new_dt = dt.AddDays(i); //прибавление дня
                sql_format_date = new_dt.Year + "-" + new_dt.Month + "-" + new_dt.Day + " 00:00:00"; //строка для sql запроса
            }
            Console.WriteLine("Done!");
        }

        public static void update_day_of_week(string date, string day_of_week)
        {
            MySqlCommand update = new MySqlCommand("UPDATE `schedule`.`work_days` SET `day_of_week` = '" + day_of_week + "' WHERE (`date_key` = '" + date + "');", mysql_client);

            try
            {
                update.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public static void updating_days_of_week()
        {
            DateTime dt = DateTime.UtcNow;
            DateTime new_dt = dt;
            Console.WriteLine("updating_days_of_week");

            for (int i = 1; i < 366; i++)
            {
                update_day_of_week(new_dt.ToString("yyyy-MM-dd 00:00:00"), new_dt.DayOfWeek.ToString());
                new_dt = dt.AddDays(i); //прибавление дня
            }
            Console.WriteLine("Done!");

        }

        public static void update_day_of_college(string date, string day_of_college)
        {
            MySqlCommand update = new MySqlCommand("UPDATE `schedule`.`work_days` SET `day_of_college` = '" + day_of_college + "' WHERE (`date_key` = '" + date + "');", mysql_client);

            try
            {
                update.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public static string return_days_of_week(string date)
        {
            MySqlCommand select = new MySqlCommand("SELECT day_of_week FROM schedule.work_days WHERE date_key = '" + date + "'", mysql_client);

            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }


        public static void updating_days_of_college(int num_week)
        {
            DateTime dt = DateTime.UtcNow;
            DateTime new_dt = dt;
            Console.WriteLine("updating_days_of_college");
            bool first = true;

            string day_of_week = String.Empty;
            string day_of_college = String.Empty;

            if (num_week == 1) first = true;
            else first = false;


            for (int i = 1; i < 366; i++)
            {
                day_of_week = return_days_of_week(new_dt.ToString("yyyy-MM-dd 00:00:00"));

                if (day_of_week == "Monday" && first == true) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "first_monday");
                else if (day_of_week == "Tuesday" && first == true) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "first_tuesday");
                else if (day_of_week == "Wednesday" && first == true) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "first_wednesday");
                else if (day_of_week == "Thursday" && first == true) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "first_thursday");
                else if (day_of_week == "Friday" && first == true) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "first_friday");
                else if (day_of_week == "Saturday" && first == true) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "first_saturday");
                else if (day_of_week == "Sunday" && first == true)
                {
                    update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "first_sunday");
                    first = false;
                }
                else if (day_of_week == "Monday" && first == false) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "second_monday");
                else if (day_of_week == "Tuesday" && first == false) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "second_tuesday");
                else if (day_of_week == "Wednesday" && first == false) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "second_wednesday");
                else if (day_of_week == "Thursday" && first == false) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "second_thursday");
                else if (day_of_week == "Friday" && first == false) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "second_friday");
                else if (day_of_week == "Saturday" && first == false) update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "second_saturday");
                else if (day_of_week == "Sunday" && first == false)
                {
                    update_day_of_college(new_dt.ToString("yyyy-MM-dd 00:00:00"), "second_sunday");
                    first = true;
                }

                new_dt = dt.AddDays(i); //прибавление дня
            }
            Console.WriteLine("Done!");

        }

        //initialization_dates_in_work_days(); - 1
        //updating_days_of_week(); - 2
        //updating_days_of_college(2); - 3 СРАЗУ В ОДИН И ТОТ ЖЕ ДЕНЬ
        #endregion

        #region Функция экранирования строк для insert sql
        public static string Escape_String(string sql)
        {
            char[] text = sql.ToCharArray();

            string done = "";

            for (int i = 0; i < sql.Length; i++)
            {
                if (text[i] != '"' || text[i] != ';')
                    done = done + text[i];
            }

            return done.Replace("'", "");
        }
        #endregion

        #region Завтра и сегодня

        //мы получаем  select_group_id_by_user - через юзера, который подал запрос

        //получить day_of_college

        public static string select_workday_today_of_college()
        {
            string sql_date = time.Year + "-" + time.Month + "-" + time.Day + " 00:00:00";

            MySqlCommand select = new MySqlCommand("SELECT day_of_college FROM schedule.work_days WHERE date_key='" + sql_date + "';", mysql_client);

            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; }

        }

        public static string select_workday_tomorrow_of_college()
        {
            DateTime dt = time.AddDays(1);
            string sql_date = dt.Year + "-" + dt.Month + "-" + dt.Day + " 00:00:00";

            MySqlCommand select = new MySqlCommand("SELECT day_of_college FROM schedule.work_days WHERE date_key='" + sql_date + "';", mysql_client);

            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; }

        }

        public static string select_name_table_today_changes()
        {
            string sql_date = time.Year + "-" + time.Month + "-" + time.Day + " 00:00:00";

            MySqlCommand select = new MySqlCommand("SELECT table_name FROM schedule.date_tables WHERE date='" + sql_date + "';", mysql_client);

            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; }

        }

        public static string select_name_table_tomorrow_of_college()
        {
            DateTime dt = time.AddDays(1);
            string sql_date = dt.Year + "-" + dt.Month + "-" + dt.Day + " 00:00:00";

            MySqlCommand select = new MySqlCommand("SELECT table_name FROM schedule.date_tables WHERE date='" + sql_date + "';", mysql_client);

            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; }

        }

        public static string return_part_answer(string work_day)
        {
            switch (work_day)
            {
                case "first_monday":
                    return "<b>Первый понедельник</b>\n\n";
                case "first_tuesday":
                    return "<b>Первый вторник</b>\n\n";
                case "first_wednesday":
                    return "<b>Первая среда</b>\n\n";
                case "first_thursday":
                    return "<b>Первый четверг</b>\n\n";
                case "first_friday":
                    return "<b>Первая пятница</b>\n\n";
                case "first_saturday":
                    return "<b>Первая суббота</b>\n\n";
                case "second_monday":
                    return "<b>Второй понедельник</b>\n\n";
                case "second_tuesday":
                    return "<b>Второй вторник</b>\n\n";
                case "second_wednesday":
                    return "<b>Вторая среда</b>\n\n";
                case "second_thursday":
                    return "<b>Второй четверг</b>\n\n";
                case "second_friday":
                    return "<b>Вторая пятница</b>\n\n";
                case "second_saturday":
                    return "<b>Вторая суббота</b>\n\n";
                default:
                    return "";
            }


        }




        #endregion

        #region Работа с изменениями в расписании
        public static List<int> return_y_with_group_names(string xls_table_name, string group_name)
        {
            List<int> y = new List<int>();

            MySqlCommand select = new MySqlCommand("SELECT x_three FROM schedule." + xls_table_name + " WHERE y='1';", mysql_client);

            for (int i = 1; i <= 110; i++)
            {
                try
                {
                    select = new MySqlCommand("SELECT x_three FROM schedule." + xls_table_name + " WHERE y='" + i.ToString() + "';", mysql_client);
                    if (select.ExecuteScalar() != null)
                    {
                        if (select.ExecuteScalar().ToString() == group_name || select.ExecuteScalar().ToString() == group_name.Replace("-", "") || select.ExecuteScalar().ToString() == one_defis(group_name) || select.ExecuteScalar().ToString() == two_defis(group_name)) y.Add(i);
                    }
                }
                catch { }
            }

            return y;
        }

        public static string return_lesson_number(string xls_table_name, string y)
        {
            MySqlCommand select = new MySqlCommand("SELECT x_nine FROM schedule." + xls_table_name + " WHERE y='" + y + "';", mysql_client);

            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; }
        }

        public static string return_lesson_class(string xls_table_name, string y)
        {
            MySqlCommand select = new MySqlCommand("SELECT x_ten FROM schedule." + xls_table_name + " WHERE y='" + y + "';", mysql_client);

            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; }
        }

        public static string return_lesson_name(string xls_table_name, string y)
        {
            MySqlCommand select = new MySqlCommand("SELECT x_eleven FROM schedule." + xls_table_name + " WHERE y='" + y + "';", mysql_client);
            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; }
        }

        public static string return_lesson_teacher_name(string xls_table_name, string y)
        {
            MySqlCommand select = new MySqlCommand("SELECT x_twelve FROM schedule." + xls_table_name + " WHERE y='" + y + "';", mysql_client);
            try
            {
                if (select.ExecuteScalar() != null) return select.ExecuteScalar().ToString();
                else return "";
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return ""; }
        }

        public static string return_schedule_changes(string xls_table_name, string group_name)
        {
            string answer = String.Empty;

            List<int> y = return_y_with_group_names(xls_table_name, group_name);

            for (int i = 0; i < y.Count; i++)
            {
                answer = answer + "\n" + "<b>" + return_lesson_number(xls_table_name, y[i].ToString()) + "  пара:</b>" + " " + return_lesson_name(xls_table_name, y[i].ToString()) + "\nпрепод: " + return_lesson_teacher_name(xls_table_name, y[i].ToString()) + "\nкабинет: " + return_lesson_class(xls_table_name, y[i].ToString());
            }

            return answer;
        }


        #endregion

        #region добавление дефисов
        public static string one_defis(string tag)
        {
            char[] char_tag = tag.ToCharArray();
            string done_tag = "";
            for (int i = 0; i < tag.Length; i++)
            {
                if (i == 1) done_tag = done_tag + "-";
                done_tag = done_tag + char_tag[i];
            }
            return done_tag;
        }

        public static string two_defis(string tag)
        {
            char[] char_tag = tag.ToCharArray();
            string done_tag = "";
            for (int i = 0; i < tag.Length; i++)
            {
                if (i == 2) done_tag = done_tag + "-";
                done_tag = done_tag + char_tag[i];
            }
            return done_tag;
        }
        #endregion

    }
}
