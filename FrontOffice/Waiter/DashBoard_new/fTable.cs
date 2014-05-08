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
            }
        }

        private void fTable_Shown(object sender, EventArgs e)
        {
            Button btnTable;
            for (int i = 0; i <= tableNumber; i++)
            {
                btnTable = new Button();
                btnTable.Text = i.ToString();
                btnTable.TextAlign = ContentAlignment.MiddleCenter;
                btnTable.Click += new EventHandler(btnTable_Click);
                btnTable.GotFocus += new EventHandler(btnTable_GotFocus);
                btnTable.LostFocus += new EventHandler(btnTable_LostFocus);
                btnTable.Width = flowLayoutPanel_table.Width - 25;
                flowLayoutPanel_table.Controls.Add(btnTable);
            }
            if (flowLayoutPanel_table.Controls.Count > 0)
                flowLayoutPanel_table.Controls[0].Focus();
        }

        void btnTable_LostFocus(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void btnTable_GotFocus(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(185, 209, 234);
        }

        void btnTable_Click(object sender, EventArgs e)
        {
            tableNumber = int.Parse(((Button)sender).Text);
            DialogResult = DialogResult.OK;
        }
    }
}
