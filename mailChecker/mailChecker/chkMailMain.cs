using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net.Security;
using ActiveUp.Net.Mail;

namespace com.sbs.dll.mailChecker
{
    public class ChkMailMain
    {
        public void run()
        {
            //Thread chkThread = new Thread(new Checker().run);
            //chkThread.Name = "thrChkMail";
            //chkThread.Start();

            Checker chk = new Checker();
            chk.run();
        }
    }

    public class Checker
    { 
        public void run()
        {
            MailRepository rep = new MailRepository("imap.gmail.com", 993, true, @"meldimo@gmail.com", "dimon_google");
            checkMail(rep);
            
        }

        private void checkMail(MailRepository pRep)
        {
            foreach (Message email in pRep.GetAllMails("INBOX"))
            {
                continue;
            }
        }
    }

    public class MailRepository
    {
        private Imap4Client _client = null;

        public MailRepository(string mailServer, int port, bool ssl, string login, string password)
        {
            if (ssl)
                Client.ConnectSsl(mailServer, port);
            else
                Client.Connect(mailServer, port);

            Client.Login(login, password);
        }

        public IEnumerable<Message> GetAllMails(string mailBox)
        {
            return GetMails(mailBox, "ALL").Cast<Message>();
        }

        public IEnumerable<Message> GetUnreadMails(string mailBox)
        {
            return GetMails(mailBox, "UNSEEN").Cast<Message>();
        }

        protected Imap4Client Client
        {
            get
            {
                if (_client == null)
                    _client = new Imap4Client();
                return _client;
            }
        }

        private MessageCollection GetMails(string mailBox, string searchPhrase)
        {
            Mailbox mails = Client.SelectMailbox(mailBox);
            MessageCollection messages = mails.SearchParse(searchPhrase);
            return messages;
        }
    }
}
