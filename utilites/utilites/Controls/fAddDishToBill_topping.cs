using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class fAddDishToBill_topping : Form
    {
        DataTable dtToppings;
        string curGroup;
        int curId;
        int countGroup;

        public fAddDishToBill_topping(DataTable pDtGroup, DataTable pDtToppings)
        {
            InitializeComponent();

            dtToppings = pDtToppings;

            var qry = (from row in dtToppings.AsEnumerable()
                      select row.Field<int>("toppings_groups")).Distinct();

            countGroup = qry.Count();

            dataGridView_topping.Columns["isSelected"].DataPropertyName = "isSelected";
            dataGridView_topping.Columns["id"].DataPropertyName = "id";
            dataGridView_topping.Columns["toppings_groups"].DataPropertyName = "toppings_groups";
            dataGridView_topping.Columns["carteDishes"].DataPropertyName = "carteDishes";
            dataGridView_topping.Columns["name"].DataPropertyName = "name";
            dataGridView_topping.Columns["price"].DataPropertyName = "price";

            fillToppingDish();
            fillToppingGroup(pDtGroup);
        }

        private void fillToppingDish()
        {
            dataGridView_topping.DataSource = dtToppings;
        }

        private void fillToppingGroup(DataTable dtGroup)
        {
            treeView_toppGroup.Nodes.Clear();

            bool isChild;

            foreach (DataRow dr in dtGroup.Rows)
            {
                isChild = false;

                TreeNode nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Name = dr["id"].ToString();

                foreach (TreeNode node_parent in treeView_toppGroup.Nodes.Find(dr["id_parent"].ToString(), true))
                {
                    node_parent.Nodes.Add(nodes);
                    isChild = true;
                }

                if (!isChild) treeView_toppGroup.Nodes.Add(nodes);
            }

        }

        private void treeView_toppGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dtToppings.DefaultView.RowFilter = string.Format("toppings_groups = {0}", treeView_toppGroup.SelectedNode.Name);
            dataGridView_topping.DataSource = dtToppings;
            dataGridView_topping.ClearSelection();
        }

        private void fAddDishToBill_topping_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    treeView_toppGroup.Focus();
                    if (checkSelectedTopping())
                    {
                        DialogResult = DialogResult.OK;
                        return;
                    }
                    if (MessageBox.Show("Не в каждой группе выбран топпинг." + Environment.NewLine +
                        "Продолжить формирование блюда?", GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                    break;
            }
        }

        private bool checkSelectedTopping()
        {
            int selectedCount = (from row in dtToppings.AsEnumerable()
                       where row.Field<int>("isSelected") == 1
                       select row).Count();

            return (selectedCount == countGroup); // В каждой группе есть выделенные элементы?
        }

        private void fAddDishToBill_topping_Shown(object sender, EventArgs e)
        {
            treeView_toppGroup.SelectedNode = treeView_toppGroup.Nodes[0];
            if (dataGridView_topping.Rows.Count > 0)
            {
                dataGridView_topping.CurrentCell = dataGridView_topping.Rows[0].Cells["isSelected"];
                dataGridView_topping.Rows[0].Selected = true;
                dataGridView_topping.Focus();
            }
        }

        private void dataGridView_topping_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    curId = (int)dataGridView_topping.SelectedRows[0].Cells["id"].Value;
                    for (int i = 0; i < dataGridView_topping.Rows.Count; i++)
                    {
                        dataGridView_topping.Rows[i].Cells["isSelected"].Value = 0;
                        if ((int)dataGridView_topping.Rows[i].Cells["id"].Value == curId) dataGridView_topping.Rows[i].Cells["isSelected"].Value = 1;
                    }
                    e.Handled = true;
                    break;

                case Keys.Tab:
                    e.Handled = true;
                    break;

                case Keys.Back:
                    dataGridView_topping.ClearSelection();
                    treeView_toppGroup.Focus();
                    break;

            }
        }

        private void treeView_toppGroup_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    if (dataGridView_topping.RowCount > 0)
                    {
                        dataGridView_topping.CurrentCell = dataGridView_topping.Rows[0].Cells["isSelected"];
                        dataGridView_topping.Rows[0].Selected = true;
                        dataGridView_topping.Focus();
                    }
                    break;
            }
        }
    }
}
