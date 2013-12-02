using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.sbs.dll;
using System.Data.SqlClient;

namespace com.sbs.gui.docsjournal
{
    class DBAccess
    {
        private SqlConnection con = null;
        private SqlCommand command = null;

        DataTable dtResult;

        public DataTable getFilteredData(string pDbType, Filter pFilter)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "PackagesFilteredData_get";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@pPackType", SqlDbType.Int).Value = pFilter.packType;
                command.Parameters.Add("@pPackDate", SqlDbType.DateTime).Value = pFilter.packDate;
                command.Parameters.Add("@pUsers", SqlDbType.Int).Value = UsersInfo.UserId;
                command.Parameters.Add("@pPackStatus", SqlDbType.Int).Value = pFilter.packStatus;
                command.Parameters.Add("@pPackOwn", SqlDbType.Int).Value = pFilter.packOwn;

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
}
