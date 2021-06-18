using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BotLauncherBeta
{
    class SqlBridge
    {
        private string DBdefname;
        private string DBname;
        private string server;
        private string port;
        private string username;
        private string password;
        private DataBase database;
        private DataTable table;
        private MySqlDataAdapter adapter;
        private MySqlCommand command;
        private string BotName = "KorelaBot";

        private string[] ColNames =
        {
            "Month",
            "Date",
            "Name",
            "Phone",
        };

        private string[] TableNames =
        {
            "recorclients",
            "possclients",
        };


        public SqlBridge(string[] SettingsList)
        {
            server = SettingsList[(int)SettingsTxt.Indexes.server];
            port = SettingsList[(int)SettingsTxt.Indexes.port];
            username = SettingsList[(int)SettingsTxt.Indexes.username];
            password = SettingsList[(int)SettingsTxt.Indexes.password];
            DBdefname = SettingsList[(int)SettingsTxt.Indexes.dbdef];
            DBname = SettingsList[(int)SettingsTxt.Indexes.dbname];

            database = new DataBase(server, port, username, password, DBname);
            InitialiseSettings();
        }

        public void RecStory(Telegram.Bot.Types.Message msg)
        {
            string[] CommandList =
            {
                $"CREATE TABLE IF NOT EXISTS `{DBname}`.`ID{msg.From.Id.ToString()}` (" +
                $" `ID` VARCHAR(13) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `MessDate` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `MessText` TEXT(300) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ) ENGINE = InnoDB;",

                $"INSERT INTO `ID{msg.From.Id.ToString()}` (`ID`, `MessDate`, `MessText`)" +
                $" VALUES ('ID{msg.From.Id.ToString()}', '{DateTime.Now.ToString()}', '{msg.Text}');",
            };
            CommandWorker(database, CommandList);
        }

        public void RecStoryAnswer(Telegram.Bot.Types.Message msg, string text, string ClientID)
        {
            string tempStr;
            if (msg != null)
                tempStr  = msg.From.Id.ToString();
            else
                tempStr = ClientID;
            string[] CommandList =
            {
                $"CREATE TABLE IF NOT EXISTS `{DBname}`.`ID{tempStr}` (" +
                $" `ID` VARCHAR(13) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `MessDate` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `MessText` TEXT(300) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ) ENGINE = InnoDB;",

                $"INSERT INTO `ID{tempStr}` (`ID`, `MessDate`, `MessText`)" +
                $" VALUES ('{BotName}', '{DateTime.Now}', '{text}');",
            };
            CommandWorker(database, CommandList);
        }


        public void InfoPossClients(Telegram.Bot.Types.Message msg)
        {
            string[] CommandList =
            {
                $"INSERT INTO `possclients`" +
                $" (`ID`, `Username`, `Firstname`, `Lastname`)" +
                $" VALUES ('{msg.From.Id}', '{msg.From.Username}'," +
                $" '{msg.From.FirstName}', '{msg.From.LastName}');",
            };
            command = new MySqlCommand($"SELECT * FROM `possclients` WHERE `ID` = '{msg.From.Id.ToString()}'",
                database.getConnection());
            adapter = new MySqlDataAdapter();
            table = new DataTable();
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(table);
            }
            catch
            {

            }
            if (table.Rows.Count == 0)
                CommandWorker(database, CommandList);
        }

        public void StartInfoRecorClients(Telegram.Bot.Types.Message msg)
        {
            string[] CommandList =
            {
                $"INSERT INTO `recorclients` (" +
                $"`ID`, `UserId`, `Username`, `Firstname`, `Lastname`, `Month`, `Date`, `Name`, `Phone`)" +
                $" VALUES(NULL, '{msg.From.Id}', '{msg.From.Username}'," +
                $" '{msg.From.FirstName}', '{msg.From.LastName}', '', '', '', '');",
            };
            CommandWorker(database, CommandList);
        }

        public void SecondInfoRecorClients(Telegram.Bot.Types.Message msg, int ColNameIndex)
        {
            string[] CommandList =
            {
                $"UPDATE `recorclients` SET `{ColNames[ColNameIndex]}` = '{msg.Text}' " +
                $"WHERE `recorclients`.`UserId` = {msg.From.Id} " +
                $"ORDER BY `recorclients`.`ID` DESC LIMIT 1",
            };
            if (0 <= ColNameIndex && ColNameIndex < ColNames.Length)
                CommandWorker(database, CommandList);
        }


        public DataTable IdListCreator(int TabNameIndex)
        {
            string query = null;
            if (TableNames[TabNameIndex] == "recorclients")
                query = $"SELECT `UserId`, `UserName` FROM `recorclients`";
            if (TableNames[TabNameIndex] == "possclients")
                query = $"SELECT `ID`, `UserName` FROM `possclients`";

            if (0 <= TabNameIndex && TabNameIndex < TableNames.Length)
                return DataTableFiller(query);
            else
                return null;
        }

        public DataTable StoryCreator(string UserId)
        {
            string query = $"SELECT * FROM `ID{UserId}`";
            return DataTableFiller(query);
        }

        /*личные методы класса, к которым нельзя давать доступ*/
        private void InitialiseSettings()
        {
            string[] CommandList =
            {
                $"CREATE DATABASE IF NOT EXISTS `{DBname}`",

                $"CREATE TABLE IF NOT EXISTS `{DBname}`.`possclients` (" +
                $" `ID` INT NOT NULL ," +
                $" `Username` VARCHAR(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `Firstname` VARCHAR(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `Lastname` VARCHAR(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" PRIMARY KEY (`ID`)) ENGINE = MyISAM CHARSET=utf8 COLLATE utf8_general_ci;",

                $"CREATE TABLE IF NOT EXISTS `{DBname}`.`recorclients` (" +
                $" `ID` INT NOT NULL AUTO_INCREMENT ," +
                $" `UserId` INT NOT NULL ," +
                $" `Username` VARCHAR(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `Firstname` VARCHAR(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `Lastname` VARCHAR(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `Month` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `Date` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `Name` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" `Phone` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ," +
                $" PRIMARY KEY (`ID`)) ENGINE = MyISAM CHARSET=utf8 COLLATE utf8_general_ci;"
            };
            DataBase defdatabase = new DataBase(server, port, username, password, DBdefname);

            CommandWorker(defdatabase, CommandList);
        }
        private void CommandWorker(DataBase DB, string[] CommandList)
        {
            DB.openConnection();
            for (int i = 0; i < CommandList.Length; i++)
            {
                command = new MySqlCommand(CommandList[i], DB.getConnection());
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    
                }
            }
            DB.closeConnection();
        }

        private DataTable DataTableFiller(string query)
        {
            command = new MySqlCommand(query, database.getConnection());
            adapter = new MySqlDataAdapter();
            table = new DataTable();
            adapter.SelectCommand = command;
            try { adapter.Fill(table); }
            catch { table = null; }
            return table;
        }
    }
}
