using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace com.sbs.dll.mailChecker
{
    public partial class fFormWaiting : Form
    {
        public List<DTO.Mail> oMail { get; set; }

        private object[] xParam;
        private string xMethodName;

        public fFormWaiting(string pMethodName, object[] pParam)
        {
            xParam = pParam;
            xMethodName = pMethodName;

            InitializeComponent();
        }

        private void fFormWaiting_Shown(object sender, EventArgs e)
        {
            chooseMethod();
        }

        private void chooseMethod()
        {
            BackgroundWorker worThread = new BackgroundWorker();

            switch (xMethodName)
            {
                case "getMail":
                    worThread.DoWork += new DoWorkEventHandler(getMail_DoWork);
                    worThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getMail_RunWorkerCompleted);
                    worThread.RunWorkerAsync(xParam);
                    break;

                case "deleteMail":
                    worThread.DoWork += new DoWorkEventHandler(deleteMail_DoWork);
                    worThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getMail_RunWorkerCompleted);
                    worThread.RunWorkerAsync(xParam);
                    break;
            }
        }

        void getMail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        void getMail_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] xParam = (object[])e.Argument;
            Checker checker = new Checker();

            oMail = checker.getMail((int)xParam[0], (int)xParam[1]);
        }

        void deleteMail_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] xParam = (object[])e.Argument;
            Checker checker = new Checker();

            checker.deleteMail((int)xParam[0]);
        }

    }
}
