using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using static schedule_alfa.Database;
using static schedule_alfa.Control;

namespace schedule_alfa
{
    class Parse_Static
    {
        public static IWebDriver driver;

        public static void Update_Name_Groups()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://www.oat.ru/sites/default/downloads/schedule/Classes.html");

            List<IWebElement> tags = driver.FindElements(By.CssSelector("body > table > tbody > tr > td:nth-child(1) > a")).ToList();

            int group_id = 1;

            for (int i = 0; i < tags.Count; i++)
            {
                group_id = i + 1;
                update_tag(tags[i].Text, i+1);
            }

            tags = driver.FindElements(By.CssSelector("body > table > tbody > tr > td:nth-child(2) > a")).ToList();

            for (int i = 0; i < tags.Count; i++)
            {
                group_id += 1;
                update_tag(tags[i].Text, group_id);
            }

            driver.Close();
        }

        public static void Update_Schedule_Group(string tag, string day)
        {
            #region Переменные для сохранения текста
            string one_lesson_name_t = "";
            string one_lesson_teacher_t = "";
            string one_lesson_teacher_2_t = "";
            string one_lesson_class_t = "";
            string one_lesson_class_2_t = "";

            string two_lesson_name_t = "";
            string two_lesson_teacher_t = "";
            string two_lesson_teacher_2_t = "";
            string two_lesson_class_t = "";
            string two_lesson_class_2_t = "";

            string three_lesson_name_t = "";
            string three_lesson_teacher_t = "";
            string three_lesson_teacher_2_t = "";
            string three_lesson_class_t = "";
            string three_lesson_class_2_t = "";

            string four_lesson_name_t = "";
            string four_lesson_teacher_t = "";
            string four_lesson_teacher_2_t = "";
            string four_lesson_class_t = "";
            string four_lesson_class_2_t = "";

            string five_lesson_name_t = "";
            string five_lesson_teacher_t = "";
            string five_lesson_teacher_2_t = "";
            string five_lesson_class_t = "";
            string five_lesson_class_2_t = "";

            string six_lesson_name_t = "";
            string six_lesson_teacher_t = "";
            string six_lesson_teacher_2_t = "";
            string six_lesson_class_t = "";
            string six_lesson_class_2_t = "";
            #endregion

            #region Переменные для сохранения CSS селекторов
            string one_lesson_name_s = "";
            string one_lesson_teacher_s = "";
            string one_lesson_teacher_2_s = "";
            string one_lesson_class_s = "";

            string two_lesson_name_s = "";
            string two_lesson_teacher_s = "";
            string two_lesson_teacher_2_s = "";
            string two_lesson_class_s = "";

            string three_lesson_name_s = "";
            string three_lesson_teacher_s = "";
            string three_lesson_teacher_2_s = "";
            string three_lesson_class_s = "";

            string four_lesson_name_s = "";
            string four_lesson_teacher_s = "";
            string four_lesson_teacher_2_s = "";
            string four_lesson_class_s = "";

            string five_lesson_name_s = "";
            string five_lesson_teacher_s = "";
            string five_lesson_teacher_2_s = "";
            string five_lesson_class_s = "";

            string six_lesson_name_s = "";
            string six_lesson_teacher_s = "";
            string six_lesson_teacher_2_s = "";
            string six_lesson_class_s = "";
            #endregion

            if (day == "first_monday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(3) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(3) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(3) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(3) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(3) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(3) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(3) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "first_tuesday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(4) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(4) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(4) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(4) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(4) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(4) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(4) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "first_wednesday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(5) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(5) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(5) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(5) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(5) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(5) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(5) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "first_thursday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(6) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(6) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(6) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(6) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(6) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(6) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(6) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "first_friday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(7) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(7) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(7) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(7) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(7) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(7) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(7) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "first_saturday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(8) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(8) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(8) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(8) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(8) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(8) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(8) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "second_monday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(10) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(10) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(10) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(10) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(10) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(10) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(10) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "second_tuesday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(11) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(11) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(11) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(11) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(11) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(11) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(11) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "second_wednesday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(12) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(12) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(12) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(12) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(12) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(12) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(12) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "second_thursday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(13) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(13) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(13) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(13) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(13) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(13) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(13) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "second_friday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(14) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(14) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(14) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(14) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(14) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(14) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(14) > table > tbody > tr:nth-child(2) > td";
            }
            else if (day == "second_saturday")
            {
                one_lesson_name_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                one_lesson_teacher_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                one_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                one_lesson_class_s = "body > table > tbody > tr:nth-child(2) > td:nth-child(15) > table > tbody > tr:nth-child(2) > td";

                two_lesson_name_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                two_lesson_teacher_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                two_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                two_lesson_class_s = "body > table > tbody > tr:nth-child(3) > td:nth-child(15) > table > tbody > tr:nth-child(2) > td";

                three_lesson_name_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                three_lesson_teacher_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                three_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                three_lesson_class_s = "body > table > tbody > tr:nth-child(4) > td:nth-child(15) > table > tbody > tr:nth-child(2) > td";

                four_lesson_name_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                four_lesson_teacher_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                four_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                four_lesson_class_s = "body > table > tbody > tr:nth-child(5) > td:nth-child(15) > table > tbody > tr:nth-child(2) > td";

                five_lesson_name_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                five_lesson_teacher_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                five_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                five_lesson_class_s = "body > table > tbody > tr:nth-child(6) > td:nth-child(15) > table > tbody > tr:nth-child(2) > td";

                six_lesson_name_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(1)";
                six_lesson_teacher_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(2)";
                six_lesson_teacher_2_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(15) > table > tbody > tr:nth-child(1) > td:nth-child(4)";
                six_lesson_class_s = "body > table > tbody > tr:nth-child(7) > td:nth-child(15) > table > tbody > tr:nth-child(2) > td";
            }

            if (select_group_id(tag) != 0 || select_group_id(tag.Replace("-", "")) != 0 || select_group_id(one_defis(tag)) != 0 || select_group_id(two_defis(tag)) != 0)
            {
                driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

                driver.Navigate().GoToUrl("https://www.oat.ru/sites/default/downloads/schedule/Classes.html");

                List<IWebElement> tags = driver.FindElements(By.CssSelector("body > table > tbody > tr > td:nth-child(1) > a")).ToList();

                bool find = false;

                for (int i = 0; i < tags.Count; i++)
                {
                    if (tags[i].Text == tag || tags[i].Text == tag.Replace("-", "") || tags[i].Text == one_defis(tag) || tags[i].Text == two_defis(tag) )
                    {
                        find = true;
                        tags[i].Click();
                        IWebElement link_to_paper = driver.FindElement(By.CssSelector("body > a:nth-child(4)"));
                        link_to_paper.Click();

                        try
                        {
                            IWebElement one_lesson_name_e = driver.FindElement(By.CssSelector(one_lesson_name_s));
                            IWebElement one_lesson_teacher_e = driver.FindElement(By.CssSelector(one_lesson_teacher_s));
                            List <IWebElement> one_lesson_class_e = driver.FindElements(By.CssSelector(one_lesson_class_s)).ToList();

                            one_lesson_name_t = one_lesson_name_e.Text;
                            one_lesson_teacher_t = one_lesson_teacher_e.Text;
                            
                            if(one_lesson_class_e.Count == 1) one_lesson_class_t = one_lesson_class_e[0].Text;
                            else if(one_lesson_class_e.Count == 2)
                            {
                                one_lesson_class_t = one_lesson_class_e[0].Text;
                                one_lesson_class_2_t = one_lesson_class_e[1].Text;
                            }

                            IWebElement one_lesson_teacher_2_e = driver.FindElement(By.CssSelector(one_lesson_teacher_2_s));
                            one_lesson_teacher_2_t = one_lesson_teacher_2_e.Text;

                        }
                        catch { }

                        try
                        {
                            IWebElement two_lesson_name_e = driver.FindElement(By.CssSelector(two_lesson_name_s));
                            IWebElement two_lesson_teacher_e = driver.FindElement(By.CssSelector(two_lesson_teacher_s));
                            List <IWebElement> two_lesson_class_e = driver.FindElements(By.CssSelector(two_lesson_class_s)).ToList();

                            two_lesson_name_t = two_lesson_name_e.Text;
                            two_lesson_teacher_t = two_lesson_teacher_e.Text;

                            if (two_lesson_class_e.Count == 1) two_lesson_class_t = two_lesson_class_e[0].Text;
                            else if (two_lesson_class_e.Count == 2)
                            {
                                two_lesson_class_t = two_lesson_class_e[0].Text;
                                two_lesson_class_2_t = two_lesson_class_e[1].Text;
                            }

                            IWebElement two_lesson_teacher_2_e = driver.FindElement(By.CssSelector(two_lesson_teacher_2_s));
                            two_lesson_teacher_2_t = two_lesson_teacher_2_e.Text;

                        }
                        catch { }

                        try
                        {
                            IWebElement three_lesson_name_e = driver.FindElement(By.CssSelector(three_lesson_name_s));
                            IWebElement three_lesson_teacher_e = driver.FindElement(By.CssSelector(three_lesson_teacher_s));
                            List <IWebElement> three_lesson_class_e = driver.FindElements(By.CssSelector(three_lesson_class_s)).ToList();

                            three_lesson_name_t = three_lesson_name_e.Text;
                            three_lesson_teacher_t = three_lesson_teacher_e.Text;

                            if (three_lesson_class_e.Count == 1) three_lesson_class_t = three_lesson_class_e[0].Text;
                            else if (three_lesson_class_e.Count == 2)
                            {
                                three_lesson_class_t = three_lesson_class_e[0].Text;
                                three_lesson_class_2_t = three_lesson_class_e[1].Text;
                            }

                            IWebElement three_lesson_teacher_2_e = driver.FindElement(By.CssSelector(three_lesson_teacher_2_s));
                            three_lesson_teacher_2_t = three_lesson_teacher_2_e.Text;
                        }
                        catch { }

                        try
                        {
                            IWebElement four_lesson_name_e = driver.FindElement(By.CssSelector(four_lesson_name_s));
                            IWebElement four_lesson_teacher_e = driver.FindElement(By.CssSelector(four_lesson_teacher_s));
                            List <IWebElement> four_lesson_class_e = driver.FindElements(By.CssSelector(four_lesson_class_s)).ToList();

                            four_lesson_name_t = four_lesson_name_e.Text;
                            four_lesson_teacher_t = four_lesson_teacher_e.Text;

                            if (four_lesson_class_e.Count == 1) one_lesson_class_t = four_lesson_class_e[0].Text;
                            else if (four_lesson_class_e.Count == 2)
                            {
                                four_lesson_class_t = four_lesson_class_e[0].Text;
                                four_lesson_class_2_t = four_lesson_class_e[1].Text;
                            }

                            IWebElement four_lesson_teacher_2_e = driver.FindElement(By.CssSelector(four_lesson_teacher_2_s));
                            four_lesson_teacher_2_t = four_lesson_teacher_2_e.Text;
                        }
                        catch { }

                        try
                        {
                            IWebElement five_lesson_name_e = driver.FindElement(By.CssSelector(five_lesson_name_s));
                            IWebElement five_lesson_teacher_e = driver.FindElement(By.CssSelector(five_lesson_teacher_s));
                            List <IWebElement> five_lesson_class_e = driver.FindElements(By.CssSelector(five_lesson_class_s)).ToList();

                            five_lesson_name_t = five_lesson_name_e.Text;

                            five_lesson_teacher_t = five_lesson_teacher_e.Text;
                            
                             
                            if(five_lesson_class_e.Count == 1) five_lesson_class_t = five_lesson_class_e[0].Text;
                            else if (five_lesson_class_e.Count == 2)
                            {
                                five_lesson_class_t = five_lesson_class_e[0].Text;
                                five_lesson_class_2_t = five_lesson_class_e[1].Text;
                            }

                            IWebElement five_lesson_teacher_2_e = driver.FindElement(By.CssSelector(five_lesson_teacher_2_s));
                            five_lesson_teacher_2_t = five_lesson_teacher_2_e.Text;

                        }
                        catch { }

                        try
                        {
                            IWebElement six_lesson_name_e = driver.FindElement(By.CssSelector(six_lesson_name_s));
                            IWebElement six_lesson_teacher_e = driver.FindElement(By.CssSelector(six_lesson_teacher_s));
                            List <IWebElement> six_lesson_class_e = driver.FindElements(By.CssSelector(six_lesson_class_s)).ToList();

                            six_lesson_name_t = six_lesson_name_e.Text;
                            six_lesson_teacher_t = six_lesson_teacher_e.Text;

                            if (six_lesson_class_e.Count == 1) six_lesson_class_t = six_lesson_class_e[0].Text;
                            else if (six_lesson_class_e.Count == 2)
                            {
                                six_lesson_class_t = six_lesson_class_e[0].Text;
                                six_lesson_class_2_t = six_lesson_class_e[1].Text;
                            }

                            IWebElement six_lesson_teacher_2_e = driver.FindElement(By.CssSelector(six_lesson_teacher_2_s));
                            six_lesson_teacher_2_t = six_lesson_teacher_2_e.Text;
                        }
                        catch { }

                        if (one_lesson_name_t != "")
                        {
                            //Console.WriteLine("1 пара: " + one_lesson_name_t);
                        }
                        if (one_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + one_lesson_teacher_t);
                        }
                        if (one_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + one_lesson_class_t);
                        }
                        if (one_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + one_lesson_teacher_2_t);
                        }
                        if (one_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + one_lesson_class_2_t);
                        }
                        if (two_lesson_name_t != "")
                        {
                            //Console.WriteLine("2 пара: " + two_lesson_name_t);
                        }
                        if (two_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + two_lesson_teacher_t);
                        }
                        if (two_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + two_lesson_class_t);
                        }
                        if (two_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + two_lesson_teacher_2_t);
                        }
                        if (two_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + two_lesson_class_2_t);
                        }
                        if (three_lesson_name_t != "")
                        {
                            //Console.WriteLine("3 пара: " + three_lesson_name_t);
                        }
                        if (three_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + three_lesson_teacher_t);
                        }
                        if (three_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + three_lesson_class_t);
                        }
                        if (three_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + three_lesson_teacher_2_t);
                        }
                        if (three_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + three_lesson_class_2_t);
                        }
                        if (four_lesson_name_t != "")
                        {
                            //Console.WriteLine("4 пара: " + four_lesson_name_t);
                        }
                        if (four_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + four_lesson_teacher_t);
                        }
                        if (four_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + four_lesson_class_t);
                        }
                        if (four_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + four_lesson_teacher_2_t);
                        }
                        if (four_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + four_lesson_class_2_t);
                        }
                        if (five_lesson_name_t != "")
                        {
                            //Console.WriteLine("5 пара: " + five_lesson_name_t);
                        }
                        if (five_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + five_lesson_teacher_t);
                        }
                        if (five_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + five_lesson_class_t);
                        }
                        if (five_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + five_lesson_teacher_2_t);
                        }
                        if (five_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + five_lesson_class_2_t);
                        }
                        if (six_lesson_name_t != "")
                        {
                            //Console.WriteLine("6 пара: " + six_lesson_name_t);
                        }
                        if (six_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + six_lesson_teacher_t);
                        }
                        if (six_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + six_lesson_class_t);
                        }
                        if (six_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + six_lesson_teacher_2_t);
                        }
                        if (six_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + six_lesson_class_t);
                        }

                        if (select_group_id(tag) != 0)
                        {
                            update_day(select_group_day_id(select_group_id(tag), day), one_lesson_name_t, one_lesson_teacher_t, one_lesson_class_t, one_lesson_teacher_2_t, one_lesson_class_2_t, two_lesson_name_t, two_lesson_teacher_t, two_lesson_class_t, two_lesson_teacher_2_t, two_lesson_class_2_t, three_lesson_name_t, three_lesson_teacher_t, three_lesson_class_t, three_lesson_teacher_2_t, three_lesson_class_2_t, four_lesson_name_t, four_lesson_teacher_t, four_lesson_class_t, four_lesson_teacher_2_t, four_lesson_class_2_t, five_lesson_name_t, five_lesson_teacher_t, five_lesson_class_t, five_lesson_teacher_2_t, five_lesson_class_2_t, six_lesson_name_t, six_lesson_teacher_t, six_lesson_class_t, six_lesson_teacher_2_t, six_lesson_class_2_t);
                        }
                        else if (select_group_id(tag.Replace("-", "")) != 0)
                        {
                            update_day(select_group_day_id(select_group_id(tag.Replace("-", "")), day), one_lesson_name_t, one_lesson_teacher_t, one_lesson_class_t, one_lesson_teacher_2_t, one_lesson_class_2_t, two_lesson_name_t, two_lesson_teacher_t, two_lesson_class_t, two_lesson_teacher_2_t, two_lesson_class_2_t, three_lesson_name_t, three_lesson_teacher_t, three_lesson_class_t, three_lesson_teacher_2_t, three_lesson_class_2_t, four_lesson_name_t, four_lesson_teacher_t, four_lesson_class_t, four_lesson_teacher_2_t, four_lesson_class_2_t, five_lesson_name_t, five_lesson_teacher_t, five_lesson_class_t, five_lesson_teacher_2_t, five_lesson_class_2_t, six_lesson_name_t, six_lesson_teacher_t, six_lesson_class_t, six_lesson_teacher_2_t, six_lesson_class_2_t);
                        }
                        else if (select_group_id(one_defis(tag)) != 0)
                        {
                            update_day(select_group_day_id(select_group_id(one_defis(tag)), day), one_lesson_name_t, one_lesson_teacher_t, one_lesson_class_t, one_lesson_teacher_2_t, one_lesson_class_2_t, two_lesson_name_t, two_lesson_teacher_t, two_lesson_class_t, two_lesson_teacher_2_t, two_lesson_class_2_t, three_lesson_name_t, three_lesson_teacher_t, three_lesson_class_t, three_lesson_teacher_2_t, three_lesson_class_2_t, four_lesson_name_t, four_lesson_teacher_t, four_lesson_class_t, four_lesson_teacher_2_t, four_lesson_class_2_t, five_lesson_name_t, five_lesson_teacher_t, five_lesson_class_t, five_lesson_teacher_2_t, five_lesson_class_2_t, six_lesson_name_t, six_lesson_teacher_t, six_lesson_class_t, six_lesson_teacher_2_t, six_lesson_class_2_t);
                        }
                        else if (select_group_id(two_defis(tag)) != 0)
                        {
                            update_day(select_group_day_id(select_group_id(two_defis(tag)), day), one_lesson_name_t, one_lesson_teacher_t, one_lesson_class_t, one_lesson_teacher_2_t, one_lesson_class_2_t, two_lesson_name_t, two_lesson_teacher_t, two_lesson_class_t, two_lesson_teacher_2_t, two_lesson_class_2_t, three_lesson_name_t, three_lesson_teacher_t, three_lesson_class_t, three_lesson_teacher_2_t, three_lesson_class_2_t, four_lesson_name_t, four_lesson_teacher_t, four_lesson_class_t, four_lesson_teacher_2_t, four_lesson_class_2_t, five_lesson_name_t, five_lesson_teacher_t, five_lesson_class_t, five_lesson_teacher_2_t, five_lesson_class_2_t, six_lesson_name_t, six_lesson_teacher_t, six_lesson_class_t, six_lesson_teacher_2_t, six_lesson_class_2_t);
                        }

                        break;
                    }
                }

                tags = driver.FindElements(By.CssSelector("body > table > tbody > tr > td:nth-child(2) > a")).ToList();

                for (int i = 0; i < tags.Count; i++)
                {
                    if (tags[i].Text == tag || tags[i].Text == tag.Replace("-", "") || tags[i].Text == one_defis(tag) || tags[i].Text == two_defis(tag))
                    {
                        find = true;
                        tags[i].Click();
                        IWebElement link_to_paper = driver.FindElement(By.CssSelector("body > a:nth-child(4)"));
                        link_to_paper.Click();

                        try
                        {
                            IWebElement one_lesson_name_e = driver.FindElement(By.CssSelector(one_lesson_name_s));
                            IWebElement one_lesson_teacher_e = driver.FindElement(By.CssSelector(one_lesson_teacher_s));
                            List<IWebElement> one_lesson_class_e = driver.FindElements(By.CssSelector(one_lesson_class_s)).ToList();

                            one_lesson_name_t = one_lesson_name_e.Text;
                            one_lesson_teacher_t = one_lesson_teacher_e.Text;

                            if (one_lesson_class_e.Count == 1) one_lesson_class_t = one_lesson_class_e[0].Text;
                            else if (one_lesson_class_e.Count == 2)
                            {
                                one_lesson_class_t = one_lesson_class_e[0].Text;
                                one_lesson_class_2_t = one_lesson_class_e[1].Text;
                            }

                            IWebElement one_lesson_teacher_2_e = driver.FindElement(By.CssSelector(one_lesson_teacher_2_s));
                            one_lesson_teacher_2_t = one_lesson_teacher_2_e.Text;

                        }
                        catch { }

                        try
                        {
                            IWebElement two_lesson_name_e = driver.FindElement(By.CssSelector(two_lesson_name_s));
                            IWebElement two_lesson_teacher_e = driver.FindElement(By.CssSelector(two_lesson_teacher_s));
                            List<IWebElement> two_lesson_class_e = driver.FindElements(By.CssSelector(two_lesson_class_s)).ToList();

                            two_lesson_name_t = two_lesson_name_e.Text;
                            two_lesson_teacher_t = two_lesson_teacher_e.Text;

                            if (two_lesson_class_e.Count == 1) two_lesson_class_t = two_lesson_class_e[0].Text;
                            else if (two_lesson_class_e.Count == 2)
                            {
                                two_lesson_class_t = two_lesson_class_e[0].Text;
                                two_lesson_class_2_t = two_lesson_class_e[1].Text;
                            }

                            IWebElement two_lesson_teacher_2_e = driver.FindElement(By.CssSelector(two_lesson_teacher_2_s));
                            two_lesson_teacher_2_t = two_lesson_teacher_2_e.Text;

                        }
                        catch { }

                        try
                        {
                            IWebElement three_lesson_name_e = driver.FindElement(By.CssSelector(three_lesson_name_s));
                            IWebElement three_lesson_teacher_e = driver.FindElement(By.CssSelector(three_lesson_teacher_s));
                            List<IWebElement> three_lesson_class_e = driver.FindElements(By.CssSelector(three_lesson_class_s)).ToList();

                            three_lesson_name_t = three_lesson_name_e.Text;
                            three_lesson_teacher_t = three_lesson_teacher_e.Text;

                            if (three_lesson_class_e.Count == 1) three_lesson_class_t = three_lesson_class_e[0].Text;
                            else if (three_lesson_class_e.Count == 2)
                            {
                                three_lesson_class_t = three_lesson_class_e[0].Text;
                                three_lesson_class_2_t = three_lesson_class_e[1].Text;
                            }

                            IWebElement three_lesson_teacher_2_e = driver.FindElement(By.CssSelector(three_lesson_teacher_2_s));
                            three_lesson_teacher_2_t = three_lesson_teacher_2_e.Text;
                        }
                        catch { }

                        try
                        {
                            IWebElement four_lesson_name_e = driver.FindElement(By.CssSelector(four_lesson_name_s));
                            IWebElement four_lesson_teacher_e = driver.FindElement(By.CssSelector(four_lesson_teacher_s));
                            List<IWebElement> four_lesson_class_e = driver.FindElements(By.CssSelector(four_lesson_class_s)).ToList();

                            four_lesson_name_t = four_lesson_name_e.Text;
                            four_lesson_teacher_t = four_lesson_teacher_e.Text;

                            if (four_lesson_class_e.Count == 1) one_lesson_class_t = four_lesson_class_e[0].Text;
                            else if (four_lesson_class_e.Count == 2)
                            {
                                four_lesson_class_t = four_lesson_class_e[0].Text;
                                four_lesson_class_2_t = four_lesson_class_e[1].Text;
                            }

                            IWebElement four_lesson_teacher_2_e = driver.FindElement(By.CssSelector(four_lesson_teacher_2_s));
                            four_lesson_teacher_2_t = four_lesson_teacher_2_e.Text;
                        }
                        catch { }

                        try
                        {
                            IWebElement five_lesson_name_e = driver.FindElement(By.CssSelector(five_lesson_name_s));
                            IWebElement five_lesson_teacher_e = driver.FindElement(By.CssSelector(five_lesson_teacher_s));
                            List<IWebElement> five_lesson_class_e = driver.FindElements(By.CssSelector(five_lesson_class_s)).ToList();

                            five_lesson_name_t = five_lesson_name_e.Text;

                            five_lesson_teacher_t = five_lesson_teacher_e.Text;


                            if (five_lesson_class_e.Count == 1) five_lesson_class_t = five_lesson_class_e[0].Text;
                            else if (five_lesson_class_e.Count == 2)
                            {
                                five_lesson_class_t = five_lesson_class_e[0].Text;
                                five_lesson_class_2_t = five_lesson_class_e[1].Text;
                            }

                            IWebElement five_lesson_teacher_2_e = driver.FindElement(By.CssSelector(five_lesson_teacher_2_s));
                            five_lesson_teacher_2_t = five_lesson_teacher_2_e.Text;

                        }
                        catch { }

                        try
                        {
                            IWebElement six_lesson_name_e = driver.FindElement(By.CssSelector(six_lesson_name_s));
                            IWebElement six_lesson_teacher_e = driver.FindElement(By.CssSelector(six_lesson_teacher_s));
                            List<IWebElement> six_lesson_class_e = driver.FindElements(By.CssSelector(six_lesson_class_s)).ToList();

                            six_lesson_name_t = six_lesson_name_e.Text;
                            six_lesson_teacher_t = six_lesson_teacher_e.Text;

                            if (six_lesson_class_e.Count == 1) six_lesson_class_t = six_lesson_class_e[0].Text;
                            else if (six_lesson_class_e.Count == 2)
                            {
                                six_lesson_class_t = six_lesson_class_e[0].Text;
                                six_lesson_class_2_t = six_lesson_class_e[1].Text;
                            }

                            IWebElement six_lesson_teacher_2_e = driver.FindElement(By.CssSelector(six_lesson_teacher_2_s));
                            six_lesson_teacher_2_t = six_lesson_teacher_2_e.Text;
                        }
                        catch { }

                        if (one_lesson_name_t != "")
                        {
                            //Console.WriteLine("1 пара: " + one_lesson_name_t);
                        }
                        if (one_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + one_lesson_teacher_t);
                        }
                        if (one_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + one_lesson_class_t);
                        }
                        if (one_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + one_lesson_teacher_2_t);
                        }
                        if (one_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + one_lesson_class_2_t);
                        }
                        if (two_lesson_name_t != "")
                        {
                            //Console.WriteLine("2 пара: " + two_lesson_name_t);
                        }
                        if (two_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + two_lesson_teacher_t);
                        }
                        if (two_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + two_lesson_class_t);
                        }
                        if (two_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + two_lesson_teacher_2_t);
                        }
                        if (two_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + two_lesson_class_2_t);
                        }
                        if (three_lesson_name_t != "")
                        {
                            //Console.WriteLine("3 пара: " + three_lesson_name_t);
                        }
                        if (three_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + three_lesson_teacher_t);
                        }
                        if (three_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + three_lesson_class_t);
                        }
                        if (three_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + three_lesson_teacher_2_t);
                        }
                        if (three_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + three_lesson_class_2_t);
                        }
                        if (four_lesson_name_t != "")
                        {
                            //Console.WriteLine("4 пара: " + four_lesson_name_t);
                        }
                        if (four_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + four_lesson_teacher_t);
                        }
                        if (four_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + four_lesson_class_t);
                        }
                        if (four_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + four_lesson_teacher_2_t);
                        }
                        if (four_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + four_lesson_class_2_t);
                        }
                        if (five_lesson_name_t != "")
                        {
                            //Console.WriteLine("5 пара: " + five_lesson_name_t);
                        }
                        if (five_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + five_lesson_teacher_t);
                        }
                        if (five_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + five_lesson_class_t);
                        }
                        if (five_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + five_lesson_teacher_2_t);
                        }
                        if (five_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + five_lesson_class_2_t);
                        }
                        if (six_lesson_name_t != "")
                        {
                            //Console.WriteLine("6 пара: " + six_lesson_name_t);
                        }
                        if (six_lesson_teacher_t != "")
                        {
                            //Console.WriteLine("препод: " + six_lesson_teacher_t);
                        }
                        if (six_lesson_class_t != "")
                        {
                            //Console.WriteLine("кабинет: " + six_lesson_class_t);
                        }
                        if (six_lesson_teacher_2_t != "")
                        {
                            //Console.WriteLine("препод: " + six_lesson_teacher_2_t);
                        }
                        if (six_lesson_class_2_t != "")
                        {
                            //Console.WriteLine("кабинет: " + six_lesson_class_t);
                        }

                        update_day(select_group_day_id(select_group_id(tag), day), one_lesson_name_t, one_lesson_teacher_t, one_lesson_class_t, one_lesson_teacher_2_t, one_lesson_class_2_t, two_lesson_name_t, two_lesson_teacher_t, two_lesson_class_t, two_lesson_teacher_2_t, two_lesson_class_2_t, three_lesson_name_t, three_lesson_teacher_t, three_lesson_class_t, three_lesson_teacher_2_t, three_lesson_class_2_t, four_lesson_name_t, four_lesson_teacher_t, four_lesson_class_t, four_lesson_teacher_2_t, four_lesson_class_2_t, five_lesson_name_t, five_lesson_teacher_t, five_lesson_class_t, five_lesson_teacher_2_t, five_lesson_class_2_t, six_lesson_name_t, six_lesson_teacher_t, six_lesson_class_t, six_lesson_teacher_2_t, six_lesson_class_2_t);

                        driver.Close();
                        break;
                        
                    }
                }
                if(find == false)
                {
                    Console.WriteLine("Группы " + tag + " нет на странице с группами");
                }
            }
            else Console.WriteLine("Группы "+ tag +" нет в базе данных");
            driver.Close();
        }

        public static void Update_Schedule_Groups()
        {
            for (int i = 1; i <= 90; i++)
            {
                try
                {
                    Update_Schedule_Group(select_tag(i), "first_monday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " first_monday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "first_tuesday");
                }
                catch { Console.WriteLine(select_tag(i) + " first_tuesday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "first_wednesday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " first_wednesday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "first_thursday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " first_thursday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "first_friday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " first_friday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "first_saturday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " first_saturday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "second_monday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " second_monday"); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "second_tuesday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " second_tuesday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "second_wednesday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " second_wednesday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "second_thursday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " second_thursday"); Kill(); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "second_friday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " second_friday"); }

                try
                {
                    Update_Schedule_Group(select_tag(i), "second_saturday");
                    Kill();
                }
                catch { Console.WriteLine(select_tag(i) + " second_saturday"); Kill(); }

                Console.WriteLine("{0:00.00}%", (i / 90f * 100f));
            }
        }

    }
}
