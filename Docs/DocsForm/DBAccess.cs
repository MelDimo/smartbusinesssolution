using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.docsaction;

namespace com.sbs.gui.docsform.db
{
    class DBAccess
    {
        private SqlConnection con = null;
        private SqlCommand command = null;

        DataTable dtResult;

        public DataTable getTmcByType(string pDbType, int pTmcType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ri.id, ri.name, rm.name_short" +
                                        " FROM ref_items ri" +
                                        " INNER JOIN ref_measure rm ON rm.id = ri.ref_measure"+
                                        " WHERE ri.ref_tmc_type = @ref_tmc_type AND" +
                                            " ri.ref_status = @ref_status" +
                                        " ORDER BY ri.name";

                command.Parameters.Add("ref_tmc_type", SqlDbType.Int).Value = pTmcType;
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

        public DataTable getAdditionalCost(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT rac.id, rac.name, " +
                                            " rac.ref_accounts, ltrim(str(acc.group_II) + ' (' + acc.name + ')') AS ref_accounts_name, " +
                                            " rac.ref_contractor, rc.name AS ref_contractor_name " +
                                        " FROM ref_additionalCost rac " +
                                        " INNER JOIN ref_accounts acc ON acc.id = rac.ref_accounts " +
                                        " INNER JOIN ref_contractor rc ON rc.id = rac.ref_contractor";

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

        public DataTable getTMC_DOC(string pDbType, Packages pPackages)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT doc.id, rdp.name, dpv.value" +
                                        " FROM docs doc" +
                                        " INNER JOIN docs_param_value dpv ON dpv.docs = doc.id" +
                                        " INNER JOIN ref_docs_param rdp ON rdp.id = dpv.ref_docs_param" +
                                        " WHERE doc.packages = @packId"+
                                        " ORDER BY id";

                command.Parameters.Add("packId", SqlDbType.Int).Value = pPackages.id;

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
