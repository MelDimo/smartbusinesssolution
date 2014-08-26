using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
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
        public static string prgLogFile = @"C:\SBS\errors.msg";

        public static string localDBPath = @"C:\SBS\DB";

        public static string DBMode = string.Empty;
        public static string mainDB = string.Empty;

        public static int unitId;
        public static int branchId;
        public static string branchName;
        public static string resourcePath;

        public static int branchTable;
        public static int branchBill;
        public static int printRunners;

        public static int authortype;
        public static string billPrinter;
        public static bool dbSynch;
        public static int timeSynch;
        //public static bool isDelivery;

        public static bool isAlive = true;  // Флаг для потоков synch говорящий живо ли приложение и нужно ли работать

        public static Dictionary<string, Type> DicDemans =      // Перечень типов и методов запущенных деманаф.
            new Dictionary<string, Type>();                     // При закрытии основной формы вызываю для последней отработки
                                                                // Ввел для синхронизации при завершении приложения, но может еще для чего понадобится

        #region -------------------------------------------- Почта

        public static string mailBox;
        public static string mailUsername;
        public static string mailPassword;
        public static int mailMax = 5;
        public static int mailChkSec = 30000;
        public static string mailMelody;

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
        private SqlConnection con = null;
        private SqlCommand command = null;

        DataTable dtResult;

        public void getMailConfig(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT email, login, pwd, ring_name, maxMail, chkSec " +
                                        " FROM users_email ue, mailbox_config mc" +
                                        " WHERE ue.users = @users AND mc.users = @users";

                command.Parameters.Add("users", SqlDbType.Int).Value = UsersInfo.UserId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            if (dtResult.Rows.Count > 0)
            {
                GValues.mailBox = dtResult.Rows[0]["email"].ToString();
                GValues.mailUsername = dtResult.Rows[0]["login"].ToString();
                GValues.mailPassword = dtResult.Rows[0]["pwd"].ToString();

                GValues.mailMax = (int)dtResult.Rows[0]["maxMail"];
                GValues.mailMelody = dtResult.Rows[0]["ring_name"].ToString();
                GValues.mailChkSec = (int)dtResult.Rows[0]["chkSec"];
            }
        }

        private string readKey()
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

            strPwd = strPwd.PadRight(16, '0');

            return strPwd;

        }

        public bool loadConString()
        {
            string strPwd;
            string[] resultString;

            try
            {
                strPwd = readKey();

                FileStream fs = new FileStream(GValues.mdfPath, FileMode.Open, FileAccess.Read);

                StreamReader sReader = new StreamReader(fs, Encoding.GetEncoding(1251));
                string strData = sReader.ReadToEnd();

                sReader.Close();
                fs.Close();

                strData = Crypto.Decrypt(strData, strPwd.PadRight(16, '0'));


                resultString = strData.Split(new string[] { "\n" }, StringSplitOptions.None);

                GValues.localDBConStr = "Data Source=" + resultString[0] + ";Initial Catalog=" + resultString[1] + ";User ID=" + resultString[2] + ";Password=" + resultString[3];
                GValues.mainDBConStr = "Data Source=" + resultString[4] + ";Initial Catalog=" + resultString[5] + ";User ID=" + resultString[6] + ";Password=" + resultString[7];
            }
            catch (Exception exc)
            {
                //uMessage.Show("Неудалось установить параметры подключения.", exc, SystemIcons.Information);
                return false;
            }
            return true;
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
            XmlNode node_billPrinter;
            XmlNode node_dbSynch;
            XmlNode node_timeSynch;
            //XmlNode node_isDelivery;


            try
            {
                doc.Load(GValues.fileSettingsPath);
                node_ref_branch = doc.GetElementsByTagName("ref_branch")[0];
                node_dbmode = doc.GetElementsByTagName("dbmode")[0];
                node_resourcePath = doc.GetElementsByTagName("resourcePath")[0];
                node_modulesPath = doc.GetElementsByTagName("modulesPath")[0];
                node_waiterConfig = doc.SelectNodes("settings/waiter/authortype").Item(0);
                node_billPrinter = doc.SelectNodes("settings/waiter/billPrinter")[0];
                node_dbSynch = doc.GetElementsByTagName("dbsynch")[0];
                node_timeSynch = doc.SelectNodes("settings/waiter/timeSynch")[0];
                //node_isDelivery = doc.GetElementsByTagName("isDelivery")[0];

                if (!int.TryParse(node_ref_branch.InnerText, out xBranchId))
                    msgError += Environment.NewLine + "- Не удалось определить заведение;";
                else GValues.branchId = xBranchId;

                GValues.DBMode = node_dbmode.InnerText;
                if (GValues.DBMode.Length == 0)
                    msgError += Environment.NewLine + "- Не удалось определить режим взаисодействия с БД;";

                GValues.resourcePath = node_resourcePath.InnerText;
                if (GValues.resourcePath.Length == 0)
                    msgError += Environment.NewLine + "- Не удалось определить путь к ресурсам;";

                GValues.modulesPath = node_modulesPath.InnerText;
                if (GValues.modulesPath.Length == 0)
                    msgError += Environment.NewLine + "- Не удалось определить путь к модулям;";

                if (!int.TryParse(node_waiterConfig.InnerText, out xBranchId))
                    msgError += Environment.NewLine + "- Не удалось определить тип авторизации официанта;";
                else GValues.authortype = xBranchId;

                switch (node_billPrinter.InnerText)
                {
                    case "default":
                        GValues.billPrinter = "default";
                        break;

                    case "branch":
                        GValues.billPrinter = "branch";
                        break;

                    default:
                        msgError += Environment.NewLine + "- Не удалось определить тип принтера счетов;";
                        break;
                }

                switch (node_dbSynch.InnerText)
                {
                    case "true":
                        GValues.dbSynch = true;
                        break;

                    case "false":
                        GValues.dbSynch = false;
                        break;

                    default:
                        msgError += Environment.NewLine + "- Не удалось определить тип синхронизации;";
                        break;
                }

                //switch (node_isDelivery.InnerText)
                //{
                //    case "true":
                //        GValues.isDelivery = true;
                //        break;

                //    case "false":
                //        GValues.isDelivery = false;
                //        break;

                //    default:
                //        msgError += Environment.NewLine + "- Не удалось определить является ли рабочее место доставкой;";
                //        break;
                //}                

                if (!int.TryParse(node_timeSynch.InnerText, out xBranchId))
                    msgError += Environment.NewLine + "- Не удалось определить период синхронизации заведения;";
                else GValues.timeSynch = xBranchId;

                if (!msgError.Equals("В ходе разбора файла конфигурации произошли следующие ошибки:"))
                {
                    uMessage.Show(msgError + Environment.NewLine + Environment.NewLine + "Приложение будет закрыто.", SystemIcons.Error);
                    return false;
                }

                //loadConString();
            }
            catch (Exception exc) { uMessage.Show("Неудалось прочесть файл конфигураций", exc, SystemIcons.Information); return false; }

            return true;
        }

        public void initAdditionData(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT b.name AS branchName, " +
                                        " bi.xtable AS xtable," +
                                        " bi.countBill AS countBill," +
                                        " bi.printRunners AS printRunners" +
                                        " FROM branch b " +
                                        " INNER JOIN branch_info bi ON bi.branch = b.id" +
                                        " WHERE b.id = @pBranch";

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach(DataRow dr in dtResult.Rows)
            {
                GValues.branchName = dr["branchName"].ToString();
                GValues.branchTable = (int)dr["xtable"];
                GValues.branchBill = (int)dr["countBill"];
                GValues.printRunners = (int)dr["printRunners"];
            }
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
