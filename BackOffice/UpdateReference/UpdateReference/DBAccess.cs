using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.updatereference
{
    public class DBAccess
    {
        SqlConnection con;
        SqlCommand command;
        DataTable dtResult;

        DTO_Updater.Branch oBranch;

        public DTO_Updater.Branch getBranchInfo(string pDbType, int pBranchId)
        {
            oBranch = new DTO_Updater.Branch();

            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT branch, replace(xIp,' ','') AS ip, srvName, dbName FROM branch_info WHERE branch = @branch";
                command.Parameters.Add("branch", SqlDbType.Int).Value = pBranchId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                if (dtResult.Rows.Count != 1 )
                {
                    throw new Exception("У данного заведения отсутствуют дополнительные параметры.");
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            oBranch.id = dtResult.Rows[0]["branch"].ToString();
            oBranch.name = string.Empty;
            oBranch.ip = dtResult.Rows[0]["ip"].ToString();
            oBranch.srvName = dtResult.Rows[0]["srvName"].ToString();
            oBranch.dbName = dtResult.Rows[0]["dbName"].ToString();
            oBranch.updateStatus = 0;

            return oBranch;
        }

        public DataTable getUpdateCategory(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name, script FROM updateCategory";

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

        public void executeScript(string pDbType, string pScript)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = pScript;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
    }
}
