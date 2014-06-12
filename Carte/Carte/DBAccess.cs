using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll;

namespace com.sbs.gui.carte
{
    public class DBAccess
    {
        private SqlConnection con;
        private SqlCommand command;
        private SqlTransaction tx;

        #region -------------------------------------------------------------- Меню

        public void carte_add(string pDbType, DTO.Carte pCarte)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO carte(code, name, branch, ref_status) VALUES(@code, @name, @branch, @ref_status)";
                command.Parameters.Add("code", SqlDbType.Int).Value = pCarte.code;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarte.name;
                command.Parameters.Add("branch", SqlDbType.Int).Value = pCarte.branch;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarte.refStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void carte_edit(string pDbType, DTO.Carte pCarte)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE carte SET code = @code, name = @name, branch = @branch, ref_status = @ref_status" +
                                        " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pCarte.id;
                command.Parameters.Add("code", SqlDbType.Int).Value = pCarte.code;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarte.name;
                command.Parameters.Add("branch", SqlDbType.Int).Value = pCarte.branch;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarte.refStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
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

        public void carte_dublicate(string pDbType, int pCarteId, int pBranch, int pCode)
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

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = pCarteId;
                command.Parameters.Add("pCarte", SqlDbType.Int).Value = pCarteId;
                command.Parameters.Add("pCode", SqlDbType.Int).Value = pCarteId;

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

        public void dishes_add(string pDbType, DTO.CarteDishes pCarteDishes)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO carte_dishes(carte_dishes_group,     ref_dishes,     name,   price,  minStep,    isvisible,  ref_printers_type,  ref_status)"+
                                                        " VALUES(@carte_dishes_group,   @ref_dishes,    @name,  @price, @minStep,   @isvisible, @ref_printers_type, @ref_status)";

                command.Parameters.Add("carte_dishes_group", SqlDbType.Int).Value = pCarteDishes.carteDishesGroup;
                command.Parameters.Add("ref_dishes", SqlDbType.Int).Value = pCarteDishes.refDishes;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarteDishes.name;
                command.Parameters.Add("price", SqlDbType.Decimal).Value = pCarteDishes.price;
                command.Parameters.Add("minStep", SqlDbType.Decimal).Value = pCarteDishes.minStep;
                command.Parameters.Add("isvisible", SqlDbType.Int).Value = pCarteDishes.isVisible;
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = pCarteDishes.refPrintersType;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarteDishes.refStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void dishes_edit(string pDbType, DTO.CarteDishes pCarteDishes)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE carte_dishes SET carte_dishes_group = @carte_dishes_group, " +
                                                            " ref_dishes = @ref_dishes," +
                                                            " name = @name, " +
                                                            " price = @price," +
                                                            " isvisible = @isvisible," +
                                                            " ref_printers_type = @ref_printers_type," +
                                                            " ref_status = @ref_status," +
                                                            " minStep = @minStep" +
                                                        " WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.Int).Value = pCarteDishes.id;
                command.Parameters.Add("carte_dishes_group", SqlDbType.Int).Value = pCarteDishes.carteDishesGroup;
                command.Parameters.Add("ref_dishes", SqlDbType.Int).Value = pCarteDishes.refDishes;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pCarteDishes.name;
                command.Parameters.Add("price", SqlDbType.Decimal).Value = pCarteDishes.price;
                command.Parameters.Add("minStep", SqlDbType.Decimal).Value = pCarteDishes.minStep;
                command.Parameters.Add("isvisible", SqlDbType.Int).Value = pCarteDishes.isVisible;
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = pCarteDishes.refPrintersType;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pCarteDishes.refStatus;
                

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

        public void toppingDishAll_get(string pDbType, DTO.ToppingGroup pToppGroup, int pCarteId)
        {
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

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion
    }
}
