using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites.Controls
{
    public partial class textBoxNumeric : UserControl
    {
        public decimal minValue = 0;
        public decimal maxValue = 100;
        public decimal stepValue = 1;
        public decimal Value = 0;

        private decimal nextVal = 0;

        public textBoxNumeric()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (textBox_numb.Focused)
            {
                switch (keyData)
                {
                    case Keys.Up:
                        nextVal = Value + stepValue;
                        Value = nextVal < maxValue ? nextVal : maxValue;
                        break;

                    case Keys.Down:
                        nextVal = Value - stepValue;
                        Value = nextVal > minValue ? nextVal : minValue;
                        break;
                }

                textBox_numb.Text = Value.ToString("F2");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textBox_numb_KeyDown(object sender, KeyEventArgs e)
        {
            textBox_numb.Select(0, textBox_numb.Text.Length);
        }

        private void textBoxNumeric_Load(object sender, EventArgs e)
        {
            textBox_numb.Text = Value.ToString("F2");
        }


    }
}
