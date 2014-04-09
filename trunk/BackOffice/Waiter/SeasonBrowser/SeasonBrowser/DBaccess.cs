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
        private SqlTransaction tx = null;

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

            //for (int i = 0; i < 250; i++ )
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
                    refStat = (int)dr["ref_status"],
                    refStatName = dr["ref_status_name"].ToString(),
                    summFact = decimal.Parse(dr["bill_sum"].ToString())
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
    }

    class Filter
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
