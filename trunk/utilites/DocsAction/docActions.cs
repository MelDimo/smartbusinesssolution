using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace com.sbs.dll.docsaction
{
    public class Oper
    {
        public int id { set; get; }
        public int ref_accountDeb { set; get; }
        public int ref_accountKred { set; get; }
        public int ref_currency_course { set; get; }
        public decimal summa { set; get; }
        public decimal equivalent { set; get; }
        public int packages { set; get; }
        public int ref_status { set; get; }
    }

    public class Packages
    {
        public int id { set; get; }
        public int packages_type { set; get; }
        public int user_create { set; get; }
        public DateTime date_create { set; get; }
        public string doc_base { get; set; }
        public string doc_proxy { get; set; }
        public string doc_comment { get; set; }
        public int ref_status { set; get; }
    }

    public class Docs
    {
        public int id { set; get; }
        public int docs_type { set; get; }
        public Dictionary<string, object> param  = new Dictionary<string, object>();
        public int packages { set; get; }
        public int ref_status { set; get; }

        public void addParam(string pParam, object pValue)
        {
            param.Add(pParam, pValue);
        }
    }

    public class DocActions
    {
        private SqlConnection con;
        private SqlCommand command = null;
        private SqlTransaction tx = null;

        public int savePackage(string pDbType, Packages pPackage)
        {
            int xPackId;

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "DocsPackage_Save";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pUsers", SqlDbType.Int).Value = UsersInfo.UserId;
                command.Parameters.Add("pPackagesType", SqlDbType.Int).Value = pPackage.packages_type;
                command.Parameters.Add("pDocBase", SqlDbType.NVarChar).Value = pPackage.doc_base;
                command.Parameters.Add("pDocProxy", SqlDbType.NVarChar).Value = pPackage.doc_proxy;
                command.Parameters.Add("pDocComment", SqlDbType.NVarChar).Value = pPackage.doc_comment;
                command.Parameters.Add("pStatus", SqlDbType.Int).Value = pPackage.ref_status;
                command.Parameters.Add("outPackId", SqlDbType.Int);
                command.Parameters["outPackId"].Value = pPackage.id;
                command.Parameters["outPackId"].Direction = ParameterDirection.InputOutput;

                command.ExecuteNonQuery();

                xPackId = (int)command.Parameters["outPackId"].Value;

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return xPackId;
        }

        public void saveDoc(string pDbType, Packages pPackage, Docs pDocs)
        {
            DataTable dtParamValue = new DataTable();
            dtParamValue.Columns.Add(new DataColumn("refDocsParam"));
            dtParamValue.Columns.Add(new DataColumn("value"));

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "DocsDoc_Save";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pId", SqlDbType.Int).Value = pDocs.id;
                command.Parameters.Add("pDocsType", SqlDbType.Int).Value = pDocs.docs_type;
                command.Parameters.Add("pDocsParamValue", SqlDbType.Structured);
                command.Parameters.Add("pPackages", SqlDbType.Int).Value = pDocs.packages;
                command.Parameters.Add("pUsers", SqlDbType.Int).Value = UsersInfo.UserId;

                foreach (KeyValuePair<string, object> pair in pDocs.param)
                {
                    dtParamValue.Rows.Add(new object[] { pair.Key, pair.Value });
                }
                command.Parameters["pDocsParamValue"].Value = dtParamValue;
                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void recalcPackageCost(string pDbType, Packages pPackage, int pDocType)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "DocsRecalcPackage";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pPackagesId", SqlDbType.Int).Value = pPackage.id;
                command.Parameters.Add("pDocType", SqlDbType.Int).Value = pDocType;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
    }
}
