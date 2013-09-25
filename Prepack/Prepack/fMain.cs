using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using com.sbs.dll.utilites;
using com.sbs.dll;
using System.Data.SqlClient;

namespace com.sbs.gui.prepack
{
    public partial class fMain : Form
    {
        private DBaccess dbAccess = new DBaccess();

        private DataTable dtOrg;
        private DataTable dtBranch;
        private DataTable dtUnit;
        private DataTable dtStatus;

        private int xSelectedPrepack;

        public fMain()
        {

            InitializeComponent();

            dataGridView_prepackMain.AutoGenerateColumns = false;
            dataGridView_prepack.AutoGenerateColumns = false;
            dataGridView_goods.AutoGenerateColumns = false;
            
            loadIcons();

            loadCompOrg();
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            comboBox_unit.SelectedIndexChanged += new EventHandler(comboBox_unit_SelectedIndexChanged);
            comboBox_branch.SelectedIndexChanged += new EventHandler(comboBox_branch_SelectedIndexChanged);
            comboBox_org.SelectedIndexChanged += new EventHandler(comboBox_org_SelectedIndexChanged);
        }

        private void loadIcons()
        {
            tSButton_addPrepackMain.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_editPrepackMain.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_delPrepackMain.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_addGoods.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_delGoods.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_addPrepack.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_delPrepack.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            button_filter.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.filter_26;

            tSButton_dublicate.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;
        }

        private void loadCompOrg()
        {
            dtOrg = new DataTable();
            dtBranch = new DataTable();
            dtUnit = new DataTable();
            dtStatus = new DataTable();

            try
            {
                dtOrg = dbAccess.getOrganipation("offline");
                dtBranch = dbAccess.getBranch("offline");
                dtUnit = dbAccess.getUnit("offline");

                dtStatus = new getReference().getStatus("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

            comboBox_unit.DataSource = dtUnit;
            comboBox_unit.ValueMember = "id";
            comboBox_unit.DisplayMember = "name";

            comboBox_branch.DataSource = dtBranch;
            comboBox_branch.ValueMember = "id";
            comboBox_branch.DisplayMember = "name";

            comboBox_org.DataSource = dtOrg;
            comboBox_org.ValueMember = "id";
            comboBox_org.DisplayMember = "name";
        }

        private void updatePrepackMain()
        {
            clearDGV();

            DataTable dt = new DataTable();
            int xIdUnit = (int)comboBox_unit.SelectedValue;

            try 
            {
                dt = dbAccess.getPrepack("offline", xIdUnit);
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

            dataGridView_prepackMain.Columns["prepackmain_id"].DataPropertyName = "id";
            dataGridView_prepackMain.Columns["prepackmain_code"].DataPropertyName = "code";
            dataGridView_prepackMain.Columns["prepackmain_name"].DataPropertyName = "name";
            dataGridView_prepackMain.Columns["prepackmain_ref_status"].DataPropertyName = "ref_status";
            dataGridView_prepackMain.Columns["prepackmain_ref_status_name"].DataPropertyName = "ref_status_name";
            dataGridView_prepackMain.DataSource = dt;

        }

        private void clearDGV()
        {
            dataGridView_prepackMain.DataSource = null;
            dataGridView_goods.DataSource = null;
            dataGridView_prepack.DataSource = null;
        }

        private void getPrepackInfo()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = dbAccess.getPrepackInfo("offline", xSelectedPrepack);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }

            dataGridView_prepack.DataSource = ds.Tables["PREPACK"];
            dataGridView_prepack.Columns["prepack_id"].DataPropertyName = "id";
            dataGridView_prepack.Columns["prepack_code"].DataPropertyName = "code";
            dataGridView_prepack.Columns["prepack_name"].DataPropertyName = "name";
            dataGridView_prepack.Columns["prepack_status"].DataPropertyName = "ref_status";
            dataGridView_prepack.Columns["prepack_status_name"].DataPropertyName = "ref_status_name";

            dataGridView_goods.DataSource = ds.Tables["GOODS"];
            dataGridView_goods.Columns["goods_id"].DataPropertyName = "id";
            dataGridView_goods.Columns["goods_code"].DataPropertyName = "code";
            dataGridView_goods.Columns["goods_name"].DataPropertyName = "name";
            dataGridView_goods.Columns["goods_manufacturer"].DataPropertyName = "manufacturer";
            dataGridView_goods.Columns["goods_status"].DataPropertyName = "ref_status";
            dataGridView_goods.Columns["goods_status_name"].DataPropertyName = "ref_status_name";

        }

        private void comboBox_org_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearDGV();

            string filter;

            if (comboBox_org.SelectedValue.ToString().Equals("0"))
                filter = "";
            else
                filter = string.Format("organization = '{0}'", comboBox_org.SelectedValue.ToString());

            (comboBox_branch.DataSource as DataTable).DefaultView.RowFilter = filter;

            comboBox_branch_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void comboBox_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearDGV();

            string filter;

            if (comboBox_branch.SelectedValue.ToString().Equals("0"))
                filter = "";
            else
                filter = string.Format("branch = '{0}'", comboBox_branch.SelectedValue.ToString());

            (comboBox_unit.DataSource as DataTable).DefaultView.RowFilter = filter;

            comboBox_unit_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void comboBox_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearDGV();

            if (comboBox_unit.SelectedValue == null) button_filter.Enabled = false;
            else button_filter.Enabled = true;
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            updatePrepackMain();
        }

        #region PrepackMain

        private void tSButton_addPrepackMain_Click(object sender, EventArgs e)
        {
            int xOrg = 0;
            int xBranch = 0;
            int xUnit = 0;

            if (comboBox_org.Text.Length != 0) xOrg = (int)comboBox_org.SelectedValue;
            if (comboBox_branch.Text.Length != 0) xBranch = (int)comboBox_branch.SelectedValue;
            if (comboBox_unit.Text.Length != 0) xUnit = (int)comboBox_unit.SelectedValue;

            DTO.Prepack oPrepack = new DTO.Prepack();
            oPrepack.Org = xOrg;
            oPrepack.Branch = xBranch;
            oPrepack.Unit = xUnit;

            fAddPrepack_Main faddprepackmain = new fAddPrepack_Main(dtOrg.Copy(), dtBranch.Copy(), dtUnit.Copy(), dtStatus.Copy(), oPrepack);
            if (faddprepackmain.ShowDialog() == DialogResult.OK) updatePrepackMain();
        }

        private void tSButton_editPrepackMain_Click(object sender, EventArgs e)
        {

            if (dataGridView_prepackMain.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите редактируемый элемент", SystemIcons.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_prepackMain.SelectedRows[0];

            int xOrg = 0;
            int xBranch = 0;
            int xUnit = 0;

            if (comboBox_org.Text.Length != 0) xOrg = (int)comboBox_org.SelectedValue;
            if (comboBox_branch.Text.Length != 0) xBranch = (int)comboBox_branch.SelectedValue;
            if (comboBox_unit.Text.Length != 0) xUnit = (int)comboBox_unit.SelectedValue;

            DTO.Prepack oPrepack = new DTO.Prepack();
            oPrepack.Org = xOrg;
            oPrepack.Branch = xBranch;
            oPrepack.Unit = xUnit;

            oPrepack.Id = (int)dr.Cells["prepackmain_id"].Value;
            oPrepack.Name = dr.Cells["prepackmain_name"].Value.ToString();
            oPrepack.Status = (int)dr.Cells["prepackmain_ref_status"].Value;
            oPrepack.Code = dr.Cells["prepackmain_code"].Value.ToString();

            fAddPrepack_Main faddprepackmain = new fAddPrepack_Main(dtOrg.Copy(), dtBranch.Copy(), dtUnit.Copy(), dtStatus.Copy(), oPrepack);
            if (faddprepackmain.ShowDialog() == DialogResult.OK) updatePrepackMain();
        }

        private void tSButton_delPrepackMain_Click(object sender, EventArgs e)
        {
            if (dataGridView_prepackMain.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите удаляемый элемент", SystemIcons.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены что шотите удалить элемент '" +
                dataGridView_prepackMain.SelectedRows[0].Cells["prepackmain_name"].Value.ToString() + "'",
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int xId = (int)dataGridView_prepackMain.SelectedRows[0].Cells["prepackmain_id"].Value;

            try
            {
                dbAccess.delPrepackMain("offline", xId);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }

            updatePrepackMain();
        }

        private void dataGridView_prepackMain_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;

            DataGridView dgv = sender as DataGridView;

            if (dgv.SelectedRows.Count == 0)
            {
                toolStrip_goods.Enabled = false;
                toolStrip_prepack.Enabled = false;
                xSelectedPrepack = 0;
            }
            else
            {
                xSelectedPrepack = (int)dgv.SelectedRows[0].Cells["prepackmain_id"].Value;
                try
                {
                    getPrepackInfo();
                }
                catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

                toolStrip_goods.Enabled = true;
                toolStrip_prepack.Enabled = true;
            }
        }

        #endregion

        #region Goods

        private void tSButton_addGoods_Click(object sender, EventArgs e)
        {
            fAddGoods faddgoods = new fAddGoods();
            faddgoods.selectedPrepack = xSelectedPrepack;
            if (faddgoods.ShowDialog() == DialogResult.OK) getPrepackInfo();
        }

        private void tSButton_delGoods_Click(object sender, EventArgs e)
        {
            if (dataGridView_goods.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите удаляемый элемент", SystemIcons.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены что шотите удалить элемент '" +
                dataGridView_goods.SelectedRows[0].Cells["goods_name"].Value.ToString() + "'",
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int xIdGoods = (int)dataGridView_goods.SelectedRows[0].Cells["goods_id"].Value;

            try
            {
                dbAccess.delGoodsInfo("offline", xSelectedPrepack, xIdGoods);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }

            getPrepackInfo();
        }

        #endregion

        #region Prepack

        private void tSButton_addPrepack_Click(object sender, EventArgs e)
        {
            int xIdUnit = (int)comboBox_unit.SelectedValue;
            fAddPrepack faddprepack = new fAddPrepack(xIdUnit);
            faddprepack.selectedPrepack = xSelectedPrepack;
            if (faddprepack.ShowDialog() == DialogResult.OK) getPrepackInfo();
        }

        private void tSButton_delPrepack_Click(object sender, EventArgs e)
        {
            if (dataGridView_prepack.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите удаляемый элемент", SystemIcons.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены что шотите удалить элемент '" +
                dataGridView_prepack.SelectedRows[0].Cells["prepack_name"].Value.ToString() + "'",
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int xIdPrepack = (int)dataGridView_prepack.SelectedRows[0].Cells["prepack_id"].Value;

            try
            {
                dbAccess.delPrepackInfo("offline", xSelectedPrepack, xIdPrepack);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }

            getPrepackInfo();
        }

        #endregion

    }
}
