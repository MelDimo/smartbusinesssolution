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

namespace refAddCostsType
{
    public partial class fAddCostsType : Form
    {
        DataTable dtItems;

        public fAddCostsType()
        {
            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            updateData();
        }

        private void updateData()
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            dtItems = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = " SELECT rac.id, rac.name, " +
                                            " rac.ref_accounts, ltrim(str(acc.group_II) + ' (' + acc.name + ')') AS ref_accounts_name, " +
                                            " rac.ref_contractor, rc.name AS ref_contractor_name " +
                                        " FROM ref_additionalCost rac " +
                                        " INNER JOIN ref_accounts acc ON acc.id = rac.ref_accounts " +
                                        " INNER JOIN ref_contractor rc ON rc.id = rac.ref_contractor";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtItems.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) tSSLabel_recCount.Text = "Итого записей: 0"; con.Close(); }

            dataGridView_main.DataSource = dtItems;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["ref_accounts"].DataPropertyName = "ref_accounts";
            dataGridView_main.Columns["ref_accounts_name"].DataPropertyName = "ref_accounts_name";
            dataGridView_main.Columns["ref_contractor"].DataPropertyName = "ref_contractor";
            dataGridView_main.Columns["ref_contractor_name"].DataPropertyName = "ref_contractor_name";

            tSSLabel_recCount.Text = "Итого записей: " + dtItems.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            fAddEdit faddedit = new fAddEdit(new Items());
            faddedit.Text = "Новый вид доп. расходов";
            faddedit.ShowDialog();
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

            Items oItems = new Items();
            oItems.id = (int)dr.Cells["id"].Value;
            oItems.name = dr.Cells["id"].Value.ToString();
            oItems.refAccounts = (int)dr.Cells["ref_accounts"].Value;
            oItems.refAccountsName = dr.Cells["ref_accounts_name"].Value.ToString();
            oItems.refContractor = (int)dr.Cells["ref_contractor"].Value;
            oItems.refContractorName = dr.Cells["ref_contractor_name"].Value.ToString();

            fAddEdit faddedit = new fAddEdit(oItems);
            faddedit.Text = "Редактирование " + oItems.name;

            if (faddedit.ShowDialog() == DialogResult.OK) updateData();

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

            if (DialogResult.Yes != MessageBox.Show("Вы уверены, что хотите удалить '" + dr.Cells["name"].Value.ToString() + "'?", GValues.prgNameFull,
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
                command.CommandText = "DELETE FROM ref_additionalCost WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = (int)dr.Cells["id"].Value;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
        }
    }

    public class Items
    {
        public int id { set; get; }
        public string name { set; get; }
        public int refAccounts { set; get; }
        public string refAccountsName { set; get; }
        public int refContractor { set; get; }
        public string refContractorName { set; get; }

    }

}
