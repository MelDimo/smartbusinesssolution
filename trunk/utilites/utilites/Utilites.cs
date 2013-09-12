using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace com.sbs.dll.utilites
{
    public static class uMessage
    {
        public static void Show(string pMsgText, Exception pExc, Icon pMsgIcon)
        {
            fMessage_Exception message = new fMessage_Exception(pMsgText, pExc, pMsgIcon);
            message.ShowDialog();
        }

        public static void Show(string pMsgText, Icon pMsgIcon)
        {
            fMessage message = new fMessage(pMsgText, pMsgIcon);
            message.ShowDialog();
        }
    }
}
