﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.utilites;
using System.Drawing;

namespace com.sbs.gui.users
{

    class DBaccess
    {
        SqlConnection con = null;
        SqlCommand command = null;
        SqlTransaction tx = null;

        public DataTable getOrganipation(string pDbType)
        {
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT 0 AS id, '< все >' AS name " +
                                        " FROM organization " +
                                        " UNION " +
                                        " SELECT id, name FROM organization" +
                                        " WHERE ref_status = @ref_status"+
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
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT 0 AS id, '< все >' AS name, 0 AS organization" +
                                        " FROM branch " +
                                        " UNION " +
                                        " SELECT id, name, organization FROM branch" +
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
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT 0 AS id, '< все >' AS name, 0 AS branch " +
                                        " FROM unit " +
                                        " UNION " +
                                        " SELECT id, name, branch FROM unit" +
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

        #region Users

        public DataTable getUsers(string pDbType, int pIdOrg, int pIdBranch, int pIdUnit)
        {
            string where = "WHERE";

            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT u.id, u.tabn, u.lname + ' ' + u.fname + ' ' + u.sname AS fio, stat.name AS status_name, post.name AS post" +
                                        " FROM users AS u INNER JOIN " +
                                        " ref_status AS stat ON stat.id = u.ref_status INNER JOIN " +
                                        " ref_post AS post ON post.id = u.ref_post";

                if (pIdOrg != 0) where += " org = " + pIdOrg + " AND";
                if(pIdBranch != 0) where += " branch = " + pIdBranch + " AND";
                if(pIdUnit != 0) where += " unit = " + pIdUnit + " AND";

                if (where.Equals("WHERE")) where = string.Empty;
                else where = where.Substring(0, where.Length - 3);

                command.CommandText += where;

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

        public UsersDTO getUser(string pDbType, int pIdUser)
        {
            UsersDTO oUsers = new UsersDTO();
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, tabn, fname, sname, lname, bdate, org, branch, unit, ref_post, ref_status, pwd" +
                                        " FROM users" +
                                        " WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.Int).Value = pIdUser;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach (DataRow dr in dtResult.Rows)
            {
                oUsers.Id = (int)dr["id"];
                oUsers.Tabn = (int)dr["tabn"];
                oUsers.fName = dr["fname"].ToString();
                oUsers.sName = dr["sname"].ToString();
                oUsers.lName = dr["lname"].ToString();
                oUsers.BDate = (DateTime)dr["bdate"];
                oUsers.Org = (int)dr["org"];
                oUsers.Branch = (int)dr["branch"];
                oUsers.Unit = (int)dr["unit"];
                oUsers.RefPost = (int)dr["ref_post"];
                oUsers.RefStatus = (int)dr["ref_status"];
            }

            return oUsers;
        }

        public void addUser(string pDbType, UsersDTO pUsersDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO users (tabn,   fname,  sname,  lname,  bdate,  org,    branch,     unit,   ref_post,   ref_status)" +
                                                " VALUES (@tabn,  @fname, @sname, @lname, @bdate, @org,   @branch,    @unit,  @ref_post,  @ref_status)";
                command.Parameters.Add("tabn", SqlDbType.Int).Value = pUsersDTO.Tabn;
                command.Parameters.Add("fname", SqlDbType.NVarChar).Value = pUsersDTO.fName;
                command.Parameters.Add("sname", SqlDbType.NVarChar).Value = pUsersDTO.sName;
                command.Parameters.Add("lname", SqlDbType.NVarChar).Value = pUsersDTO.lName;
                command.Parameters.Add("bdate", SqlDbType.DateTime).Value = pUsersDTO.BDate;
                command.Parameters.Add("org", SqlDbType.Int).Value = pUsersDTO.Org;
                command.Parameters.Add("branch", SqlDbType.Int).Value = pUsersDTO.Branch;
                command.Parameters.Add("unit", SqlDbType.Int).Value = pUsersDTO.Unit;
                command.Parameters.Add("ref_post", SqlDbType.Int).Value = pUsersDTO.RefPost;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pUsersDTO.RefStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void editUser(string pDbType, UsersDTO pUsersDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE users SET tabn = @tabn, fname = @fname, sname = @sname, lname = @lname, bdate = @bdate, org = @org, branch = @branch, unit = @unit, ref_post = @ref_post, ref_status = @ref_status"+
                                        " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pUsersDTO.Id;
                command.Parameters.Add("tabn", SqlDbType.Int).Value = pUsersDTO.Tabn;
                command.Parameters.Add("fname", SqlDbType.NVarChar).Value = pUsersDTO.fName;
                command.Parameters.Add("sname", SqlDbType.NVarChar).Value = pUsersDTO.sName;
                command.Parameters.Add("lname", SqlDbType.NVarChar).Value = pUsersDTO.lName;
                command.Parameters.Add("bdate", SqlDbType.DateTime).Value = pUsersDTO.BDate;
                command.Parameters.Add("org", SqlDbType.Int).Value = pUsersDTO.Org;
                command.Parameters.Add("branch", SqlDbType.Int).Value = pUsersDTO.Branch;
                command.Parameters.Add("unit", SqlDbType.Int).Value = pUsersDTO.Unit;
                command.Parameters.Add("ref_post", SqlDbType.Int).Value = pUsersDTO.RefPost;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pUsersDTO.RefStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delUser(string pDbType, int pIdUser)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM users WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pIdUser;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public DataTable getUserGroup(string pDbType, int pIdUser)
        {
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ug.groups, g.name"+
                                       " FROM users_groups AS ug"+
                                       " INNER JOIN groups AS g ON g.id = ug.groups"+
                                       " WHERE ug.users = @users";
                command.Parameters.Add("users", SqlDbType.Int).Value = pIdUser;

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

        public DataTable getAvaliableUserGroup(string pDbType, int pIdUser)
        {
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name" +
                                        " FROM groups" +
                                        " WHERE (ref_status = 1) " +
                                        " AND (id NOT IN(SELECT groups FROM users_groups WHERE (users = @users)))";

                command.Parameters.Add("users", SqlDbType.Int).Value = pIdUser;

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

        public void addUserGroups(string pDbType, int pIdUser, int pIdGroup)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO users_groups(users,   groups)" +
                                                        "VALUES(@users,  @groups)";
                command.Parameters.Add("users", SqlDbType.Int).Value = pIdUser;
                command.Parameters.Add("groups", SqlDbType.Int).Value = pIdGroup;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delUserGroups(string pDbType, int pIdUser, int pIdGroup)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM users_groups WHERE users = @users AND groups = @groups";
                command.Parameters.Add("users", SqlDbType.Int).Value = pIdUser;
                command.Parameters.Add("groups", SqlDbType.Int).Value = pIdGroup;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion

        #region Groups

        public DataTable getGroups(string pDbType)
        {
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT gp.id, gp.name, stat.name AS ref_status_name, gp.ref_status AS ref_status" +
                                        " FROM groups gp"+
                                        " INNER JOIN ref_status stat ON stat.id = gp.ref_status";

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

        public void addGroup(string pDbType, GroupDTO pGroupDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO groups(name,  ref_status)" +
                                                " VALUES(@name,  @ref_status)";
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pGroupDTO.Name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pGroupDTO.RefStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void editGroup(string pDbType, GroupDTO pGroupDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE groups SET name = @name, ref_status = @ref_status" +
                                                " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pGroupDTO.Id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pGroupDTO.Name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pGroupDTO.RefStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void delGroup(string pDbType, int pIdGroup)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM groups" +
                                        " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pIdGroup;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #endregion

        #region Menu

        public DataTable getMenu(string pDbType)
        {
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, id_parent, name, ref_menu_type, ref_modules, ref_status "+
                                        " FROM menu WHERE ref_status = @ref_status ORDER BY id_parent";
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

        public DataTable getMenuUser(string pDbType, int pUserId)
        {
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT users, menu " +
                                        " FROM users_menu WHERE users = @users";

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

        public void createMenuUser(string pDbType, int pUserId, List<int> pUserMenuId)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                tx = con.BeginTransaction();

                command = con.CreateCommand();
                command.Transaction = tx;

                command.CommandText = "DELETE FROM users_menu WHERE users = @users";
                command.Parameters.Add("users", SqlDbType.Int).Value = pUserId;
                command.ExecuteNonQuery();

                command.Parameters.Add("menu", SqlDbType.Int);
                command.CommandText = "INSERT INTO users_menu(users, menu) VALUES(@users, @menu)";
                foreach (int menu in pUserMenuId)
                {
                    command.Parameters["menu"].Value = menu;
                    command.ExecuteNonQuery();
                }

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }
        }

        #endregion


    }
}
