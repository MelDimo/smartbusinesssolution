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
using CrystalDecisions.CrystalReports.Engine;
using System.Reflection;

namespace com.sbs.gui.dashboard
{
    public partial class fSplash : Form
    {
        private DBaccess dbAccess = new DBaccess();
        Suppurt Supp = new Suppurt();

        private com.sbs.dll.DTO_DBoard.SeasonBranch[] oSeasonBranchArray;
        private com.sbs.dll.DTO_DBoard.User oUser;

        Thread trReadCard;

        private int xPriv = 0;
        private string xErrMessage = string.Empty;

        //DataTable dtResult;

        public fSplash()
        {
            trReadCard = new Thread(enterKey);

            InitializeComponent();

            foreach(Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                
                if (ass.GetModules()[0].Name.Equals("TimeTracking.dll"))
                {
                    DashboardEnvironment.assTimeTrack = ass;
                    break;
                }
            }


            // Подгружаем общие справочиники
            try
            {
                DashboardEnvironment.initRefDataTables();
                DashboardEnvironment.initPayment();
                DashboardEnvironment.initPrintersType();
            }
            catch (Exception exc) 
            { 
                uMessage.Show("Неудалось заполнить справочники."+ Environment.NewLine + "Модуль будет закрыт принудительно.", exc, SystemIcons.Information);
                Load += (s, e) => CloseForm();
                return;
            }

            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.splash_1;
        }

        private void CloseForm()
        {
            DashboardEnvironment.Clear();
            Close();
        }

        private void fSplash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt)
            {
                switch (e.KeyCode)
                {
                    // Закрытие индивидуально смены
                    case (Keys.F12):
                        if (DashboardEnvironment.gSeasonBranch == null)
                        {
                            MessageBox.Show("Заведение не заведено в смену." + Environment.NewLine + "Закрытие индивидуальной смены невозможно!", GValues.prgNameFull,
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

                            xPriv = 14; xErrMessage = "У Вас отсутствуют привилегии на закрытие индивидуальной смены.";

                            if (!Supp.checkPrivileges(DashboardEnvironment.gUser.oUserACL, xPriv))
                            {
                                MessageBox.Show(xErrMessage, GValues.prgNameFull,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            #endregion

                            fCloseSeason_User fCSB = new fCloseSeason_User(DashboardEnvironment.gUser);
                            if (fCSB.errMsg.Length > 0)
                            {
                                MessageBox.Show(fCSB.errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            fCSB.ShowDialog();
                            fCSB.Dispose();
                        }
                        break;
                }
            }
            else
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
                                if (showSeasonForm())
                                {
                                    showMainForm();
                                    GC.Collect();
                                }
                            }
                        }
                        break;

                    case Keys.Escape:
                        if (MessageBox.Show("Вы увеерены что хотите выйти?", GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            != DialogResult.Yes) return;
                        CloseForm();
                        break;

                    // Закрытие смены заведение
                    case Keys.F12:
                        if (DashboardEnvironment.gSeasonBranch == null)
                        {
                            MessageBox.Show("Заведение не заведено в смену." + Environment.NewLine + "Закрытие смены заведения невозможно!", GValues.prgNameFull,
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
                            fCSB.Dispose();
                        }
                        break;

                    case Keys.Home:
                        return;

                    case Keys.F6:   // Регистрация прихода/ухода
                        if (DashboardEnvironment.assTimeTrack == null)
                        {
                            MessageBox.Show("Данная конфигурация не предусматривает учет прихода/ухода сотрудников");
                            return;
                        }

                        Type type = DashboardEnvironment.assTimeTrack.GetType("com.sbs.gui.timetracking.fSplash", false, true);

                        Form form = (Form)Activator.CreateInstance(type);
                        form.ShowDialog();
                        form.Dispose();
                        break;

                    case Keys.F1:   // Помощь
                        fHelp fHLP = new fHelp();
                        fHLP.ShowDialog();
                        fHLP.Dispose();
                        break;
                }
            }
        }

        /// <summary>
        /// Получаем информацию о пользователе
        /// </summary>
        private void enterKey()
        {
            try
            {

                //--------------------------------------------------------------- Получаем информацию о пользователе
                switch (GValues.authortype)
                {
                    case 1:
                        fMIFare fMiFare = new fMIFare();
                        if (fMiFare.ShowDialog() == DialogResult.OK)
                        {

                                DashboardEnvironment.gUser = getUserByKey(fMiFare.keyId);
                                fMiFare.Dispose();

                        }
                        else
                            fMiFare.Dispose();
                        break;

                    case 2:
                        fLogin fl = new fLogin();
                        if (fl.ShowDialog() != DialogResult.OK) return;

                        DashboardEnvironment.gUser = getUserByPwd(fl.pwd);
                        fl.Dispose();

                        break;
                }
            }
            catch (Exception exc)
            {
                DashboardEnvironment.gUser = null;
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
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
                {
                    fseason.Dispose();
                    return true;
                }
                fseason.Dispose();
            }
            else
            {
                return true;
            }

            return false;
        }

        private void showMainForm()
        {
            DashboardEnvironment.gBillList = new List<com.sbs.dll.DTO_DBoard.Bill>();

            try
            {
                DashboardEnvironment.gBillList = dbAccess.getBills(GValues.DBMode, DashboardEnvironment.gUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            fMain fmain = new fMain();
            //fMain_lite fmain = new fMain_lite();
            fmain.ShowDialog();
            fmain.Dispose();
        }

        private DTO_DBoard.SeasonBranch[] getOpenSeason()
        {
            try
            {
                oSeasonBranchArray = dbAccess.getAvaliableSeason(GValues.DBMode);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return null; }

            return oSeasonBranchArray;
        }

        private DTO_DBoard.User getUserByKey(string pUserKey)
        {
            oUser = dbAccess.getMifareUser(GValues.DBMode, pUserKey);
            return oUser;
        }

        private DTO_DBoard.User getUserByPwd(string pPwd)
        {
            oUser = dbAccess.getLoginUser(GValues.DBMode, pPwd);
            return oUser;
        }
    }
}
