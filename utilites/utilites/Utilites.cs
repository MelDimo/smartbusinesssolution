using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll.utilites.Properties;

namespace com.sbs.dll.utilites
{
    public static class uMessage
    {
        public static void Show(string pMsgText, Exception pExc, Icon pMsgIcon)
        {
            fMessage_Exception message = new fMessage_Exception(pMsgText, pExc, pMsgIcon);
            message.ShowDialog();
        }

        public static void Show(string pMsgText, Icon pMsgIcon)
        {
            fMessage message = new fMessage(pMsgText, pMsgIcon);
            message.ShowDialog();
        }
    }

    public class getReference
    {
        public DataTable getStatus(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name, textcolor, backcolor, ref_status_info FROM ref_status";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            dtResult.TableName = "refStatus";

            return dtResult;
        }

        public DataTable getOrganization(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
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
            dtResult.TableName = "Organization";
            return dtResult;
        }

        public DataTable getBranch(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, organization, name, ref_status FROM branch";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            dtResult.TableName = "Branch";

            return dtResult;
        }

        public DataTable getUnit(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, branch, name, ref_status FROM unit";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            dtResult.TableName = "Unit";

            return dtResult;
        }

        public DataTable getPost(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name FROM ref_post WHERE ref_status = 1";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            dtResult.TableName = "refPost";

            return dtResult;
        }
    }
}
