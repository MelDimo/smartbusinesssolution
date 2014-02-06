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
    public partial class fSeason : Form
    {
        DBaccess dbAccess = new DBaccess();
        Suppurt Supp = new Suppurt();

        Button btnSeason;

        public fSeason(SeasonBranch[] pSeasonBranchArray)
        {
            InitializeComponent();

            this.Text = GValues.prgNameFull;

            button_cancel.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.close_48;

            createContrlos(pSeasonBranchArray);
        }

        private void createContrlos(SeasonBranch[] pSeasonBranchArray)
        {
            foreach (SeasonBranch sb in pSeasonBranchArray)
            {
                btnSeason = new Button();
                btnSeason.BackColor = Color.FromArgb(255, 255, 196);
                btnSeason.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                btnSeason.UseVisualStyleBackColor = false;
                btnSeason.TextAlign = ContentAlignment.MiddleLeft;
                btnSeason.Height = 150;
                btnSeason.Width = 150;
                btnSeason.Click += new EventHandler(btnSeason_Click);
                btnSeason.Text = "Смена: " + sb.seasonID.ToString() + Environment.NewLine +
                                "Открыта: " + sb.dateOpen.ToString() + Environment.NewLine +
                                sb.userName;
                btnSeason.Tag = sb;
                panel_holder.Controls.Add(btnSeason);
            }

            btnSeason = new Button();
            btnSeason.BackColor = Color.FromArgb(196, 255, 196);
            btnSeason.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            btnSeason.UseVisualStyleBackColor = false;
            btnSeason.Click += new EventHandler(btnSeason_Click);
            btnSeason.Height = 150;
            btnSeason.Width = 150;
            btnSeason.Text = "Новая смена";
            btnSeason.Tag = null;

            panel_holder.Controls.Add(btnSeason);
        }

        void btnSeason_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Tag == null){
                openNewSeason();
            }
            else{
                openExistSeason((SeasonBranch)btn.Tag);
            }
        }

        private void openExistSeason(SeasonBranch pSeasonBranch)
        {
            int xPriv = 0;
            string xErrMessage = string.Empty;

            if (pSeasonBranch.userID == DashboardEnvironment.gUser.id){ // Пытаемся войти в свою, открытую ранее смену
                xPriv = 10; xErrMessage = "У Вас отсутствуют привилегии на ввод заведения в открытую Вами ранее смену.";
            }
            else{                                                        // Пытаемся войти в чужую, открытую ранее смену
                xPriv = 11; xErrMessage = "У Вас отсутствуют привилегии на ввод заведения в чужую, открытую ранее смену.";
            }

            if (!Supp.checkPrivileges(DashboardEnvironment.gUser.oUserACL, xPriv))
            {
                MessageBox.Show(xErrMessage, GValues.prgNameFull,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DashboardEnvironment.gSeasonBranch = pSeasonBranch;

            MessageBox.Show("Рабочее место заведено в смену № " + DashboardEnvironment.gSeasonBranch.seasonID +
                                                Environment.NewLine + "Смена открыта: " + DashboardEnvironment.gSeasonBranch.dateOpen +
                                                Environment.NewLine + "Администратор: " + DashboardEnvironment.gSeasonBranch.userName +
                                                Environment.NewLine + "Удачного дня!",
                                                GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            closeForm(0);
        }

        private void openNewSeason()
        {
            if (!Supp.checkPrivileges(DashboardEnvironment.gUser.oUserACL, 1))
            {
                MessageBox.Show("У Вас отсутствуют привилегии на открытие смены заведения.", GValues.prgNameFull, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                dbAccess.openNewSeason("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось открыть новую смену.", exc, SystemIcons.Information);
                return;
            }

            MessageBox.Show("Смена создана!" + Environment.NewLine + "Рабочее место заведено в смену № " + DashboardEnvironment.gSeasonBranch.seasonID +
                                                Environment.NewLine + "Смена открыта: " + DashboardEnvironment.gSeasonBranch.dateOpen +
                                                Environment.NewLine + "Администратор: " + DashboardEnvironment.gSeasonBranch.userName +
                                                Environment.NewLine + "Удачного дня!",
                                                GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            closeForm(0);
                
        }

        private void closeForm(int pCloseParam)
        {
            switch(pCloseParam)
            {
                case 0:
                    DialogResult = DialogResult.Cancel;
                    break;

                default:
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            closeForm(0);
        }

        private void fSeason_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    closeForm(0);
                    break;
            }
        }
    }
}
