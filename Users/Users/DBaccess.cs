using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.utilites;
using System.Drawing;

namespace com.sbs.gui.users
{
    class DBaccess
    {
        public DataTable getOrganipation(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT 0 AS id, '< все >' AS name " +
                                        " FROM organization " +
                                        " UNION " +
                                        " SELECT id, name FROM organization" +
                                        " WHERE ref_status = @ref_status"+
                                        " ORDER BY name";
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return dtResult; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return dtResult;
        }

        public DataTable getBranch(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT 0 AS id, '< все >' AS name, 0 AS organization" +
                                        " FROM branch " +
                                        " UNION " +
                                        " SELECT id, name, organization FROM branch" +
                                        " WHERE ref_status = @ref_status" +
                                        " ORDER BY name";
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return dtResult; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return dtResult;
        }

        public DataTable getUnit(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT 0 AS id, '< все >' AS name, 0 AS branch " +
                                        " FROM unit " +
                                        " UNION " +
                                        " SELECT id, name, branch FROM unit" +
                                        " WHERE ref_status = @ref_status" +
                                        " ORDER BY name";
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return dtResult; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return dtResult;
        }


    }
}
