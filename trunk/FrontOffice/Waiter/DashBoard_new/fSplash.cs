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

namespace com.sbs.gui.dashboard
{
    public partial class fSplash : Form
    {
        private DBaccess DbAccess = new DBaccess();

        private SeasonBranch[] oSeasonBranchArray;
        private User oUser;

        public fSplash()
        {
            InitializeComponent();

            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.splash_1;
        }

        private void fSplash_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    enterKey();
                    break;
            }
        }

        /// <summary>
        /// Получаем информацию о пользователе
        /// Получаем информацию об открытых сменах
        /// Получаем информацию о пользователе открывшем смену
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
                            DashboardEnveronvent.gUser = getUserByKey(fMiFare.keyId); 
                        }
                        catch (Exception exc)
                        {
                            uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                            return;
                        }
                    }
                    break;
                case 2:
                    MessageBox.Show("Авторизация по логину на данном этапе не доступна");
                    return;
            }
            //--------------------------------------------------------------- Получаем информацию об открытых сменах
            DashboardEnveronvent.gSeasonBranchArray
            oSeasonBranchArray = getOpenSeason();

            fSeason fseason = new fSeason(oSeasonBranchArray);
            fseason.ShowDialog();
        }

        private SeasonBranch[] getOpenSeason()
        {
            try
            {
                oSeasonBranchArray = DbAccess.getAvaliableSeason("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return null; }

            return oSeasonBranchArray;
        }

        private User getUserByKey(string pUserKey)
        {
            try
            {
                oUser = DbAccess.getMifareUser("offline", pUserKey);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return null; }

            return oUser;
        }
    }
}
