using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.prepack
{
    class DBaccess
    {
        private SqlConnection con = null;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        private DataTable dtResult;

        public DataTable getPrepack(string pDbType, int pIdUnit)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ppack.id, ppack.code, ppack.name, ppack.ref_status, status.name AS ref_status_name " +
                                        " FROM prepack ppack" +
                                        " INNER JOIN ref_status status ON status.id = ppack.ref_status" +
                                        " WHERE unit = @unit AND ppack.ref_status = @ref_status" +
                                        " ORDER BY name";
                command.Parameters.Add("unit", SqlDbType.Int).Value = pIdUnit;
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

        public DataTable getOrganipation(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name FROM organization" +
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

        public DataTable getBranch(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, organization FROM branch" +
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

        public DataTable getUnit(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, branch FROM unit" +
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

        public void delPrepackMain(string pDbType, int pId)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "DELETE FROM prepack WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public DataTable getAllGoods(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, code, name, manufacturer " +
                                        " FROM ref_goods" +
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

        public DataSet getPrepackInfo(string pDbType, int pPrepack)
        {
            DataSet ds = new DataSet();

            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = " SELECT rgoods.id, rgoods.code, rgoods.name, rgoods.manufacturer, rgoods.ref_status, stat.name AS ref_status_name" +
                                        " FROM prepack_info pinfo" +
                                        " INNER JOIN ref_goods rgoods ON rgoods.id = pinfo.ref_goods" +
                                        " INNER JOIN ref_status stat ON stat.id = rgoods.ref_status" +
                                        " WHERE pinfo.prepack = @prepack";
                command.Parameters.Add("prepack", SqlDbType.Int).Value = pPrepack;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                dtResult.TableName = "GOODS";
                ds.Tables.Add(dtResult.Copy());

                dtResult = new DataTable();

                command = con.CreateCommand();
                command.CommandText = " SELECT ppack.id, ppack.code, ppack.name, ppack.ref_status, stat.name AS ref_status_name" +
                                        " FROM prepack_info pinfo" +
                                        " INNER JOIN prepack ppack ON ppack.id = pinfo.prepack_id" +
                                        " INNER JOIN ref_status stat ON stat.id = ppack.ref_status" +
                                        " WHERE pinfo.prepack = @prepack";
                command.Parameters.Add("prepack", SqlDbType.Int).Value = pPrepack;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }
                dtResult.TableName = "PREPACK";
                ds.Tables.Add(dtResult.Copy());

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return ds;
        }

        public void addGoodsInfo(string pDbType, int pPrepack, int pRefGoods, int pPrepackId)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "INSERT INTO prepack_info(prepack, ref_goods, prepack_id) VALUES(@prepack, @ref_goods, @prepack_id)";
                command.Parameters.Add("prepack", SqlDbType.Int).Value = pPrepack;
                command.Parameters.Add("ref_goods", SqlDbType.Int).Value = pRefGoods;
                command.Parameters.Add("prepack_id", SqlDbType.Int).Value = pPrepackId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delGoodsInfo(string pDbType, int pIdPrapack, int pIdGoods)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "DELETE FROM prepack_info WHERE prepack = @prepack AND ref_goods = @ref_goods";
                command.Parameters.Add("prepack", SqlDbType.Int).Value = pIdPrapack;
                command.Parameters.Add("ref_goods", SqlDbType.Int).Value = pIdGoods;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void addPrepackInfo(string pDbType, int pPrepack, int pRefGoods, int pPrepackId)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "INSERT INTO prepack_info(prepack, ref_goods, prepack_id) VALUES(@prepack, @ref_goods, @prepack_id)";
                command.Parameters.Add("prepack", SqlDbType.Int).Value = pPrepack;
                command.Parameters.Add("ref_goods", SqlDbType.Int).Value = pRefGoods;
                command.Parameters.Add("prepack_id", SqlDbType.Int).Value = pPrepackId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delPrepackInfo(string pDbType, int pPrapack, int pIdPrepack_id)
        {
            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "DELETE FROM prepack_info WHERE prepack = @prepack AND prepack_id = @prepack_id";
                command.Parameters.Add("prepack", SqlDbType.Int).Value = pPrapack;
                command.Parameters.Add("prepack_id", SqlDbType.Int).Value = pIdPrepack_id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }



    }
}
