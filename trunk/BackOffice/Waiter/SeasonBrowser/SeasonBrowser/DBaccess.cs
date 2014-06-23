using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll.utilites;
using System.Drawing;

namespace com.sbs.gui.seasonbrowser
{
    public class DBaccess
    {
        public enum Role { FRONTOFFICE, BACKOFFICE, NONE };

        private DataTable dtResult;

        private SqlConnection con = new SqlConnection();
        private SqlConnection conMain = new SqlConnection();
        private SqlConnection conLocal = new SqlConnection();
        private SqlCommand command = null;
        private SqlCommand commandMain = null;
        private SqlCommand commandLocal = null;

        private SqlTransaction txMain = null;
        private SqlTransaction txLocal = null;

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
                    discount = decimal.Parse(dr["discount"].ToString()),
                    fioClose = dr["fioClose"].ToString()
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
                    refStatus = (int)dr["ref_status"],
                    discount = decimal.Parse(dr["discount"].ToString())
                });
            }

            return lDish;
        }

        internal void saveBill(Filter pFilter, DTO_DBoard.Bill pBill)
        {
            try
            {
                conMain = new DBCon().getConnection(GValues.DBMode);
                conMain.Open();
                commandMain = conMain.CreateCommand();

                txMain = conMain.BeginTransaction();
                commandMain.Transaction = txMain;

                commandMain.CommandText = "SeasonBrowser_SaveBill";
                commandMain.CommandType = CommandType.StoredProcedure;

                commandMain.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                commandMain.Parameters.Add("pSeason", SqlDbType.Int).Value = pFilter.season;
                commandMain.Parameters.Add("pID", SqlDbType.Int).Value = pBill.id;
                commandMain.Parameters.Add("pRefPaymentType", SqlDbType.Int).Value = pBill.paymentType;
                commandMain.Parameters.Add("pRefNotes", SqlDbType.Int).Value = pBill.refNotes;
                commandMain.Parameters.Add("pRefStatus", SqlDbType.Int).Value = pBill.refStat;
                commandMain.Parameters.Add("pDiscount", SqlDbType.Int).Value = pBill.discount;
                commandMain.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;

                commandMain.ExecuteNonQuery();
                #region Скидка на счет
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //conLocal = new DBCon().getConnection("offline");
                //conLocal.Open();
                //commandLocal = conLocal.CreateCommand();

                //txLocal = conLocal.BeginTransaction();
                //commandLocal.Transaction = txLocal;

                //commandLocal.CommandText = "SeasonBrowser_SaveBill_localBill";
                //commandLocal.CommandType = CommandType.StoredProcedure;

                //commandLocal.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                //commandLocal.Parameters.Add("pSeason", SqlDbType.Int).Value = pFilter.season;
                //commandLocal.Parameters.Add("pID", SqlDbType.Int).Value = pBill.id;
                //commandLocal.Parameters.Add("pDiscount", SqlDbType.Int).Value = pBill.discount;

                //commandLocal.ExecuteNonQuery();

                //txLocal.Commit();
                #endregion Скидка на счет
                txMain.Commit();
            }
            catch (Exception exc) { txMain.Rollback(); /*txLocal.Rollback();*/ throw new Exception("", exc); }
            finally 
            { 
                if (conMain.State == ConnectionState.Open) conMain.Close();
                //if (conLocal.State == ConnectionState.Open) conLocal.Close();
            }
        }

        internal void saveDish(Filter pFilter, DTO_DBoard.Dish pDish, DBaccess.Role pCurRole)
        {
            decimal newBillSum;

            try
            {
                conMain = new DBCon().getConnection(GValues.DBMode);

                conMain.Open();
                commandMain = conMain.CreateCommand();

                txMain = conMain.BeginTransaction();
                commandMain.Transaction = txMain;

                commandMain.CommandText = "SeasonBrowser_SaveDish";
                commandMain.CommandType = CommandType.StoredProcedure;

                commandMain.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                commandMain.Parameters.Add("pSeason", SqlDbType.Int).Value = pFilter.season;
                commandMain.Parameters.Add("pBillsInfo", SqlDbType.Int).Value = pDish.id;
                commandMain.Parameters.Add("pCount", SqlDbType.Decimal).Value = pDish.count;
                commandMain.Parameters.Add("pDiscount", SqlDbType.Decimal).Value = pDish.discount;
                commandMain.Parameters.Add("pStatus", SqlDbType.Int).Value = pDish.refStatus;
                commandMain.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;
                commandMain.Parameters.Add("pBillsId", SqlDbType.Int).Value = pFilter.bill;
                commandMain.Parameters.Add("pSumNew", SqlDbType.Decimal);
                commandMain.Parameters["pSumNew"].Direction = ParameterDirection.Output;

                commandMain.ExecuteNonQuery();

                newBillSum = (decimal)commandMain.Parameters["pSumNew"].Value;

                if (pFilter.isSeasonOpen && pCurRole == Role.FRONTOFFICE)
                {
                    conLocal = new DBCon().getConnection("offline");
                    conLocal.Open();
                    commandLocal = conLocal.CreateCommand();

                    txLocal = conLocal.BeginTransaction();
                    commandLocal.Transaction = txLocal;

                    commandLocal.CommandText = "SeasonBrowser_SaveDish_localDish";
                    commandLocal.CommandType = CommandType.StoredProcedure;

                    commandLocal.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
                    commandLocal.Parameters.Add("pSeason", SqlDbType.Int).Value = pFilter.season;
                    commandLocal.Parameters.Add("pBillsId", SqlDbType.Int).Value = pFilter.bill;
                    commandLocal.Parameters.Add("pSumNew", SqlDbType.Int).Value = newBillSum;

                    commandLocal.ExecuteNonQuery();

                    txLocal.Commit();
                }

                txMain.Commit();

            }
            catch (Exception exc) { txMain.Rollback(); txLocal.Rollback(); throw new Exception(exc.Message, exc); }
            finally {
                if (conMain.State == ConnectionState.Open) conMain.Close();
                if (conLocal.State == ConnectionState.Open) conLocal.Close();
            }
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
                                        " WHERE branch = @branch AND season = @season AND ref_status = 21;";
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
                                        //" ORDER BY bia.bills, u.code;" +
                                        " UNION " +
                                        " SELECT bita.bills, " +
                                            " u.code as DEPARTAMENT, " +
                                            " bia.id as LineID, " +
                                            " 0 as OwnerID, " +
                                            " rd.code as ASSID, " +
                                            " 1 as QTY, " +
                                            " 0 as COEF_QTY, " +
                                            " bia.dishes_price as PRICE, " +
                                            " 0 as NODISK_PRICE, " +
                                            " 0 as NDS_PROCENT, " +
                                            " 0 as NDSID, " +
                                            " 1 * bia.dishes_price as SUMM, " +
                                            " 0 as NDSSUMM, " +
                                            " 0 as DISCOUNTSUMM, " +
                                            " 0 as DISCOUNTSUMMNDS " +
                                        " FROM bills_info_toppings_all bita " +
                                        " INNER JOIN bills_info_all bia ON bia.bills_info = bita.bills_info " +
                                        " INNER JOIN toppings_carte_dishes tcd ON tcd.id = bita.toppings_carte_dishes " +
                                        " INNER JOIN carte_dishes cd ON cd.id = tcd.carte_dishes " +
                                        " INNER JOIN ref_dishes rd ON rd.id = cd.ref_dishes " +
                                        " INNER JOIN unit u ON u.ref_printers_type = rd.ref_printers_type AND u.branch = @branch " +
                                        " WHERE bia.branch = @branch AND bia.season = @season AND bita.isSelected = 1 " +
                                        " ORDER BY bia.bills, u.code";
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
                                            " dishes_price AS Цена, " +
                                            " discount AS Скидка, " +
                                            " ((dishes_price * xcount) - ((dishes_price * xcount) * discount) / 100) AS Сумма, " +
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
