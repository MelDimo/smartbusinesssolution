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
                        strSQL = "SELECT id, name, textcolor, backcolor, ref_status_info FROM ref_status";
                        break;

                    default:
                        strSQL = "SELECT id, name, textcolor, backcolor, ref_status_info FROM ref_status "+
                                    " WHERE ref_status_info = " + pRefStatusInfo;
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

                command.CommandText = " SELECT cd.id, cd.carte_dishes_group, cd.ref_dishes, cd.name, cd.price, cd.isvisible, " +
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

                command.CommandText = " SELECT rd.id, rd.code, rd.name, rd.price," +
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
    }

    public static class WriteLog
    {
        public static void write(string pString)
        {
            if (!Directory.Exists(Path.GetDirectoryName(GValues.prgLogFile))) Directory.CreateDirectory(Path.GetDirectoryName(GValues.prgLogFile));
            if (!File.Exists(GValues.prgLogFile)) File.Create(GValues.prgLogFile).Dispose();

            using (StreamWriter sw = new StreamWriter(GValues.prgLogFile, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + pString);
            }
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
        public bool checkPrivileges(com.sbs.dll.DTO_DBoard.UserACL[] pUserACL, int pUsersAclType)
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
}
