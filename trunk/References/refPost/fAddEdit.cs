using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.references.post
{
    public partial class fAddEdit : Form
    {
        bool changeData = false;
        string formMode; // В каком режиме диалог "EDIT"/"ADD"

        DataTable dtStatus = new DataTable();

        public fAddEdit()
        {
            InitializeComponent();

            formMode = "ADD";

            getRefStatus(0);
        }

        public fAddEdit(string pId, string pName, string pRefStatus)
        {
            InitializeComponent();

            formMode = "EDIT";

            textBox_id.Text = pId;
            textBox_name.Text = pName;

            getRefStatus(int.Parse(pRefStatus));
        }

        private void getRefStatus(int pRefStatus)
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT id, name FROM ref_status";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtStatus.Load(dr);
                }
                con.Close();

                if (dtStatus.Rows.Count == 0) throw new Exception("Таблица справочников не содержит данных");
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            comboBox_status.DataSource = dtStatus;
            comboBox_status.ValueMember = "id";
            comboBox_status.DisplayMember = "name";

            comboBox_status.SelectedValue = pRefStatus;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            saveData();
            if(changeData == true) DialogResult = DialogResult.OK;
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
            int xIdStatus = 0;

            if(comboBox_status.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус должности;";
            else xIdStatus = (int)comboBox_status.SelectedValue;

            if (xName.Length == 0) errMessage += System.Environment.NewLine + "- Наименование должности;";

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
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = xIdStatus;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_post(name, ref_status)" +
                                                " VALUES (@name, @ref_status)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_post SET name = @name, ref_status = @ref_status" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = textBox_id.Text;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); changeData = false;  return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            changeData = true;
        }
    }
}
