using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace com.sbs.dll
{
    public partial class DTO
    {
        public class User
        {
            public User()
            {
                passDateIssued = DateTime.Now;
                bdate = DateTime.Now;
                refStatusDate = DateTime.Now;
                dateAdopted = DateTime.Now;
                dateStarted = DateTime.Now;
                dateFired = DateTime.Now;
            }

            public int id { get; set; }
            public string tabn { get; set; }
            public string login { get; set; }
            public string fName { get; set; }
            public string sName { get; set; }
            public string lName { get; set; }
            public DateTime bdate { get; set; }
            public string bPlace { get; set; }
            public int org { get; set; }
            public int branch { get; set; }
            public int unit { get; set; }
            public int refPost { get; set; }
            public int refStatus { get; set; }
            public DateTime? refStatusDate { get; set; }
            public string pwd { get; set; }

            public DateTime? dateAdopted { get; set; }
            public DateTime? dateStarted { get; set; }
            public DateTime? dateFired { get; set; }
            public string docNumber { get; set; }
            public string pensNumber { get; set; }
            public int citizen1 { get; set; }
            public int citizen2 { get; set; }
            public int nationality { get; set; }
            public string passSeriy { get; set; }
            public string passNumber { get; set; }
            public DateTime? passDateIssued { get; set; }
            public string passWhoIssued { get; set; }
            public string passAddress { get; set; }
            public int education1 { get; set; }
            public int specialty1 { get; set; }
            public string doc1 { get; set; }
            public int education2 { get; set; }
            public int specialty2 { get; set; }
            public string doc2 { get; set; }

            public int reservist { get; set; }
        }

        public class Group
        {
            public int id;
            public string name;
            public int refStatus;
        }

        public class DiscountInfo
        {
            public DiscountInfo()
            {
                photo = com.sbs.dll.utilites.Properties.Resources.user_64;
                dateEnd = DateTime.Now;
                dateStart = DateTime.Now;
                bdate = DateTime.Now;
                refStatus = 1;
            }

            public int id { get; set; }
            public Guid guid { get; set; }
            public string fio { get; set; }
            public DateTime? bdate { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string xNumber { get; set; }
            public string xKey { get; set; }
            public int ref_discount_type { get; set; }
            public string ref_discount_type_name { get; set; }
            public decimal discount { get; set; }
            public decimal stepDiscount { get; set; }
            public decimal maxDiscount { get; set; }
            public int refStatus { get; set; }
            public DateTime dateStart { get; set; }
            public DateTime dateEnd { get; set; }
            public int isExpDate { get; set; }
            public Image photo { get; set; }
            public int isConfirmed { get; set; }
        }

        public class DiscountType
        {
            public int id { get; set; }
            public string name { get; set; }
            public int ref_status { get; set; }
            public string notes { get; set; }
            public decimal discount { get; set; }
            public decimal stepDiscount { get; set; }
            public decimal maxDiscount { get; set; }
        }
    }
}
