using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using com.sbs.dll.utilites;

namespace com.sbs.dll.mailChecker
{
    public partial class fMain : Form
    {
        DBAccess dbAccess = new DBAccess();

        DTO.MailBox oMailBox = new DTO.MailBox();
        List<DTO.Mail> oMail = new List<DTO.Mail>();
        Checker checker = new Checker();

        DataTable dtConfig;

        int curMail = 1;

        public fMain()
        {
            InitializeComponent();

            dataGridView_postBox.AutoGenerateColumns = false;

            tSButton_recive.Image = com.sbs.dll.utilites.Properties.Resources.refresh_26;
            tSButton_delete.Image = com.sbs.dll.utilites.Properties.Resources.delete_26_1;
            tSButton_config.Image = com.sbs.dll.utilites.Properties.Resources.config_26;

            button_previos.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.left_26;
            button_next.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.right_26;
        }

        private void tSButton_recive_Click(object sender, EventArgs e)
        {
            dataGridView_postBox.SelectionChanged -= new EventHandler(dataGridView_postBox_SelectionChanged);

            fFormWaiting fWaiting = new fFormWaiting("getMail", new object[] { 1, GValues.mailMax });
            fWaiting.ShowDialog();
            oMail = fWaiting.oMail;

            dataGridView_postBox.DataSource = oMail;
            dataGridView_postBox.Columns["dateIncoming"].DataPropertyName = "date";
            dataGridView_postBox.Columns["from"].DataPropertyName = "from";
            dataGridView_postBox.Columns["subject"].DataPropertyName = "subject";
            dataGridView_postBox.Columns["body"].DataPropertyName = "body";
            dataGridView_postBox.Columns["messageNumber"].DataPropertyName = "messageNumber";

            dataGridView_postBox.Refresh();

            dataGridView_postBox.SelectionChanged +=new EventHandler(dataGridView_postBox_SelectionChanged);
        }

        private void dataGridView_postBox_SelectionChanged(object sender, EventArgs e)
        {
            webBrowser_content.DocumentText = "";
            webBrowser_content.DocumentText = dataGridView_postBox.SelectedRows[0].Cells["body"].Value.ToString();
        }

        private void tSButton_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_postBox.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите сообщение помечаемое как удаленное.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_postBox.SelectedRows[0];

            if (MessageBox.Show("Вы действительно хотите удалить сообщение:" + Environment.NewLine +
                            "дата: '" + dr.Cells["dateIncoming"].Value.ToString() + "'" + Environment.NewLine +
                            "от: '" + dr.Cells["from"].Value.ToString() + "'" + Environment.NewLine +
                            "тема: '" + dr.Cells["subject"].Value.ToString() + "'",GValues.prgNameFull,MessageBoxButtons.YesNo,MessageBoxIcon.Information) 
                            != DialogResult.Yes)
            {
                return;
            }

            fFormWaiting fWaiting = new fFormWaiting("deleteMail", new object[] { (int)dr.Cells["messageNumber"].Value});
            fWaiting.ShowDialog();

        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            //getConfig();
        }

        //private void getConfig()
        //{
        //    try
        //    {
        //        dtConfig = dbAccess.getMailClientConfig("offline");
        //    }
        //    catch (Exception exc)
        //    {
        //        uMessage.Show("Неудалось поучить конфигурацию почтового модуля.", exc, SystemIcons.Information);
        //        foreach (Control ctr in this.Controls) ctr.Enabled = false;
        //        return;
        //    }
        //}

        private void tSButton_config_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            fConfig fConf;

            try { dt = dbAccess.getMailClientConfig("offline"); }
            catch (Exception exc)
            {
                foreach (Control ctr in this.Controls)
                {
                    ctr.Enabled = false;
                }
                uMessage.Show("Неудалось загрузить параметры.", exc, SystemIcons.Information);
                return;
            }

            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
                fConf = new fConfig(dr["ring_name"].ToString(), (int)dr["maxMail"], (int)dr["chkSec"]);
            }
            else
            {
                fConf = new fConfig();
            }
                
            fConf.ShowDialog();
        }
    }
}
