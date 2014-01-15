using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;

namespace com.sbs.gui.references.refdishes
{
    public partial class fAddEdit : Form
    {
        DTO.Dishes oDishes;

        public fAddEdit(DTO.Dishes pDishes)
        {
            oDishes = pDishes;

            InitializeComponent();

            initControls();
        }

        private void initControls()
        {
            numericUpDown_code.DataBindings.Add("Value", oDishes, "code");
            textBox_name.DataBindings.Add("Text", oDishes, "name");
            numericUpDown_price.DataBindings.Add("Value", oDishes, "price");
            textBox_id.DataBindings.Add("Text", oDishes, "id");
        }
    }
}
