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
        DataTable dtResult = new DataTable();

        SqlConnection con;
        SqlCommand command = null;

        public DataTable getAvaliableSeason(string pDbType)
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

        public void openNewSeason(string pDbType)
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

        public DataTable getAvaliableBills(string pDbType)
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
                                        " WHERE b.unit = @unit AND b.season = @season";

                command.Parameters.Add("unit", SqlDbType.Int).Value = GValues.unitId;
                command.Parameters.Add("season", SqlDbType.Int).Value = GValues.openSeasonId;

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

        public DataTable getCarte(string pDbType)
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
    }
}
