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

namespace com.sbs.gui.references.accounts
{
    public partial class fAddEdit : Form
    {
        Account oAcc = new Account();
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(Account pAcc)
        {
            oAcc = pAcc;

            InitializeComponent();

            if (oAcc.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            textBox_I.DataBindings.Add("Text", oAcc, "group_I");
            textBox_I_I.DataBindings.Add("Text", oAcc, "group_I_I");
            textBox_II.DataBindings.Add("Text", oAcc, "group_II");
            textBox_name.DataBindings.Add("Text", oAcc, "name");
            textBox_id.DataBindings.Add("Text", oAcc, "id");

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

            if (oAcc.group_I == 0) errMessage += System.Environment.NewLine + "- Код группы счетов 1-го порядка;";
            if (oAcc.group_I_I == 0) errMessage += System.Environment.NewLine + "- Код группы счетов 1-го порядка;";
            if (oAcc.group_II == 0) errMessage += System.Environment.NewLine + "- Код группы счетов 2-го порядка;";
            if (oAcc.name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";


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

                command.Parameters.Add("group_I", SqlDbType.Int).Value = oAcc.group_I;
                command.Parameters.Add("group_I_I", SqlDbType.Int).Value = oAcc.group_I_I;
                command.Parameters.Add("group_II", SqlDbType.Int).Value = oAcc.group_II;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oAcc.name;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_accounts(group_I, group_I_I, group_II, name)" +
                                                " VALUES (@group_I, @group_I_I, @group_II, @name)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_accounts SET group_I = @group_I, group_I_I = @group_I_I, group_II = @group_II, name = @name" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oAcc.id;
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
