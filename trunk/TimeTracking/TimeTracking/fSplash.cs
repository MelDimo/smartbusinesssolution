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
    public partial class fSplash : Form
    {
        private static DBaccess DbAccess = new DBaccess();
        static curUser cUser = new curUser();

        public fSplash()
        {
            InitializeComponent();

            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.splash;
        }

        private void fSplash_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    runProgramm();
                    break;

                case Keys.Escape:
                    if (MessageBox.Show("Вы уверены, что хотите завершить выполнение модуля 'Регистрации прихода/ухода сотр.'?",
                        GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                        return;
                    Close();
                    break;
            }
        }

        private void runProgramm()
        {
            switch (GValues.authortype)
            {
                case 1:
                    if (!mifareAccess()) { return; }
                    break;
                case 2:
                    if (!logInAccess()) { return; }
                    break;
            }

            fMain fmain = new fMain(cUser);
            fmain.ShowDialog();
        }

        private bool logInAccess()
        {
            fLoginPWD flogin = new fLoginPWD();
            if (flogin.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cUser = DbAccess.getUserByLogIn("offline", flogin.xLogIn, flogin.xPwd);
                }
                catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return false; }
            }
            else
                return false;

            return true;
        }

        private bool mifareAccess()
        {
            fMIFare fMifare = new fMIFare();
            if (fMifare.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cUser = DbAccess.getUserByMifire("offline", fMifare.keyId);
                }
                catch (Exception exc) { uMessage.Show("Ошибка регистрации сотрудника." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return false; }
            }
            else
                return false;

            return true;
        }
    }
}
