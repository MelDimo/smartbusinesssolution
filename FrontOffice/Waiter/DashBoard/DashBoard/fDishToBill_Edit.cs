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

namespace com.sbs.gui.DashBoard
{
    public partial class fDishToBill_Edit : Form
    {
        private DBaccess DbAccess = new DBaccess();
        oBillInfo xBillInfo;

        public fDishToBill_Edit(ref oBillInfo pBillInfo)
        {
            xBillInfo = pBillInfo;

            InitializeComponent();
        }

        private void fDishToBill_Add_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (!isConfirm()) return;
                    DialogResult = DialogResult.OK;
                    break;

                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private bool isConfirm()
        {
            double xNewCount;

            if ((double)numericUpDown_count.Value == xBillInfo.XCount) return false;

            if (numericUpDown_count.Value > 10)
                if (MessageBox.Show("Подтвердите вввод " + numericUpDown_count.Value + " ед.",GValues.prgNameFull,MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                    != DialogResult.Yes) return false;

            xNewCount = (double)(numericUpDown_count.Value);
            try
            {
                //DbAccess.editDishToBill("offline", xBillInfo, xNewCount);
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); return false; }
            xBillInfo.XCount = xNewCount;
            return true;
        }

        private void fDishToBill_Edit_Shown(object sender, EventArgs e)
        {
            numericUpDown_count.Value = decimal.Parse(xBillInfo.XCount.ToString());
            
            label_dishName.Text = xBillInfo.DishesName;

            numericUpDown_count.Select(0, numericUpDown_count.Text.Length);
        }

    }
}
