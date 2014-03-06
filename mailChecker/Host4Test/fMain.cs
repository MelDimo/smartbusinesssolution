using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.mailChecker;
using System.Threading;
using System.Diagnostics;
using System.Messaging;
using com.sbs.dll;

namespace Host4Test
{
    public partial class fMain : Form
    {
        ChkMailMain chkMail = new ChkMailMain();
        DTO.Message oMessage = new DTO.Message();

        public fMain()
        {
            InitializeComponent();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if (!MessageQueue.Exists(@".\Private$\SBSInnerMessage")) MessageQueue.Create(@".\Private$\SBSInnerMessage");

            MessageQueue messageQueue = new MessageQueue(@".\Private$\SBSInnerMessage");
            messageQueue.Purge();

            while (true)
            {
                System.Messaging.Message[] messages = messageQueue.GetAllMessages();
                foreach (System.Messaging.Message message in messages)
                {
                    message.Formatter = new XmlMessageFormatter(new Type[] { typeof(DTO.Message) });
                    oMessage = (DTO.Message)message.Body;
                    switch (oMessage.id)
                    {
                        case "MAIL":
                            message_Mail(oMessage);
                            break;
                    }
                }
                // after all processing, delete all the messages
                messageQueue.Purge();

                Thread.Sleep(2000);
            }
        }

        private void message_Mail(DTO.Message oMessage)
        {
            label_info.Text = oMessage.id + " | " + oMessage.Header + " | " + oMessage.Body;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button_openMainForm_Click(object sender, EventArgs e)
        {
            com.sbs.dll.mailChecker.fMain main = new com.sbs.dll.mailChecker.fMain();
            main.ShowDialog();

        }
    }
}
