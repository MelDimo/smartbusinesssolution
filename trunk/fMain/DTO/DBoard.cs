using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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
            public DateTime? dateClose { get; set; }
            public int refStatus { get; set; }
            public string refStatusName { get; set; }
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

        public class Bill : ICloneable
        {
            public Bill()
            {
                fioClose = string.Empty;
            }

            public int id { get; set; }
            public int numb { get; set; }
            public int table { get; set; }
            public DateTime openDate { get; set; }
            public DateTime? closeDate { get; set; }
            public int refStat { get; set; }
            public int refNotes { get; set; }
            public string refStatName { get; set; }
            public decimal summFact { get; set; }
            public decimal summ { get; set; }
            public int paymentType { get; set; }
            public decimal discount { get; set; }
            public string fioClose { get; set; }

            public object Clone()
            {
                return new Bill()
                {
                    id = this.id,
                    numb = this.numb,
                    table = this.table,
                    openDate = this.openDate,
                    closeDate = this.closeDate,
                    refStat = this.refStat,
                    refNotes = this.refNotes,
                    refStatName = this.refStatName,
                    summFact = this.summFact,
                    summ = this.summ,
                    paymentType = this.paymentType,
                    discount = this.discount,
                    fioClose = this.fioClose
                };
            }
        }

        public class Dish : ICloneable
        {
            public int id { get; set; }
            public int carteDishes { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public decimal minStep { get; set; }
            public decimal count { get; set; }
            //public string portion { get; set; }
            public DateTime? dateStatus { get; set; }
            public int refStatus { get; set; }
            public int refNotes { get; set; }
            public string refNotesName { get; set; }
            public int refPrintersType { get; set; }


            public object Clone()
            {
                return new Dish()
                {
                    id = this.id,
                    carteDishes = this.carteDishes,
                    name = this.name,
                    price = this.price,
                    minStep = this.minStep,
                    count = this.count,
                    dateStatus = this.dateStatus,
                    refStatus = this.refStatus,
                    refNotes = this.refNotes,
                    refNotesName = this.refNotesName,
                    refPrintersType = this.refPrintersType
                };
            }
        }

        public class DishRefuse
        {
            public int id { get; set; }
            public int carteDishes { get; set; }
            public string name { get; set; }
            public decimal minStep { get; set; }
            public decimal count { get; set; }
            public decimal price { get; set; }
            public DateTime refuseDate { get; set; }
            public string refuseFio { get; set; }
            public int refPrintersType { get; set; }
            public int refStatus { get; set; }
        }
    }
}
