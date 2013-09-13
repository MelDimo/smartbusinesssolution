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
    public partial class fAddEdit_org : Form
    {
        private bool changeData = false;
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        private DBaccess dbAccess = new DBaccess();
        private CompOrgDTO.OrganizationDTO oOrgDTO;

        public fAddEdit_org(CompOrgDTO.OrganizationDTO pOrgDTO, DataTable pDtStatus)
        {
            InitializeComponent();

            oOrgDTO = pOrgDTO;

            if (oOrgDTO.Id == 0) formMode = "ADD";
            else formMode = "EDIT";

            textBox_id.Text = oOrgDTO.Id.ToString();
            textBox_name.Text = oOrgDTO.Name;
            
            comboBox_refStatus.DataSource = pDtStatus;
            comboBox_refStatus.DisplayMember = "name";
            comboBox_refStatus.ValueMember = "id";

            comboBox_refStatus.SelectedValue = oOrgDTO.RefStatus;
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
            oOrgDTO.Name = textBox_name.Text.Trim();
            oOrgDTO.RefStatus = comboBox_refStatus.SelectedValue == null ? 0 : (int)comboBox_refStatus.SelectedValue;

            if (oOrgDTO.Name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (oOrgDTO.RefStatus == 0) errMessage += System.Environment.NewLine + "- Статус;";

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
                        dbAccess.addOrganization("offline", oOrgDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); }
                    break;
                case "EDIT":
                    try
                    {
                        dbAccess.editOrganization("offline", oOrgDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); }
                    break;
            }

            changeData = true;
        }
    }
}
