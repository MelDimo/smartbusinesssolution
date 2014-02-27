using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.mailChecker;
using System.Threading;
using System.Diagnostics;

namespace Host4Test
{
    public partial class fMain : Form
    {
        ChkMailMain chkMail = new ChkMailMain();

        public fMain()
        {
            InitializeComponent();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            chkMail.run();
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
