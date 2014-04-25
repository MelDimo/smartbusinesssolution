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
    public partial class ctrSeasonPerson : UserControl
    {
        public int refStatus;

        public ctrSeasonPerson()
        {
            InitializeComponent();

            button_host.GotFocus += new EventHandler(button_host_GotFocus);
            button_host.LostFocus += new EventHandler(button_host_LostFocus);
        }

        void button_host_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void button_host_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(185, 209, 234);
        }
    }
}
