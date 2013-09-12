using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.compositionorg
{
    public partial class fCompOrg : Form
    {
        private DataTable dtOrg = new DataTable();
        private DataTable dtBranch = new DataTable();
        private DataTable dtUnit = new DataTable();

        public fCompOrg()
        {
            InitializeComponent();

            initData();
        }

        private void initData()
        {
            DBaccess dbAccess = new DBaccess();
            try
            {
                dtOrg = dbAccess.getOrganization("offline");
                dtBranch = dbAccess.getBranch("offline");
                dtUnit = dbAccess.getUnit("offline");
            }
            catch (Exception exc) { uMessage.Show("Невозможно получить данные!", exc, SystemIcons.Error); Close(); }

            listBox_org.DataSource = dtOrg;
            listBox_org.DisplayMember = "name";
            listBox_org.ValueMember = "id";

            listBox_branch.DataSource = dtBranch;
            listBox_branch.DisplayMember = "name";
            listBox_branch.ValueMember = "id";

            listBox_unit.DataSource = dtUnit;
            listBox_unit.DisplayMember = "name";
            listBox_unit.ValueMember = "id";
        }

        private void tSButton_orgAdd_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_orgEdit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_orgDel_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_branchAdd_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_branchEdit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_branchDel_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_unitAdd_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_unitEdit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_unitDel_Click(object sender, EventArgs e)
        {

        }
    }
}
