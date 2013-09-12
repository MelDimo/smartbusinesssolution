using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.dto;

namespace com.sbs.gui.compositionorg
{
    class DBaccess
    {
        /// <summary>
        /// Возвращаем все организации
        /// </summary>
        /// <param name="pDbType">тип взаимодействия с базой</param>
        /// <returns></returns>
        public DataTable getOrganization(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name, ref_status FROM organization";
                
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

        public void addOrganization(string pDbType, CompOrgDTO.OrganizationDTO pOrgDTO)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO organization(name, ref_status) VALUES(@name, @ref_status)";
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pOrgDTO.Name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pOrgDTO.RefStatus;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        /// <summary>
        /// Возвращаем все заведения
        /// </summary>
        /// <param name="pDbType">тип взаимодействия с базой</param>
        /// <returns></returns>
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

                command.CommandText = "SELECT id, name, ref_status FROM branch";

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

        /// <summary>
        /// Возвращаем все подразделения
        /// </summary>
        /// <param name="pDbType"></param>
        /// <returns></returns>
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

                command.CommandText = "SELECT id, name, ref_status FROM unit";

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
