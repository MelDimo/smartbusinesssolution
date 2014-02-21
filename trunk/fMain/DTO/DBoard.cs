using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll
{
    public partial class DTO_DBoard
    {
        public class SeasonBranch
        {
            public int seasonID { get; set; }
            public int userID { get; set; }
            public string userName { get; set; }
            public DateTime dateOpen { get; set; }
        }

        public class SeasonUser
        {
            public int id { get; set; }
            public string userOpenName { get; set; }
            public DateTime dateOpen { get; set; }
            public DateTime? dateClose { get; set; }
            public int refStatus { get; set; }
            public string refStatusName { get; set; }
            public decimal summ { get; set; }
        }

        public class User : UserACL
        {
            public int id { get; set; }
            public string name { get; set; }
            public string tabn { get; set; }
            public UserACL[] oUserACL { get; set; }
        }

        public class UserACL
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Bill
        {
            public int id { get; set; }
            public int numb { get; set; }
            public int table { get; set; }
            public DateTime openDate { get; set; }
            public DateTime? closeDate { get; set; }
            public int refStat { get; set; }
            public string refStatName { get; set; }
            public decimal summ { get; set; }
        }

        public class Dish
        {
            public int id { get; set; }
            public int carteDishes { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public decimal count { get; set; }
            public string portion { get; set; }
            public DateTime? addDate { get; set; }
            public int refStatus { get; set; }
            public int refPrintersType { get; set; }
        }
    }
}
