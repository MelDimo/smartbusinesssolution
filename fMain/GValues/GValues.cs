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
using System.IO;
using System.Security.Cryptography;

namespace com.sbs.dll
{
    public static class GValues
    {
        public static string prgNameFull = "SmartBusinessSolution";
        public static string prgNameShort = "SBS";

        public static string DBMode = string.Empty;
        public static string mainDB = string.Empty;

        public static int unitId;
        public static int branchId;
        public static string resourcePath;

        public static byte[] rgbIV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        public static int authortype;

        #region ----------------------------- Оставил пока не перепишу официантскую часть, потом убрать -----------------------------

        public static int openSeasonId;
        public static int openSeasonUserId;
        public static string openSeasonDate;
        public static string openSeasonUserName;
        public static void seasonInfoClear()
        {
            openSeasonId = 0;
            openSeasonUserId = 0;
            openSeasonDate = string.Empty;
            openSeasonUserName = string.Empty;
        }
        #endregion

#if DEBUG
        //public static string logoPath = @"D:\VisualStudio2010\Projects\SBS\resource\logo.png";

        //public static string mdfPath = @"D:\VisualStudio2010\Projects\SBS\resource\db.mdf";

        public static string fileSettingsPath = @"D:\VisualStudio2010\Projects\RELEASE\SBS\settings.xml";

        public static string logoPath
        {
            get { return GValues.resourcePath + @"\logo.png"; }
            set { logoPath = value; }

        }

        public static string mdfPath
        {
            get { return GValues.resourcePath + @"\db.mdf"; }
            set { mdfPath = value; }

        }

        public static string modulesPath;

        public static string mainDBConStr;// = @"Data Source=Programer\SQLEXP_SBS;Initial Catalog=sbsLocal;User ID=sa;Password=74563";
        public static string localDBConStr;// = @"Data Source=Programer\SQLEXP_SBS;Initial Catalog=sbsLocal;User ID=sa;Password=74563"; 

#else
        public static string logoPath
        {
            get { return GValues.resourcePath + @"\logo.png"; }
            set { logoPath = value; }

        }

        public static string mdfPath
        {
            get { return GValues.resourcePath + @"\db.mdf"; }
            set { mdfPath = value; }

        }

        public static string modulesPath;

        public static string fileSettingsPath = Environment.CurrentDirectory + @"\settings.xml";

        public static string mainDBConStr;// = @"Data Source=Programer\SQLEXP_SBS;Initial Catalog=sbsLocal;User ID=sa;Password=74563";
        public static string localDBConStr;// = @"Data Source=Programer\SQLEXP_SBS;Initial Catalog=sbsLocal;User ID=sa;Password=74563"; 
#endif

    }

    public class Config
    {
        private byte[] readKey()
        {
            string strPwd = string.Empty;
            byte[] bSourceFile = File.ReadAllBytes(GValues.logoPath);
            /*
                00 00 00 00 49 45 4e 44 ae 42 60 82
                ........... I  E  N  D  ...........
            */
            int indexAE = Array.LastIndexOf(bSourceFile, (byte)174) + 4; // 174 - "ae"

            for (long i = indexAE; i < bSourceFile.Length; i++)
            {
                strPwd += Encoding.ASCII.GetString(new byte[] { (byte)bSourceFile.GetValue(i) });
            }

            if (strPwd.Length == 0) throw new Exception("ошибка инициализации, длина ноль");

            strPwd = strPwd.PadRight(32, '0');

            return Encoding.ASCII.GetBytes(strPwd);

        }

        private void loadConString()
        {
            byte[] rgbKey;
            string[] resultString;


            try
            {
                rgbKey = readKey();

                using (FileStream fStream = File.Open(GValues.mdfPath, FileMode.Open))
                {
                    Rijndael RijndaelAlg = Rijndael.Create();
                    RijndaelAlg.KeySize = 256;
                    RijndaelAlg.BlockSize = 128;
                    RijndaelAlg.Mode = System.Security.Cryptography.CipherMode.CFB;
                    RijndaelAlg.Padding = System.Security.Cryptography.PaddingMode.ISO10126;
                    CryptoStream cStream = new CryptoStream(fStream,
                                                            RijndaelAlg.CreateDecryptor(rgbKey, GValues.rgbIV),
                                                            CryptoStreamMode.Read);
                    StreamReader sReader = new StreamReader(cStream, Encoding.GetEncoding(1251));

                    resultString = sReader.ReadToEnd().Split(new string[] { "\n" }, StringSplitOptions.None);

                    GValues.localDBConStr = "Data Source=" + resultString[0] + ";Initial Catalog=" + resultString[1] + ";User ID=" + resultString[2] + ";Password=" + resultString[3];
                    GValues.localDBConStr = "Data Source=" + resultString[4] + ";Initial Catalog=" + resultString[5] + ";User ID=" + resultString[6] + ";Password=" + resultString[7];

                    sReader.Close();
                    cStream.Close();
                    fStream.Close();
                }

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool loadConfig()
        {
            string msgError = "В ходе разбора файла конфигурации произошли следующие ошибки:";
            int xBranchId;
            XmlDocument doc = new XmlDocument();
            XmlNode node_ref_branch;
            XmlNode node_dbmode;
            XmlNode node_waiterConfig;
            XmlNode node_resourcePath;
            XmlNode node_modulesPath;

            try
            {
                doc.Load(GValues.fileSettingsPath);
                node_ref_branch = doc.GetElementsByTagName("ref_branch")[0];
                node_dbmode = doc.GetElementsByTagName("dbmode")[0];
                node_waiterConfig = doc.SelectNodes("settings/waiter/authortype").Item(0);
                node_resourcePath = doc.GetElementsByTagName("resourcePath")[0];
                node_modulesPath = doc.GetElementsByTagName("modulesPath")[0];

                if (!int.TryParse(node_ref_branch.InnerText, out xBranchId))
                    msgError += Environment.NewLine + "- Не удалось определить заведение;";
                else GValues.branchId = xBranchId;

                GValues.DBMode = node_dbmode.InnerText;
                if (GValues.DBMode.Length == 0)
                    msgError += Environment.NewLine + "- Не удалось определить режим взаисодействия с БД;";

                if (!int.TryParse(node_waiterConfig.InnerText, out xBranchId))
                    msgError += Environment.NewLine + "- Не удалось определить тип авторизации официанта;";
                else GValues.authortype = xBranchId;

                GValues.resourcePath = node_resourcePath.InnerText;
                if (GValues.resourcePath.Length == 0)
                    msgError += Environment.NewLine + "- Не удалось определить путь к ресурсам;";

                GValues.modulesPath = node_modulesPath.InnerText;
                if (GValues.modulesPath.Length == 0)
                    msgError += Environment.NewLine + "- Не удалось определить путь к модулям;";

                if (!msgError.Equals("В ходе разбора файла конфигурации произошли следующие ошибки:"))
                {
                    uMessage.Show(msgError + Environment.NewLine + Environment.NewLine + "Приложение будет закрыто.", SystemIcons.Error);
                    return false;
                }

                loadConString();
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

    public static class UsersInfo
    {
        private static int _userId;
        private static string _userName;
        private static string _userTabn;
        private static int _postId;
        private static List<int> _acl;
        private static string _logIN;

        public static void Clear()
        {
            _userId = 0;
            _userName = "";
            _userTabn = "";
            _postId = 0;
            _acl = new List<int>();
        }

        public static string LogIn
        {
            get { return _logIN; }
            set { _logIN = value; }
        }

        public static List<int> Acl
        {
            get { return _acl; }
            set { _acl = value; }
        }

        public static int PostId
        {
            get { return _postId; }
            set { _postId = value; }
        }

        public static string UserTabn
        {
            get { return _userTabn; }
            set { _userTabn = value; }
        }

        public static string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public static int UserId
	    {
		    get { return _userId;}
		    set { _userId = value;}
	    }
    }
}
