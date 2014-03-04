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
    }
}
