using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll.utilites;
using System.Drawing;

namespace com.sbs.gui.dashboard
{
    public class checkDiscount
    {
        private SqlConnection con;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        private DataTable dtResult;

        internal bool checkDishForDiscount(List<DTO_DBoard.Dish> plDishs, int pDiscount)
        {
            string dishesList = string.Empty;

            List<int> lDistinctDishes = plDishs.Select(o => o.carteDishes).Distinct().ToList();
            dtResult = new DataTable();

            foreach (int i in lDistinctDishes) dishesList = dishesList + i + ",";
            dishesList = dishesList.TrimEnd(',');

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = " SELECT carte_dishes, count(carte_dishes) as count " +
	                                    " FROM carte_dishes_discount " +
                                        " WHERE ref_discount_type = " + pDiscount + " AND carte_dishes IN (" + dishesList  + ") " +
	                                    " GROUP BY carte_dishes";
                command.CommandType = CommandType.Text;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return lDistinctDishes.Count == dtResult.Rows.Count;
        }
    }
}
