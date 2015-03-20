using System;
using System.Collections.Generic;

public class DTO
{

    public class Menu
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<MenuGroup> oMenuGroup { get; set; }
        public List<MenuDishes> oMenuDishes { get; set; }
        public List<RefNotes> oRefNotes { get; set; }

        public Menu()
        {
            oMenuGroup = new List<MenuGroup>();
            oMenuDishes = new List<MenuDishes>();
            oRefNotes = new List<RefNotes>();
        }
    }

    public class MenuGroup
    {
        public int id { get; set; }
        public int id_parent { get; set; }
        public string name { get; set; }
    }

    public class MenuDishes
    {
        public int id { get; set; }
        public int refDishes { get; set; }
        public int groupId { get; set; }
        public string name { get; set; }
        public decimal minStep { get; set; }
        public decimal price { get; set; }
        public int isVisible { get; set; }
    }

    public class RefNotes
    {
        public int id { get; set; }
        public int refNotesType { get; set; }
        public string note { get; set; }
        public int refStatus { get; set; }
    }

    public class GetReferences
    {
        public List<BranchPayment> oBranchPayment { get; set; }

        public GetReferences()
        {
            oBranchPayment = new List<BranchPayment>();
        }
    }

    public class BranchPayment
    {
        public int branch { get; set; }
        public int refPaymentType { get; set; }
        public string name { get; set; }
        public string color { get; set; }

    }



    //public class Deals
    //{
    //    public int id { get; set; }
    //    public int carte { get; set; }
    //    public string name { get; set; }
    //    public decimal xcount { get; set; }
    //}

    //public class Deals_dishes
    //{
    //    public int id { get; set; }
    //    public int deals { get; set; }
    //    public string ref_dishes { get; set; }
    //    public decimal price { get; set; }
    //}

    //public class Deals_bonus
    //{
    //    public int id { get; set; }
    //    public int deals { get; set; }
    //    public string ref_dishes { get; set; }
    //    public decimal price { get; set; }
    //}

    //---------------------------------------------------------------------
    public class Bill
    {
        public int id { get; set; }
        public int season { get; set; }
        public string dateBill { get; set; }
        public int numBill { get; set; }
        public int table { get; set; }
        public decimal sum { get; set; }
    }

    public class BillInfo
    {
        public int id { get; set; }
        public int bills { get; set; }
        public int ref_dishes { get; set; }
        public string dishes_name { get; set; }
        public decimal dishes_price { get; set; }
        public decimal xcount { get; set; }
        public int ref_status { get; set; }
        public int ref_notes { get; set; }
        public string refNotesName { get; set; }
    }

    public class GValuesEx
    {
        public string fio { get; set; }
        public int branch { get; set; }
        public int userId { get; set; }
        public int season { get; set; }
    }
}