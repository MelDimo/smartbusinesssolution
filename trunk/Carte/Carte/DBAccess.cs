using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll;

namespace com.sbs.gui.carte
{
    internal static class ReferData
    {
        internal static DataTable dtUnit;
        internal static DataTable dtCheckedUnit;

    }

    public class DBAccess
    {
        private DataTable dtResult;

        private SqlConnection con;
        private SqlCommand command;
        private SqlTransaction tx;

        internal void setDtUnit(string pDbType)
        {
            ReferData.dtUnit = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT u.branch, " +
                                      "         u.id AS unit, " +
                                      "         u.name " +
                                      " FROM unit u " +
                                      " WHERE u.ref_status = 1";

                command.Parameters.Add("refStatus", SqlDbType.Int).Value = 1;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    ReferData.dtUnit.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
        
        internal void setDtCheckedUnit(string pDbType)
        {
            ReferData.dtCheckedUnit = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT carte, unit FROM carte_unit ";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    ReferData.dtCheckedUnit.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #region -------------------------------------------------------------- Меню

        public void carte_add(string pDbType, DTO.Carte pCarte)
        {
            int carteId = 0;

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Connection = con;
                command.Transaction = tx;

                command.CommandText = "INSERT INTO carte(code, name, branch, ref_status) VALUES(@code, @name, @branch, @ref_status); " +
                                        " SELECT CAST(scope_identity() AS int)";
                command.Parameters.Add("code", SqlDbType.Int).Value = pCarte.code;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarte.name;
                command.Parameters.Add("branch", SqlDbType.Int).Value = pCarte.branch;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarte.refStatus;

                carteId = (Int32)command.ExecuteScalar();

                command.Parameters.Clear();
                command.CommandText = "INSERT INTO carte_unit(carte, unit) VALUES(@carte, @unit)";
                command.Parameters.Add("@carte", SqlDbType.Int);
                command.Parameters.Add("@unit", SqlDbType.Int);
                foreach (int i in pCarte.unit)
                {
                    command.Parameters["@carte"].Value = carteId;
                    command.Parameters["@unit"].Value = i;

                    command.ExecuteNonQuery();
                }

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }
        }

        public void carte_edit(string pDbType, DTO.Carte pCarte)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Connection = con;
                command.Transaction = tx;

                command.CommandText = "UPDATE carte SET code = @code, name = @name, branch = @branch, ref_status = @ref_status" +
                                        " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pCarte.id;
                command.Parameters.Add("code", SqlDbType.Int).Value = pCarte.code;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarte.name;
                command.Parameters.Add("branch", SqlDbType.Int).Value = pCarte.branch;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarte.refStatus;

                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = "DELETE FROM carte_unit WHERE carte = @carte";
                command.Parameters.Add("@carte", SqlDbType.Int).Value = pCarte.id;

                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = "INSERT INTO carte_unit(carte, unit) VALUES(@carte, @unit)";
                command.Parameters.Add("@carte", SqlDbType.Int);
                command.Parameters.Add("@unit", SqlDbType.Int);
                foreach (int i in pCarte.unit)
                {
                    command.Parameters["@carte"].Value = pCarte.id;
                    command.Parameters["@unit"].Value = i;

                    command.ExecuteNonQuery();
                }

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }
        }

        public void carte_delete(string pDbType, int pCarteId)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM carte WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pCarteId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void carte_dublicate(string pDbType, int pBranch, int pCode, int pCarteId)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Connection = con;
                command.Transaction = tx;

                command.CommandText = "CarteDublicate";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = pBranch;
                command.Parameters.Add("pCarte", SqlDbType.Int).Value = pCarteId;
                command.Parameters.Add("pCode", SqlDbType.Int).Value = pCode;

                command.ExecuteNonQuery();

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }
        }

        #endregion

        #region -------------------------------------------------------------- Группа

        public void group_add(string pDbType, DTO.CarteDishesGroup pCarteDishesGroup)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO carte_dishes_group(id_parent, carte, name, ref_status) VALUES(@id_parent, @carte, @name, @ref_status)";
                command.Parameters.Add("id_parent", SqlDbType.Int).Value = pCarteDishesGroup.idParent;
                command.Parameters.Add("carte", SqlDbType.Int).Value = pCarteDishesGroup.carte;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarteDishesGroup.name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarteDishesGroup.refStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void group_edit(string pDbType, DTO.CarteDishesGroup pCarteDishesGroup)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE carte_dishes_group SET id_parent = @id_parent, carte = @carte, name = @name, ref_status = @ref_status" + 
                                        " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pCarteDishesGroup.id;
                command.Parameters.Add("id_parent", SqlDbType.Int).Value = pCarteDishesGroup.idParent;
                command.Parameters.Add("carte", SqlDbType.Int).Value = pCarteDishesGroup.carte;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarteDishesGroup.name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarteDishesGroup.refStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void group_delete(string pDbType, int pGroupId)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM carte_dishes_group WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pGroupId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion

        #region -------------------------------------------------------------- Блюда

        public void dishes_add(string pDbType, DTO.CarteDishes pCarteDishes, int branchId)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "CarteDishes_add";

                command.Parameters.Add("carte_dishes_group", SqlDbType.Int).Value = pCarteDishes.carteDishesGroup;
                command.Parameters.Add("ref_dishes", SqlDbType.Int).Value = pCarteDishes.refDishes;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarteDishes.name;
                command.Parameters.Add("price", SqlDbType.Decimal).Value = pCarteDishes.price;
                command.Parameters.Add("minStep", SqlDbType.Decimal).Value = pCarteDishes.minStep;
                command.Parameters.Add("isvisible", SqlDbType.Int).Value = pCarteDishes.isVisible;
                command.Parameters.Add("avalHall", SqlDbType.Int).Value = pCarteDishes.avalHall;
                command.Parameters.Add("avalDelivery", SqlDbType.Int).Value = pCarteDishes.avalDelivery;
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = pCarteDishes.refPrintersType;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarteDishes.refStatus;
                command.Parameters.Add("branch", SqlDbType.Int).Value = branchId;
                command.Parameters.Add("carte", SqlDbType.Int).Value = pCarteDishes.carte;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void dishes_edit(string pDbType, DTO.CarteDishes pCarteDishes, int branchId, int checkRefDish)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "CarteDishes_edit";

                command.Parameters.Add("id", SqlDbType.Int).Value = pCarteDishes.id;
                command.Parameters.Add("carte_dishes_group", SqlDbType.Int).Value = pCarteDishes.carteDishesGroup;
                command.Parameters.Add("ref_dishes", SqlDbType.Int).Value = pCarteDishes.refDishes;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarteDishes.name;
                command.Parameters.Add("price", SqlDbType.Decimal).Value = pCarteDishes.price;
                command.Parameters.Add("minStep", SqlDbType.Decimal).Value = pCarteDishes.minStep;
                command.Parameters.Add("isvisible", SqlDbType.Int).Value = pCarteDishes.isVisible;
                command.Parameters.Add("avalHall", SqlDbType.Int).Value = pCarteDishes.avalHall;
                command.Parameters.Add("avalDelivery", SqlDbType.Int).Value = pCarteDishes.avalDelivery;
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = pCarteDishes.refPrintersType;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarteDishes.refStatus;
                command.Parameters.Add("branch", SqlDbType.Int).Value = branchId;
                command.Parameters.Add("carte", SqlDbType.Int).Value = pCarteDishes.carte;
                command.Parameters.Add("checkRefDish", SqlDbType.Int).Value = checkRefDish;
                
                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void dishes_delete(string pDbType, int pDishesId)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM carte_dishes WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pDishesId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion

        #region -------------------------------------------------------------- Топпинги_группы

        public void topping_add(string pDbType, DTO.ToppingGroup pToppGroup)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO toppings_groups(id_parent, carte_dishes, name, ref_status) VALUES(@id_parent, @carte_dishes, @name, @ref_status)";
                command.Parameters.Add("id_parent", SqlDbType.Int).Value = pToppGroup.id_parent;
                command.Parameters.Add("carte_dishes", SqlDbType.Int).Value = pToppGroup.carteDishes;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pToppGroup.name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pToppGroup.refStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void topping_edit(string pDbType, DTO.ToppingGroup pToppGroup)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE toppings_groups SET id_parent = @id_parent, carte_dishes = @carte_dishes, name = @name, ref_status = @ref_status" +
                                        " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pToppGroup.id;
                command.Parameters.Add("id_parent", SqlDbType.Int).Value = pToppGroup.id_parent;
                command.Parameters.Add("carte_dishes", SqlDbType.Int).Value = pToppGroup.carteDishes;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pToppGroup.name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pToppGroup.refStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void topping_del(string pDbType, int pToppGroup_id)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM toppings_groups WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pToppGroup_id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion

        #region -------------------------------------------------------------- Топпинги_позиции

        /// <summary>
        /// Возвращает все возможные позиции из текущего меню
        /// </summary>
        /// <param name="pDbType"></param>
        /// <param name="pToppGroup"></param>
        /// <param name="pCarteId"></param>
        /// <returns></returns>
        public DataTable toppingDishAll_get(string pDbType, DTO.ToppingGroup pToppGroup, int pCarteId)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT cd.id, cd.name, cd.price, isvisible " +
                                        " FROM carte_dishes cd " +
                                        " INNER JOIN carte_dishes_group cdg ON cdg.id = cd.carte_dishes_group AND cdg.carte = @carteId " +
                                        " ORDER BY cd.name";

                command.Parameters.Add("carteId", SqlDbType.Int).Value = pCarteId;

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

        public void toppingDish_add(string pDbType, DTO.Topping pTopping)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO toppings_carte_dishes(toppings_groups, carte_dishes, price) VALUES(@toppingsGroups, @carteDishes, @price)";
                
                command.Parameters.Add("toppingsGroups", SqlDbType.Int).Value = pTopping.toppingsGroups;
                command.Parameters.Add("carteDishes", SqlDbType.Int).Value = pTopping.carteDishes;
                command.Parameters.Add("price", SqlDbType.Decimal).Value = pTopping.price;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void toppingDish_del(string pDbType, int pToppingId)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM toppings_carte_dishes WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.Int).Value = pToppingId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion

        public DataTable reportsCarte(string pDbType, int pBranchId, int pCarteId)
        {
            dtResult = new DataTable() { TableName = "carte" };
            
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "REP_Carte";

                command.Parameters.Add("pBranchId", SqlDbType.Int).Value = pBranchId;
                command.Parameters.Add("pCarteId", SqlDbType.Int).Value = pCarteId;

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

    public class advFilter
    {
        public advFilter()
        {
            carteRefStatus = 1;
            carteGroupRefStatus = 1;
            carteDishesRefStatus = 1;
        }

        public int carteRefStatus { get; set; }
        public int carteGroupRefStatus { get; set; }
        public int carteDishesRefStatus { get; set; }
    }
}
