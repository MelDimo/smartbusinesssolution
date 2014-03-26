using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll
{
    public partial class DTO
    {
        public class Carte
        {
            public int id { get; set; }
            public int code { get; set; }
            public string name { get; set; }
            public int branch { get; set; }
            public int refStatus { get; set; }
        }

        public class CarteDishesGroup
        {
            public int id { get; set; }
            public int idParent { get; set; }
            public int carte { get; set; }
            public string carte_name { get; set; }
            public string name { get; set; }
            public int refStatus { get; set; }
        }

        public class CarteDishes
        {
            public int id { get; set; }
            public int carteDishesGroup { get; set; }
            public int refDishes { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public decimal minStep { get; set; }
            public int refStatus { get; set; }
            public int isVisible { get; set; }
            public int refPrintersType { get; set; }
        }

        public class Dishes
        {
            public int id { get; set; }
            public int code { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public decimal minStep { get; set; }
            public int refPrintersType { get; set; }
            public int refStatus { get; set; }
        }
    }
}
