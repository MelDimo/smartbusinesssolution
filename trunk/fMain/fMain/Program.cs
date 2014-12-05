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
using System.Diagnostics;
using System.Threading;

namespace com.sbs.gui.main
{
    static class Program
    {
        private static string curModule = string.Empty;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string[] sPwd = new string[]{string.Empty,string.Empty};

            fLogIn flogin;

            if (isRunning())
            {
                MessageBox.Show("Данное приложение уже запущенно, либо завершаются потоки синхронизации.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            object[] xResultSet;
            DBaccess dbAccess = new DBaccess();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Читаем файл конфигурации
            Config conf = new Config();
            if (!conf.loadConfig()) return;
            if (!conf.loadConString()) return;

            switch(GValues.authortype)
            {
                case 2:
                    //Авторизуем пользователя, 
                    flogin = new fLogIn(args);
                    flogin.Text = GValues.prgNameFull;
                    if (flogin.ShowDialog() != DialogResult.OK) return; //авторизация прошла не успешно - выходим из приложения
                    break;

                case 1:
                    if (args.Length != 0)
                    {
                        //Авторизуем пользователя, 
                        flogin = new fLogIn(args);
                        flogin.Text = GValues.prgNameFull;
                        if (flogin.ShowDialog() != DialogResult.OK) return; //авторизация прошла не успешно - выходим из приложения
                    }
                    else
                    {
                        fMIFare fMiFare = new fMIFare();
                        fMiFare.Text = GValues.prgNameFull;
                        if (fMiFare.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                sPwd = dbAccess.getUserPwd(GValues.DBMode, fMiFare.keyId);
                                UserAuthorize uAuth = new UserAuthorize();
                                if (!uAuth.checkLogin(sPwd[0], sPwd[1])) return;
                            }
                            catch (Exception exc) { uMessage.Show("Ошибка!", exc, SystemIcons.Information); return; }
                        }
                        else
                        {
                            uMessage.Show("Не удалось определить пользователя. " + Environment.NewLine + "Приложение будет закрыто.", 
                                SystemIcons.Information);
                            return;
                        }
                    }
                    break;
            }

            // Формируем меню пользователя
            try
            {
                xResultSet = dbAccess.createMenuLoadModules(GValues.DBMode);
            }
            catch (Exception exc) { uMessage.Show("Ошибка формирования меню", exc, SystemIcons.Error); return; }

            // Читаем конфигурацию взаимодействия с почтой
            conf.getMailConfig(GValues.DBMode);

            // Инициализируем дополнительные параметры
            conf.initAdditionData(GValues.DBMode);

            // загрузка необходимых модулей
            try
            {
                loadProgramModules((List<string>)xResultSet[1]);
            }
            catch (Exception exc) 
            {
                uMessage.Show(string.Format("Ошибка загрузки модулей ({0})", curModule), exc, SystemIcons.Error); 
                return; 
            }

            try
            {
                Application.Run(new fMain((DataTable)xResultSet[0]));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        private static bool isRunning()
        {
            Process[] proc = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            return (proc.Length > 1);
        }

        private static void loadProgramModules(List<string> pArrayModules)
        {
            //try
            //{
            //    MessageBox.Show(string.Format("Assembly.LoadFile({0})", GValues.modulesPath + Path.DirectorySeparatorChar + "usersDiscount.dll"));
            //    Assembly.LoadFile(GValues.modulesPath + Path.DirectorySeparatorChar + "usersDiscount.dll"); // В официантской программе использую для предоставления скидочных карт
            //}
            //catch (Exception exc) { MessageBox.Show(exc.Message); }

            foreach (string str in pArrayModules)
            try
            {
                curModule = str;
#if DEBUG
                //Assembly.LoadFile(@"D:\VisualStudio2010\Projects\RELEASE\SBS\modules" + Path.DirectorySeparatorChar + str);
                Assembly.LoadFile(GValues.modulesPath + Path.DirectorySeparatorChar + str);

                Assembly assembly = Assembly.LoadFile(GValues.modulesPath + Path.DirectorySeparatorChar + str, 
                    new Evidence( Assembly.GetExecutingAssembly().Evidence ));

                if (str == "mailChecker.dll")   // если проверка почты
                {
                    /*
                    Type type = assembly.GetType("com.sbs.dll.mailChecker.ChkMailMain");
                    MethodInfo methodInfo = type.GetMethod("run");
                    object classInstance = Activator.CreateInstance(type, null);
                    methodInfo.Invoke(classInstance, null);
                    */
                }

#else
                Assembly assembly = Assembly.LoadFile(GValues.modulesPath + Path.DirectorySeparatorChar + str, 
                    new Evidence( Assembly.GetExecutingAssembly().Evidence ));

                #region ------------------------------------------------------ запуск демонов

                if (str == "mailChecker.dll")   // если проверка почты. Временно закоментировал. Не доточил
                {
                    ;
                    /*
                    Type type = assembly.GetType("com.sbs.dll.mailChecker.ChkMailMain");
                    MethodInfo methodInfo = type.GetMethod("run");
                    object classInstance = Activator.CreateInstance(type, null);
                    methodInfo.Invoke(classInstance, null);
                     * */
                }

                if (str == "synchData.dll" && GValues.dbSynch)   // если модуль синхронизации и установлен признак синхронизации (settings.xml)
                {
                    Type typeBill = assembly.GetType("com.sbs.dll.synchdata.SynchData");
                    MethodInfo methodInfoBill = typeBill.GetMethod("run");
                    object classInstance = Activator.CreateInstance(typeBill, null);
                    methodInfoBill.Invoke(classInstance, null);

                    GValues.DicDemans.Add("sendSeasonData", typeBill);

                    Type typeTime = assembly.GetType("com.sbs.dll.synchdata.SynchTimeTracking");
                    MethodInfo methodInfoTime = typeTime.GetMethod("run");
                    object classInstanceTime = Activator.CreateInstance(typeTime, null);
                    methodInfoTime.Invoke(classInstanceTime, null);

                    GValues.DicDemans.Add("sendTimeTrackingData", typeTime);
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
