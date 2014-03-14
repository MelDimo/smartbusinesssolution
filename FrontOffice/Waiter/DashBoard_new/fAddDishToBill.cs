using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fAddDishToBill : Form
    {
        private DBaccess dbAccess = new DBaccess();
        ctrDishes oCtrDishes;
        com.sbs.dll.DTO_DBoard.Bill oBill;

        public fAddDishToBill(com.sbs.dll.DTO_DBoard.Bill pBill, ctrDishes pCtrDishes)
        {
            oBill = pBill;
            oCtrDishes = pCtrDishes;

            InitializeComponent();

            Controls.Add(oCtrDishes);
        }

        private void fAddDishToBill_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Enter:
                    if (addDish2Bill()) DialogResult = DialogResult.OK;
                    break;
            }
        }

        private bool addDish2Bill()
        {
            com.sbs.dll.DTO_DBoard.Dish oDish = new com.sbs.dll.DTO_DBoard.Dish();
            oDish.id = oCtrDishes.id;
            oDish.name = oCtrDishes.label_name.Text;
            oDish.price = decimal.Parse(oCtrDishes.label_price.Text);
            oDish.count = oCtrDishes.numericUpDown_count.Value;

            try
            {
                dbAccess.addDish2Bill("offline", oBill, oDish);
            }
            catch (Exception exc) { uMessage.Show("Неудалось сформировать меню.", exc, SystemIcons.Information); return false; }

            return true;
        }

        private void fAddDishToBill_Shown(object sender, EventArgs e)
        {
            foreach (Control ctr in this.Controls)
            {
                ((ctrDishes)ctr).button_host.TabStop = false;
                ((ctrDishes)ctr).button_deals.TabStop = true;
                ((ctrDishes)ctr).button_topping.TabStop = true;
                ((ctrDishes)ctr).numericUpDown_count.Focus();
            }
        }
    }
}
