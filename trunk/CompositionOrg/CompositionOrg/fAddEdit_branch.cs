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
    public partial class fAddEdit_branch : Form
    {
        private bool changeData = false;
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
                return;
            }
            switch (formMode)
            {
                case "ADD":
                    try
                    {
                        dbAccess.addBranch("offline", oBranchDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); }
                    break;
                case "EDIT":
                    try
                    {
                        dbAccess.editBranch("offline", oBranchDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); }
                    break;
            }

            changeData = true;
        }
    }
}
