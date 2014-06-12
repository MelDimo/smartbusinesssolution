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

namespace com.sbs.gui.carte
{
    public partial class fTopping : Form
    {
        getReference oReferences = new getReference();
        DBAccess dbAccess = new DBAccess();

        DataTable dtGroup;
        DataTable dtToppings;
        DataTable dtGroupEx;
        DataTable dtStatus;

        DTO.CarteDishes oCarteDishes;
        DTO.ToppingGroup oToppingGroup;

        public fTopping(DTO.CarteDishes pCarteDishes, DataTable pDtStatus)
        {
            oCarteDishes = pCarteDishes;
            dtStatus = pDtStatus.Copy();

            InitializeComponent();

            toolStripButton_groupAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            toolStripButton_groupEdit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            toolStripButton_groupDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            toolStripButton_toppingAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            toolStripButton_toppingDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            intitData();
        }

        private void intitData()
        {
            try
            {
                dtGroup = oReferences.getToppingsGroups(GValues.DBMode, oCarteDishes.id);
                dtToppings = oReferences.getTopingsCarteDishes(GValues.DBMode, oCarteDishes.id);

                dbAccess.toppingDishAll_get(GValues.DBMode, oToppingGroup, oCarteDishes.carte);

                dtGroupEx = dtGroup.Copy();
                dtGroupEx.Rows.Add(new object[] { 0, 0, oCarteDishes.id, "<Корневой элемент>", 1 });
            }
            catch (Exception exc) { uMessage.Show("Неудалось получить данные.", exc, SystemIcons.Information); setEnabled(false); }
        }

        private void setEnabled(bool pEnabled)
        {
            groupBox1.Enabled = pEnabled;
            groupBox2.Enabled = pEnabled;
        }

        private void fTopping_Shown(object sender, EventArgs e)
        {
            fillToppingGroup();
        }

        #region ------------------------------------------------------------------------------ Группы

        private void fillToppingGroup()
        {
            treeView_toppGroup.Nodes.Clear();

            bool isChild;

            foreach (DataRow dr in dtGroup.Rows)
            { 
                oToppingGroup = new DTO.ToppingGroup();
                oToppingGroup.id = (int)dr["id"];
                oToppingGroup.id_parent = (int)dr["id_parent"];
                oToppingGroup.carteDishes = (int)dr["carte_dishes"];
                oToppingGroup.name = dr["name"].ToString();
                oToppingGroup.refStatus = (int)dr["ref_status"];

                isChild = false;

                TreeNode nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Name = dr["id"].ToString();
                nodes.Tag = oToppingGroup;

                foreach (TreeNode node_parent in treeView_toppGroup.Nodes.Find(dr["id_parent"].ToString(), true))
                {
                    node_parent.Nodes.Add(nodes);
                    isChild = true;
                }

                if (!isChild) treeView_toppGroup.Nodes.Add(nodes);
            }
        }

        private void toolStripButton_groupAdd_Click(object sender, EventArgs e)
        {
            oToppingGroup = new DTO.ToppingGroup();

            oToppingGroup.carteDishes = oCarteDishes.id;

            fTopping_AddEditGroup fTAddEdit = new fTopping_AddEditGroup(oToppingGroup);
            fTAddEdit.Text = "Создание нового пункта";
            fTAddEdit.comboBox_parent.DataSource = dtGroupEx;
            fTAddEdit.comboBox_parent.DisplayMember = "name";
            fTAddEdit.comboBox_parent.ValueMember = "id";
            fTAddEdit.comboBox_status.DataSource = dtStatus;
            fTAddEdit.comboBox_status.DisplayMember = "name";
            fTAddEdit.comboBox_status.ValueMember = "id";

            if (fTAddEdit.ShowDialog() != DialogResult.OK) return;

            intitData();
            fillToppingGroup();
        }

        private void toolStripButton_groupEdit_Click(object sender, EventArgs e)
        {
            if (treeView_toppGroup.SelectedNode == null)
            {
                MessageBox.Show("Укажите группу для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oToppingGroup = (DTO.ToppingGroup)treeView_toppGroup.SelectedNode.Tag;

            fTopping_AddEditGroup fTAddEdit = new fTopping_AddEditGroup(oToppingGroup);
            fTAddEdit.Text = "Создание нового пункта";
            fTAddEdit.comboBox_parent.DataSource = dtGroupEx;
            fTAddEdit.comboBox_parent.DisplayMember = "name";
            fTAddEdit.comboBox_parent.ValueMember = "id";
            fTAddEdit.comboBox_status.DataSource = dtStatus;
            fTAddEdit.comboBox_status.DisplayMember = "name";
            fTAddEdit.comboBox_status.ValueMember = "id";

            if (fTAddEdit.ShowDialog() != DialogResult.OK) return;

            intitData();
            fillToppingGroup();
        }

        private void toolStripButton_groupDel_Click(object sender, EventArgs e)
        {
            if (treeView_toppGroup.SelectedNode == null)
            {
                MessageBox.Show("Укажите группу для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (treeView_toppGroup.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("Группа '" + oToppingGroup.name + "' содержит додгруппы." + Environment.NewLine + "Сначала удалите подгруппы.",
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oToppingGroup = (DTO.ToppingGroup)treeView_toppGroup.SelectedNode.Tag;

            if (MessageBox.Show("Вы уверены, что хотите удалить группу '" + oToppingGroup.name + "'", GValues.prgNameFull,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                dbAccess.topping_del(GValues.DBMode, oToppingGroup.id);
            }
            catch (Exception exc) { uMessage.Show("Неудалось удалить группу.", exc, SystemIcons.Information); return; }

            intitData();
            fillToppingGroup();
        }
        #endregion

        #region ------------------------------------------------------------------------------ Топпинги

        private void toolStripButton_toppingAdd_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_toppingDel_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
