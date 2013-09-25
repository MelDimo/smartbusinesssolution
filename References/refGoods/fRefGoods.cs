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
    public partial class fRefGoods : Form
    {
        public fRefGoods()
        {
            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;

            updateData();
        }

        private void updateData()
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT goods.id, goods.code, goods.name, goods.ref_measure, measure.name_short AS ref_measure_name, goods.ref_status, stat.name AS ref_status_name  " +
                                        " FROM ref_goods goods" +
                                        " INNER JOIN ref_status stat ON stat.id = goods.ref_status"+
                                        " INNER JOIN ref_measure measure ON measure.id = goods.ref_measure";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dt.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            dataGridView_main.DataSource = dt;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["code"].DataPropertyName = "code";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["ref_measure"].DataPropertyName = "ref_measure";
            dataGridView_main.Columns["ref_measure_name"].DataPropertyName = "ref_measure_name";
            dataGridView_main.Columns["ref_status"].DataPropertyName = "ref_status";
            dataGridView_main.Columns["ref_status_name"].DataPropertyName = "ref_status_name";


            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {

            fAddEdit faddedit = new fAddEdit(new Goods());
            faddedit.Text = "Ввод нового продукта";
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            Goods oGoods = new Goods();

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите удаляемый элемент", SystemIcons.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];

            oGoods.Id = (int)dr.Cells["id"].Value;
            oGoods.Code = (int)dr.Cells["code"].Value;
            oGoods.Name = dr.Cells["name"].Value.ToString();
            oGoods.Measure = (int)dr.Cells["ref_measure"].Value;
            oGoods.Status = (int)dr.Cells["ref_status"].Value;

            fAddEdit faddedit = new fAddEdit(oGoods);
            faddedit.Text = "Редактирование '" + oGoods.Name + "'";
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите удаляемый элемент", SystemIcons.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены что шотите удалить элемент '" +
                dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString() + "'",
                GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            int xId = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "DELETE FROM ref_goods WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = xId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
        }
    }

    public class Goods
    {
        private int _id;
        private int _code;
        private string _name;
        private int _measure;
        private int _status;
        private string _manufacturer;
        private string _note;

        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
        
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        public int Measure
        {
            get { return _measure; }
            set { _measure = value; }
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
            
    }
}
