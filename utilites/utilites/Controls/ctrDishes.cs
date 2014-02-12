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
        public int id;

        public ctrDishes()
        {
            InitializeComponent();
        }

        public object Clone()
        {
            ctrDishes oCtr = new ctrDishes();
            oCtr.id = this.id;
            oCtr.label_name.Text = this.label_name.Text;
            oCtr.label_portion.Text = this.label_portion.Text;
            oCtr.label_price.Text = this.label_price.Text;
            return oCtr;
        }

        private void numericUpDown_count_KeyUp(object sender, KeyEventArgs e)
        {
            numericUpDown_count.Select(0, numericUpDown_count.Text.Length);
        }
    }
}
