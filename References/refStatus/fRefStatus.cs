using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using System.Data.SqlClient;
using com.sbs.dll.utilites;

namespace com.sbs.gui.references.status
{
    public partial class fRefStatus : Form
    {
        public fRefStatus()
        {

            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;

            updatData();
        }

        private void updatData()
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT id, name, description, textcolor, backcolor FROM ref_status";

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
            dataGridView_main.Columns["description"].DataPropertyName = "description";
            dataGridView_main.Columns["textcolor"].DataPropertyName = "textcolor";
            dataGridView_main.Columns["backcolor"].DataPropertyName = "backcolor";

            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }   

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            fAddEdit faddedit = new fAddEdit();
            faddedit.Text = "Создание нового статуса";
            if (faddedit.ShowDialog() == DialogResult.OK) updatData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataRow = dataGridView_main.SelectedRows[0];
            fAddEdit faddedit = new fAddEdit((int)dataRow.Cells["id"].Value,
                dataRow.Cells["name"].Value.ToString(),
                dataRow.Cells["description"].Value.ToString(),
                int.Parse(dataRow.Cells["textcolor"].Value.ToString()),
                int.Parse(dataRow.Cells["backcolor"].Value.ToString()));
            faddedit.Text = "Редактирование '" + dataRow.Cells["name"].Value.ToString() + "'";
            if (faddedit.ShowDialog() == DialogResult.OK) updatData();

        }

        private void dataGridView_main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                e.CellStyle.BackColor = Color.FromArgb(int.Parse(e.Value.ToString()));
                e.Value = "";
            }
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
                command.CommandText = "DELETE FROM ref_status WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = xId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updatData();
        }
    }
}
