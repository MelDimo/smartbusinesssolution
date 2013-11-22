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

namespace com.sbs.gui.references.refitems
{
    public partial class fRefItems : Form
    {
        DataTable dtItems = new DataTable();

        public fRefItems()
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
                command.CommandText = " SELECT ri.id," +
                                            " ri.items_type, it.name AS items_type_name," +
                                            " ri.name," +
                                            " ri.nameForSale," +
                                            " ri.ref_measure, rm.name_short AS ref_measure_name," +
                                            " ri.ref_measureForSale, rmForSale.name_short AS ref_measure_nameForSale," +
                                            " ri.koefSale," +
                                            " ri.ref_items_raw, rir.name AS ref_items_raw_name," +
                                            " ri.koefRaw," +
                                            " ri.ref_tmc_type_nomenkl, rttNomenkl.name AS ref_tmc_type_nameNomenkl," +
                                            " ri.ref_tmc_type, rtt.name AS ref_tmc_type_name," +
                                            " ri.ref_status, rs.name AS ref_status_name" +
                                        " FROM ref_items ri" +
                                        " INNER JOIN items_type it ON it.id = ri.items_type" +
                                        " INNER JOIN ref_items_raw rir ON rir.id = ri.ref_items_raw" +
                                        " INNER JOIN ref_tmc_type rtt ON rtt.id = ri.ref_tmc_type" +
                                        " INNER JOIN ref_tmc_type rttNomenkl ON rttNomenkl.id = ri.ref_tmc_type_nomenkl" +
                                        " INNER JOIN ref_measure rm ON rm.id = ri.ref_measure" +
                                        " INNER JOIN ref_measure rmForSale ON rmForSale.id = ri.ref_measureForSale" +
                                        " INNER JOIN ref_status rs ON rs.id = ri.ref_status";

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
            dataGridView_main.Columns["ref_tmc_type_name"].DataPropertyName = "ref_tmc_type_name";
            dataGridView_main.Columns["ref_measure_name"].DataPropertyName = "ref_measure_name";
            dataGridView_main.Columns["ref_status_name"].DataPropertyName = "ref_status_name";

            tSSLabel_recCount.Text = "Итого записей: " + dtItems.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            fAddEdit faddedit = new fAddEdit(new Items());
            faddedit.Text = "Новый материал";
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

            var recData = (from rows in dtItems.AsEnumerable()
                          where rows.Field<int>("id") == (int)dr.Cells["id"].Value
                          select rows).First();

            index = dr.Index;

            Items oItems = new Items();
            oItems.id = (int)recData["id"];
            oItems.itemsType = (int)recData["items_type"];
            oItems.itemsTypeName = recData["items_type_name"].ToString();
            oItems.name = recData["name"].ToString();
            oItems.nameForSale = recData["nameForSale"].ToString();
            oItems.refMeasure = (int)recData["ref_measure"];
            oItems.refMeasureName = recData["ref_measure_name"].ToString();
            oItems.refMeasureForSale = (int)recData["ref_measureForSale"];
            oItems.refMeasureNameForSale = recData["ref_measure_nameForSale"].ToString();
            oItems.koefSale = (decimal)recData["koefSale"];
            oItems.refItemsRaw = (int)recData["ref_items_raw"];
            oItems.refItemsRawName = recData["ref_items_raw_name"].ToString();
            oItems.koefRaw = (decimal)recData["koefRaw"];
            oItems.refTmcTypeNomenkl = (int)recData["ref_tmc_type_nomenkl"];
            oItems.refTmcTypeNameNomenkl = recData["ref_tmc_type_nameNomenkl"].ToString();
            oItems.refTmcType = (int)recData["ref_tmc_type"];
            oItems.refTmcTypeName = recData["ref_tmc_type_name"].ToString();
            oItems.refStatus = (int)recData["ref_status"];

            fAddEdit faddedit = new fAddEdit(oItems);
            faddedit.Text = "Редактирование " + oItems.name;

            if (faddedit.ShowDialog() == DialogResult.OK) updateData();

            dataGridView_main.CurrentCell = dataGridView_main.Rows[index].Cells[1];
        }
        
        private void tSButton_del_Click(object sender, EventArgs e)
        {


        }
    }

    public class Items
    {
        public Items()
        {
            itemsTypeName = string.Empty;
            name = string.Empty;
            nameForSale = string.Empty;
            refMeasureName = string.Empty;
            refMeasureNameForSale = string.Empty;
            refItemsRawName = string.Empty;
            refTmcTypeNameNomenkl = string.Empty;
            refTmcTypeName = string.Empty;
        }

        public int id { get; set; }
        public int itemsType { get; set; }
        public string itemsTypeName { get; set; }
        public string name { get; set; }
        public string nameForSale { get; set; }
        public int refMeasure { get; set; }
        public string refMeasureName { get; set; }
        public int refMeasureForSale { get; set; }
        public string refMeasureNameForSale { get; set; }
        public decimal koefSale { get; set; }
        public int refItemsRaw { get; set; }
        public string refItemsRawName { get; set; }
        public decimal koefRaw { get; set; }
        public int refTmcTypeNomenkl { get; set; }
        public string refTmcTypeNameNomenkl { get; set; }
        public int refTmcType { get; set; }
        public string refTmcTypeName { get; set; }
        public int refStatus { get; set; }
    }
}
