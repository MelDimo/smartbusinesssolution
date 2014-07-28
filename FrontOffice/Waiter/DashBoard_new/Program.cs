using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
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
            conf.initAdditionData(GValues.DBMode);
            
            UserAuthorize uAuthor = new UserAuthorize();
            uAuthor.checkLogin("ivan", "147");

            GValues.branchTable = 10;
            GValues.branchName = "lp2";
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fSplash());
        }
    }
}
