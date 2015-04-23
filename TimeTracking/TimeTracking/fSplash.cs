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
        private bool isPress = true;

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
                    if (isPress)
                    {
                        isPress = false;
                        runProgramm();
                    }
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
            cUser = new curUser();

            switch (GValues.authortype)
            {
                case 1:
                    if (!mifareAccess())
                    {
                        fMain fmain = new fMain(cUser);
                        fmain.ShowDialog();
                    }
                    break;
                case 2:
                    if (!logInAccess())
                    {
                        fMain fmain = new fMain(cUser);
                        fmain.ShowDialog();
                    }
                    break;
            }
        }

        private bool logInAccess()
        {
            fLoginPWD flogin = new fLoginPWD();
            if (flogin.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cUser = DbAccess.getUserByLogIn(GValues.DBMode, flogin.xLogIn, flogin.xPwd);
                }
                catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return false; }
            }
            else
                return false;

            return true;
        }

        private bool mifareAccess()
        {
            bool error = false;

            fMIFare fMifare = new fMIFare();
            if (fMifare.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cUser = DbAccess.getUserByMifire(GValues.DBMode, fMifare.keyId);
                }
                catch (Exception exc)
                {
                    uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                    error = true;
                }
            }
            else
            {
                error = true;
            }

            return error;
            
        }

        private void fSplash_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    isPress = true;
                    break;
            }
        }
    }
}
