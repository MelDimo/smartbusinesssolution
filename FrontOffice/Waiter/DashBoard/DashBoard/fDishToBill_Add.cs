using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.gui.DashBoard
{
    public partial class fDishToBill_Add : Form
    {
        oDishes Dishes;

        public fDishToBill_Add(ref oDishes pDishes)
        {
            Dishes = pDishes;

            InitializeComponent();

            textBox_price.Text = Dishes.Price.ToString();
            label_dishName.Text = Dishes.Name;
        }

        private void fDishToBill_Add_KeyDown(object sender, KeyEventArgs e)
        {
            float xCount = 0;

            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    if (float.TryParse(textBox_count.Text, out xCount))
                    {
                        Dishes.Count = xCount;
                        DialogResult = DialogResult.OK;
                    }
                    break;

                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}
