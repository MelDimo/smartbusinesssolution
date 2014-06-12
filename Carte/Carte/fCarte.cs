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
using System.Diagnostics;

namespace com.sbs.gui.carte
{
    public partial class fCarte : Form
    {
        DBAccess bdAccess = new DBAccess();

        DTO.Carte oCarte;
        DTO.CarteDishesGroup oCarteGroup;
        DTO.CarteDishes oCarteDishes;

        DataTable dtCarte;
        DataTable dtCarteDishesGroup;
        DataTable dtCarteDishes;
        
        DataTable dtStatus;
        DataTable dtPrintersType;
        DataTable dtBranch;
        DataTable dtRefDishes;

        int branchId = 0;
        string branchName = string.Empty;

        getReference oReferences = new getReference();

        public fCarte()
        {
            InitializeComponent();

            dataGridView_carte.AutoGenerateColumns = false;
            dataGridView_dishes.AutoGenerateColumns = false;

            toolStripButton_carteAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            toolStripButton_carteEdit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            toolStripButton_carteDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            toolStripButton_carteDublicate.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;

            toolStripButton_groupAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            toolStripButton_groupEdit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            toolStripButton_groupDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            toolStripButton_dishAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            toolStripButton_dishEdit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            toolStripButton_dishDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            toolStripButton_branch.Image = com.sbs.dll.utilites.Properties.Resources.filter_26;

            initData();
        }

        private void initData()
        {
            try
            {
                dtStatus = oReferences.getStatus("offline", 1);
                dtPrintersType = oReferences.getRefPrintersType("offline");
                dtBranch = oReferences.getBranch("offline");
                dtRefDishes = oReferences.getRefDishes("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочников", exc, SystemIcons.Error); return; }
        }

        private void toolStripButton_branch_Click(object sender, EventArgs e)
        {
            branchId = 0;
            branchName = string.Empty;
            fChooserUnit fchooseUnit = new fChooserUnit(0, 2);
            if(fchooseUnit.ShowDialog() != DialogResult.OK) return;

            branchId = fchooseUnit.selectedId;
            branchName = fchooseUnit.selectedName;

            toolStripTextBox_branchName.Text = branchName;

            clearDataGrids();

            dataGridView_carte.SelectionChanged -= new EventHandler(dataGridView_carte_SelectionChanged);
            fillCarte();
            dataGridView_carte.SelectionChanged += new EventHandler(dataGridView_carte_SelectionChanged);

            dataGridView_carte_SelectionChanged(null, new EventArgs());
        }

        void dataGridView_carte_SelectionChanged(object sender, EventArgs e)    // Навигация по меню
        {
            if (dataGridView_carte.SelectedRows.Count == 0) return;

            int xCarte = (int)dataGridView_carte.SelectedRows[0].Cells["carte_id"].Value;
            fillCarteDishesGroup(xCarte);
        }

        private void fillCarteDishesGroup(int pCarte)                           // Заполняем Группы согласно выбраному меню
        {
            treeView_group.Nodes.Clear();

            dataGridView_dishes.DataSource = null;
            dataGridView_dishes.Rows.Clear();

            dtCarteDishesGroup = new DataTable();
            try
            {
                dtCarteDishesGroup = oReferences.getCarteDishesGroup("offline", pCarte);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочников.", exc, SystemIcons.Error); return; }

            bool isChild;

            foreach (DataRow dr in dtCarteDishesGroup.Rows)
            {
                isChild = false;

                TreeNode nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Name = dr["id"].ToString();

                foreach (TreeNode node_parent in treeView_group.Nodes.Find(dr["id_parent"].ToString(), true))
                {
                    node_parent.Nodes.Add(nodes);
                    isChild = true;
                }

                if (!isChild) treeView_group.Nodes.Add(nodes);
            }
        }

        private void fillCarte()
        {
            dtCarte = new DataTable();
            try
            {
                dtCarte = oReferences.getCarte("offline", branchId);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочников", exc, SystemIcons.Error); return; }

            dataGridView_carte.DataSource = dtCarte;
            dataGridView_carte.Columns["carte_id"].DataPropertyName = "id";
            dataGridView_carte.Columns["carte_name"].DataPropertyName = "name";
            dataGridView_carte.Columns["carte_ref_status_name"].DataPropertyName = "ref_status_name";
        }

        private void clearDataGrids()
        {
            dataGridView_carte.DataSource = null;
            treeView_group.Nodes.Clear();
            dataGridView_dishes.DataSource = null;
        }

        private void dataGridView_carte_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    break;

                case Keys.Enter:
                    break;

                case Keys.Delete:
                    break;
            }
        }
        
        #region ------------------------------------------------------------------------------ Меню
        
        private void toolStripButton_carteAdd_Click(object sender, EventArgs e)
        {
            if (branchId == 0)
            {
                MessageBox.Show("Укажите заведение.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oCarte = new DTO.Carte();
            oCarte.branch = branchId;
            fAddEdit_Carte faddedit = new fAddEdit_Carte(oCarte);
            faddedit.comboBox_branch.DataSource = dtBranch;
            faddedit.comboBox_branch.ValueMember = "id";
            faddedit.comboBox_branch.DisplayMember = "name";
            faddedit.comboBox_refStatus.DataSource = dtStatus;
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.Text = "Создание нового меню";
            if (faddedit.ShowDialog() == DialogResult.OK)
            {
                updateCarte();
            }
        }

        private void toolStripButton_carteEdit_Click(object sender, EventArgs e)
        {
            int index = 0;

            if (dataGridView_carte.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_carte.SelectedRows[0];
            index = dr.Index;
            oCarte = new DTO.Carte();

            oCarte.id = (int)dr.Cells["carte_id"].Value;

            DataRow carteInfo = (from rec in dtCarte.AsEnumerable()
                             where rec.Field<int>("id") == oCarte.id
                             select rec).First();

            oCarte.branch = carteInfo.Field<int>("branch");
            oCarte.code = carteInfo.Field<int>("code");
            oCarte.name = carteInfo.Field<string>("name");
            oCarte.refStatus = carteInfo.Field<int>("ref_status");

            fAddEdit_Carte faddedit = new fAddEdit_Carte(oCarte);
            faddedit.comboBox_branch.DataSource = dtBranch;
            faddedit.comboBox_branch.ValueMember = "id";
            faddedit.comboBox_branch.DisplayMember = "name";
            faddedit.comboBox_refStatus.DataSource = dtStatus;
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.Text = "Редактирование меню '" + oCarte.name + "'";
            if (faddedit.ShowDialog() == DialogResult.OK)
            {
                updateCarte();
            }

            dataGridView_carte.CurrentCell = dataGridView_carte.Rows[index].Cells[1];
        }

        private void toolStripButton_carteDel_Click(object sender, EventArgs e)
        {
            int carteId;
            string carteName = string.Empty;

            if (dataGridView_carte.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_carte.SelectedRows[0];

            carteId = (int)dr.Cells["carte_id"].Value;
            carteName = dr.Cells["carte_name"].Value.ToString();

            if (MessageBox.Show(@"Вы действительно хотите удалить меню '" + carteName + "'?", GValues.prgNameFull,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                bdAccess.carte_delete("offline", carteId);
            }
            catch (Exception exc)
            {
                uMessage.Show("Нуедалось удалить меню.", exc, SystemIcons.Information);
                return;
            }

            updateCarte();
        }

        private void updateCarte()
        {
            clearDataGrids();
            fillCarte();
        }
        
        #endregion

        #region ------------------------------------------------------------------------------ Группы

        private void toolStripButton_groupAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView_carte.SelectedRows.Count == 0) 
            {
                MessageBox.Show("Укажите меню.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            DataTable dtGroup = dtCarteDishesGroup.Copy();
            dtGroup.Rows.Add(new object[] { 0, 0, "<Корневой элемент>", 1, "" });

            oCarteGroup = new DTO.CarteDishesGroup();
            oCarteGroup.carte_name = dataGridView_carte.SelectedRows[0].Cells["carte_name"].Value.ToString();
            oCarteGroup.carte = (int)dataGridView_carte.SelectedRows[0].Cells["carte_id"].Value;

            fAddEdit_Group faddedit = new fAddEdit_Group(oCarteGroup);
            faddedit.comboBox_parent.DataSource = dtGroup;
            faddedit.comboBox_parent.DisplayMember = "name";
            faddedit.comboBox_parent.ValueMember = "id";
            faddedit.comboBox_status.DataSource = dtStatus;
            faddedit.comboBox_status.DisplayMember = "name";
            faddedit.comboBox_status.ValueMember = "id";
            faddedit.Text = "Создание элемента.";
            if (faddedit.ShowDialog() != DialogResult.OK) return;
            updateGroup();
        }

        private void updateGroup()
        {
            int carteId = (int)dataGridView_carte.SelectedRows[0].Cells["carte_id"].Value;

            fillCarteDishesGroup(carteId);
        }

        private void toolStripButton_groupEdit_Click(object sender, EventArgs e)
        {
            if (treeView_group.SelectedNode == null)
            {
                MessageBox.Show("Укажите элемент для редакттирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtGroup = dtCarteDishesGroup.Copy();
            dtGroup.Rows.Add(new object[] { 0, 0, "<Корневой элемент>", 1, "" });

            oCarteGroup = new DTO.CarteDishesGroup();
            oCarteGroup.id = int.Parse(treeView_group.SelectedNode.Name);

            DataRow groupInfo = (from rec in dtGroup.AsEnumerable()
                                 where rec.Field<int>("id") == oCarteGroup.id
                                 select rec).First();
            oCarteGroup.idParent = groupInfo.Field<int>("id_parent");
            oCarteGroup.carte = (int)dataGridView_carte.SelectedRows[0].Cells["carte_id"].Value;
            oCarteGroup.carte_name = dataGridView_carte.SelectedRows[0].Cells["carte_name"].Value.ToString();
            oCarteGroup.name = groupInfo.Field<string>("name");
            oCarteGroup.refStatus = groupInfo.Field<int>("ref_status");

            fAddEdit_Group faddedit = new fAddEdit_Group(oCarteGroup);
            faddedit.comboBox_parent.DataSource = dtGroup;
            faddedit.comboBox_parent.DisplayMember = "name";
            faddedit.comboBox_parent.ValueMember = "id";
            faddedit.comboBox_status.DataSource = dtStatus;
            faddedit.comboBox_status.DisplayMember = "name";
            faddedit.comboBox_status.ValueMember = "id";
            faddedit.Text = "Редактирование элемента '" + oCarteGroup.name + "'.";
            if (faddedit.ShowDialog() != DialogResult.OK) return;
            
            updateGroup();

            treeView_group.SelectedNode = treeView_group.Nodes.Find(oCarteGroup.id.ToString(), true)[0];
        }

        private void toolStripButton_groupDel_Click(object sender, EventArgs e)
        {
            int groupId;
            string groupName;

            if (treeView_group.Nodes.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            groupId = int.Parse(treeView_group.SelectedNode.Name);
            groupName = treeView_group.SelectedNode.Text;

            if (MessageBox.Show(@"Вы действительно хотите удалить группу '" + groupName + "'?", GValues.prgNameFull,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                bdAccess.group_delete("offline", groupId);
            }
            catch (Exception exc)
            {
                uMessage.Show("Нуедалось удалить элемент.", exc, SystemIcons.Information);
                return;
            }

            updateGroup();
        }

        #endregion

        #region ------------------------------------------------------------------------------ Блюда

        private void toolStripButton_dishAdd_Click(object sender, EventArgs e)
        {
            if (treeView_group.SelectedNode == null)
            {
                MessageBox.Show("Укажите категорию меню.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oCarteDishes = new DTO.CarteDishes();
            oCarteDishes.minStep = 1;
            oCarteDishes.carte = (int)dataGridView_carte.SelectedRows[0].Cells["carte_id"].Value;
            oCarteDishes.carteDishesGroup = int.Parse(treeView_group.SelectedNode.Name);
            
            fAddEdit_Dishes faddedit = new fAddEdit_Dishes(oCarteDishes);
            faddedit.comboBox_group.DataSource = dtCarteDishesGroup;
            faddedit.comboBox_group.DisplayMember = "name";
            faddedit.comboBox_group.ValueMember = "id";
            faddedit.comboBox_group.SelectedValue = treeView_group.SelectedNode.Name;

            faddedit.comboBox_refPrintersType.DataSource = dtPrintersType;
            faddedit.comboBox_refPrintersType.DisplayMember = "name";
            faddedit.comboBox_refPrintersType.ValueMember = "id";

            faddedit.comboBox_refStatus.DataSource = dtStatus;
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.dtDishes = dtRefDishes;
            faddedit.Text = "Ввод новой позиции";
            if (faddedit.ShowDialog() != DialogResult.OK) return;
            updateDishes();

        }

        private void updateDishes()
        {
            int groupId = int.Parse(treeView_group.SelectedNode.Name);

            fillGroupDishes(groupId);
        }

        private void fillGroupDishes(int pGroupId)
        {
            dtCarteDishes = new DataTable();
            
            try
            {
                dtCarteDishes = oReferences.getCarteDishes("offline", pGroupId);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочников", exc, SystemIcons.Error); return; }

            dataGridView_dishes.DataSource = dtCarteDishes;
            dataGridView_dishes.Columns["dishes_id"].DataPropertyName = "id";
            dataGridView_dishes.Columns["dishes_name"].DataPropertyName = "name";
            dataGridView_dishes.Columns["dishes_price"].DataPropertyName = "price";
            dataGridView_dishes.Columns["dishes_ref_printers_type_name"].DataPropertyName = "ref_printers_type_name";
            dataGridView_dishes.Columns["dishes_ref_status_name"].DataPropertyName = "ref_status_name";
        }

        private void toolStripButton_dishEdit_Click(object sender, EventArgs e)
        {
            int selectedItemIndex;

            if (dataGridView_dishes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oCarteDishes = new DTO.CarteDishes();
            oCarteDishes.id = (int)dataGridView_dishes.SelectedRows[0].Cells["dishes_id"].Value;
            oCarteDishes.carte = (int)dataGridView_carte.SelectedRows[0].Cells["carte_id"].Value;

            selectedItemIndex = dataGridView_dishes.SelectedRows[0].Index;

            DataRow dishInfo = (from rec in dtCarteDishes.AsEnumerable()
                                 where rec.Field<int>("id") == oCarteDishes.id
                                 select rec).First();

            oCarteDishes.carteDishesGroup = dishInfo.Field<int>("carte_dishes_group");
            oCarteDishes.isVisible = dishInfo.Field<int>("isvisible");
            oCarteDishes.name = dishInfo.Field<string>("name");
            oCarteDishes.price = dishInfo.Field<decimal>("price");
            oCarteDishes.refDishes = dishInfo.Field<int>("ref_dishes");
            oCarteDishes.refPrintersType = dishInfo.Field<int>("ref_printers_type");
            oCarteDishes.refStatus = dishInfo.Field<int>("ref_status");
            oCarteDishes.minStep = dishInfo.Field<decimal>("minStep");

            fAddEdit_Dishes faddedit = new fAddEdit_Dishes(oCarteDishes);
            faddedit.comboBox_group.DataSource = dtCarteDishesGroup;
            faddedit.comboBox_group.DisplayMember = "name";
            faddedit.comboBox_group.ValueMember = "id";
            faddedit.comboBox_group.SelectedValue = oCarteDishes.carteDishesGroup;

            faddedit.comboBox_refPrintersType.DataSource = dtPrintersType;
            faddedit.comboBox_refPrintersType.DisplayMember = "name";
            faddedit.comboBox_refPrintersType.ValueMember = "id";
            faddedit.comboBox_refPrintersType.SelectedValue = oCarteDishes.refPrintersType;

            faddedit.comboBox_refStatus.DataSource = dtStatus;
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refStatus.SelectedValue = oCarteDishes.refStatus;

            faddedit.dtDishes = dtRefDishes;
            faddedit.Text = "Редактирование '" + oCarteDishes.name + "'";
            if (faddedit.ShowDialog() != DialogResult.OK) return;

            updateDishes();

            if (dataGridView_dishes.Rows.Count >= selectedItemIndex) dataGridView_dishes.Rows[selectedItemIndex].Selected = true;
        }

        private void toolStripButton_dishDel_Click(object sender, EventArgs e)
        {
            int dishId;
            string dishName = string.Empty;

            if (dataGridView_dishes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dishId = (int)dataGridView_dishes.SelectedRows[0].Cells["dishes_id"].Value;
            dishName = dataGridView_dishes.SelectedRows[0].Cells["dishes_name"].Value.ToString();

            if (MessageBox.Show(@"Вы действительно хотите удалить позицию '" + dishName + "' из меню?", GValues.prgNameFull,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                bdAccess.dishes_delete("offline", dishId);
            }
            catch (Exception exc)
            {
                uMessage.Show("Нуедалось удалить элемент.", exc, SystemIcons.Information);
                return;
            }

            updateDishes();
        }

        #endregion

        private void treeView_group_AfterSelect(object sender, TreeViewEventArgs e)
        {
            updateDishes();
        }

        private void toolStripButton_carteDublicate_Click(object sender, EventArgs e)
        {
            int index = 0;

            if (dataGridView_carte.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_carte.SelectedRows[0];
            index = dr.Index;
            oCarte = new DTO.Carte();

            oCarte.id = (int)dr.Cells["carte_id"].Value;

            DataRow carteInfo = (from rec in dtCarte.AsEnumerable()
                                 where rec.Field<int>("id") == oCarte.id
                                 select rec).First();

            oCarte.branch = carteInfo.Field<int>("branch");
            oCarte.code = carteInfo.Field<int>("code");
            oCarte.name = carteInfo.Field<string>("name");
            oCarte.refStatus = carteInfo.Field<int>("ref_status");

            fDublicate_Carte fDubCarte = new fDublicate_Carte(toolStripTextBox_branchName.Text, oCarte, dtBranch);
            fDubCarte.ShowDialog();

        }

    }
}
