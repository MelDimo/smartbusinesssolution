using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll.docsaction
{
    public class Oper
    {
        public int id { set; get; }
        public int ref_accountDeb { set; get; }
        public int ref_accountKred { set; get; }
        public int ref_currency_course { set; get; }
        public decimal summa { set; get; }
        public decimal equivalent { set; get; }
        public int packages { set; get; }
        public int ref_status { set; get; }
    }

    public class Packages
    {
        public int id { set; get; }
        public int docs_type { set; get; }
        public int user_create { set; get; }
        public DateTime date_create { set; get; }
        public int ref_status { set; get; }
    }

    public class Docs
    {
        public int id { set; get; }
        public int docs_type { set; get; }
        public int docs_param { set; get; }
        public string value { set; get; }
        public int packages { set; get; }
        public int ref_status { set; get; }
    }

    public class DocActions
    {
        public void billsSaveDoc()
        { 

        }
    }
}
