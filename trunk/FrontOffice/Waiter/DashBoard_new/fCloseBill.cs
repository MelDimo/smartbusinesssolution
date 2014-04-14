using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fCloseBill : Form
    {
        decimal sumBill = 0;

        private DTO_DBoard.Bill oBill;
        private List<DTO_DBoard.Dish> lDishs;

        public int paymentType;

        public fCloseBill()
        {
            InitializeComponent();
        }

        public fCloseBill(DTO_DBoard.Bill pBill, List<DTO_DBoard.Dish> plDishs)
        {
            oBill = pBill;
            lDishs = plDishs;

            InitializeComponent();
        }

        private void fCloseBill_Shown(object sender, EventArgs e)
        {
            ctrBill oCtrBill;

            ctrDishesSmall oCtrDishesSmall;

            oCtrBill = new ctrBill(oBill);
            //oCtrBill.id = oBill.id;
            //oCtrBill.label_numbBill.Text = oBill.numb.ToString();
            //oCtrBill.label_numbTable.Text = oBill.table.ToString();
            //oCtrBill.label_refStatusName.Text = oBill.refStatName;
            //oCtrBill.label_summ.Visible = false;
            //switch (oBill.refStat)
            //{
            //    case 20:
            //        oCtrBill.label_refStatusName.ForeColor = Color.Red;
            //        break;
            //    case 21:
            //        oCtrBill.label_refStatusName.ForeColor = Color.Green;
            //        break;
            //}
            //oCtrBill.label_dateOpenClose.Text = oBill.openDate.ToString();
            //oCtrBill.Tag = oBill;
            oCtrBill.TabStop = false;
            oCtrBill.label_summ.Visible = true;

            oCtrBill.Width = flowLayoutPanel_bills.Width - 10;
            
            flowLayoutPanel_bills.Controls.Add(oCtrBill);

            foreach (DTO_DBoard.Dish oDish in lDishs)
            {
                oCtrDishesSmall = new ctrDishesSmall(oDish);

                oCtrDishesSmall.Width = flowLayoutPanel_bills.Width - 25;
                oCtrDishesSmall.TabStop = false;
                flowLayoutPanel_bills.Controls.Add(oCtrDishesSmall);

                sumBill += oDish.price * oDish.count;
            }

            oCtrBill.label_summ.Text = sumBill.ToString("F2");
            label_billSum.Text = sumBill.ToString("F2");
            numericUpDown_curSumm.Value = sumBill;

            createCloseType();
        }

        private void createCloseType()
        {
            ToolStripItem tsmi;

            foreach (DataRow dr in DashboardEnvironment.dtPayment.Rows)
            {
                tsmi = new ToolStripMenuItem(dr["name"].ToString());
                tsmi.Tag = dr["id"];
                tsmi.Font = new Font("Microsoft Sans Serif", 10);
                tsmi.Click +=new EventHandler(closeType_click);
                tsmi.ForeColor = Color.FromName(dr["color"].ToString());
                cMStrip_closeType.Items.Add(tsmi);
            }
        }

        void closeType_click(object sender, EventArgs e)
        {
            paymentType = (int)((ToolStripMenuItem)sender).Tag;
            DialogResult = DialogResult.OK;
        }

        private void fCloseBill_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void numericUpDown_curSumm_Enter(object sender, EventArgs e)
        {
            numericUpDown_curSumm.Select(0, numericUpDown_curSumm.Text.Length);
        }

        private void numericUpDown_curSumm_KeyUp(object sender, KeyEventArgs e)
        {
            label_diff.Text = (sumBill - numericUpDown_curSumm.Value).ToString("F2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cMStrip_closeType.Show(button1, new Point(0, button1.Height));
        }
    }
}
