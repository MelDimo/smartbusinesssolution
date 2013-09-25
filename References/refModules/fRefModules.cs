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
using System.IO;

namespace com.sbs.gui.references.modules
{
    public partial class fRefModules : Form
    {
        public fRefModules()
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
                command.CommandText = "SELECT id, fname, fpath, assembly_name, isGUI FROM ref_modules";

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
            dataGridView_main.Columns["fname"].DataPropertyName = "fname";
            dataGridView_main.Columns["fpath"].DataPropertyName = "fpath";
            dataGridView_main.Columns["assembly_name"].DataPropertyName = "assembly_name";
            dataGridView_main.Columns["isGUI"].DataPropertyName = "isGUI";

            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            fAddEdit faddedit = new fAddEdit();
            faddedit.Text = "Создание новой записи";
            if (faddedit.ShowDialog() != DialogResult.OK) return;

            updateData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите редактируемый элемент", SystemIcons.Information);
                return;
            }

            DataGridViewRow dataRow = dataGridView_main.SelectedRows[0];

            fAddEdit faddedit = new fAddEdit(dataRow.Cells["id"].Value.ToString(),
                dataRow.Cells["fpath"].Value.ToString(),
                dataRow.Cells["assembly_name"].Value.ToString(),
                dataRow.Cells["isGUI"].Value.ToString());
            faddedit.Text = "Редактирование записи '" + Path.GetFileName(dataRow.Cells["fpath"].Value.ToString()) + "'";
            if (faddedit.ShowDialog() != DialogResult.OK) return;

            updateData();
                
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите удаляемый элемент", SystemIcons.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены что хотите удалить элемент '" +
               Path.GetFileName(dataGridView_main.SelectedRows[0].Cells["fpath"].Value.ToString()) + "'",
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
                command.CommandText = "DELETE FROM ref_modules WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = xId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
        }
    }
}
