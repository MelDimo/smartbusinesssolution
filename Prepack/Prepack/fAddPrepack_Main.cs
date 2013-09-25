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

namespace com.sbs.gui.prepack
{
    public partial class fAddPrepack_Main : Form
    {
        private DTO.Prepack oPrepack;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddPrepack_Main(DataTable dtOrg, DataTable dtBranch, DataTable dtUnit, DataTable dtStatus, DTO.Prepack pPrepack )
        {
            oPrepack = pPrepack;

            InitializeComponent();

            if (oPrepack.Id == 0) formMode = "ADD";
            else formMode = "EDIT";

            initControls(dtOrg, dtBranch, dtUnit, dtStatus);
        }

        private void initControls(DataTable dtOrg, DataTable dtBranch, DataTable dtUnit, DataTable dtStatus)
        {
            comboBox_org.DataSource = dtOrg;
            comboBox_org.DisplayMember = "name";
            comboBox_org.ValueMember = "id";
            comboBox_org.SelectedValue = oPrepack.Org;

            comboBox_branch.DataSource = dtBranch;
            comboBox_branch.DisplayMember = "name";
            comboBox_branch.ValueMember = "id";
            comboBox_branch.SelectedValue = oPrepack.Branch;

            comboBox_unit.DataSource = dtUnit;
            comboBox_unit.DisplayMember = "name";
            comboBox_unit.ValueMember = "id";
            comboBox_unit.SelectedValue = oPrepack.Unit;

            comboBox_org_SelectedIndexChanged(new Object(), new EventArgs());
            comboBox_branch_SelectedIndexChanged(new Object(), new EventArgs());
            comboBox_unit_SelectedIndexChanged(new Object(), new EventArgs());

            comboBox_status.DataSource = dtStatus;
            comboBox_status.DisplayMember = "name";
            comboBox_status.ValueMember = "id";
            comboBox_status.SelectedValue = oPrepack.Status;

            textBox_id.Text = oPrepack.Id.ToString();
            textBox_code.Text = oPrepack.Code;
            textBox_name.Text = oPrepack.Name;
        }

        private void fAddPrepack_Main_Shown(object sender, EventArgs e)
        {
            comboBox_unit.SelectedIndexChanged += new EventHandler(comboBox_unit_SelectedIndexChanged);
            comboBox_branch.SelectedIndexChanged += new EventHandler(comboBox_branch_SelectedIndexChanged);
            comboBox_org.SelectedIndexChanged += new EventHandler(comboBox_org_SelectedIndexChanged);
        }

        private void comboBox_org_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter;

            if (comboBox_org.SelectedValue.ToString().Equals("0"))
                filter = "";
            else
                filter = string.Format("organization = '{0}'", comboBox_org.SelectedValue.ToString());

            (comboBox_branch.DataSource as DataTable).DefaultView.RowFilter = filter;

            comboBox_branch_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void comboBox_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter;

            if (comboBox_branch.SelectedValue.ToString().Equals("0"))
                filter = "";
            else
                filter = string.Format("branch = '{0}'", comboBox_branch.SelectedValue.ToString());

            (comboBox_unit.DataSource as DataTable).DefaultView.RowFilter = filter;
        }

        private void comboBox_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            bool xResult = false;
            try
            {
                xResult = saveData();
            }
            catch (Exception exc) { uMessage.Show("Ошибка при сохранении.", exc, SystemIcons.Information); return; }

            if (!xResult) return;

            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            oPrepack.Name = textBox_name.Text.Trim();
            oPrepack.Code = textBox_code.Text.Trim();

            if (comboBox_unit.SelectedValue == null) errMessage += System.Environment.NewLine + "- Подразделение;";
            else oPrepack.Unit = (int)comboBox_unit.SelectedValue;
            if (comboBox_status.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус;";
            else oPrepack.Status = (int)comboBox_status.SelectedValue;

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

                command.Parameters.Add("code", SqlDbType.NVarChar).Value = oPrepack.Code;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oPrepack.Name;
                command.Parameters.Add("unit", SqlDbType.Int).Value = oPrepack.Unit;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = oPrepack.Status;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO prepack(code, name, unit, ref_status)" +
                                                " VALUES (@code, @name, @unit, @ref_status)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE prepack SET code = @code, name = @name, unit = @unit, ref_status = @ref_status" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oPrepack.Id;
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
    }
}
