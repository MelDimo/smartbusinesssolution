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

            oCtrDishes.Dock = DockStyle.Fill;
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
            DTO_DBoard.Dish oDish = oCtrDishes.oDish;
            oDish.count = oCtrDishes.numericUpDown_count.Value;
            oDish.refNotes = (int)oCtrDishes.comboBox_note.SelectedValue;

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
                ((ctrDishes)ctr).button_deals.Enabled = false;
                
                ((ctrDishes)ctr).button_topping.TabStop = true;
                ((ctrDishes)ctr).button_topping.Enabled = false;

                ((ctrDishes)ctr).comboBox_note.TabStop = true;

                ((ctrDishes)ctr).numericUpDown_count.Focus();
            }
        }
    }
}
