using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fCloseSeason_Branch : Form
    {
        private DBaccess dbAccess = new DBaccess();
        List<SeasonUser> lSeasonUser = new List<SeasonUser>();
        SeasonUser oSeasonUser = new SeasonUser();
        ctrSeasonPerson ctrSUser;

        public fCloseSeason_Branch()
        {
            InitializeComponent();

            getSeasonUser();
        }

        private void getSeasonUser()
        {
            flowLayoutPanel_seasonPerson.Controls.Clear();

            try
            {
                lSeasonUser = dbAccess.getSeasonUser("offline");
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
                ctrSUser = new ctrSeasonPerson();
                ctrSUser.label_fio.Text = oSeasonUser.userOpenName;
                ctrSUser.label_dateOpenClose.Text = oSeasonUser.dateOpen.ToString() + " / " 
                                                    + oSeasonUser.dateClose == null ? "" : oSeasonUser.dateClose.ToString();
                
                ctrSUser.label_curStatus.Text = oSeasonUser.refStatusName;
                switch (oSeasonUser.refStatus)
                {
                    case 16:    // Смена открыта
                        ctrSUser.label_curStatus.ForeColor = Color.Red;
                        break;

                    case 17:
                        ctrSUser.label_curStatus.ForeColor = Color.Green;
                        break;  // Смена закрыта
                }

                ctrSUser.button_host.Click += new EventHandler(button_host_Click);
                ctrSUser.Width = flowLayoutPanel_seasonPerson.Width - 10;

                flowLayoutPanel_seasonPerson.Controls.Add(ctrSUser);
            }
            
        }

        void button_host_Click(object sender, EventArgs e)
        {
            
        }

        private void fCloseSeason_Branch_Shown(object sender, EventArgs e)
        {

        }

        private void fCloseSeason_Branch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void button_closeSeason_Click(object sender, EventArgs e)
        {
            if (closeSeason()) DialogResult = DialogResult.OK;
        }

        private bool closeSeason()
        {
            return true;
        }


    }
}
