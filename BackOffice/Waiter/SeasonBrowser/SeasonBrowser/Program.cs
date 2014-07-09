using System;
using System.Collections.Generic;
using System.Linq;      
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.seasonbrowser
{
    static class Program
    {
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
            uAuthor.checkLogin("lupolova", "145");
            GValues.branchName = "LP2";
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fMain());
        }
    }
}
