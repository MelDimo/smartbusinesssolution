using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.utilites;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;

namespace com.sbs.gui.users
{

    class DBaccess
    {
        SqlConnection con = null;
        SqlCommand command = null;
        SqlTransaction tx = null;

        DataTable dtResult;

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
                                        " ref_post AS post ON post.id = u.ref_post ";

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

        public DTO.User getUser(string pDbType, int pIdUser)
        {
            DTO.User oUsers = new DTO.User();
            DataTable dtResult = new DataTable();
            XmlSerializer xmlSer = new XmlSerializer(typeof(DTO.User));

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id,	tabn,			fname as fName,	sname as sName,	lname as lName,	bdate,		bPlace, 	org," +
                                                    " branch,			unit,			ref_post as refPost, ref_status as refStatus,	refStatusDate,	dateAdopted," +
                                                    " dateStarted,	dateFired,		docNumber,		pensNumber,		citizen1,		citizen2," +
                                                    " nationality,	passSeriy,		passNumber,		passDateIssued,	passWhoIssued,	passAddress," +
                                                    " education1,	specialty1,		doc1,			education2,		specialty2,		doc2,   reservist" +
                                        " FROM users" +
                                        " WHERE id = @id" +
                                        " FOR XML RAW('User'), ELEMENTS XSINIL;";

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
                StringReader reader = new StringReader(dr[0].ToString());
                oUsers = (DTO.User)xmlSer.Deserialize(reader);
            }

            return oUsers;
        }

        public void addEditUser(string pDbType, DTO.User pUsersDTO)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(DTO.User));

            StringWriter sw = new StringWriter();
            xmlSer.Serialize(sw, pUsersDTO);
            string xml = sw.ToString();

            using (con = new DBCon().getConnection(pDbType))
            {
                command = null;
                try
                {
                    con.Open();
                    command = con.CreateCommand();

                    command.CommandText = "Users_AddEdit";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pUserXML", SqlDbType.Xml).Value = xml;

                    command.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception exc) { throw exc; }
            }
        }

        public void delUser(string pDbType, int pIdUser)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "Users_delete";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = pIdUser;

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

        public void addGroup(string pDbType, DTO.Group pGroupDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO groups(name,  ref_status)" +
                                                " VALUES(@name,  @ref_status)";
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pGroupDTO.name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pGroupDTO.refStatus;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        public void editGroup(string pDbType, DTO.Group pGroupDTO)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE groups SET name = @name, ref_status = @ref_status" +
                                                " WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pGroupDTO.id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pGroupDTO.name;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pGroupDTO.refStatus;

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

                command.CommandText = "DELETE FROM groups " +
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

        #region ACL

        internal DataTable getUserACL(string pDbType, int pUserID)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ua.user_acl_type acl_type, uat.name " +
                                         " FROM users_acl ua " +
                                         " INNER JOIN users_acl_type uat ON uat.id = ua.user_acl_type " +
                                         " WHERE ua.users = @userID";

                command.Parameters.Add("userID", SqlDbType.Int).Value = pUserID;
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

        internal DataTable getGroupACL(string pDbType, int pGroupID)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT gacl.user_acl_type acl_type, uat.name " +
                                         " FROM groups_acl gacl " +
                                         " INNER JOIN users_acl_type uat ON uat.id = gacl.user_acl_type " +
                                         " WHERE gacl.groups = @groupID";

                command.Parameters.Add("groupID", SqlDbType.Int).Value = pGroupID;
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

        internal void addUserACL(string pDbType, int pUserID, int pACLType)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " INSERT INTO users_acl(users, user_acl_type) VALUES (@users, @user_acl_type)";

                command.Parameters.Add("users", SqlDbType.Int).Value = pUserID;
                command.Parameters.Add("user_acl_type", SqlDbType.Int).Value = pACLType;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void addGroupACL(string pDbType, int pUserID, int pACLType)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " INSERT INTO groups_acl(groups, user_acl_type) VALUES (@groups, @user_acl_type)";

                command.Parameters.Add("groups", SqlDbType.Int).Value = pUserID;
                command.Parameters.Add("user_acl_type", SqlDbType.Int).Value = pACLType;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void deleteUserACL(string pDbType, int pUserID, int pACLType)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " DELETE FROM users_acl WHERE users = @users AND user_acl_type = @user_acl_type";

                command.Parameters.Add("users", SqlDbType.Int).Value = pUserID;
                command.Parameters.Add("user_acl_type", SqlDbType.Int).Value = pACLType;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void deleteGroupACL(string pDbType, int pUserID, int pACLType)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " DELETE FROM groups_acl WHERE groups = @groups AND user_acl_type = @user_acl_type";

                command.Parameters.Add("groups", SqlDbType.Int).Value = pUserID;
                command.Parameters.Add("user_acl_type", SqlDbType.Int).Value = pACLType;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal DataTable getAllACL(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, name, note " +
                                         " FROM users_acl_type " +
                                         " WHERE ref_status = @ref_status";

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

        #endregion

        public DataTable getPwdUser(string pDbType, int pUserId)
        {
            DataTable dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT up.users_pwd_type, up.pwd, u.login " + 
                                        " FROM users_pwd up "+
                                        " INNER JOIN users u ON u.id = up.users " +
                                        " WHERE users = @users";

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

        public void saveUsersPwd(string pDbType, object[] pOParam)
        {
            int xUsersId = (int)pOParam[0];
            string xCardID = pOParam[1].ToString();
            string xPwd = pOParam[2].ToString();
            string xLogIn = pOParam[3].ToString();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "Users_savePWD";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@pUsers", SqlDbType.Int).Value = xUsersId;
                command.Parameters.Add("@pLogIn", SqlDbType.NVarChar).Value = xLogIn;
                command.Parameters.Add("@pPwd", SqlDbType.NVarChar).Value = xPwd;
                command.Parameters.Add("@pCardID", SqlDbType.NVarChar).Value = xCardID;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        #region email

        public void saveEmailUser(string pDbType, object[] pOParam)
        {
            int xUsersId = (int)pOParam[0];
            string xEMail = pOParam[1].ToString();
            string xLogIn = pOParam[2].ToString();
            string xPwd = pOParam[3].ToString();

            con = new DBCon().getConnection(pDbType);
            command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "Users_saveEmail";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@pUsers", SqlDbType.Int).Value = xUsersId;
                command.Parameters.Add("@pLogIn", SqlDbType.NVarChar).Value = xLogIn;
                command.Parameters.Add("@pPwd", SqlDbType.NVarChar).Value = xPwd;
                command.Parameters.Add("@xEMail", SqlDbType.NVarChar).Value = xEMail;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }
        }

        #endregion
    }
}
