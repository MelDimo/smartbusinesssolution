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

namespace com.sbs.gui.references.accounts
{
    public partial class fAcc : Form
    {
        public fAcc()
        {
            InitializeComponent();

            tSSLabel_recCount.Text = "";

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

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
                command.CommandText = "SELECT id, group_I, group_I_I, group_II, name" +
                                        " FROM ref_accounts"+
                                        " ORDER BY group_I, group_I_I, group_II";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dt.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) tSSLabel_recCount.Text = "Итого записей: 0"; con.Close(); }

            dataGridView_main.DataSource = dt;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["group_I"].DataPropertyName = "group_I";
            dataGridView_main.Columns["group_I_I"].DataPropertyName = "group_I_I";
            dataGridView_main.Columns["group_II"].DataPropertyName = "group_II";
            dataGridView_main.Columns["name"].DataPropertyName = "name";

            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            Account oAcc = new Account();
            fAddEdit faddedit = new fAddEdit(oAcc);
            faddedit.Text = "Ввод нового элемента";
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();
            
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            int index;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];

            index = dr.Index;

            Account oAcc = new Account();
            oAcc.id = (int)dr.Cells["id"].Value;
            oAcc.name = dr.Cells["name"].Value.ToString();
            oAcc.group_I = (int)dr.Cells["group_I"].Value;
            oAcc.group_I_I = (int)dr.Cells["group_I_I"].Value;
            oAcc.group_II = (int)dr.Cells["group_II"].Value;


            fAddEdit faddedit = new fAddEdit(oAcc);
            faddedit.Text = "Редактирование " + oAcc.name;
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();

            //dataGridView_main.Rows[index].Selected = true;
            dataGridView_main.CurrentCell = dataGridView_main.Rows[index].Cells[1];
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];

            if (DialogResult.Yes != MessageBox.Show("Вы уверены, что хотите удалить счет '" + dr.Cells["name"].Value.ToString() + "'?", GValues.prgNameFull,
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
                command.CommandText = "DELETE FROM ref_accounts WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = (int)dr.Cells["id"].Value;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
        }
    }

    public class Account
    {
        public int id { get; set; }
        public int group_I { get; set; }
        public int group_I_I { get; set; }
        public int group_II { get; set; }
        public string name { get; set; }
    }
}
