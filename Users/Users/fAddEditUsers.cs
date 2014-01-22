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

namespace com.sbs.gui.users
{
    public partial class fAddEditUsers : Form
    {
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        private DTO.User oUsers = new DTO.User();
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

            textBox_fname.DataBindings.Add("Text", oUsers, "fName");
            textBox_lname.DataBindings.Add("Text", oUsers, "lName");
            textBox_sname.DataBindings.Add("Text", oUsers, "sName");
            textBox_docNumber.DataBindings.Add("Text", oUsers, "docNumber");
            textBox_tabn.DataBindings.Add("Text", oUsers, "tabn");
            maskedTextBox_pensNumber.DataBindings.Add("Text", oUsers, "pensNumber");

            dateTimePicker_bdate.DataBindings.Add("Value", oUsers, "bdate");
            textBox_bpalce.DataBindings.Add("Text", oUsers, "bPlace");
            textBox_passSeriya.DataBindings.Add("Text", oUsers, "passSeriy");
            textBox_passNumber.DataBindings.Add("Text", oUsers, "passNumber");
            dateTimePicker_PassWhen.DataBindings.Add("Value", oUsers, "passDateIssued");
            textBox_passWho.DataBindings.Add("Text", oUsers, "passWhoIssued");
            textBox_passAddress.DataBindings.Add("Text", oUsers, "passAddress");

            textBox_doc1.DataBindings.Add("Text", oUsers, "doc1");
            textBox_doc2.DataBindings.Add("Text", oUsers, "doc2");

            Binding bind = new Binding("Checked", oUsers, "reservist");
            bind.Format += (s, e) =>
            {
                e.Value = (int)e.Value == 1;
            };
            checkBox_reservist.DataBindings.Add(bind);
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
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); }
                    break;

                case "EDIT":
                    try
                    {
                        DbAccess.addEditUser("offline", oUsers);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); }
                    break;
            }

            return true;
        }

        private void fAddEditUsers_Shown(object sender, EventArgs e)
        {
            comboBox_unit.SelectedIndexChanged += new EventHandler(comboBox_unit_SelectedIndexChanged);
            comboBox_branch.SelectedIndexChanged += new EventHandler(comboBox_branch_SelectedIndexChanged);
            comboBox_org.SelectedIndexChanged += new EventHandler(comboBox_org_SelectedIndexChanged);

            comboBox_org.SelectedValue = oUsers.org;
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
