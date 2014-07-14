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
        List<com.sbs.dll.DTO_DBoard.SeasonUser> lSeasonUser;
        
        List<com.sbs.dll.DTO_DBoard.Bill> lBills;
        ctrBill oCtrBill;

        com.sbs.dll.DTO_DBoard.User oUser;


        public string errMsg = string.Empty;

        public fCloseSeason_User(com.sbs.dll.DTO_DBoard.User pUser)
        {
            oUser = pUser;

            InitializeComponent();

            getSeasonUser();
        }

        private void getSeasonUser()
        {
            try
            {
                lSeasonUser = dbAccess.getSeasonUser(GValues.DBMode, oUser);
                lBills = dbAccess.getBills(GValues.DBMode, oUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            label_season.Text += DashboardEnvironment.gSeasonBranch.seasonID;
            label_seasonFIO.Text = DashboardEnvironment.gSeasonBranch.userName;
            label_seasonPeriod.Text = DashboardEnvironment.gSeasonBranch.dateOpen.ToString();

            foreach (com.sbs.dll.DTO_DBoard.SeasonUser oSeasonUser in lSeasonUser)
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

            foreach (com.sbs.dll.DTO_DBoard.Bill xBill in lBills)
            {
                oCtrBill = new ctrBill(xBill);
                //oCtrBill.label_numbBill.Text = xBill.numb.ToString();
                //oCtrBill.label_numbTable.Text = xBill.table.ToString();
                //oCtrBill.label_summ.Text = xBill.summ.ToString("F2");
                //oCtrBill.label_refStatusName.Text = xBill.refStatName;
                //switch (xBill.refStat)
                //{
                //    case 20:
                //        oCtrBill.label_refStatusName.ForeColor = Color.Red;
                //        oCtrBill.label_dateOpenClose.Text = xBill.openDate.ToString();
                //        break;
                //    case 21:
                //        oCtrBill.label_refStatusName.ForeColor = Color.Green;
                //        oCtrBill.label_dateOpenClose.Text = xBill.closeDate.ToString();
                //        break;
                //}

                oCtrBill.Width = flowLayoutPanel_bills.Width - 10;

                flowLayoutPanel_bills.Controls.Add(oCtrBill);
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
                dbAccess.seasonUser_Close(GValues.DBMode, oUser);
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
