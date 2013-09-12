using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using com.sbs.dll.utilites;
using System.Drawing;

namespace com.sbs.dll
{
    public static class GValues
    {
        public static string prgNameFull = "SmartBusinessSolution";
        public static string prgNameShort = "SBS";

        public static int unitID = 0;
        public static string DBMode = string.Empty;
        public static string mainDB = string.Empty;

#if DEBUG

        public static string fileSettingsPath = @"D:\VisualStudio2010\Projects\SBS\resource\settings.xml";
        public static string fileBDLocalPath = @"D:\VisualStudio2010\Projects\SBS\localDB\localDB.sdf";
        public static string mainDBConStr = @"Server=myServerAddress; Database=fileBDLocalPath; Password=74563;";
        public static string localDBConStr = @"Data Source=NBHP\SQLEXPLOCALDB;Initial Catalog=sbsLocal;User ID=sa;Password=74563";
        
#else
        public static string fileSettingsPath = Environment.CurrentDirectory + @"\resource\settings.xml";
        public static string fileBDLocalPath = Environment.CurrentDirectory + @"\DataBase\localData.sdf";
        private static string mainDBConStr = "Server=myServerAddress; Database=fileBDLocalPath; Password=74563;";
#endif

    }

    public class Config
    {
        public bool loadConfig()
        {
            string msgError = "В ходе разбора файла конфигурации произошли следующие ошибки:";

            XmlDocument doc = new XmlDocument();
            XmlNode node_ref_unit;
            XmlNode node_dbmode;
            XmlNode node_maindb;

            try
            {
                doc.Load(GValues.fileSettingsPath);
                node_ref_unit = doc.GetElementsByTagName("ref_unit")[0];
                node_dbmode = doc.GetElementsByTagName("dbmode")[0];
                node_maindb = doc.GetElementsByTagName("maindb")[0];

                if (!int.TryParse(node_ref_unit.InnerText, out GValues.unitID))
                    msgError += Environment.NewLine + "- Не удалось определить заведение;";

                GValues.DBMode = node_dbmode.InnerText;
                if (GValues.DBMode.Length == 0)
                    msgError += Environment.NewLine + "- Не удалось определить режим взаисодействия с БД;";

                GValues.mainDB = node_maindb.InnerText;
                if (GValues.mainDB.Length == 0)
                    msgError += Environment.NewLine + "- Не удалось определить головную БД;";

                if (!msgError.Equals("В ходе разбора файла конфигурации произошли следующие ошибки:"))
                {
                    uMessage.Show(msgError + Environment.NewLine + Environment.NewLine + "Приложение будет закрыто.", SystemIcons.Error);
                    return false;
                }
            }
            catch (Exception exc) { uMessage.Show("Неудалось прочесть файл конфигураций", exc, SystemIcons.Information); return false; }

            return true;
        }
    }
    // Класс реализует метод возвращающий дескриптор соединения.
    // При инициализации учитывается режим работы приложения
    public class DBCon
    {
        /// <summary>
        /// Метод восвращает дескриптор соединения
        /// </summary>
        /// <param name="pDBMode">режим желаемого соединения(offline; online)</param>
        /// <returns></returns>
        public SqlConnection getConnection(string pDBMode)
        {
            switch (pDBMode)
            {
                case "offline":
                    switch (GValues.DBMode)
                    {
                        case "offline":
                            return new SqlConnection(GValues.localDBConStr);

                        case "online":
                            return new SqlConnection(GValues.mainDBConStr);

                        case "mixed":
                            return new SqlConnection(GValues.localDBConStr);

                    }
                    break;

                case "online":
                    switch(GValues.DBMode)
                    {
                        case "offline":
                            return new SqlConnection(GValues.localDBConStr);

                        case "online":
                            return new SqlConnection(GValues.mainDBConStr);

                        case "mixed":
                            return new SqlConnection(GValues.mainDBConStr);
                    }
                    break;

                default:
                    throw new Exception("Неудалось определить режи работы заведения.");
            }

            return null;
        }
    }
}
