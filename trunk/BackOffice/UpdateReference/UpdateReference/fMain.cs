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
using System.Threading;

namespace com.sbs.gui.updatereference
{
    public partial class fMain : Form
    {
        DBAccess dbAccess = new DBAccess();
        DataTable dtCategory;
        List<BackgroundWorker> lWorkers = new List<BackgroundWorker>();
        int countActiveThread;

        public fMain()
        {
            InitializeComponent();

            toolStripButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            toolStripButton_remove.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            getData();
        }

        private void getData()
        {
            
            try
            {
                dtCategory = dbAccess.getUpdateCategory(GValues.DBMode);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные.", exc, SystemIcons.Information);
                return;
            }

            foreach(DataRow dr in dtCategory.Rows)
            {
                checkedListBox_type.Items.Add(new DTO_Updater.Category() 
                { 
                    id = (int)dr["id"],
                    name = dr["name"].ToString(), 
                    script = dr["script"].ToString() 
                });
            }
        }

        private void toolStripButton_add_Click(object sender, EventArgs e)
        {
            DTO_Updater.Branch oBranch = new DTO_Updater.Branch();

            fChooserUnit fChoose = new fChooserUnit(1, 1);
            if (fChoose.ShowDialog() != DialogResult.OK) return;

            try
            {
                oBranch = dbAccess.getBranchInfo(GValues.DBMode, fChoose.selectedId);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные.", exc, SystemIcons.Information);
                return;
            }

            oBranch.name = fChoose.selectedName;

            foreach (Control ctr in flowLayoutPanel_branch.Controls)
            {
                if (((ctrBranchUpdate)ctr).oBranch.id == oBranch.id) 
                {
                    ((ctrBranchUpdate)ctr).button_host.Select();
                    return; 
                }
            }

            ctrBranchUpdate ctrBrabch = new ctrBranchUpdate(oBranch);
            ctrBrabch.Width = flowLayoutPanel_branch.Width - 25;
            ctrBrabch.Dock = DockStyle.Top;
            flowLayoutPanel_branch.Controls.Add(ctrBrabch);
            ctrBrabch.button_host.Select();
        }

        private void toolStripButton_remove_Click(object sender, EventArgs e)
        {
            ctrBranchUpdate ctrBranch;
            DTO_Updater.Branch oBranch = null;
            Control ctr4Remove = null;

            foreach (Control ctr in flowLayoutPanel_branch.Controls)
            {
                ctrBranch = (ctrBranchUpdate)ctr;
                if (ctrBranch.button_host.Focused) 
                {
                    ctr4Remove = ctr;
                    oBranch = ctrBranch.oBranch;
                    break;
                }
            }

            if (oBranch == null) 
            {
                MessageBox.Show("Укажите элемент который желаете исключить.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(string.Format("Вы действительно хотите исключить заведение '{0}' ?", oBranch.name), 
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            ctr4Remove.Dispose();
            flowLayoutPanel_branch.Refresh();
        }

        private void flowLayoutPanel_branch_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctr in flowLayoutPanel_branch.Controls)
            {
                ctr.Width = flowLayoutPanel_branch.Width - 25;
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            ctrBranchUpdate ctrBranch = null;

            foreach (Control ctr in flowLayoutPanel_branch.Controls)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerSupportsCancellation = true;
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);

                ctrBranch = (ctrBranchUpdate)ctr;
                ctrBranch.progressBar_info.Style = ProgressBarStyle.Marquee;
                ctrBranch.progressBar_info.Value = ctrBranch.progressBar_info.Minimum;
                ctrBranch.progressBar_info.MarqueeAnimationSpeed = 20;

                worker.RunWorkerAsync(ctrBranch);

                lWorkers.Add(worker);
            }

            countActiveThread = lWorkers.Count;
            button_export.Enabled = false;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<DTO_Updater.Category, Exception> dicExc = new Dictionary<DTO_Updater.Category, Exception>();

            ctrBranchUpdate ctrBranch = e.Argument as ctrBranchUpdate;
            foreach (object itemChecked in checkedListBox_type.CheckedItems)
            {
                Exception xExc = null;
                try
                {
                    executeScript(((DTO_Updater.Category)itemChecked), ctrBranch.oBranch);
                }
                catch (Exception exc) { xExc = exc; }

                dicExc.Add((DTO_Updater.Category)itemChecked, xExc);
            }
            e.Result = new object[] { ctrBranch, dicExc };
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object[] result = e.Result as object[];

            ctrBranchUpdate ctrBranch = (ctrBranchUpdate)result[0];
            Dictionary<DTO_Updater.Category, Exception> dicExc = (Dictionary<DTO_Updater.Category, Exception>)result[1];

            foreach (Exception exc in dicExc.Values)
            {
                if (exc != null)
                {
                    ctrBranch.oDCategiryExc = dicExc;
                    ctrBranch.button_error.Visible = true;
                }
                else
                {
                    ctrBranch.button_error.Visible = false; ;
                }
            }

            ctrBranch.progressBar_info.MarqueeAnimationSpeed = 0;
            ctrBranch.progressBar_info.Style = ProgressBarStyle.Blocks;
            ctrBranch.progressBar_info.Value = ctrBranch.progressBar_info.Maximum;

            cancelWorking();
        }

        private void cancelWorking()
        {
            countActiveThread = countActiveThread - 1;
            if (countActiveThread == 0) button_export.Enabled = true;
        }

        private void executeScript(DTO_Updater.Category pCategory, DTO_Updater.Branch pBranch)
        {
            DBAccess dbAccessThread = new DBAccess();
            string xScript = string.Empty;

            switch (pCategory.name)
            {
                case "Сотрудники":
                    xScript = string.Format(pCategory.script, pBranch.getPath());
                    break;

                case  "Меню":
                    xScript = string.Format(pCategory.script, pBranch.id, pBranch.getPath());
                    break;
            }

            dbAccessThread.executeScript(GValues.DBMode, xScript);
        }

        private void tSButton_script_Click(object sender, EventArgs e)
        {
            if (checkedListBox_type.SelectedItems.Count == 0)
            {
                MessageBox.Show("Укажите категорию для редактирования", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DTO_Updater.Category oCategory = (DTO_Updater.Category)checkedListBox_type.SelectedItem;

            fEditScript fScript = new fEditScript();
            fScript.oCategory = oCategory;
            if (fScript.ShowDialog() != DialogResult.OK) return;


        }
    }
}
