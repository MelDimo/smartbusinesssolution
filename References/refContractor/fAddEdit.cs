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
using System.Data.SqlClient;

namespace com.sbs.gui.references.contractor
{
    public partial class fAddEdit : Form
    {
        private Contractor oContr;
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(Contractor pContr)
        {
            InitializeComponent();

            oContr = pContr;

            if (oContr.id == 0)
            {
                formMode = "ADD";
            }
            else
            {
                formMode = "EDIT";
                getAdditionInfo();
            }
        }

        private void getAdditionInfo()
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dtResult = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT ref_contractor_type, nameFull, fiscalCode, passport, address, tel" +
                                        " FROM ref_contractor" +
                                        " WHERE id = @id"+
                                        " ORDER BY name";

                command.Parameters.Add("id", SqlDbType.Int).Value = oContr.id;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach (DataRow dr in dtResult.Rows)
            {
                oContr.refContractorType = (int)dr["ref_contractor_type"];
                oContr.nameFull = dr["nameFull"].ToString();
                oContr.fiscalCode = dr["fiscalCode"].ToString();
                oContr.passport = dr["passport"].ToString();
                oContr.address = dr["address"].ToString();
                oContr.tel = dr["tel"].ToString();
            }
        }

        private void fAddEdit_Shown(object sender, EventArgs e)
        {
            textBox_id.DataBindings.Add("Text", oContr, "id");
            textBox_name.DataBindings.Add("Text", oContr, "name");
            textBox_fiscalCode.DataBindings.Add("Text", oContr, "fiscalCode");
            textBox_nameFull.DataBindings.Add("Text", oContr, "nameFull");
            textBox_address.DataBindings.Add("Text", oContr, "address");
            textBox_tel.DataBindings.Add("Text", oContr, "tel");

            comboBox_refStatus.SelectedValue = oContr.refStatus;
            comboBox_contrType.SelectedValue = oContr.refContractorType;
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

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";

            if (oContr.name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (comboBox_contrType.SelectedValue == null) errMessage += System.Environment.NewLine + "- Тип контрагента;";
            else oContr.refContractorType = (int)comboBox_contrType.SelectedValue;
            if (comboBox_refStatus.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус;";
            else oContr.refStatus = (int)comboBox_refStatus.SelectedValue;

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

                command.Parameters.Add("ref_contractor_type", SqlDbType.Int).Value = oContr.refContractorType;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oContr.name;
                command.Parameters.Add("nameFull", SqlDbType.NVarChar).Value = oContr.nameFull;
                command.Parameters.Add("fiscalCode", SqlDbType.NVarChar).Value = oContr.fiscalCode;
                command.Parameters.Add("passport", SqlDbType.NVarChar).Value = oContr.passport;
                command.Parameters.Add("address", SqlDbType.NVarChar).Value = oContr.address;
                command.Parameters.Add("tel", SqlDbType.NVarChar).Value = oContr.tel;
                command.Parameters.Add("refStatus", SqlDbType.Int).Value = oContr.refStatus;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_contractor(ref_contractor_type,  name,   nameFull,   fiscalCode,     passport," +
                                                                        " address,              tel,    ref_status)" +
                                                                " VALUES (@ref_contractor_type, @name,  @nameFull,  @fiscalCode,    @passport," +
                                                                        " @address,             @tel,   @refStatus)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_contractor SET ref_contractor_type = @ref_contractor_type," +
                                                                    " name = @name," +
                                                                    " nameFull = @nameFull," +
                                                                    " fiscalCode = @fiscalCode," +
                                                                    " passport = @passport," +
                                                                    " address = @address," +
                                                                    " tel = @tel," +
                                                                    " ref_status = @refStatus" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oContr.id;
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

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
