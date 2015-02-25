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

            if(sItems.Length == 0) sItems = "";
            else  sItems = " AND bi.ref_dishes in (" + sItems + ") ";

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
                command.CommandTimeout = 600;

                //command.CommandText = " SELECT rd.code, " +
                //                                " bi.ref_dishes, " +
                //                                " rdg.name AS dishesGroupName, " +
                //                                " bi.dishes_name AS dishesName, " +
                //                                " br.name AS nameBranch, " +
                //                                " bi.dishes_price AS dishesPrice, " +
                //                                " SUM(bi.xcount) AS dishesCount, " +
                //                                " (bi.dishes_price - (bi.dishes_price * bi.discount / 100))  * sum(bi.xcount) AS dishesSumm " +
                //                        " FROM bills_all b " +
                //                        " INNER JOIN season_all s ON s.season_id = b.season AND s.branch = b.branch " +
                //                        " INNER JOIN bills_info_all bi ON bi.bills = b.bills_id AND bi.season = s.season_id AND bi.branch = b.branch" +
                //                        " LEFT JOIN ref_dishes rd ON rd.id = bi.ref_dishes " +
                //                        " LEFT JOIN ref_dishes_group rdg ON rdg.id = rd.ref_dishes_group " +
                //                        " INNER JOIN branch br ON br.id = b.branch " +
                //                        " WHERE b.date_open >= CONVERT(datetime,'" + sDateStart + "',120) " +
                //                            " AND b.date_close <= CONVERT(datetime,'" + sDateEnd + "',120) " +
                //                            " AND b.branch in (" + sBranch + ") AND b.ref_payment_type in (" + sPaymentType + ") " +
                //                            sItems +
                //                        " GROUP BY bi.ref_dishes, rd.code, rdg.name, bi.dishes_name, br.name, bi.dishes_price, bi.discount " +
                //                        " ORDER BY rdg.name, bi.dishes_name";

                command.CommandText = string.Empty;
                foreach (int i in pFilter.lBranch.ToArray())
                {
                    command.CommandText += " SELECT rd.code, " +
                                            "    bi.ref_dishes,  " +
                                            "    rdg.name AS dishesGroupName,  " +
                                            "    bi.dishes_name AS dishesName,  " +
                                            "    br.name AS nameBranch,  " +
                                            "    bi.dishes_price AS dishesPrice,  " +
                                            "    SUM(bi.xcount) AS dishesCount," +
                                            "    (bi.dishes_price - (bi.dishes_price * bi.discount / 100))  * sum(bi.xcount) AS dishesSumm  " +
                                            " FROM bills_all b  " +
                                            " INNER JOIN season_all s ON s.season_id = b.season AND s.branch = b.branch  " +
                                            " INNER JOIN bills_info_all bi ON bi.bills = b.bills_id AND bi.season = s.season_id AND bi.branch = b.branch " +
                                            " LEFT JOIN ref_dishes rd ON rd.id = bi.ref_dishes  " +
                                            " LEFT JOIN ref_dishes_group rdg ON rdg.id = rd.ref_dishes_group  " +
                                            " INNER JOIN branch br ON br.id = b.branch  " +
                                            " WHERE b.branch = " + i.ToString() + " AND b.ref_payment_type in (" + sPaymentType + ") AND " +
                                                " b.date_open BETWEEN CONVERT(datetime,'" + sDateStart + "',120) AND CONVERT(datetime,'" + sDateEnd + "',120) " +
                                                " GROUP BY bi.ref_dishes, rd.code, rdg.name, bi.dishes_name, br.name, bi.dishes_price, bi.discount " +
                                            " UNION";
                                        
                }

                command.CommandText = command.CommandText.TrimEnd("UNION".ToCharArray());
                command.CommandText += " ORDER BY rdg.name, bi.dishes_name ";

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
            lItemsTree = new List<int>();
        }

        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public List<int> lBranch { get; set; }
        public string branchNames { get; set; }
        public List<int> lPaymentType { get; set; }
        public List<int> lItems { get; set; }
        public List<int> lItemsTree { get; set; }
    }
}
