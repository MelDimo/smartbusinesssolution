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
    public partial class fUserGroupACL : Form
    {
        private DBaccess dbAccess = new DBaccess();
        private DataTable dtCurACL;
        private DataTable dtACL;

        private int xMode = 0; // 0 - user; 1 - group
        private int xID = 0; // 0 - user; 1 - group

        public fUserGroupACL(int pMode, int pId, string pName)
        {
            xMode = pMode;
            xID = pId;
            
            InitializeComponent();

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            label_name.Text = pName;
            
            initData();
        }

        private void initData()
        {
            switch (xMode)
            { 
                case 0:
                    loadUserACL();
                    break;

                case 1:
                    loadGroupACL();
                    break;
            }
        }

        private void loadGroupACL()
        {
            try
            {
                dtCurACL = dbAccess.getGroupACL("offline", xID);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные.", exc, SystemIcons.Information);
                return;
            }

            listBox_acl.DataSource = dtCurACL;
            listBox_acl.DisplayMember = "name";
            listBox_acl.ValueMember = "acl_type";
        }

        private void loadUserACL()
        {
            try
            {
                dtCurACL = dbAccess.getUserACL("offline", xID);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные.", exc, SystemIcons.Information);
                return;
            }

            listBox_acl.DataSource = dtCurACL;
            listBox_acl.DisplayMember = "name";
            listBox_acl.ValueMember = "acl_type";
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            int xValueId = 0;

            if(listBox_acl.SelectedItems.Count == 0 )
            {
                return;
            }

            xValueId = (int)listBox_acl.SelectedValue;

            try
            {
                switch (xMode)
                {
                    case 0:
                        dbAccess.deleteUserACL("offline", xID, xValueId);
                        break;
                    case 1:
                        break;
                }
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось удалить данные.", exc, SystemIcons.Information);
                return;
            }
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {

            switch (xMode)
            {
                case 0:
                    addUserACL();
                    break;
                case 1:
                    addGroupACL();
                    break;
            }
        }

        private void addGroupACL()
        {
            throw new NotImplementedException();
        }

        private void addUserACL()
        {
            DataTable dtBuf = new DataTable();

            try
            {
                dtBuf = dbAccess.getAllACL("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные.", exc, SystemIcons.Information);
                return;
            }

            int[] arrCurACL = new int[dtCurACL.Rows.Count];

            for (int i = 0; i < dtCurACL.Rows.Count; i++)
            {
                arrCurACL[i] = (int)dtCurACL.Rows[i]["acl_type"];
            }

            dtACL = (from row in dtBuf.AsEnumerable().Where(r => !arrCurACL.Contains(r.Field<int>("id"))) select row).CopyToDataTable();
            
            fChooser fchoose = new fChooser("ACL")
            fchoose.dataGridView_main.DataSource = dtACL;

        }
    }
}
