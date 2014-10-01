using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.report
{
    class DBaccess
    {
        private DataTable dtResult = new DataTable();

        private SqlConnection con;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        internal DataTable getEmplList(string pDbType, string pUnitIds)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT us.tabn, us.lname + ' ' + us.fname + ' ' + us.sname as fio, org.name as org, br.name as branch, un.name as unit, post.name as post" +
                                        " FROM users us " +
                                        " INNER JOIN unit un ON un.id = us.unit " +
                                        " INNER JOIN branch br ON br.id = un.branch " +
                                        " INNER JOIN organization org ON org.id = br.organization " +
                                        " LEFT JOIN ref_post post ON post.id = us.ref_post " +
                                        " WHERE us.unit in (" + pUnitIds + ")";

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
            string sId = string.Empty;
            string sWhere = string.Empty;

            con = new DBCon().getConnection(pDbType);

            if (pRepParam.checkedUnit == null) pRepParam.checkedUnit = new List<int>();
            

            foreach (int id in pRepParam.checkedUnit)
            {
                sId += id + ",";
            }

            if (sId.Length > 0)sWhere = " WHERE us.unit in (" + sId.TrimEnd(',') + ") ";

            if (pRepParam.checkUvol == 1) sWhere += " AND us.ref_status IN (12, 13, 15)";
            else sWhere += " AND us.ref_status IN (12, 13 )";

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT us.tabn, us.lname +' '+ us.fname +' '+ us.sname as fio, org.name as org, br.name as branch, un.name as unit, post.name as post " +
                                        " FROM users us " +
                                        " INNER JOIN ref_post post ON post.id = us.ref_post " +
                                        " INNER JOIN organization org ON org.id = us.org " +
                                        " INNER JOIN branch br ON br.id = us.branch " +
                                        " INNER JOIN unit un ON un.id = us.unit " + sWhere;
                                        //" WHERE us.unit in (" + sId.TrimEnd(',') + ") ";

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
        public List<int> checkedUnit { get; set; }
        public int checkUvol { get; set; }
    }
}
