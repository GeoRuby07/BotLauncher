using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotLauncherBeta
{
    enum TabNames
    {
        RecorClients,
        PossClients,
    }
    public partial class MainForm : Form
    {
        string fileSettings = Environment.CurrentDirectory + "\\BotSettings.txt";
        Color brownColor = Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(115)))), ((int)(((byte)(106)))));
        int currentTabName;
        string[] SettingsList;
        BotWorker bot;
        ExcelBridge excelBridge;
        SqlBridge sqlBridge;
        Point lastPosition;
        public MainForm()
        {
            InitializeComponent();
            if (File.Exists(fileSettings))
            {
                ReloadSettings();
                currentTabName = (int)TabNames.RecorClients;

                IdTable.DataSource = IdTabGenerator();
                if (IdTable.DataSource != null)
                {
                    IdTable.Columns[0].Width = 115;
                    IdTable.Columns[1].Width = 115;
                }
            }
            else
            {
                MessageBox.Show("Отсутствует файл настроек!!! " +
                    "Приложение не будет работать нормально");
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (playButton.ImageIndex == 0)
            {
                playButton.ImageIndex = 1;
                statPictSleep.Visible = true;
                statPictActiv.Visible = false;
                SendText.ReadOnly = true;
                statusInfo.Text = "Выключен";
                StopBot();
            }

            else
            {
                playButton.ImageIndex = 0;
                statPictActiv.Visible = true;
                statPictSleep.Visible = false;
                SendText.ReadOnly = false;
                statusInfo.Text = "Активен";
                StartBot();
            }
        }

        private void UpPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPosition.X;
                this.Top += e.Y - lastPosition.Y;
            }
        }

        private void UpPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPosition = new Point(e.X, e.Y);
        }

        private void playButton_MouseEnter(object sender, EventArgs e)
        {
            if (playButton.ImageIndex == 1)
                InfoBox.Text = "Запустить бота";
            else InfoBox.Text = "Остановить бота";
        }

        private void playButton_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void settingsButton_MouseEnter(object sender, EventArgs e)
        {
            InfoBox.Text = "Открыть настройки";
        }

        private void settingsButton_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            InfoBox.Text = "Закрыть программу";
        }

        private void exitButton_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void reloadButton_MouseEnter(object sender, EventArgs e)
        {
            InfoBox.Text = "Обновить список клиентов";
        }

        private void reloadButton_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void IdInfo_MouseEnter(object sender, EventArgs e)
        {
            InfoBox.Text = "ID клиента. Вы можете ввести вручную это значение";
        }

        private void IdInfo_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void LoadButton_MouseEnter(object sender, EventArgs e)
        {
            InfoBox.Text = "Загрузить историю диалога с клиентом с данным ID";
        }

        private void LoadButton_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void SendText_MouseEnter(object sender, EventArgs e)
        {
            if (playButton.ImageIndex == 0 && bot != null)
                InfoBox.Text = "Сообщение, которое вы хотите отправить клиенту";
            else
            {
                InfoBox.Text = "Невозможно отправить сообщение, когда бот выключен";
                TextNotify();
            }
        }

        private void SendText_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void buttonSend_MouseEnter(object sender, EventArgs e)
        {
            InfoBox.Text = "Отправить введенное сообщение";
        }
        private void buttonSend_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }
        private void SelectAllButton_MouseEnter(object sender, EventArgs e)
        {
            InfoBox.Text = "Выделить всех клиентов из списка";
        }
        private void SelectAllButton_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            IdTable.SelectAll();
        }
        private void ClientsButton_MouseEnter(object sender, EventArgs e)
        {
            if (currentTabName == (int)TabNames.RecorClients)
                InfoBox.Text = "Переключиться на просмотр возможных клиентов";
            else InfoBox.Text = "Переключиться на просмотр уже записанных клиентов";
        }
        private void ClientsButton_MouseLeave(object sender, EventArgs e) { InfoBox.Text = ""; }

        private void IdInfo_TextChanged(object sender, EventArgs e)
        {
            LoadButton.Enabled = (IdInfo.Text == "") ? (false) : (true);
        }

        private void SendText_TextChanged(object sender, EventArgs e)
        {
            buttonSend.Enabled = (SendText.Text == "" || playButton.ImageIndex == 1) ? (false) : (true);
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            IdTable.DataSource = IdTabGenerator();
            if (IdTable.DataSource != null)
            {
                IdTable.Columns[0].Width = 115;
                IdTable.Columns[1].Width = 115;
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (IdInfo.Text != "")
            {
                bool symDetect = false;
                bool sepDetect = false;
                foreach (char sym in IdInfo.Text)
                {
                    if (Char.Equals(sym, ','))
                    {
                        sepDetect = true;
                        break;
                    }
                    if (!Char.IsDigit(sym))
                    {
                        symDetect = true;
                        break;
                    }
                }
                if (symDetect == false)
                {
                    if(sepDetect == false)
                    {
                        StoryTable.DataSource = StoryGenerator(IdInfo.Text);
                        if (StoryTable.DataSource != null)
                        {
                            StoryTable.Columns[0].Width = 60;
                            StoryTable.Columns[1].Width = 60;
                            StoryTable.Columns[2].Width = 220;
                        }
                        else
                        {
                            InfoBox.Text = "Такой таблицы/файла не существует";
                            TextNotify();
                        }
                    }
                    else
                    {
                        InfoBox.Text = "Невозможно отобразить историю сообщений нескольких клиентов сразу";
                        TextNotify();
                    }
                }
                else
                {
                    InfoBox.Text = "Неверно указан ID клиента";
                    TextNotify();
                }
            }
        }

        private void IdTable_SelectionChanged(object sender, EventArgs e)
        {
            if (IdTable.SelectedCells.Count == 1)
            {
                try
                {
                    IdInfo.Text = IdTable.SelectedCells[0].Value.ToString();
                }
                catch
                {

                }
            }
            else
            {
                bool symDetect;
                string tempStr;
                string tempSum = "";
                for(int i = 0; i < IdTable.SelectedCells.Count; i++)
                {
                    symDetect = false;
                    try
                    {
                        tempStr = IdTable.SelectedCells[i].Value.ToString();
                        if (tempStr != "")
                        {
                            foreach (char sym in tempStr)
                            {
                                if (!Char.IsDigit(sym))
                                {
                                    symDetect = true;
                                    break;
                                }
                            }
                            if (symDetect == false)
                            {
                                tempSum += tempStr;
                                tempSum += ",";
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                IdInfo.Text = tempSum;
            }
        }
        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(this);
            settings.Show();
            this.Hide();
        }
        private void ClientsButton_Click(object sender, EventArgs e)
        {
            if (currentTabName == (int)TabNames.RecorClients)
            {
                currentTabName = (int)TabNames.PossClients;
                ClientsButton.Text = "Возможные клиенты";
            }
            else
            {
                currentTabName = (int)TabNames.RecorClients;
                ClientsButton.Text = "Клиенты";
            }
            ClientsButton_MouseEnter(sender, e);
            reloadButton_Click(sender, e);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(IdInfo.Text != "")
            {
                foreach(char sym in IdInfo.Text)
                    if(!Char.IsDigit(sym) && sym != ',')
                    {
                        InfoBox.Text = "Некорректный ID клиента";
                        TextNotify();
                        return;
                    }
                if (playButton.ImageIndex == 0 && bot != null)
                {
                    string[] tempArray = IdInfo.Text.Split(','); //создание списка с ID клиентов
                    if (tempArray.Length == 1) //если элемент всего один
                    {
                        bot.MessageSender(SendText.Text, IdInfo.Text);
                        LoadButton_Click(sender, e); //в else это не имеет смысла ставить
                        StoryTable.ClearSelection();
                        int maxRow = StoryTable.Rows.Count;
                        StoryTable.Rows[maxRow - 1].Selected = true;
                        //Console.WriteLine("условие сработало");
                    }
                    else
                    {
                        List<string> unique = new List<string>(); //создание списка с уникальными ID клиентов
                        unique.Add(tempArray[0]);
                        for (int i = 0; i < tempArray.Length; i++)
                        {
                            if (!unique.Contains(tempArray[i]))
                                unique.Add(tempArray[i]);
                        }
                        SenderMuch(unique);
                    }
                }
                else
                {
                    InfoBox.Text = "Невозможно отправить сообщение, когда бот выключен";
                    TextNotify();
                }
            }
        }

        /*методы класса для взаимодействия с ботом и файлами*/
        public void ReloadSettings()
        {
            SettingsTxt st = new SettingsTxt();
            SettingsList = new string[st.ST.Length];
            using (var fileRead = new StreamReader(fileSettings))
            {
                for (int i = 0; i < st.ST.Length; i++)
                    SettingsList[i] = fileRead.ReadLine().Split('=')[1];
            }

            /*загрузка листа ID клиентов*/
            if (SettingsList[(int)SettingsTxt.Indexes.remoteinfo] == "true")
                sqlBridge = new SqlBridge(SettingsList);
            else
                excelBridge = new ExcelBridge(SettingsList);

            /*просмотр настроек, включать ли бота*/
            if (SettingsList[1] == "true")
                playButton.ImageIndex = 0;
            else playButton.ImageIndex = 1;

            /*запуск бота*/
            if (bot != null)
                bot.Dispose();
            bot = new BotWorker(SettingsList, excelBridge, sqlBridge);
            if (playButton.ImageIndex == 0)
            {
                statPictActiv.Visible = true;
                statPictSleep.Visible = false;
                SendText.ReadOnly = false;
                statusInfo.Text = "Активен";
            }
            else
            {
                StopBot();
                statPictSleep.Visible = true;
                statPictActiv.Visible = false;
                SendText.ReadOnly = true;
                statusInfo.Text = "Выключен";
            }
        }

        private DataTable IdTabGenerator()
        {
            DataTable tempTable;
            if (SettingsList[(int)SettingsTxt.Indexes.remoteinfo] == "true")
            {
                tempTable = sqlBridge.IdListCreator(currentTabName);
                if (tempTable == null)
                {
                    InfoBox.Text = "Невозможно загрузить таблицы клиентов! " +
                    "Проверьте подключение к серверу";
                    TextNotify();
                    return null;
                }
            }
            else
            {
                tempTable = excelBridge.IdListCreator(currentTabName);
                if (tempTable == null)
                {
                    InfoBox.Text = "Невозможно загрузить таблицы клиентов! " +
                    "Проверьте расположение папок и уровень доступа к ним";
                    TextNotify();
                    return null;
                }
            }
            return tempTable;
        }

        private DataTable StoryGenerator(string UserId)
        {
            DataTable tempTable;
            if (SettingsList[(int)SettingsTxt.Indexes.remoteinfo] == "true")
                tempTable = sqlBridge.StoryCreator(UserId);
            else
                tempTable = excelBridge.StoryCreator(UserId);
            return tempTable;
        }

        private void StartBot()
        {
            if (bot != null)
                bot.client.StartReceiving();
        }

        private void StopBot()
        {
            if (bot != null)
                bot.client.StopReceiving();
        }

        private void TextNotify()
        {
            Task.Factory.StartNew(async () =>
            {
                InfoBox.ForeColor = Color.SaddleBrown;
                await Task.Delay(2000);
                InfoBox.ForeColor = brownColor;
            });
        }

        async private void SenderMuch(List<string> messageList)
        {
            string text = SendText.Text;
            await Task.Factory.StartNew(async () =>
            {
                for (int i = 0; i < messageList.Count; i++)
                {
                    await Task.Delay(5000);
                    if (messageList[i] != "")
                        bot.MessageSender(text, messageList[i]);
                }
            });
        }
    }
}
