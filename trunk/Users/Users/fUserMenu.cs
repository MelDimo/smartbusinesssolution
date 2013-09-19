using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.users
{
    public partial class fUserMenu : Form
    {
        DBaccess DbAccess = new DBaccess();


        public string xUserName;
        public int xUserId;

        private List<int> xSelectedNodesId;

        public fUserMenu(DataTable pDtMenu, DataTable pDtMenuUser)
        {
            InitializeComponent();

            createMenu(pDtMenu, pDtMenuUser);
            
        }

        private void fUserMenu_Shown(object sender, EventArgs e)
        {
            label_fio.Text = xUserName;
        }

        private void createMenu(DataTable pDtMenu, DataTable pDtMenuUser)
        {
            TreeNode nodes;

            foreach (DataRow dr in pDtMenu.Rows)
            {
                bool isChild = false;

                nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Name = dr["id"].ToString();

                var results = from myRow in pDtMenuUser.AsEnumerable()
                              where myRow.Field<int>("menu") == int.Parse(nodes.Name)
                              select myRow;

                if (results.ToArray().Count() != 0) nodes.Checked = true;

                foreach (TreeNode node_parent in treeView_menu.Nodes.Find(dr["id_parent"].ToString(), true))
                {
                    node_parent.Nodes.Add(nodes);
                    isChild = true;
                }

                if (!isChild) treeView_menu.Nodes.Add(nodes);
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            xSelectedNodesId = new List<int>();

            foreach (TreeNode tn in treeView_menu.Nodes)
                getCheckedId(tn);

            try{
                DbAccess.createMenuUser("offline", xUserId, xSelectedNodesId);}
            catch (Exception exc)
            {
                uMessage.Show("Неудалось обновить список.", exc, SystemIcons.Information);
                return;
            }

            Close();
        }

        private void getCheckedId(TreeNode pTn)
        {
            if (pTn.Nodes.Count > 0) // есть дети
            {
                if (pTn.Checked) xSelectedNodesId.Add(int.Parse(pTn.Name));
                foreach(TreeNode tn in pTn.Nodes)
                    getCheckedId(tn);
            }
            else                    // конечный узел
            {
                if (pTn.Checked) xSelectedNodesId.Add(int.Parse(pTn.Name));
            }

            DbAccess.createMenuUser("offline", xUserId, xSelectedNodesId);
        }

        private void treeView_menu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
