using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites.Controls;
using com.sbs.dll;

namespace com.sbs.gui.dashboard
{
    public partial class fTable : Form
    {
        internal int tableNumber;
        internal int peopleCount;

        textBoxNumeric numericUpDown_table;
        textBoxNumeric numericUpDown_people;

        public fTable()
        {
            InitializeComponent();

            numericUpDown_table = new textBoxNumeric();
            numericUpDown_table.Dock = DockStyle.Fill;
            numericUpDown_table.fontSize = 20;

            numericUpDown_people = new textBoxNumeric();
            numericUpDown_people.Dock = DockStyle.Fill;
            numericUpDown_people.fontSize = 20;

            groupBox1.Controls.Add(numericUpDown_table);
            groupBox2.Controls.Add(numericUpDown_people);
        }

        private void fTable_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Enter:
                    if(checkValues()) DialogResult = DialogResult.OK;
                    break;
            }
        }

        private bool checkValues()
        {
            tableNumber = (int)numericUpDown_table.Value;
            peopleCount = (int)numericUpDown_people.Value;

            if ((tableNumber * peopleCount) == 0)
            {
                MessageBox.Show("Необходимо указать номер столика и кол-во гостей за столиком", GValues.prgNameFull, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void fTable_Shown(object sender, EventArgs e)
        {
            numericUpDown_table.minValue = 0;
            numericUpDown_table.maxValue = tableNumber;
            numericUpDown_table.Focus();
        }

        void btnTable_Click(object sender, EventArgs e)
        {
            tableNumber = (int)numericUpDown_table.Value;
            DialogResult = DialogResult.OK;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                    this.SelectNextControl(ActiveControl, true, true, true, true);
                    break;

                case Keys.Left:
                    this.SelectNextControl(ActiveControl, true, true, true, true);
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
