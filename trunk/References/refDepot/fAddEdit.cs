using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.references.refDepot
{
    public partial class fAddEdit : Form
    {
        Depot oDepot = new Depot();
        DataSet dsRef = new DataSet();
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(Depot pDepot, DataSet pDsRef)
        {
            oDepot = pDepot;
            dsRef = pDsRef;

            if (oDepot.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();

            textBox_id.Text = oDepot.id.ToString();
            textBox_name.Text = oDepot.name;
        }

        private void fAddEdit_Shown(object sender, EventArgs e)
        {
            comboBox_org.DataSource = dsRef.Tables["Organization"];
            comboBox_org.DisplayMember = "name";
            comboBox_org.ValueMember = "id";
            comboBox_org.SelectedValue = oDepot.organization;

            comboBox_branch.DataSource = dsRef.Tables["Branch"];
            comboBox_branch.DisplayMember = "name";
            comboBox_branch.ValueMember = "id";
            comboBox_branch.SelectedValue = oDepot.branch;

            comboBox_unit.DataSource = dsRef.Tables["Unit"];
            comboBox_unit.DisplayMember = "name";
            comboBox_unit.ValueMember = "id";
            comboBox_unit.SelectedValue = oDepot.unit;

            comboBox_stat.DataSource = dsRef.Tables["refStatus"];
            comboBox_stat.DisplayMember = "name";
            comboBox_stat.ValueMember = "id";
            comboBox_stat.SelectedValue = oDepot.ref_status;
            (comboBox_stat.DataSource as DataTable).DefaultView.RowFilter = "ref_status_info = 1";

            comboBox_branch.SelectedIndexChanged += new EventHandler(comboBox_branch_SelectedIndexChanged);
            comboBox_org.SelectedIndexChanged += new EventHandler(comboBox_org_SelectedIndexChanged);
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

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            oDepot.name = textBox_name.Text.Trim();

            if (oDepot.name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (comboBox_org.SelectedValue == null) errMessage += System.Environment.NewLine + "- Организация;";
            else oDepot.organization = (int)comboBox_org.SelectedValue;
            if (comboBox_branch.SelectedValue == null) errMessage += System.Environment.NewLine + "- Заведение;";
            else oDepot.branch = (int)comboBox_branch.SelectedValue;
            if (comboBox_unit.SelectedValue == null) errMessage += System.Environment.NewLine + "- Подразделение;";
            else oDepot.unit = (int)comboBox_unit.SelectedValue;
            if (comboBox_stat.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус;";
            else oDepot.ref_status = (int)comboBox_stat.SelectedValue;

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oDepot.name;
                command.Parameters.Add("organization", SqlDbType.NVarChar).Value = oDepot.organization;
                command.Parameters.Add("branch", SqlDbType.Int).Value = oDepot.branch;
                command.Parameters.Add("unit", SqlDbType.Int).Value = oDepot.unit;
                command.Parameters.Add("ref_status", SqlDbType.NVarChar).Value = oDepot.ref_status;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_depot(name, organization, branch, unit, ref_status)" +
                                                " VALUES (@name, @organization, @branch, @unit, @ref_status)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_depot SET name = @name, organization = @organization, branch = @branch, unit = @unit, ref_status = @ref_status" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oDepot.id;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return true;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            bool retVal = false;
            try
            {
                retVal = saveData();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

            if (!retVal) return;

            MessageBox.Show("Данные успешно сохранены.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
