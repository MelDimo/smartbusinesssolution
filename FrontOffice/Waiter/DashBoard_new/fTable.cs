using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.gui.dashboard
{
    public partial class fTable : Form
    {
        internal int tableNumber;

        public fTable()
        {
            InitializeComponent();
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
            numericUpDown_table.Minimum = 0;
            numericUpDown_table.Maximum = tableNumber;
        }

        void btnTable_Click(object sender, EventArgs e)
        {
            tableNumber = (int)numericUpDown_table.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
