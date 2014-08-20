using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites.Controls;

namespace com.sbs.gui.dashboard
{
    public partial class fTable : Form
    {
        internal int tableNumber;

        textBoxNumeric numericUpDown_table;

        public fTable()
        {
            InitializeComponent();

            numericUpDown_table = new textBoxNumeric();
            numericUpDown_table.Dock = DockStyle.Fill;
            numericUpDown_table.fontSize = 20;

            groupBox1.Controls.Add(numericUpDown_table);
        }

        private void fTable_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Enter:
                    tableNumber = (int)numericUpDown_table.Value;
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        private void fTable_Shown(object sender, EventArgs e)
        {
            numericUpDown_table.minValue = 0;
            numericUpDown_table.maxValue = tableNumber;
        }

        void btnTable_Click(object sender, EventArgs e)
        {
            tableNumber = (int)numericUpDown_table.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
