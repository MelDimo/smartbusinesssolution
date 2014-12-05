using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll
{
    public partial class DTO
    {
        public class Discount
        {
            public int id { get; set; }
            public Guid guid { get; set; }
            public string fio { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public int ref_discount_type { get; set; }
            public decimal discount { get; set; }
            public decimal stepDiscount { get; set; }
            public decimal maxDiscount { get; set; }
            public string xKey { get; set; }
            public DateTime dateStart { get; set; }
            public DateTime? dateEnd { get; set; }
            public int isExpDate { get; set; }
            public int ref_status { get; set; }
        }
    }
}
