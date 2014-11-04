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

namespace com.sbs.gui.deals
{
    public partial class fDeals : Form
    {
        DBAccess dbAccess = new DBAccess();
        DataTable dtDeals = new DataTable();

        public fDeals()
        {
            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;

            toolStripButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            toolStripButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            toolStripButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            if (!intiData()) return;

            setData();
            updateDeals();

            treeView_carte.AfterSelect += new TreeViewEventHandler(treeView_carte_AfterSelect);
        }

        void treeView_carte_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView_carte.SelectedNode.Tag == null) dtDeals.DefaultView.RowFilter = "carte = 0";
            else
                dtDeals.DefaultView.RowFilter = string.Format("carte = {0}",
                                                            ((DTO.Carte)treeView_carte.SelectedNode.Tag).id);
        }

        private void updateDeals()
        {
            try
            {
                dtDeals = dbAccess.getDeals_All(GValues.DBMode);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные по акциям.", exc, SystemIcons.Information);
                setEnabled(false);
            }

            dataGridView_main.DataSource = dtDeals;
            dataGridView_main.Columns["deals_id"].DataPropertyName = "id";
            dataGridView_main.Columns["deals_name"].DataPropertyName = "name";
            dataGridView_main.Columns["deals_dateStart"].DataPropertyName = "date_start";
            dataGridView_main.Columns["deals_dateEnd"].DataPropertyName = "date_end";
            dataGridView_main.Columns["deals_refStatus"].DataPropertyName = "refStatusName";
        }

        private bool intiData()
        {
            try
            {
                dbAccess.getReferences(GValues.DBMode);
                dtDeals = dbAccess.getDeals_All(GValues.DBMode);
            }
            catch (Exception exc) 
            { 
                uMessage.Show("Не удалось получить справочники.", exc, SystemIcons.Information);
                setEnabled(false);
                return false;
            }

            return true;
        }

        private void setEnabled(bool pEnable)
        {
            toolStrip_top.Enabled = pEnable;
        }

        private void setData()
        {
            foreach (DataRow dr in RefData.dtRefBranch.Rows)
            {
                TreeNode nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Name = string.Format("branch{0}", dr["id"].ToString());
                nodes.Tag = null;
                treeView_carte.Nodes.Add(nodes);
            }

            foreach (DataRow dr in RefData.dtRefCarte.Rows)
            {
                if ((int)dr["ref_status"] != 1) continue;

                DTO.Carte oCarte = new DTO.Carte()
                {
                    id = (int)dr["id"],
                    code = (int)dr["code"],
                    branch = (int)dr["branch"],
                    name = dr["name"].ToString(),
                    refStatus = (int)dr["ref_status"]
                };

                TreeNode nodesBranch = treeView_carte.Nodes.Find(string.Format("branch{0}", dr["branch"].ToString()), true)[0];
                TreeNode nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Tag = oCarte;
                nodesBranch.Nodes.Add(nodes);
            }

        }

        private void toolStripButton_add_Click(object sender, EventArgs e)
        {
            if (treeView_carte.SelectedNode == null) 
            { 
                MessageBox.Show("Укажите меню для которого желаете создать акцию", GValues.prgNameFull, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return;
            }

            if (treeView_carte.SelectedNode.Tag == null )
            {
                MessageBox.Show("Укажите меню для которого желаете создать акцию", GValues.prgNameFull,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DTO.Deals oDeals = new DTO.Deals();

            fDealsAddEdit fAddEdit = new fDealsAddEdit((DTO.Carte)treeView_carte.SelectedNode.Tag, oDeals);
            fAddEdit.Text = "Новая акция";
            fAddEdit.ShowDialog();
        }

        private void toolStripButton_edit_Click(object sender, EventArgs e)
        {
            DTO.Deals oDeals = new DTO.Deals();

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                oDeals = dbAccess.getDeal(GValues.DBMode, (int)dataGridView_main.SelectedRows[0].Cells["deals_id"].Value);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные по акции.", exc, SystemIcons.Information);
                return;
            }

            fDealsAddEdit fAddEdit = new fDealsAddEdit((DTO.Carte)treeView_carte.SelectedNode.Tag, oDeals);
            fAddEdit.Text = string.Format("Редактирование [{0}]", oDeals.name);
            fAddEdit.ShowDialog();
        }

        private void toolStripButton_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
