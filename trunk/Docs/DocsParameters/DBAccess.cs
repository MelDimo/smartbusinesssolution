using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll;

namespace com.sbs.gui.docs
{
    class DBAccess
    {
        private SqlConnection con = null;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        private DataTable dtResult;

        #region------------------------------------------------------------------------ docsType

        public DataTable getDocsType(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT dtype.id, dtype.name, dtype.ref_status, stat.name AS ref_status_name, dtype.log_name" +
                                        " FROM docs_type dtype" +
                                        " INNER JOIN ref_status stat ON stat.id = dtype.ref_status" +
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

        public void addDocsType(string pDbType, DocsType pDocsType)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " INSERT INTO docs_type(name, ref_status, log_name) VALUES (@name, @ref_status, @logname)";

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pDocsType.name;
                command.Parameters.Add("logname", SqlDbType.NVarChar).Value = pDocsType.logname;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pDocsType.refStat;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void editDocsType(string pDbType, DocsType pDocsType)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " UPDATE docs_type SET name = @name, ref_status = @ref_status, log_name = @logname WHERE id = @id";

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pDocsType.name;
                command.Parameters.Add("logname", SqlDbType.NVarChar).Value = pDocsType.logname;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pDocsType.refStat;
                command.Parameters.Add("id", SqlDbType.Int).Value = pDocsType.id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delDocsType(string pDbType, int pId)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " DELETE FROM docs_type WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.Int).Value = pId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion------------------------------------------------------------------------------

        #region----------------------------------------------------------------------- docsParam

        public DataTable getDocsParam(string pDbType, int pDocsType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT dp.id, dp.ref_docs_param, rdp.name, rdp.description" +
                                        " FROM docs_param dp" +
                                        " INNER JOIN ref_docs_param rdp ON rdp.id = dp.ref_docs_param" +
                                        " WHERE dp.docs_type = @docsType";

                command.Parameters.Add("docsType", SqlDbType.Int).Value = pDocsType;

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

        public void addDocsParam(string pDbType, DocsParam pDocsParam)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " INSERT INTO docs_param(docs_type, ref_docs_param) VALUES (@docs_type, @ref_docs_param)";

                command.Parameters.Add("docs_type", SqlDbType.NVarChar).Value = pDocsParam.docsTypeId;
                command.Parameters.Add("ref_docs_param", SqlDbType.Int).Value = pDocsParam.refDocsParamId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void editDocsParam(string pDbType, DocsParam pDocsParam)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " UPDATE docs_param SET docs_type = @docs_type, ref_docs_param = @ref_docs_param WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.NVarChar).Value = pDocsParam.id;
                command.Parameters.Add("docs_type", SqlDbType.NVarChar).Value = pDocsParam.docsTypeId;
                command.Parameters.Add("ref_docs_param", SqlDbType.Int).Value = pDocsParam.refDocsParamId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delDocsParam(string pDbType, int pId)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " DELETE FROM docs_param WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.NVarChar).Value = pId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion-------------------------------------------------------------------------------

        #region----------------------------------------------------------------------- docs_block

        public DataTable getDocsBlock(string pDbType, int pDocsType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT db.id, db.name, db.docs_type, db.xorder, " +
                                            " db.ref_statusIn, rsIn.name AS ref_statusIn_name," +
                                            " db.ref_statusOut, rsOut.name AS ref_statusOut_name," +
                                            " db.isAuto," +
                                            " db.condition" +
                                        " FROM docs_block db" +
                                        " INNER JOIN ref_status rsIn ON rsIn.id = db.ref_statusIn" +
                                        " INNER JOIN ref_status rsOut ON rsOut.id = db.ref_statusOut"+
                                        " WHERE db.docs_type = @docsType"+
                                        " ORDER BY db.xorder";

                command.Parameters.Add("docsType", SqlDbType.Int).Value = pDocsType;

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

        public void addDocsBlock(string pDbType, DocsBlock pDocsBlock)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO docs_block(docs_type,    name,   xorder, ref_statusIn,   ref_statusOut,  isAuto, condition)"+
                                                    " VALUES(@docs_type,    @name,  @xorder,@ref_statusIn,  @ref_statusOut, @isAuto,@condition)";


                command.Parameters.Add("docs_type", SqlDbType.Int).Value = pDocsBlock.docsType;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pDocsBlock.name;
                command.Parameters.Add("xorder", SqlDbType.Int).Value = pDocsBlock.xorder;
                command.Parameters.Add("ref_statusIn", SqlDbType.Int).Value = pDocsBlock.refStatusIn;
                command.Parameters.Add("ref_statusOut", SqlDbType.Int).Value = pDocsBlock.refStatusOut;
                command.Parameters.Add("isAuto", SqlDbType.Int).Value = pDocsBlock.isAuto;
                command.Parameters.Add("condition", SqlDbType.NVarChar).Value = pDocsBlock.condition;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void editDocsBlock(string pDbType, DocsBlock pDocsBlock)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " UPDATE docs_block SET docs_type = @docs_type,        name = @name,       xorder = @xorder,   ref_statusIn = @ref_statusIn, " +
                                                        " ref_statusOut = @ref_statusOut,    isAuto = @isAuto,   condition = @condition" +
                                                    " WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.Int).Value = pDocsBlock.id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pDocsBlock.name;
                command.Parameters.Add("docs_type", SqlDbType.Int).Value = pDocsBlock.docsType;
                command.Parameters.Add("xorder", SqlDbType.Int).Value = pDocsBlock.xorder;
                command.Parameters.Add("ref_statusIn", SqlDbType.Int).Value = pDocsBlock.refStatusIn;
                command.Parameters.Add("ref_statusOut", SqlDbType.Int).Value = pDocsBlock.refStatusOut;
                command.Parameters.Add("isAuto", SqlDbType.Int).Value = pDocsBlock.isAuto;
                command.Parameters.Add("condition", SqlDbType.NVarChar).Value = pDocsBlock.condition;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delDocsBlock(string pDbType, int pId)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " DELETE FROM docs_block WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.NVarChar).Value = pId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion-------------------------------------------------------------------------------
    }

    public class DocsBlock
    {
        public int id { get; set; }
        public int docsType { get; set; }
        public string name { get; set; }
        public int xorder { get; set; }
        public int refStatusIn { get; set; }
        public int refStatusOut { get; set; }
        public int isAuto { get; set; }
        public string condition { get; set; }
    }

    public class DocsType
    {
        public int id { get; set; }
        public string name { get; set; }
        public int refStat { get; set; }
        public string logname { get; set; }
    }

    public class DocsParam
    {
        public int id { get; set; }
        public int docsTypeId { get; set; }
        public int refDocsParamId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
