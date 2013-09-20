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

namespace com.sbs.gui.references.measure
{
    public partial class fAddEdit : Form
    {
        Measure oMeasure;
        DataTable dtStatus = new DataTable();

        string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(Measure pMeasure)
        {
            InitializeComponent();

            oMeasure = pMeasure;

            if (oMeasure.Id == 0) formMode = "ADD";
            else formMode = "EDIT";

            textBox_id.Text = oMeasure.Id.ToString();
            textBox_name.Text = oMeasure.Name;
            textBox_nameShort.Text = oMeasure.NameShort;
            textBox_measure.Text = oMeasure.Rate.ToString();

            getRefStatus(oMeasure.RefStatus);
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

            comboBox_refStatus.DataSource = dtStatus;
            comboBox_refStatus.ValueMember = "id";
            comboBox_refStatus.DisplayMember = "name";

            comboBox_refStatus.SelectedValue = pRefStatus;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            saveData();
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void saveData()
        {
            decimal xRate;

            string errMessage = "Заполнены не все обязательные поля:";
            oMeasure.Name = textBox_name.Text.Trim();
            oMeasure.NameShort = textBox_nameShort.Text.Trim();

            if (decimal.TryParse(textBox_measure.Text, out xRate)) oMeasure.Rate = xRate;
            else errMessage += System.Environment.NewLine + "- Измерение;";

            if (comboBox_refStatus.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус;";
            else oMeasure.RefStatus = (int)comboBox_refStatus.SelectedValue;

            if (oMeasure.Name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (oMeasure.NameShort.Length == 0) errMessage += System.Environment.NewLine + "- Краткое наименование;";

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

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oMeasure.Name;
                command.Parameters.Add("name_short", SqlDbType.NVarChar).Value = oMeasure.NameShort;
                command.Parameters.Add("rate", SqlDbType.Int).Value = oMeasure.Rate;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = oMeasure.RefStatus;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_measure(name, name_short, rate, ref_status)" +
                                                " VALUES (@name, @name_short, @rate, @ref_status)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_measure SET name = @name, name_short = @name_short, rate = @rate, ref_status = @ref_status" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oMeasure.Id;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
    }
}
