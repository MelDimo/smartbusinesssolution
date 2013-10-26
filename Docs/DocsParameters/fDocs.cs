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
using System.Diagnostics;

namespace com.sbs.gui.docs
{
    public partial class fDocs : Form
    {
        DataTable dtRefStatus;
        DataTable dtRefDocsParam;
        DataTable dtDocsType;
        DataTable dtDocsParam;
        DataTable dtDocsBlock;
        DataTable dtRefStatusBlock;

        DocsType oDocsType;// = new DocsType();
        DocsParam oDocsParam;// = new DocsParam();
        DocsBlock oDocsBlock;
        getReference oRef = new getReference();
        DBAccess dbAccess = new DBAccess();

        int selectedDocsTypeId;

        public fDocs()
        {
            InitializeComponent();

            tSButton_docsAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_docsEdit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_docsDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_docsCopy.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;

            tSButton_docsParamAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_docsParamEdit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_docsParamDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            tSButton_mapAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_mapEdit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_mapDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            
            tSButton_actionAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_actionEdit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_actionDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            dataGridView_docs.AutoGenerateColumns = false;
            dataGridView_docsParam.AutoGenerateColumns = false;
            dataGridView_docsBlock.AutoGenerateColumns = false;
            dataGridView_docsAction.AutoGenerateColumns = false;
        }

        #region docs_type

        private void tSButton_docsAdd_Click(object sender, EventArgs e)
        {
            fDocsAddEdit faddeditdocs = new fDocsAddEdit(new DocsType());
            faddeditdocs.comboBox_refStatus.DataSource = dtRefStatus;
            faddeditdocs.comboBox_refStatus.ValueMember = "id";
            faddeditdocs.comboBox_refStatus.DisplayMember = "name";
            faddeditdocs.Text = "Создание нового документа";
            if (faddeditdocs.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_docsEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView_docs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_docs.SelectedRows[0];

            oDocsType = new DocsType();
            oDocsType.id = (int)dr.Cells["docstype_id"].Value;
            oDocsType.name = dr.Cells["docstype_name"].Value.ToString();
            oDocsType.refStat = (int)dr.Cells["docstype_refStatus"].Value;

            fDocsAddEdit faddeditdocs = new fDocsAddEdit(oDocsType);
            faddeditdocs.comboBox_refStatus.DataSource = dtRefStatus;
            faddeditdocs.comboBox_refStatus.ValueMember = "id";
            faddeditdocs.comboBox_refStatus.DisplayMember = "name";
            faddeditdocs.Text = "Редактирование документа '" + oDocsType.name + "'";
            if (faddeditdocs.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_docsDel_Click(object sender, EventArgs e)
        {
            if (dataGridView_docs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите документ для удаления", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_docs.SelectedRows[0];

            if (DialogResult.Yes != MessageBox.Show("Вы уверены, что хотите удалить документ '" + dr.Cells["docstype_name"].Value.ToString() + "'?", GValues.prgNameFull,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            try
            {
                dbAccess.delDocsType("offline", selectedDocsTypeId);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }

            updateData();
        }

        private void tSButton_docsCopy_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region docs_param

        private void tSButton_docsParamAdd_Click(object sender, EventArgs e)
        {
            if (selectedDocsTypeId == 0) return;

            oDocsParam = new DocsParam();
            oDocsParam.docsTypeId = selectedDocsTypeId;
            fDocsParamAddEdit fdocaddeditparam = new fDocsParamAddEdit(oDocsParam);
            fdocaddeditparam.comboBox_docsParam.DataSource = dtRefDocsParam;
            fdocaddeditparam.comboBox_docsParam.ValueMember = "id";
            fdocaddeditparam.comboBox_docsParam.DisplayMember = "name";
            fdocaddeditparam.Text = "Новый параметр к документу";
            fdocaddeditparam.textBox_description.DataBindings.Add("Text", dtRefDocsParam, "description");
            if (fdocaddeditparam.ShowDialog() == DialogResult.OK) initDocsParamData(selectedDocsTypeId);
        }

        private void tSButton_docsParamEdit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_docsParamDel_Click(object sender, EventArgs e)
        {
            int xId;

            if (dataGridView_docs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите документ для удаления", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_docs.SelectedRows[0];

            if (DialogResult.Yes != MessageBox.Show("Вы уверены, что хотите удалить параметр '" + dr.Cells["refdocsparam_name"].Value.ToString() + "'?", GValues.prgNameFull,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            xId = (int)dr.Cells["refdocsparam_id"].Value;

            try
            {
                dbAccess.delDocsParam("offline", xId);
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }

            updateData();
        }

        #endregion

        #region docs_block

        private void tSButton_mapAdd_Click(object sender, EventArgs e)
        {
            DocsBlock oDocsBlock = new DocsBlock();
            oDocsBlock.docsType = selectedDocsTypeId;

            fDocsBlockAddEdit fdocsblock = new fDocsBlockAddEdit(oDocsBlock);
            
            fdocsblock.comboBox_statusIn.DataSource = dtRefStatusBlock.Copy();
            fdocsblock.comboBox_statusIn.ValueMember = "id";
            fdocsblock.comboBox_statusIn.DisplayMember = "name";

            fdocsblock.comboBox_statusOut.DataSource = dtRefStatusBlock.Copy();
            fdocsblock.comboBox_statusOut.ValueMember = "id";
            fdocsblock.comboBox_statusOut.DisplayMember = "name";

            fdocsblock.Text = "Создание нового этапа";
            if (fdocsblock.ShowDialog() == DialogResult.OK) initDocsParamData(selectedDocsTypeId);
        }

        private void tSButton_mapEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView_docsBlock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_docsBlock.SelectedRows[0];

            DocsBlock oDocsBlock = new DocsBlock();
            oDocsBlock.docsType = selectedDocsTypeId;

            oDocsBlock.id = (int)dr.Cells["docsblock_id"].Value;
            oDocsBlock.name = dr.Cells["docsblock_name"].Value.ToString();
            oDocsBlock.docsType = (int)dr.Cells["docsblock_docstype"].Value;
            oDocsBlock.xorder = (int)dr.Cells["docsblock_xorder"].Value;
            oDocsBlock.refStatusIn = (int)dr.Cells["docsblock_refStatusIn"].Value;
            oDocsBlock.refStatusOut = (int)dr.Cells["docsblock_refStatusOut"].Value;
            oDocsBlock.isAuto = (int)dr.Cells["docsblock_isAuto"].Value;
            oDocsBlock.condition = dr.Cells["docsblock_condition"].Value.ToString();

            fDocsBlockAddEdit fdocsblock = new fDocsBlockAddEdit(oDocsBlock);

            fdocsblock.comboBox_statusIn.DataSource = dtRefStatusBlock.Copy();
            fdocsblock.comboBox_statusIn.ValueMember = "id";
            fdocsblock.comboBox_statusIn.DisplayMember = "name";

            fdocsblock.comboBox_statusOut.DataSource = dtRefStatusBlock.Copy();
            fdocsblock.comboBox_statusOut.ValueMember = "id";
            fdocsblock.comboBox_statusOut.DisplayMember = "name";

            fdocsblock.Text = "Редактирование этапа '" + oDocsBlock.name + "'";
            if (fdocsblock.ShowDialog() == DialogResult.OK) initDocsParamData(selectedDocsTypeId);
        }

        private void tSButton_mapDel_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void fDocs_Shown(object sender, EventArgs e)
        {
            updateData();
        }

        private void updateData()
        {
            DataTable[] dt = new DataTable[2];

            try
            {
                dt = getReferences();
                dtRefStatus = dt[0];
                dtRefDocsParam = dt[1];
                dtRefStatusBlock = dt[2];
            }
            catch (Exception exc)
            {
                splitContainer1.Enabled = false;
                uMessage.Show("Неудалось получить справочники", exc, SystemIcons.Information);
                return;
            }

            initDocsTypeData();
        }

        private void initDocsTypeData()
        {
            dtDocsType = new DataTable();

            dataGridView_docs.SelectionChanged -= new EventHandler(dataGridView_docs_SelectionChanged);

            try
            {
                dtDocsType = getDocsType();
            }
            catch (Exception exc)
            {
                splitContainer1.Enabled = false;
                uMessage.Show("Неудалось получить типы документов", exc, SystemIcons.Information);
                return;
            }
            //dtype.id, dtype.name, dtype.ref_status, stat.name AS ref_status_name
            dataGridView_docs.DataSource = dtDocsType;
            dataGridView_docs.Columns["docstype_id"].DataPropertyName = "id";
            dataGridView_docs.Columns["docstype_name"].DataPropertyName = "name";
            dataGridView_docs.Columns["docstype_refStatus"].DataPropertyName = "ref_status";
            dataGridView_docs.Columns["docstype_refStatusName"].DataPropertyName = "ref_status_name";

            dataGridView_docs.SelectionChanged +=new EventHandler(dataGridView_docs_SelectionChanged);

            if(dataGridView_docs.Rows.Count == 0)return;

            if (selectedDocsTypeId == 0)
            {
                dataGridView_docs.Rows[0].Selected = false;
                dataGridView_docs.Rows[0].Selected = true;
            }
            else
                foreach (DataGridViewRow dr in dataGridView_docs.Rows)
                {
                    if ((int)dr.Cells["docstype_id"].Value == selectedDocsTypeId) dr.Selected = true;
                }
        }

        private void initDocsParamData(int pDocsTypeId)
        {
            dtDocsParam = new DataTable();
            dtDocsBlock = new DataTable();

            try
            {
                dtDocsParam = getDocsParam(pDocsTypeId);
                dtDocsBlock = getDocsBlock(pDocsTypeId);
            }
            catch (Exception exc)
            {
                splitContainer1.Enabled = false;
                uMessage.Show("Неудалось получить пареметры документов", exc, SystemIcons.Information);
                return;
            }

            //dp.id, dp.ref_docs_param, rdp.name, rdp.description
            dataGridView_docsParam.DataSource = dtDocsParam;
            dataGridView_docsParam.Columns["refdocsparam_id"].DataPropertyName = "id";
            dataGridView_docsParam.Columns["refdocsparam_name"].DataPropertyName = "name";
            dataGridView_docsParam.Columns["refdocsparam_refdocsparam"].DataPropertyName = "ref_docs_param";
            dataGridView_docsParam.Columns["refdocsparam_description"].DataPropertyName = "description";

            //db.id, db.name, db.docs_type, db.xorder, db.ref_statusIn, rsIn.name AS ref_statusIn_name, db.ref_statusOut, rsOut.name AS ref_statusOut_name, 
            //db.isAuto, db.condition
            dataGridView_docsBlock.DataSource = dtDocsBlock;
            dataGridView_docsBlock.Columns["docsblock_id"].DataPropertyName = "id";
            dataGridView_docsBlock.Columns["docsblock_name"].DataPropertyName = "name";
            dataGridView_docsBlock.Columns["docsblock_docsType"].DataPropertyName = "docs_type";
            dataGridView_docsBlock.Columns["docsblock_xorder"].DataPropertyName = "xorder";
            dataGridView_docsBlock.Columns["docsblock_refStatusIn"].DataPropertyName = "ref_statusIn";
            dataGridView_docsBlock.Columns["docsblock_refStatusInName"].DataPropertyName = "ref_statusIn_name";
            dataGridView_docsBlock.Columns["docsblock_refStatusOut"].DataPropertyName = "ref_statusOut";
            dataGridView_docsBlock.Columns["docsblock_refStatusOutName"].DataPropertyName = "ref_statusOut_name";
            dataGridView_docsBlock.Columns["docsblock_isAuto"].DataPropertyName = "isAuto";
            dataGridView_docsBlock.Columns["docsblock_condition"].DataPropertyName = "condition";
        }

        private DataTable getDocsParam(int pDocsTypeId)
        {
            return dbAccess.getDocsParam("offline", pDocsTypeId);
        }

        private DataTable getDocsBlock(int pDocsTypeId)
        {
            return dbAccess.getDocsBlock("offline", pDocsTypeId);
        }

        private DataTable getDocsType()
        {
            return dbAccess.getDocsType("offline");
        }

        private DataTable[] getReferences()
        {
            return new DataTable[] { oRef.getStatus("offline", 1), oRef.getRefDocsParam("offline"), oRef.getStatus("offline", 6) };
        }

        private void dataGridView_docs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_docs.SelectedRows.Count == 0) return;

            selectedDocsTypeId = (int)dataGridView_docs.SelectedRows[0].Cells["docstype_id"].Value;

            initDocsParamData(selectedDocsTypeId);
        }
    }
}
