using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using com.sbs.dll;
using System.Drawing;
using com.sbs.dll.utilites;
using System.Data;
using System.Reflection;
using System.IO;

namespace com.sbs.gui.main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            object[] xResultSet;
            DBaccess dbAccess = new DBaccess();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Читаем файл конфигурации
            Config conf = new Config();
            if (!conf.loadConfig()) return;

            //Авторизуем пользователя, 
            fLogIn flogin = new fLogIn();
            flogin.Text = GValues.prgNameFull;
            if (flogin.ShowDialog() != DialogResult.OK) return; //авторизация прошла не успешно - выходим из приложения

            // Формируем меню пользователя
            try
            {
                xResultSet = dbAccess.createMenuLoadModules("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка формирования меню", exc, SystemIcons.Error); return; }

            // загрузка необходимых модулей
            try
            {
                loadProgramModules((List<string>)xResultSet[1]);
            }
            catch (Exception exc) { uMessage.Show("Ошибка загрузки модулей", exc, SystemIcons.Error); return; }

            Application.Run(new fMain((DataTable)xResultSet[0]));
        }

        private static void loadProgramModules(List<string> pArrayModules)
        {
            foreach (string str in pArrayModules)
            try
            {
                //Assembly.LoadFile(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "module" + Path.DirectorySeparatorChar + str);
                Assembly.LoadFile(@"D:\VisualStudio2010\Projects\RELEASE\SBS\modules" + Path.DirectorySeparatorChar + str);
            }
            catch (Exception exc) { throw exc; }
        }

        //private static bool loadConfig()
        //{
        //    string msgError = "В ходе разбора файла конфигурации произошли следующие ошибки:";

        //    XmlDocument doc = new XmlDocument();
        //    XmlNode node_ref_unit;
        //    XmlNode node_dbmode;
        //    XmlNode node_maindb;

        //    try
        //    {
        //        doc.Load(GValues.fileSettingsPath);
        //        node_ref_unit = doc.GetElementsByTagName("ref_unit")[0];
        //        node_dbmode = doc.GetElementsByTagName("dbmode")[0];
        //        node_maindb = doc.GetElementsByTagName("maindb")[0];

        //        if (!int.TryParse(node_ref_unit.InnerText, out GValues.unitID))
        //            msgError += Environment.NewLine + "- Не удалось определить заведение;";
            
        //        GValues.DBMode = node_dbmode.InnerText;
        //        if (GValues.DBMode.Length == 0)
        //            msgError += Environment.NewLine + "- Не удалось определить режим взаисодействия с БД;";

        //        GValues.mainDB = node_maindb.InnerText;
        //        if (GValues.mainDB.Length == 0)
        //            msgError += Environment.NewLine + "- Не удалось определить головную БД;";

        //        if (!msgError.Equals("В ходе разбора файла конфигурации произошли следующие ошибки:"))
        //        {
        //            uMessage.Show(msgError + Environment.NewLine + Environment.NewLine + "Приложение будет закрыто.", SystemIcons.Error);
        //            return false;
        //        }
        //    }
        //    catch (Exception exc) { uMessage.Show("Неудалось прочесть файл конфигураций", exc, SystemIcons.Information); return false; }

        //    return true;
        //}
    }
}
