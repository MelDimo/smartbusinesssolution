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
    public partial class fAddEditUsers : Form
    {
        private bool changeData = false;
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        private UsersDTO oUsers = new UsersDTO();
        private DBaccess DbAccess = new DBaccess();

        private DataTable dtRefStatus = new DataTable();
        private DataTable dtRefPost = new DataTable();

        public fAddEditUsers(UsersDTO pUsersDTO, DataTable pDtOrg, DataTable pDtBranch, DataTable pDtUnit)
        {
            InitializeComponent();

            oUsers = pUsersDTO;

            initRef();

            if (oUsers.Id == 0) formMode = "ADD";
            else formMode = "EDIT";

            comboBox_status.DataSource = dtRefStatus;
            comboBox_status.ValueMember = "id";
            comboBox_status.DisplayMember = "name";
            comboBox_status.SelectedValue = oUsers.RefStatus;

            comboBox_post.DataSource = dtRefPost;
            comboBox_post.ValueMember = "id";
            comboBox_post.DisplayMember = "name";
            comboBox_post.SelectedValue = oUsers.RefPost;

            textBox_fname.Text = oUsers.fName;
            textBox_lname.Text = oUsers.lName;
            textBox_sname.Text = oUsers.sName;

            dateTimePicker_bdate.Value = oUsers.BDate;

            textBox_tabn.Text = oUsers.Tabn.ToString();

            comboBox_org.DataSource = pDtOrg;
            comboBox_org.ValueMember = "id";
            comboBox_org.DisplayMember = "name";
            comboBox_org.SelectedValue = oUsers.Org;

            comboBox_branch.DataSource = pDtBranch;
            comboBox_branch.ValueMember = "id";
            comboBox_branch.DisplayMember = "name";
            comboBox_branch.SelectedValue = oUsers.Branch;

            comboBox_unit.DataSource = pDtUnit;
            comboBox_unit.ValueMember = "id";
            comboBox_unit.DisplayMember = "name";
            comboBox_unit.SelectedValue = oUsers.Unit;

        }

        private void initRef()
        {
            getReference getRef = new getReference();
            try
            {
                dtRefStatus = getRef.getStatus("offline");
                dtRefPost = getRef.getPost("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочника.", exc, SystemIcons.Information); }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            saveData();
            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (changeData) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void saveData()
        {
            int xTabn;
            string errMessage = "Заполнены не все обязательные поля:";

            oUsers.fName = textBox_fname.Text.Trim();
            oUsers.lName = textBox_lname.Text.Trim();
            oUsers.sName = textBox_sname.Text.Trim();

            if(!int.TryParse(textBox_tabn.Text.Trim(), out xTabn))
            {
                uMessage.Show("Неудалось распознать табельный номер.",SystemIcons.Information);
                return;
            }
            oUsers.Tabn = xTabn;

            oUsers.BDate = dateTimePicker_bdate.Value;

            oUsers.Org = comboBox_org.SelectedValue == null ? 0 : (int)comboBox_org.SelectedValue;
            oUsers.Branch = comboBox_branch.SelectedValue == null ? 0 : (int)comboBox_branch.SelectedValue;
            oUsers.Unit = comboBox_unit.SelectedValue == null ? 0 : (int)comboBox_unit.SelectedValue;
            oUsers.RefStatus = comboBox_status.SelectedValue == null ? 0 : (int)comboBox_status.SelectedValue;
            oUsers.RefPost = comboBox_post.SelectedValue == null ? 0 : (int)comboBox_post.SelectedValue;

            if (oUsers.fName.Length == 0) errMessage += System.Environment.NewLine + "- Имя;";
            if (oUsers.lName.Length == 0) errMessage += System.Environment.NewLine + "- Фамилия;";
            if (oUsers.sName.Length == 0) errMessage += System.Environment.NewLine + "- Отчество;";

            if (oUsers.Org == 0) errMessage += System.Environment.NewLine + "- Организация;";
            //if (oUsers.Branch == 0) errMessage += System.Environment.NewLine + "- Заведение;";
            //if (oUsers.Unit == 0) errMessage += System.Environment.NewLine + "- Подразделение;";
            if (oUsers.RefStatus == 0) errMessage += System.Environment.NewLine + "- Статус;";
            //if (oUsers.RefPost == 0) errMessage += System.Environment.NewLine + "- Должность;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return;
            }
            switch (formMode)
            {
                case "ADD":
                    try
                    {
                        DbAccess.addUser("offline", oUsers);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); }
                    break;

                case "EDIT":
                    try
                    {
                        DbAccess.editUser("offline", oUsers);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); }
                    break;
            }

            changeData = true;
        }

        private void fAddEditUsers_Shown(object sender, EventArgs e)
        {
            comboBox_unit.SelectedIndexChanged += new EventHandler(comboBox_unit_SelectedIndexChanged);
            comboBox_branch.SelectedIndexChanged += new EventHandler(comboBox_branch_SelectedIndexChanged);
            comboBox_org.SelectedIndexChanged += new EventHandler(comboBox_org_SelectedIndexChanged);
        }

        void comboBox_unit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void comboBox_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter;

            if (comboBox_branch.SelectedValue.ToString().Equals("0"))
                filter = "";
            else
                filter = string.Format("branch = '{0}'", comboBox_branch.SelectedValue.ToString());

            (comboBox_unit.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        void comboBox_org_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter;

            if (comboBox_org.SelectedValue.ToString().Equals("0"))
                filter = "";
            else
                filter = string.Format("organization = '{0}'", comboBox_org.SelectedValue.ToString());

            (comboBox_branch.DataSource as DataTable).DefaultView.RowFilter = filter;

            comboBox_branch_SelectedIndexChanged(new object(), new EventArgs());
        }
    }
}
