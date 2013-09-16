using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll.dto;
using com.sbs.dll;

namespace com.sbs.gui.compositionorg
{
    public partial class fCompOrg : Form
    {
        DBaccess dbAccess = new DBaccess();

        private DataTable dtOrg = new DataTable();
        private DataTable dtBranch = new DataTable();
        private DataTable dtUnit = new DataTable();
        private DataTable dtStatus = new DataTable();
        private DataTable dtCity = new DataTable();

        public fCompOrg()
        {
            InitializeComponent();

            dataGridView_org.AutoGenerateColumns = false;
            dataGridView_branch.AutoGenerateColumns = false;
            dataGridView_unit.AutoGenerateColumns = false;

            initData();
        }

        private void initData()
        {
            DBaccess dbAccess = new DBaccess();
            try
            {
                dtOrg = dbAccess.getOrganization("offline");
                dtBranch = dbAccess.getBranch("offline");
                dtUnit = dbAccess.getUnit("offline");
                dtStatus = dbAccess.getStatus("offline");
                dtCity = dbAccess.getCity("offline");
            }
            catch (Exception exc) { uMessage.Show("Невозможно получить данные!", exc, SystemIcons.Error); Close(); }

            dataGridView_org.DataSource = dtOrg;
            dataGridView_org.Columns["org_id"].DataPropertyName = "id";
            dataGridView_org.Columns["org_name"].DataPropertyName = "name";
            dataGridView_org.Columns["org_ref_status"].DataPropertyName = "ref_status";
            dataGridView_org.Columns["org_ref_status_name"].DataPropertyName = "ref_status_name";

            dataGridView_branch.DataSource = dtBranch;
            dataGridView_branch.Columns["branch_id"].DataPropertyName = "id";
            dataGridView_branch.Columns["branch_name"].DataPropertyName = "name";
            dataGridView_branch.Columns["branch_ref_status"].DataPropertyName = "ref_status";
            dataGridView_branch.Columns["branch_ref_city"].DataPropertyName = "ref_city";
            dataGridView_branch.Columns["branch_organization"].DataPropertyName = "organization";
            dataGridView_branch.Columns["branch_ref_status_name"].DataPropertyName = "ref_status_name";

            dataGridView_unit.DataSource = dtUnit;
            dataGridView_unit.Columns["unit_id"].DataPropertyName = "id";
            dataGridView_unit.Columns["unit_name"].DataPropertyName = "name";
            dataGridView_unit.Columns["unit_branch"].DataPropertyName = "branch";
            dataGridView_unit.Columns["unit_ref_status_name"].DataPropertyName = "ref_status_name";
            dataGridView_unit.Columns["unit_ref_status"].DataPropertyName = "ref_status";

        }

        #region Organization

        private void tSButton_orgAdd_Click(object sender, EventArgs e)
        {
            fAddEdit_org faddeditorg = new fAddEdit_org(new CompOrgDTO.OrganizationDTO(), dtStatus);
            faddeditorg.Text = "Новая организация";
            if (faddeditorg.ShowDialog() == DialogResult.OK) initData();
        }

        private void tSButton_orgEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView_org.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dataRow = dataGridView_org.SelectedRows[0];

            CompOrgDTO.OrganizationDTO oOrgDTO = new CompOrgDTO.OrganizationDTO();
            oOrgDTO.Id = (int)dataRow.Cells["org_id"].Value;
            oOrgDTO.Name = dataRow.Cells["org_name"].Value.ToString();
            oOrgDTO.RefStatus = (int)dataRow.Cells["org_ref_status"].Value;

            fAddEdit_org faddeditorg = new fAddEdit_org(oOrgDTO, dtStatus);
            faddeditorg.Text = "Редактирование '" + oOrgDTO.Name + "'";
            if (faddeditorg.ShowDialog() == DialogResult.OK) initData();
        }

        private void tSButton_orgDel_Click(object sender, EventArgs e)
        {
            if (dataGridView_org.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CompOrgDTO.OrganizationDTO oOrgDTO = new CompOrgDTO.OrganizationDTO();
            DataGridViewRow dataRow = dataGridView_org.SelectedRows[0];

            if(MessageBox.Show("Вы уверены что хотите удалить '"
                + dataGridView_org.SelectedRows[0].Cells["org_name"].Value.ToString()  +"'?", 
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            oOrgDTO.Id = (int)dataRow.Cells["id"].Value;
            try
            {
                dbAccess.delOrganization("offline", oOrgDTO);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления записи.", exc, SystemIcons.Error); }

            initData();
        }

        #endregion

        #region Branch

        private void tSButton_branchAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataRow = dataGridView_org.SelectedRows[0];
            CompOrgDTO.BranchDTO oBranchDTO = new CompOrgDTO.BranchDTO();

            oBranchDTO.RefOrg = (int)dataRow.Cells["org_id"].Value;

            fAddEdit_branch faddeditbranch = new fAddEdit_branch(oBranchDTO, dtOrg, dtStatus, dtCity);
            faddeditbranch.Text = "Новое заведение";
            if (faddeditbranch.ShowDialog() == DialogResult.OK) initData();
        }

        private void tSButton_branchEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView_branch.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dataRow = dataGridView_branch.SelectedRows[0];
            CompOrgDTO.BranchDTO oBranchDTO = new CompOrgDTO.BranchDTO();
            int ref_city;

            oBranchDTO.Id = (int)dataRow.Cells["branch_id"].Value;
            oBranchDTO.Name = dataRow.Cells["branch_name"].Value.ToString();
            if (Convert.IsDBNull(dataRow.Cells["branch_ref_city"].Value)) ref_city = 0;
            else ref_city = (int)dataRow.Cells["branch_ref_city"].Value;
            oBranchDTO.RefCity = ref_city;
            oBranchDTO.RefOrg = (int)dataRow.Cells["branch_organization"].Value;
            oBranchDTO.RefStatus = (int)dataRow.Cells["branch_ref_status"].Value;

            fAddEdit_branch faddeditbranch = new fAddEdit_branch(oBranchDTO, dtOrg, dtStatus, dtCity);
            faddeditbranch.Text = "Редактирование + '" + oBranchDTO.Name + "'";
            if (faddeditbranch.ShowDialog() == DialogResult.OK) initData();
        }

        private void tSButton_branchDel_Click(object sender, EventArgs e)
        {
            if (dataGridView_branch.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CompOrgDTO.BranchDTO oBranchDTO = new CompOrgDTO.BranchDTO();
            DataGridViewRow dataRow = dataGridView_branch.SelectedRows[0];

            if (MessageBox.Show("Вы уверены что хотите удалить '"
                + dataGridView_branch.SelectedRows[0].Cells["branch_name"].Value.ToString() + "'?",
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            oBranchDTO.Id = (int)dataRow.Cells["id"].Value;
            try
            {
                dbAccess.delBranch("offline", oBranchDTO);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления записи.", exc, SystemIcons.Error); }

            initData();
        }

        #endregion

        #region Unit

        private void tSButton_unitAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataRow = dataGridView_branch.SelectedRows[0];
            CompOrgDTO.UnitDTO oUnitDTO = new CompOrgDTO.UnitDTO();

            oUnitDTO.Branch = (int)dataRow.Cells["branch_id"].Value;

            fAddEdit_unit faddeditunit = new fAddEdit_unit(oUnitDTO, dtBranch, dtStatus);
            faddeditunit.Text = "Новое подразделение";
            if (faddeditunit.ShowDialog() == DialogResult.OK) initData();

        }

        private void tSButton_unitEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView_unit.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dataRow = dataGridView_unit.SelectedRows[0];
            CompOrgDTO.UnitDTO oUnitDTO = new CompOrgDTO.UnitDTO();

            oUnitDTO.Id = (int)dataRow.Cells["unit_id"].Value;
            oUnitDTO.Name = dataRow.Cells["unit_name"].Value.ToString();
            oUnitDTO.RefStatus = (int)dataRow.Cells["unit_ref_status"].Value;
            oUnitDTO.Branch = (int)dataRow.Cells["unit_branch"].Value;

            fAddEdit_unit faddeditunit = new fAddEdit_unit(oUnitDTO, dtBranch, dtStatus);
            faddeditunit.Text = "Редактирование '" + oUnitDTO.Name + "'";
            if (faddeditunit.ShowDialog() == DialogResult.OK) initData();

        }

        private void tSButton_unitDel_Click(object sender, EventArgs e)
        {
            if (dataGridView_unit.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CompOrgDTO.UnitDTO oUnitDTO = new CompOrgDTO.UnitDTO();
            DataGridViewRow dataRow = dataGridView_unit.SelectedRows[0];

            if (MessageBox.Show("Вы уверены что хотите удалить '"
                + dataRow.Cells["unit_name"].Value.ToString() + "'?",
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            oUnitDTO.Id = (int)dataRow.Cells["unit_id"].Value;
            try
            {
                dbAccess.delUnit("offline", oUnitDTO);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления записи.", exc, SystemIcons.Error); }

            initData();
        }

        #endregion

        private void fCompOrg_Shown(object sender, EventArgs e)
        {
            dataGridView_org.SelectionChanged += new EventHandler(dataGridView_org_SelectionChanged);
            dataGridView_branch.SelectionChanged += new EventHandler(dataGridView_branch_SelectionChanged);
            dataGridView_unit.SelectionChanged += new EventHandler(dataGridView_unit_SelectionChanged);
        }

        void dataGridView_org_SelectionChanged(object sender, EventArgs e)
        {
            (dataGridView_branch.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("organization = '{0}'", dataGridView_org.SelectedRows[0].Cells["org_id"].Value);
        }

        void dataGridView_branch_SelectionChanged(object sender, EventArgs e)
        {
            (dataGridView_unit.DataSource as DataTable).DefaultView.RowFilter = 
                string.Format("branch = '{0}'", dataGridView_branch.SelectedRows[0].Cells["branch_id"].Value);
        }

        void dataGridView_unit_SelectionChanged(object sender, EventArgs e)
        {
           
        }

    }
}
