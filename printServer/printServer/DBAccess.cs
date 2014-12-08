using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.sbs.dll;
using System.Data.SqlClient;

namespace printServer
{
    class DBAccess
    {
        private SqlConnection con;
        private SqlCommand command;
        //private SqlTransaction tx;

        DataTable dtResult;

        internal DataTable getWatingRecords(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            Console.WriteLine(string.Format("Обработка: {0}", DateTime.Now));
            try
            {
                con.Open();
                command = con.CreateCommand();


                command.Connection = con;

                command.CommandText = "printServer_getWatingRecords";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }

            return dtResult;
        }

        internal void updateRecords(string pDbType, List<dtoResult> lDtoResult)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.Connection = con;

                command.CommandText = "UPDATE printerTurn SET ref_status = @ref_status, retMessage = @retMessage " +
                                        " WHERE id = @id";

                command.CommandType = CommandType.Text;

                command.Parameters.Add("ref_status", SqlDbType.Int);
                command.Parameters.Add("retMessage", SqlDbType.NVarChar);
                command.Parameters.Add("id", SqlDbType.Int);

                foreach (dtoResult oDto in lDtoResult)
                {
                    command.Parameters["id"].Value = oDto.id;
                    command.Parameters["retMessage"].Value = string.Format("GetLastError: {0}", oDto.errCode);
                    if (oDto.errCode == 0) command.Parameters["ref_status"].Value = 37;
                    else command.Parameters["ref_status"].Value = 38;

                    command.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }
    }

    class dtoResult
    {
        public int id { get; set; }
        public int errCode { get; set; }
    }
}
