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
    public partial class fRefMeasure : Form
    {
        public fRefMeasure()
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
                command.CommandText = "SELECT meas.id, meas.name, meas.name_short, meas.rate, meas.ref_status AS ref_status, stat.name AS ref_status_name " +
                                        " FROM ref_measure meas" +
                                        " INNER JOIN ref_status stat ON stat.id = meas.ref_status";

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
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["name_short"].DataPropertyName = "name_short";
            dataGridView_main.Columns["rate"].DataPropertyName = "rate";
            dataGridView_main.Columns["ref_status"].DataPropertyName = "ref_status";
            dataGridView_main.Columns["ref_status_name"].DataPropertyName = "ref_status_name";
            

            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            Measure oMeasure = new Measure();

            fAddEdit faddedit = new fAddEdit(oMeasure);
            faddedit.Text = "Создание нового";
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();

        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            Measure oMeasure = new Measure();
            
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите удаляемый элемент", SystemIcons.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];

            oMeasure.Id = (int)dr.Cells["id"].Value;
            oMeasure.Name = dr.Cells["name"].Value.ToString();
            oMeasure.NameShort = dr.Cells["name_short"].Value.ToString();
            oMeasure.Rate = (decimal)dr.Cells["rate"].Value;
            oMeasure.RefStatus = (int)dr.Cells["ref_status"].Value;

            fAddEdit faddedit = new fAddEdit(oMeasure);
            faddedit.Text = "Редактирование " + oMeasure.Name;
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
                command.CommandText = "DELETE FROM ref_measure WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = xId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
        }
    }

    public class Measure
    {
        private int _id;
        private string _name;
        private string _nameShort;
        private decimal _rate;
        private int _refStatus;

        public int RefStatus
        {
            get { return _refStatus; }
            set { _refStatus = value; }
        }

        public decimal Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        
        public string NameShort
        {
            get { return _nameShort; }
            set { _nameShort = value; }
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
