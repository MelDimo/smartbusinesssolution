using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.docsaction;

namespace com.sbs.gui.docsform
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

            UsersInfo.UserId = 1;
#endif
            Packages oPackages = new Packages();
            oPackages.packages_type = 1;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fSupplyTMC(oPackages));
        }
    }
}
