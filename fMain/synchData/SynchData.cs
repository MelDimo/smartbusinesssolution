using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using com.sbs.dll.utilites;
using System.Drawing;
using System.IO;

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
        DataTable dtToppings;
        DataTable dtBillsInfoDeliVery;
        DataTable dtRefDeliveryClients;

        Thread chkBillThread;

        public void run()
        {
            chkBillThread = new Thread(send2MainDB);
            chkBillThread.IsBackground = true;
            chkBillThread.Start();

            return;
        }

        public void send2MainDB()
        {
            //if (GValues.DBMode.Equals("online")) return; // Мы уже работаем в режиме онлайн

            while (GValues.isAlive)
            {
                try
                {
                    sendSeasonData();
                }
                catch (Exception exc)
                {
                    WriteLog.write(exc.Message + Environment.NewLine + exc.StackTrace);
                }
                Thread.Sleep(300000);
            }
        }

        public void sendSeasonData()
        {
            dtSeason = new DataTable();
            dtBills = new DataTable();
            dtBillsInfo = new DataTable();
            dtToppings = new DataTable();
            dtBillsInfoDeliVery = new DataTable();
            dtRefDeliveryClients = new DataTable();

            string billsArray = string.Empty;
            string DishArray = string.Empty;
            string refDeliveryClients = string.Empty;

            int xBranch = 0;

            #region -------------------------------------------------------- Сбор данных с локальных таблиц

            try
            {
                conLocal = new SqlConnection(GValues.localDBConStr);
                conLocal.Open();
                commandLocal = conLocal.CreateCommand();
                

                commandLocal.CommandText = " SELECT id, phone, fio, ref_city, street, house, korp, app, porch, code, [floor], isSynch FROM ref_delivery_clients WHERE isSynch = 0";
                using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtRefDeliveryClients.Load(dr); }

                commandLocal.CommandText = " SELECT id, code, branch, date_open, date_close, user_open, user_close, ref_status FROM season";
                using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtSeason.Load(dr); }

                commandLocal.CommandText = " SELECT id, branch, season, numb, xTable, date_open, date_close, " +
                                        " ref_payment_type, user_open, user_close, ref_notes, ref_status, sum, discount " +
                                        " FROM bills WHERE ref_status NOT IN(19, 20) AND isSynch = 0";
                using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtBills.Load(dr); }

                foreach(DataRow dr in dtBills.Rows)
                {
                    billsArray += dr["id"].ToString() + ",";
                }

                if (billsArray.Length > 0)  // Если есть подходящие счета берем по ним информацию. 
                {
                    billsArray = billsArray.Substring(0, billsArray.Length - 1);

                    commandLocal.CommandText = " SELECT id, branch, season, bills, carte_dishes, ref_dishes, dishes_name, dishes_price, xcount, discount, " +
                                                    "user_add, date_status, ref_notes, ref_status, usersDiscount " +
                                            " FROM bills_info WHERE bills IN (" + billsArray + ") AND ref_status = 24"; // 24 Обработано - 
                                                                                                                        //Позиция была отправлена на изготовление
                    using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtBillsInfo.Load(dr); }

                    commandLocal.CommandText = " SELECT id, branch, season, bills, ref_delivery_client, ref_driver, ref_delivery_tariff, discountNumber, xcomment " +
                                            " FROM bills_info_delivery WHERE bills IN (" + billsArray + ")";
                    using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtBillsInfoDeliVery.Load(dr); }
                }

                if (dtBillsInfo.Rows.Count > 0) // Смотрим топпинги по блюдам
                {
                    foreach(DataRow dr in dtBillsInfo.Rows) DishArray += dr["id"].ToString() + ",";

                    DishArray = DishArray.Substring(0, DishArray.Length - 1);

                    commandLocal.CommandText = " SELECT branch, season, bills, bills_info, toppings_carte_dishes, isSelected " +
                                                " FROM bills_info_toppings WHERE bills_info in (" + DishArray + ");";

                    using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtToppings.Load(dr); }
                }

                conLocal.Close();

            }
            catch (Exception exc) { WriteLog.write(exc.Message + Environment.NewLine + exc.StackTrace); return; }
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

                commandMain.CommandType = CommandType.StoredProcedure;
                commandMain.CommandText = "SynchData_Season";

                foreach (DataRow dr in dtSeason.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("season_id", SqlDbType.Int).Value = (int)dr["id"];
                    commandMain.Parameters.Add("code", SqlDbType.Int).Value = (int)dr["code"];
                    xBranch = (int)dr["branch"];
                    commandMain.Parameters.Add("branch", SqlDbType.Int).Value = xBranch;
                    commandMain.Parameters.Add("dateOpen", SqlDbType.DateTime).Value = dr["date_open"];
                    commandMain.Parameters.Add("dateClose", SqlDbType.DateTime).Value = dr["date_close"];
                    commandMain.Parameters.Add("userOpen", SqlDbType.Int).Value = dr["user_open"];
                    commandMain.Parameters.Add("userClose", SqlDbType.Int).Value = dr["user_close"];
                    commandMain.Parameters.Add("refStatus", SqlDbType.Int).Value = dr["ref_status"];

                    commandMain.ExecuteNonQuery();
                }

                commandMain.CommandType = CommandType.Text;
                commandMain.CommandText = "INSERT INTO bills_all(branch,        season,     bills_id,           numb,       xTable, " +
                                                                "date_open,     date_close, ref_payment_type,   user_open,  user_close," +
                                                                "ref_notes,     ref_status, [sum],              discount)" +
                                                        "VALUES(@branch,        @season,    @bills_id,          @numb,      @xTable," +
                                                               "@date_open,     @date_close,@ref_payment_type,  @user_open, @user_close," +
                                                                "@ref_notes,    @ref_status,@sum,               @discount);";
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
                    commandMain.Parameters.Add("ref_payment_type", SqlDbType.Int).Value = DBNull.Value == dr["ref_payment_type"] ? 0 : (int)dr["ref_payment_type"];
                    commandMain.Parameters.Add("user_open", SqlDbType.Int).Value = (int)dr["user_open"];
                    commandMain.Parameters.Add("user_close", SqlDbType.Int).Value = DBNull.Value == dr["user_close"] ? 0 : (int)dr["user_close"];
                    commandMain.Parameters.Add("ref_notes", SqlDbType.Int).Value = dr["ref_notes"];
                    commandMain.Parameters.Add("ref_status", SqlDbType.Int).Value = (int)dr["ref_status"];
                    commandMain.Parameters.Add("sum", SqlDbType.Decimal).Value = DBNull.Value == dr["sum"] ? 0 : (decimal)dr["sum"];
                    commandMain.Parameters.Add("discount", SqlDbType.Decimal).Value = DBNull.Value == dr["discount"] ? 0 : (decimal)dr["discount"];


                    commandMain.ExecuteNonQuery();
                }

                commandMain.CommandText = "INSERT INTO bills_info_all(bills_info,    branch,     season,     bills,          carte_dishes,  ref_dishes,     dishes_name,    dishes_price," +
                                                                    "xcount,        discount,   user_add,   date_status,    ref_notes,      ref_status,     usersDiscount)" +
                                                           " VALUES(@bills_info,    @branch,    @season,    @bills,         @carte_dishes,  @ref_dishes,    @dishes_name,   @dishes_price," +
                                                                    "@xcount,       @discount,  @user_add,  @date_status,   @ref_notes,     @ref_status,    @usersDiscount)";
                foreach (DataRow dr in dtBillsInfo.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("bills_info", SqlDbType.Int).Value = (int)dr["id"];
                    commandMain.Parameters.Add("branch", SqlDbType.Int).Value = (int)dr["branch"];
                    commandMain.Parameters.Add("season", SqlDbType.Int).Value = (int)dr["season"];
                    commandMain.Parameters.Add("bills", SqlDbType.Int).Value = (int)dr["bills"];
                    commandMain.Parameters.Add("ref_dishes", SqlDbType.Int).Value = (int)dr["ref_dishes"];
                    commandMain.Parameters.Add("carte_dishes", SqlDbType.Int).Value = (int)dr["carte_dishes"];
                    commandMain.Parameters.Add("dishes_name", SqlDbType.NVarChar).Value = dr["dishes_name"].ToString();
                    commandMain.Parameters.Add("dishes_price", SqlDbType.Decimal).Value = (decimal)dr["dishes_price"];
                    commandMain.Parameters.Add("xcount", SqlDbType.Decimal).Value = (decimal)dr["xcount"];
                    commandMain.Parameters.Add("discount", SqlDbType.Decimal).Value = (decimal)dr["discount"];
                    commandMain.Parameters.Add("user_add", SqlDbType.Int).Value = (int)dr["user_add"];
                    commandMain.Parameters.Add("date_status", SqlDbType.DateTime).Value = dr["date_status"];
                    commandMain.Parameters.Add("ref_notes", SqlDbType.Int).Value = dr["ref_notes"];
                    commandMain.Parameters.Add("ref_status", SqlDbType.Int).Value = (int)dr["ref_status"];
                    commandMain.Parameters.Add("usersDiscount", SqlDbType.Int).Value = (int)dr["usersDiscount"];

                    commandMain.ExecuteNonQuery();
                }

                commandMain.CommandText = "INSERT INTO bills_info_delivery_all(bills_info_delivery, branch,     season,     bills,  ref_delivery_client,    ref_driver,     ref_delivery_tariff,    discountNumber, xcomment) " +
                                                                "       VALUES (@id,                @branch,    @season,    @bills, @ref_delivery_client,   @ref_driver,    @ref_delivery_tariff,   @discountNumber, @xcomment)";

                foreach (DataRow dr in dtBillsInfoDeliVery.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("id", SqlDbType.Int).Value = (int)dr["id"];
                    commandMain.Parameters.Add("branch", SqlDbType.Int).Value = (int)dr["branch"];
                    commandMain.Parameters.Add("season", SqlDbType.Int).Value = (int)dr["season"];
                    commandMain.Parameters.Add("bills", SqlDbType.Int).Value = (int)dr["bills"];
                    commandMain.Parameters.Add("ref_delivery_client", SqlDbType.NVarChar).Value = dr["ref_delivery_client"].ToString();
                    commandMain.Parameters.Add("ref_driver", SqlDbType.Int).Value = (int)dr["ref_driver"];
                    commandMain.Parameters.Add("ref_delivery_tariff", SqlDbType.Int).Value = (int)dr["ref_delivery_tariff"];
                    commandMain.Parameters.Add("discountNumber", SqlDbType.NVarChar).Value = dr["discountNumber"].ToString();
                    commandMain.Parameters.Add("xcomment", SqlDbType.NVarChar).Value = dr["xcomment"].ToString();

                    commandMain.ExecuteNonQuery();
                }

                commandMain.CommandText = "INSERT INTO ref_delivery_clients_all(id,  phone,  fio,    ref_city,   street,     house,  korp,   app,    porch,  code,   [floor])" +
                                               "                         VALUES(@id, @phone, @fio,   @ref_city,  @street,    @house, @korp,  @app,   @porch, @code,  @floor)";
                foreach (DataRow dr in dtRefDeliveryClients.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("id", SqlDbType.NVarChar).Value = dr["id"].ToString();
                    commandMain.Parameters.Add("phone", SqlDbType.NVarChar).Value = dr["phone"].ToString();
                    commandMain.Parameters.Add("fio", SqlDbType.NVarChar).Value = dr["fio"].ToString();
                    commandMain.Parameters.Add("ref_city", SqlDbType.Int).Value = (int)dr["ref_city"];
                    commandMain.Parameters.Add("street", SqlDbType.NVarChar).Value = dr["street"].ToString();
                    commandMain.Parameters.Add("house", SqlDbType.NVarChar).Value = dr["house"].ToString();
                    commandMain.Parameters.Add("korp", SqlDbType.NVarChar).Value = dr["korp"].ToString();
                    commandMain.Parameters.Add("app", SqlDbType.NVarChar).Value = dr["app"].ToString();
                    commandMain.Parameters.Add("porch", SqlDbType.NVarChar).Value = dr["porch"].ToString();
                    commandMain.Parameters.Add("code", SqlDbType.NVarChar).Value = dr["code"].ToString();
                    commandMain.Parameters.Add("floor", SqlDbType.NVarChar).Value = dr["floor"].ToString();

                    commandMain.ExecuteNonQuery();
                }

                commandMain.CommandText = "INSERT INTO bills_info_toppings_all(branch,  season,     bills,  bills_info,     toppings_carte_dishes,  isSelected) " +
                                                                    " VALUES( @branch,  @season,    @bills, @bills_info,    @toppings_carte_dishes, @isSelected)";

                foreach (DataRow dr in dtToppings.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("branch", SqlDbType.Int).Value = (int)dr["branch"];
                    commandMain.Parameters.Add("season", SqlDbType.Int).Value = (int)dr["season"];
                    commandMain.Parameters.Add("bills", SqlDbType.Int).Value = (int)dr["bills"];
                    commandMain.Parameters.Add("bills_info", SqlDbType.Int).Value = (int)dr["bills_info"];
                    commandMain.Parameters.Add("toppings_carte_dishes", SqlDbType.Int).Value = (int)dr["toppings_carte_dishes"];
                    commandMain.Parameters.Add("isSelected", SqlDbType.Int).Value = (int)dr["isSelected"];

                    commandMain.ExecuteNonQuery();
                }

                conLocal = new SqlConnection(GValues.localDBConStr);

                conLocal.Open();

                commandLocal = conLocal.CreateCommand();
                txLocal = conLocal.BeginTransaction();

                commandLocal.Connection = conLocal;
                commandLocal.Transaction = txLocal;

                if (!billsArray.Equals(string.Empty))
                {
                    commandLocal.CommandText = "DELETE FROM bills_info WHERE bills in(" + billsArray + ")";
                    commandLocal.ExecuteNonQuery();
                    commandLocal.CommandText = "DELETE FROM bills_info_toppings WHERE bills in(" + billsArray + ")";
                    commandLocal.ExecuteNonQuery();
                    commandLocal.CommandText = "UPDATE bills SET isSynch = 1 WHERE id in(" + billsArray + ")";
                    commandLocal.ExecuteNonQuery();
                }

                commandLocal.CommandText = "UPDATE ref_delivery_clients SET isSynch = 1 WHERE id = @id";
                foreach (DataRow dr in dtRefDeliveryClients.Rows)
                {
                    commandLocal.Parameters.Clear();
                    commandLocal.Parameters.Add("id", SqlDbType.NVarChar).Value = dr["id"].ToString();
                    commandLocal.ExecuteNonQuery();
                }
                commandLocal.Parameters.Clear();

                commandLocal.CommandText = "DELETE FROM season_waiter WHERE ref_status != 16"; // Смена не открыта
                commandLocal.ExecuteNonQuery();

                commandLocal.CommandText = "DELETE FROM season WHERE ref_status != 16"; // Смена не открыта
                commandLocal.ExecuteNonQuery();

                commandMain.CommandText = "INSERT INTO SynchData_log(branch) VALUES (@branch)";
                commandMain.Parameters.Clear();
                commandMain.Parameters.Add("branch", SqlDbType.Int).Value = xBranch;
                commandMain.ExecuteNonQuery();

                txLocal.Commit();
                conLocal.Close();

                txMain.Commit();
                conMain.Close();

                WriteLog.write("SynchData: Ok.");
            }
            catch (Exception exc) 
            {
                txLocal.Rollback();
                txMain.Rollback();
                WriteLog.write(exc.Message + Environment.NewLine + exc.StackTrace);
            }

            finally 
            {
                if (conLocal.State == ConnectionState.Open)
                {
                    conLocal.Close();
                }
                if (conMain.State == ConnectionState.Open)
                {
                    conMain.Close();
                }
            }

            #endregion
        }
    }
}
