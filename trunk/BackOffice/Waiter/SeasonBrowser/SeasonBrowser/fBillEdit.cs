using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.seasonbrowser
{
    public partial class fBillEdit : Form
    {
        DBaccess dbAccess = new DBaccess();

        DBaccess.Role curRole;

        private DTO_DBoard.Bill oBill;
        private Filter oFilter;

        public fBillEdit(Filter pFilter, DTO_DBoard.Bill pBill,  DBaccess.Role pCurRole)
        {
            oBill = pBill;
            oFilter = pFilter;
            curRole = pCurRole;

            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (curRole == DBaccess.Role.BACKOFFICE && oFilter.isSeasonOpen)
            {
                MessageBox.Show("Вы не можете вносить изменения в открытую смену.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oBill.discount = (int)numericUpDown_discount.Value;
            oBill.refNotes = (int)((comboBox_notes.SelectedValue == null) ? 0 : comboBox_notes.SelectedValue);
            oBill.refStat = (int)((comboBox_status.SelectedValue == null) ? 0 : comboBox_status.SelectedValue);
            oBill.paymentType = (int)((comboBox_typePayment.SelectedValue == null) ? 0 : comboBox_typePayment.SelectedValue);

            try
            {
                dbAccess.saveBill(oFilter, oBill);
            }
            catch (Exception exc) { uMessage.Show("Неудалось сохранить счет.", exc, SystemIcons.Information); return; }

            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fBillEdit_Shown(object sender, EventArgs e)
        {
            fillControls();

            //switch (curRole)
            //{ 
            //    case DBaccess.Role.BACKOFFICE:
            //        comboBox_typePayment.Enabled = false;
            //        comboBox_notes.Enabled = false;
            //        comboBox_status.Enabled = false;
            //        break;

            //    case DBaccess.Role.FRONTOFFICE:
            //        comboBox_typePayment.Enabled = true;
            //        comboBox_notes.Enabled = false;
            //        comboBox_status.Enabled = false;
            //        break;
            //}
        }

        private void fillControls()
        {
            textBox_id.Text = oBill.id.ToString();
            textBox_numb.Text = oBill.numb.ToString();
            textBox_table.Text = oBill.table.ToString();
            numericUpDown_discount.Value = oBill.discount;

            comboBox_typePayment.SelectedValue = oBill.paymentType;
            comboBox_notes.SelectedValue = oBill.refNotes;
            comboBox_status.SelectedValue = oBill.refStat;
        }

        private void button_history_Click(object sender, EventArgs e)
        {
            DataTable dt = dbAccess.getBillsLog(oFilter);

            fHistory fHis = new fHistory();
            fHis.dataGridView_main.DataSource = dt;
            fHis.ShowDialog();
        }
    }
}
