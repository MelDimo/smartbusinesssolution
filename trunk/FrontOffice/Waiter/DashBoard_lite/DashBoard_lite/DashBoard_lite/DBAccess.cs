using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll.utilites;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using com.sbs.dll;

namespace com.sbs.gui.dashboard
{
    class DashboardEnvironment
    {
        getReference getRefer = new getReference();

        public static com.sbs.dll.DTO_DBoard.User gUser;
        public static com.sbs.dll.DTO_DBoard.SeasonBranch gSeasonBranch;
        public static List<com.sbs.dll.DTO_DBoard.Bill> gBillList;

        public static DataTable dtNotes = new DataTable();
        public static DataTable dtPayment = new DataTable();
        public static DataTable dtRefPrintersType = new DataTable();

        public static void initRefDataTables()
        {
            SqlConnection con;
            SqlCommand command = null;

            dtNotes = new DataTable();

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT 0 as id, 0 as ref_notes_type, '<Выберите комментарий>' as note" +
                                        "    UNION" +
                                        " SELECT id, ref_notes_type, note " +
                                        "   FROM ref_notes WHERE ref_status = @ref_status" +
                                        " ORDER BY note";
                command.Parameters.Clear();

                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtNotes.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public static void initPayment()
        {
            SqlConnection con;
            SqlCommand command = null;

            dtPayment = new DataTable();

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = " SELECT rpt.id, rpt.name, rpt.color" +
                                        " FROM branch_payment bp " +
                                        " INNER JOIN ref_payment_type rpt ON rpt.id = bp.ref_payment_type" +
                                        " WHERE bp.branch = @branch AND ref_status = @refStatus " +
                                        " ORDER BY rpt.name";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("refStatus", SqlDbType.Int).Value = 1;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtPayment.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public static void initPrintersType()
        {
            getReference getRefer = new getReference();

            try
            {
                dtRefPrintersType = getRefer.getRefPrintersType(GValues.DBMode);
            }
            catch (Exception exc) { throw exc; }
        }

        public static void Clear()
        {
            gUser = null;
            gSeasonBranch = null;
            gBillList = null;
        }

        public static Assembly assTimeTrack { get; set; }
    }

    class DBaccess
    {
        private DataTable dtResult;

        private SqlConnection con;
        private SqlCommand command = null;
        private SqlTransaction tx = null;

        private DTO_DBoard.SeasonBranch[] oSeasonBranchArray;
        private DTO_DBoard.SeasonBranch oSeasonBranch;
        private DTO_DBoard.User oUser;
        private DTO_DBoard.UserACL[] oUserACL;

        internal List<DTO_DBoard.SeasonUser> getSeasonUser(string pDbType, DTO_DBoard.User pUser)
        {
            dtResult = new DataTable();
            List<com.sbs.dll.DTO_DBoard.SeasonUser> lSeasonUser = new List<com.sbs.dll.DTO_DBoard.SeasonUser>();
            com.sbs.dll.DTO_DBoard.SeasonUser oSeasonUser;

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
                oSeasonUser = new com.sbs.dll.DTO_DBoard.SeasonUser();
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

        internal DTO_DBoard.User getMifareUser(string pDbType, string pKeyId)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT u.id, u.fname + ' ' + substring(u.lname, 1, 1)+ '.' AS fio, u.tabn" +
                                        " FROM users_pwd upwd" +
                                        " INNER JOIN users u ON u.id = upwd.users " + //AND u.branch = @branch" +
                                        " WHERE upwd.pwd = @pwd";

                //command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
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

            oUser = new com.sbs.dll.DTO_DBoard.User();
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

        internal DTO_DBoard.User getLoginUser(string pDbType, string pPwd)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT u.id, u.fname + ' ' + substring(u.lname, 1, 1)+ '.' AS fio, u.tabn" +
                                        " FROM users_pwd upwd" +
                                        " INNER JOIN users u ON u.id = upwd.users" +// AND u.branch = @branch" +
                                        " WHERE upwd.pwd = @pwd";

                //command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pwd", SqlDbType.NVarChar).Value = pPwd;

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

            oUser = new com.sbs.dll.DTO_DBoard.User();
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

        private DTO_DBoard.UserACL[] getUserACL(string pDbType, int pUserId)
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

            oUserACL = new com.sbs.dll.DTO_DBoard.UserACL[dtResult.Rows.Count];
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                oUserACL[i] = new com.sbs.dll.DTO_DBoard.UserACL();
                oUserACL[i].id = (int)dtResult.Rows[i]["user_acl_type"];
                oUserACL[i].name = dtResult.Rows[i]["name"].ToString();
            }

            return oUserACL;
        }

        internal DTO_DBoard.SeasonBranch[] getAvaliableSeason(string pDbType)
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

            oSeasonBranchArray = new com.sbs.dll.DTO_DBoard.SeasonBranch[dtResult.Rows.Count];
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                oSeasonBranchArray[i] = new com.sbs.dll.DTO_DBoard.SeasonBranch();
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

            oSeasonBranch = new com.sbs.dll.DTO_DBoard.SeasonBranch();
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

        internal void seasonUser_Close(string pDbType, DTO_DBoard.User pUser)
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

        internal void seasonBranch_Close(string pDbType)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SeasonClose";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;
                command.Parameters.Add("pDateClose", SqlDbType.DateTime).Value = DateTime.Now;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal List<DTO_DBoard.Bill> getBills(string pDbType, DTO_DBoard.User pUser)
        {
            List<com.sbs.dll.DTO_DBoard.Bill> oBillList = new List<com.sbs.dll.DTO_DBoard.Bill>();
            com.sbs.dll.DTO_DBoard.Bill oBill = new com.sbs.dll.DTO_DBoard.Bill();
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
                command.Parameters.Add("pUserOpen", SqlDbType.Int).Value = pUser.id;

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
                oBill = new DTO_DBoard.Bill();
                oBill.id = (int)dtResult.Rows[i]["id"];
                oBill.numb = (int)dtResult.Rows[i]["numb"];
                oBill.openDate = (DateTime)dtResult.Rows[i]["date_open"];
                oBill.closeDate = (DateTime?)dtResult.Rows[i]["date_open"];
                oBill.refStat = (int)dtResult.Rows[i]["ref_status"];
                oBill.refStatName = dtResult.Rows[i]["ref_status_name"].ToString();
                oBill.table = (int)dtResult.Rows[i]["xTable"];
                oBill.summ = (decimal)dtResult.Rows[i]["summa"];
                oBill.summFact = (decimal)dtResult.Rows[i]["summa"];
                oBill.dishCount = (int)dtResult.Rows[i]["itemCount"];
                oBill.oDelivery.bills = (int)dtResult.Rows[i]["bid_bills"];
                oBill.oDelivery.branch = (int)dtResult.Rows[i]["bid_branch"];
                oBill.oDelivery.season = (int)dtResult.Rows[i]["bid_season"];
                oBill.oDelivery.cardNumber = dtResult.Rows[i]["bid_discountNumber"].ToString();
                oBill.oDelivery.comment = dtResult.Rows[i]["bid_xcomment"].ToString();
                oBill.oDelivery.driverId = (int)dtResult.Rows[i]["bid_driver"];
                oBill.oDelivery.tariff = (int)dtResult.Rows[i]["bid_tariff"];
                oBill.oDelivery.deliveryClient.telNumb = dtResult.Rows[i]["rdc_phone"].ToString();
                oBill.oDelivery.deliveryClient.fio = dtResult.Rows[i]["rdc_fio"].ToString();
                oBill.oDelivery.deliveryClient.addr_city = (int)dtResult.Rows[i]["rdc_refCity"];
                oBill.oDelivery.deliveryClient.addr_str = dtResult.Rows[i]["rdc_street"].ToString();
                oBill.oDelivery.deliveryClient.addr_house = dtResult.Rows[i]["rdc_house"].ToString();
                oBill.oDelivery.deliveryClient.addr_korp = dtResult.Rows[i]["rdc_korp"].ToString();
                oBill.oDelivery.deliveryClient.addr_app = dtResult.Rows[i]["rdc_app"].ToString();
                oBill.oDelivery.deliveryClient.addr_porch = dtResult.Rows[i]["rdc_porch"].ToString();
                oBill.oDelivery.deliveryClient.addr_code = dtResult.Rows[i]["rdc_code"].ToString();
                oBill.oDelivery.deliveryClient.addr_floor = dtResult.Rows[i]["rdc_floor"].ToString();


                oBillList.Add(oBill);
            }

            return oBillList;
        }

        internal List<DTO_DBoard.DishRefuse> getRefuse(string pDbType, string pDishesFilter)
        {
            DTO_DBoard.DishRefuse oDishRefuse;
            List<DTO_DBoard.DishRefuse> lDishesRefuse = new List<DTO_DBoard.DishRefuse>();

            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DishToBill_refuseGet";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            dtResult.DefaultView.RowFilter = pDishesFilter;
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                if ((int)dtResult.Rows[i][pDishesFilter.Substring(0, pDishesFilter.IndexOf(' '))] != 1) continue;
                oDishRefuse = new DTO_DBoard.DishRefuse();
                oDishRefuse.id = (int)dtResult.Rows[i]["id"];
                oDishRefuse.carteDishes = (int)dtResult.Rows[i]["carte_dishes"];
                oDishRefuse.refDishes = (int)dtResult.Rows[i]["ref_dishes"];
                oDishRefuse.name = dtResult.Rows[i]["name"].ToString();
                oDishRefuse.minStep = (decimal)dtResult.Rows[i]["minStep"];
                oDishRefuse.count = (decimal)dtResult.Rows[i]["xcount"];
                oDishRefuse.price = (decimal)dtResult.Rows[i]["price"];
                oDishRefuse.refuseDate = (DateTime)dtResult.Rows[i]["date_refuse"];
                oDishRefuse.refuseFio = dtResult.Rows[i]["fio"].ToString();
                oDishRefuse.refPrintersType = (int)dtResult.Rows[i]["ref_printers_type"];
                oDishRefuse.refStatus = (int)dtResult.Rows[i]["ref_status"];
                lDishesRefuse.Add(oDishRefuse);
            }

            return lDishesRefuse;
        }
    }
}
