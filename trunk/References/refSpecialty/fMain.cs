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

namespace com.sbs.gui.references.refspecialty
{
    public partial class fMain : Form
    {
        DBAccess dbAccess = new DBAccess();
        getReference oReference = new getReference();
        Specialty oSpecialty;

        DataTable dtData;
        DataTable dtStatus;

        public fMain()
        {
            InitializeComponent();

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            dataGridView_main.AutoGenerateColumns = false;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.Columns["refStatus"].DataPropertyName = "ref_status";

            initData();
            getData();
        }

        private void initData()
        {
            dtStatus = new DataTable();

            try
            {
                dtStatus = oReference.getStatus(GValues.DBMode, 1);
            }
            catch (Exception exc) { uMessage.Show("Неудалось получить данные", exc, SystemIcons.Information); setEnabled(false); return; }
        }

        private void getData()
        {
            dtData = new DataTable();

            try
            {
                dtData = dbAccess.data_get();
            }
            catch (Exception exc) { uMessage.Show("Неудалось получить данные", exc, SystemIcons.Information); setEnabled(false); return; }

            dataGridView_main.DataSource = dtData;
        }

        private void setEnabled(bool pEnabled)
        {
            toolStrip1.Enabled = pEnabled;
            dataGridView_main.Enabled = pEnabled;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            oSpecialty = new Specialty();

            fAddEdit fAE = new fAddEdit(oSpecialty);
            fAE.comboBox_status.DataSource = dtStatus;
            fAE.comboBox_status.DisplayMember = "name";
            fAE.comboBox_status.ValueMember = "id";
            fAE.Text = "Новая запись";
            if(fAE.ShowDialog() != DialogResult.OK) return;

            getData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            oSpecialty = new Specialty();

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oSpecialty.id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            oSpecialty.name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();
            oSpecialty.refStatus = (int)dataGridView_main.SelectedRows[0].Cells["refStatus"].Value;

            fAddEdit fAE = new fAddEdit(oSpecialty);
            fAE.comboBox_status.DataSource = dtStatus;
            fAE.comboBox_status.DisplayMember = "name";
            fAE.comboBox_status.ValueMember = "id";
            fAE.Text = "Редактирование '" + oSpecialty.name + "'";
            if (fAE.ShowDialog() != DialogResult.OK) return;

            getData();

            for(int i = 0; i < dataGridView_main.Rows.Count; i++)
            {
                if ((int)dataGridView_main.Rows[i].Cells["id"].Value == oSpecialty.id)
                {
                    dataGridView_main.Rows[i].Selected = true;
                }
            }
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {
            oSpecialty = new Specialty();

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для удаления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oSpecialty.id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            oSpecialty.name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();

            if (MessageBox.Show("Вы уверены что хотите удалить '" + oSpecialty.name + "'", GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) return;

            try
            {
                dbAccess.data_del(oSpecialty.id);
            }
            catch (Exception exc) { uMessage.Show("Неудалось удалить '" + oSpecialty.name + "'", exc, SystemIcons.Information); setEnabled(false); return; }

            getData();
        }
    }
}
