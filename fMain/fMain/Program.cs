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
using System.Data.SqlClient;
using System.Security.Policy;

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
            if (!conf.loadConString()) return;

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

            // Читаем конфигурацию взаимодействия с почтой
            conf.getMailConfig("offline");

            // Инициализируем дополнительные параметры
            conf.initAdditionData("offline");

            // загрузка необходимых модулей
            try
            {
                loadProgramModules((List<string>)xResultSet[1]);
            }
            catch (Exception exc) 
            { 
                uMessage.Show("Ошибка загрузки модулей", exc, SystemIcons.Error); 
                return; 
            }

            Application.Run(new fMain((DataTable)xResultSet[0]));
        }

        private static void loadProgramModules(List<string> pArrayModules)
        {
            foreach (string str in pArrayModules)
            try
            {
#if DEBUG
                //Assembly.LoadFile(@"D:\VisualStudio2010\Projects\RELEASE\SBS\modules" + Path.DirectorySeparatorChar + str);
                Assembly.LoadFile(GValues.modulesPath + Path.DirectorySeparatorChar + str);

                Assembly assembly = Assembly.LoadFile(GValues.modulesPath + Path.DirectorySeparatorChar + str, 
                    new Evidence( Assembly.GetExecutingAssembly().Evidence ));

                if (str == "mailChecker.dll")   // если проверка почты
                {
                    Type type = assembly.GetType("com.sbs.dll.mailChecker.ChkMailMain");
                    MethodInfo methodInfo = type.GetMethod("run");
                    object classInstance = Activator.CreateInstance(type, null);
                    methodInfo.Invoke(classInstance, null);
                }

#else
                Assembly assembly = Assembly.LoadFile(GValues.modulesPath + Path.DirectorySeparatorChar + str, 
                    new Evidence( Assembly.GetExecutingAssembly().Evidence ));

                #region ------------------------------------------------------ запуск демонов

                if (str == "mailChecker.dll")   // если проверка почты
                {
                    Type type = assembly.GetType("com.sbs.dll.mailChecker.ChkMailMain");
                    MethodInfo methodInfo = type.GetMethod("run");
                    object classInstance = Activator.CreateInstance(type, null);
                    methodInfo.Invoke(classInstance, null);
                }

                if (str == "synchData.dll")   // если модуль синхронизации
                {
                    Type typeBill = assembly.GetType("com.sbs.dll.synchdata.SynchData");
                    MethodInfo methodInfoBill = typeBill.GetMethod("run");
                    object classInstance = Activator.CreateInstance(typeBill, null);
                    methodInfoBill.Invoke(classInstance, null);

                    Type typeTime = assembly.GetType("com.sbs.dll.synchdata.SynchTimeTracking");
                    MethodInfo methodInfoTime = typeTime.GetMethod("run");
                    object classInstanceTime = Activator.CreateInstance(typeTime, null);
                    methodInfoTime.Invoke(classInstanceTime, null);
                }
                #endregion
#endif
            }
            catch (Exception exc) 
            {
                if (str == "synchData.dll") 
                {

                    continue;
                }
                else throw exc;
            }
        }
    }
}
