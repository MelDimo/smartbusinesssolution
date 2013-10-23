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

namespace com.sbs.gui.references.refDepot
{
    public partial class fDepot : Form
    {
        DataSet dsRef = new DataSet();

        public fDepot()
        {
            InitializeComponent();

            tSSLabel_recCount.Text = "";

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            dataGridView_main.AutoGenerateColumns = false;

            updateData();
        }

        private void fDepot_Shown(object sender, EventArgs e)
        {
            getReference oReference = new getReference();

            try
            {
                dsRef.Tables.Add(oReference.getOrganization("offline"));
                dsRef.Tables.Add(oReference.getBranch("offline"));
                dsRef.Tables.Add(oReference.getUnit("offline"));
                dsRef.Tables.Add(oReference.getStatus("offline"));
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
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
                command.CommandText = "SELECT dep.id, dep.name, " +
                                        "   dep.organization, org.name AS orgName," +
                                        "   dep.branch, b.name AS branchName," +
                                        "   dep.unit, u.name AS unitName," +
                                        "   stat.id AS ref_status," +
                                        "   stat.name AS ref_status_name" +
                                        " FROM ref_depot dep" +
                                        "   INNER JOIN organization org ON org.id = dep.organization" +
                                        "   INNER JOIN branch b ON b.id = dep.branch" +
                                        "   INNER JOIN unit u ON u.id = dep.unit" +
                                        "   INNER JOIN ref_status stat ON stat.id = dep.ref_status";

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
            dataGridView_main.Columns["organization"].DataPropertyName = "organization";
            dataGridView_main.Columns["orgName"].DataPropertyName = "orgName";
            dataGridView_main.Columns["branch"].DataPropertyName = "branch";
            dataGridView_main.Columns["branchName"].DataPropertyName = "branchName";
            dataGridView_main.Columns["unit"].DataPropertyName = "unit";
            dataGridView_main.Columns["unitName"].DataPropertyName = "unitName";
            dataGridView_main.Columns["ref_status"].DataPropertyName = "ref_status";
            dataGridView_main.Columns["ref_status_name"].DataPropertyName = "ref_status_name";

            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            fAddEdit faddedit = new fAddEdit(new Depot(), dsRef);
            faddedit.Text = "Ввод нового склада";
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            DataGridViewRow dr = dataGridView_main.SelectedRows[0];

            Depot oDepot = new Depot();
            oDepot.id = (int)dr.Cells["id"].Value;
            oDepot.name = dr.Cells["name"].Value.ToString();
            oDepot.organization = (int)dr.Cells["organization"].Value;
            oDepot.branch = (int)dr.Cells["branch"].Value;
            oDepot.unit = (int)dr.Cells["unit"].Value;
            oDepot.ref_status = (int)dr.Cells["ref_status"].Value;

            fAddEdit faddedit = new fAddEdit(oDepot, dsRef);
            faddedit.Text = "Редактирование склада " + oDepot.name;
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];

            if (DialogResult.Yes != MessageBox.Show("Вы уверены, что хотите удалить склад '" + dr.Cells["name"].Value.ToString() + "'?",GValues.prgNameFull,
                MessageBoxButtons.YesNo,MessageBoxIcon.Question))
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
                command.CommandText = "DELETE FROM depot WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = (int)dr.Cells["id"].Value;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка удаления данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
            
        }
    }

    public class Depot
    {
        public int id { set; get; }
        public string name { set; get; }
        public int organization { set; get; }
        public int branch { set; get; }
        public int unit { set; get; }
        public int ref_status { set; get; }
    }
}
