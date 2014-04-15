using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class ctrBill : UserControl
    {
        public DTO_DBoard.Bill oBill;

        public ctrBill(DTO_DBoard.Bill pBill)
        {
            oBill = pBill;

            InitializeComponent();

            fillControls();
        }

        private void fillControls()
        {
            button_editMnu.BackgroundImage = Properties.Resources.edit_26;

            label_numbBill.Text = oBill.numb.ToString();
            label_numbTable.Text = oBill.table.ToString();
            label_dateOpenClose.Text = oBill.openDate + " - " + oBill.closeDate;
            comboBox_note.SelectedValue = oBill.refNotes;
            label_summ.Text = oBill.summFact.ToString("F2");
            label_refStatusName.Text = oBill.refStatName;
            switch (oBill.refStat)
            {
                case 20:
                    label_refStatusName.ForeColor = Color.Red;
                    break;
                case 21:
                    label_refStatusName.ForeColor = Color.Green;
                    break;
            }
        }
    }
}
