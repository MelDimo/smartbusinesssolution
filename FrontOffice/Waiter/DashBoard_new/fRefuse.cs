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
    public partial class fRefuse : Form
    {
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

        private void trackBar_count_Scroll(object sender, EventArgs e)
        {
            label_info.Text = trackBar_count.Value.ToString();
        }

        private void fRefuse_Shown(object sender, EventArgs e)
        {
            label_info.Text = trackBar_count.Maximum.ToString();
        }
    }
}
