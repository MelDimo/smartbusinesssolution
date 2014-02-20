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

namespace com.sbs.gui.dashboard
{
    public partial class fCloseSeason_User : Form
    {
        private DBaccess dbAccess = new DBaccess();
        List<SeasonUser> lSeasonUser;

        User oUser;

        public string errMsg;

        public fCloseSeason_User(User pUser)
        {
            oUser = pUser;

            InitializeComponent();

            getSeasonUser();
        }

        private void getSeasonUser()
        {
            try
            {
                lSeasonUser = dbAccess.getSeasonUser("offline", oUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            label_season.Text += DashboardEnvironment.gSeasonBranch.seasonID;
            label_seasonFIO.Text = DashboardEnvironment.gSeasonBranch.userName;
            label_seasonPeriod.Text = DashboardEnvironment.gSeasonBranch.dateOpen.ToString();

            foreach (SeasonUser oSeasonUser in lSeasonUser)
            {
                if (oSeasonUser.refStatus == 17) // Смена закрыта
                {
                    errMsg = "У данного сотрудника, в текущей смене заведения, открытых индивидуальных смен нет.";
                    return;
                }

                label_season.Text += oSeasonUser.id.ToString();
                label_seasonFIO.Text = oSeasonUser.userOpenName;
                label_seasonPeriod.Text = oSeasonUser.dateOpen.ToString();

                numericUpDown_season.Value = oSeasonUser.summ;
            }

        }

        private void button_closeSeason_Click(object sender, EventArgs e)
        {

            if (closeSeason())
                DialogResult = DialogResult.OK;
        }

        private bool closeSeason()
        {
            try
            {
                dbAccess.seasonUser_Close("offline", oUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось закрыть индивидуальную смену." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return false;
            }

            MessageBox.Show(oUser.name + Environment.NewLine + "Индивидуальная смена закрыта.",
                GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        private void fCloseSeason_User_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Enter:
                    if (numericUpDown_curr.Focused)
                        SendKeys.Send("{TAB}");
                    break;
            }
        }

        private void numericUpDown_curr_Enter(object sender, EventArgs e)
        {
            numericUpDown_curr.Select(0, numericUpDown_curr.Text.Length);
        }

        private void numericUpDown_curr_Leave(object sender, EventArgs e)
        {
            decimal dBuff;

            if (decimal.TryParse(numericUpDown_curr.Value.ToString(), out dBuff))
            {
                numericUpDown_diff.Value = numericUpDown_season.Value - dBuff;
            }
        }
    }
}
