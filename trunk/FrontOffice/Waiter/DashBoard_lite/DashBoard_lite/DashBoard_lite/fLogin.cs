using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.gui.dashboard
{
    public partial class fLogin : Form
    {
        public string pwd = string.Empty;

        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Enter:
                    if (textBox_pwd.Text.Length == 0) return;
                    pwd = textBox_pwd.Text.Trim();
                    DialogResult = DialogResult.OK;
                    break;
            }
        }
    }
}
