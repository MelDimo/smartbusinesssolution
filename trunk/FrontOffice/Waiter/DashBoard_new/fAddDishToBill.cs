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
        private getReference oReferences = new getReference();
        private DBaccess dbAccess = new DBaccess();
        private ctrDishes oCtrDishes;
        private DTO_DBoard.Bill oBill;

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
                    switch(oCtrDishes.oDish.refStatus)
                    {
                        case 0:             // Бонально новое блюдо добавляется в счет
                            if (addDish2Bill()) DialogResult = DialogResult.OK;
                            break;

                        case 34:            // Висяк добавляемм в счет
                            if (addRefuse2Bill()) DialogResult = DialogResult.OK;
                            break;
                    }
                    break;
            }
        }

        private bool addRefuse2Bill()
        {
            DTO_DBoard.Dish oDish = oCtrDishes.oDish;
            oDish.count = oCtrDishes.numericUpDown_count.Value;
            oDish.refNotes = (int)oCtrDishes.comboBox_note.SelectedValue;

            try
            {
                dbAccess.addRefuse2Bill(GValues.DBMode, oBill, oDish);
            }
            catch (Exception exc) { uMessage.Show("Неудалось добавить \"висяк\" к счету.", exc, SystemIcons.Information); return false; }

            return true;
        }

        private bool addDish2Bill()
        {
            int dishId = 0;

            DTO_DBoard.Dish oDish = oCtrDishes.oDish;
            oDish.count = oCtrDishes.numericUpDown_count.Value;
            oDish.refNotes = (int)oCtrDishes.comboBox_note.SelectedValue;

            try
            {
                dishId = dbAccess.addDish2Bill(GValues.DBMode, oBill, oDish, oCtrDishes.dtToppings.Rows.Count);
                dbAccess.addDish2Bill_toppings(GValues.DBMode, dishId, oBill, oDish, oCtrDishes.dtToppings);
            }
            catch (Exception exc) 
            {
                if (dishId != 0) // Сторнируем добавление блюда
                {
                    try
                    {
                        dbAccess.addDish2Bill_remove(GValues.DBMode, dishId);
                    }
                    catch (Exception exc1) { uMessage.Show("Неудалось добавить блюдо к счету.", exc1, SystemIcons.Information); return false; }
                }

                uMessage.Show("Неудалось добавить блюдо к счету.", exc, SystemIcons.Information); return false; 
            }

            return true;
        }

        private void fAddDishToBill_Shown(object sender, EventArgs e)
        {
            foreach (Control ctr in this.Controls)
            {
                ((ctrDishes)ctr).button_host.TabStop = false;
                
                ((ctrDishes)ctr).button_deals.TabStop = true;
                ((ctrDishes)ctr).button_deals.Enabled = false;
                
                ((ctrDishes)ctr).comboBox_note.TabStop = true;

                ((ctrDishes)ctr).numericUpDown_count.Focus();
            }
        }
    }
}
