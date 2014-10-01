using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll.utilites.Properties;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

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
        public DataTable getStatus(string pDbType, int pRefStatusInfo)
        {
            string strSQL = string.Empty;
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                switch(pRefStatusInfo)
                {
                    case 0:
                        strSQL = "SELECT id, name, textcolor, backcolor, ref_status_info FROM ref_status ORDER BY name";
                        break;

                    default:
                        strSQL = "SELECT id, name, textcolor, backcolor, ref_status_info FROM ref_status "+
                                    " WHERE ref_status_info = " + pRefStatusInfo + 
                                    " ORDER BY name";
                        break;
                }

                command.CommandText = strSQL;

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

        public DataTable getCity(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name, ref_status FROM ref_city";
                
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

        public DataTable getUnitWhithDepot(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, branch, name, ref_status FROM unit"+
                                        " WHERE isDepot = 1";

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

        public DataTable getRefDocsParam(string pDbType)
        {
            DataTable dtResult = new DataTable();
            
            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, description" +
                                        " FROM ref_docs_param"+
                                        " ORDER BY name";

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

        public DataTable getRefPrinters(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name" +
                                        " FROM ref_printers" +
                                        " ORDER BY name";

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

        public DataTable getRefPrintersType(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name" +
                                        " FROM ref_printers_type" +
                                        " ORDER BY name";

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

        public DataTable getAccounts(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, group_I, group_I_I, group_II, name, xvid, xcount, xoffbalance" +
                                        " FROM ref_accounts" +
                                        " ORDER BY name";

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

        public DataTable getAccounts(string pDbType, int pGroup_I, int pGroup_I_I)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, group_I, group_I_I, group_II, name, xvid, xcount, xoffbalance" +
                                        " FROM ref_accounts" +
                                        " WHERE group_I = @group_I AND group_I_I = @group_I_I" +
                                        " ORDER BY name";

                command.Parameters.Add("group_I", SqlDbType.Int).Value = pGroup_I;
                command.Parameters.Add("group_I_I", SqlDbType.Int).Value = pGroup_I_I;

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

        public DataTable getAccounts(string pDbType, int pGroup_I, int pGroup_I_I, int pGroup_II)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, group_I, group_I_I, group_II, name, xvid, xcount, xoffbalance" +
                                        " FROM ref_accounts" +
                                        " WHERE group_I = @group_I AND group_I_I = @group_I_I AND group_II = @group_II" +
                                        " ORDER BY name";

                command.Parameters.Add("group_I", SqlDbType.Int).Value = pGroup_I;
                command.Parameters.Add("group_I_I", SqlDbType.Int).Value = pGroup_I_I;
                command.Parameters.Add("group_II", SqlDbType.Int).Value = pGroup_II;

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

        public DataTable getCurrency(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT rc.id AS IdCurrency, rc.code, rc.name, rc.description," +
                                            " ref_currency_type," +
                                            " rct.name AS ref_currency_type_name," +
                                            " rcc.id AS IdCourse," +
                                            " rcc.multiplicity," +
                                            " rcc.course" +
                                        " FROM ref_currency rc" +
                                        " INNER JOIN ref_currency_type rct ON rct.id = rc.ref_currency_type" +
                                        " INNER JOIN ref_currency_course rcc ON rcc.ref_currency = rc.id " +
                                            " AND rcc.date_start = (SELECT max(date_start) FROM ref_currency_course WHERE ref_currency = rc.id)" +
                                            " AND rcc.id = (SELECT max(id) FROM ref_currency_course WHERE ref_currency = rc.id)";

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

        public DataTable getDocsType(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, log_name, classPath, ref_status " +
                                        " FROM docs_type " +
                                        " WHERE ref_status = @ref_status " +
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

        public DataTable getPackageType(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name" +
                                        " FROM packages_type " +
                                        " ORDER BY name";

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

        public DataTable getTmcType(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name " +
                                        " FROM ref_tmc_type " +
                                        " ORDER BY name";

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

        public DataTable getItemsRaw(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name " +
                                        " FROM ref_items_raw " +
                                        " ORDER BY name";

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

        public DataTable getMeasure(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, name_short, rate, ref_status " +
                                        " FROM ref_measure " +
                                        " ORDER BY name";

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

        public DataTable getContactor(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

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

        public DataTable getCarte(string pDbType, int pBranch)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT c.id, c.code, c.name, c.branch, c.ref_status, stat.name as ref_status_name" +
                                        " FROM carte c" +
                                        " INNER JOIN ref_status stat ON stat.id = c.ref_status" +
                                        " WHERE c.branch = @pBranch";

                command.Parameters.Add("pBranch", SqlDbType.NVarChar).Value = pBranch;

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

        public DataTable getCarteDishesGroup(string pDbType, int pCarte)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT cdg.id, cdg.id_parent, cdg.name, cdg.ref_status, stat.name as ref_status_name" +
                                        " FROM carte_dishes_group cdg" +
                                        " INNER JOIN ref_status stat ON stat.id = cdg.ref_status" +
                                        " WHERE cdg.carte = @pCarte";

                command.Parameters.Add("pCarte", SqlDbType.NVarChar).Value = pCarte;

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

        public DataTable getCarteDishes(string pDbType, int pCarteDishesGroup)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT cd.id, cd.carte_dishes_group, cd.ref_dishes, cd.name, cd.price, cd.isvisible, cd.avalHall, cd.avalDelivery," +
                                            " cd.ref_printers_type, rpt.name as ref_printers_type_name," +
                                            " cd.ref_status, stat.name as ref_status_name, cd.minStep" +
                                        " FROM carte_dishes cd" +
                                        " INNER JOIN carte_dishes_group cdg ON cdg.id = cd.carte_dishes_group" +
                                        " INNER JOIN ref_status stat ON stat.id = cd.ref_status" +
                                        " INNER JOIN ref_printers_type rpt ON rpt.id = cd.ref_printers_type" +
                                        " WHERE cd.carte_dishes_group = @pCarteDishesGroup";

                command.Parameters.Add("pCarteDishesGroup", SqlDbType.NVarChar).Value = pCarteDishesGroup;

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

        public DataTable getRefDishes(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT rd.id, rd.code, rd.ref_dishes_group, rd.name, rd.price," +
                                            " rd.ref_printers_type, rpt.name as ref_printers_type_name," +
                                            " rd.ref_status, rs.name as ref_status_name, rd.minStep" +
                                        " FROM ref_dishes rd" +
                                        " INNER JOIN ref_printers_type rpt ON rpt.id = rd.ref_printers_type" +
                                        " INNER JOIN ref_status rs ON rs.id = rd.ref_status" +
                                        " WHERE rd.ref_status = @ref_status" +
                                        " ORDER BY rd.name";

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

        public DataTable getSitizen(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, ref_status" +
                                        " FROM ref_sitizen" +
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

        public DataTable getNationality(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, ref_status" +
                                        " FROM ref_nationality" +
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

        public DataTable getEducation(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, ref_status" +
                                        " FROM ref_education" +
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

        public DataTable getSpecialty(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, ref_status" +
                                        " FROM ref_specialty" +
                                        //" WHERE ref_status = @ref_status" +
                                        " ORDER BY name";

                //command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;

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

        public DataSet getOrganizationTree(string pDbType)
        {
            DataSet ds = new DataSet();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            SqlDataAdapter da;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, 0 as idparent, name FROM organization; " +
                                    " SELECT id, organization as idparent, name FROM branch; " +
                                    " SELECT id, branch as idparent, name FROM unit;";

                da = new SqlDataAdapter(command);

                da.Fill(ds);

                ds.Tables[0].TableName = "organization";
                ds.Tables[1].TableName = "branch";
                ds.Tables[2].TableName = "unit";

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return ds;
        }

        public DataTable getAllUserGroups(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name FROM groups " +
                                        " WHERE ref_status = @ref_status";

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

        public DataTable getEmailUser(string pDbType, int pUserId)
        {
            DataTable dtResult = new DataTable();
            
            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT users, email, login, pwd " +
                                        " FROM users_email " +
                                        " WHERE users = @users";

                command.Parameters.Add("users", SqlDbType.Int).Value = pUserId;

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

        public DataTable getPaymentType(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT 'false' as isChecked, id, name FROM ref_payment_type " +
                                        " WHERE ref_status = @ref_status";

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

        public DataTable getRefNotes(string pDbType, int pNotesType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new DBCon().getConnection(pDbType);
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, ref_notes_type, note, ref_status FROM ref_notes " +
                                        " WHERE ref_status = @ref_status AND ref_notes_type = @refNotesType";

                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;
                command.Parameters.Add("refNotesType", SqlDbType.Int).Value = pNotesType;

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
        /// Возвращает структуру топингов для блюда
        /// </summary>
        /// <param name="pDbType">режим подключаемой БД</param>
        /// <param name="pCarteDishes">id блюда</param>
        /// <returns></returns>
        public DataTable getToppingsGroups(string pDbType, int pCarteDishes)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, id_parent, carte_dishes, name, ref_status " +
                                        " FROM toppings_groups " +
                                        " WHERE carte_dishes = @carte_dishes" +
                                        " ORDER BY id, id_parent";

                command.Parameters.Add("carte_dishes", SqlDbType.Int).Value = pCarteDishes;

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
        /// Возвращает ВСЕ топинги которые доступны для блюда
        /// </summary>
        /// <param name="pDbType">режим подключаемой БД</param>
        /// <param name="pCarteDishes">id блюда</param>
        /// <returns></returns>
        public DataTable getTopingsCarteDishes(string pDbType, int pCarteDishes)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT tcd.id, tcd.toppings_groups, cd.id as carteDishes, cd.name, cd.price, tcd.isSelected" +
                                        " FROM toppings_carte_dishes tcd" +
                                        " INNER JOIN carte_dishes cd ON cd.id = tcd.carte_dishes" +
                                        " INNER JOIN toppings_groups tg ON tg.id = tcd.toppings_groups" +
                                        " WHERE tg.carte_dishes = @carteDishes";

                command.Parameters.Add("carteDishes", SqlDbType.Int).Value = pCarteDishes;

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

        public DataTable getTopingsCarteDishes_refuse(string pDbType, int pCarteDishes, int pBillsInfoId)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT tcd.id, tcd.toppings_groups, cd.id as carteDishes, cd.name, cd.price, [bit].isSelected " +
                                        " FROM toppings_carte_dishes tcd " +
                                        " INNER JOIN carte_dishes cd ON cd.id = tcd.carte_dishes " +
                                        " INNER JOIN toppings_groups tg ON tg.id = tcd.toppings_groups " +
                                        " INNER JOIN bills_info_toppings [bit] ON [bit].toppings_carte_dishes = tcd.id " +
                                        " INNER JOIN season_refuse sr ON sr.bills_info = [bit].bills_info " +
                                        " WHERE tg.carte_dishes = @carteDishes AND sr.id = @billsInfo";

                command.Parameters.Add("carteDishes", SqlDbType.Int).Value = pCarteDishes;
                command.Parameters.Add("billsInfo", SqlDbType.Int).Value = pBillsInfoId;

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

        public DataTable getTopingsCarteDishes_post(string pDbType, int pCarteDishes, int pBillsInfoId)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT tcd.id, tcd.toppings_groups, cd.id as carteDishes, cd.name, cd.price, " +
                                            " (SELECT isSelected FROM bills_info_toppings bita WHERE tcd.id = bita.toppings_carte_dishes AND bita.bills_info = @billsInfo ) AS isSelected " +
                                        " FROM toppings_carte_dishes tcd " +
                                        " INNER JOIN carte_dishes cd ON cd.id = tcd.carte_dishes " +
                                        " INNER JOIN toppings_groups tg ON tg.id = tcd.toppings_groups " +
                                        " WHERE tg.carte_dishes = @carteDishes";

                command.Parameters.Add("carteDishes", SqlDbType.Int).Value = pCarteDishes;
                command.Parameters.Add("billsInfo", SqlDbType.Int).Value = pBillsInfoId;

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

        public DataTable getDiscountUsers(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, fio, xkey, discount, ref_status, date_start, date_end, isExpDate, photo FROM usersDiscount";

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

        public DataTable getDiscountUsers(string pDbType, string pKey)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, fio, xkey, discount, ref_status, date_start, date_end, isExpDate, photo FROM usersDiscount WHERE xkey = @xkey";
                command.Parameters.Add("xkey", SqlDbType.NVarChar).Value = pKey;

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

        public DataTable getDeliveryClients(string pDbType, string pPhoneNumber)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT rdc.id, rdc.phone, rdc.fio, rdc.ref_city, rc.name as cityName, rdc.street, rdc.house, rdc.korp, rdc.app, rdc.porch, rdc.code, rdc.[floor] " + 
                                        " FROM ref_delivery_clients rdc" +
                                        " INNER JOIN ref_city rc ON rc.id = rdc.ref_city " +
                                        " WHERE rdc.phone = @pPhoneNumber";

                command.Parameters.Add("pPhoneNumber", SqlDbType.NVarChar).Value = pPhoneNumber;

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

        public DataTable getDeliveryDrivers(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name, description, ref_status = @refStatus FROM ref_delivery_drivers";

                command.Parameters.Add("refStatus", SqlDbType.Int).Value = 1;

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

        public DataTable getDeliveryTariff(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name, xprice, xtime, ref_status = @refStatus FROM ref_delivery_tariff";

                command.Parameters.Add("refStatus", SqlDbType.Int).Value = 1;

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

        public DataTable getDishesGroup(string pDbType)
        {
            DataTable dtResult = new DataTable();

            SqlConnection con = new SqlConnection();
            SqlCommand command = null;

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, id_parent, name, ref_status FROM ref_dishes_group WHERE ref_status = @refStatus";

                command.Parameters.Add("refStatus", SqlDbType.Int).Value = 1;

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

    public static class WriteLog
    {
        public static void write(string pString)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(GValues.prgLogFile))) Directory.CreateDirectory(Path.GetDirectoryName(GValues.prgLogFile));
                if (!File.Exists(GValues.prgLogFile))
                    File.Create(GValues.prgLogFile).Dispose();
                else
                {
                    FileInfo fi = new FileInfo(GValues.prgLogFile);
                    if (fi.Length >= 200000)
                    {
                        File.Delete(GValues.prgLogFile);
                        File.Create(GValues.prgLogFile).Dispose();
                    }

                }
                using (StreamWriter sw = new StreamWriter(GValues.prgLogFile, true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + pString);
                }
            }
            catch (Exception exc) { ;}
        }
    }

    public static class Crypto
    {
        public static string Encrypt(string toEncrypt, string securityKey)
        {
            var key = securityKey;
            var keyArray = Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.ANSIX923
            };

            var cTransform = tdes.CreateEncryptor();
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, string securityKey)
        {
            var key = securityKey;
            var keyArray = Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.ANSIX923
            };

            var cTransform = tdes.CreateDecryptor();
            var toEncryptArray = Convert.FromBase64String(cipherString);
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
    }

    public class Suppurt
    {
        public enum FormOpenModes { New, Edit, ReadOnly };

        public bool checkPrivileges(DTO_DBoard.UserACL[] pUserACL, int pUsersAclType)
        {
            foreach (com.sbs.dll.DTO_DBoard.UserACL uAcl in pUserACL)
            {
                if (uAcl.id == pUsersAclType) return true;
            }

            return false;
        }

        public bool checkPrivileges(List<int> pUserACL, int pUsersAclType)
        {
            foreach (int uAcl in pUserACL)
            {
                if (uAcl == pUsersAclType) return true;
            }

            return false;
        }
    }

    public class UserAuthorize
    {
        SqlConnection con;
        SqlCommand command;
        DataTable dtResult;

        public bool checkLogin(string pLogIn, string pPwd)
        {
            dtResult = new DataTable();

            try
            {
                con = new DBCon().getConnection(GValues.DBMode);

                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT u.id, u.tabn, u.fname, u.sname, u.lname, u.org, u.branch, u.unit, u.ref_post, u.login " +
                                        " FROM users u " +
                                        " INNER JOIN users_pwd up ON up.users = u.id WHERE u.login = @login AND up.pwd = @pwd";
                command.Parameters.Add("login", SqlDbType.NVarChar).Value = pLogIn;
                command.Parameters.Add("pwd", SqlDbType.NVarChar).Value = pPwd;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка обращения к базе данных", exc, SystemIcons.Error);
                return false;
            }

            if (dtResult.Rows.Count > 0)
            {
                UsersInfo.UserId = int.Parse(dtResult.Rows[0]["id"].ToString());
                UsersInfo.UserTabn = dtResult.Rows[0]["tabn"].ToString();
                UsersInfo.UserName = dtResult.Rows[0]["lname"].ToString() + " " + dtResult.Rows[0]["fname"].ToString() + " " + dtResult.Rows[0]["sname"].ToString();
                UsersInfo.PostId = int.Parse(dtResult.Rows[0]["ref_post"].ToString());
                UsersInfo.LogIn = dtResult.Rows[0]["login"].ToString();

                getUserInfoACL();

                return true;
            }

            return false;
        }

        private void getUserInfoACL()
        {
            dtResult = new DataTable();

            try
            {
                con = new DBCon().getConnection(GValues.DBMode);

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ua.user_acl_type, uat.name " +
                                        " FROM users u " +
                                        " INNER JOIN users_acl ua ON ua.users = u.id " +
                                        " INNER JOIN users_acl_type uat ON uat.id = ua.user_acl_type " +
                                        " WHERE u.id = @usersId " +
                                        "       UNION " +
                                        " SELECT ga.user_acl_type, uat.name " +
                                        " FROM users_groups u " +
                                        " INNER JOIN groups_acl ga ON ga.groups = u.groups " +
                                        " INNER JOIN users_acl_type uat ON uat.id = ga.user_acl_type " +
                                        " WHERE u.users = @usersId";

                command.Parameters.Add("usersId", SqlDbType.Int).Value = UsersInfo.UserId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            UsersInfo.Acl = new List<int>();

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                UsersInfo.Acl.Add((int)dtResult.Rows[i]["user_acl_type"]);
            }
        }
    }
    
    #region Печать RAW

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "sbs_rawPrint";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }

    #endregion
}
