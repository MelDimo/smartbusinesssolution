using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.linkdevice
{
    internal static class dbData
    {
        internal static DataTable dtSeason = new DataTable();
        internal static DataTable dtUsers = new DataTable();
    }

    public class Device
    {
        internal string id { get; set; }
        internal int season { get; set; }
        internal int uId { get; set; }
        internal string uFIO { get; set; }
    }

    internal class DBAccess
    {
        private DataTable dtResult;

        private SqlConnection con;
        private SqlCommand command;
        //private SqlTransaction tx;

        internal DataTable getDevices()
        {
            dtResult = new DataTable();

            try
            {
                con = new DBCon().getConnection(GValues.DBMode);
                
                con.Open();

                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT bdmw.ref_dmw, bdmw.season, u.id AS uId, isnull(u.lname + ' ' + u.fname + ' ' + u.sname, '') AS fio " +
                                        " FROM branch_dmw bdmw " +
                                        " LEFT JOIN users u ON u.id = bdmw.users " +
                                        " WHERE bdmw.branch = @branch";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;

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

        internal DataTable getBranchSeason()
        {
            dtResult = new DataTable();

            try
            {
                con = new DBCon().getConnection(GValues.DBMode);

                con.Open();

                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT id, '№ ' + ltrim(str(id))+ '; [' + convert(nvarchar(25), date_open, 120)+']' AS season" +
                                        " FROM season WHERE branch = @branch AND ref_status = @ref_status";

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

        internal DataTable getBranchUsers()
        {
            dtResult = new DataTable();
            dtResult = new DataTable();

            try
            {
                con = new DBCon().getConnection(GValues.DBMode);

                con.Open();

                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT id, isnull(lname + ' ' + fname + ' ' + sname, '') AS fio  FROM users WHERE branch = @branch";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;

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

        internal void saveDevice(Device pDevice)
        {
            try
            {
                con = new DBCon().getConnection(GValues.DBMode);

                con.Open();

                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE branch_dmw " + 
                                        " SET   season = @season, " + 
                                        "       users = @users " + 
                                        " WHERE ref_dmw = @ref_dmw AND branch = @branch";

                command.Parameters.Add("season", SqlDbType.Int).Value = pDevice.season;
                command.Parameters.Add("users", SqlDbType.Int).Value = pDevice.uId;
                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("ref_dmw", SqlDbType.Int).Value = pDevice.id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
    }
}
