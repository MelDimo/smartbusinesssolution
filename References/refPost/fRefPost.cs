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
            faddedit.ShowDialog();

        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {

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
                command.CommandText = "SELECT rpost.id, rpost.name, rstatus.name status, rstatus.TextColor, rstatus.BackColor "+
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
            dataGridView_main.Columns["status"].DataPropertyName = "status";
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
