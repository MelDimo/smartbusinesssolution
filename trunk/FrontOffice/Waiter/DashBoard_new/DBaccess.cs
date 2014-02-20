using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.dashboard
{
    class DashboardEnvironment
    {
        public static User gUser;
        public static SeasonBranch gSeasonBranch;
        public static List<Bill> gBillList;

        public static void Clear()
        {
            gUser = null;
            gSeasonBranch = null;
            gBillList = null;
        }
    }

    internal class DBaccess
    {
        private DataTable dtResult;

        private SqlConnection con;
        private SqlCommand command = null;
        private SqlTransaction tx = null;

        private SeasonBranch[] oSeasonBranchArray;
        private SeasonBranch oSeasonBranch;
        private User oUser;
        private UserACL[] oUserACL;

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
                oUser.oUserACL = getUserACL(pDbType, oUser.id);
            }
            catch (Exception exc) { throw exc; }

            return oUser;
        }

        private UserACL[] getUserACL(string pDbType, int pUserId)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ua.user_acl_type, uat.name " +
                                        " FROM users u " +
                                        " INNER JOIN users_acl ua ON ua.users = u.id " +
                                        " INNER JOIN users_acl_type uat ON uat.id = ua.user_acl_type " +
                                        " WHERE u.id = @usersId " +
                                        "       UNION " +
                                        " SELECT ga.user_acl_type, uat.name " +
                                        " FROM users_groups u " +
                                        " INNER JOIN groups_acl ga ON ga.groups = u.groups " +
                                        " INNER JOIN users_acl_type uat ON uat.id = ga.user_acl_type " +
                                        " WHERE u.users = @usersId";

                command.Parameters.Add("usersId", SqlDbType.Int).Value = pUserId;

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

        internal void openNewSeason(string pDbType)
        {
            con = new DBCon().getConnection(pDbType);

            oSeasonBranch = new SeasonBranch();
            oSeasonBranch.dateOpen = DateTime.Now;
            oSeasonBranch.userID = DashboardEnvironment.gUser.id;
            oSeasonBranch.userName = DashboardEnvironment.gUser.name;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SeasonOpen";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pDateOpen", SqlDbType.DateTime).Value = oSeasonBranch.dateOpen;
                command.Parameters.Add("pUserOpen", SqlDbType.Int).Value = oSeasonBranch.userID;
                command.Parameters.Add("pSeasonID", SqlDbType.Int);
                command.Parameters["pSeasonID"].Value = 0;
                command.Parameters["pSeasonID"].Direction = ParameterDirection.InputOutput;

                command.ExecuteNonQuery();

                oSeasonBranch.seasonID = (int)command.Parameters["pSeasonID"].Value;

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            DashboardEnvironment.gSeasonBranch = oSeasonBranch;
        }

        internal List<Bill> getBills(string pDbType)
        {
            List<Bill> oBillList = new List<Bill>();
            Bill oBill = new Bill();
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();


                command.CommandText = "BillsGet";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pUserOpen", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                oBill = new Bill();
                oBill.id = (int)dtResult.Rows[i]["id"];
                oBill.numb = (int)dtResult.Rows[i]["numb"];
                oBill.openDate = (DateTime)dtResult.Rows[i]["date_open"];
                oBill.refStat = (int)dtResult.Rows[i]["ref_status"];
                oBill.refStatName = dtResult.Rows[i]["ref_status_name"].ToString();
                oBill.table = (int)dtResult.Rows[i]["xTable"];
                oBill.summ = (decimal)dtResult.Rows[i]["summa"];
                oBillList.Add(oBill);
            }

            return oBillList;
        }

        internal List<Dish> getBillInfo(string pDbType, Bill pBill)
        {
            List<Dish> oBillInfoList = new List<Dish>();
            Dish oDish;
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();


                command.CommandText = "BillsInfo_get";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBills", SqlDbType.Int).Value = pBill.id;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                oDish = new Dish();
                oDish.id = (int)dtResult.Rows[i]["id"];
                oDish.name = dtResult.Rows[i]["dishes_name"].ToString();
                oDish.portion = dtResult.Rows[i]["portion"].ToString();
                oDish.price = (decimal)dtResult.Rows[i]["dishes_price"];
                oDish.count = (decimal)dtResult.Rows[i]["xcount"];
                oDish.addDate = (DateTime)dtResult.Rows[i]["date_add"];
                oDish.refStatus = (int)dtResult.Rows[i]["ref_status"];
                oBillInfoList.Add(oDish);
            }

            return oBillInfoList;
        }

        internal Bill BillOpen(string pDbType)
        {
            Bill oBill = new Bill();
            dtResult = new DataTable();

            oBill.openDate = DateTime.Now;
            oBill.refStat = 19;
            oBill.table = 0;

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "BillOpen";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBillId", SqlDbType.Int);
                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pNumber", SqlDbType.Int);
                command.Parameters.Add("pxTable", SqlDbType.Int).Value = oBill.table;
                command.Parameters.Add("pDateOpen", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("pUserOpen", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;

                command.Parameters["pNumber"].Value = 0;
                command.Parameters["pNumber"].Direction = ParameterDirection.InputOutput;
                command.Parameters["pBillId"].Value = 0;
                command.Parameters["pBillId"].Direction = ParameterDirection.InputOutput;

                command.ExecuteNonQuery();

                oBill.numb = (int)command.Parameters["pNumber"].Value;
                oBill.id = (int)command.Parameters["pBillId"].Value;

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return oBill;
        }

        internal DataSet prepareCarteDishes(string pDbType)
        {
            DataSet ds = new DataSet();
            DataTable dtCarte = new DataTable("carte");
            DataTable dtGrop = new DataTable("group");
            DataTable dtDishes = new DataTable("dishes");

            string sCarte = string.Empty;
            string sGroup = string.Empty;

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                #region carte

                command.CommandText = " SELECT id, code, name " +
                                        " FROM carte " +
                                        " WHERE branch = @branch AND ref_status = @refStatus";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("refStatus", SqlDbType.Int).Value = 1;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtCarte.Load(dr);
                }

                #endregion

                command.Parameters.Clear();

                foreach (DataRow dr in dtCarte.Rows) sCarte += dr["id"].ToString() + ",";

                sCarte = sCarte.TrimEnd(',');

                #region carte_dishes_group

                command.CommandText = " SELECT id, id_parent, carte, name " +
                                        " FROM carte_dishes_group " +
                                        (sCarte.Equals(string.Empty) ? string.Empty : " WHERE carte in (" + sCarte + ")");

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtGrop.Load(dr);
                }

                #endregion

                command.Parameters.Clear();

                foreach (DataRow dr in dtGrop.Rows) sGroup += dr["id"].ToString() + ",";

                sGroup = sGroup.TrimEnd(',');

                #region carte_dishes

                command.CommandText = " SELECT id, carte_dishes_group, ref_dishes, name, price, portion, isvisible, ref_printers_type " +
                                        " FROM carte_dishes " +
                                        (sGroup.Equals(string.Empty) ? string.Empty : " WHERE carte_dishes_group in (" + sGroup + ")"); 
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtDishes.Load(dr);
                }

                #endregion
            }
            catch (Exception exc) { throw exc;}

            ds.Tables.AddRange(new DataTable[] { dtCarte, dtGrop, dtDishes });

            return ds;

        }

        internal void addDish2Bill(string pDbType, Bill pBill, Dish pDish)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "DishToBill_Add";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pDishId", SqlDbType.Int).Value = pDish.id;
                command.Parameters.Add("dishesName", SqlDbType.NVarChar).Value = pDish.name;
                command.Parameters.Add("pCount", SqlDbType.Decimal).Value = pDish.count;
                command.Parameters.Add("dishesPrice", SqlDbType.Decimal).Value = pDish.price;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;
                command.Parameters.Add("pDateAdd", SqlDbType.DateTime).Value = DateTime.Now;
                

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void BillCancel(string pDbType)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "BillCancel";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void BillInfoCancel(string pDbType, Bill pBill)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "BillInfoCancel";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal DataTable commitDish(string pDbType, Bill pBill)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Connection = con;
                command.Transaction = tx;

                command.CommandText = "DishToBill_changeStatus";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;
                command.Parameters.Add("pStatusId", SqlDbType.Int).Value = 24; // Позиция была отправлена на изготовление
                
                command.ExecuteNonQuery();

                dtResult = printRunners(command, pBill);
                
                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }

            return dtResult;
        }

        private DataTable printRunners(SqlCommand command, Bill pBill)
        {
            dtResult = new DataTable();

            command.CommandText = "SELECT d.name, bi.xcount, d.ref_printers_type, rp.name AS printerName, rr.xpath AS reportPath" +
                                        " FROM bills_info bi" +
                                        " INNER JOIN carte_dishes d ON d.id = bi.carte_dishes" +
                                        " INNER JOIN bills b ON b.id = bi.bills" +
                                        " LEFT JOIN unit u ON u.branch = b.branch AND u.ref_printers_type = d.ref_printers_type" +
                                        " LEFT JOIN ref_printers rp ON rp.id = u.ref_printers" +
                                        " LEFT JOIN ref_reports rr ON rr.ref_printers_type = d.ref_printers_type" +
                                        " WHERE bi.bills = @bills";
            
            command.CommandType = CommandType.Text;

            command.Parameters.Clear();
            command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.id;

            using (SqlDataReader dr = command.ExecuteReader())
            {
                dtResult.Load(dr);
            }

            return dtResult;
        }

        internal DataTable billClose(string pDbType, Bill pBill)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Connection = con;
                command.Transaction = tx;

                command.CommandText = "BillClose";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;

                command.ExecuteNonQuery();

                dtResult = printBill(command, pBill);

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }

            return dtResult;

        }

        private DataTable printBill(SqlCommand command, Bill pBill)
        {
            dtResult = new DataTable();

            command.CommandText = "SELECT bi.dishes_name AS name, bi.dishes_price AS price, bi.xcount,  rp.name AS printerName, rr.xpath AS reportPath" +
                                        " FROM bills_info bi" +
                                        " INNER JOIN bills b ON b.id = bi.bills" +
                                        " INNER JOIN unit u ON u.branch = b.branch AND u.ref_printers_type = @ref_printers_type" +
                                        " LEFT JOIN ref_printers rp ON rp.id = u.ref_printers" +
                                        " LEFT JOIN ref_reports rr ON rr.ref_printers_type = u.ref_printers_type" +
                                        " WHERE bi.bills = @bills";

            command.CommandType = CommandType.Text;

            command.Parameters.Clear();
            command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = 3;
            command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.id;

            using (SqlDataReader dr = command.ExecuteReader())
            {
                dtResult.Load(dr);
            }

            return dtResult;
        }

        internal List<SeasonUser> getSeasonUser(string pDbType, User pUser)
        {
            dtResult = new DataTable();
            List<SeasonUser> lSeasonUser = new List<SeasonUser>();
            SeasonUser oSeasonUser;

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "SeasonUser_get";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = pUser == null ? 0 : pUser.id;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                oSeasonUser = new SeasonUser();
                oSeasonUser.id = (int)dtResult.Rows[i]["id"];
                oSeasonUser.userOpenName = dtResult.Rows[i]["fio"].ToString();
                oSeasonUser.dateOpen = (DateTime)dtResult.Rows[i]["date_open"];
                oSeasonUser.dateClose = (DateTime)dtResult.Rows[i]["date_open"];
                oSeasonUser.refStatus = (int)dtResult.Rows[i]["ref_status"];
                oSeasonUser.refStatusName = dtResult.Rows[i]["ref_status_name"].ToString();
                oSeasonUser.summ = (decimal)dtResult.Rows[i]["summ"];
                lSeasonUser.Add(oSeasonUser);
            }

            return lSeasonUser;
        }

        internal void seasonUser_Close(string pDbType, User pUser)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SeasonUser_close";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pUser_openSeason", SqlDbType.Int).Value = pUser.id;
                command.Parameters.Add("pUser_closeSeason", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;
                command.Parameters.Add("pDateClose", SqlDbType.DateTime).Value = DateTime.Now;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        #region ------------------------------------------------------------ Закрытие смен

        

        #endregion
    }

    public class SeasonBranch
    {
        public int seasonID { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public DateTime dateOpen { get; set; }
    }

    public class SeasonUser
    {
        public int id { get; set; }
        public string userOpenName { get; set; }
        public DateTime dateOpen { get; set; }
        public DateTime? dateClose { get; set; }
        public int refStatus { get; set; }
        public string refStatusName { get; set; }
        public decimal summ { get; set; }
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
        public int numb { get; set; }
        public int table { get; set; }
        public DateTime openDate { get; set; }
        public int refStat { get; set; }
        public string refStatName { get; set; }
        public decimal summ { get; set; }
    }

    public class Dish
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal count { get; set; }
        public string portion { get; set; }
        public DateTime? addDate { get; set; }
        public int refStatus { get; set; }
        public int refPrintersType { get; set; }
    }

    internal class Suppurt
    {
        internal bool checkPrivileges(UserACL[] pUserACL, int pUsersAclType)
        {
            foreach (UserACL uAcl in pUserACL)
            {
                if (uAcl.id == pUsersAclType) return true;
            }

            return false;
        }
    }
}
