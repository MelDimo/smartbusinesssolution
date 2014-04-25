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
    public partial class ctrDishes : UserControl
    {
        public DTO_DBoard.Dish oDish;

        public ctrDishes(DTO_DBoard.Dish pDish)
        {
            oDish = pDish;
           
            InitializeComponent();

            fillControls();

            button_host.GotFocus += new EventHandler(button_host_GotFocus);
            button_host.LostFocus += new EventHandler(button_host_LostFocus);
        }

        void button_host_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void button_host_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(185, 209, 234);
        }

        private void fillControls()
        {
            button_editMnu.BackgroundImage = Properties.Resources.edit_26;

            label_name.Text = oDish.name;
            label_price.Text = oDish.price.ToString("F2");
            numericUpDown_count.Minimum = oDish.minStep;
            numericUpDown_count.Increment = oDish.minStep;
            numericUpDown_count.Value = oDish.count;
            comboBox_note.SelectedValue = oDish.refNotes;
        }


        public object Clone()
        {

            ctrDishes oCtr = new ctrDishes(oDish);
            return oCtr;
        }

        private void numericUpDown_count_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpDown_count.Select(0, numericUpDown_count.Text.Length);
        }
    }
}
