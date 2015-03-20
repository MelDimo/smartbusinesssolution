using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.references.refdishes
{
    public partial class fRefDishes : Form
    {
        DataTable dtItems;
        DataTable dtRefPrintresType;
        DataTable dtRefStatus;
        DataTable dtGroupTree;

        DTO.Dishes oDishes;
        DishGroup oDishGroup;

        fAddEdit faddedit;
        private int intSearch;

        public fRefDishes()
        {
            InitializeComponent();
            
            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            tSButton_addTree.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_editTree.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_dublicate.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;
            tSButton_delTree.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            dataGridView_main.AutoGenerateColumns = false;
            
            initTables();

            updateGroup();
            updateData();
        }

        private void initTables()
        {
            getReference oReferences = new getReference();

            try
            {
                dtRefStatus = oReferences.getStatus(GValues.DBMode, 1);
                dtRefPrintresType = oReferences.getRefPrintersType(GValues.DBMode);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочников", exc, SystemIcons.Error); return; }
        }

        private void updateGroup()
        {
            TreeNode nodes;
            bool inPalce = false;

            getReference oReferences = new getReference();

            treeView_DishesGroups.Nodes.Clear();

            try
            {
                dtGroupTree = oReferences.getDishesGroup(GValues.DBMode);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочников", exc, SystemIcons.Error); return; }

            foreach (DataRow dr in dtGroupTree.Rows)
            {
                inPalce = false;
                nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Name = dr["id"].ToString();
                nodes.Tag = dr["id_parent"].ToString();

                foreach (TreeNode tn in treeView_DishesGroups.Nodes.Find(dr["id_parent"].ToString(), true))
                {
                    tn.Nodes.Add(nodes);
                    inPalce = true;
                }

                if (!inPalce)
                {
                    treeView_DishesGroups.Nodes.Add(nodes);
                }
            }

            dtGroupTree.Rows.Add(new object[] { 0, 0, "< Корневой элемент >", 1 });
        }

        private void updateData()
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            dtItems = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = " SELECT rd.id, rd.code, rd.ref_dishes_group, rd.name, rd.price, rd.minStep," +
                                            " rd.ref_printers_type," +
                                            " rd.ref_status, rs.name AS ref_status_name " +
                                        " FROM ref_dishes rd" +
                                        " INNER JOIN ref_status rs ON rs.id = rd.ref_status ORDER BY rd.name";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtItems.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) tSSLabel_recCount.Text = "Итого записей: 0"; con.Close(); }

            dataGridView_main.DataSource = dtItems;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["code"].DataPropertyName = "code";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["price"].DataPropertyName = "price";
            dataGridView_main.Columns["minStep"].DataPropertyName = "minStep";
            dataGridView_main.Columns["ref_status_name"].DataPropertyName = "ref_status_name";

            tSSLabel_recCount.Text = "Итого записей: " + dtItems.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            oDishes = new DTO.Dishes();

            faddedit = new fAddEdit(oDishes);
            faddedit.comboBox_refStatus.DataSource = dtRefStatus;
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.comboBox_refStatus.ValueMember = "id";
            
            faddedit.comboBox_refPrintersType.DataSource = dtRefPrintresType;
            faddedit.comboBox_refPrintersType.DisplayMember = "name";
            faddedit.comboBox_refPrintersType.ValueMember = "id";

            faddedit.Text = "Новое блюдо";
            if (faddedit.ShowDialog() == DialogResult.OK)
            {
                updateData();
                refreshData();
            }
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            oDishes = new DTO.Dishes();
            DataRow dishInfo = null;

            int rowIndex = 0;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dataRow = dataGridView_main.SelectedRows[0];
            rowIndex = dataRow.Index;

            oDishes.id = (int)dataRow.Cells["id"].Value;

            dishInfo = (from rec in dtItems.AsEnumerable()
                           where rec.Field<int>("id") == oDishes.id
                           select rec).First();

            oDishes.code = dishInfo.Field<int>("code");
            oDishes.name = dishInfo.Field<string>("name");
            oDishes.price = dishInfo.Field<decimal>("price");
            oDishes.refStatus = dishInfo.Field<int>("ref_status");
            oDishes.refPrintersType = dishInfo.Field<int>("ref_printers_type");
            oDishes.dishesGroup = dishInfo.Field<int>("ref_dishes_group");

            faddedit = new fAddEdit(oDishes);
            
            faddedit.comboBox_refStatus.DataSource = dtRefStatus;
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refStatus.SelectedValue = oDishes.refStatus;

            faddedit.comboBox_refPrintersType.DataSource = dtRefPrintresType;
            faddedit.comboBox_refPrintersType.DisplayMember = "name";
            faddedit.comboBox_refPrintersType.ValueMember = "id";
            faddedit.comboBox_refPrintersType.SelectedValue = oDishes.refPrintersType;

            faddedit.textBox_treeGroup.Text = treeView_DishesGroups.SelectedNode.Text;

            faddedit.Text = "Редактирование блюда '" + oDishes.name + "'";
            if (faddedit.ShowDialog() == DialogResult.OK)
            {
                updateData();
                dataGridView_main.CurrentCell = dataGridView_main.Rows[rowIndex].Cells[1];
                refreshData();
            }

            for (int i = 0; i < dataGridView_main.Rows.Count; i++)
                if ((int)dataGridView_main.Rows[i].Cells["id"].Value == oDishes.id) dataGridView_main.CurrentCell = dataGridView_main.Rows[i].Cells[1];
        }

        private void tSButton_dublicate_Click(object sender, EventArgs e)
        {
            oDishes = new DTO.Dishes();
            DataRow dishInfo;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dataRow = dataGridView_main.SelectedRows[0];

            
            dishInfo = (from rec in dtItems.AsEnumerable()
                        where rec.Field<int>("id") == (int)dataRow.Cells["id"].Value
                        select rec).First();

            oDishes.id = 0;
            oDishes.code = dishInfo.Field<int>("code");
            oDishes.name = dishInfo.Field<string>("name");
            oDishes.price = dishInfo.Field<decimal>("price");
            oDishes.refStatus = dishInfo.Field<int>("ref_status");
            oDishes.refPrintersType = dishInfo.Field<int>("ref_printers_type");

            faddedit = new fAddEdit(oDishes);
            faddedit.comboBox_refStatus.DataSource = dtRefStatus;
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refStatus.SelectedValue = oDishes.refStatus;
            faddedit.comboBox_refPrintersType.DataSource = dtRefPrintresType;
            faddedit.comboBox_refPrintersType.DisplayMember = "name";
            faddedit.comboBox_refPrintersType.ValueMember = "id";
            faddedit.comboBox_refPrintersType.SelectedValue = oDishes.refPrintersType;
            faddedit.Text = "Новое блюдо";

            if (faddedit.ShowDialog() == DialogResult.OK)
            {
                updateData();
                refreshData();
            }

        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите удаляемый элемент", SystemIcons.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены что хотите удалить элемент '" +
                dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString().Trim() + "'?",
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int xId = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "DELETE FROM ref_dishes WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = xId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
        }

        private void dataGridView_main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    tSButton_edit_Click(null, new EventArgs());
                    break;
                case Keys.Insert:
                    tSButton_add_Click(null, new EventArgs());
                    break;
                case Keys.Delete:
                    tSButton_del_Click(null, new EventArgs());
                    break;
            }
        }

        private void dataGridView_main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                if (!panel_bottom.Visible)
                {
                    panel_bottom.Visible = true;
                    textBox_search.Focus();
                    textBox_search.Text = e.KeyChar.ToString();
                    textBox_search.SelectionStart = textBox_search.Text.Length;
                }
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            showStrSearch(textBox_search.Text);
        }

        private void showStrSearch(string pChar4Search)
        {
            var result = from row in dtItems.AsEnumerable()
                         where row.Field<string>("name").ToUpper().StartsWith(pChar4Search.ToUpper())
                         select row;

            if (result.Count() == 0) return;

            intSearch = result.First().Field<int>("id");

            foreach (DataGridViewRow dr in dataGridView_main.Rows)
            {
                if ((int)dr.Cells["id"].Value == intSearch)
                {
                    dataGridView_main.CurrentCell = dr.Cells[1];
                }
            }
        }

        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    dataGridView_main.Focus();
                    panel_bottom.Visible = false;
                    break;

                case Keys.Enter:
                    dataGridView_main.Focus();
                    panel_bottom.Visible = false;
                    break;
            }
        }

        private void tSButton_addTree_Click(object sender, EventArgs e)
        {
            oDishGroup = new DishGroup();
            oDishGroup.id = 0;
            oDishGroup.name = treeView_DishesGroups.SelectedNode.Text;
            oDishGroup.id_parent = int.Parse(treeView_DishesGroups.SelectedNode.Name);

            fAddEditGroup faeg = new fAddEditGroup(oDishGroup, Suppurt.FormOpenModes.New);
            faeg.Text = "Новый элемент";
            faeg.comboBox_parentGroup.DataSource = dtGroupTree;
            faeg.comboBox_parentGroup.DisplayMember = "name";
            faeg.comboBox_parentGroup.ValueMember = "id";
            if (faeg.ShowDialog() != DialogResult.OK) return;

            updateGroup();
        }

        private void tSButton_editTree_Click(object sender, EventArgs e)
        {
            if (treeView_DishesGroups.Nodes.Count == 0) return;

            //int index = treeView_DishesGroups.SelectedNode.Index;

            oDishGroup = new DishGroup();
            oDishGroup.id = int.Parse(treeView_DishesGroups.SelectedNode.Name);
            oDishGroup.name = treeView_DishesGroups.SelectedNode.Text;
            oDishGroup.id_parent = int.Parse(treeView_DishesGroups.SelectedNode.Tag.ToString());

            fAddEditGroup faeg = new fAddEditGroup(oDishGroup, Suppurt.FormOpenModes.Edit);
            faeg.Text = string.Format("Редактирование [{0}]", oDishGroup.name);
            faeg.comboBox_parentGroup.DataSource = dtGroupTree;
            faeg.comboBox_parentGroup.DisplayMember = "name";
            faeg.comboBox_parentGroup.ValueMember = "id";
            if (faeg.ShowDialog() != DialogResult.OK) return;

            updateGroup();

            //treeView_DishesGroups.SelectedNode = treeView_DishesGroups.Nodes[index];
        }

        private void tSButton_delTree_Click(object sender, EventArgs e)
        {
            if (treeView_DishesGroups.Nodes.Count == 0) return;

            oDishGroup = new DishGroup();
            oDishGroup.id = int.Parse(treeView_DishesGroups.SelectedNode.Name);
            oDishGroup.name = treeView_DishesGroups.SelectedNode.Text;

            if (dataGridView_main.Rows.Count > 0)
            {
                MessageBox.Show("Данный узел содержит позиции. Сначала переместите позиции.", GValues.prgNameFull,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (treeView_DishesGroups.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("Данный узел содержит дочерниии элементы. Сначала удалите дочернии элементы.", GValues.prgNameFull,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(string.Format("Вы уверены что хотите удалить элемент [{0}]", oDishGroup.name), GValues.prgNameFull,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "DELETE FROM ref_dishes_group WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = oDishGroup.id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateGroup();
        }

        private void treeView_DishesGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            dtItems.DefaultView.RowFilter = "ref_dishes_group = " + treeView_DishesGroups.SelectedNode.Name;
        }

       
    }

    public class DishGroup
    {
        public int id { get; set; }
        public int id_parent { get; set; }
        public string name { get; set; }
    }
}
