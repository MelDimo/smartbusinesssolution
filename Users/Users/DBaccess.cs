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
        /// <summary>
        /// Возвращаем доступные организации
        /// </summary>
        /// <param name="pDbType">тип взаимодействия с базой</param>
        /// <returns></returns>
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

                command.CommandText = "SELECT id, name FROM organization" +
                                        " WHERE ref_status = @ref_status";
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

        /// <summary>
        /// Возвращаем доступные заведения
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

                command.CommandText = "SELECT id, name FROM branch" +
                                        " WHERE ref_status = @ref_status";
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
