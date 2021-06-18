using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotLauncherBeta
{
    class BotWorker : IDisposable
    {
        private string Token;
        public TelegramBotClient client;
        string[] settingsList;
        ExcelBridge excelBridge = null;
        SqlBridge sqlBridge = null;
        MainForm form;
        public BotWorker(string[] SettingsList, ExcelBridge BridgeExcel = null, SqlBridge BridgeSql = null)
        {
            /*инициализация настроек внутри самого бота*/
            settingsList = new string[SettingsList.Length];
            SettingsList.CopyTo(settingsList, 0);

            Token = settingsList[(int)SettingsTxt.Indexes.token];
            if (settingsList[(int)SettingsTxt.Indexes.remoteinfo] == "true")
                sqlBridge = new SqlBridge(settingsList);
            else
                excelBridge = new ExcelBridge(settingsList);

            client = new TelegramBotClient(Token);
            client.OnMessage += OnMessageHandler;
            client.StartReceiving();
            Console.WriteLine("А бот работает)\n");
            Console.ReadLine();
        }

        async public void MessageSender(string text, string ClientID)
        {
            if(client.IsReceiving == true)
            {
                long intID = Convert.ToInt64(ClientID);
                SaveAnswer(null, text, ClientID);
                try
                {
                    await client.SendTextMessageAsync(intID, text);
                }
                catch
                {
                    SaveAnswer(null, "<Чат с данным человеком не существует>", ClientID);
                }
            }
        }
        async private void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null) //если сообщение пришло не пустое
            {
                SaveStory(msg);// сохраняем полученное сообщение
                if (msg.Text.Length > 99)
                {
                    SaveAnswer(msg, TMas.BotText[8]);
                    await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[8]);
                    return;
                }
                if (msg.Text == TMas.mBts[0] || msg.Text == TMas.mBtsDw[0]) //если нажата кнопка контакты
                {
                    BotLogicContacts(msg);
                    return;
                }
                if (msg.Text == TMas.mBts[1] || msg.Text == TMas.mBtsDw[1]) //если нажата кнопка хочу домик
                {
                    BotLogic(msg, 0, 0, 0, 8, true);
                    return;
                }
                if (msg.Text == TMas.mBts[2] || msg.Text == TMas.mBtsDw[2]) //если нажата кнопка *тык*
                {
                    Random rnd = new Random();
                    string answer = TMas.RndText[(rnd.Next() % (TMas.RndText.Length))];
                    SaveAnswer(msg, answer);
                    await client.SendTextMessageAsync(msg.Chat.Id, answer);
                    return;
                }

                int i;
                bool month = false; //это проверка на присланный месяц
                for (i = 0; (i < 12 && month == false); i++)
                {
                    if (msg.Text == TMas.AskMon[i])
                        month = true;
                }
                if (month == true)
                {
                    BotLogic(msg, 0, 1, 1, 0, false);
                    return;
                }

                /*здесь проверяются сообщения на наличие чисел*/
                long Num = -1;
                string[] arrnum = msg.Text.Split(new char[] { ' ', ',' });
                for (i = 0; i < arrnum.Length; i++)
                {
                    try
                    {
                        Num = Convert.ToInt64(arrnum[i]);
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    catch (OverflowException)
                    {
                        continue;
                    }
                }/*смотрим, извлекли ли мы из сообщения хоть что-нибудь вроде числа*/
                if (Num != -1)
                {
                    if (Num > 0 && Num < 32)
                    {
                        BotLogic(msg, 1, 2, 2, 1, false);
                    }

                    if (Num > 1000000)
                    {
                        BotLogic(msg, 4, 5, 5, 3, false);
                        FileCleaner(msg);
                    }
                }

                if (msg.Text == TMas.AskCall[0]) //это проверка на наличие ответа "да" или "нет"
                {
                    BotLogic(msg, 3, 4, 4, -1, false);
                    return;
                }

                if (msg.Text == TMas.AskCall[1]) //это проверка на наличие ответа "да" или "нет"
                {
                    BotLogic(msg, 3, 5, 6, -1, false);
                    Console.WriteLine($"Пользователь {msg.From.Id} не захотел сообщать номер телефона\n");
                    FileCleaner(msg);
                    return;
                }

                bool name = true; //проверка на получение имени
                for (i = 0; (i < TMas.mBts.Length && name == true); i++)
                {
                    if (msg.Text == TMas.mBts[i])
                        name = false;
                }
                for (i = 0; (i < TMas.mBtsDw.Length && name == true); i++)
                {
                    if (msg.Text == TMas.mBtsDw[i])
                        name = false;
                }
                for (i = 0; i < TMas.PosGreetings.Length && name == true; i++)
                {
                    if (msg.Text == TMas.PosGreetings[i])
                        name = false;
                }
                for (i = 0; i < TMas.PosGoodbyes.Length && name == true; i++)
                {
                    if (msg.Text == TMas.PosGoodbyes[i])
                        name = false;
                }
                for (i = 0; i < TMas.AskCall.Length && name == true; i++)
                {
                    if (msg.Text == TMas.AskCall[i])
                        name = false;
                }
                if (name == true)
                {
                    foreach (char sym in msg.Text)
                    {
                        if (Char.IsDigit(sym))
                        {
                            name = false;
                            break;
                        }
                    }
                    if (name == true)
                    {
                        BotLogic(msg, 2, 3, 3, 2, false);
                        return;
                    }
                }

                for (i = 0; i < TMas.PosGreetings.Length; i++) //это проверка на приветствие
                    if (msg.Text.Contains(TMas.PosGreetings[i]))
                    {
                        SaveAnswer(msg, TMas.BotAnswers[2]);
                        await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotAnswers[2], replyMarkup: GetButtonsMenu());
                        return;
                    }
                for (i = 0; i < TMas.PosGoodbyes.Length; i++)
                    if (msg.Text.Contains(TMas.PosGoodbyes[i])) //это проверка на прощание
                    {
                        SaveAnswer(msg, TMas.BotAnswers[3]);
                        await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotAnswers[3], replyMarkup: DelButtons());
                        return;
                    }
            }
        }
        async private void BotLogic(Telegram.Bot.Types.Message msg, int IndexRead, int IndexWrite, int answer, int info, bool FirstWrite)
        {
            string PathToTempFiles = Environment.CurrentDirectory + "\\tempfiles";
            string FileNameDef = "Client";
            int Count = new DirectoryInfo(PathToTempFiles).GetFiles().Length;
            int Result;
            if (FirstWrite == true)
            {
                Result = MatcherID(PathToTempFiles, FileNameDef, Count, (msg.From.Id.ToString()), true);

                if (Result == -1)
                {
                    Result = Count; //чтобы номер temp файла был больше количества файлов, которое есть в папке
                    StartRecorClients(msg);
                    using (var file_io = new StreamWriter(PathToTempFiles + "\\" + FileNameDef + Result.ToString() + ".txt", false))
                    {
                        file_io.Write($"{msg.From.Id}{TMas.InfoIndex[IndexWrite]}");
                    }
                    Console.WriteLine($"Первые данные о клиенте {msg.From.Id} собраны в файле RecorClients.xlsx\n");
                }
                else
                {
                    Console.WriteLine($"Клиент {msg.From.Id} уже обслуживается в данный момент\n");
                    SaveAnswer(msg, TMas.BotText[7]);
                    await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[7]);
                    Result = -1;
                }
            }
            else
            {
                Result = MatcherID(PathToTempFiles, FileNameDef, Count, (msg.From.Id.ToString() + TMas.InfoIndex[IndexRead]), true);
                if (Result != -1)
                {
                    if (info != -1)
                        NextInfoClients(msg, info);
                    using (var file_io = new StreamWriter(PathToTempFiles + "\\" + FileNameDef + Result.ToString() + ".txt", false))
                    {
                        file_io.Write($"{msg.From.Id}{TMas.InfoIndex[IndexWrite]}");
                    }
                    if (info == -1)
                        info = 7;
                    Console.WriteLine($"Пользователь {msg.From.Id} сообщил {TMas.InfoMassive[info]}\n");
                }
            }

            if (Result != -1)
            {
                SaveAnswer(msg, TMas.BotText[answer]);
                switch (answer)
                {
                    case (0): await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[answer], replyMarkup: GetButtonsAskMon()); break;
                    case (1): await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[answer], replyMarkup: DelButtons()); break;
                    case (2): await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[answer], replyMarkup: DelButtons()); break;
                    case (3): await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[answer], replyMarkup: GetButtonsAskCall()); break;
                    case (4): await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[answer], replyMarkup: DelButtons()); break;
                    case (5): await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[answer], replyMarkup: GetButtonsMenu()); break;
                    case (6): await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotText[answer], replyMarkup: GetButtonsMenu()); break;
                }
            }
        }
        async private void BotLogicContacts(Telegram.Bot.Types.Message msg)
        {
            SavePossClients(msg);
            Console.WriteLine($"Пользователь {msg.From.Id} записан в файл как потенциальный клиент\n");
            SaveAnswer(msg, TMas.BotAnswers[0]);
            await client.SendTextMessageAsync(msg.Chat.Id, TMas.BotAnswers[0], replyMarkup: GetButtonsMenu());
        }

        private void SaveStory(Telegram.Bot.Types.Message msg)
        {
            if (sqlBridge != null) { sqlBridge.RecStory(msg); return; }
            if (excelBridge != null) { excelBridge.RecStory(msg); return; }
        }
        private void SaveAnswer(Telegram.Bot.Types.Message msg, string text, string ClientID = null)
        {
            if (sqlBridge != null) { sqlBridge.RecStoryAnswer(msg, text, ClientID); return; }
            if (excelBridge != null) { excelBridge.RecStoryAnswer(msg, text, ClientID); return; }
        }
        private void SavePossClients(Telegram.Bot.Types.Message msg)
        {
            if (sqlBridge != null) { sqlBridge.InfoPossClients(msg); return; }
            if (excelBridge != null) { excelBridge.InfoPossClients(msg); return; }
        }
        private void StartRecorClients(Telegram.Bot.Types.Message msg)
        {
            if (sqlBridge != null) { sqlBridge.StartInfoRecorClients(msg); return; }
            if (excelBridge != null) { excelBridge.StartInfoRecorClients(msg); return; }
        }
        private void NextInfoClients(Telegram.Bot.Types.Message msg, int ColNameIndex)
        {
            if (sqlBridge != null) { sqlBridge.SecondInfoRecorClients(msg, ColNameIndex); return; }
            if (excelBridge != null) { excelBridge.SecondInfoRecorClients(msg, ColNameIndex); return; }
        }
        private void FileCleaner(Telegram.Bot.Types.Message msg)
        {
            string PathToTempFiles = Environment.CurrentDirectory + "\\tempfiles";
            string FileNameDef = "Client";
            int Count = new DirectoryInfo(PathToTempFiles).GetFiles().Length;
            int Result = MatcherID(PathToTempFiles, FileNameDef, Count, (msg.From.Id.ToString() + TMas.InfoIndex[5]), true);
            if (Result != -1)
            {
                string PathName = PathToTempFiles + "\\" + FileNameDef;
                File.Delete(PathName + Result.ToString() + ".txt");
                Count--;

                for (int i = 0; i < Count - Result; i++)
                {
                    if (File.Exists(PathName + (Result + i + 1).ToString() + ".txt"))
                        File.Move(PathName + (Result + i + 1).ToString() + ".txt", PathName + (Result + i).ToString() + ".txt");
                }
                Console.WriteLine($"Временный файл клиента {msg.From.Id} успешно удален");
            }
        }
        private int MatcherID(string PathToTempFiles, string FileNameDef, int Count, string SearchText, bool SubString)
        {/*проверяет, есть ли среди файлов в папке tempfile какой-нибудь, который содержит ID пользователя приславшего сообщение
        (+ еще что-нибудь), . Если возвращает число, равное -1, то файла с требуемым текстом не существует*/
            string TempFileName;
            int i, MatchID = -1;

            for (i = 0; (i < Count && MatchID == -1); i++)
            {
                TempFileName = FileNameDef + i.ToString() + ".txt";
                if (File.Exists(PathToTempFiles + "\\" + TempFileName))
                {
                    using (var file_view = new StreamReader(PathToTempFiles + "\\" + TempFileName))
                    {
                        if (SubString == true)
                        {
                            if (file_view.ReadToEnd().Contains(SearchText))
                                MatchID = i;
                        }
                        else
                        {
                            if (SearchText == file_view.ReadToEnd())
                                MatchID = i;
                        }
                    }
                }
            }
            return MatchID;
        }

        private IReplyMarkup GetButtonsMenu()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = TMas.mBts[0] }, new KeyboardButton {Text = TMas.mBts[1] } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = TMas.mBts[2] } },
                }
            };
        }

        private IReplyMarkup GetButtonsAskCall()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = TMas.AskCall[0] } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = TMas.AskCall[1] } },
                }
            };
        }

        private IReplyMarkup GetButtonsAskMon()
        {
            int mon1 = DateTime.Now.Month - 1;
            int mon2 = (mon1 + 1 > 12) ? (mon1 + 1 - 12) : (mon1 + 1);
            int mon3 = (mon1 + 2 > 12) ? (mon1 + 2 - 12) : (mon1 + 2);
            int mon4 = (mon1 + 3 > 12) ? (mon1 + 3 - 12) : (mon1 + 3);
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = TMas.AskMon[mon1] }, new KeyboardButton { Text = TMas.AskMon[mon2] } },
                    new List<KeyboardButton> { new KeyboardButton { Text = TMas.AskMon[mon3] }, new KeyboardButton { Text = TMas.AskMon[mon4] } },
                }
            };
        }

        private IReplyMarkup DelButtons()
        {
            return new ReplyKeyboardRemove { };
        }

        public void Dispose()
        {
            client.OnMessage -= OnMessageHandler;
            client.StopReceiving();
        }
    }
}
