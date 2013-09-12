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
        bool changeData = false;

        public fAddEdit_org(CompOrgDTO.OrganizationDTO pOrgDTO, DataTable pDtStatus)
        {
            InitializeComponent();

            textBox_id.Text = pOrgDTO.Id.ToString();
            textBox_name.Text = pOrgDTO.Name;
            
            comboBox_refStatus.DataSource = pDtStatus;
            comboBox_refStatus.DisplayMember = "name";
            comboBox_refStatus.ValueMember = "id";

            comboBox_refStatus.SelectedValue = pOrgDTO.RefStatus;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {

        }

        private void button_apply_Click(object sender, EventArgs e)
        {

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {

        }

        private void saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            string xName = textBox_name.Text.Trim();
            int xIdStatus = comboBox_refStatus.SelectedValue == null ? 0 : (int)comboBox_refStatus.SelectedValue;

            if (xName.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (xIdStatus == 0) errMessage += System.Environment.NewLine + "- Статус;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return;
            }



            changeData = true;
        }
    }
}
