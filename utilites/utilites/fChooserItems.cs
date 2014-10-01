using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace com.sbs.dll.utilites
{
    public partial class fChooserItems : Form
    {
        public List<int> isChoosen;
        public List<int> isChoosenTree;
        public string choosenName;

        DataTable dtItems;
        DataTable dtGroupTree;

        getReference oReference = new getReference();

        private string field4QuickSearch = "name";
        private int field4QuickIndex = 1;

        public fChooserItems(List<int> pIsChoosen, List<int> pIsChoosenTree)
        {
            isChoosen = pIsChoosen;
            isChoosenTree = pIsChoosenTree;

            InitializeComponent();

            initRef();

            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["code"].DataPropertyName = "code";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["isSelected"].DataPropertyName = "isSelected";
        }

        private void initRef()
        {
            dtItems = new DataTable();
            try
            {
                dtItems = oReference.getRefDishes(GValues.DBMode);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных.", exc, SystemIcons.Error);
                return;
            }

            DataColumn column = new DataColumn("isSelected", Type.GetType("System.Boolean"));
            column.DefaultValue = false;
            dtItems.Columns.Add(column);

            dataGridView_main.AutoGenerateColumns = false;


            foreach (DataRow dr in dtItems.Rows)
            {
                if (isChoosen.Contains((int)dr["id"]))
                {
                    dr["isSelected"] = true;
                }
            }

            dataGridView_main.DataSource = dtItems;

            createTree();

            treeView_main.ExpandAll();
        }

        private void createTree()
        {
            TreeNode nodes;
            bool inPalce = false;

            getReference oReferences = new getReference();

            treeView_main.Nodes.Clear();

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
                if (isChoosenTree.Contains((int)dr["id"])) nodes.Checked = true;

                foreach (TreeNode tn in treeView_main.Nodes.Find(dr["id_parent"].ToString(), true))
                {
                    tn.Nodes.Add(nodes);
                    inPalce = true;
                }

                if (!inPalce)
                {
                    treeView_main.Nodes.Add(nodes);
                }
            }
        }

        private void dataGridView_main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) && !field4QuickSearch.Equals(string.Empty))
            {
                if (!panel_bottom.Visible)
                {
                    panel_bottom.Visible = true;
                    textBox_search.Focus();
                    textBox_search.Text = e.KeyChar.ToString();
                    textBox_search.SelectionStart = textBox_search.Text.Length;
                }
            }
            else
                if (!e.KeyChar.Equals((char)Keys.Enter))
                {
                    ((DataGridViewCheckBoxCell)dataGridView_main.SelectedRows[0].Cells[0]).Value =
                        !(bool)((DataGridViewCheckBoxCell)dataGridView_main.SelectedRows[0].Cells[0]).Value;
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

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            showStrSearch(textBox_search.Text);
        }

        private void showStrSearch(string pChar4Search)
        {
            int intSearch = 0;

            var result = from row in dtItems.AsEnumerable()
                         where row.Field<string>(field4QuickSearch).ToUpper().StartsWith(pChar4Search.ToUpper())
                         select row;

            if (result.Count() == 0) return;

            intSearch = result.First().Field<int>(field4QuickIndex);

            foreach (DataGridViewRow dr in dataGridView_main.Rows)
            {
                if ((int)dr.Cells[field4QuickIndex].Value == intSearch)
                {
                    dataGridView_main.CurrentCell = dr.Cells[0];
                }
            }
        }

        private void fChooserItems_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void dataGridView_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
                ((DataGridViewCheckBoxCell)dataGridView_main.SelectedRows[0].Cells[0]).Value =
                        !(bool)((DataGridViewCheckBoxCell)dataGridView_main.SelectedRows[0].Cells[0]).Value;
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            isChoosen = new List<int>();

            foreach (DataRow dr in dtItems.Rows)
                if ((bool)dr["isSelected"])
                {
                    choosenName = "[ ... ]";
                    isChoosen.Add((int)dr["id"]);
                }

            isChoosenTree = new List<int>();
            
            treeView_main.ExpandAll();

            getCheckedNodes(treeView_main.Nodes[0]);

            foreach (TreeNode tn in treeView_main.Nodes) 
                if ((bool)tn.Checked) isChoosenTree.Add(int.Parse(tn.Name));

            DialogResult = DialogResult.OK;
        }

        private void getCheckedNodes(TreeNode pTreeNode)
        {
            foreach (TreeNode node in pTreeNode.Nodes)
            {
                if (node.Checked) isChoosenTree.Add(int.Parse(node.Name));

                if (node.Nodes.Count > 0) this.getCheckedNodes(node);
            }
        }

        private void treeView_main_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeView_main.SelectedNode = e.Node;

            checkedNode(e.Node, e.Node.Checked);
        }

        private void checkedNode(TreeNode pNodes, bool nodeChecked)
        {
            foreach (TreeNode node in pNodes.Nodes)
            {
                foreach (DataRow dr in dtItems.Rows)
                {
                    if (dr["ref_dishes_group"].ToString().Equals(pNodes.Name))
                    {
                        dr["isSelected"] = node.Checked;
                    }
                }

                node.Checked = nodeChecked;

                if (node.Nodes.Count > 0)
                {
                    this.checkedNode(node, nodeChecked);
                }
            }

            foreach (DataRow dr in dtItems.Rows)
            {
                if (dr["ref_dishes_group"].ToString().Equals(pNodes.Name))
                {
                    dr["isSelected"] = pNodes.Checked;
                }
            }

            dataGridView_main.DataSource = dtItems;
        }

        private void reselectItems(string pGroupId)
        {
            dtItems.DefaultView.RowFilter = "ref_dishes_group = " + pGroupId;
        }

        private void treeView_main_AfterSelect(object sender, TreeViewEventArgs e)
        {
            reselectItems(e.Node.Name);
        }
    }
}
