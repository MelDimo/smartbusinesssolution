using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.dashboard
{
    static class DashboardEnveronvent
    {
        public static SeasonBranch gSeasonBranch;
        public static SeasonBranch[] gSeasonBranchArray;
        public static User gUser;
    }
    class DBaccess
    {
        private DataTable dtResult = new DataTable();

        private SqlConnection con;
        private SqlCommand command = null;
        private SqlTransaction tx = null;

        private SeasonBranch[] oSeasonBranchArray;
        private SeasonUser oSeasonUser;
        private User oUser;
        private UserACL[] oUserACL;
        private Bill oBill;
        private Dish oDish;

        internal User getMifareUser(string pDbType, string pKeyId)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT u.id, lname+' '+ substring(fname,1,1) +'. '+ substring(sname,1,1) + '.' AS fio, u.tabn" +
                                        " FROM users_pwd upwd" +
                                        " INNER JOIN users u ON u.id = upwd.users AND u.branch = @branch" +
                                        " WHERE upwd.pwd = @pwd";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pwd", SqlDbType.NVarChar).Value = pKeyId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            switch (dtResult.Rows.Count)
            {
                case 0:
                    throw new Exception("Сотрудник не найден");

                case 1:
                    break;

                default:
                    throw new Exception("Найдено больше одного сотрудника удовлетворяющего параметрам.");
            }

            oUser = new User();
            oUser.id = (int)dtResult.Rows[0]["id"];
            oUser.name = dtResult.Rows[0]["fio"].ToString();
            oUser.tabn = dtResult.Rows[0]["tabn"].ToString();
            
            try
            {
                oUser.oUserACL = getUserACL(oUser.id);
            }
            catch (Exception exc) { throw exc; }

            return oUser;
        }

        private UserACL[] getUserACL(int pUserId)
        {
            dtResult = new DataTable();

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ua.user_acl_type, uat.name " +
                                            " FROM users_acl ua " +
                                            " INNER JOIN users_acl_type uat ON uat.id = ua.user_acl_type " +
                                            " WHERE ua.users = @usersId";

                command.Parameters.Add("@usersId", SqlDbType.Int).Value = pUserId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            oUserACL = new UserACL[dtResult.Rows.Count];
            for(int i = 0; i < dtResult.Rows.Count; i++)
            {
                oUserACL[i] = new UserACL();
                oUserACL[i].id = (int)dtResult.Rows[i]["user_acl_type"];
                oUserACL[i].name = dtResult.Rows[i]["name"].ToString();
            }

            return oUserACL;
        }

        internal SeasonBranch[] getAvaliableSeason(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT s.id seasonId, u.id userId, s.date_open, u.lname + ' ' + u.fname + ' ' + u.sname as fio, stat.name as status_name " +
                                        " FROM season s " +
                                        " INNER JOIN users u ON u.id = s.user_open" +
                                        " INNER JOIN ref_status stat ON stat.id = s.ref_status" +
                                        " WHERE s.branch = @branch AND s.ref_status = @ref_status";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 16;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            oSeasonBranchArray = new SeasonBranch[dtResult.Rows.Count];
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                oSeasonBranchArray[i] = new SeasonBranch();
                oSeasonBranchArray[i].seasonID = (int)dtResult.Rows[i]["seasonId"];
                oSeasonBranchArray[i].userID = (int)dtResult.Rows[i]["userId"];
                oSeasonBranchArray[i].userName = (string)dtResult.Rows[i]["fio"];
                oSeasonBranchArray[i].dateOpen = (DateTime)dtResult.Rows[i]["date_open"];
            }

            return oSeasonBranchArray;
        }
    }

    public class SeasonBranch
    {
        public int seasonID { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public DateTime dateOpen { get; set; }
        public DateTime? dateClose { get; set; }
    }

    public class SeasonUser
    {
        public int id { get; set; }
        public string idUser { get; set; }
        public DateTime dateOpen { get; set; }
        public DateTime? dateClose { get; set; }
    }

    public class User : UserACL
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tabn { get; set; }
        public UserACL[] oUserACL { get; set; }
    }

    public class UserACL
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Bill
    {
        public int id { get; set; }
    }

    public class Dish
    {
        public int id { get; set; }
        public string name { get; set; }
    }


}
