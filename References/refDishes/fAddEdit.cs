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
using System.Diagnostics;
using System.Data.SqlClient;

namespace com.sbs.gui.references.refdishes
{
    public partial class fAddEdit : Form
    {
        DTO.Dishes oDishes;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(DTO.Dishes pDishes)
        {
            oDishes = pDishes;

            if (oDishes.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();

            initControls();
        }

        private void initControls()
        {
            numericUpDown_code.DataBindings.Add("Value", oDishes, "code");
            textBox_name.DataBindings.Add("Text", oDishes, "name");
            numericUpDown_price.DataBindings.Add("Value", oDishes, "price");
            textBox_id.DataBindings.Add("Text", oDishes, "id");
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (commitChange()) DialogResult = DialogResult.OK;
        }

        private bool commitChange()
        {
            StringBuilder errMsg = new StringBuilder("Незаполнены след обязательные поля:");

            if (oDishes.name.Length == 0) errMsg.AppendLine("- Наименование;");

            oDishes.refPrintersType = (int)comboBox_refPrintersType.SelectedValue;
            oDishes.refStatus = (int)comboBox_refStatus.SelectedValue;

            if (!errMsg.ToString().Equals("Незаполнены след обязательные поля:"))
            {
                MessageBox.Show(errMsg.ToString(), GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return saveData();
        }

        private bool saveData()
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.Parameters.Add("code", SqlDbType.Int).Value = oDishes.code;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oDishes.name;
                command.Parameters.Add("price", SqlDbType.Decimal).Value = oDishes.price;
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = oDishes.refPrintersType;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = oDishes.refStatus;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = " INSERT INTO ref_dishes(code, name,   price,  ref_printers_type,  ref_status)" +
                                                            "VALUES(@code,  @name,  @price, @ref_printers_type, @ref_status)";
                        break;

                    case "EDIT":
                        command.CommandText = " UPDATE ref_dishes SET code = @code," +
                                                                    " name = @name," +
                                                                    " price = @price," +
                                                                    " ref_printers_type = @ref_printers_type," +
                                                                    " ref_status = @ref_status" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oDishes.id;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Неудалось внести изменения.", exc, SystemIcons.Information); return false; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return true;
        }
    }
}