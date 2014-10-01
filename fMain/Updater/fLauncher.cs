using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace com.sbs.gui.launcher
{
    public partial class fLauncher : Form
    {
        public fLauncher()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {

        }

        private void fLauncher_Shown(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            updateFiles(UpdateParam.sourcePath);
        }

        private void updateFiles(string pSourcePath)
        {
            copyFiles(Directory.GetFiles(pSourcePath));
            foreach (string path in Directory.GetDirectories(pSourcePath))
            {
                updateFiles(path);
            }
        }

        private void copyFiles(string[] p)
        {
            string newFileName;
            foreach (string str in p)
            {
                newFileName = UpdateParam.destPath + str.Replace(UpdateParam.sourcePath,"");
                if (!Directory.Exists(Path.GetDirectoryName(newFileName))) 
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileName));
                File.Copy(str, newFileName, true);
            }
        }
    }
}
