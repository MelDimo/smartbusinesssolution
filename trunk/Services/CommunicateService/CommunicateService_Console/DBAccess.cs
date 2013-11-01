using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.comunicate.CommunicateService_Console
{
    class DBAccess
    {
        SqlConnection con = null;
        SqlCommand command = null;
        SqlTransaction tx = null;
        DataTable dtResult = null;

        #region Получение информации о сменах (Season) и счетах (bills, bills_info)

        internal DataTable getSeason(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, code, branch, date_open, date_close, user_open, user_close, ref_status" +
                                        " FROM season";

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

        internal DataTable getBills(string pDbType, DataTable pAvalSeason)
        {
            string avalSeason = string.Empty;
            dtResult = new DataTable();

            foreach (DataRow dr in pAvalSeason.Rows)
            {
                avalSeason += dr["id"].ToString() + ",";
            }

            avalSeason = avalSeason.TrimEnd(',');

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, branch, season, numb, date_open, date_close, user_open, user_close, ref_status "+
                                        " FROM bills "+
                                        " WHERE season in (" + avalSeason + ") AND ref_status != @ref_status";

                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 20;

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

        internal DataTable getBillsInfo(string pDbType, DataTable pAvalBills)
        {
            string avalBills = string.Empty;
            dtResult = new DataTable();

            foreach (DataRow dr in pAvalBills.Rows)
            {
                avalBills += dr["id"].ToString() + ",";
            }

            avalBills = avalBills.TrimEnd(',');

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT branch, season, bills, dishes, dishes_name, dishes_price, xcount, discount, user_add, ref_status" +
                                        " FROM bills_info" +
                                        " WHERE bills in (" + avalBills + ")";

                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 20;

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

        #endregion

        internal void sendSeasonInfo(DataTable dtSeason, DataTable dtBills, DataTable dtBillsInfo)
        {
            string seasonId = string.Empty;
            string billsId = string.Empty;

            con = new DBCon().getConnection("online");
            command = null;
            try
            {
                con.Open();

                tx = con.BeginTransaction();
                command = con.CreateCommand();
                command.Transaction = tx;

                command.CommandText = "INSERT INTO season_all (branch,      season_id,  date_open,  date_close,     user_open,  user_close,     ref_status)" +
                                                        " VALUES(@branch,   @season_id, @date_open, @date_close,    @user_open, @user_close,    @ref_status)";

                command.Parameters.Add("branch", SqlDbType.Int);
                command.Parameters.Add("season_id", SqlDbType.Int);
                command.Parameters.Add("date_open", SqlDbType.DateTime);
                command.Parameters.Add("date_close", SqlDbType.DateTime);
                command.Parameters.Add("user_open", SqlDbType.Int);
                command.Parameters.Add("user_close", SqlDbType.Int);
                command.Parameters.Add("ref_status", SqlDbType.Int);

                foreach (DataRow dr in dtSeason.Rows)
                {
                    seasonId += dr["id"].ToString() + ",";
                    command.Parameters["branch"].Value = dr["branch"];
                    command.Parameters["season_id"].Value = dr["id"];
                    command.Parameters["date_open"].Value = dr["date_open"];
                    command.Parameters["date_close"].Value = dr["date_close"]??DBNull.Value;
                    command.Parameters["user_open"].Value = dr["user_open"];
                    command.Parameters["user_close"].Value = dr["user_close"] ?? DBNull.Value;
                    command.Parameters["ref_status"].Value = dr["ref_status"];

                    command.ExecuteNonQuery();
                }

                seasonId = seasonId.TrimEnd(',');
//------------------------------------------------------------------------------------------------------
                command.CommandText = string.Empty;
                command.Parameters.Clear();

                command.CommandText = "INSERT INTO bills_all(branch, season,    bills_id,   numb,   date_open,  date_close,     user_open,  user_close,     ref_status)"+
                                                    " VALUES(@branch, @season,   @bills_id,  @numb,  @date_open, @date_close,    @user_open, @user_close,    @ref_status)";

                command.Parameters.Add("branch", SqlDbType.Int);
                command.Parameters.Add("season", SqlDbType.Int);
                command.Parameters.Add("bills_id", SqlDbType.Int);
                command.Parameters.Add("numb", SqlDbType.Int);
                command.Parameters.Add("date_open", SqlDbType.DateTime);
                command.Parameters.Add("date_close", SqlDbType.DateTime);
                command.Parameters.Add("user_open", SqlDbType.Int);
                command.Parameters.Add("user_close", SqlDbType.Int);
                command.Parameters.Add("ref_status", SqlDbType.Int);

                foreach (DataRow dr in dtBills.Rows)
                {
                    billsId += dr["id"].ToString() + ",";

                    command.Parameters["branch"].Value = dr["branch"];
                    command.Parameters["season"].Value = dr["season"];
                    command.Parameters["bills_id"].Value = dr["id"];
                    command.Parameters["numb"].Value = dr["numb"];
                    command.Parameters["date_open"].Value = dr["date_open"];
                    command.Parameters["date_close"].Value = dr["date_close"];
                    command.Parameters["user_open"].Value = dr["user_open"];
                    command.Parameters["user_close"].Value = dr["user_close"];
                    command.Parameters["ref_status"].Value = dr["ref_status"];

                    command.ExecuteNonQuery();
                }

                billsId = billsId.TrimEnd(',');
//------------------------------------------------------------------------------------------------------
                command.CommandText = string.Empty;
                command.Parameters.Clear();

                command.CommandText = "INSERT INTO bills_info_all(branch,   season,     bills,  dishes,     dishes_name,    dishes_price,   xcount,     discount,   user_add,   ref_status)" +
                                                        " VALUES(@branch,    @season,    @bills, @dishes,    @dishes_name,   @dishes_price,  @xcount,    @discount,  @user_add,  @ref_status)";

                command.Parameters.Add("branch", SqlDbType.Int);
                command.Parameters.Add("season", SqlDbType.Int);
                command.Parameters.Add("bills", SqlDbType.Int);
                command.Parameters.Add("dishes", SqlDbType.Int);
                command.Parameters.Add("dishes_name", SqlDbType.NVarChar);
                command.Parameters.Add("dishes_price", SqlDbType.Int);
                command.Parameters.Add("xcount", SqlDbType.Int);
                command.Parameters.Add("discount", SqlDbType.Int);
                command.Parameters.Add("user_add", SqlDbType.Int);
                command.Parameters.Add("ref_status", SqlDbType.Int);

                foreach (DataRow dr in dtBillsInfo.Rows)
                {
                    command.Parameters["branch"].Value = dr["branch"];
                    command.Parameters["season"].Value = dr["season"];
                    command.Parameters["bills"].Value = dr["bills"];
                    command.Parameters["dishes"].Value = dr["dishes"];
                    command.Parameters["dishes_name"].Value = dr["dishes_name"];
                    command.Parameters["dishes_price"].Value = dr["dishes_price"];
                    command.Parameters["xcount"].Value = dr["xcount"];
                    command.Parameters["discount"].Value = dr["discount"];
                    command.Parameters["user_add"].Value = dr["user_add"];
                    command.Parameters["ref_status"].Value = dr["ref_status"];

                    command.ExecuteNonQuery();
                }

//----------------------------------------------------------------------------------------------------
                // Поидеи должно откатиться о изменения в обоих подключениях
                //clearLocalDB(seasonId, billsId);

                tx.Commit();
            }
            catch (Exception exc) { tx.Rollback(); throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

        }

        internal void clearLocalDB(string pSeasonId, string pBillsId)
        {
            SqlConnection lCon = null;
            SqlCommand lCommand = null;
            SqlTransaction lTx = null;

            lCon = new DBCon().getConnection("offline");
            lCommand = null;

            try
            {
                lCon.Open();

                lTx = con.BeginTransaction();
                lCommand = con.CreateCommand();
                lCommand.Transaction = lTx;

                lCommand.CommandText = "DELETE FROM season WHERE id in (" + pSeasonId + ") AND ref_status = 17";
                lCommand.ExecuteNonQuery();

                lCommand.CommandText = "DELETE FROM bills WHERE id in (" + pBillsId + ")";
                lCommand.ExecuteNonQuery();

                lCommand.CommandText = "DELETE FROM bills_info WHERE bills in (" + pBillsId + ")";
                lCommand.ExecuteNonQuery();

                lTx.Commit();
            }
            catch (Exception exc) { lTx.Rollback(); throw exc; }
            finally { if (lCon.State == ConnectionState.Open) lCon.Close(); }

        }
    }
}
