using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class fMessage_Exception : Form
    {
        public fMessage_Exception(string pMsgText, Exception pExc, Icon pMsgIcon)
        {
            InitializeComponent();

            this.Icon = pMsgIcon;
            this.Text = GValues.prgNameFull;
            textBox_message.Text = pMsgText + Environment.NewLine;
            textBox_exception.Text = "Message: " + pExc.Message + Environment.NewLine + "StackTrace: " + pExc.StackTrace;
            textBox_message.Visible = true;

            WriteLog.write(pMsgText + Environment.NewLine + "Message: " + pExc.Message + Environment.NewLine + "StackTrace: " + pExc.StackTrace);
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
