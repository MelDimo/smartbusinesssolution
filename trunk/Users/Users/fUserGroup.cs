using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.users
{
    public partial class fUserGroup : Form
    {
        private DBaccess DbAccess = new DBaccess();
        private DataTable dtUserGroup = new DataTable();
        public int xIdUser;

        public fUserGroup(string pNameUser, DataTable pDtUserGroup)
        {
            InitializeComponent();

            label_fio.Text = pNameUser;
            dtUserGroup = pDtUserGroup;

            updateDSUsersGroups();
        }

        private void getUserGroups()
        {
            dtUserGroup = DbAccess.getUserGroup("offline", xIdUser);
        }

        private void updateDSUsersGroups()
        {
            listBox_groups.DataSource = dtUserGroup;
            listBox_groups.ValueMember = "groups";
            listBox_groups.DisplayMember = "name";
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            DataTable dtAvalGroup = new DataTable();

            try
            {
                dtAvalGroup = DbAccess.getAvaliableUserGroup("offline", xIdUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось получить информацию по сотруднику.", exc, SystemIcons.Information);
                return;
            }

            fUserGroup_Add fusergroupadd = new fUserGroup_Add();
            fusergroupadd.Text = "Группы";
            fusergroupadd.xIdUser = xIdUser;
            fusergroupadd.listBox_groups.DataSource = dtAvalGroup;
            fusergroupadd.listBox_groups.ValueMember = "id";
            fusergroupadd.listBox_groups.DisplayMember = "name";
            if (fusergroupadd.ShowDialog() == DialogResult.OK)
            {
                getUserGroups();
                updateDSUsersGroups();
            }

            //DbAccess.addUserGroup("offline",xIdUser, dtUserGroup);
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            if (listBox_groups.SelectedItems.Count == 0)
            {
                MessageBox.Show("Укажитегруппу для исключения.",
                                   GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Вы действительно хотие исключить из группы '" + listBox_groups.GetItemText(listBox_groups.SelectedItem) + "'"
                    , GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                DbAccess.delUserGroups("offline", xIdUser, (int)listBox_groups.SelectedValue);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось получить информацию по сотруднику.", exc, SystemIcons.Information);
                return;
            }

            getUserGroups();
            updateDSUsersGroups();
        }
    }
}
