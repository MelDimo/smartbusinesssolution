using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll;

namespace com.sbs.gui.report.repsumbyitems
{
    class DBaccess
    {
        private SqlConnection con;
        private SqlCommand command = null;

        public DataTable prepareReport(string pDbType, Filter pFilter)
        {
            string sBranch = string.Empty;
            string sPaymentType = string.Empty;
            string sItems = string.Empty;

            string sDateStart = string.Empty;
            string sDateEnd = string.Empty;

            foreach (int i in pFilter.lBranch.ToArray()) sBranch += i.ToString() + ",";
            sBranch = sBranch.TrimEnd(',');

            foreach (int i in pFilter.lPaymentType.ToArray()) sPaymentType += i.ToString() + ",";
            sPaymentType = sPaymentType.TrimEnd(',');

            foreach (int i in pFilter.lItems.ToArray()) sItems += i.ToString() + ",";
            sItems = sItems.TrimEnd(',');

            sDateStart = pFilter.dateStart.Year.ToString() + "-" +
                        pFilter.dateStart.Month.ToString() + "-" +
                        pFilter.dateStart.Day.ToString() +
                        " " +
                        pFilter.dateStart.Hour.ToString() + ":" +
                        pFilter.dateStart.Minute.ToString() + ":" +
                        pFilter.dateStart.Second.ToString();

            sDateEnd = pFilter.dateEnd.Year.ToString() + "-" +
                        pFilter.dateEnd.Month.ToString() + "-" +
                        pFilter.dateEnd.Day.ToString() +
                        " " +
                        pFilter.dateEnd.Hour.ToString() + ":" +
                        pFilter.dateEnd.Minute.ToString() + ":" +
                        pFilter.dateEnd.Second.ToString();

            DataTable dtResult = new DataTable();

            try
            {
                con = new DBCon().getConnection(pDbType);
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT rd.code, " +
                                                " bi.ref_dishes, " +
                                                " bi.dishes_name AS dishesName, " +
                                                " br.name AS nameBranch, " +
                                                " bi.dishes_price AS dishesPrice, " +
                                                " count(bi.ref_dishes) AS dishesCount, " +
                                                " bi.dishes_price * sum(bi.xcount) AS dishesSumm " +
                                        " FROM bills_all b " +
                                        " INNER JOIN season_all s ON s.season_id = b.season AND s.branch = b.branch " +
                                        " INNER JOIN bills_info_all bi ON bi.bills = b.bills_id AND bi.season = s.season_id " +
                                        " LEFT JOIN ref_dishes rd ON rd.id = bi.ref_dishes " +
                                        " INNER JOIN branch br ON br.id = b.branch " +
                                        " WHERE b.date_open >= CONVERT(datetime,'" + sDateStart + "',120) " +
                                            " AND b.date_close <= CONVERT(datetime,'" + sDateEnd + "',120) " +
                                            " AND b.branch in (" + sBranch + ") AND b.ref_payment_type in (" + sPaymentType + ") " +
                                            " AND bi.ref_dishes in (" + sItems + ") " +
                                        " GROUP BY bi.ref_dishes, rd.code, bi.dishes_name, br.name, bi.dishes_price";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
            return dtResult;
        }
    }

    public class Filter
    {
        public Filter()
        {
            lBranch = new List<int>();
            lPaymentType = new List<int>();
            lItems = new List<int>();
        }

        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public List<int> lBranch { get; set; }
        public List<int> lPaymentType { get; set; }
        public List<int> lItems { get; set; }
    }
}
