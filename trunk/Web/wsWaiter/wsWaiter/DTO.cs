using System;

public class DTO
{

    public class Bill
    {
        public int id { get; set; }
        public int season { get; set; }
        public string dateBill { get; set; }
        public int numBill { get; set; }
        public int table { get; set; }
        public decimal sum { get; set; }
    }

    public class GValuesEx
    {
        public int branch { get; set; }
    }
}