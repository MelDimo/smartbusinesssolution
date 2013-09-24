using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.prepack
{
    class DBaccess
    {
        private SqlConnection con = null;
        private SqlCommand command = null;
        private SqlTransaction tx = null;

        private DataTable dtResult = new DataTable();

        public DataTable getPrepack(string pDbType)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ppack.id, ppack.code, ppack.name, ppack.unit AS UNIT " +
                                        " FROM prepack ppack" +
                                        " WHERE ref_status = @ref_status" +
                                        " ORDER BY name";
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;
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
