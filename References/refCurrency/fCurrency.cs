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

namespace com.sbs.gui.references.currency
{
    public partial class fCurrency : Form
    {
        public fCurrency()
        {
            InitializeComponent();

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_copy.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;
            tSButton_setCourse.Image = com.sbs.dll.utilites.Properties.Resources.combo_26;

            dataGridView_main.AutoGenerateColumns = false;

            updateData();
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];

            if (DialogResult.Yes != MessageBox.Show("Вы уверены, что хотите удалить счет '" + dr.Cells["description"].Value.ToString() + "'?", GValues.prgNameFull,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "DELETE FROM ref_currency WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = (int)dr.Cells["id"].Value;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

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
                command.CommandText = "SELECT rc.id AS IdCurrency, rc.code, rc.name, rc.description,"+
	                                        " ref_currency_type,"+
	                                        " rct.name AS ref_currency_type_name,"+
	                                        " rcc.id AS IdCourse,"+
	                                        " rcc.multiplicity,"+
	                                        " rcc.course,"+
	                                        " rcc.date_start"+
                                        " FROM ref_currency rc"+
                                        " INNER JOIN ref_currency_type rct ON rct.id = rc.ref_currency_type"+
                                        " LEFT JOIN ref_currency_course rcc ON rcc.ref_currency = rc.id " +
	                                        " AND rcc.date_start = (SELECT max(date_start) FROM ref_currency_course WHERE ref_currency = rc.id)"+
                                            " AND rcc.id = (SELECT max(id) FROM ref_currency_course WHERE ref_currency = rc.id)";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dt.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) tSSLabel_recCount.Text = "Итого записей: 0"; con.Close(); }

            dataGridView_main.DataSource = dt;
            dataGridView_main.Columns["id"].DataPropertyName = "IdCurrency";
            dataGridView_main.Columns["code"].DataPropertyName = "code";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["description"].DataPropertyName = "description";
            dataGridView_main.Columns["ref_currency_type"].DataPropertyName = "ref_currency_type";
            dataGridView_main.Columns["ref_currency_type_name"].DataPropertyName = "ref_currency_type_name";
            dataGridView_main.Columns["IdCourse"].DataPropertyName = "IdCourse";
            dataGridView_main.Columns["multiplicity"].DataPropertyName = "multiplicity";
            dataGridView_main.Columns["course"].DataPropertyName = "course";
            dataGridView_main.Columns["date_start"].DataPropertyName = "date_start";

            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }

        private void tSButton_setCourse_Click(object sender, EventArgs e)
        {
            Currency oCurrency = new Currency();
            int index;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];

            oCurrency.id = (int)dr.Cells["id"].Value;
            oCurrency.description = dr.Cells["description"].Value.ToString();
            oCurrency.IdCourse = dr.Cells["IdCourse"].Value == DBNull.Value ? 0 : (int)dr.Cells["IdCourse"].Value;
            oCurrency.multiplicity = dr.Cells["multiplicity"].Value == DBNull.Value ? 0 : (int)dr.Cells["multiplicity"].Value;
            oCurrency.course = dr.Cells["course"].Value == DBNull.Value ? (decimal)0 : (decimal)dr.Cells["course"].Value;
            oCurrency.dateStart = dr.Cells["date_start"].Value == DBNull.Value ? DateTime.Now : (DateTime)dr.Cells["date_start"].Value;

            index = dr.Index;

            fCourse fcourse = new fCourse(oCurrency);
            if (fcourse.ShowDialog() == DialogResult.OK)
            {
                updateData();
            }
        }
    }

    public class Course
    {
        public int IdCourse { get; set; }
        public int multiplicity { get; set; }
        public decimal course { get; set; }
        public DateTime dateStart { get; set; }

        public Course()
        {
            dateStart = DateTime.Now;
        }
    }

    public class Currency : Course
    {
        public int id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public int refCurrencyType { get; set; }
        public string description { get; set; }

        public Currency()
        {
            name = string.Empty;
            description = string.Empty;
        }
    }
}
