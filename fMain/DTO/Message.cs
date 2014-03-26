using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll
{
    public partial class DTO
    {
        [Serializable]
        public class Message
        {
            public string id { get; set; }
            public string Header { get; set; }
            public string Body { get; set; }
        }

        public class MailBox
        {
            public int countMails { get; set; }
            public string uName { get; set; }
            public string uPwd { get; set; }
            public List<Mail> mails { get; set; }
        }

        public class Mail
        {
            public int messageNumber { get; set; }
            public string date { get; set; }
            public string from { get; set; }
            public string subject { get; set; }
            public string body { get; set; }
            public string isSeen { get; set; }
        }
    }
}
