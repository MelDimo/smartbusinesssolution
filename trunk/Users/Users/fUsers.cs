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
        DataTable dtUnit = new DataTable();

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

            tSComboBox_unit.ComboBox.DataSource = dtUnit;
            tSComboBox_unit.ComboBox.ValueMember = "id";
            tSComboBox_unit.ComboBox.DisplayMember = "name";
        }

        private void getReferences()
        {
            dtOrg = DbAccess.getOrganipation("offline");
            dtBranch = DbAccess.getBranch("offline");
            dtUnit = DbAccess.getUnit("offline");
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            fAddEditUsers faddedit = new fAddEditUsers();
            faddedit.Text = "Новый пользователь";
            faddedit.ShowDialog();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {

        }
    }
}
