using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.dto;

namespace com.sbs.gui.compositionorg
{
    public partial class fAddEdit_unit : Form
    {
        private bool changeData = false;
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        private DBaccess dbAccess = new DBaccess();
        private CompOrgDTO.UnitDTO oUnitDTO;

        public fAddEdit_unit(CompOrgDTO.UnitDTO pUnitDTO, DataTable pDtBranch, DataTable pDtStatus)
        {
            InitializeComponent();

            oUnitDTO = pUnitDTO;

            if (oUnitDTO.Id == 0) formMode = "ADD";
            else formMode = "EDIT";

            comboBox_branch.DataSource = pDtBranch;
            comboBox_branch.ValueMember = "id";
            comboBox_branch.DisplayMember = "name";
            comboBox_branch.SelectedValue = oUnitDTO.Branch;

            comboBox_refStatus.DataSource = pDtStatus;
            comboBox_refStatus.ValueMember = "id";
            comboBox_refStatus.DisplayMember = "name";
            comboBox_refStatus.SelectedValue = oUnitDTO.RefStatus;
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
    }
}
