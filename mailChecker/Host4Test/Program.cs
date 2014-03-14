using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.sbs.dll;

namespace Host4Test
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
            UsersInfo.LogIn = "dimon";
            UsersInfo.UserId = 1;
            Config conf = new Config();
            if (!conf.loadConfig()) return;
            conf.getMailConfig("offline");
            
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fMain());
        }
    }
}
