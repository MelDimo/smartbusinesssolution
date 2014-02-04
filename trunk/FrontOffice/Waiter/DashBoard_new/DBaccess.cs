using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.dashboard
{
    class DBaccess
    {
        private DataTable dtResult = new DataTable();

        private SqlConnection con;
        private SqlCommand command = null;
        private SqlTransaction tx = null;

        internal DataTable getAvaliableSeason(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT s.id, s.date_open, u.lname + ' ' + u.fname + ' ' + u.sname as fio, stat.name as status_name " +
                                        " FROM season s " +
                                        " INNER JOIN users u ON u.id = s.user_open" +
                                        " INNER JOIN ref_status stat ON stat.id = s.ref_status" +
                                        " WHERE s.branch = @branch AND s.ref_status = @ref_status";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 16;

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

    class SeasonBranch
    {
        public int id { get; set; }
        public int idManager { get; set; }
        public DateTime dateOpen { get; set; }
        public DateTime? dateClose { get; set; }
    }
    class SeasonWaiter
    {
        public int id { get; set; }
        public string idWaiter { get; set; }
        public DateTime dateOpen { get; set; }
        public DateTime? dateClose { get; set; }
    }
    class Manager
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    class Waiter
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    class Bill
    {
        public int id { get; set; }
    }
    class Dish
    {
        public int id { get; set; }
        public string name { get; set; }
    }


}
