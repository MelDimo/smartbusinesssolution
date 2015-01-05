using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.report.repdelivery
{
    class DBAccess
    {
        private DataTable dtResult = new DataTable();

        private SqlConnection con;
        private SqlCommand command = null;

        internal DataTable prepareReport(string pDbType, RepParam pRepParam)
        {
            dtResult = new DataTable();
            string branch = string.Empty;

            string sDateStart = string.Empty;
            string sDateEnd = string.Empty;

            sDateStart = pRepParam.dateStart.Year.ToString() + "-" +
                        pRepParam.dateStart.Month.ToString() + "-" +
                        pRepParam.dateStart.Day.ToString() +
                        " " +
                        pRepParam.dateStart.Hour.ToString() + ":" +
                        pRepParam.dateStart.Minute.ToString() + ":" +
                        pRepParam.dateStart.Second.ToString();

            sDateEnd = pRepParam.dateEnd.Year.ToString() + "-" +
                        pRepParam.dateEnd.Month.ToString() + "-" +
                        pRepParam.dateEnd.Day.ToString() +
                        " " +
                        pRepParam.dateEnd.Hour.ToString() + ":" +
                        pRepParam.dateEnd.Minute.ToString() + ":" +
                        pRepParam.dateEnd.Second.ToString();


            foreach (int id in pRepParam.checkedBranch) branch += id + ",";

            try
            {
                con = new DBCon().getConnection(pDbType);
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT b.name, DATEADD(dd, 0, DATEDIFF(dd, 0, ba.date_open)) AS date_open, " +
                                                      " DATEADD(dd, 0, DATEDIFF(dd, 0, ba.date_close)) AS date_close, " +
                                                      " ba.ref_payment_type, ba.ref_status, ba.sum AS xSumm, ba.discount, rdt.xprice AS tariff " +
                                        " FROM bills_all ba " +
                                        " INNER JOIN bills_info_delivery_all bida ON bida.bills = ba.bills_id AND bida.branch = ba.branch AND bida.season = ba.season " +
                                        " INNER JOIN ref_delivery_tariff rdt ON rdt.id = bida.ref_delivery_tariff " +
                                        " INNER JOIN branch b ON b.id = ba.branch " +
                                        " WHERE ba.ref_status = 21 AND ref_payment_type != 9 AND  ba.date_open >= CONVERT(datetime,'" + sDateStart + "',120) " +
                                            " AND ba.date_close <= CONVERT(datetime,'" + sDateEnd + "',120) "
                                        + (branch.Equals(string.Empty) ? "" : " AND ba.branch in (" + branch.TrimEnd(',') + ")");

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
    class RepParam
    {
        public List<int> checkedBranch { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }

        public RepParam()
        {
            checkedBranch = new List<int>();
        }
    }
}