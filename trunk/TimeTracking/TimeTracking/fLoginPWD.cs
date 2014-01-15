using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.timetracking
{
    public partial class fLoginPWD : Form
    {
        private DBaccess DbAccess = new DBaccess(); 
        public string xLogIn;
        public string xPwd;

        public fLoginPWD()
        {
            InitializeComponent();
        }

        private void fAuthorizeUser_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    Control ctl;
                    ctl = (Control)sender;
                    ctl.SelectNextControl(ActiveControl, true, true, true, true);
                    break;
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            xLogIn = textBox_name.Text;
            xPwd = textBox_pwd.Text;

            if ((xLogIn.Length * xPwd.Length) == 0)
            {
                MessageBox.Show("Поля 'Имя' и 'Пароль' являются обязательными для заполнения! O_o.", 
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
