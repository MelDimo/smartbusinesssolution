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
    public partial class fRefPost : Form
    {
        public fRefPost()
        {
            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;

            updateData();
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            fAddEdit faddedit = new fAddEdit();
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow dRow = dataGridView_main.SelectedRows[0];

            fAddEdit faddedit = new fAddEdit(dRow.Cells["id"].Value.ToString(),
                dRow.Cells["name"].Value.ToString(),
                dRow.Cells["status_id"].Value.ToString());
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

            SqlConnection con = new DBCon().getConnection(GValues.DBMode);
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "DELETE FROM ref_post WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = xId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
        }

        private void updateData()
        {
            SqlConnection con = new DBCon().getConnection(GValues.DBMode);
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT rpost.id, rpost.name, rstatus.name status_name, rstatus.id status_id, rstatus.TextColor, rstatus.BackColor " +
                                        " FROM ref_post AS rpost " +
                                        " INNER JOIN ref_status AS rstatus ON rstatus.id = rpost.ref_status";

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
            dataGridView_main.Columns["status_name"].DataPropertyName = "status_name";
            dataGridView_main.Columns["status_id"].DataPropertyName = "status_id";
            dataGridView_main.Columns["textcolor"].DataPropertyName = "textcolor";
            dataGridView_main.Columns["backcolor"].DataPropertyName = "backcolor";

            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }

        private void dataGridView_main_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                dataGridView_main.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(int.Parse(e.Value.ToString()));
            }

            if (e.ColumnIndex == 5)
            {
                dataGridView_main.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(int.Parse(e.Value.ToString()));
            }
        }
    }
}
