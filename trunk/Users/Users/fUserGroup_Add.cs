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
    public partial class fUserGroup_Add : Form
    {
        private DBaccess DbAccess = new DBaccess();
        public int xIdUser;

        public fUserGroup_Add()
        {
            InitializeComponent();
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            if (listBox_groups.SelectedItems.Count == 0) return;

            try
            {
                DbAccess.addUserGroups("offline", xIdUser, (int)listBox_groups.SelectedValue);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось получить информацию по сотруднику.", exc, SystemIcons.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
