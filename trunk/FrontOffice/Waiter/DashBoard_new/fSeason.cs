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
        DBaccess DbAccess = new DBaccess();
        SeasonBranch[] oSeasonBranchArray;
        Button btnSeason;

        public fSeason(SeasonBranch[] pSeasonBranchArray)
        {
            oSeasonBranchArray = pSeasonBranchArray; 
            InitializeComponent();

            this.Text = GValues.prgNameFull;

            button_cancel.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.close_48;

            createContrlos();
        }

        private void createContrlos()
        {
            foreach (SeasonBranch sb in oSeasonBranchArray)
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
                DataRow dr = (DataRow)btn.Tag;
                GValues.openSeasonDate= dr["date_open"].ToString();
                GValues.openSeasonUserName = dr["fio"].ToString();
                GValues.openSeasonId = (int)dr["id"];
                openExistSeason((int)dr["id"]);
            }
        }

        private void openExistSeason(int pSeasonId)
        {

            closeForm(pSeasonId);
        }

        private void openNewSeason()
        {
            //try
            //{
            //    DbAccess.openNewSeason("offline");
            //}
            //catch (Exception exc)
            //{
            //    uMessage.Show("Не удалось получить данные по сменам", exc, SystemIcons.Information);
            //    return;
            //}

            //uMessage.Show("Смена создана!", SystemIcons.Information);
            //closeForm(0);
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
