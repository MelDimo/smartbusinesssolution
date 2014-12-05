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
            public List<int> unit { get; set; }

            public Carte()
            {
                unit = new List<int>();
            }
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
            public int carte { get; set; }
            public int refDishes { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public decimal minStep { get; set; }
            public int refStatus { get; set; }
            public int isVisible { get; set; }
            public int avalHall { get; set; }
            public int avalDelivery { get; set; }
            public int refPrintersType { get; set; }
        }

        public class Dishes
        {
            public Dishes()
            {
                minStep = 1;
            }

            public int id { get; set; }
            public int code { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public decimal minStep { get; set; }
            public int refPrintersType { get; set; }
            public int refStatus { get; set; }
            public int dishesGroup { get; set; }
        }

        public class Topping
        {
            public int id { get; set; }
            public int toppingsGroups { get; set; }
            public int carteDishes { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public int isSelected { get; set; }

        }

        public class ToppingGroup
        {
            public int id { get; set; }
            public int id_parent { get; set; }
            public int carteDishes { get; set; }
            public string name { get; set; }
            public int refStatus { get; set; }
        }

        public class Deals
        {
            public int id { get; set; }
            public string name { get; set; }
            public int carte { get; set; }
            public int refStatus { get; set; }
            public List<CarteDishes> lCarteDishes { get; set; }
            public List<CarteDishes> lCarteDishesBonus { get; set; }
            public int sumCount { get; set; }
            public DateTime dateStart { get; set; }
            public DateTime? dateEnd { get; set; }

            public Deals()
            {
                lCarteDishes = new List<CarteDishes>();
                lCarteDishesBonus = new List<CarteDishes>();
            }
        }
    }
}
