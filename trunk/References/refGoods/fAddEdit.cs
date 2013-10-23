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

namespace com.sbs.gui.references.goods
{
    public partial class fAddEdit : Form
    {
        Goods oGoods;

        string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(Goods pGood)
        {
            oGoods = pGood;

            InitializeComponent();

            if (oGoods.Id == 0) formMode = "ADD";
            else formMode = "EDIT";
            
            getReference();

            textBox_id.Text = oGoods.Id.ToString();
            textBox_code.Text = oGoods.Code;
            textBox_name.Text = oGoods.Name;
            textBox_manufacturer.Text = oGoods.Manufacturer;
            textBox_note.Text = oGoods.Note;

        }
//---------------------------------------------------------------------------------------
        private void getReference()
        {
            getRefStatus(oGoods.Status);
            getRefMeasure(oGoods.Measure);
            if (formMode == "EDIT") getRefGoodsInfo(oGoods.Id);
        }

        private void getRefGoodsInfo(int pIdGoods)
        {
            DataTable dtGoodsInfo = new DataTable();

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT manufacturer, note FROM ref_goods WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.NVarChar).Value = pIdGoods;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtGoodsInfo.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach (DataRow dr in dtGoodsInfo.Rows)
            {
                oGoods.Manufacturer = dr["manufacturer"].ToString();
                oGoods.Note = dr["note"].ToString();
            }

        }

        private void getRefMeasure(int pRefMeasure)
        {
            DataTable dtMeasure = new DataTable();

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT id, name_short AS name FROM ref_measure WHERE ref_status = 1";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtMeasure.Load(dr);
                }
                con.Close();

                if (dtMeasure.Rows.Count == 0) throw new Exception("Таблица ед. измерения не содержит данных");
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            comboBox_measure.DataSource = dtMeasure;
            comboBox_measure.ValueMember = "id";
            comboBox_measure.DisplayMember = "name";

            comboBox_measure.SelectedValue = pRefMeasure;
        }

        private void getRefStatus(int pRefStatus)
        {
            DataTable dtStatus = new DataTable();

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

                if (dtStatus.Rows.Count == 0) throw new Exception("Таблица статусов не содержит данных");
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            comboBox_status.DataSource = dtStatus;
            comboBox_status.ValueMember = "id";
            comboBox_status.DisplayMember = "name";

            comboBox_status.SelectedValue = pRefStatus;
        }
//-----------------------------------------------------------------------------------------
        private void button_ok_Click(object sender, EventArgs e)
        {
            if (!saveData()) return;

            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            oGoods.Name = textBox_name.Text.Trim();
            oGoods.Manufacturer = textBox_manufacturer.Text.Trim();
            oGoods.Note = textBox_note.Text.Trim();

            if (comboBox_status.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус;";
            else oGoods.Status = (int)comboBox_status.SelectedValue;
            if (comboBox_measure.SelectedValue == null) errMessage += System.Environment.NewLine + "- Ед. измерения;";
            else oGoods.Measure = (int)comboBox_measure.SelectedValue;

            if (oGoods.Name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";

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

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oGoods.Name;
                command.Parameters.Add("code", SqlDbType.NVarChar).Value = oGoods.Code;
                command.Parameters.Add("ref_measure", SqlDbType.Int).Value = oGoods.Measure;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = oGoods.Status;
                command.Parameters.Add("manufacturer", SqlDbType.NVarChar).Value = oGoods.Manufacturer;
                command.Parameters.Add("note", SqlDbType.NVarChar).Value = oGoods.Note;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_goods(code, name, ref_measure, ref_status, manufacturer, note)" +
                                                " VALUES (@code, @name, @ref_measure, @ref_status, @manufacturer, @note)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_goods SET code = @code, name = @name, ref_measure = @ref_measure, ref_status = @ref_status, manufacturer = @manufacturer, note = @note" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oGoods.Id;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw new Exception("Ошибка обработки данных", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return true;
        }
    }
}
