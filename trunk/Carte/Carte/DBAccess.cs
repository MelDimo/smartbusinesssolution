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
        SqlConnection con;
        SqlCommand command;
        SqlTransaction tx;

        DataTable dtResult;

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
    }
}
