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

namespace com.sbs.gui.references.refdishes
{
    public partial class fRefDishes : Form
    {
        DataTable dtItems;
        DataTable dtRefPrintresType;
        DataTable dtRefStatus;

        DTO.Dishes oDishes;

        fAddEdit faddedit;

        public fRefDishes()
        {
            InitializeComponent();
            
            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            dataGridView_main.AutoGenerateColumns = false;
            
            initTables();

            updateData();
        }

        private void initTables()
        {
            getReference oReferences = new getReference();

            try
            {
                dtRefStatus = oReferences.getStatus("offline", 1);
                dtRefPrintresType = oReferences.getRefPrintersType("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочников", exc, SystemIcons.Error); return; }
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
                command.CommandText = " SELECT rd.id, rd.code, rd.name, rd.price, rd.minStep" +
                                            " rd.ref_printers_type," +
                                            " rd.ref_status, rs.name AS ref_status_name" +
                                        " FROM ref_dishes rd" +
                                        " INNER JOIN ref_status rs ON rs.id = rd.ref_status";

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
            dataGridView_main.Columns["code"].DataPropertyName = "code";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["price"].DataPropertyName = "price";
            dataGridView_main.Columns["minStep"].DataPropertyName = "minStep";
            dataGridView_main.Columns["ref_status_name"].DataPropertyName = "ref_status_name";

            tSSLabel_recCount.Text = "Итого записей: " + dtItems.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            oDishes = new DTO.Dishes();

            faddedit = new fAddEdit(oDishes);
            faddedit.comboBox_refStatus.DataSource = dtRefStatus;
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refPrintersType.DataSource = dtRefPrintresType;
            faddedit.comboBox_refPrintersType.DisplayMember = "name";
            faddedit.comboBox_refPrintersType.ValueMember = "id";
            faddedit.Text = "Новое блюдо";
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            oDishes = new DTO.Dishes();
            DataRow dishInfo;

            int rowIndex = 0;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow dataRow = dataGridView_main.SelectedRows[0];
            rowIndex = dataRow.Index;

            oDishes.id = (int)dataRow.Cells["id"].Value;

            dishInfo = (from rec in dtItems.AsEnumerable()
                           where rec.Field<int>("id") == oDishes.id
                           select rec).First();

            oDishes.code = dishInfo.Field<int>("code");
            oDishes.name = dishInfo.Field<string>("name");
            oDishes.price = dishInfo.Field<decimal>("price");
            oDishes.refStatus = dishInfo.Field<int>("ref_status");
            oDishes.refPrintersType = dishInfo.Field<int>("ref_printers_type");

            faddedit = new fAddEdit(oDishes);
            faddedit.comboBox_refStatus.DataSource = dtRefStatus;
            faddedit.comboBox_refStatus.DisplayMember = "name";
            faddedit.comboBox_refStatus.ValueMember = "id";
            faddedit.comboBox_refStatus.SelectedValue = oDishes.refStatus;
            faddedit.comboBox_refPrintersType.DataSource = dtRefPrintresType;
            faddedit.comboBox_refPrintersType.DisplayMember = "name";
            faddedit.comboBox_refPrintersType.ValueMember = "id";
            faddedit.comboBox_refPrintersType.SelectedValue = oDishes.refPrintersType;
            faddedit.Text = "Редактирование блюда '" + oDishes.name + "'";
            if (faddedit.ShowDialog() == DialogResult.OK)
            {
                updateData();
                dataGridView_main.CurrentCell = dataGridView_main.Rows[rowIndex].Cells[1];
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
                dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString().Trim() + "'?",
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
                command.CommandText = "DELETE FROM ref_dishes WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = xId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            updateData();
        }

        private void dataGridView_main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    tSButton_edit_Click(null, new EventArgs());
                    break;
                case Keys.Insert:
                    tSButton_add_Click(null, new EventArgs());
                    break;
                case Keys.Delete:
                    tSButton_del_Click(null, new EventArgs());
                    break;
            }

            e.SuppressKeyPress = true;
        }

    }
}
