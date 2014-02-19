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
using System.Threading;
using System.Diagnostics;

namespace com.sbs.gui.dashboard
{
    public partial class fSplash : Form
    {
        private DBaccess dbAccess = new DBaccess();
        Suppurt Supp = new Suppurt();

        private SeasonBranch[] oSeasonBranchArray;
        private User oUser;

        Thread trReadCard;

        private int xPriv = 0;
        private string xErrMessage = string.Empty;

        public fSplash()
        {
            trReadCard = new Thread(enterKey);

            InitializeComponent();

            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.splash_1;
        }

        private void fSplash_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    if (!trReadCard.IsAlive)
                    {
                        DashboardEnvironment.gUser = null;

                        trReadCard = new Thread(enterKey);
                        trReadCard.Start();

                        trReadCard.Join();

                        if (DashboardEnvironment.gUser != null)
                        {
                            if (showSeasonForm()) showMainForm();
                        }
                    }
                    break;

                case Keys.Escape:
                    if (MessageBox.Show("Вы увеерены что хотите выйти?", GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        != DialogResult.Yes) return;

                    DashboardEnvironment.Clear();
                    Close();
                    break;

                    // Закрытие индивидуально смены
                case Keys.Alt | Keys.F12:
                    break;

                    // Закрытие смены заведение
                case Keys.F12:
                    if (DashboardEnvironment.gSeasonBranch == null)
                    {
                        MessageBox.Show("Заведение не заведено в смену." + Environment.NewLine + "Закрытие смены заведения не возможно!", GValues.prgNameFull,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (!trReadCard.IsAlive)
                    {
                        DashboardEnvironment.gUser = null;

                        trReadCard = new Thread(enterKey);
                        trReadCard.Start();

                        trReadCard.Join();

                        if (DashboardEnvironment.gUser == null) return; // Пользователь не авторизовался

                        #region проверка привелегий

                        if (DashboardEnvironment.gSeasonBranch.userID == DashboardEnvironment.gUser.id)
                        {                                               // Пытаемся закрыть в свою смену
                            xPriv = 2; xErrMessage = "У Вас отсутствуют привилегии на закрытие смены заведения, открытую ранее Вами.";
                        }
                        else
                        {                                               // Пытаемся закрыть чужую смену
                            xPriv = 13; xErrMessage = "У Вас отсутствуют привилегии на закрытие смены заведения, открытую ранее не Вами.";
                        }

                        if (!Supp.checkPrivileges(DashboardEnvironment.gUser.oUserACL, xPriv))
                        {
                            MessageBox.Show(xErrMessage, GValues.prgNameFull,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        #endregion

                        fCloseSeason_Branch fCSB = new fCloseSeason_Branch();
                        if (fCSB.ShowDialog() == DialogResult.OK)
                        {
                            DashboardEnvironment.Clear();
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Получаем информацию о пользователе
        /// </summary>
        private void enterKey()
        {
            //--------------------------------------------------------------- Получаем информацию о пользователе
            switch(GValues.authortype)
            {
                case 1:
                    fMIFare fMiFare = new fMIFare();
                    if (fMiFare.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            DashboardEnvironment.gUser = getUserByKey(fMiFare.keyId);
                        }
                        catch (Exception exc)
                        {
                            uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                            return;
                        }
                    }
                    else
                        return;
                    break;

                case 2:
                    MessageBox.Show("Авторизация по логину на данном этапе не доступна");
                    return;
            }

        }

        //--------------------------------------------------------------- Получаем информацию об открытых сменах
        private bool showSeasonForm()
        {
            if (DashboardEnvironment.gSeasonBranch == null) // рабочее место не в смене
            {
                oSeasonBranchArray = getOpenSeason();

                fSeason fseason = new fSeason(oSeasonBranchArray);
                if (fseason.ShowDialog() == DialogResult.OK) // Если определились со сменами, загружаю основное окно офиц части
                    return true;
            }
            else
                return true;

            return false;
        }

        private void showMainForm()
        {
            DashboardEnvironment.gBillList = new List<Bill>();

            try
            {
                DashboardEnvironment.gBillList = dbAccess.getBills("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            //fMain_old fmain = new fMain_old();
            fMain fmain = new fMain();
            fmain.ShowDialog();
        }

        private SeasonBranch[] getOpenSeason()
        {
            try
            {
                oSeasonBranchArray = dbAccess.getAvaliableSeason("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return null; }

            return oSeasonBranchArray;
        }

        private User getUserByKey(string pUserKey)
        {
            try
            {
                oUser = dbAccess.getMifareUser("offline", pUserKey);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return null; }

            return oUser;
        }
    }
}
