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
using ActiveUp.Net.Mail;

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

                Thread.Sleep(GValues.mailChkSec);
            }
            
        }

        private void getUnseenMessage()
        {
            msg = new DTO.Message();
            int cntUnseenMessage = 0;

            Imap4Client imap = new Imap4Client();
            imap.ConnectSsl("imap.gmail.com", 993);
            imap.Login(GValues.mailUsername, GValues.mailPassword);

            Mailbox inbox = imap.SelectMailbox("inbox");
            int[] ids = inbox.Search("UNSEEN");
            cntUnseenMessage = ids.Length;

            imap.Disconnect();

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
            DTO.Mail oMail;
            ActiveUp.Net.Mail.Message msg = null;

            Imap4Client imap = new Imap4Client();
            imap.ConnectSsl("imap.gmail.com", 993);
            imap.LoginFast(GValues.mailUsername, GValues.mailPassword);

            Mailbox inbox = imap.SelectMailbox("inbox");
            int[] ids = inbox.Search("ALL");
            Array.Reverse(ids);

            for (int i = pCurCount; i < pCurCount + pStepMail; i++)
            {
                msg = inbox.Fetch.MessageObject(ids[i - 1]);
                oMail = new DTO.Mail();
                oMail.messageNumber = ids[i - 1];
                oMail.isSeen = msg.Flag;
                oMail.date = msg.Date.ToShortDateString() + " " + msg.Date.ToShortTimeString();
                oMail.from = msg.From.Email;
                oMail.subject = msg.Subject;
                oMail.body = msg.BodyHtml.Text;

                lMail.Add(oMail);
            }

            imap.Disconnect();

            return lMail;
        }

        internal void deleteMail(int mailNumber)
        {
            Imap4Client imap = new Imap4Client();
            imap.ConnectSsl("imap.gmail.com", 993);
            imap.LoginFast(GValues.mailUsername, GValues.mailPassword);

            //imap.LoadMailboxes();

            imap.SelectMailbox("inbox");

            imap.Command("move " + mailNumber + " andys/trash");

            imap.Disconnect();
        }

        /*
        internal List<DTO.Mail> getMail_pop3(int pCurCount, int pStepMail)
        {
            List<DTO.Mail> lMail = new List<DTO.Mail>();
            Dictionary<string, string> dicMail = new Dictionary<string, string>();

            string Email;
            List<int> EmailUids;
            int cntMessage = 0;

            try
            {
                Pop3MailClient mailClient = new Pop3MailClient("pop.gmail.com", 995, true, username, password);
                mailClient.IsAutoReconnect = true;
                mailClient.ReadTimeout = 60000;     //give pop server 60 seconds to answer
                mailClient.Connect();

                mailClient.GetEmailIdList(out EmailUids);
                EmailUids.Reverse();
                cntMessage = EmailUids.Count;
                
                for (int i = pCurCount; i < pCurCount + pStepMail; i++ )
                {
                    mailClient.GetRawEmail(EmailUids[i], out Email);
                    lMail.Add(parseRawMail(Email));
                }

                mailClient.Disconnect();
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка при работе с почтовым сервером.", exc, SystemIcons.Information);
            }

            return lMail;
        }

        private DTO.Mail parseRawMail(string pRawEmail)
        {
            DTO.Mail oMail = new DTO.Mail();
            string[] strBase64;

            foreach (string line in pRawEmail.Split(Environment.NewLine.ToCharArray()))
            {
                string[] pair = line.Split(new string[] { ": " }, StringSplitOptions.None);
                switch (pair.Length)
                { 
                    case 2:
                        switch (pair[0])
                        {
                            case "Date":
                                oMail.date = pair[1];
                                break;
                            case "From":
                                oMail.from = pair[1];
                                strBase64 = pair[1].Split('?');
                                if(strBase64.Length > 2) if (strBase64[1].Equals("KOI8-R")) oMail.from = Encoding.UTF8.GetString(Convert.FromBase64String(strBase64[3]));
                                break;
                            case "Subject":
                                oMail.subject = pair[1];
                                strBase64 = pair[1].Split('?');
                                if (strBase64.Length > 2)
                                    switch (strBase64[1])
                                    {
                                        case "KOI8-R":
                                            oMail.subject = Encoding.UTF8.GetString(Convert.FromBase64String(strBase64[3]));
                                            break;
                                        case "ISO-8859":
                                            oMail.subject = Encoding.UTF8.GetString(Convert.FromBase64String(strBase64[3]));
                                            break;
                                    }
                                    
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }

            return oMail;

        }
        */


    }   
}
