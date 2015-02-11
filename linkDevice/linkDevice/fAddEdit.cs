using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.linkdevice
{
    public partial class fAddEdit : Form
    {
        DBAccess dbAccess = new DBAccess();

        Device oDevice;

        public fAddEdit(Device pDevice)
        {
            InitializeComponent();

            oDevice = pDevice;

            comboBox_season.DataSource = dbData.dtSeason;
            comboBox_season.DisplayMember = "season";
            comboBox_season.ValueMember = "id";
            comboBox_season.SelectedValue = oDevice.season;

            comboBox_waiter.DataSource = dbData.dtUsers;
            comboBox_waiter.DisplayMember = "fio";
            comboBox_waiter.ValueMember = "id";
            comboBox_waiter.SelectedValue = oDevice.uId;

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            oDevice.season = (int)comboBox_season.SelectedValue;
            oDevice.uId = (int)comboBox_waiter.SelectedValue;

            try
            {
                dbAccess.saveDevice(oDevice);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось сохранить данные.", exc, SystemIcons.Information);
                return;
            }

            DialogResult = DialogResult.OK;

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fAddEdit_Shown(object sender, EventArgs e)
        {
            textBox_device.Text = oDevice.id;
            textBox_branch.Text = string.Format("{0} ({1})", GValues.branchName, GValues.branchId.ToString());
        }
    }
}
