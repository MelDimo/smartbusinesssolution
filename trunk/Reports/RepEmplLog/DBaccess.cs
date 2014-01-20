using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.report.repempllog
{
    class DBaccess
    {
        private DataTable dtResult = new DataTable();

        private SqlConnection con;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        internal DataTable getUsers(string pDbType, RepParam pRepParam)
        {
            dtResult = new DataTable();
            string branch = string.Empty;
            string groups = string.Empty;
            string sWhere = " WHERE ";

            con = new DBCon().getConnection(pDbType);

            foreach (int id in pRepParam.checkedBranch) branch += id + ",";
            foreach (int id in pRepParam.checkedUsersGroup) groups += id + ",";

            if (!branch.Equals(string.Empty))
            {
                sWhere += " br.id in (" + branch.TrimEnd(',') + ") AND";
            }
            if (!groups.Equals(string.Empty))
            {
                sWhere += " us_gr.groups in(" + groups.TrimEnd(',') + ") AND";
            }

            if (!sWhere.Equals(" WHERE "))
                sWhere = sWhere.TrimEnd('A', 'N', 'D');
            else
                sWhere = string.Empty;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT us.id, us.lname +' '+ us.fname +' '+ us.sname as fio" +
                                        " FROM users us " +
                                        " INNER JOIN branch br ON br.id = us.branch " +
                                        " INNER JOIN users_groups us_gr ON us_gr.users = us.id " +
                                        sWhere;

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

        internal DataTable prepareReport(string pDbType, RepParam pRepParam)
        {
            dtResult = new DataTable();
            string branch = string.Empty;
            string groups = string.Empty;
            string sWhere = " WHERE ";
            
            con = new DBCon().getConnection(pDbType);

            foreach (int id in pRepParam.checkedBranch) branch += id + ",";
            foreach (int id in pRepParam.checkedUsersGroup) groups += id + ",";

            if (!branch.Equals(string.Empty))
            {
                sWhere += " br.id in (" + branch.TrimEnd(',') + ") AND";
            }
            if (!groups.Equals(string.Empty))
            {
                sWhere += " us_gr.groups in(" + groups.TrimEnd(',') + ") AND";
            }

            if (!sWhere.Equals(" WHERE "))
                sWhere = sWhere.TrimEnd('A', 'N', 'D');
            else
                sWhere = string.Empty;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT us.id, us.lname +' '+ us.fname +' '+ us.sname as fio, tt.datetime_in, tt.datetime_out " +
                                        " FROM users us " +
                                        " INNER JOIN branch br ON br.id = us.branch " +
                                        " INNER JOIN users_groups us_gr ON us_gr.users = us.id " +
                                        " LEFT JOIN timeTracking tt ON tt.users = us.id " + (branch.Equals(string.Empty) ? "" : " tt.branch in (" + branch.TrimEnd(',') + ") ") +
                                        sWhere;

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
        public List<int> checkedUsersGroup { get; set; }
        public List<int> checkedUsers { get; set; }

        public RepParam()
        {
            checkedBranch = new List<int>();
            checkedUsersGroup = new List<int>();
            checkedUsers = new List<int>();
        }


    }
}
