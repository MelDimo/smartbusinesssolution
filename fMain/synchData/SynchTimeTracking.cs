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
    class SynchTimeTracking
    {
        private SqlConnection conLocal = null;
        private SqlConnection conMain = null;
        private SqlCommand commandLocal = null;
        private SqlCommand commandMain = null;
        private SqlTransaction txLocal = null;
        private SqlTransaction txMain = null;

        DataTable dtTimeTracking;

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

            while (true)
            {
                sendTimeTrackingData();
                Thread.Sleep(300000);
            }
        }

        private void sendTimeTrackingData()
        {
            dtTimeTracking = new DataTable();

            #region -------------------------------------------------------- Сбор данных с локальных таблиц

            try
            {
                conLocal = new SqlConnection(GValues.localDBConStr);

                conLocal.Open();
                commandLocal = conLocal.CreateCommand();

                commandLocal.CommandText = " SELECT id, users, datetime_in, datetime_out, branch FROM timeTracking WHERE isUploaded = 0";
                using (SqlDataReader dr = commandLocal.ExecuteReader()) { dtTimeTracking.Load(dr); }

                conLocal.Close();

            }
            catch (Exception exc) { WriteLog.write(exc.Message + Environment.NewLine + exc.StackTrace); return; }
            finally { if (conLocal.State == ConnectionState.Open) conLocal.Close(); }

            #endregion

            #region -------------------------------------------------------- Вставка данных в головную базу и поднятие признака в локальной

            try
            {
                conMain = new SqlConnection(GValues.mainDBConStr);

                conMain.Open();

                commandMain = conMain.CreateCommand();
                txMain = conMain.BeginTransaction();

                commandMain.Connection = conMain;
                commandMain.Transaction = txMain;

                commandMain.CommandType = CommandType.StoredProcedure;
                commandMain.CommandText = "SynchData_Time";

                foreach (DataRow dr in dtTimeTracking.Rows)
                {
                    commandMain.Parameters.Clear();

                    commandMain.Parameters.Add("pUsers", SqlDbType.Int).Value = (int)dr["users"];
                    commandMain.Parameters.Add("pDateTime_IN", SqlDbType.DateTime).Value = dr["datetime_in"];
                    commandMain.Parameters.Add("pDateTime_OUT", SqlDbType.DateTime).Value = dr["datetime_out"];
                    commandMain.Parameters.Add("pBranch", SqlDbType.Int).Value = (int)dr["branch"];

                    commandMain.ExecuteNonQuery();
                }

                conLocal = new SqlConnection(GValues.localDBConStr);

                conLocal.Open();

                commandLocal = conLocal.CreateCommand();
                txLocal = conLocal.BeginTransaction();

                commandLocal.Connection = conLocal;
                commandLocal.Transaction = txLocal;

                commandLocal.CommandType = CommandType.Text;
                commandLocal.CommandText = "UPDATE timeTracking SET isUploaded = @pIsUploaded WHERE id = @id";

                foreach (DataRow dr in dtTimeTracking.Rows)
                {
                    if (dr["datetime_out"].Equals(DBNull.Value)) continue;

                    commandLocal.Parameters.Clear();

                    commandLocal.Parameters.Add("id", SqlDbType.Int).Value = (int)dr["id"];
                    commandLocal.Parameters.Add("pIsUploaded", SqlDbType.Int).Value = 1;

                    commandLocal.ExecuteNonQuery();
                }

                txLocal.Commit();
                conLocal.Close();

                txMain.Commit();
                conMain.Close();

                WriteLog.write("SynchTimeTracking: Ok.");

            }
            catch (Exception exc)
            {
                WriteLog.write(exc.Message + Environment.NewLine + exc.StackTrace);
            }

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
