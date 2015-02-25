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
    public partial class fAddEdit_unit : Form
    {
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
            textBox_code.DataBindings.Add("Text", oUnitDTO, "Code");
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if(saveData()) DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
           DialogResult = DialogResult.Cancel;
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            oUnitDTO.Name = textBox_name.Text.Trim();
            oUnitDTO.RefStatus = comboBox_refStatus.SelectedValue == null ? 0 : (int)comboBox_refStatus.SelectedValue;
            oUnitDTO.Branch = comboBox_branch.SelectedValue == null ? 0 : (int)comboBox_branch.SelectedValue;
            oUnitDTO.RefPrintersType = comboBox_refPrintersType.SelectedValue == null ? 0 : (int)comboBox_refPrintersType.SelectedValue;
            oUnitDTO.RefPrinters = comboBox_refPrinters.SelectedValue == null ? 0 : (int)comboBox_refPrinters.SelectedValue;
            oUnitDTO.Code = textBox_code.Text.Trim();


            if (oUnitDTO.Name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (oUnitDTO.Branch == 0) errMessage += System.Environment.NewLine + "- Заведение;";
            if (oUnitDTO.RefStatus == 0) errMessage += System.Environment.NewLine + "- Статус;";
            if (oUnitDTO.Code.Length == 0) errMessage += System.Environment.NewLine + "- Внешний ключ;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }
            switch (formMode)
            {
                case "ADD":
                    try
                    {
                        dbAccess.addUnit(GValues.DBMode, oUnitDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); return false; }
                    break;
                case "EDIT":
                    try
                    {
                        dbAccess.editUnit(GValues.DBMode, oUnitDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); return false; }
                    break;
            }

            return true;
        }
    }
}
