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
        DTO.Dishes oDishesOld;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        int flagAccess = 0; // 1 - необходим контроль изменений

        public fAddEdit(DTO.Dishes pDishes)
        {
            oDishes = pDishes;
            oDishesOld = pDishes;

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
            numericUpDown_minStep.DataBindings.Add("Value", oDishes, "minStep");
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

            if (oDishes.dishesGroup == 0) errMsg.AppendLine("- Группа;");

            if (!errMsg.ToString().Equals("Незаполнены след обязательные поля:"))
            {
                MessageBox.Show(errMsg.ToString(), GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!oDishes.code.Equals(oDishesOld.code)) flagAccess = 1;

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
                command.Parameters.Add("minStep", SqlDbType.Decimal).Value = oDishes.minStep;
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = oDishes.refPrintersType;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = oDishes.refStatus;
                command.Parameters.Add("ref_dishes_group", SqlDbType.Int).Value = oDishes.dishesGroup;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = " INSERT INTO ref_dishes(code, ref_dishes_group, name, price, minStep, ref_printers_type, ref_status)" +
                                                            "VALUES(@code,   @ref_dishes_group,@name,@price,@minStep,@ref_printers_type,@ref_status)";
                        break;

                    case "EDIT":
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "Dishes_edit";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oDishes.id;
                        command.Parameters.Add("flagAccess", SqlDbType.Int).Value = flagAccess;
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

        private void button_treeGroup_Click(object sender, EventArgs e)
        {
            fChooserItemsGroups fcig = new fChooserItemsGroups(false);
            fcig.Text = "Укажите группу";
            if (fcig.ShowDialog() == DialogResult.OK)
            {
                textBox_treeGroup.Text = fcig.checkedGroupName;
                oDishes.dishesGroup = fcig.checkedGroup[0];
            }
        }
    }
}