using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.gui.users
{
    public partial class fUsers : Form
    {
        DBaccess DbAccess = new DBaccess();

        DataTable dtOrg = new DataTable();
        DataTable dtBranch = new DataTable();

        public fUsers()
        {
            InitializeComponent();

            tSComboBox_RecType.SelectedIndex = 0;

            initReferences();
        }

        private void initReferences()
        {
            getReferences();

            tSComboBox_organization.ComboBox.DataSource = dtOrg;
            tSComboBox_organization.ComboBox.ValueMember = "id";
            tSComboBox_organization.ComboBox.DisplayMember = "name";

            tSComboBox_branch.ComboBox.DataSource = dtBranch;
            tSComboBox_branch.ComboBox.ValueMember = "id";
            tSComboBox_branch.ComboBox.DisplayMember = "name";
        }

        private void getReferences()
        {
            dtOrg = DbAccess.getOrganipation("offline");
            dtBranch = DbAccess.getBranch("offline");
        }
    }
}
