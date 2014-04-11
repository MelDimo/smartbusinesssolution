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

        private DTO_DBoard.Bill oBill;
        private Filter oFilter;

        public fBillEdit(Filter pFilter, DTO_DBoard.Bill pBill)
        {
            oBill = pBill;
            oFilter = pFilter;

            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
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
    }
}
