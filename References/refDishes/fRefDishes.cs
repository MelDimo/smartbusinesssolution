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
        public fRefDishes()
        {
            InitializeComponent();
            
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
            dtItems = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = " SELECT rd.id, rd.code, rd.name, rd.price, " +
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
            dataGridView_main.Columns["ref_status_name"].DataPropertyName = "ref_status_name";

            tSSLabel_recCount.Text = "Итого записей: " + dtItems.Rows.Count;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            fAddEdit faddedit = new fAddEdit(new Items());
            faddedit.Text = "Новый материал";
            if (faddedit.ShowDialog() == DialogResult.OK) updateData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {

        }

    }

}
