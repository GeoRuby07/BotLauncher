using OfficeOpenXml;
using System;
using System.Data;
using System.IO;

namespace BotLauncherBeta
{
    class ExcelBridge
    {
        private string RecorPath;
        private string PossPath;
        private string IDsPath;
        private string BotName = "KorelaBot";

        private string[] TableNames =
{
            "recorclients",
            "possclients",
        };

        private DataTable table;
        public ExcelBridge(string[] SettingsList)
        {
            /*инициализация полей класса*/
            RecorPath = SettingsList[(int)SettingsTxt.Indexes.recorclients];
            PossPath = SettingsList[(int)SettingsTxt.Indexes.possclients];
            IDsPath = SettingsList[(int)SettingsTxt.Indexes.ids];

            /*создание директорий для файлов .xlsx*/
            if (!Directory.Exists(RecorPath))
                Directory.CreateDirectory(RecorPath);
            if (!Directory.Exists(PossPath))
                Directory.CreateDirectory(PossPath);
            if (!Directory.Exists(IDsPath))
                Directory.CreateDirectory(IDsPath);

            /*создание самих файлов .xlsx*/
            if (!File.Exists(RecorPath + "\\RecorClients.xlsx"))
                FilePrepare(RecorPath + "\\RecorClients.xlsx", 8);
            if (!File.Exists(PossPath + "\\PossClients.xlsx"))
                FilePrepare(PossPath + "\\PossClients.xlsx", 4);
        }

        public void RecStory(Telegram.Bot.Types.Message msg)
        {
            if (!File.Exists(IDsPath + $"\\ID{msg.From.Id}.xlsx"))
                FilePrepare(IDsPath + $"\\ID{msg.From.Id}.xlsx", 3, 10, "ChatStory");

            FileInfo file = new FileInfo(IDsPath + $"\\ID{msg.From.Id}.xlsx");
            using (ExcelPackage excel = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];
                var rowCnt = worksheet.Dimension.End.Row + 1;
                worksheet.Cells[rowCnt, 1].Value = $"ID{msg.From.Id}";
                worksheet.Cells[rowCnt, 2].Value = DateTime.Now.ToString();
                worksheet.Cells[rowCnt, 3].Value = msg.Text;
                if (worksheet.Column(3).Width < msg.Text.Length)
                    worksheet.Column(3).Width = msg.Text.Length;
                excel.Save();
            }
        }

        public void RecStoryAnswer(Telegram.Bot.Types.Message msg, string text, string ClientID)
        {
            if (!File.Exists(IDsPath + $"\\ID{ClientID}.xlsx"))
                FilePrepare(IDsPath + $"\\ID{ClientID}.xlsx", 3, 10, "ChatStory");

            FileInfo file;
            if (msg != null)
                file = new FileInfo(IDsPath + $"\\ID{msg.From.Id}.xlsx");
            else
                file = new FileInfo(IDsPath + $"\\ID{ClientID}.xlsx");
            using (ExcelPackage excel = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];
                var rowCnt = worksheet.Dimension.End.Row + 1;
                worksheet.Cells[rowCnt, 1].Value = BotName;
                worksheet.Cells[rowCnt, 2].Value = DateTime.Now.ToString();
                worksheet.Cells[rowCnt, 3].Value = text;
                if (worksheet.Column(3).Width < text.Length)
                    worksheet.Column(3).Width = text.Length;
                excel.Save();
            }
        }

        public void InfoPossClients(Telegram.Bot.Types.Message msg)
        {
            /*проверка на наличие записи контактов*/
            FileInfo file = new FileInfo(PossPath + "\\PossClients.xlsx");
            bool equelFlag = false;
            using (ExcelPackage excel = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];
                var rowCnt = worksheet.Dimension.End.Row;
                for (int i = 2; (i <= rowCnt && equelFlag == false); i++)
                {
                    if (worksheet.Cells[i, 1].Value.ToString() == msg.From.Id.ToString())
                        equelFlag = true;
                }
            }
            /*если клиент в possclients.xlsx не найден, то записать*/
            if (equelFlag == false)
                FileStart(PossPath + "\\PossClients.xlsx", msg);
        }

        public void StartInfoRecorClients(Telegram.Bot.Types.Message msg)
        {
            FileStart(RecorPath + "\\RecorClients.xlsx", msg);
        }

        public void SecondInfoRecorClients(Telegram.Bot.Types.Message msg, int ColNameIndex)
        {
            FileInfo file = new FileInfo(RecorPath + "\\RecorClients.xlsx");
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCnt = worksheet.Dimension.End.Row;
                int qual = rowCnt;
                for (qual = rowCnt; qual > 0; qual--)
                {
                    if (worksheet.Cells[qual, 1].Value.ToString() == msg.From.Id.ToString())
                        break;
                }
                worksheet.Cells[qual, ColNameIndex + 1 + 4].Value = msg.Text;
                /*здесь 1 это значит что нумерация ячеек идет с единицы, а 4 это отступ от первых данных*/
                package.Save();
            }
        }

        public DataTable IdListCreator(int TabNameIndex)
        {
            if (0 <= TabNameIndex && TabNameIndex < TableNames.Length)
            {
                FileInfo file = null;
                table = new DataTable();
                switch (TableNames[TabNameIndex])
                {
                    case ("recorclients"):
                        file = new FileInfo(RecorPath + "\\RecorClients.xlsx"); break;
                    case ("possclients"):
                        file = new FileInfo(PossPath + "\\PossClients.xlsx"); break;
                }
                if (file != null)
                    table = DataTableFiller(file, 2);
                return table;
            }
            else
                return null;
        }

        public DataTable StoryCreator(string UserId)
        {
            FileInfo file;
            table = new DataTable();
            if (File.Exists(IDsPath + $"\\ID{UserId}.xlsx"))
            {
                file = new FileInfo(IDsPath + $"\\ID{UserId}.xlsx");
                table = DataTableFiller(file);
            }
            else
                table = null;
            return table;
        }



        /*личные методы класса, к которым нельзя давать доступ*/
        private void FilePrepare(string PathAndName, int Count, int Start = 0, string SheetName = "Clients")
        {
            FileInfo file = new FileInfo(PathAndName);
            using (ExcelPackage excel = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add(SheetName);
                for (int i = 0; i < Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = TMas.InfoMassive[i + Start];
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Column(i + 1).Width = 25;
                }
                excel.Save();
            }
        }

        private void FileStart(string PathAndName, Telegram.Bot.Types.Message msg)
        {
            FileInfo file = new FileInfo(PathAndName);
            using (ExcelPackage excel = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];
                var rowCnt = worksheet.Dimension.End.Row + 1;
                worksheet.Cells[rowCnt, 1].Value = msg.From.Id;
                worksheet.Cells[rowCnt, 2].Value = msg.From.Username;
                worksheet.Cells[rowCnt, 3].Value = msg.From.FirstName;
                worksheet.Cells[rowCnt, 4].Value = msg.From.LastName;
                excel.Save();
            }
        }

        private DataTable DataTableFiller(FileInfo file, int limit = 1024)
        {
            using (ExcelPackage excel = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[1];
                int rowCnt = worksheet.Dimension.End.Row;
                int colCnt = worksheet.Dimension.End.Column;
                DataRow curRow;
                string[] tempArray;
                if (limit == 1024)
                    tempArray = new string[colCnt];
                else tempArray = new string[limit];

                for (int j = 1; (j <= colCnt && j <= limit); j++)
                    table.Columns.Add(worksheet.Cells[1, j].Value.ToString(), typeof(string));

                for (int i = 2; i <= rowCnt; i++)
                {
                    curRow = table.NewRow();
                    for (int j = 1; (j <= colCnt && j <= limit) ; j++)
                        try { tempArray[j - 1] = worksheet.Cells[i, j].Value.ToString(); }
                        catch { tempArray[j - 1] = ""; }
                    curRow.ItemArray = tempArray;
                    table.Rows.Add(curRow);
                }
            }
            return table;
        }
    }
}
