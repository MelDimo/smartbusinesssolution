﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Data;
using System.Data.SqlClient;

namespace com.sbs.gui.seasonbrowser
{
    public class DBaccess
    {
        public enum Role { FRONTOFFICE, BACKOFFICE, NONE };

        private DataTable dtResult;

        private SqlConnection con;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        DataTable dtXmlBill, dtXmlBuxs, dtXmlCeks;

        internal List<DTO_DBoard.SeasonBranch> getSeason(Filter pFilter)
        {
            dtResult = new DataTable();

            List<DTO_DBoard.SeasonBranch> lSeasonBranch = new List<DTO_DBoard.SeasonBranch>();
            DTO_DBoard.SeasonBranch oSeasonBranch;

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();


                command.CommandText = "SeasonBrowser_GetSeason";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("pConType", SqlDbType.NVarChar).Value = "online";// GValues.DBMode;
                command.Parameters.Add("pDateOpen", SqlDbType.DateTime).Value = pFilter.dateStart;
                command.Parameters.Add("pDateClose", SqlDbType.DateTime).Value = pFilter.dateEnd;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();

            }
            catch (Exception exc) { throw new Exception("", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach (DataRow dr in dtResult.Rows)
            {
                oSeasonBranch = new DTO_DBoard.SeasonBranch();
                oSeasonBranch.seasonID = (int)dr["season_id"];
                oSeasonBranch.dateOpen = (DateTime)dr["date_open"];
                oSeasonBranch.dateClose = DBNull.Value.Equals(dr["date_close"]) ? (DateTime?)null : (DateTime)dr["date_close"];
                oSeasonBranch.userID = (int)dr["user_open"];
                oSeasonBranch.refStatus = (int)dr["ref_status"];
                oSeasonBranch.refStatusName = dr["ref_status_name"].ToString();
                
                lSeasonBranch.Add(oSeasonBranch);
            }

            return lSeasonBranch;
        }

        internal List<DTO_DBoard.Bill> getBill(Filter pFilter)
        {
            dtResult = new DataTable();
            List<DTO_DBoard.Bill> lBill = new List<DTO_DBoard.Bill>();

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "SeasonBrowser_GetBills";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("pSeasonId", SqlDbType.Int).Value = pFilter.season;
                command.Parameters.Add("pConType", SqlDbType.NVarChar).Value = "online";// GValues.DBMode;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();

            }
            catch (Exception exc) { throw new Exception("", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach (DataRow dr in dtResult.Rows)
            {
                lBill.Add(new DTO_DBoard.Bill()
                {
                    id = (int)dr["bills_id"],
                    numb = (int)dr["numb"],
                    table = (int)dr["xTable"],
                    openDate = (DateTime)dr["date_open"],
                    closeDate = DBNull.Value.Equals(dr["date_close"]) ? (DateTime?)null : (DateTime)dr["date_close"],
                    paymentType = DBNull.Value.Equals(dr["ref_payment_type"]) ? 0 : (int)dr["ref_payment_type"],
                    refNotes = DBNull.Value.Equals(dr["ref_notes"]) ? 0 : (int)dr["ref_notes"],
                    refStat = (int)dr["ref_status"],
                    refStatName = dr["ref_status_name"].ToString(),
                    summFact = decimal.Parse(dr["sum"].ToString()),
                    discount = decimal.Parse(dr["discount"].ToString())
                });
            }

            return lBill;
        }

        internal List<DTO_DBoard.Dish> getDish(Filter pFilter)
        { 
            dtResult = new DataTable();
            List<DTO_DBoard.Dish> lDish = new List<DTO_DBoard.Dish>();

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "SeasonBrowser_GetDishes";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("pSeasonId", SqlDbType.Int).Value = pFilter.season;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pFilter.bill;
                command.Parameters.Add("pConType", SqlDbType.NVarChar).Value = "online";// GValues.DBMode;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();

            }
            catch (Exception exc) { throw new Exception("", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach (DataRow dr in dtResult.Rows)
            {
                lDish.Add(new DTO_DBoard.Dish()
                {
                    id = (int)dr["bills_info"],
                    carteDishes = (int)dr["carte_dishes"],
                    name = dr["dishes_name"].ToString(),
                    price = decimal.Parse(dr["dishes_price"].ToString()),
                    count = decimal.Parse(dr["xcount"].ToString()),
                    refNotes = (int)dr["ref_notes"],
                    refStatus = (int)dr["ref_status"]
                });
            }

            return lDish;
        }

        internal void saveBill(Filter pFilter, DTO_DBoard.Bill pBill)
        {
            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "SeasonBrowser_SaveBill";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = pFilter.season;
                command.Parameters.Add("pID", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pRefPaymentType", SqlDbType.Int).Value = pBill.paymentType;
                command.Parameters.Add("pRefNotes", SqlDbType.Int).Value = pBill.refNotes;
                command.Parameters.Add("pRefStatus", SqlDbType.Int).Value = pBill.refStat;
                command.Parameters.Add("pDiscount", SqlDbType.Int).Value = pBill.discount;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;

                command.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception exc) { throw new Exception("", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void saveDish(Filter pFilter, DTO_DBoard.Dish pDish)
        {
            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "SeasonBrowser_SaveDish";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = pFilter.season;
                command.Parameters.Add("pBillsInfo", SqlDbType.Int).Value = pDish.id;
                command.Parameters.Add("pCount", SqlDbType.Int).Value = pDish.count;
                command.Parameters.Add("pStatus", SqlDbType.Int).Value = pDish.refStatus;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;

                command.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception exc) { throw new Exception(exc.Message, exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal Report REP_xOrder(Filter pFilter)
        {
            string conType = string.Empty;
            Report oReport = new Report();
            dtResult = new DataTable();

            //if (UsersInfo.Acl.Contains<int>(21)) // Постобработка счетов в ОТКРЫТОЙ смене
            //    conType = "offline";

            //if (UsersInfo.Acl.Contains<int>(22)) // Постобработка счетов в ЗАКРЫТОЙ смене
            //    conType = "online";

            conType = "online";

            if (conType.Equals(String.Empty))
                throw new Exception("Неудалось определить привилегии для Постобработки смены");

            con = new DBCon().getConnection(conType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.Connection = con;

                command.CommandText = "REP_xOrder";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("pSeasonId", SqlDbType.Int).Value = pFilter.season;
                command.Parameters.Add("repPath", SqlDbType.NVarChar, 128);
                command.Parameters["repPath"].Direction = ParameterDirection.Output;
                command.Parameters.Add("printerName", SqlDbType.NVarChar, 128);
                command.Parameters["printerName"].Direction = ParameterDirection.Output;
                command.Parameters.Add("pConType", SqlDbType.NVarChar, 8).Value = conType;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                dtResult.TableName = "xReport";
                oReport = new Report()
                {
                    repPath = command.Parameters["repPath"].Value.ToString(),
                    printName = command.Parameters["printerName"].Value.ToString(),
                    dtReport = dtResult
                };
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }

            return oReport;
        }

        internal DataSet exportFor1C(Filter pFilter)
        {
            DataSet dsResult = new DataSet();

            dtXmlBill = new DataTable("XmlBill");
            dtXmlBuxs = new DataTable("XmlBuxs");
            dtXmlCeks = new DataTable("XmlCeks");

            dtResult = new DataTable();

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "SELECT bills_id, " +
                                            " id as ID, " +
                                            " date_open as D_DATE, " +
			                                " '000549' as OFI, " +
                                            " branch as DEPARTAMEN, " +
                                            " [sum] as D_SUMM, " +
                                            " NULL as D_NDSSUMM, " +
                                            " NULL as D_DISCOUNT_SUMM, " +
                                            " NULL as D_DISCOUNT_NDSSUMM, " +
                                            " season as SMENID, " +
                                            " NULL as CASSID, " +
                                            " NULL as CLIENDID " +
	                                    " FROM bills_all " +
                                        " WHERE branch = @branch AND season = @season;";
                command.CommandType = CommandType.Text;

                command.Parameters.Add("branch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("season", SqlDbType.Int).Value = pFilter.season;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtXmlBill.Load(dr);
                }

                dsResult.Tables.Add(dtXmlBill);

                command.CommandText = " SELECT id, " +
                                            " bills_id, " +
                                            " ref_payment_type as BUXS_ID " +
                                            " FROM bills_all " +
                                        " WHERE branch = @branch AND season = @season;";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtXmlBuxs.Load(dr);
                }

                dsResult.Tables.Add(dtXmlBuxs);

                command.CommandText = " SELECT bia.bills," +
                                                " u.code as DEPARTAMENT," +
                                                " bia.id as LineID," +
                                                " 0 as OwnerID," +
                                                " rd.code as ASSID," +
                                                " bia.xcount as QTY," +
                                                " 0 as COEF_QTY," +
                                                " bia.dishes_price as PRICE," +
                                                " 0 as NODISK_PRICE," +
                                                " 0 as NDS_PROCENT," +
                                                " 0 as NDSID," +
                                                " bia.xcount * bia.dishes_price as SUMM," +
                                                " 0 as NDSSUMM," +
                                                " 0 as DISCOUNTSUMM," +
                                                " 0 as DISCOUNTSUMMNDS" +
                                        " FROM bills_info_all bia" +
                                        " INNER JOIN carte_dishes cd ON cd.id = bia.carte_dishes" +
                                        " INNER JOIN carte_dishes_group cdg ON cdg.id = cd.carte_dishes_group" +
                                        " INNER JOIN ref_dishes rd ON rd.id = cd.ref_dishes" +
                                        " INNER JOIN unit u ON u.ref_printers_type = rd.ref_printers_type AND u.branch = @branch" +
                                        " WHERE bia.branch = @branch AND bia.season = @season" +
                                        " ORDER BY bia.bills, u.code;";
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtXmlCeks.Load(dr);
                }

                dsResult.Tables.Add(dtXmlCeks);

                con.Close();

            }
            catch (Exception exc) { throw new Exception("", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return dsResult;
        }

        internal DataTable getBillsLog(Filter pFilter)
        { 
            dtResult = new DataTable();

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = " SELECT ROW_NUMBER() OVER(ORDER BY xorder ASC) AS [п/п], " +
                                      " [sum] AS Сумма, " +
                                      "        discount AS Скидка, " +
                                      "         rpt.name AS [Тип оплаты], " +
                                      "         uopen.lname+' '+uopen.fname+' '+uopen.sname AS [Открыл], " +
                                      "         uclose.lname+' '+uclose.fname+' '+uclose.sname AS [Закрыл], " +
                                      "         uedit.lname+' '+uedit.fname+' '+uedit.sname AS [Редактировал], " +
                                      "         bal.date_edit [Дата ред.]" +
                                      " FROM bills_all_log bal " +
                                      " INNER JOIN users uopen ON uopen.id = bal.user_open " +
                                      " INNER JOIN users uclose ON uclose.id = bal.user_close " +
                                      " LEFT JOIN users uedit ON uedit.id = bal.user_edit " +
                                      " INNER JOIN ref_payment_type rpt ON rpt.id = bal.ref_payment_type " +
                                      " WHERE bal.branch = @branch AND bal.season = @season AND bal.bills_id = @bills" +
                                      " ORDER BY xorder ";
                command.CommandType = CommandType.Text;

                command.Parameters.Add("branch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("season", SqlDbType.Int).Value = pFilter.season;
                command.Parameters.Add("bills", SqlDbType.Int).Value = pFilter.bill;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }
            }
            catch (Exception exc) { throw new Exception("", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return dtResult;
        }

        internal DataTable getDishesLog(Filter pFilter, DTO_DBoard.Dish pDish)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "SELECT ROW_NUMBER() OVER(ORDER BY xorder ASC) AS [п/п], " +
                                            " dishes_name AS Наименование, " +
                                            " xcount AS [Кол-во], " +
                                            " dishes_price AS Сумма, " +
                                            " uopen.lname+' '+uopen.fname+' '+uopen.sname AS [Добавил], " +
                                            " uedit.lname+' '+uedit.fname+' '+uedit.sname AS [Редактировал], " +
                                            " bial.date_edit AS [Дата ред.] " +
                                    " FROM bills_info_all_log bial " +
                                    " INNER JOIN users uopen ON uopen.id = bial.user_add " +
                                    " LEFT JOIN users uedit ON uedit.id = bial.user_edit " +
                                    " WHERE bial.branch = @branch AND bial.season = @season AND bial.bills = @bills AND bial.bills_info = @bills_info" +
                                    " ORDER BY bial.xorder ";
                command.CommandType = CommandType.Text;

                command.Parameters.Add("branch", SqlDbType.Int).Value = pFilter.branch;
                command.Parameters.Add("season", SqlDbType.Int).Value = pFilter.season;
                command.Parameters.Add("bills", SqlDbType.Int).Value = pFilter.bill;
                command.Parameters.Add("bills_info", SqlDbType.Int).Value = pDish.id;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }
            }
            catch (Exception exc) { throw new Exception("", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return dtResult;
        }
    }

    public class Filter
    {
        public int branch { get; set; }
        public int season { get; set; }
        public int bill { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public bool isSeasonOpen { get; set; }
        
        public int countBill { get; set; }

        /// <summary>
        /// Текущий последний элемент
        /// </summary>
        public int curLast;

        public Filter()
        {
            countBill = 25;
        }
    }

    internal class Report
    {
        public string repPath;
        public string printName;
        public DataTable dtReport;
    }
}