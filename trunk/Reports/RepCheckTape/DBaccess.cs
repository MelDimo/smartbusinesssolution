using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.sbs.dll;
using System.Data.SqlClient;

namespace com.sbs.gui.report.repchecktape
{
    class DBaccess
    {
        private DataTable dtResult = new DataTable();

        private SqlConnection con;
        private SqlCommand command = null;

        internal DataTable REP_CheckType(string pDbType, RepParam pRepParam)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "REP_CheckType";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pBranch", SqlDbType.DateTime).Value = pRepParam.branch;
                command.Parameters.Add("pDateStart", SqlDbType.DateTime).Value = pRepParam.dateStart;
                command.Parameters.Add("pDateEnd", SqlDbType.DateTime).Value = pRepParam.dateEnd;

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
        public int branch { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }

        RepParam()
        {
            branch = 0;
            dateStart = DateTime.Now;
            dateEnd = DateTime.Now;
        }
    }
}
