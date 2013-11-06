using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.sbs.dll;

namespace DocsForm
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
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fSupplyTMC());
        }
    }
}
