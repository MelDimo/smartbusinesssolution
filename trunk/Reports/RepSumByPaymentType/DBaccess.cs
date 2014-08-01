using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.report.repsumbypaymenttype
{
    public class DBaccess
    {
        private SqlConnection con;
        private SqlCommand command = null;

        public DataTable prepareReport(string pDbType, Filter pFilter)
        {
            string sBranch = string.Empty;
            string sPaymentType = string.Empty;
            string sDateStart = string.Empty;
            string sDateEnd = string.Empty;

            foreach(int i in pFilter.lBranch.ToArray())sBranch += i.ToString() + ",";
            sBranch = sBranch.TrimEnd(',');

            foreach(int i in pFilter.lPaymentType.ToArray())sPaymentType += i.ToString() + ",";
            sPaymentType = sPaymentType.TrimEnd(',');

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

                command.CommandText = " SELECT b.branch, br.name AS nameBranch, b.ref_payment_type, pt.name AS namePayment, count(b.numb) AS billsCount, sum(b.[sum]) AS summ" +
                                            " FROM bills_all b " +
                                            " INNER JOIN season_all s ON s.season_id = b.season AND s.branch = b.branch " +
                                            " INNER JOIN branch br ON br.id = b.branch " +
                                            " INNER JOIN ref_payment_type pt ON pt.id = b.ref_payment_type " +
                                            " WHERE s.date_open >= CONVERT(datetime,'" + sDateStart + "',120) " +
                                                " AND s.date_close <= CONVERT(datetime,'" + sDateEnd + "',120) " +
                                                " AND b.branch in (" + sBranch + ") AND b.ref_payment_type in (" + sPaymentType + ")" +
                                            " GROUP BY b.branch, br.name, b.ref_payment_type, pt.name";

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
        }

        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public List<int> lBranch { get; set; }
        public List<int> lPaymentType { get; set; }
    }
}
