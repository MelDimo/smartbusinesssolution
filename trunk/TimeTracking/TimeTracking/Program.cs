using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.sbs.dll;
using System.Drawing;
using com.sbs.dll.utilites;

namespace com.sbs.gui.timetracking
{
    static class Program
    {
        private static DBaccess DbAccess = new DBaccess();
        static curUser cUser = new curUser();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            Config conf = new Config();
            if (!conf.loadConfig()) return;
            if (!conf.loadConString()) return;
            //GValues.DBMode = "offline";
            //GValues.DBMode = "online";
            //UsersInfo.Acl = new List<int>();
            //UsersInfo.Acl.Add(22);
            UserAuthorize uAuthor = new UserAuthorize();
            uAuthor.checkLogin("dimon", "74563");
            GValues.branchName = "LP2";
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch (GValues.authortype)
            { 
                case 1:
                    if (!mifareAccess()) { return; }
                    break;
                case 2:
                    if (!logInAccess()) { return; }
                    break;
            }

            Application.Run(new fMain(cUser));
        }

        private static bool logInAccess()
        {
            fLoginPWD flogin = new fLoginPWD();
            if (flogin.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cUser = DbAccess.getUserByLogIn("offline", flogin.xLogIn, flogin.xPwd);
                }
                catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return false; }
            }
            else
                return false;

            return true;
        }

        private static bool mifareAccess()
        {
            fMIFare fMifare = new fMIFare();
            if (fMifare.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cUser = DbAccess.getUserByMifire("offline", fMifare.keyId);
                }
                catch (Exception exc) { uMessage.Show("Ошибка регистрации сотрудника." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return false; }
            }
            else
                return false;

            return true;
        }
    }
}
