using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using com.sbs.dll.utilites;
using System.Drawing;

namespace com.sbs.dll.synchdata
{
    class SynchData
    {
        private SqlConnection conLocal = null;
        private SqlConnection conMain = null;
        private SqlCommand commandLocal = null;
        private SqlCommand commandMain = null;
        private SqlTransaction txLocal = null;
        private SqlTransaction txMain = null;

        DataTable dtSeason;
        DataTable dtBills;
        DataTable dtBillsInfo;

        public void send2MainDB()
        {
            if (GValues.DBMode.Equals("online")) return; // Мы уже работаем в режиме онлайн

            //while (true)
            //{
                sendSeasonData();
                //Thread.Sleep(300000);
            //}
        }

        private void sendSeasonData()
        {
            dtSeason = new DataTable();
            dtBills = new DataTable();
            dtBillsInfo = new DataTable();

            string billsArray = string.Empty;

            #region -------------------------------------------------------- Сбор данных с локальных таблиц

            try
            {
                conLocal = new SqlConnection(GValues.localDBConStr);

                conLocal.Open();
                commandLocal = conLocal.CreateCommand();

                commandLocal.CommandText = " SELECT id, code, branch, date_open, date_close, user_open, user_close, ref_status FROM season";
                using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtSeason.Load(dr); }

                commandLocal.CommandText = " SELECT id, branch, season, numb, xTable, date_open, date_close, " +
                                        "ref_payment_type, user_open, user_close, ref_notes, ref_status, sum " +
                                        " FROM bills WHERE ref_status NOT IN(19, 20) ";
                using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtBills.Load(dr); }

                foreach(DataRow dr in dtBills.Rows)
                {
                    billsArray += dr["id"].ToString() + ",";
                }

                if (billsArray.Length > 0)  // Если есть подходящие счета берем по ним информацию.
                {
                    billsArray = billsArray.Substring(0, billsArray.Length - 1);

                    commandLocal.CommandText = " SELECT id, branch, season, bills, carte_dishes, dishes_name, dishes_price, xcount, discount, " +
                                                    "user_add, date_status, ref_notes, ref_status " +
                                            " FROM bills_info WHERE bills IN (" + billsArray + ")";

                    using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtBillsInfo.Load(dr); }
                }

                conLocal.Close();

            }
            catch (Exception exc) { uMessage.Show(exc.Message, SystemIcons.Information); }
            finally { if (conLocal.State == ConnectionState.Open) conLocal.Close(); }

            #endregion

            #region -------------------------------------------------------- Вставка данных в головную базу и удаление из локальной

            try
            {
                conMain = new SqlConnection(GValues.mainDBConStr);

                conMain.Open();

                commandMain = conMain.CreateCommand();
                txMain = conMain.BeginTransaction();

                commandMain.Connection = conMain;
                commandMain.Transaction = txMain;

                commandMain.CommandText = "INSERT INTO season_all(season_id,    code,   branch,     date_open, date_close, user_open,   user_close, ref_status)" +
                                                    "VALUES(@season_id,     @code,  @branch,    @date_open,@date_close,@user_open,  @user_close,@ref_status)";
                foreach (DataRow dr in dtSeason.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("season_id", SqlDbType.Int).Value = (int)dr["id"];
                    commandMain.Parameters.Add("code", SqlDbType.Int).Value = (int)dr["code"];
                    commandMain.Parameters.Add("branch", SqlDbType.Int).Value = (int)dr["branch"];
                    commandMain.Parameters.Add("date_open", SqlDbType.DateTime).Value = dr["date_open"];
                    commandMain.Parameters.Add("date_close", SqlDbType.DateTime).Value = dr["date_close"];
                    commandMain.Parameters.Add("user_open", SqlDbType.Int).Value = dr["user_open"];
                    commandMain.Parameters.Add("user_close", SqlDbType.Int).Value = dr["user_close"];
                    commandMain.Parameters.Add("ref_status", SqlDbType.Int).Value = dr["ref_status"];

                    commandMain.ExecuteNonQuery();
                }

                commandMain.CommandText = "INSERT INTO bills_all(branch,        season,     bills_id,           numb,       xTable, " +
                                                                "date_open,     date_close, ref_payment_type,   user_open,  user_close," +
                                                                "ref_notes,     ref_status, [sum])" +
                                                        "VALUES(@branch,        @season,    @bills_id,          @numb,      @xTable," +
                                                               "@date_open,     @date_close,@ref_payment_type,  @user_open, @user_close," +
                                                                "@ref_notes,    @ref_status,@sum);";
                foreach(DataRow dr in dtBills.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("branch", SqlDbType.Int).Value = (int)dr["branch"];
                    commandMain.Parameters.Add("season", SqlDbType.Int).Value = (int)dr["season"];
                    commandMain.Parameters.Add("bills_id", SqlDbType.Int).Value = (int)dr["id"];
                    commandMain.Parameters.Add("numb", SqlDbType.Int).Value = (int)dr["numb"];
                    commandMain.Parameters.Add("xTable", SqlDbType.Int).Value = (int)dr["xTable"];
                    commandMain.Parameters.Add("date_open", SqlDbType.DateTime).Value = dr["date_open"];
                    commandMain.Parameters.Add("date_close", SqlDbType.DateTime).Value = dr["date_close"];
                    commandMain.Parameters.Add("ref_payment_type", SqlDbType.Int).Value = (int)dr["ref_payment_type"];
                    commandMain.Parameters.Add("user_open", SqlDbType.Int).Value = (int)dr["user_open"];
                    commandMain.Parameters.Add("user_close", SqlDbType.Int).Value = (int)dr["user_close"];
                    commandMain.Parameters.Add("ref_notes", SqlDbType.Int).Value = dr["ref_notes"];
                    commandMain.Parameters.Add("ref_status", SqlDbType.Int).Value = (int)dr["ref_status"];
                    commandMain.Parameters.Add("sum", SqlDbType.Decimal).Value = (decimal)dr["sum"];


                    commandMain.ExecuteNonQuery();
                }

                commandMain.CommandText = "INSERT INTO bills_info_all(bills_info,    branch,     season,     bills,          carte_dishes,   dishes_name,    dishes_price," +
                                                                "xcount,        discount,   user_add,   date_status,    ref_notes,      ref_status)" +
                                                       " VALUES(@bills_info,    @branch,    @season,    @bills,         @carte_dishes,  @dishes_name,   @dishes_price," +
                                                                "@xcount,       @discount,  @user_add,  @date_status,   @ref_notes,     @ref_status)";
                foreach (DataRow dr in dtBillsInfo.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("bills_info", SqlDbType.Int).Value = (int)dr["id"];
                    commandMain.Parameters.Add("branch", SqlDbType.Int).Value = (int)dr["branch"];
                    commandMain.Parameters.Add("season", SqlDbType.Int).Value = (int)dr["season"];
                    commandMain.Parameters.Add("bills", SqlDbType.Int).Value = (int)dr["bills"];
                    commandMain.Parameters.Add("carte_dishes", SqlDbType.Int).Value = (int)dr["carte_dishes"];
                    commandMain.Parameters.Add("dishes_name", SqlDbType.NVarChar).Value = dr["dishes_name"].ToString();
                    commandMain.Parameters.Add("dishes_price", SqlDbType.Decimal).Value = (decimal)dr["dishes_price"];
                    commandMain.Parameters.Add("xcount", SqlDbType.Decimal).Value = (decimal)dr["xcount"];
                    commandMain.Parameters.Add("discount", SqlDbType.Decimal).Value = (decimal)dr["discount"];
                    commandMain.Parameters.Add("user_add", SqlDbType.Int).Value = (int)dr["user_add"];
                    commandMain.Parameters.Add("date_status", SqlDbType.DateTime).Value = dr["date_status"];
                    commandMain.Parameters.Add("ref_notes", SqlDbType.Int).Value = dr["ref_notes"];
                    commandMain.Parameters.Add("ref_status", SqlDbType.Int).Value = (int)dr["ref_status"];

                    commandMain.ExecuteNonQuery();
                }

                conLocal = new SqlConnection(GValues.localDBConStr);

                conLocal.Open();

                commandLocal = conLocal.CreateCommand();
                txLocal = conLocal.BeginTransaction();

                commandLocal.Connection = conLocal;
                commandLocal.Transaction = txLocal;

                //commandLocal.CommandText = "DELETE FROM bills WHERE id in(" + billsArray + ")";
                //commandLocal.ExecuteNonQuery();
                //commandLocal.CommandText = "DELETE FROM bills_info WHERE bills in(" + billsArray + ")";
                //commandLocal.ExecuteNonQuery();

                txLocal.Commit();
                conLocal.Close();

                txMain.Commit();
                conMain.Close();
                
            }
            catch (Exception exc) { }
            finally 
            {
                if (conLocal.State == ConnectionState.Open)
                {
                    txLocal.Rollback();
                    conLocal.Close();
                }
                if (conMain.State == ConnectionState.Open)
                {
                    txMain.Rollback();
                    conMain.Close();
                }

            }

            #endregion
        }
    }
}
