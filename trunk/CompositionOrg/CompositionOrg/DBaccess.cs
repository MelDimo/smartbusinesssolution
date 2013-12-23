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
        SqlConnection con;
        SqlCommand command;
        SqlTransaction tx;

        DataTable dtResult;

        #region Organization

        public DataTable getOrganization(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT org.id, org.name, org.ref_status, refstat.name ref_status_name " +
                                        " FROM organization org " +
                                        " INNER JOIN ref_status refstat ON refstat.id = org.ref_status"+
                                        " ORDER BY org.name";
                
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
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO organization(name, ref_status) VALUES(@name, @ref_status)";
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pOrgDTO.Name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pOrgDTO.RefStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void editOrganization(string pDbType, CompOrgDTO.OrganizationDTO pOrgDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE organization SET name = @name, ref_status = @ref_status WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pOrgDTO.Id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pOrgDTO.Name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pOrgDTO.RefStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delOrganization(string pDbType, CompOrgDTO.OrganizationDTO pOrgDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM organization WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pOrgDTO.Id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
        
        #endregion

        #region Branch

        public DataTable getBranch(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT br.id, br.name, br.organization, br.ref_status, stat.name ref_status_name, br.ref_city, city.name ref_city_name," +
                                        " bi.countBill, bi.xopen, bi.xclose, bi.season_duration, bi.xIP, bi.xtable, bi.code " +
                                        " FROM branch AS br " +
                                        " LEFT JOIN branch_info bi ON bi.branch = br.id " +
                                        " INNER JOIN ref_status AS stat ON stat.id = br.ref_status " +
                                        " LEFT JOIN ref_city AS city ON city.id = br.ref_city "+
                                        " ORDER BY br.name ";

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

        public void addBranch(string pDbType, CompOrgDTO.BranchDTO pBranchDTO)
        {
            object ref_city = DBNull.Value;

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                
                tx = con.BeginTransaction();

                command = con.CreateCommand();

                command.Transaction = tx;

                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "Branch_add";

                command.Parameters.Add("pName", SqlDbType.NVarChar).Value = pBranchDTO.Name;
                command.Parameters.Add("pOrganization", SqlDbType.Int).Value = pBranchDTO.RefOrg;
                if(pBranchDTO.RefCity != 0) ref_city = pBranchDTO.RefCity;
                command.Parameters.Add("pRefCity", SqlDbType.Int).Value = ref_city;
                command.Parameters.Add("pRefStatus", SqlDbType.Int).Value = pBranchDTO.RefStatus;
                command.Parameters.Add("pOpen", SqlDbType.Time).Value = pBranchDTO.XOpen.ToString("HH:mm");
                command.Parameters.Add("pClose", SqlDbType.Time).Value = pBranchDTO.XClose.ToString("HH:mm");
                command.Parameters.Add("pDuration", SqlDbType.Int).Value = pBranchDTO.XDuration;
                command.Parameters.Add("pIP", SqlDbType.NVarChar).Value = pBranchDTO.Xip;
                command.Parameters.Add("pTable", SqlDbType.Int).Value = pBranchDTO.XTable;
                command.Parameters.Add("pCode", SqlDbType.Int).Value = pBranchDTO.Code;

                command.ExecuteNonQuery();

                tx.Commit();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }
        }

        public void editBranch(string pDbType, CompOrgDTO.BranchDTO pBranchDTO)
        {
            object ref_city = DBNull.Value;

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();

                tx = con.BeginTransaction();

                command = con.CreateCommand();

                command.Transaction = tx;

                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "Branch_edit";

                command.Parameters.Add("pId", SqlDbType.Int).Value = pBranchDTO.Id;
                command.Parameters.Add("pName", SqlDbType.NVarChar).Value = pBranchDTO.Name;
                command.Parameters.Add("pOrganization", SqlDbType.Int).Value = pBranchDTO.RefOrg;
                if (pBranchDTO.RefCity != 0) ref_city = pBranchDTO.RefCity;
                command.Parameters.Add("pRefCity", SqlDbType.Int).Value = ref_city;
                command.Parameters.Add("pRefStatus", SqlDbType.Int).Value = pBranchDTO.RefStatus;
                command.Parameters.Add("pOpen", SqlDbType.Time).Value = pBranchDTO.XOpen.ToString("HH:mm");
                command.Parameters.Add("pClose", SqlDbType.Time).Value = pBranchDTO.XClose.ToString("HH:mm");
                command.Parameters.Add("pDuration", SqlDbType.Int).Value = pBranchDTO.XDuration;
                command.Parameters.Add("pIP", SqlDbType.NVarChar).Value = pBranchDTO.Xip;
                command.Parameters.Add("pTable", SqlDbType.Int).Value = pBranchDTO.XTable;
                command.Parameters.Add("pCode", SqlDbType.Int).Value = pBranchDTO.Code;

                command.ExecuteNonQuery();

                tx.Commit();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }
        }

        public void delBranch(string pDbType, CompOrgDTO.BranchDTO pBranchDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM branch WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pBranchDTO.Id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion

        #region Unit

        public DataTable getUnit(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT un.id, un.name, un.ref_status, un.branch, stat.name ref_status_name, " +
                                            " ref_printers, ref_printers_type, isDepot, code" +
                                        " FROM unit un" +
                                        " INNER JOIN ref_status stat ON stat.id = un.ref_status" +
                                        " ORDER BY un.name";

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

        public void addUnit(string pDbType, CompOrgDTO.UnitDTO pUnitDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO unit(name, branch, ref_status, ref_printers, ref_printers_type, isDepot, code)" +
                                                    " VALUES(@name, @branch, @ref_status, @ref_printers, @ref_printers_type, @isDepot, @pCode )";
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pUnitDTO.Name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pUnitDTO.RefStatus;
                command.Parameters.Add("branch", SqlDbType.Int).Value = pUnitDTO.Branch;
                if (pUnitDTO.RefPrinters == 0) command.Parameters.Add("ref_printers", SqlDbType.Int).Value = DBNull.Value;
                else command.Parameters.Add("ref_printers", SqlDbType.Int).Value = pUnitDTO.RefPrinters;
                if (pUnitDTO.RefPrinters == 0) command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = DBNull.Value;
                else command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = pUnitDTO.RefPrintersType;
                command.Parameters.Add("isDepot", SqlDbType.Int).Value = pUnitDTO.isDepot;
                command.Parameters.Add("pCode", SqlDbType.Int).Value = pUnitDTO.Code;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void editUnit(string pDbType, CompOrgDTO.UnitDTO pUnitDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE unit SET name = @name, ref_status = @ref_status, branch = @branch, "+
                                        " ref_printers = @ref_printers, ref_printers_type = @ref_printers_type, isDepot = @isDepot, code = @pCode "+
                                        " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pUnitDTO.Id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pUnitDTO.Name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pUnitDTO.RefStatus;
                command.Parameters.Add("branch", SqlDbType.Int).Value = pUnitDTO.Branch;
                command.Parameters.Add("ref_printers", SqlDbType.Int).Value = pUnitDTO.RefPrinters;
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = pUnitDTO.RefPrintersType;
                command.Parameters.Add("isDepot", SqlDbType.Int).Value = pUnitDTO.isDepot;
                command.Parameters.Add("pCode", SqlDbType.Int).Value = pUnitDTO.Code;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delUnit(string pDbType, CompOrgDTO.UnitDTO pUnitDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM unit WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pUnitDTO.Id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion

        public DataTable getCity(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name, ref_status FROM ref_city";

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
