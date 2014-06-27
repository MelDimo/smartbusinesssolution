using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;
using System.IO;

namespace com.sbs.gui.usersdiscount
{
    public partial class fMain : Form
    {
        DBAccess dbAccess = new DBAccess();
        getReference oReference = new getReference();

        DTO.DiscountInfo oDiscountInfo;

        DataTable dtStatus;
        DataTable dtDUsers;

        public fMain()
        {
            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;

            tSSLabel_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSSLabel_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSSLabel_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["fio"].DataPropertyName = "fio";
            dataGridView_main.Columns["discount"].DataPropertyName = "discount";
            dataGridView_main.Columns["refStatus"].DataPropertyName = "ref_status";
            dataGridView_main.Columns["dateStart"].DataPropertyName = "date_start";
            dataGridView_main.Columns["dateEnd"].DataPropertyName = "date_end";
            dataGridView_main.Columns["isExpDate"].DataPropertyName = "isExpDate";
            dataGridView_main.Columns["xkey"].DataPropertyName = "xKey";

            intData();
        }

        private void intData()
        {
            dtStatus = new DataTable();

            try
            {
                dtStatus = oReference.getStatus(GValues.DBMode, 1);
            }
            catch (Exception exc) { uMessage.Show("Неудалось загрузить справочники.", exc, SystemIcons.Information); setEnabled(false); }
        }

        private void setEnabled(bool pEnabled)
        {
            toolStrip1.Enabled = pEnabled;
            dataGridView_main.Enabled = pEnabled;
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            showData();
        }

        private void showData()
        {
            dtDUsers = new DataTable();

            try
            {
                dtDUsers = oReference.getDiscountUsers(GValues.DBMode);
            }
            catch (Exception exc) { uMessage.Show("Неудалось получить данные.", exc, SystemIcons.Information); setEnabled(false); }

            dataGridView_main.DataSource = dtDUsers;

            tSSLabel_count.Text = string.Format("Кол-во записей: {0}", dtDUsers.Rows.Count);
        }

        private void tSSLabel_add_Click(object sender, EventArgs e)
        {
            oDiscountInfo = new DTO.DiscountInfo();
            fAddEdit fAE = new fAddEdit(oDiscountInfo);
            fAE.Text = "Новая запись";
            fAE.comboBox_refStatus.DataSource = dtStatus;
            if (fAE.ShowDialog() == DialogResult.OK) showData();
        }

        private void tSSLabel_edit_Click(object sender, EventArgs e)
        {
            int xIndex;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            xIndex = dataGridView_main.SelectedRows[0].Index;

            oDiscountInfo = new DTO.DiscountInfo();
            oDiscountInfo.id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            oDiscountInfo.fio = dataGridView_main.SelectedRows[0].Cells["fio"].Value.ToString();
            oDiscountInfo.xKey = dataGridView_main.SelectedRows[0].Cells["xkey"].Value.ToString();
            oDiscountInfo.discount = (decimal)dataGridView_main.SelectedRows[0].Cells["discount"].Value;
            oDiscountInfo.refStatus = (int)dataGridView_main.SelectedRows[0].Cells["refStatus"].Value;
            oDiscountInfo.dateStart = dataGridView_main.SelectedRows[0].Cells["dateStart"].Value == null ? 
                DateTime.Now : (DateTime)dataGridView_main.SelectedRows[0].Cells["dateStart"].Value;
            oDiscountInfo.dateEnd = dataGridView_main.SelectedRows[0].Cells["dateEnd"].Value == DBNull.Value ?
                DateTime.Now : (DateTime)dataGridView_main.SelectedRows[0].Cells["dateEnd"].Value;
            oDiscountInfo.isExpDate = (int)dataGridView_main.SelectedRows[0].Cells["isExpDate"].Value;

            DataRow dr = (from row in dtDUsers.AsEnumerable()
                      where row.Field<int>("id") == oDiscountInfo.id
                      select row).First();

            oDiscountInfo.photo = Image.FromStream(new MemoryStream((byte[])dr["photo"]));

            
            fAddEdit fAE = new fAddEdit(oDiscountInfo);
            fAE.Text = string.Format("Редактирование '{0}'", oDiscountInfo.fio);
            fAE.comboBox_refStatus.DataSource = dtStatus;
            if (fAE.ShowDialog() == DialogResult.OK)
            {
                showData();
                dataGridView_main.Rows[xIndex].Selected = true;
            }
        }

        private void tSSLabel_del_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oDiscountInfo = new DTO.DiscountInfo();
            oDiscountInfo.id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            oDiscountInfo.fio = dataGridView_main.SelectedRows[0].Cells["fio"].Value.ToString();
            oDiscountInfo.discount = (decimal)dataGridView_main.SelectedRows[0].Cells["discount"].Value;

            if (MessageBox.Show(string.Format("Выуверены что хотите удалить запись о {0} со скидкой в {1}% ?", oDiscountInfo.fio, oDiscountInfo.discount), GValues.prgNameFull,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) return;

            try
            {
                dbAccess.data_del(GValues.DBMode, oDiscountInfo.id);
            }
            catch (Exception exc) { uMessage.Show("Неудалось сохранить данные.", exc, SystemIcons.Information); return; }

            showData();
        }
    }
}
