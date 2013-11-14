using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.docsform.db
{
    class DBAccess
    {
        private SqlConnection con = null;
        private SqlCommand command = null;

        DataTable dtResult;

        public DataTable getContactor(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name" +
                                        " FROM ref_contractor" +
                                        " WHERE ref_status = @ref_status" +
                                        " ORDER BY name";

                command.Parameters.Add("ref_status", SqlDbType.NVarChar).Value = 1;

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
