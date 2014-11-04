using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.sbs.dll.utilites;
using com.sbs.dll;
using System.Data.SqlClient;

namespace com.sbs.gui.deals
{
    public static class RefData
    {
        public static DataTable dtRefStatus;
        public static DataTable dtRefBranch;
        public static DataTable dtRefCarte;
    }
    
    public class DBAccess
    {
        DataTable dtResult;

        private SqlConnection con;
        private SqlCommand command;
        private SqlTransaction tx;

        getReference oReferences = new getReference();

        internal void getReferences(string pDbType)
        {
            RefData.dtRefStatus = oReferences.getStatus(pDbType, 1);
            RefData.dtRefBranch = oReferences.getBranch(pDbType);
            RefData.dtRefCarte = oReferences.getCarte(pDbType);
        }

        internal DataTable getDeals_All(string pDbType)
        {
            dtResult = new DataTable();

            try
            {
                con = new DBCon().getConnection(pDbType);
                con.Open();
                command = con.CreateCommand();
                command.Connection = con;

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT d.id, d.carte, d.name, d.date_start, d.date_end, d.xcount, d.ref_status, rs.name AS refStatusName " + 
                                        " FROM deals d " + 
                                        " INNER JOIN ref_status rs ON rs.id = d.ref_status ";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }

            return dtResult;
        }

        internal DTO.Deals getDeal(string pDbType, int pDealsId)
        {
            DTO.Deals oDeals = new DTO.Deals();
            DataTable dtBuf = new DataTable();

            try
            {
                con = new DBCon().getConnection(pDbType);
                con.Open();
                command = con.CreateCommand();
                command.Connection = con;

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT id, carte, name, date_start, date_end, xcount, ref_status " +
                                        " FROM deals " +
                                        " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pDealsId;
                dtResult = new DataTable();
                using (SqlDataReader dr = command.ExecuteReader()) dtResult.Load(dr);

                oDeals.id = (int)dtResult.Rows[0]["id"];
                oDeals.carte = (int)dtResult.Rows[0]["carte"];
                oDeals.name = dtResult.Rows[0]["name"].ToString();
                oDeals.sumCount = (int)dtResult.Rows[0]["xcount"];
                oDeals.refStatus = (int)dtResult.Rows[0]["ref_status"];
                oDeals.dateStart = (DateTime)dtResult.Rows[0]["date_start"];
                oDeals.dateEnd = (DateTime?)(dtResult.Rows[0]["date_end"] == DBNull.Value ? null : dtResult.Rows[0]["date_end"]);

                command.CommandText = "SELECT deals, ref_dishes, price " +
                                        " FROM deals_dishes " +
                                        " WHERE deals = @id";
                dtResult = new DataTable();
                using (SqlDataReader dr = command.ExecuteReader()) dtResult.Load(dr);

                foreach (DataRow dr in dtResult.Rows)
                {
                    dtBuf = new DataTable();
                    dtBuf = oReferences.getCarteDishes_Carte_RefDishes(pDbType, oDeals.carte, (int)dr["ref_dishes"]);
                    if (dtBuf.Rows.Count == 0)
                    {
                        throw new Exception("Внимание!" + Environment.NewLine +
                        "Позиция указанная как акционная не доступна в меню!" + Environment.NewLine +
                        string.Format("Внешний ключ:{0}", dr["ref_dishes"]) + Environment.NewLine +
                        "Дальнейшая работа модуля недопустима!");
                    }
                    foreach (DataRow drDish in dtBuf.Rows)
                    {
                        oDeals.lCarteDishes.Add(new DTO.CarteDishes()
                        {
                            id = (int)drDish["id"],
                            avalDelivery = (int)drDish["avalDelivery"],
                            avalHall = (int)drDish["avalHall"],
                            carte = oDeals.carte,
                            carteDishesGroup = (int)drDish["carte_dishes_group"],
                            isVisible = (int)drDish["isvisible"],
                            minStep = (decimal)drDish["minStep"],
                            name = drDish["name"].ToString(),
                            price = (decimal)drDish["price"],
                            refDishes = (int)drDish["ref_dishes"],
                            refPrintersType = (int)drDish["ref_printers_type"],
                            refStatus = (int)drDish["ref_status"]
                        });
                    }
                }

                command.CommandText = "SELECT deals, ref_dishes, price " +
                        " FROM deals_bonus " +
                        " WHERE deals = @id";
                dtResult = new DataTable();
                using (SqlDataReader dr = command.ExecuteReader()) dtResult.Load(dr);

                foreach (DataRow dr in dtResult.Rows)
                {
                    dtBuf = new DataTable();
                    dtBuf = oReferences.getCarteDishes_Carte_RefDishes(pDbType, oDeals.carte, (int)dr["ref_dishes"]);
                    if (dtBuf.Rows.Count == 0)
                    {
                        throw new Exception("Внимание!" + Environment.NewLine +
                        "Позиция указанная как бонусная не доступна в меню!" + Environment.NewLine +
                        string.Format("Внешний ключ:{0}", dr["ref_dishes"]) + Environment.NewLine +
                        "Дальнейшая работа модуля недопустима!");
                    }

                    foreach (DataRow drBonus in dtBuf.Rows)
                    {
                        oDeals.lCarteDishesBonus.Add(new DTO.CarteDishes()
                        {
                            id = (int)drBonus["id"],
                            avalDelivery = (int)drBonus["avalDelivery"],
                            avalHall = (int)drBonus["avalHall"],
                            carte = oDeals.carte,
                            carteDishesGroup = (int)drBonus["carte_dishes_group"],
                            isVisible = (int)drBonus["isvisible"],
                            minStep = (decimal)drBonus["minStep"],
                            name = drBonus["name"].ToString(),
                            price = (decimal)drBonus["price"],
                            refDishes = (int)drBonus["ref_dishes"],
                            refPrintersType = (int)drBonus["ref_printers_type"],
                            refStatus = (int)drBonus["ref_status"]
                        });
                    }
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }

            return oDeals;
        }

        internal void saveData(string pDbType, DTO.Deals pDeals)
        {
            Int32 dealsId = 0;

            try
            {
                con = new DBCon().getConnection(pDbType);

                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Connection = con;
                command.Transaction = tx;

                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO deals (id, carte,name,date_start,date_end,xcount,ref_status) " +
                                        " VALUES (@id, @carte, @name, @date_start, @date_end, @xcount, @ref_status); "+
                                        " SELECT CAST(scope_identity() AS int)";

                command.Parameters.Add("id", SqlDbType.Int).Value = pDeals.id;
                command.Parameters.Add("carte", SqlDbType.Int).Value = pDeals.carte;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pDeals.name;
                command.Parameters.Add("date_start", SqlDbType.DateTime).Value = pDeals.dateStart;
                command.Parameters.Add("date_end", SqlDbType.DateTime).Value = pDeals.dateEnd == null ? (object)DBNull.Value : pDeals.dateEnd;
                command.Parameters.Add("xcount", SqlDbType.Int).Value = pDeals.sumCount;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pDeals.refStatus;

                dealsId = (Int32)command.ExecuteScalar();

                command.Parameters.Clear();
                command.CommandText = "INSERT INTO deals_dishes (deals, ref_dishes, price) " +
                                        " VALUES (@deals, @ref_dishes, @price) ";
                command.Parameters.Add("deals", SqlDbType.Int).Value = dealsId;
                command.Parameters.Add("ref_dishes", SqlDbType.Int);
                command.Parameters.Add("price", SqlDbType.Decimal);
                foreach (DTO.CarteDishes cd in pDeals.lCarteDishes)
                {
                    command.Parameters["ref_dishes"].Value = cd.refDishes;
                    command.Parameters["price"].Value = cd.price;
                    command.ExecuteNonQuery();
                }

                command.Parameters.Clear();
                command.CommandText = "INSERT INTO deals_bonus (deals, ref_dishes, price) " +
                                        " VALUES (@deals, @ref_dishes, @price) ";
                command.Parameters.Add("deals", SqlDbType.Int).Value = dealsId;
                command.Parameters.Add("ref_dishes", SqlDbType.Int);
                command.Parameters.Add("price", SqlDbType.Decimal);
                foreach (DTO.CarteDishes cd in pDeals.lCarteDishesBonus)
                {
                    command.Parameters["ref_dishes"].Value = cd.refDishes;
                    command.Parameters["price"].Value = cd.price;
                    command.ExecuteNonQuery();
                }
                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }
        }

        internal void updateData(string pDbType, DTO.Deals pDeals)
        {
            try
            {
                con = new DBCon().getConnection(pDbType);

                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Connection = con;
                command.Transaction = tx;

                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE deals SET name = @name, " +
                                        " date_start = @date_start, " +
                                        " date_end = @date_end, " +
                                        " xcount = @xcount, " +
                                        " ref_status = @ref_status " +
                                        " WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.Int).Value = pDeals.id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pDeals.name;
                command.Parameters.Add("date_start", SqlDbType.DateTime).Value = pDeals.dateStart;
                command.Parameters.Add("date_end", SqlDbType.DateTime).Value = pDeals.dateEnd == null ? (object)DBNull.Value : pDeals.dateEnd;
                command.Parameters.Add("xcount", SqlDbType.Int).Value = pDeals.sumCount;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pDeals.refStatus;

                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = "DELETE FROM deals_dishes WHERE deals = @id ";
                command.Parameters.Add("id", SqlDbType.Int).Value = pDeals.id;
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO deals_dishes (deals, ref_dishes, price) " +
                                        " VALUES (@deals, @ref_dishes, @price) ";
                command.Parameters.Add("deals", SqlDbType.Int).Value = pDeals.id;
                command.Parameters.Add("ref_dishes", SqlDbType.Int);
                command.Parameters.Add("price", SqlDbType.Decimal);
                foreach (DTO.CarteDishes cd in pDeals.lCarteDishes)
                {
                    command.Parameters["ref_dishes"].Value = cd.refDishes;
                    command.Parameters["price"].Value = cd.price;
                    command.ExecuteNonQuery();
                }

                command.Parameters.Clear();
                command.CommandText = "DELETE FROM deals_bonus WHERE deals = @id ";
                command.Parameters.Add("id", SqlDbType.Int).Value = pDeals.id;
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = "INSERT INTO deals_bonus (deals, ref_dishes, price) " +
                                        " VALUES (@deals, @ref_dishes, @price) ";
                command.Parameters.Add("deals", SqlDbType.Int).Value = pDeals.id;
                command.Parameters.Add("ref_dishes", SqlDbType.Int);
                command.Parameters.Add("price", SqlDbType.Decimal);
                foreach (DTO.CarteDishes cd in pDeals.lCarteDishesBonus)
                {
                    command.Parameters["ref_dishes"].Value = cd.refDishes;
                    command.Parameters["price"].Value = cd.price;
                    command.ExecuteNonQuery();
                }

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }
        }
    }
}
