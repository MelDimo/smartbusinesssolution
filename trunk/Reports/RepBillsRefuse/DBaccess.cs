using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll;

namespace com.sbs.gui.report.repbillsrefuse
{
    class DBaccess
    {
        private SqlConnection con;
        private SqlCommand command = null;

        public DataTable prepareReport(string pDbType, Filter pFilter)
        {
            string sBranch = string.Empty;
            string sPaymentType = string.Empty;
            string sDateStart = string.Empty;
            string sDateEnd = string.Empty;

            foreach (int i in pFilter.lBranch.ToArray()) sBranch += i.ToString() + ",";
            sBranch = sBranch.TrimEnd(',');

            foreach (int i in pFilter.lPaymentType.ToArray()) sPaymentType += i.ToString() + ",";
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

                command.CommandText = " SELECT b.name AS branch, " +
                                      "      season,  " +
                                      "      date_open, " +
                                      "      date_close, " +
                                      "      numb,  " +
                                      "      u.lname + ' ' + u.fname + ' ' + u.sname AS fio, " +
                                      "      [sum] AS summa, " +
                                      "      rpt.name AS ref_payment_type_name " +
                                      "  FROM bills_all ba " +
                                      "  INNER JOIN users u ON u.id = ba.user_open " +
                                      "  INNER JOIN branch b ON b.id = ba.branch " +
                                      "  INNER JOIN ref_payment_type rpt ON rpt.id = ba.ref_payment_type  " +
                                      "  WHERE ba.date_open >= CONVERT(datetime,'" + sDateStart + "',120) " +
                                      "     AND ba.date_close <= CONVERT(datetime,'" + sDateEnd + "',120) " +
                                      "     AND ba.ref_payment_type in (" + sPaymentType + ") " +
                                      "     AND ba.branch in (" + sBranch + ") " +
                                      "  ORDER BY b.name, season, numb";

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
