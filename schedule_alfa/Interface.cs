using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
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
using MihaZupan;
using MihaZupan.Socks5Proxy.Enums;
using MihaZupan.Socks5Proxy;
using MySql.Data.MySqlClient;
using Leaf.xNet;
using static schedule_alfa.TelegramBot;
using static schedule_alfa.Database;
namespace schedule_alfa
{
    class Interface
    {
        public static List<string> result_groups = new List<string>() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        static int total_groups = 0;
        static string name = "";
        static int course = 0;
        static int msg_id = 0;
        static string smile_easy = "♥️";
        static string smile_schedule = "♠️";
        public static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
            result_groups = new List<string>() {"/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/", "/" };
            try
            {
                await Bot.AnswerCallbackQueryAsync(
                        callbackQuery.Id,
                        $"{callbackQuery.Data}");
            }
            catch { }
            //callback
            try
            {
                await Bot.SendTextMessageAsync(
                callbackQuery.Message.Chat.Id,
                $"", disableNotification: true);
            }
            catch { }

            cid_own = callbackQueryEventArgs.CallbackQuery.Message.Chat.Id;
            name = callbackQueryEventArgs.CallbackQuery.Message.Chat.FirstName + " " + callbackQueryEventArgs.CallbackQuery.Message.Chat.LastName;

            

            switch (callbackQuery.Data)
            {
                case "1":
                    course = 1;
                    #region course

                    result_groups = return_groups(1);
                  
                    total_groups = result_groups.Count;

                    var choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                          new []
                         {
                             InlineKeyboardButton.WithCallbackData("Групп нет")
                         }
                    });

                    
                    if (total_groups == 1)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             }
                        });

                    }
                    else if (total_groups == 2)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             }
                        });
                    }
                    else if (total_groups == 3)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             }
                        });
                    }
                    else if (total_groups == 4)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             }
                        });
                    }
                    else if (total_groups == 5)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             }
                        });
                    }
                    else if (total_groups == 6)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             }
                        });
                    }
                    else if (total_groups == 7)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             }
                        });
                    }
                    else if (total_groups == 8)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             }
                        });
                    }
                    else if (total_groups == 9)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             }
                        });
                    }
                    else if (total_groups == 10)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             }
                        });
                    }
                    else if (total_groups == 11)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             }
                        });
                    }
                    else if (total_groups == 12)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             }
                        });
                    }
                    else if (total_groups == 13)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             }
                        });
                    }
                    else if (total_groups == 14)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             }
                        });
                    }
                    else if (total_groups == 15)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             }
                        });
                    }
                    else if (total_groups == 16)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             }
                        });
                    }
                    else if (total_groups == 17)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             }
                        });
                    }
                    else if (total_groups == 18)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             }
                        });
                    }
                    else if (total_groups == 19)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             }
                        });
                    }
                    else if (total_groups == 20)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             }
                        });
                    }
                    else if (total_groups == 21)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             }
                        });
                    }
                    else if (total_groups == 22)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             }
                        });
                    }
                    else if (total_groups == 23)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             }
                        });
                    }
                    else if (total_groups == 24)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             }
                        });
                    }
                    else if (total_groups == 25)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[24].ToString())
                             }
                        });
                    }
                    


                    try
                    {
                        await Bot.EditMessageReplyMarkupAsync(cid_own, callbackQuery.Message.MessageId, choose_group_inlineKeyboard);
                    }
                    catch
                    {
                        //Process.Start(path);
                        //Environment.Exit(0);
                    }

                    #endregion
                    
                    break;

                case "2":
                    course = 2;
                    #region course
                    result_groups = return_groups(2);
                   
                    total_groups = result_groups.Count;

                    choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                          new []
                         {
                             InlineKeyboardButton.WithCallbackData("Групп нет")
                         }
                    });


                    if (total_groups == 1)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             }
                        });

                    }
                    else if (total_groups == 2)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             }
                        });
                    }
                    else if (total_groups == 3)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             }
                        });
                    }
                    else if (total_groups == 4)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             }
                        });
                    }
                    else if (total_groups == 5)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             }
                        });
                    }
                    else if (total_groups == 6)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             }
                        });
                    }
                    else if (total_groups == 7)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             }
                        });
                    }
                    else if (total_groups == 8)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             }
                        });
                    }
                    else if (total_groups == 9)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             }
                        });
                    }
                    else if (total_groups == 10)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             }
                        });
                    }
                    else if (total_groups == 11)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             }
                        });
                    }
                    else if (total_groups == 12)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             }
                        });
                    }
                    else if (total_groups == 13)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             }
                        });
                    }
                    else if (total_groups == 14)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             }
                        });
                    }
                    else if (total_groups == 15)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             }
                        });
                    }
                    else if (total_groups == 16)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             }
                        });
                    }
                    else if (total_groups == 17)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             }
                        });
                    }
                    else if (total_groups == 18)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             }
                        });
                    }
                    else if (total_groups == 19)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             }
                        });
                    }
                    else if (total_groups == 20)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             }
                        });
                    }
                    else if (total_groups == 21)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             }
                        });
                    }
                    else if (total_groups == 22)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             }
                        });
                    }
                    else if (total_groups == 23)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             }
                        });
                    }
                    else if (total_groups == 24)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             }
                        });
                    }
                    else if (total_groups == 25)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[24].ToString())
                             }
                        });
                    }



                    try
                    {
                        await Bot.EditMessageReplyMarkupAsync(cid_own, callbackQuery.Message.MessageId, choose_group_inlineKeyboard);
                    }
                    catch
                    {
                        //Process.Start(path);
                        //Environment.Exit(0);
                    }

                    #endregion
                    break;

                case "3":
                    course = 3;
                    #region course
                    result_groups = return_groups(3);

                    total_groups = result_groups.Count;

                    choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                          new []
                         {
                             InlineKeyboardButton.WithCallbackData("Групп нет")
                         }
                    });


                    if (total_groups == 1)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             }
                        });

                    }
                    else if (total_groups == 2)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             }
                        });
                    }
                    else if (total_groups == 3)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             }
                        });
                    }
                    else if (total_groups == 4)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             }
                        });
                    }
                    else if (total_groups == 5)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             }
                        });
                    }
                    else if (total_groups == 6)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             }
                        });
                    }
                    else if (total_groups == 7)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             }
                        });
                    }
                    else if (total_groups == 8)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             }
                        });
                    }
                    else if (total_groups == 9)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             }
                        });
                    }
                    else if (total_groups == 10)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             }
                        });
                    }
                    else if (total_groups == 11)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             }
                        });
                    }
                    else if (total_groups == 12)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             }
                        });
                    }
                    else if (total_groups == 13)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             }
                        });
                    }
                    else if (total_groups == 14)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             }
                        });
                    }
                    else if (total_groups == 15)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             }
                        });
                    }
                    else if (total_groups == 16)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             }
                        });
                    }
                    else if (total_groups == 17)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             }
                        });
                    }
                    else if (total_groups == 18)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             }
                        });
                    }
                    else if (total_groups == 19)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             }
                        });
                    }
                    else if (total_groups == 20)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             }
                        });
                    }
                    else if (total_groups == 21)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             }
                        });
                    }
                    else if (total_groups == 22)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             }
                        });
                    }
                    else if (total_groups == 23)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             }
                        });
                    }
                    else if (total_groups == 24)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             }
                        });
                    }
                    else if (total_groups == 25)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[24].ToString())
                             }
                        });
                    }



                    try
                    {
                        await Bot.EditMessageReplyMarkupAsync(cid_own, callbackQuery.Message.MessageId, choose_group_inlineKeyboard);
                    }
                    catch
                    {
                        //Process.Start(path);
                        //Environment.Exit(0);
                    }

                    #endregion
                    break;

                case "4":
                    course = 4;
                    #region course
                    result_groups = return_groups(4);
                  

                    total_groups = result_groups.Count;

                    choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                          new []
                         {
                             InlineKeyboardButton.WithCallbackData("Групп нет")
                         }
                    });


                    if (total_groups == 1)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             }
                        });

                    }
                    else if (total_groups == 2)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             }
                        });
                    }
                    else if (total_groups == 3)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             }
                        });
                    }
                    else if (total_groups == 4)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             }
                        });
                    }
                    else if (total_groups == 5)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             }
                        });
                    }
                    else if (total_groups == 6)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             }
                        });
                    }
                    else if (total_groups == 7)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             }
                        });
                    }
                    else if (total_groups == 8)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             }
                        });
                    }
                    else if (total_groups == 9)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             }
                        });
                    }
                    else if (total_groups == 10)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             }
                        });
                    }
                    else if (total_groups == 11)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             }
                        });
                    }
                    else if (total_groups == 12)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             }
                        });
                    }
                    else if (total_groups == 13)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             }
                        });
                    }
                    else if (total_groups == 14)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             }
                        });
                    }
                    else if (total_groups == 15)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             }
                        });
                    }
                    else if (total_groups == 16)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             }
                        });
                    }
                    else if (total_groups == 17)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             }
                        });
                    }
                    else if (total_groups == 18)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             }
                        });
                    }
                    else if (total_groups == 19)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             }
                        });
                    }
                    else if (total_groups == 20)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             }
                        });
                    }
                    else if (total_groups == 21)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             }
                        });
                    }
                    else if (total_groups == 22)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             }
                        });
                    }
                    else if (total_groups == 23)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             }
                        });
                    }
                    else if (total_groups == 24)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             }
                        });
                    }
                    else if (total_groups == 25)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[24].ToString())
                             }
                        });
                    }



                    try
                    {
                        await Bot.EditMessageReplyMarkupAsync(cid_own, callbackQuery.Message.MessageId, choose_group_inlineKeyboard);
                    }
                    catch
                    {
                        //Process.Start(path);
                        //Environment.Exit(0);
                    }

                    #endregion
                    break;

                case "5":
                    course = 5;
                    #region course
                    result_groups = return_groups(5);
                    
                    total_groups = result_groups.Count;

                    choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                          new []
                         {
                             InlineKeyboardButton.WithCallbackData("Групп нет")
                         }
                    });


                    if (total_groups == 1)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             }
                        });

                    }
                    else if (total_groups == 2)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             }
                        });
                    }
                    else if (total_groups == 3)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             }
                        });
                    }
                    else if (total_groups == 4)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             }
                        });
                    }
                    else if (total_groups == 5)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             }
                        });
                    }
                    else if (total_groups == 6)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             }
                        });
                    }
                    else if (total_groups == 7)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             }
                        });
                    }
                    else if (total_groups == 8)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             }
                        });
                    }
                    else if (total_groups == 9)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             }
                        });
                    }
                    else if (total_groups == 10)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             }
                        });
                    }
                    else if (total_groups == 11)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             }
                        });
                    }
                    else if (total_groups == 12)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             }
                        });
                    }
                    else if (total_groups == 13)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             }
                        });
                    }
                    else if (total_groups == 14)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             }
                        });
                    }
                    else if (total_groups == 15)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             }
                        });
                    }
                    else if (total_groups == 16)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             }
                        });
                    }
                    else if (total_groups == 17)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             }
                        });
                    }
                    else if (total_groups == 18)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             }
                        });
                    }
                    else if (total_groups == 19)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             }
                        });
                    }
                    else if (total_groups == 20)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             }
                        });
                    }
                    else if (total_groups == 21)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             }
                        });
                    }
                    else if (total_groups == 22)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             }
                        });
                    }
                    else if (total_groups == 23)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             }
                        });
                    }
                    else if (total_groups == 24)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             }
                        });
                    }
                    else if (total_groups == 25)
                    {
                        choose_group_inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[0].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[1].ToString())
                             },new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[2].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[3].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[4].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[5].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[6].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[7].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[8].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[9].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[10].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[11].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[12].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[13].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[14].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[15].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[16].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[17].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[18].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[19].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[20].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[21].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[22].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[23].ToString())
                             },
                             new []
                             {
                             InlineKeyboardButton.WithCallbackData(result_groups[24].ToString())
                             }
                        });
                    }



                    try
                    {
                        await Bot.EditMessageReplyMarkupAsync(cid_own, callbackQuery.Message.MessageId, choose_group_inlineKeyboard);
                    }
                    catch
                    {
                        //Process.Start(path);
                        //Environment.Exit(0);
                    }

                    #endregion
                    break;

                case "1️⃣ понедельник":
                    try
                    {
                        var schedule_inlineKeyboard_mon = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "first_monday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId,"<b>Первый понедельник</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_mon);
                    }
                    catch(Exception ex) { Console.WriteLine(ex.Message + "_GG_");  }
                    break;

                case "1️⃣ вторник":
                    try
                    {
                        var schedule_inlineKeyboard_tue = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "first_tuesday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Первый вторник</b>\n\n"  + answer, ParseMode.Html, false, schedule_inlineKeyboard_tue);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "1️⃣ среда":
                    try
                    {
                        var schedule_inlineKeyboard_wed = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "first_wednesday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Первая среда</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_wed);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "1️⃣ четверг":
                    try
                    {
                        var schedule_inlineKeyboard_thu = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "first_thursday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Первый четверг</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_thu);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "1️⃣ пятница":
                    try
                    {
                        var schedule_inlineKeyboard_fri = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "first_friday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Первая пятница</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_fri);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "1️⃣ суббота":
                    try
                    {
                        var schedule_inlineKeyboard_sat = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "first_saturday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Первая суббота</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_sat);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "2️⃣ понедельник":
                    try
                    {
                        var schedule_inlineKeyboard_mon = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "second_monday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId,"<b>Второй понедельник</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_mon);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "2️⃣ вторник":
                    try
                    {
                        var schedule_inlineKeyboard_tue = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "second_tuesday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Второй вторник</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_tue);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "2️⃣ среда":
                    try
                    {
                        var schedule_inlineKeyboard_wed = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "second_wednesday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Вторая среда</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_wed);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "2️⃣ четверг":
                    try
                    {
                        var schedule_inlineKeyboard_thu = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "second_thursday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Второй четверг</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_thu);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "2️⃣ пятница":
                    try
                    {
                        var schedule_inlineKeyboard_fri = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "second_friday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Вторая пятница</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_fri);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "2️⃣ суббота":
                    try
                    {
                        var schedule_inlineKeyboard_sat = new InlineKeyboardMarkup(new[]
                     {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), "second_saturday");
                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "<b>Вторая суббота</b>\n\n" + answer, ParseMode.Html, false, schedule_inlineKeyboard_sat);
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "Сегодня":
                    try
                    {
                        var easy_inlineKeyboard_today = new InlineKeyboardMarkup(new[]
                        {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("Сегодня")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("Завтра")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_schedule)
                         }
                    });
                        string answer = return_schedule_in_day(select_group_id_by_user(name), select_workday_today_of_college());

                        try
                        {
                            List<int> y = return_y_with_group_names(select_name_table_today_changes(), select_tag(select_group_id_by_user(name)));
                            if (y.Count > 0)
                            {
                                answer = answer + "<b>Изменения </b>\n" + return_schedule_changes(select_name_table_today_changes(), select_tag(select_group_id_by_user(name)));
                            }
                            else answer = answer + "<b>Изменений нет</b>";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "_GG_");
                        }

                        if (select_workday_today_of_college() == "first_sunday" || select_workday_today_of_college() == "second_sunday")
                        {
                            answer = "<b>Воскресенье</b>\n🤩 хороших выходных ";
                            await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId,answer, ParseMode.Html, false, easy_inlineKeyboard_today);
                        }
                        else
                        { 
                            await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, return_part_answer(select_workday_today_of_college()) + answer, ParseMode.Html, false, easy_inlineKeyboard_today);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "Завтра":
                    try
                    {
                        var easy_inlineKeyboard_tomorrow = new InlineKeyboardMarkup(new[]
                        {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("Сегодня")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("Завтра")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_schedule)
                         }
                    });
                        
                        string answer = return_schedule_in_day(select_group_id_by_user(name), select_workday_tomorrow_of_college());

    
                        try
                        {
                            List<int> y = return_y_with_group_names(select_name_table_tomorrow_of_college(), select_tag(select_group_id_by_user(name)));
                            if (y.Count > 0)
                            {
                                answer = answer + "<b>Изменения </b>\n" + return_schedule_changes(select_name_table_tomorrow_of_college(), select_tag(select_group_id_by_user(name)));
                            }
                            else answer = answer + "<b>Изменений нет</b>";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "_GG_");
                        }

                        if (select_workday_tomorrow_of_college() == "first_sunday" || select_workday_tomorrow_of_college() == "second_sunday")
                        {
                            answer = "<b>Воскресенье</b>\n🤩 хороших выходных ";
                            await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId,answer, ParseMode.Html, false, easy_inlineKeyboard_tomorrow);
                        }
                        else
                        {
                            await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, return_part_answer(select_workday_tomorrow_of_college()) + answer, ParseMode.Html, false, easy_inlineKeyboard_tomorrow);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message + "_GG_"); }
                    break;

                case "♥️":
                    var easy_inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("Сегодня")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("Завтра")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_schedule)
                         }
                    });

                    await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "✈️ Просто тапни на нужное тебе📆", ParseMode.Html, false, easy_inlineKeyboard);

                    break;

                case "♠️":
                    var schedule_days_inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }
                    });

                    await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "✈️ Тапни на нужный день 📆 ", ParseMode.Html, false, schedule_days_inlineKeyboard);

                    break;

                default:
                    //await Bot.SendTextMessageAsync(cid_own, "chat_id: " + cid_own + " name: " + name + " course: " + course + " tag: " + callbackQuery.Data +" group_id: "+ select_group_id(callbackQuery.Data).ToString());

                    register_user(cid_own.ToString(),name,course,callbackQuery.Data);

                    var schedule_inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });

                    var easy_inlineKeyboard_start = new InlineKeyboardMarkup(new[]
                    {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("Сегодня")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("Завтра")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_schedule)
                         }
                    });

                    try
                    {
                        //await Bot.SendTextMessageAsync(cid_own,"✈️ Тапни на нужный день 📆 ",replyMarkup: schedule_inlineKeyboard);

                        await Bot.EditMessageTextAsync(cid_own, callbackQueryEventArgs.CallbackQuery.Message.MessageId, "✈️ Тапни на нужный день 📆 ", ParseMode.Html, false, easy_inlineKeyboard_start);
                    }
                    catch
                    {
                        //Process.Start(path);
                        //Environment.Exit(0);
                    }
                    

                    break;
            }

            Console.WriteLine(name + " " + callbackQuery.Data);

        }

        public static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Text)
            {
                #region var txt 
                var txt = e.Message.Text;
                #endregion


                #region Console
                var cid = e.Message.Chat.Id;                                            //чат id
                name = e.Message.From.FirstName + " " + e.Message.From.LastName;    //имя
                var uid = e.Message.From.Id;                                            //юзер id
                msg_id = e.Message.MessageId;
                Console.WriteLine("{0} - {1} : {2} ", uid, name, txt); //вывод в консоль
                #endregion

                

                if (txt == "/start") //регистрация юзера в бд если такого нет
                {
                    cid_own = cid;

                    var start_inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1"),
                             InlineKeyboardButton.WithCallbackData("2"),
                             InlineKeyboardButton.WithCallbackData("3"),
                             InlineKeyboardButton.WithCallbackData("4"),
                             InlineKeyboardButton.WithCallbackData("5")
                         }
                    });

                    try
                    {
                        await Bot.SendTextMessageAsync(
                        e.Message.Chat.Id,
                        "✈️ Тапни на свой курс и выбери группу ",
                        replyMarkup: start_inlineKeyboard);
                    }
                    catch
                    {
                        //Process.Start(path);
                        //Environment.Exit(0);
                    }
                }
                else if(txt.StartsWith("Группа", false, CultureInfo.InvariantCulture) == true)
                {
                    try
                    {
                        string text = txt.Substring(7, txt.Length - 7);
                        string group = text.Split()[0];
                        string[] words = text.Split(new char[] { ' ' });
                        string message = "";

                        bool first = false;
                        foreach (string s in words)
                        {
                            if (first == false)
                            {
                                first = true;
                                continue;
                            }
                            message = message + ' ' + s;
                        }


                        if(select_group_id(group) != 0)
                        {
                            List<int> chat_ids = select_users_chat_id_by_group_id(select_group_id(group));

                            string users = "";
                            foreach(int chat_id in chat_ids)
                            {
                                users = users + select_username_by_chat_id(chat_id) + "\n";
                            }

                            if(message == "")
                            {
                                await Bot.SendTextMessageAsync(e.Message.Chat.Id, "<b>Группа :</b> " + group + "\n<b>Юзеры : </b>\n" + users, ParseMode.Html);
                            }
                            else
                            {
                                var easy_inlineKeyboard = new InlineKeyboardMarkup(new[]
                                {
                                    new []
                                    {
                                        InlineKeyboardButton.WithCallbackData("Сегодня")

                                    },new []
                                    {
                                        InlineKeyboardButton.WithCallbackData("Завтра")
                                    },new []
                                    {
                                         InlineKeyboardButton.WithCallbackData("🥶🔥🌏🍔🇺🇦")
                                    }
                                 });
                                foreach (int chat_id in chat_ids)
                                {
                                    Thread.Sleep(500);
                                    Console.WriteLine(select_username_by_chat_id(chat_id));
                                    await Bot.SendTextMessageAsync(chat_id, message, ParseMode.Html, replyMarkup: easy_inlineKeyboard);
                                }
                                await Bot.SendTextMessageAsync(e.Message.Chat.Id, "<b>Группа :</b> " + group + "\n<b>Сообщение :</b> " + message + "\n" + "<b>Юзеры : </b>\n" + users, ParseMode.Html);
                            }
                        }
                        else
                        { 
                            await Bot.SendTextMessageAsync(e.Message.Chat.Id, "Группы нет в базе данных" + message, ParseMode.Html);
                        }
                           
                        

                    }
                    catch
                    {
                        Console.WriteLine("Oops!");
                    }
                }
                else
                {
                    cid_own = cid;

                    var schedule_inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ понедельник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ понедельник")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ вторник"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ вторник")

                         }
                         ,new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ среда"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ среда")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ четверг"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ четверг")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ пятница"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ пятница")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("1️⃣ суббота"),
                             InlineKeyboardButton.WithCallbackData("2️⃣ суббота")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_easy)
                         }


                    });

                    var easy_inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                         new []
                         {
                             InlineKeyboardButton.WithCallbackData("Сегодня")

                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData("Завтра")
                         },new []
                         {
                             InlineKeyboardButton.WithCallbackData(smile_schedule)
                         }
                    });

                    try
                    {
                        await Bot.SendTextMessageAsync(
                        e.Message.Chat.Id,
                        "✈️ Тапни на нужный день 📆 ",
                        replyMarkup: easy_inlineKeyboard);
                    }
                    catch
                    {
                        //Process.Start(path);
                        //Environment.Exit(0);
                    }




                }


            }

        }
    }
}
