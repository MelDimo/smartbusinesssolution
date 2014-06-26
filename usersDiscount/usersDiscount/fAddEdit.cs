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

namespace com.sbs.gui.usersdiscount
{
    public partial class fAddEdit : Form
    {
        DBAccess dbAccess = new DBAccess();

        DTO.DiscountInfo oDiscountInfo;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(DTO.DiscountInfo pDiscountInfo)
        {
            InitializeComponent();

            oDiscountInfo = pDiscountInfo;

            if (oDiscountInfo.id == 0)
            {
                formMode = "ADD";
                oDiscountInfo.refStatus = 1;
            }
            else formMode = "EDIT";

            comboBox_refStatus.DisplayMember = "name";
            comboBox_refStatus.ValueMember = "id";
        }

        private void fAddEdit_Shown(object sender, EventArgs e)
        {
            textBox_fio.Text = oDiscountInfo.fio;
            textBox_id.Text = oDiscountInfo.id.ToString();
            textBox_key.Text = oDiscountInfo.xKey;
            numericUpDown_discount.Value = oDiscountInfo.discount;
            dateTimePicker_dateStart.Value = oDiscountInfo.dateStart;
            dateTimePicker_dateEnd.Value = oDiscountInfo.dateEnd;
            checkBox_dateEnd.Checked = (oDiscountInfo.isExpDate == 1);
            comboBox_refStatus.SelectedValue = oDiscountInfo.refStatus;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string errMsg = "Заполнены не все обязательные поля:";

            oDiscountInfo.fio = textBox_fio.Text.Trim();
            oDiscountInfo.xKey = textBox_key.Text.Trim();
            oDiscountInfo.discount = numericUpDown_discount.Value;
            oDiscountInfo.dateStart = dateTimePicker_dateStart.Value;
            oDiscountInfo.isExpDate = checkBox_dateEnd.Checked ? 1 : 0;
            if (oDiscountInfo.isExpDate == 1) oDiscountInfo.dateEnd = dateTimePicker_dateEnd.Value;
            oDiscountInfo.refStatus = (int)comboBox_refStatus.SelectedValue;

            if (oDiscountInfo.fio.Length == 0) errMsg += Environment.NewLine + " - ФИО;";
            if (oDiscountInfo.xKey.Length == 0) errMsg += Environment.NewLine + " - Ключ;";

            if (!"Заполнены не все обязательные поля:".Equals(errMsg))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            saveData();
        }

        private void saveData()
        {
            try
            {
                switch (formMode)
                {
                    case "ADD":
                        dbAccess.data_add(GValues.DBMode, oDiscountInfo);
                        break;
                    case "EDIT":
                        dbAccess.data_edit(GValues.DBMode, oDiscountInfo);
                        break;
                }
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось сохранить данные.", exc, SystemIcons.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void checkBox_dateEnd_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_dateEnd.Enabled = checkBox_dateEnd.Checked;
        }
    }
}
