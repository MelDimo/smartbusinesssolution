using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using System.IO.Ports;

namespace com.sbs.gui.dashboard
{
    public partial class fFiscalDevice : Form
    {
        MiniFP6 miniFP6 = new MiniFP6();

        public fFiscalDevice()
        {
            InitializeComponent();
        }

        private void button_Xorder_Click(object sender, EventArgs e)
        {
            if(miniFP6 == null) return;

            if (!miniFP6.DayReport_(2))
            {
                SerialPort sp = new SerialPort("COM2");
                sp.Close();
                miniFP6.DayReport_(2);
                MessageBox.Show(miniFP6.GetLastErr_());
            }
        }

        private void button_Zorder_Click(object sender, EventArgs e)
        {
            if (miniFP6 == null) return;

            if (!miniFP6.DayClrReport_(2)) MessageBox.Show(miniFP6.GetLastErr_());
        }

        private void fFiscalDevice_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
