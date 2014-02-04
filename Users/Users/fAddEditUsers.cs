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
using System.Xml.Serialization;
using System.Diagnostics;

namespace com.sbs.gui.users
{
    public partial class fAddEditUsers : Form
    {
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        private DTO.User oUsers;
        private DBaccess DbAccess = new DBaccess();

        private DataTable dtRefStatus = new DataTable();
        private DataTable dtRefPost = new DataTable();
        private DataTable dtSitizen1 = new DataTable();
        private DataTable dtSitizen2 = new DataTable();
        private DataTable dtNationality = new DataTable();
        private DataTable dtEducation1 = new DataTable();
        private DataTable dtEducation2 = new DataTable();
        private DataTable dtSpecialty1 = new DataTable();
        private DataTable dtSpecialty2 = new DataTable();
        

        public fAddEditUsers(DTO.User pUsersDTO, DataTable pDtOrg, DataTable pDtBranch, DataTable pDtUnit)
        {
            InitializeComponent();

            oUsers = pUsersDTO;

            initRef();

            if (oUsers.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            comboBox_status.DataSource = dtRefStatus;
            comboBox_status.ValueMember = "id";
            comboBox_status.DisplayMember = "name";
            comboBox_status.SelectedValue = oUsers.refStatus;

            comboBox_post.DataSource = dtRefPost;
            comboBox_post.ValueMember = "id";
            comboBox_post.DisplayMember = "name";
            comboBox_post.SelectedValue = oUsers.refPost;

            comboBox_org.DataSource = pDtOrg.Copy();
            comboBox_org.ValueMember = "id";
            comboBox_org.DisplayMember = "name";

            comboBox_branch.DataSource = pDtBranch.Copy();
            comboBox_branch.ValueMember = "id";
            comboBox_branch.DisplayMember = "name";

            comboBox_unit.DataSource = pDtUnit.Copy();
            comboBox_unit.ValueMember = "id";
            comboBox_unit.DisplayMember = "name";

            comboBox_citizen1.DataSource = dtSitizen1;
            comboBox_citizen1.ValueMember = "id";
            comboBox_citizen1.DisplayMember = "name";
            comboBox_citizen1.SelectedValue = oUsers.citizen1;

            comboBox_citizen2.DataSource = dtSitizen2;
            comboBox_citizen2.ValueMember = "id";
            comboBox_citizen2.DisplayMember = "name";
            comboBox_citizen2.SelectedValue = oUsers.citizen2;

            comboBox_nationality.DataSource = dtNationality;
            comboBox_nationality.ValueMember = "id";
            comboBox_nationality.DisplayMember = "name";
            comboBox_nationality.SelectedValue = oUsers.nationality;

            comboBox_education1.DataSource = dtEducation1;
            comboBox_education1.ValueMember = "id";
            comboBox_education1.DisplayMember = "name";
            comboBox_education1.SelectedValue = oUsers.education1;

            comboBox_education2.DataSource = dtEducation2;
            comboBox_education2.ValueMember = "id";
            comboBox_education2.DisplayMember = "name";
            comboBox_education2.SelectedValue = oUsers.education2;

            comboBox_specialty1.DataSource = dtSpecialty1;
            comboBox_specialty1.ValueMember = "id";
            comboBox_specialty1.DisplayMember = "name";
            comboBox_specialty1.SelectedValue = oUsers.specialty1;

            comboBox_specialty2.DataSource = dtSpecialty2;
            comboBox_specialty2.ValueMember = "id";
            comboBox_specialty2.DisplayMember = "name";
            comboBox_specialty2.SelectedValue = oUsers.specialty2;


        }

        private void initRef()
        {
            getReference getRef = new getReference();
            try
            {
                dtRefStatus = getRef.getStatus("offline", 2);
                dtRefPost = getRef.getPost("offline");
                dtSitizen1 = getRef.getSitizen("offline");
                dtSitizen2 = dtSitizen1.Copy();
                dtNationality = getRef.getNationality("offline");
                dtEducation1 = getRef.getEducation("offline");
                dtEducation2 = dtEducation1.Copy();
                dtSpecialty1 = getRef.getSpecialty("offline");
                dtSpecialty2 = dtSpecialty1.Copy();
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочника.", exc, SystemIcons.Information); }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (!saveData()) return;
            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";

            writeBindingsData();

            oUsers.org = comboBox_org.SelectedValue == null ? 0 : (int)comboBox_org.SelectedValue;
            oUsers.branch = comboBox_branch.SelectedValue == null ? 0 : (int)comboBox_branch.SelectedValue;
            oUsers.unit = comboBox_unit.SelectedValue == null ? 0 : (int)comboBox_unit.SelectedValue;
            oUsers.refStatus = comboBox_status.SelectedValue == null ? 0 : (int)comboBox_status.SelectedValue;
            oUsers.refPost = comboBox_post.SelectedValue == null ? 0 : (int)comboBox_post.SelectedValue;
            oUsers.citizen1 = comboBox_citizen1.SelectedValue == null ? 0 : (int)comboBox_citizen1.SelectedValue;
            oUsers.citizen2 = comboBox_citizen2.SelectedValue == null ? 0 : (int)comboBox_citizen2.SelectedValue;
            oUsers.nationality = comboBox_nationality.SelectedValue == null ? 0 : (int)comboBox_nationality.SelectedValue;
            oUsers.education1 = comboBox_education1.SelectedValue == null ? 0 : (int)comboBox_education1.SelectedValue;
            oUsers.education2 = comboBox_education2.SelectedValue == null ? 0 : (int)comboBox_education2.SelectedValue;
            oUsers.specialty1 = comboBox_specialty1.SelectedValue == null ? 0 : (int)comboBox_specialty1.SelectedValue;
            oUsers.specialty2 = comboBox_specialty2.SelectedValue == null ? 0 : (int)comboBox_specialty2.SelectedValue;

            if (dateTimePicker_started.Checked) oUsers.dateStarted = dateTimePicker_started.Value;
            if (dateTimePicker_fired.Checked) oUsers.dateFired = dateTimePicker_fired.Value;
            if (dateTimePicker_statusEND.Checked) oUsers.dateFired = dateTimePicker_statusEND.Value;

            if (oUsers.fName.Length == 0) errMessage += System.Environment.NewLine + "- Имя;";
            if (oUsers.lName.Length == 0) errMessage += System.Environment.NewLine + "- Фамилия;";
            if (oUsers.sName.Length == 0) errMessage += System.Environment.NewLine + "- Отчество;";

            if (oUsers.org == 0) errMessage += System.Environment.NewLine + "- Организация;";
            if (oUsers.branch == 0) errMessage += System.Environment.NewLine + "- Заведение;";
            if (oUsers.unit == 0) errMessage += System.Environment.NewLine + "- Подразделение;";
            if (oUsers.refStatus == 0) errMessage += System.Environment.NewLine + "- Статус;";
            if (oUsers.refPost == 0) errMessage += System.Environment.NewLine + "- Должность;";

            if (oUsers.docNumber.Length == 0) errMessage += System.Environment.NewLine + "- Труд. договор №;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            switch (formMode)
            {
                case "ADD":
                    try
                    {
                        DbAccess.addEditUser("offline", oUsers);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); return false; }
                    break;

                case "EDIT":
                    try
                    {
                        DbAccess.addEditUser("offline", oUsers);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); return false; }
                    break;
            }

            return true;
        }

        private void writeBindingsData()
        {
            oUsers.fName = textBox_fname.Text;
            oUsers.lName = textBox_lname.Text;
            oUsers.sName = textBox_sname.Text;

            oUsers.docNumber = textBox_docNumber.Text;
            oUsers.tabn = textBox_tabn.Text;
            oUsers.pensNumber = maskedTextBox_pensNumber.Text;

            oUsers.bdate = dateTimePicker_bdate.Value;
            oUsers.bPlace = textBox_bpalce.Text;
            oUsers.passSeriy = textBox_passSeriya.Text;
            oUsers.passNumber = textBox_passNumber.Text;
            oUsers.passDateIssued = dateTimePicker_PassWhen.Value == null ? DateTime.ParseExact("01.01.1900", "dd.MM.yyyy", null) : dateTimePicker_PassWhen.Value;
            oUsers.passWhoIssued = textBox_passWho.Text;
            oUsers.passAddress = textBox_passAddress.Text;

            oUsers.doc1 = textBox_doc1.Text;
            oUsers.doc2 = textBox_doc2.Text;
        }

        private void fAddEditUsers_Shown(object sender, EventArgs e)
        {
            textBox_fname.Text = oUsers.fName;
            textBox_lname.Text = oUsers.lName;
            textBox_sname.Text = oUsers.sName;

            textBox_docNumber.Text = oUsers.docNumber;
            textBox_tabn.Text = oUsers.tabn;
            maskedTextBox_pensNumber.Text = oUsers.pensNumber;

            dateTimePicker_bdate.Value = oUsers.bdate;
            textBox_bpalce.Text = oUsers.bPlace;
            textBox_passSeriya.Text = oUsers.passSeriy;
            textBox_passNumber.Text = oUsers.passNumber;
            dateTimePicker_PassWhen.Value = (DateTime)(oUsers.passDateIssued == null ? DateTime.ParseExact("01.01.1900", "dd.MM.yyyy", null) : oUsers.passDateIssued);
            textBox_passWho.Text = oUsers.passWhoIssued;
            textBox_passAddress.Text = oUsers.passAddress;

            textBox_doc1.Text = oUsers.doc1;
            textBox_doc2.Text = oUsers.doc2;

            comboBox_unit.SelectedIndexChanged += new EventHandler(comboBox_unit_SelectedIndexChanged);
            comboBox_branch.SelectedIndexChanged += new EventHandler(comboBox_branch_SelectedIndexChanged);
            comboBox_org.SelectedIndexChanged += new EventHandler(comboBox_org_SelectedIndexChanged);
            comboBox_org.SelectedValue = oUsers.org;

            checkBox_reservist.CheckedChanged += new EventHandler(checkBox_reservist_CheckedChanged);
            checkBox_reservist.DataBindings.Add("Checked", oUsers, "reservist", false, DataSourceUpdateMode.Never, false);

        }

        void checkBox_reservist_CheckedChanged(object sender, EventArgs e)
        {
            oUsers.reservist = checkBox_reservist.Checked == true ? 1 : 0;
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