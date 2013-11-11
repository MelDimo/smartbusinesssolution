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

namespace com.sbs.gui.compositionorg
{
    public partial class fAddEdit_unit : Form
    {
        private bool changeData = false;
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        private DBaccess dbAccess = new DBaccess();
        private CompOrgDTO.UnitDTO oUnitDTO;

        public fAddEdit_unit(CompOrgDTO.UnitDTO pUnitDTO, DataTable pDtBranch, DataTable pDtStatus, DataTable pDtPrinters, DataTable pDtPrintersType)
        {
            InitializeComponent();

            oUnitDTO = pUnitDTO;

            if (oUnitDTO.Id == 0) formMode = "ADD";
            else formMode = "EDIT";

            textBox_id.Text = pUnitDTO.Id.ToString();
            textBox_name.Text = pUnitDTO.Name;

            comboBox_branch.DataSource = pDtBranch;
            comboBox_branch.ValueMember = "id";
            comboBox_branch.DisplayMember = "name";
            comboBox_branch.SelectedValue = oUnitDTO.Branch;

            comboBox_refStatus.DataSource = pDtStatus;
            comboBox_refStatus.ValueMember = "id";
            comboBox_refStatus.DisplayMember = "name";
            comboBox_refStatus.SelectedValue = oUnitDTO.RefStatus;

            comboBox_refPrinters.DataSource = pDtPrinters;
            comboBox_refPrinters.ValueMember = "id";
            comboBox_refPrinters.DisplayMember = "name";
            comboBox_refPrinters.SelectedValue = oUnitDTO.RefPrinters;

            comboBox_refPrintersType.DataSource = pDtPrintersType;
            comboBox_refPrintersType.ValueMember = "id";
            comboBox_refPrintersType.DisplayMember = "name";
            comboBox_refPrintersType.SelectedValue = oUnitDTO.RefPrintersType;

            checkBox_isDepot.DataBindings.Add("Checked", oUnitDTO, "isDepot");

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            saveData();
            DialogResult = DialogResult.OK;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (changeData) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }

        private void saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            oUnitDTO.Name = textBox_name.Text.Trim();
            oUnitDTO.RefStatus = comboBox_refStatus.SelectedValue == null ? 0 : (int)comboBox_refStatus.SelectedValue;
            oUnitDTO.Branch = comboBox_branch.SelectedValue == null ? 0 : (int)comboBox_branch.SelectedValue;

            if (oUnitDTO.Name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (oUnitDTO.Branch == 0) errMessage += System.Environment.NewLine + "- Заведение;";
            if (oUnitDTO.RefStatus == 0) errMessage += System.Environment.NewLine + "- Статус;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return;
            }
            switch (formMode)
            {
                case "ADD":
                    try
                    {
                        dbAccess.addUnit("offline", oUnitDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); }
                    break;
                case "EDIT":
                    try
                    {
                        dbAccess.editUnit("offline", oUnitDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); }
                    break;
            }

            changeData = true;
        }
    }
}
