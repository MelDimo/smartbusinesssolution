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
using System.Threading;

namespace com.sbs.gui.dashboard
{
    public partial class fCloseBill : Form
    {
        DBaccess dbAccess = new DBaccess();

        decimal sumBill = 0;

        private DTO_DBoard.Bill oBill;
        private List<DTO_DBoard.Dish> lDishs;

        public int paymentType;
        public DTO.DiscountInfo oDiscountInfo;

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

            if (paymentType == 5) // ref_payment_type.id - По дисконтной карте
            {
                try
                {
                    oDiscountInfo = new DTO.DiscountInfo();
                    closeWithDiscount();
                }
                catch (Exception exc)
                {
                    uMessage.Show("Неудалось обаботать дисконтную карту.", exc, SystemIcons.Information);
                    return;
                }

                if(oDiscountInfo.id != 0) confirmDiscountPayment();
                else MessageBox.Show("Данная карта не найдена либо не активна.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                DialogResult = DialogResult.OK;
        }

        private void confirmDiscountPayment()
        {
            fConfDiscPay fcdp = new fConfDiscPay(oDiscountInfo);
            if (fcdp.ShowDialog() != DialogResult.OK) return;

            if(oDiscountInfo.refStatus == 1) DialogResult = DialogResult.OK;
        }

        private void closeWithDiscount()
        {
            fMIFare fMiFare = new fMIFare();
            if (fMiFare.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    getUserByKey(fMiFare.keyId);
                }
                catch (Exception exc)
                {
                    uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                    return;
                }
            }
        }

        private void getUserByKey(string pUserKey)
        {
            oDiscountInfo = dbAccess.getMifareDiscountInfo(GValues.DBMode, pUserKey);
        }

        private void fCloseBill_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Enter:
                    SendKeys.Send("{TAB}");
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
