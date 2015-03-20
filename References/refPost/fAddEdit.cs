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
using com.sbs.dll.utilites.Controls;

namespace com.sbs.gui.references.post
{
    public partial class fAddEdit : Form
    {
        bool changeData = false;
        string formMode; // В каком режиме диалог "EDIT"/"ADD"

        DataTable dtStatus = new DataTable();
        DataTable dtParam = new DataTable();

        private int postId;

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

            postId =  int.Parse(pId);
            textBox_id.Text = pId;
            textBox_name.Text = pName;

            getParam();
            getRefStatus(int.Parse(pRefStatus));
        }

        private void getParam()
        {
            SqlConnection con = new DBCon().getConnection(GValues.DBMode);
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT valueBottom, valueTop, valueFULL FROM ref_post_param WHERE ref_post = @ref_post";
                command.Parameters.Add("ref_post", SqlDbType.Int).Value = postId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtParam.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach (DataRow dr in dtParam.Rows)
            {
                textBox_bottom.Text = dr["valueBottom"].ToString();
                textBox_top.Text = dr["valueTop"].ToString();
                textBox_full.Text = dr["valueFULL"].ToString();
            }

        }

        private void getRefStatus(int pRefStatus)
        {
            SqlConnection con = new DBCon().getConnection(GValues.DBMode);
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


            decimal valueBottom;
            decimal valueTop;
            decimal valueFULL;

            if (!decimal.TryParse(textBox_bottom.Text, out valueBottom)) errMessage += System.Environment.NewLine + "- Мин. кол-во часов для учета 0,5 смены;";
            if (!decimal.TryParse(textBox_top.Text, out valueTop)) errMessage += System.Environment.NewLine + "- Мин. кол-во часов для учета 1,0 смены";
            if (!decimal.TryParse(textBox_full.Text, out valueFULL)) errMessage += System.Environment.NewLine + "- Кол-во часов в смене";


            if(comboBox_status.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус должности;";
            else xIdStatus = (int)comboBox_status.SelectedValue;

            if (xName.Length == 0) errMessage += System.Environment.NewLine + "- Наименование должности;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return;
            }

            SqlConnection con = new DBCon().getConnection(GValues.DBMode);
            SqlCommand command = null;
            SqlTransaction transaction = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();

                command = con.CreateCommand();
                transaction = con.BeginTransaction();
                command.Connection = con;
                command.Transaction = transaction;

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = xName;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = xIdStatus;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_post(name, ref_status) VALUES (@name, @ref_status); " +
                                                " SELECT CAST(scope_identity() AS int)";

                        postId = (Int32)command.ExecuteScalar();
                        
                        command.CommandText = "INSERT INTO ref_post_param(ref_post, valueBottom, valueTop, valueFULL)" +
                                                " VALUES (@ref_post, @valueBottom, @valueTop, @valueFULL)";

                        command.Parameters.Clear();
                        command.Parameters.Add("ref_post", SqlDbType.Int).Value = postId;
                        command.Parameters.Add("valueBottom", SqlDbType.Decimal).Value = valueBottom;
                        command.Parameters.Add("valueTop", SqlDbType.Decimal).Value = valueTop;
                        command.Parameters.Add("valueFULL", SqlDbType.Decimal).Value = valueFULL;

                        command.ExecuteNonQuery();

                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_post SET name = @name, ref_status = @ref_status" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = textBox_id.Text;

                        command.ExecuteNonQuery();

                        command.CommandText = "UPDATE ref_post_param SET valueBottom = @valueBottom, valueTop = @valueTop, valueFULL = @valueFULL " +
                                                " WHERE ref_post = @ref_post";
                        command.Parameters.Clear();
                        command.Parameters.Add("ref_post", SqlDbType.Int).Value = postId;
                        command.Parameters.Add("valueBottom", SqlDbType.Decimal).Value = valueBottom;
                        command.Parameters.Add("valueTop", SqlDbType.Decimal).Value = valueTop;
                        command.Parameters.Add("valueFULL", SqlDbType.Decimal).Value = valueFULL;

                        command.ExecuteNonQuery();

                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }


                transaction.Commit();
                con.Close();
            }
            catch (Exception exc) 
            { 
                transaction.Rollback(); 
                uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); 
                changeData = false; 
                return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            changeData = true;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                //Цифры
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    return;
                }
                //Точку заменим запятой
                if (e.KeyChar == '.')
                {
                    e.KeyChar = ',';
                }

                if (e.KeyChar == ',')
                {
                    if (((TextBox)sender).Text.IndexOf(',') != -1)
                    {
                        //Уже есть одна запятая в textBox1
                        e.Handled = true;
                    }
                    return;
                }

                //Управляющие клавиши <Backspace>, <Enter> и т.д.
                if (Char.IsControl(e.KeyChar))
                {
                    return;
                }

                //Остальное запрещено
                e.Handled = true;
            }
        }
    }
}
