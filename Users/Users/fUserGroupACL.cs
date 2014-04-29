using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.users
{
    public partial class fUserGroupACL : Form
    {
        private DBaccess dbAccess = new DBaccess();
        private DataTable dtCurACL;
        private DataTable dtACL;

        private int xMode = 0; // 0 - user; 1 - group
        private int xID = 0; 

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
            dtCurACL = new DataTable();

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
            string xValueName = string.Empty;

            if(listBox_acl.SelectedItems.Count == 0 )
            {
                return;
            }

            xValueId = (int)listBox_acl.SelectedValue;
            xValueName = listBox_acl.Text;
            try
            {
                switch (xMode)
                {
                    case 0:
                        deleteUserACL(xValueId, xValueName);
                        break;
                    case 1:
                        deleteGroupACL(xValueId, xValueName);
                        break;
                }
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось удалить данные.", exc, SystemIcons.Information);
                return;
            }
        }

        private void deleteGroupACL(int xValueId, string xValueName)
        {
            if (MessageBox.Show("Вы уверены, что хотите отозвать привилегию '" + xValueName + "'?", GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               != DialogResult.Yes) return;
            try
            {
                dbAccess.deleteGroupACL("offline", xID, xValueId);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось отозвать привилегию.", exc, SystemIcons.Information);
                return;
            }

            loadGroupACL();
        }

        private void deleteUserACL(int xValueId, string xValueName)
        {
            if (MessageBox.Show("Вы уверены, что хотите отозвать привилегию '" + xValueName + "'?", GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;
            try
            {
                dbAccess.deleteUserACL("offline", xID, xValueId);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось отозвать привилегию.", exc, SystemIcons.Information);
                return;
            }
            
            loadUserACL();
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

            var vDT = from row in dtBuf.AsEnumerable().Where(r => !arrCurACL.Contains(r.Field<int>("id"))) select row;

            if (vDT.Count() == 0) dtACL = new DataTable();
            else dtACL = vDT.CopyToDataTable();

            fChooser fchoose = new fChooser("ACL");

            fchoose.dataGridView_main.DataSource = dtACL;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Наименование";
            col1.Name = "name";
            col1.DataPropertyName = "name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fchoose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1 });

            fchoose.Text = "Привилегии";

            if (fchoose.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dbAccess.addGroupACL("offline", xID, (int)fchoose.xData[0]);
                }
                catch (Exception exc)
                {
                    uMessage.Show("Не удалось сохранить данные.", exc, SystemIcons.Information);
                    return;
                }

                loadGroupACL();
            }
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

            var vDT = from row in dtBuf.AsEnumerable().Where(r => !arrCurACL.Contains(r.Field<int>("id"))) select row;

            if (vDT.Count() == 0) dtACL = new DataTable();
            else dtACL = vDT.CopyToDataTable();

            fChooser fchoose = new fChooser("ACL");

            fchoose.dataGridView_main.DataSource = dtACL;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Наименование";
            col1.Name = "name";
            col1.DataPropertyName = "name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fchoose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1 });

            fchoose.Text = "Привилегии";

            if (fchoose.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dbAccess.addUserACL("offline", xID, (int)fchoose.xData[0]);
                }
                catch (Exception exc)
                {
                    uMessage.Show("Не удалось сохранить данные.", exc, SystemIcons.Information);
                    return;
                }

                loadUserACL();
            }

        }
    }
}
