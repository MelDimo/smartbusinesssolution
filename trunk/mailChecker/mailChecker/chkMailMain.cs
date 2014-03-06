using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net.Security;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Messaging;
using System.Text.RegularExpressions;
using com.sbs.dll.utilites;
using System.Drawing;

namespace com.sbs.dll.mailChecker
{
    public class ChkMailMain
    {
        Thread chkMailThread;
        
        public void run()
        {
            chkMailThread = new Thread(new Checker().run);
            chkMailThread.IsBackground = true;
            chkMailThread.Start();

            return;
        }

        public void stop()
        {
            if (chkMailThread != null)
                if (chkMailThread.IsAlive) chkMailThread.Abort();
        }

    }

    public class Checker
    {
        DTO.Message msg = new DTO.Message();
        DTO.Mail mail = new DTO.Mail();

        string username = "meldimo@gmail.com", password = "dimon_google";

        public void run()
        {
            while (true)
            {
                try
                {
                    getUnseenMessage();
                }
                catch (Exception exc)
                {
                    Debug.Print(exc.Message);
                }

                Thread.Sleep(5000);
            }
            
        }

        private void getUnseenMessage()
        {
            msg = new DTO.Message();
            int cntUnseenMessage = 0;

            
            msg.id = "MESSAGE_UNSEEN";
            msg.Header = "Непрочитанных сообщений:";
            msg.Body = cntUnseenMessage.ToString();
            sendMessage(msg);
        }

        private void sendMessage(DTO.Message pMsg)
        {
            MessageQueue myQueue = new MessageQueue(".\\Private$\\SBSInnerMessage");
            myQueue.Send(pMsg);
        }

        internal List<DTO.Mail> getMail(int pCurCount, int pStepMail)
        {
            List<DTO.Mail> lMail = new List<DTO.Mail>();
            DTO.Mail oMail = new DTO.Mail();


            return lMail;
        }

    }   
}
