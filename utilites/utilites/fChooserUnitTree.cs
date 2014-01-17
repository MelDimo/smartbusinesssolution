using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace com.sbs.dll.utilites
{
    public partial class fChooserUnitTree : Form
    {
        public List<int> checkedUnit = new List<int>();
        public string checkedUnitName = string.Empty;
        public bool autoCheckChild = false;

        getReference oReference = new getReference();

        public fChooserUnitTree()
        {
            InitializeComponent();
        }

        private void fChooserUnitTree_Shown(object sender, EventArgs e)
        {
            DataSet dsOrgTree;
            try
            {
                dsOrgTree = oReference.getOrganizationTree("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных.", exc, SystemIcons.Error);
                return;
            }

            createTree(dsOrgTree);

            treeView_main.ExpandAll();
        }

        private void createTree(DataSet pDsOrgTree)
        {
            bool isChild = false;
            string parentId = string.Empty;
            TreeNode nodes;

            foreach (DataTable dt in pDsOrgTree.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    isChild = false;

                    nodes = new TreeNode();
                    nodes.Text = dr["name"].ToString();

                    switch (dt.TableName)
                    {
                        case "organization":
                            nodes.Name = "organization" + dr["id"].ToString();
                            parentId = dr["idparent"].ToString();
                            break;

                        case "branch":
                            nodes.Name = "branch" + dr["id"].ToString();
                            parentId = "organization" + dr["idparent"].ToString();
                            break;

                        case "unit":
                            nodes.Name = "unit" + dr["id"].ToString();
                            parentId = "branch" + dr["idparent"].ToString();
                            break;
                    }

                    foreach (TreeNode node_parent in treeView_main.Nodes.Find(parentId, true))
                    {
                        node_parent.Nodes.Add(nodes);
                        isChild = true;
                    }

                    if (!isChild) treeView_main.Nodes.Add(nodes);
                }
            }
        }

        private void checkedNode(TreeNode pNodes, bool nodeChecked)
        {
            foreach (TreeNode node in pNodes.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.checkedNode(node, nodeChecked);
                }
            }
        }

        private void treeView_main_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (autoCheckChild)
                checkedNode(e.Node, e.Node.Checked);
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            getCheckedId(treeView_main.Nodes[0]);
            checkedUnitName = checkedUnitName.Substring(0, checkedUnitName.Length - 2);

            if (checkedUnit.Count == 0) DialogResult = DialogResult.Cancel;
            DialogResult = DialogResult.OK;
        }

        private void getCheckedId(TreeNode pTn)
        {
            string curWord = string.Empty;

            Regex regOnlyNumber = new Regex(@"\D+");
            Regex regOnlyLetter = new Regex(@"\d+");

            if (pTn.Nodes.Count > 0) // есть дети
            {
                foreach (TreeNode tn in pTn.Nodes)
                    getCheckedId(tn);
            }
            else                    // конечный узел
            {
                curWord = regOnlyLetter.Replace(pTn.Name,"");
                switch(curWord)
                {
                    case "organization":
                        break;

                    case "branch":
                        break;

                    case "unit":
                        if (pTn.Checked)
                        {
                            checkedUnit.Add(int.Parse(regOnlyNumber.Replace(pTn.Name, "")));
                            checkedUnitName += pTn.Text + "; ";
                        }
                        break;
                }
                
            }
        }
    }
}
