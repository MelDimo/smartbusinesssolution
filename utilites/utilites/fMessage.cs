﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class fMessage : Form
    {
        public fMessage(string pMsgText, Icon pMsgIcon)
        {
            InitializeComponent();

            this.Text = GValues.prgNameFull;
            textBox_message.Text = pMsgText;
            this.Icon = pMsgIcon;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
