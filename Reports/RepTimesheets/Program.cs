﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.sbs.dll;

namespace com.sbs.gui.report.reptimesheets
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
            GValues.DBMode = "online";
            UsersInfo.Acl = new List<int>();
            UsersInfo.Acl.Add(22);
            GValues.branchName = "LP2";
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fRepTimesheets());
        }
    }
}
