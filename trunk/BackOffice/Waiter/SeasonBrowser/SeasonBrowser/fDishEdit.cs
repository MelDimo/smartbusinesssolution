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

namespace com.sbs.gui.seasonbrowser
{
    public partial class fDishEdit : Form
    {
        DBaccess dbAccess = new DBaccess();
        
        DTO_DBoard.Dish oDish;
        Filter oFilter;

        public fDishEdit(Filter pFilter, DTO_DBoard.Dish pDish)
        {
            oDish = pDish;
            oFilter = pFilter;

            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            oDish.count = numericUpDown_count.Value;
            oDish.refStatus = (int)comboBox_status.SelectedValue;

            try
            {
                dbAccess.saveDish(oFilter, oDish);
            }
            catch (Exception exc) { uMessage.Show("Неудалось сохранить блюдо.", exc, SystemIcons.Information); return; }

            DialogResult = DialogResult.OK;
        }

        private void fDishEdit_Shown(object sender, EventArgs e)
        {
            fillControls();
        }

        private void fillControls()
        {
            textBox_id.Text = oDish.id.ToString();
            textBox_name.Text = oDish.name;
            textBox_price.Text = oDish.price.ToString();
            numericUpDown_count.Value = oDish.count;

            comboBox_status.SelectedValue = oDish.refStatus;

        }
    }
}
