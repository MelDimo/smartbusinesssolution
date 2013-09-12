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

namespace com.sbs.gui.references.menutype
{
    public partial class fAddEdit : Form
    {
        bool changeData = false;
        string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit()
        {
            InitializeComponent();

            formMode = "ADD";
        }

        public fAddEdit(string pId, string pName)
        {
            InitializeComponent();

            formMode = "EDIT";

            textBox_id.Text = pId;
            textBox_name.Text = pName;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            saveData();
            DialogResult = DialogResult.OK;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (changeData) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }

        private void saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            string xName = textBox_name.Text.Trim();

            if (xName.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return;
            }

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = xName;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_modules(name)" +
                                                " VALUES (@name)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_modules SET name = @name" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = textBox_id.Text;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            changeData = true;
        }


    }
}
