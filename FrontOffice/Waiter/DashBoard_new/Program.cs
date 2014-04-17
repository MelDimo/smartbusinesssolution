﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.sbs.dll;

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
            //GValues.branchName = "Ла плачинте";
            //GValues.branchId = 10;
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fSplash());
        }
    }
}
