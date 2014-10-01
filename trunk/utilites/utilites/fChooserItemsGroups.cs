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
    public partial class fChooserItemsGroups : Form
    {
        public List<int> checkedGroup = new List<int>();
        public string checkedGroupName = string.Empty;

        public bool autoCheckChild = false;

        getReference oReference = new getReference();

        DataTable dtGroupTree;

        public fChooserItemsGroups(bool pCheckBoxes)
        {
            InitializeComponent();

            treeView_main.CheckBoxes = pCheckBoxes;
        }

        private void fChooserItemsGroups_Shown(object sender, EventArgs e)
        {
            //DataSet dsOrgTree;
            //try
            //{
            //    dsOrgTree = oReference.getOrganizationTree(GValues.DBMode);
            //}
            //catch (Exception exc)
            //{
            //    uMessage.Show("Ошибка получения данных.", exc, SystemIcons.Error);
            //    return;
            //}

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

        private void button_select_Click(object sender, EventArgs e)
        {
            if (treeView_main.SelectedNode == null) return;

            if (treeView_main.SelectedNode.Nodes.Count > 0) return;

            if (treeView_main.CheckBoxes) getChecketNotes();
            else getSelectedNotes();
        }

        private void getSelectedNotes()
        {
            checkedGroup.Add(int.Parse(treeView_main.SelectedNode.Name));
            checkedGroupName = treeView_main.SelectedNode.Text;

            DialogResult = DialogResult.OK;
        }

        private void getChecketNotes()
        {
            MessageBox.Show("Не реализована обработка отмеченных пунктов");
        }
    }
}
