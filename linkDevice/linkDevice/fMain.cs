using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.linkdevice
{
    public partial class fMain : Form
    {
        private DBAccess dbAccess = new DBAccess();

        private DataTable dtDevices;
        Device oDevice;

        public fMain()
        {
            InitializeComponent();
            
            dataGridView_main.AutoGenerateColumns = false;


            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;

            initDBData();

            updateData();
        }

        private void updateData()
        {
            dtDevices = new DataTable();

            try
            {
                dtDevices = dbAccess.getDevices();
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось загрузить данные по мобильным официантам", exc, SystemIcons.Information);
                return;
            }

            dataGridView_main.Columns["id"].DataPropertyName = "ref_dmw";
            dataGridView_main.Columns["season"].DataPropertyName = "season";
            dataGridView_main.Columns["uId"].DataPropertyName = "uId";
            dataGridView_main.Columns["waiter"].DataPropertyName = "fio";
            dataGridView_main.DataSource = dtDevices;
        }

        private void initDBData()
        {
            try
            {
                dbData.dtSeason = dbAccess.getBranchSeason();
                dbData.dtUsers = dbAccess.getBranchUsers();
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось загрузить справочники.", exc, SystemIcons.Information);
                return;
            }
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0) return;

            oDevice = new Device();

            oDevice.id = dataGridView_main.SelectedRows[0].Cells["id"].Value.ToString();
            oDevice.uId = (int)dataGridView_main.SelectedRows[0].Cells["uId"].Value;
            oDevice.season = (int)dataGridView_main.SelectedRows[0].Cells["season"].Value;
            oDevice.uFIO = dataGridView_main.SelectedRows[0].Cells["waiter"].Value.ToString();

            fAddEdit faddedit = new fAddEdit(oDevice);
            faddedit.Text = "Редактирование";
            if (faddedit.ShowDialog() == DialogResult.Cancel) return;
            updateData();
        }
    }
}
