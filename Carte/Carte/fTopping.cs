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
        DataTable dtToppingsAll;
        DataTable dtGroupEx;
        DataTable dtStatus;

        DTO.CarteDishes oCarteDishes;
        DTO.ToppingGroup oToppingGroup;
        DTO.Topping oTopping;

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

            dataGridView_topping.AutoGenerateColumns = false;

            dataGridView_topping.Columns["id"].DataPropertyName = "id";
            dataGridView_topping.Columns["toppings_groups"].DataPropertyName = "toppings_groups";
            dataGridView_topping.Columns["carteDishes"].DataPropertyName = "carteDishes";
            dataGridView_topping.Columns["name"].DataPropertyName = "name";
            dataGridView_topping.Columns["price"].DataPropertyName = "price";

            intitData();
        }

        private void intitData()
        {
            try
            {
                dtGroup = oReferences.getToppingsGroups(GValues.DBMode, oCarteDishes.id);

                dtToppingsAll = dbAccess.toppingDishAll_get(GValues.DBMode, oToppingGroup, oCarteDishes.carte);

                dtToppings = oReferences.getTopingsCarteDishes(GValues.DBMode, oCarteDishes.id);

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

            if (dataGridView_topping.Rows.Count > 0)
            {
                MessageBox.Show("Группа '" + oToppingGroup.name + "' содержит топпиги." + Environment.NewLine + "Сначала удалите топпинги.",
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
            if (treeView_toppGroup.SelectedNode == null)
            {
                MessageBox.Show("Укажите группу в которую добавляется топпинг.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oToppingGroup = (DTO.ToppingGroup)treeView_toppGroup.SelectedNode.Tag;

            chooseDish();
        }

        private void chooseDish()
        {
            fChooser fChose = new fChooser("TOPPING_DISH", "name", "id", "");

            fChose.dataGridView_main.DataSource = dtToppingsAll;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Наименование";
            col1.Name = "name";
            col1.DataPropertyName = "name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Цена";
            col2.Name = "price";
            col2.DataPropertyName = "price";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewCheckBoxColumn col3 = new DataGridViewCheckBoxColumn();
            col3.HeaderText = "В меню видно";
            col3.Name = "isvisible";
            col3.DataPropertyName = "isvisible";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3 });

            fChose.Text = "Выбор топпинга";

            if (fChose.ShowDialog() != DialogResult.OK) return;
            
            oTopping = new DTO.Topping();

            oTopping.toppingsGroups = oToppingGroup.id;

            oTopping.carteDishes = (int)fChose.xData[0];
            oTopping.price = (decimal)fChose.xData[1];
            oTopping.name = fChose.xData[2].ToString();

            addTopping(oTopping);
        }

        private void addTopping(DTO.Topping oTopping)
        {
            try
            {
                dbAccess.toppingDish_add(GValues.DBMode, oTopping);

                dtToppings = oReferences.getTopingsCarteDishes(GValues.DBMode, oCarteDishes.id);
            }
            catch (Exception exc) { uMessage.Show("Не удалось сохранить топпинг.", exc, SystemIcons.Information); return; }

            dtToppings.DefaultView.RowFilter = string.Format("toppings_groups = {0}", treeView_toppGroup.SelectedNode.Name);
            dataGridView_topping.DataSource = dtToppings;

        }

        private void toolStripButton_toppingDel_Click(object sender, EventArgs e)
        {
            if (dataGridView_topping.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (MessageBox.Show("Вы деуствительно хотите удалить топинг '" + dataGridView_topping.SelectedRows[0].Cells["name"].Value.ToString() + "'?",
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                dbAccess.toppingDish_del(GValues.DBMode, (int)dataGridView_topping.SelectedRows[0].Cells["id"].Value);
                dtToppings = oReferences.getTopingsCarteDishes(GValues.DBMode, oCarteDishes.id);
                treeView_toppGroup_AfterSelect(null, null);
            }
            catch (Exception exc) 
            { 
                uMessage.Show("Неудалось удалить элемент '" + dataGridView_topping.SelectedRows[0].Cells["name"].Value.ToString() + "'", exc, SystemIcons.Information);
                return;
            }
        }

        #endregion

        private void treeView_toppGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dtToppings.DefaultView.RowFilter = string.Format("toppings_groups = {0}", treeView_toppGroup.SelectedNode.Name);
            dataGridView_topping.DataSource = dtToppings;
        }
    }
}
