using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.DashBoard
{
    class DBaccess
    {
        private DataTable dtResult = new DataTable();

        private SqlConnection con;
        private SqlCommand command = null;

        internal DataTable getAvaliableSeason(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT s.id, s.date_open, u.lname + ' ' + u.fname + ' ' + u.sname as fio, stat.name as status_name " +
                                        " FROM season s " +
                                        " INNER JOIN users u ON u.id = s.user_open" +
                                        " INNER JOIN ref_status stat ON stat.id = s.ref_status" +
                                        " WHERE s.unit = @unit";

                command.Parameters.Add("unit", SqlDbType.Int).Value = GValues.unitId;

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

        internal void openNewSeason(string pDbType)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO season (unit, date_open, user_open, ref_status) " +
                                        " VALUES(@unit, @date_open, @user_open, @ref_status)";

                command.Parameters.Add("unit", SqlDbType.Int).Value = GValues.unitId;
                command.Parameters.Add("date_open", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("user_open", SqlDbType.Int).Value = UsersInfo.UserId;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 16;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal DataTable getAvaliableBills(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT b.id, stat.name AS ref_status_name" +
                                        " FROM bills b" +
                                        " INNER JOIN ref_status stat ON stat.id = b.ref_status" +
                                        " WHERE b.unit = @unit AND b.season = @season AND user_open = @user_open";

                command.Parameters.Add("unit", SqlDbType.Int).Value = GValues.unitId;
                command.Parameters.Add("season", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("user_open", SqlDbType.Int).Value = UsersInfo.UserId;

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

        internal DataTable getCarte(string pDbType)
        {
            dtResult = new DataTable("carte");

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT id, name" +
                                        " FROM carte" +
                                        " WHERE unit = @unit AND ref_status = @ref_status";

                command.Parameters.Add("unit", SqlDbType.Int).Value = GValues.unitId;
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

        internal DataTable getDishesGroup(string pDbType)
        {
            dtResult = new DataTable("dishesgroup");

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, carte, id_parent, name" +
                                        " FROM dishes_group" +
                                        " WHERE ref_status = @ref_status" +
                                        " ORDER BY id_parent";

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

        internal DataTable getDishes(string pDbType)
        {
            dtResult = new DataTable("dishes");

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT id, dishes_group, name, price " +
                                        " FROM dishes" +
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

        internal bool checkMifareWaiter(string pDbType, string pKeyId)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT u.id, lname+' '+ substring(fname,1,1) +'. '+ substring(sname,1,1) + '.' AS fio, u.tabn, u.ref_post" +
                                        " FROM users_pwd upwd" +
                                        " INNER JOIN users u ON u.id = upwd.users AND u.unit = @unit" +
                                        " INNER JOIN ref_post post ON post.id = u.ref_post" +
                                        " WHERE upwd.pwd = @pwd";

                command.Parameters.Add("unit", SqlDbType.Int).Value = GValues.unitId;
                command.Parameters.Add("pwd", SqlDbType.NVarChar).Value = pKeyId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            switch(dtResult.Rows.Count)
            {
                case 0:
                    throw new Exception("Сотрудник не найден");

                case 1:
                    break;

                default:
                    throw new Exception("Найдено больше одного сотрудника удовлетворяющего параметрам.");
            }

            UsersInfo.Clear();
            UsersInfo.UserId = (int)dtResult.Rows[0]["id"];
            UsersInfo.UserName = dtResult.Rows[0]["fio"].ToString();
            UsersInfo.UserTabn = (int)dtResult.Rows[0]["tabn"];

            dtResult = new DataTable();

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT user_acl_type" +
                                    "   FROM users_acl WHERE users = @users";

                command.Parameters.Add("users", SqlDbType.Int).Value = UsersInfo.UserId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            if (dtResult.Rows.Count == 0) throw new Exception("Не указанны права для текущего пользователя");

            foreach (DataRow dr in dtResult.Rows)
            {
                UsersInfo.Acl.Add((int)dr["user_acl_type"]);
            }

            return true;
        }

        internal void createBill(string pDbType)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO bills (unit, season, date_open, user_open, ref_status) " +
                                        " VALUES(@unit, @season, @date_open, @user_open, @ref_status)";

                command.Parameters.Add("unit", SqlDbType.Int).Value = GValues.unitId;
                command.Parameters.Add("season", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("date_open", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("user_open", SqlDbType.Int).Value = UsersInfo.UserId;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 16;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

    }
}
