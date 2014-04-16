using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Data;
using System.Data.SqlClient;

namespace com.sbs.gui.seasonbrowser
{
    class DBaccess
    {
        private DataTable dtResult;

        private SqlConnection con;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

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
                command.Parameters.Add("pConType", SqlDbType.NVarChar).Value = GValues.DBMode;
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
                command.Parameters.Add("pConType", SqlDbType.NVarChar).Value = GValues.DBMode;

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
                    discount = (int)dr["discount"],
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
                command.Parameters.Add("pConType", SqlDbType.NVarChar).Value = GValues.DBMode;

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

                command.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception exc) { throw new Exception("", exc); }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
    }

    public class Filter
    {
        public int branch { get; set; }
        public int season { get; set; }
        public int bill { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        
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
}
