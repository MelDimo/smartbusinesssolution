using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.dto;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.compositionorg
{
    public partial class fAddEdit_branch : Form
    {
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        private DBaccess dbAccess = new DBaccess();
        private CompOrgDTO.BranchDTO oBranchDTO;

        public fAddEdit_branch(CompOrgDTO.BranchDTO pBranchDTO, DataTable pDtOrg, DataTable pDtStatus, DataTable pDtCity)
        {
            InitializeComponent();

            oBranchDTO = pBranchDTO;

            if (oBranchDTO.Id == 0) formMode = "ADD";
            else formMode = "EDIT";

            textBox_id.Text = oBranchDTO.Id.ToString();
            textBox_name.Text = oBranchDTO.Name;

            comboBox_org.DataSource = pDtOrg;
            comboBox_org.DisplayMember = "name";
            comboBox_org.ValueMember = "id";

            comboBox_org.DataSource = pDtOrg;
            comboBox_org.DisplayMember = "name";
            comboBox_org.ValueMember = "id";
            comboBox_org.SelectedValue = oBranchDTO.RefOrg;

            comboBox_refStatus.DataSource = pDtStatus;
            comboBox_refStatus.DisplayMember = "name";
            comboBox_refStatus.ValueMember = "id";
            comboBox_refStatus.SelectedValue = oBranchDTO.RefStatus;

            comboBox_city.DataSource = pDtCity;
            comboBox_city.DisplayMember = "name";
            comboBox_city.ValueMember = "id";
            comboBox_city.SelectedValue = oBranchDTO.RefCity;

            dateTimePicker_open.ShowUpDown = true;
            dateTimePicker_open.CustomFormat = "HH:mm";
            dateTimePicker_open.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker_open.DataBindings.Add("Value", oBranchDTO, "XOpen");

            dateTimePicker_close.ShowUpDown = true;
            dateTimePicker_close.CustomFormat = "HH:mm";
            dateTimePicker_close.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker_close.DataBindings.Add("Value", oBranchDTO, "XClose");

            numericUpDown_duration.DataBindings.Add("Value", oBranchDTO, "XDuration");

            maskedTextBox_IP.DataBindings.Add("Text", oBranchDTO, "Xip");

            numericUpDown_tableCount.DataBindings.Add("Value", oBranchDTO, "XTable");

            numericUpDown_code.DataBindings.Add("Value", oBranchDTO, "Code");
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageBox.Show("Данные успешно сохранены", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            oBranchDTO.Name = textBox_name.Text.Trim();
            oBranchDTO.RefStatus = comboBox_refStatus.SelectedValue == null ? 0 : (int)comboBox_refStatus.SelectedValue;
            oBranchDTO.RefOrg = comboBox_org.SelectedValue == null ? 0 : (int)comboBox_org.SelectedValue;
            oBranchDTO.RefCity = comboBox_city.SelectedValue == null ? 0 : (int)comboBox_city.SelectedValue;

            if (oBranchDTO.Name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (oBranchDTO.RefOrg == 0) errMessage += System.Environment.NewLine + "- Организация;";
            if (oBranchDTO.RefStatus == 0) errMessage += System.Environment.NewLine + "- Статус;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            for (int i = 0; i < checkedListBox_payment.Items.Count; i++)
            {
                //CompOrgDTO.BranchPaymentType obj = (CompOrgDTO.BranchPaymentType)checkedListBox_payment.Items[i];
                oBranchDTO.paymentType[i].isChecked = checkedListBox_payment.GetItemChecked(i);
            }

            switch (formMode)
            {
                case "ADD":
                    try
                    {
                        dbAccess.addBranch("offline", oBranchDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); return false; }
                    break;
                case "EDIT":
                    try
                    {
                        dbAccess.editBranch("offline", oBranchDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); return false; }
                    break;
            }

            return true;
        }

        private void fAddEdit_branch_Shown(object sender, EventArgs e)
        {
            ((ListBox)checkedListBox_payment).DataSource = oBranchDTO.paymentType;
            ((ListBox)checkedListBox_payment).DisplayMember = "name";
            ((ListBox)checkedListBox_payment).ValueMember = "isChecked";

            for (int i = 0; i < checkedListBox_payment.Items.Count; i++)
            {
                CompOrgDTO.BranchPaymentType obj = (CompOrgDTO.BranchPaymentType)checkedListBox_payment.Items[i];
                checkedListBox_payment.SetItemChecked(i, obj.isChecked);
            }
        }
    }
}
