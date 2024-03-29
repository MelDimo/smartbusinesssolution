﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using com.sbs.dll.utilites;
using com.sbs.dll;
using System.Messaging;
using com.sbs.gui.users.Properties;

namespace com.sbs.gui.users
{
    public partial class fUsers : Form
    {
        DBaccess DbAccess = new DBaccess();
        
        Suppurt Supp = new Suppurt();

        DataTable dtOrg = new DataTable();
        DataTable dtBranch = new DataTable();
        DataTable dtUnit = new DataTable();

        getReference oReferences = new getReference();

        public fUsers()
        {
            InitializeComponent();

            tSComboBox_RecType.SelectedIndex = 0;

            dataGridView_main.AutoGenerateColumns = false;

            tSSLabel_recCount.Text = "";

            initReferences();

            loadIcons();
        }

        private void loadIcons()
        {
            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_group.Image = com.sbs.dll.utilites.Properties.Resources.group_26;
            tSButton_menu.Image = com.sbs.dll.utilites.Properties.Resources.menu_26;
            tSButton_pwd.Image = com.sbs.dll.utilites.Properties.Resources.lock_26;
            tSButton_doc.Image = com.sbs.dll.utilites.Properties.Resources.doc_26;
            tSButton_applyFilter.Image = com.sbs.dll.utilites.Properties.Resources.filter_26;
            tSButton_acl.Image = com.sbs.dll.utilites.Properties.Resources.key_26;
            tSButton_mail.Image = com.sbs.dll.utilites.Properties.Resources.msg_black_26;
            tSButton_search.Image = com.sbs.dll.utilites.Properties.Resources.search_26;
        }

        private void initReferences()
        {
            getReferences();

            tSComboBox_unit.ComboBox.DataSource = dtUnit;
            tSComboBox_unit.ComboBox.ValueMember = "id";
            tSComboBox_unit.ComboBox.DisplayMember = "name";

            tSComboBox_branch.ComboBox.DataSource = dtBranch;
            tSComboBox_branch.ComboBox.ValueMember = "id";
            tSComboBox_branch.ComboBox.DisplayMember = "name";

            tSComboBox_organization.ComboBox.DataSource = dtOrg;
            tSComboBox_organization.ComboBox.ValueMember = "id";
            tSComboBox_organization.ComboBox.DisplayMember = "name";
            
        }

        private void fUsers_Shown(object sender, EventArgs e)
        {
            int xPriv;

            tSComboBox_unit.ComboBox.SelectedIndexChanged += new EventHandler(tSComboBox_unit_SelectedIndexChanged);
            tSComboBox_branch.ComboBox.SelectedIndexChanged += new EventHandler(tSComboBox_branch_SelectedIndexChanged);
            tSComboBox_organization.ComboBox.SelectedIndexChanged += new EventHandler(tSComboBox_organization_SelectedIndexChanged);


            #region проверка привелегий


            if (Supp.checkPrivileges(UsersInfo.Acl, 28))   // Позволяет добавлять и редактировать сотрудников
            {
                tSButton_add.Enabled = true;
                tSButton_del.Enabled = true;
                tSButton_edit.Enabled = true;
            }

            if (Supp.checkPrivileges(UsersInfo.Acl, 29))   // Позволяет сотрудникам задавать привилегии, указывать группы
            {
                tSButton_group.Enabled = true;
                tSButton_menu.Enabled = true;
                tSButton_doc.Enabled = true;
            }

            if (Supp.checkPrivileges(UsersInfo.Acl, 30))   // Позволяет назначать сотруднику пароль
            {
                tSButton_pwd.Enabled = true;
                tSButton_acl.Enabled = true;
            }

            #endregion
        }

        private void tSComboBox_unit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tSComboBox_RecType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tSComboBox_RecType.ComboBox.Text)
            {
                case "Пользователь":
                    if (Supp.checkPrivileges(UsersInfo.Acl, 29))   // Позволяет сотрудникам задавать привилегии, указывать группы
                    {
                        tSButton_group.Enabled = true;
                    }
                    break;

                case "Группа":
                    tSButton_group.Enabled = false;
                    break;
            }
        }

        private void tSComboBox_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter;

            if (tSComboBox_branch.ComboBox.SelectedValue.ToString().Equals("0"))
                filter = "";
            else
                filter = string.Format("branch = '{0}' OR branch = 0", tSComboBox_branch.ComboBox.SelectedValue.ToString());

            (tSComboBox_unit.ComboBox.DataSource as DataTable).DefaultView.RowFilter = filter;

            Debug.Print("tSComboBox_branch_SelectedIndexChanged");
        }

        private void tSComboBox_organization_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter;

            if (tSComboBox_organization.ComboBox.SelectedValue.ToString().Equals("0"))
                filter = "";
            else
                filter = string.Format("organization = '{0}'", tSComboBox_organization.ComboBox.SelectedValue.ToString());

            (tSComboBox_branch.ComboBox.DataSource as DataTable).DefaultView.RowFilter = filter;

            tSComboBox_branch_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void getReferences()
        {
            dtOrg = DbAccess.getOrganipation(GValues.DBMode);
            dtBranch = DbAccess.getBranch(GValues.DBMode);
            dtUnit = DbAccess.getUnit(GValues.DBMode);
        }

        private void tSButton_applyFilter_Click(object sender, EventArgs e)
        {
            switch (tSComboBox_RecType.ComboBox.Text)
            { 
                case "Пользователь":
                    fullUserData();
                    break;

                case "Группа":
                    fullGroupData();
                    break;
            }

        }

        private void fullGroupData()
        {
            dataGridView_main.Columns.Clear();

            DataTable dtGroup;

            try
            {
                dtGroup = DbAccess.getGroups("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения списка групп", exc, SystemIcons.Error); return; }

            dataGridView_main.DataSource = dtGroup;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;
            col0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Наименование";
            col1.Name = "name";
            col1.DataPropertyName = "name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Статус";
            col2.Name = "ref_status_name";
            col2.DataPropertyName = "ref_status_name";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "ref_status";
            col3.Name = "ref_status";
            col3.DataPropertyName = "ref_status";
            col3.Visible = false;
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3 });
        }

        private void fullUserData()
        {
            dataGridView_main.Columns.Clear();

            DataTable dtUsers;

            int idOrg = tSComboBox_organization.ComboBox.SelectedValue == null ? 0 : (int)tSComboBox_organization.ComboBox.SelectedValue;
            int idBranch = tSComboBox_branch.ComboBox.SelectedValue == null ? 0 : (int)tSComboBox_branch.ComboBox.SelectedValue;
            int idUnit = tSComboBox_unit.ComboBox.SelectedValue == null ? 0 : (int)tSComboBox_unit.ComboBox.SelectedValue;

            try
            {
                dtUsers = DbAccess.getUsers(GValues.DBMode, idOrg, idBranch, idUnit);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения списка сотрудников", exc, SystemIcons.Error); return; }

            dataGridView_main.DataSource = dtUsers;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "user_id";
            col1.Name = "user_id";
            col1.DataPropertyName = "id";
            col1.Visible = false;
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Таб№";
            col2.Name = "user_tabn";
            col2.DataPropertyName = "tabn";
            col2.Visible = true;
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "ФИО";
            col3.Name = "user_fio";
            col3.DataPropertyName = "fio";
            col3.Visible = true;
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Организация";
            col4.Name = "org";
            col4.DataPropertyName = "org";
            col4.Visible = true;
            col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Заведение";
            col5.Name = "branch";
            col5.DataPropertyName = "branch";
            col5.Visible = true;
            col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Подразделение";
            col6.Name = "unit";
            col6.DataPropertyName = "unit";
            col6.Visible = true;
            col6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.HeaderText = "Статус";
            col7.Name = "user_status";
            col7.DataPropertyName = "status_name";
            col7.Visible = true;
            col7.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
            col8.HeaderText = "Должность";
            col8.Name = "user_post";
            col8.DataPropertyName = "post";
            col8.Visible = true;
            col8.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5, col6, col7, col8});
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            switch (tSComboBox_RecType.ComboBox.Text)
            {
                case "Пользователь":
                    DTO.User xUsersDTO = new DTO.User();
                    xUsersDTO.org = tSComboBox_organization.ComboBox.SelectedValue == null ? 0 : (int)tSComboBox_organization.ComboBox.SelectedValue;
                    xUsersDTO.branch = tSComboBox_branch.ComboBox.SelectedValue == null ? 0 : (int)tSComboBox_branch.ComboBox.SelectedValue;
                    xUsersDTO.unit = tSComboBox_unit.ComboBox.SelectedValue == null ? 0 : (int)tSComboBox_unit.ComboBox.SelectedValue;

                    fAddEditUsers faddedit = new fAddEditUsers(xUsersDTO, dtOrg, dtBranch, dtUnit);
                    faddedit.Text = "Новый пользователь";
                    if (faddedit.ShowDialog() == DialogResult.OK) tSButton_applyFilter_Click(new object(), new EventArgs());
                    break;

                case "Группа":
                    DTO.Group xGroupDTO = new DTO.Group();
                    fAddEditGroup faddeditgroup = new fAddEditGroup(xGroupDTO);
                    faddeditgroup.Text = "Новая группа";
                    if (faddeditgroup.ShowDialog() == DialogResult.OK) tSButton_applyFilter_Click(new object(), new EventArgs());
                    break;
            }

        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            int xId = 0;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", 
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (tSComboBox_RecType.ComboBox.Text)
            {
                case "Пользователь":
                    DTO.User xUsersDTO = new DTO.User();
                    xId = (int)dataGridView_main.SelectedRows[0].Index;
                    try
                    {
                        xUsersDTO = DbAccess.getUser(GValues.DBMode, (int)dataGridView_main.SelectedRows[0].Cells["user_id"].Value);
                    }
                    catch (Exception exc)
                    {
                        uMessage.Show("Неудалось получить информацию по сотруднику.", exc, SystemIcons.Information);
                        return;
                    }
                    
                    fAddEditUsers faddedit = new fAddEditUsers(xUsersDTO, dtOrg, dtBranch, dtUnit);
                    faddedit.Text = "Редактирование " + xUsersDTO.lName +" "+ xUsersDTO.fName +" "+ xUsersDTO.sName;
                    if (faddedit.ShowDialog() == DialogResult.OK)
                    {
                        tSButton_applyFilter_Click(new object(), new EventArgs());
                        dataGridView_main.Rows[xId].Selected = true;
                    }
                    break;

                case "Группа":
                    DTO.Group xGroupDTO = new DTO.Group();
                    DataGridViewRow dr = dataGridView_main.SelectedRows[0];
                    xGroupDTO.id = (int)dr.Cells["id"].Value;
                    xGroupDTO.name = dr.Cells["name"].Value.ToString();
                    xGroupDTO.refStatus = (int)dr.Cells["ref_status"].Value;

                    fAddEditGroup faddeditgroup = new fAddEditGroup(xGroupDTO);
                    faddeditgroup.Text = "Редактирование " + xGroupDTO.name;
                    if (faddeditgroup.ShowDialog() == DialogResult.OK) tSButton_applyFilter_Click(new object(), new EventArgs());
                    break;
            }
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.",
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            switch (tSComboBox_RecType.ComboBox.Text)
            {
                case "Пользователь":
                    if (MessageBox.Show("Вы уверены что хотите удалить запись '" + dataGridView_main.SelectedRows[0].Cells["user_fio"].Value.ToString() + "'?",
                        GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                        break;
                    try
                    {
                        DbAccess.delUser("offline", (int)dataGridView_main.SelectedRows[0].Cells["user_id"].Value);
                    }
                    catch (Exception exc)
                    {
                        uMessage.Show("Неудалось удалить запись.", exc, SystemIcons.Information);
                        return;
                    }
                    break;

                case "Группа":
                    if (MessageBox.Show("Вы уверены что хотите удалить запись '" + dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString() + "'?",
                        GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                        break;
                    try
                    {
                        DbAccess.delGroup("offline", (int)dataGridView_main.SelectedRows[0].Cells["id"].Value);
                    }
                    catch (Exception exc)
                    {
                        uMessage.Show("Неудалось удалить запись.", exc, SystemIcons.Information);
                        return;
                    }
                    break;
            }

            tSButton_applyFilter_Click(new object(), new EventArgs());
        }

        private void tSButton_group_Click(object sender, EventArgs e)
        {
            DataTable dtUserGroup = new DataTable();
            int xIdUser;
            string xNameUser;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.",
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            xIdUser = (int)dataGridView_main.SelectedRows[0].Cells["user_id"].Value;
            xNameUser = dataGridView_main.SelectedRows[0].Cells["user_fio"].Value.ToString();

            try
            {
                dtUserGroup = DbAccess.getUserGroup("offline", xIdUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось получить информацию по сотруднику.", exc, SystemIcons.Information);
                return;
            }

            fUserGroup fusergroup = new fUserGroup(xNameUser, dtUserGroup);
            fusergroup.xIdUser = xIdUser;
            fusergroup.Text = "Группы пользователя";
            fusergroup.ShowDialog();
        }

        private void tSButton_menu_Click(object sender, EventArgs e)
        {
            int xUserId;
            string xUserName;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.",
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (tSComboBox_RecType.ComboBox.Text)
            {
                case "Пользователь":
                    xUserId = (int)dataGridView_main.SelectedRows[0].Cells["user_id"].Value;
                    xUserName = dataGridView_main.SelectedRows[0].Cells["user_fio"].Value.ToString();
                    DataTable dtMenu = new DataTable();
                    DataTable dtMenuUser = new DataTable();
                    try
                    {
                        dtMenu = DbAccess.getMenu("offline");
                        dtMenuUser = DbAccess.getMenuUser("offline", xUserId);
                    }
                    catch (Exception exc)
                    {
                        uMessage.Show("Неудалось получить информацию по сотруднику.", exc, SystemIcons.Information);
                        return;
                    }

                    fUserMenu fusermenu = new fUserMenu(dtMenu, dtMenuUser);
                    fusermenu.xUserName = xUserName;
                    fusermenu.xUserId = xUserId;
                    fusermenu.Text = "Редактирование меню пользователя";
                    fusermenu.ShowDialog();
                    break;

                case "Группа":
                    break;
            }
        }

        private void tSButton_pwd_Click(object sender, EventArgs e)
        {
            int xUserId;
            string xUserName;
            DataTable dtPwdUsers = new DataTable();

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.",
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (tSComboBox_RecType.ComboBox.Text)
            {
                case "Пользователь":
                    xUserId = (int)dataGridView_main.SelectedRows[0].Cells["user_id"].Value;
                    xUserName = dataGridView_main.SelectedRows[0].Cells["user_fio"].Value.ToString();
                    //DataTable dtMenu = new DataTable();
                    //DataTable dtMenuUser = new DataTable();
                    try
                    {
                        dtPwdUsers = DbAccess.getPwdUser("offline", xUserId);
                    }
                    catch (Exception exc)
                    {
                        uMessage.Show("Неудалось получить информацию по сотруднику.", exc, SystemIcons.Information);
                        return;
                    }

                    fPwd fpwd = new fPwd(dtPwdUsers);
                    fpwd.label_fio.Text = xUserName;
                    fpwd.xUserId = xUserId;
                    fpwd.ShowDialog();
                    break;

                case "Группа":
                    break;
            }
        }

        private void tSButton_acl_Click(object sender, EventArgs e)
        {
            int xUserGroupId;
            string xUserGroupName;
            DataTable dtPwdUsers = new DataTable();
            fUserGroupACL facl;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.",
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            switch (tSComboBox_RecType.ComboBox.Text)
            {
                case "Пользователь":
                    xUserGroupId = (int)dataGridView_main.SelectedRows[0].Cells["user_id"].Value;
                    xUserGroupName = dataGridView_main.SelectedRows[0].Cells["user_fio"].Value.ToString();

                    facl = new fUserGroupACL(0, xUserGroupId, xUserGroupName);
                    facl.ShowDialog();
                    break;

                case "Группа":
                    xUserGroupId = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
                    xUserGroupName = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();

                    facl = new fUserGroupACL(1, xUserGroupId, xUserGroupName);
                    facl.ShowDialog();
                    break;
            }
        }

        private void tSButton_mail_Click(object sender, EventArgs e)
        {
            int xUserGroupId;
            string xUserGroupName;
            DataTable dtEmail = new DataTable();
            

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.",
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            xUserGroupId = (int)dataGridView_main.SelectedRows[0].Cells["user_id"].Value;
            xUserGroupName = dataGridView_main.SelectedRows[0].Cells["user_fio"].Value.ToString();

            try
            {
                dtEmail = oReferences.getEmailUser("offline", xUserGroupId);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось получить информацию по сотруднику.", exc, SystemIcons.Information);
                return;
            }

            fUserMail fMail = new fUserMail();
            fMail.dtMail = dtEmail;
            fMail.userID = xUserGroupId;
            fMail.userName = xUserGroupName;
            fMail.ShowDialog();
        }

        private void fUsers_Load(object sender, EventArgs e)
        {
            Settings set = new Settings();
            this.Size = set.formSize;
            this.Location = set.formLocation;
            this.WindowState = set.formState;
        }

        private void fUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings set = new Settings();
            set.formSize = this.Size;
            set.formLocation = this.Location;
            set.formState = this.WindowState;
            set.Save();
        }

        private void tSButton_search_Click(object sender, EventArgs e)
        {
            fSearch fs = new fSearch();
            if(fs.ShowDialog() != DialogResult.OK) return;
        }
    }
}
