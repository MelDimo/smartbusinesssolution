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

        private SeasonBranch[] oSeasonBranchArray;
        private User oUser;

        Thread trReadCard;

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
                        trReadCard = new Thread(enterKey);
                        trReadCard.Start();
                    }
                    Debug.Print("Keys.Enter");
                    break;

                case Keys.Escape:
                    if (MessageBox.Show("Вы увеерены что хотите выйти?", GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        != DialogResult.Yes) return;

                    DashboardEnvironment.Clear();
                    Close();
                    break;
            }
        }

        /// <summary>
        /// Получаем информацию о пользователе
        /// Получаем информацию об открытых сменах
        /// Заводим рабочее место в смену
        /// </summary>
        private void enterKey()
        {
            bool chkFlag = false;
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

            //--------------------------------------------------------------- Получаем информацию об открытых сменах
            if (DashboardEnvironment.gSeasonBranch == null) // рабочее место не в смене
            {
                oSeasonBranchArray = getOpenSeason();

                fSeason fseason = new fSeason(oSeasonBranchArray);
                if (fseason.ShowDialog() == DialogResult.OK) // Если определились со сменами, загружаю основное окно офиц части
                    chkFlag = true;
            }
            else
                chkFlag = true;

            if (chkFlag) showMainForm();//--------------------- Запускаем основную официантскую форму

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
