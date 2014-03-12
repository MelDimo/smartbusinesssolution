using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.users
{
    public partial class fUserMail : Form
    {
        DBaccess dbAccess = new DBaccess();

        public DataTable dtMail;
        public int userID = 0;
        public string userName = string.Empty;

        private string oldPwd = string.Empty;

        public fUserMail()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (saveData()) Close();
        }

        private bool saveData()
        {
            string sEmail = textBox_email.Text.Trim();
            string sLogIn = textBox_login.Text.Trim();
            string sPwd = textBox_pwd.Text.Trim();
            

            if ((sEmail.Length * sLogIn.Length * sPwd.Length) == 0)
            {
                MessageBox.Show("Заполнены не все обязательные поля.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try 
            {
                dbAccess.saveEmailUser("offline", new object[] { userID, sEmail, sLogIn, sPwd });
            }
            catch (Exception exc) { uMessage.Show("Неудалось сохранить данные.", exc, SystemIcons.Information); return false; }

            return true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fUserMail_Shown(object sender, EventArgs e)
        {
            label_fio.Text = userName;

            if (dtMail.Rows.Count > 0)
            {
                textBox_email.Text = dtMail.Rows[0]["email"].ToString();
                textBox_login.Text = dtMail.Rows[0]["login"].ToString();
                textBox_pwd.Text = dtMail.Rows[0]["pwd"].ToString();

                oldPwd = textBox_pwd.Text;
            }
        }
    }
}
