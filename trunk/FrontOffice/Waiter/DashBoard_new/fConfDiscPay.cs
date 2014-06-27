using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;

namespace com.sbs.gui.dashboard
{
    public partial class fConfDiscPay : Form
    {
        DTO.DiscountInfo oDiscountInfo;

        public fConfDiscPay(DTO.DiscountInfo pDiscountInfo)
        {
            oDiscountInfo = pDiscountInfo;

            InitializeComponent();
        }

        private void fConfDiscPay_Shown(object sender, EventArgs e)
        {
            decimal xDiscount = Math.Floor(oDiscountInfo.discount);
            if (oDiscountInfo.discount - xDiscount > 0) xDiscount = oDiscountInfo.discount;

            label_fio.Text = oDiscountInfo.fio;
            label_discount.Text = string.Format("{0}%", xDiscount);
            label_dateExp.Text = oDiscountInfo.isExpDate == 1 ? string.Format("до {0}", oDiscountInfo.dateEnd) : "беcсрочная";
            pictureBox_photo.Image = oDiscountInfo.photo;
        }

        private void fConfDiscPay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Enter:
                    DialogResult = DialogResult.OK;
                    break;
            }
        }
    }
}
