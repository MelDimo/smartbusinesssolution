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

namespace com.sbs.gui.references.contractor
{
    public partial class fContractor : Form
    {
        getReference refer = new getReference();
        DataTable dtRefStatus = new DataTable();
        DataTable dtContrType = new DataTable();

        public fContractor()
        {
            InitializeComponent();

            tSSLabel_recCount.Text = "";

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_copy.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;

            dataGridView_main.AutoGenerateColumns = false;

            getReferences();
        }

        private void getReferences()
        {
            try
            {
                dtRefStatus = refer.getStatus("offline", 1);
                dtContrType = getContrType();
                updateData();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); enabledForm(false); return; }
        }

        private DataTable getContrType()
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT id, name" +
                                        " FROM ref_contractor_type";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dt.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return dt;
        }

        private void enabledForm(bool pIsEnabled)
        {
            toolStrip1.Enabled = pIsEnabled;
            dataGridView_main.Enabled = pIsEnabled;
            statusStrip1.Enabled = pIsEnabled;
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
                command.CommandText = "SELECT contr.id, contr.name, contr.ref_status, stat.name AS ref_status_name" +
                                        " FROM ref_contractor contr" +
                                        " INNER JOIN ref_status stat ON stat.id = contr.ref_status" +
                                        " ORDER BY name";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dt.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); enabledForm(false); return; }
            finally { if (con.State == ConnectionState.Open) tSSLabel_recCount.Text = "Итого записей: 0"; con.Close(); }

            dataGridView_main.DataSource = dt;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["refstatus"].DataPropertyName = "ref_status";
            dataGridView_main.Columns["refstatusname"].DataPropertyName = "ref_status_name";

            tSSLabel_recCount.Text = "Итого записей: " + dt.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            Contractor oContr = new Contractor();
            fAddEdit faddedit = new fAddEdit(oContr);
            faddedit.Text = "Ввод нового элемента";

            faddedit.comboBox_refStatus.DataSource = dtRefStatus;
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refStatus.DisplayMember = "name";

            faddedit.comboBox_contrType.DataSource = dtContrType;
            faddedit.comboBox_contrType.ValueMember = "id";
            faddedit.comboBox_contrType.DisplayMember = "name";

            if (faddedit.ShowDialog() == DialogResult.OK)
            {
                updateData();
                if (dataGridView_main.Rows.Count > 0)
                {
                    dataGridView_main.CurrentCell = dataGridView_main.Rows[dataGridView_main.Rows.Count - 1].Cells[1];
                }
            }

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

            Contractor oContr = new Contractor();
            oContr.id = (int)dr.Cells["id"].Value;
            oContr.name = dr.Cells["name"].Value.ToString();
            oContr.refStatus = (int)dr.Cells["refstatus"].Value;

            fAddEdit faddedit = new fAddEdit(oContr);
            faddedit.Text = "Редактирование " + oContr.name;

            faddedit.comboBox_refStatus.DataSource = dtRefStatus;
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refStatus.DisplayMember = "name";

            faddedit.comboBox_contrType.DataSource = dtContrType;
            faddedit.comboBox_contrType.ValueMember = "id";
            faddedit.comboBox_contrType.DisplayMember = "name";

            if (faddedit.ShowDialog() == DialogResult.OK) updateData();

            dataGridView_main.CurrentCell = dataGridView_main.Rows[index].Cells[1];
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_copy_Click(object sender, EventArgs e)
        {

        }
    }

    public class Contractor
    {
        public Contractor()
        {
            name = string.Empty;
            nameFull = string.Empty;
            fiscalCode = string.Empty;
            passport = string.Empty;
            address = string.Empty;
            tel = string.Empty;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int refStatus { get; set; }

        public int refContractorType { get; set; }
        public string nameFull { get; set; }
        public string fiscalCode { get; set; }
        public string passport { get; set; }
        public string address { get; set; }
        public string tel { get; set; }
    }
}
