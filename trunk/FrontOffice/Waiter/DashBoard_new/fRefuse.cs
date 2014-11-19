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
    public partial class fRefuse : Form
    {
        public textBoxNumeric tbNumeric;

        public fRefuse()
        {
            InitializeComponent();
        }

        private void fRefuse_KeyDown(object sender, KeyEventArgs e)

        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DialogResult = DialogResult.OK;
                    break;

                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void fRefuse_Shown(object sender, EventArgs e)
        {
            tbNumeric.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(tbNumeric);
            tbNumeric.Focus();
        }
    }
}
