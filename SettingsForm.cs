using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BotLauncherBeta
{
    public partial class SettingsForm : Form
    {
        enum Modes : int
        {
            BoolMode = 1,
            TextMode = 2,
        }

        MainForm mainForm;
        Point lastPosition;
        string fileSettings = Environment.CurrentDirectory + "\\BotSettings.txt";
        string fileTemp = Environment.CurrentDirectory + "\\TempSettings.txt";
        public SettingsForm(MainForm returnForm)
        {
            InitializeComponent();
            mainForm = returnForm;
            this.Left = mainForm.Left;
            this.Top = mainForm.Top;

            if (!File.Exists(fileSettings))
            {
                MessageBox.Show("Отсутствует файл настроек!!! " +
                    "Приложение не будет работать нормально");
                var txt = new SettingsTxt();
                checkStartBot.Checked = (txt.DFS[1] == "true") ? (true) : (false);
                if (txt.DFS[2] == "true") { DataUseBox1.Checked = !(DataUseBox2.Checked = true); }
                else { DataUseBox1.Checked = !(DataUseBox2.Checked = false); }
            }
            else
            {
                SaveSettings(fileSettings, fileTemp);
                Initialize();
            }

            /*инициализация SQL и Folder групп*/
            FolderGroup.Enabled = (DataUseBox1.Checked == true) ? (true) : (false);
            SQLGroup.Enabled = (DataUseBox2.Checked == true) ? (true) : (false);
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            File.Delete(fileTemp);
            mainForm.Left = this.Left;
            mainForm.Top = this.Top;
            mainForm.Show();
            this.Close();
        }
        private void UpPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPosition = new Point(e.X, e.Y);
        }
        private void UpPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPosition.X;
                this.Top += e.Y - lastPosition.Y;
            }
        }


        /*подсказки на правой панели*/
        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Вернуться на главный экран";
        }
        private void exitButton_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void TokenBotInfo_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Текущий токен телеграм-бота";
        }
        private void TokenBotInfo_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void DataUseBox1_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "На данном компьютере создаются (или редактируются)" +
                " файлы с Excel-таблицами: "+
                "Файл RecorClients для записи обратившихся клиентов, и "+
                "файл PossClients для записи потенциальных клиентов";
        }
        private void DataUseBox1_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void DataUseBox2_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "На удаленном сервере в базе данных Clients " +
            "создаются (или редактируются) две таблицы " +
            "(RecorClients и PossClients) для записи клиентов";
        }
        private void DataUseBox2_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void RCInfo_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Путь хранения файла RecorClients.xlsx";
        }
        private void RCInfo_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void PCInfo_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Путь хранения файла PossClients.xlsx";
        }
        private void PCInfo_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void IDsInfo_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Путь хранения Excel-файлов, хранящих историю сообщений. " +
                "Имя каждого файла - это ID клиента";
        }
        private void IDsInfo_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void IDsButton_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Изменить директорию хранения файлов с " +
                "историями сообщений пользователей";
        }
        private void IDsButton_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void PCButton_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Изменить директорию хранения файла с таблицей " +
                "возможных клиентов";
        }
        private void PCButton_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void RCButton_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Изменить директорию хранения файла с таблицей " +
                "обратившихся к боту клиентов";
        }
        private void RCButton_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }
        private void ServerOk_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Применить изменения";
        }
        private void ServerOk_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void PortOk_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Применить изменения";
        }
        private void PortOk_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void UserOk_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Применить изменения";
        }

        private void UserOk_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }
        private void PassOk_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Применить изменения";
        }
        private void PassOk_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }
        private void DBdefOk_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Применить изменения";
        }

        private void DBdefOk_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void DBnameOk_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Применить изменения";
        }

        private void DBnameOk_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void DBdefInfo_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Здесь необходимо указать базу данных по умолчанию (например, mysql), " +
                "к которой программа будет пытаться подключиться, если не существует БД \"DB name\"";
        }

        private void DBdefInfo_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        private void DBnameInfo_MouseEnter(object sender, EventArgs e)
        {
            this.InfoBox.Text = "Имя базы данных, в которую записываются все данные о клиентах, " +
                "а так же истории сообщений с клиентами. По умолчанию лучше указывать clients";
        }
        private void DBnameInfo_MouseLeave(object sender, EventArgs e) { this.InfoBox.Text = ""; }

        /*хэндлеры галочек (включение/выключение) */
        private void ServerInfo_TextChanged(object sender, EventArgs e)
        {
            this.ServerOk.Enabled = (this.ServerInfo.Text != "") ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
        }

        private void PortInfo_TextChanged(object sender, EventArgs e)
        {
            this.PortOk.Enabled = (this.PortInfo.Text != "") ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
        }

        private void UserInfo_TextChanged(object sender, EventArgs e)
        {
            this.UserOk.Enabled = (this.UserInfo.Text != "") ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
        }

        private void PassInfo_TextChanged(object sender, EventArgs e)
        {
            this.PassOk.Enabled = (this.PassInfo.Text != "") ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
        }
        private void TokenBotInfo_TextChanged(object sender, EventArgs e)
        {
            this.TokenOk.Enabled = (this.TokenBotInfo.Text != "") ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
        }
        private void DBnameInfo_TextChanged(object sender, EventArgs e)
        {
            this.DBnameOk.Enabled = (this.DBnameInfo.Text != "") ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
        }

        private void DBdefInfo_TextChanged(object sender, EventArgs e)
        {
            this.DBdefOk.Enabled = (this.DBdefInfo.Text != "") ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
        }


        /*сами настройки приложения*/
        private void DataUseBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.FolderGroup.Enabled = (this.DataUseBox1.Checked == true) ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
            UpdateInfo(this.DataUseBox2.Checked,
                (int)SettingsTxt.Indexes.remoteinfo, (int)Modes.BoolMode);
        }

        private void DataUseBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.SQLGroup.Enabled = (this.DataUseBox2.Checked == true) ? (true) : (false);
            this.SaveChangesButton.Enabled = true;
            UpdateInfo(this.DataUseBox2.Checked,
                (int)SettingsTxt.Indexes.remoteinfo, (int)Modes.BoolMode);
        }

        private void checkStartBot_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInfo(this.checkStartBot.Checked,
                (int)SettingsTxt.Indexes.startbot, (int)Modes.BoolMode);
        }

        /*применение изменений в настройках папок хранения Excel-файлов*/
        private void RCButton_Click(object sender, EventArgs e)
        {
            if (this.LocalFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.RCInfo.Text = this.LocalFolderBrowser.SelectedPath;
                UpdateInfo(this.RCInfo.Text,
                    (int)SettingsTxt.Indexes.recorclients, (int)Modes.TextMode);
            }
        }

        private void PCButton_Click(object sender, EventArgs e)
        {
            if (this.LocalFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.PCInfo.Text = this.LocalFolderBrowser.SelectedPath;
                UpdateInfo(this.PCInfo.Text,
                    (int)SettingsTxt.Indexes.possclients, (int)Modes.TextMode);
            }
        }

        private void IDsButton_Click(object sender, EventArgs e)
        {
            if (this.LocalFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.IDsInfo.Text = this.LocalFolderBrowser.SelectedPath;
                UpdateInfo(this.IDsInfo.Text,
                    (int)SettingsTxt.Indexes.ids, (int)Modes.TextMode);
            }
        }

        /*применение изменений в токене и настройках сервера*/
        private void ServerOk_Click(object sender, EventArgs e)
        {
            UpdateInfo(this.ServerInfo.Text,
                (int)SettingsTxt.Indexes.server, (int)Modes.TextMode);
        }

        private void PortOk_Click(object sender, EventArgs e)
        {
            UpdateInfo(this.PortInfo.Text,
                (int)SettingsTxt.Indexes.port, (int)Modes.TextMode);
        }

        private void UserOk_Click(object sender, EventArgs e)
        {
            UpdateInfo(this.UserInfo.Text,
                (int)SettingsTxt.Indexes.username, (int)Modes.TextMode);
        }

        private void PassOk_Click(object sender, EventArgs e)
        {
            UpdateInfo(this.PassInfo.Text,
                (int)SettingsTxt.Indexes.password, (int)Modes.TextMode);
        }

        private void TokenOk_Click(object sender, EventArgs e)
        {
            UpdateInfo(this.TokenBotInfo.Text,
                (int)SettingsTxt.Indexes.token, (int)Modes.TextMode);
        }


        private void DBdefOk_Click(object sender, EventArgs e)
        {
            UpdateInfo(this.DBdefInfo.Text,
                (int)SettingsTxt.Indexes.dbdef, (int)Modes.TextMode);
        }

        private void DBnameOk_Click(object sender, EventArgs e)
        {
            UpdateInfo(this.DBnameInfo.Text,
                (int)SettingsTxt.Indexes.dbname, (int)Modes.TextMode);
        }

        /*сохранение изменений*/
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            ServerOk_Click(sender, e);
            PortOk_Click(sender, e);
            UserOk_Click(sender, e);
            PassOk_Click(sender, e);
            TokenOk_Click(sender, e);
            DBdefOk_Click(sender, e);
            DBnameOk_Click(sender, e);
            SaveSettings(fileTemp, fileSettings);
            mainForm.ReloadSettings();
        }

        private void DiscardChangesButton_Click(object sender, EventArgs e)
        {
            SaveSettings(fileSettings, fileTemp);
            Initialize();
        }

        /*методы для обновления инфы в файлах*/
        private void Initialize()
        {
            using (var fileView = new StreamReader(fileSettings))
            {
                var txt = new SettingsTxt();
                string[] tempArray = new string[2];
                List<string> Settings = new List<string>();
                for (int i = 0; i < txt.ST.Length; i++)
                {
                    tempArray = fileView.ReadLine().Split('=');
                    if (tempArray[0] == txt.ST[i])
                        Settings.Add(tempArray[1]);
                    else
                        Settings.Add("Error");
                }
                /*инициализация элементов приложения*/
                TokenBotInfo.Text = Settings[0];
                checkStartBot.Checked = (Settings[1] == "true") ? (true) : (false);
                if (Settings[2] == "true")
                {
                    DataUseBox2.Checked = true;
                    DataUseBox1.Checked = false;
                }
                else
                {
                    DataUseBox2.Checked = false;
                    DataUseBox1.Checked = true;
                }
                ServerInfo.Text = Settings[3];
                PortInfo.Text = Settings[4];
                UserInfo.Text = Settings[5];
                PassInfo.Text = Settings[6];
                RCInfo.Text = Settings[7];
                PCInfo.Text = Settings[8];
                IDsInfo.Text = Settings[9];
                DBdefInfo.Text = Settings[10];
                DBnameInfo.Text = Settings[11];
            }
        }

        private void UpdateInfo(object Info, int Index, int ModeWork)
        {
            if (File.Exists(fileTemp))
            {
                var txt = new SettingsTxt();
                string[] tempArray = new string[txt.ST.Length];
                int emptyflag = 0;
                using (var fileRead = new StreamReader(fileTemp))
                {
                    for (int i = 0; i < txt.ST.Length; i++)
                    {
                        tempArray[i] = fileRead.ReadLine();
                        if (tempArray[i] == null) emptyflag++;
                    }
                }
                if (emptyflag == 0)
                    using (var fileWrite = new StreamWriter(fileTemp, false))
                    {
                        switch (ModeWork)
                        {
                            case ((int)Modes.BoolMode):
                                {
                                    string tempStr2 = ((bool)Info == true) ? ("true") : ("false");
                                    string tempStr1 = tempArray[Index].Split('=')[0];
                                    tempArray[Index] = tempStr1 + "=" + tempStr2; break;
                                }
                            case ((int)Modes.TextMode):
                                {
                                    string tempStr1 = tempArray[Index].Split('=')[0];
                                    tempArray[Index] = tempStr1 + "=" + (string)Info; break;
                                }
                        }
                        for (int i = 0; i < txt.ST.Length; i++)
                            fileWrite.Write(tempArray[i] + "\n");
                    }
            }
        }

        private void SaveSettings(string input, string output)
        {
            string buffer;
            using (var file_in = new StreamReader(input))
            {
                buffer = file_in.ReadToEnd();
            }
            using (var file_out = new StreamWriter(output, false))
            {
                file_out.Write(buffer);
            }
        }
    }
}
