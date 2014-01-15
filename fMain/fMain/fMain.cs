using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using System.Diagnostics;
using System.Reflection;

namespace com.sbs.gui.main
{
    public partial class fMain : Form
    {
        public fMain(DataTable pDtMnu)
        {
            InitializeComponent();

            this.Text = GValues.prgNameFull;

            createMnu(pDtMnu);
        }

        private void createMnu(DataTable pDtMnu)
        {
            MenuStrip mainMnu = new MenuStrip();
            ToolStripMenuItem mnuItem;
            bool isChild;

            foreach (DataRow dr in pDtMnu.Rows)
            {
                isChild = false;

                mnuItem = new ToolStripMenuItem(dr["name"].ToString());
                mnuItem.Name = dr["id"].ToString();
                mnuItem.Tag = dr["assembly_name"].ToString();
                mnuItem.Click += new EventHandler(mnuItem_Click);


                foreach (ToolStripMenuItem parentItem in mainMnu.Items.Find(dr["id_parent"].ToString(), true))
                {
                    parentItem.DropDownItems.Add(mnuItem);
                    isChild = true;
                }

                if (!isChild) mainMnu.Items.Add(mnuItem);
            }

            this.Controls.Add(mainMnu);
        }

        void mnuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            if (clickedItem.Tag.ToString().Equals("")) return;

            if (isFormOpen(clickedItem.Name)) return;

            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = currentassembly.GetType(clickedItem.Tag.ToString(), false, true);

                if (type != null)
                {
                    Form form = (Form)Activator.CreateInstance(type);
                    form.Name = clickedItem.Name;
                    tabControl_top.TabPages.Add(form.Name, form.Text);
                    if (form.Tag != null)
                    {
                        if (form.Tag.Equals("DIALOG")) form.MdiParent = this;
                    }
                    else
                        form.MdiParent = this;

                    form.FormClosed += new FormClosedEventHandler(form_FormClosed);
                    form.Activated += new EventHandler(form_Activated);
                    if (form.Tag != null)
                    {
                        if (form.Tag.Equals("DIALOG")) form.ShowDialog(); // Or Application.Run(form)
                    }
                    else
                        form.Show();
                    return;
                }
            }
        }

        void form_Activated(object sender, EventArgs e)
        {
            tabControl_top.SelectTab(((Form)sender).Name);
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            tabControl_top.TabPages.RemoveByKey(((Form)sender).Name);
        }

        private bool isFormOpen(string pFormName)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals(pFormName))
                {
                    form.Activate();
                    foreach(TabPage tp in tabControl_top.TabPages)
                    {
                        if (tp.Name.Equals(pFormName)) tp.Select();
                    }
                    return true;
                }
            }

            return false;
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            tSSLabel_info.Text = UsersInfo.UserName;
        }

        private void tabControl_top_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_top.TabPages.Count == 0) return;

            string xName = tabControl_top.SelectedTab.Name;

            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals(xName))
                {
                    form.Activate();
                }
            }
        }
    }
}
