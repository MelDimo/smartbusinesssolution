using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;
using System.Reflection;
using com.sbs.dll.utilites;
using System.Drawing;
using System.IO;

namespace com.sbs.gui.dashboard
{
    class DashboardEnvironment
    {
        getReference getRefer = new getReference();

        public static com.sbs.dll.DTO_DBoard.User gUser;
        public static com.sbs.dll.DTO_DBoard.SeasonBranch gSeasonBranch;
        public static List<com.sbs.dll.DTO_DBoard.Bill> gBillList;

        public static DataTable dtNotes;
        public static DataTable dtPayment;
        public static DataTable dtRefPrintersType;

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
                                        " WHERE bp.branch = @branch AND ref_status = @refStatus "+
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

    internal class DBaccess
    {
        getReference getRefer = new getReference();

        private DataTable dtResult;

        private SqlConnection con;
        private SqlCommand command = null;
        private SqlTransaction tx = null;

        private DTO_DBoard.SeasonBranch[] oSeasonBranchArray;
        private DTO_DBoard.SeasonBranch oSeasonBranch;
        private DTO_DBoard.User oUser;
        private DTO_DBoard.UserACL[] oUserACL;

        internal DTO_DBoard.User getMifareUser(string pDbType, string pKeyId)
        {
            oUser = new com.sbs.dll.DTO_DBoard.User();

            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT u.id, u.fname + ' ' + substring(u.lname, 1, 1)+ '.' AS fio, u.tabn" +
                                        " FROM users_pwd upwd" +
                                        " INNER JOIN users u ON u.id = upwd.users "+ //AND u.branch = @branch" +
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
            oUser = new com.sbs.dll.DTO_DBoard.User();

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
            for(int i = 0; i < dtResult.Rows.Count; i++)
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

        internal List<DTO_DBoard.Dish> getBillInfo(string pDbType, DTO_DBoard.Bill pBill)
        {
            List<DTO_DBoard.Dish> oBillInfoList = new List<DTO_DBoard.Dish>();
            DTO_DBoard.Dish oDish = new DTO_DBoard.Dish();
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

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

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                oDish = new com.sbs.dll.DTO_DBoard.Dish();
                oDish.id = (int)dtResult.Rows[i]["id"];
                oDish.carteDishes = (int)dtResult.Rows[i]["carte_dishes"];
                oDish.refDishes = (int)dtResult.Rows[i]["ref_dishes"];
                oDish.name = dtResult.Rows[i]["dishes_name"].ToString();
                oDish.price = (decimal)dtResult.Rows[i]["dishes_price"];
                oDish.minStep = (decimal)dtResult.Rows[i]["minStep"];
                oDish.count = (decimal)dtResult.Rows[i]["xcount"];
                oDish.dateStatus = (DateTime)dtResult.Rows[i]["date_status"];
                oDish.refStatus = (int)dtResult.Rows[i]["ref_status"];
                oDish.refNotes = (int)dtResult.Rows[i]["ref_notes"];
                oDish.refNotesName = dtResult.Rows[i]["ref_notes_name"].ToString();
                oBillInfoList.Add(oDish);
            }

            return oBillInfoList;
        }

        internal DTO_DBoard.Bill BillOpen(string pDbType, int pNumbTable)
        {
            DTO_DBoard.Bill oBill = new DTO_DBoard.Bill();
            dtResult = new DataTable();

            oBill.openDate = DateTime.Now;
            oBill.refStat = 19;
            oBill.table = pNumbTable;

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                tx = con.BeginTransaction();
                command.Transaction = tx;

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

                tx.Commit();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }

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
                                        " WHERE branch = @branch AND ref_status = @refStatus " +
                                        " ORDER BY name ";

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
                                        (sCarte.Equals(string.Empty) ? string.Empty : " WHERE carte in (" + sCarte + ") ") +
                                        " ORDER BY id_parent, name ";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtGrop.Load(dr);
                }

                #endregion

                command.Parameters.Clear();

                foreach (DataRow dr in dtGrop.Rows) sGroup += dr["id"].ToString() + ",";

                sGroup = sGroup.TrimEnd(',');

                #region carte_dishes

                command.CommandText = " SELECT id, carte_dishes_group, ref_dishes, name, price, minStep, isvisible, avalHall, avalDelivery, ref_printers_type " +
                                        " FROM carte_dishes " +
                                        (sGroup.Equals(string.Empty) ? string.Empty : " WHERE ref_status = 1 AND isVisible = 1 AND carte_dishes_group in (" + sGroup + ") "+
                                        " ORDER BY name "); 
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

        internal int addDish2Bill(string pDbType, DTO_DBoard.Bill pBill, DTO_DBoard.Dish pDish, int pToppingsCount)
        {
            int billInfoId;

            try
            {
                con = new DBCon().getConnection(pDbType);
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DishToBill_Add";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pDishId", SqlDbType.Int).Value = pDish.id;
                command.Parameters.Add("pRefDishes", SqlDbType.Int).Value = pDish.refDishes;
                command.Parameters.Add("dishesName", SqlDbType.NVarChar).Value = pDish.name;
                command.Parameters.Add("pCount", SqlDbType.Decimal).Value = pDish.count;
                command.Parameters.Add("dishesPrice", SqlDbType.Decimal).Value = pDish.price;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;
                command.Parameters.Add("pDateAdd", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("pNote", SqlDbType.Int).Value = pDish.refNotes;
                command.Parameters.Add("pToppingsCount", SqlDbType.Int).Value = pToppingsCount;
                command.Parameters.Add("pOutBillInfoId", SqlDbType.Int);
                command.Parameters["pOutBillInfoId"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                billInfoId = (int)command.Parameters["pOutBillInfoId"].Value;

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return billInfoId;
        }

        internal void addDish2Bill_remove(string pDbType, int pDishId)
        {
            try
            {
                con = new DBCon().getConnection(pDbType);
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM biils_info WHERE id = @id";

                command.Parameters.Add("dishId", SqlDbType.Int).Value = pDishId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void addDish2Bill_toppings(string pDbType, int dishId, DTO_DBoard.Bill pBill, DTO_DBoard.Dish pDish, DataTable dtToppings)
        {
            try
            {
                con = new DBCon().getConnection(pDbType);
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DishToBill_AddToppings";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBills", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pBillsInfo", SqlDbType.Int).Value = dishId;
                command.Parameters.Add("pToppingsCarteDishes", SqlDbType.Int);
                command.Parameters.Add("isSelected", SqlDbType.Int);

                foreach (DataRow dr in dtToppings.AsEnumerable())
                {
                    command.Parameters["pToppingsCarteDishes"].Value = dr["id"];
                    command.Parameters["isSelected"].Value = dr["isSelected"];

                    command.ExecuteNonQuery();
                }

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

        internal void BillInfoCancel(string pDbType, DTO_DBoard.Bill pBill)
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

        internal DataSet commitDish(string pDbType, DTO_DBoard.Bill pBill)
        {
            DataSet dsResult = new DataSet();

            try
            {
                con = new DBCon().getConnection(pDbType);

                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Transaction = tx;

                dsResult = printRunners(command, pBill); // Возвращаем перечень блюд для бегунка

                command.CommandText = "DishToBill_changeStatus";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Clear();

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;
                command.Parameters.Add("pStatusId", SqlDbType.Int).Value = 24; // Позиция была отправлена на изготовление
                command.Parameters.Add("pDateStatus", SqlDbType.DateTime).Value = DateTime.Now;
                
                command.ExecuteNonQuery();

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); dtResult = null; con.Close(); } }

            return dsResult;
        }

        private DataSet printRunners(SqlCommand command, DTO_DBoard.Bill pBill)
        {
            DataSet dsResult = new DataSet();

            DataTable tPrintersType = new DataTable();

            command.CommandText = " SELECT d.ref_printers_type " +
                                    " FROM bills_info bi " +
                                    " INNER JOIN carte_dishes d ON d.id = bi.carte_dishes " +
                                    " WHERE bi.bills = @bills AND bi.ref_status = @refStatus " +
                                    " GROUP BY d.ref_printers_type";

            command.CommandType = CommandType.Text;

            command.Parameters.Clear();

            command.Parameters.Add("refStatus", SqlDbType.Int).Value = 23;
            command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.id;

            using (SqlDataReader sdr = command.ExecuteReader()) //------------------------- типы принтеров
            {
                tPrintersType.Load(sdr);
            }

            command.Parameters.Clear();
            command.CommandText = " SELECT bi.id," +
                                            " d.name, " +
                                            " b.numb, " +
                                            " sum(bi.xcount) AS xcount,  " +
                                            " rp.name AS printerName,  " +
                                            " rn.note " +
                                    " FROM bills_info bi " +
                                    " INNER JOIN carte_dishes d ON d.id = bi.carte_dishes " +
                                    " INNER JOIN bills b ON b.id = bi.bills " +
                                    " LEFT JOIN unit u ON u.branch = b.branch AND u.ref_printers_type = d.ref_printers_type " +
                                    " LEFT JOIN ref_printers rp ON rp.id = u.ref_printers " +
                                    " LEFT JOIN ref_reports rr ON rr.ref_printers_type = d.ref_printers_type " +
                                    " LEFT JOIN ref_notes rn ON rn.id = bi.ref_notes AND rn.ref_notes_type = 2 " +
                                    " WHERE bi.bills = @bills AND bi.ref_status = @refStatus AND d.ref_printers_type = @printersType " +
                                    " GROUP BY bi.id, d.name, b.numb, rp.name, rn.note";

            command.Parameters.Add("refStatus", SqlDbType.Int);
            command.Parameters.Add("printersType", SqlDbType.Int);
            command.Parameters.Add("bills", SqlDbType.Int);

            foreach (DataRow dr in tPrintersType.Rows)
            {
                command.Parameters["refStatus"].Value = 23;
                command.Parameters["printersType"].Value = (int)dr["ref_printers_type"];
                command.Parameters["bills"].Value = pBill.id;

                dtResult = new DataTable();

                using (SqlDataReader sdr = command.ExecuteReader()) //------------------------- Блюда
                {
                    dtResult.Load(sdr);
                    dtResult.TableName = dr["ref_printers_type"].ToString();
                    dsResult.Tables.Add(dtResult);
                }
            }

            command.Parameters.Clear();
            command.CommandText = " SELECT bi.id AS billsInfo," +
                                            " cd.name " +
                                    " FROM bills_info_toppings bitop " +
                                    " INNER JOIN bills_info bi ON bi.id = bitop.bills_info " +
                                    " INNER JOIN toppings_carte_dishes tcd ON tcd.id = bitop.toppings_carte_dishes " +
                                    " INNER JOIN carte_dishes cd ON cd.id = tcd.carte_dishes " +
                                    " WHERE bi.bills = @bills AND bi.ref_status = @refStatus AND bitop.isSelected = 1 " +
                                    " ORDER BY bi.id ";

            command.Parameters.Add("refStatus", SqlDbType.Int).Value = 23;
            command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.id;

            dtResult = new DataTable();

            using (SqlDataReader sdr = command.ExecuteReader()) //------------------------- Топпинги
            {
                dtResult.Load(sdr);
                dtResult.TableName = "toppings";
                dsResult.Tables.Add(dtResult);
            }

            return dsResult;
        }

        private DataSet printRunners_crystal(SqlCommand command, DTO_DBoard.Bill pBill)
        {
            DataSet dsResult = new DataSet();
            dtResult = new DataTable();
            dtResult.TableName = "preOrder";

            command.CommandText = "SELECT bi. id, d.name, bi.xcount, d.ref_printers_type, rp.name AS printerName, rr.xpath AS reportPath, bi.ref_status, rn.note " +
                                        " FROM bills_info bi " +
                                        " INNER JOIN carte_dishes d ON d.id = bi.carte_dishes " +
                                        " INNER JOIN bills b ON b.id = bi.bills" +
                                        " LEFT JOIN unit u ON u.branch = b.branch AND u.ref_printers_type = d.ref_printers_type " +
                                        " LEFT JOIN ref_printers rp ON rp.id = u.ref_printers " +
                                        " LEFT JOIN ref_reports rr ON rr.ref_printers_type = d.ref_printers_type " +
                                        " LEFT JOIN ref_notes rn ON rn.id = bi.ref_notes AND rn.ref_notes_type = 2 " +
                                        " WHERE bi.bills = @bills AND bi.ref_status = @refStatus ";
            
            command.CommandType = CommandType.Text;

            command.Parameters.Clear();

            command.Parameters.Add("refStatus", SqlDbType.Int).Value = 23;
            command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.id;

            using (SqlDataReader dr = command.ExecuteReader())
            {
                dtResult.Load(dr);
                dsResult.Tables.Add(dtResult);
            }

            dtResult = new DataTable();
            dtResult.TableName = "orderToppings";

            command.CommandText = "SELECT bi.id AS billsInfo, cd.name " +
                                    "FROM bills_info_toppings bitop " +
                                    "INNER JOIN bills_info bi ON bi.id = bitop.bills_info " +
                                    "INNER JOIN toppings_carte_dishes tcd ON tcd.id = bitop.toppings_carte_dishes " +
                                    "INNER JOIN carte_dishes cd ON cd.id = tcd.carte_dishes " +
                                    "WHERE bi.bills = @bills AND bi.ref_status = @refStatus AND bitop.isSelected = 1 " +
                                    "ORDER BY bi.id";

            using (SqlDataReader dr = command.ExecuteReader())
            {
                dtResult.Load(dr);
                dsResult.Tables.Add(dtResult);
            }
            return dsResult;
        }

        internal DataSet billClose(string pDbType, DTO_DBoard.Bill pBill)
        {
            DataSet dsResult = new DataSet();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Connection = con;
                command.Transaction = tx;

                if (pBill.oDiscountInfo.id != 0) setDiscount(command, pBill); // есть оплата по карте

                command.CommandText = "BillClose";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Clear();

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pPaymentType", SqlDbType.Int).Value = pBill.paymentType;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;

                command.ExecuteNonQuery();

                dsResult = printBill(command, pBill);

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); con.Close(); } }

            return dsResult;
        }

        private void setDiscount(SqlCommand command, DTO_DBoard.Bill pBill)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BillClose_setDiscount";

            command.Parameters.Clear();

            command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
            command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
            command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
            command.Parameters.Add("pDiscount", SqlDbType.Decimal).Value = pBill.oDiscountInfo.discount;
            command.Parameters.Add("pUsersDiscount", SqlDbType.Int).Value = pBill.oDiscountInfo.id;

            command.ExecuteNonQuery();
        }

        private DataSet printBill(SqlCommand command, DTO_DBoard.Bill pBill)
        {
            DataSet dsResult = new DataSet();

            dsResult.Tables.Add(new DataTable("order"));
            dsResult.Tables.Add(new DataTable("deliveryOrder"));

            command.CommandText = "SELECT bi.dishes_name AS name, bi.dishes_price AS price, sum(bi.xcount) as xcount, bi.discount, " +
                                        " rp.name AS printerName, rr.xpath AS reportPath " +
                                        " FROM bills_info bi " +
                                        " INNER JOIN bills b ON b.id = bi.bills " +
                                        " INNER JOIN unit u ON u.branch = b.branch AND u.ref_printers_type = @ref_printers_type " +
                                        " LEFT JOIN ref_printers rp ON rp.id = u.ref_printers " +
                                        " LEFT JOIN ref_reports rr ON rr.ref_printers_type = u.ref_printers_type AND logName = @logName " +
                                        " WHERE bi.bills = @bills AND bi.ref_status = @ref_status AND bi.branch = @branch AND bi.season = @season " +
                                        " GROUP BY bi.dishes_name, bi.dishes_price, rp.name, rr.xpath, bi.discount ";

            command.CommandType = CommandType.Text;

            command.Parameters.Clear();
            command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
            command.Parameters.Add("season", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
            command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = 3;
            command.Parameters.Add("ref_status", SqlDbType.Int).Value = 24;
            command.Parameters.Add("logName", SqlDbType.NVarChar).Value = "bill";
            command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.id;

            using (SqlDataReader dr = command.ExecuteReader())
            {
                dsResult.Tables["order"].Load(dr);
            }

            
            if (pBill.oDelivery.bills != 0) // есть доставка
            {
                dtResult = new DataTable();

                command.CommandText = "SELECT rdd.name AS driverName, " +
                                                " u.lname + ' ' +u.fname + ' ' + u.sname AS userName, " +
                                                " rdc.phone AS xphone, " +
                                                " 'г.' + rc.name +  " +
                                                " ' ул.' + rdc.street + " +
                                                " ' д.' + rdc.house + " +
                                                " CASE WHEN rdc.korp = '' THEN '' ELSE ' кор.' + rdc.korp END + " +
                                                " CASE WHEN rdc.app = '' THEN '' ELSE ' кв.' + rdc.app END + " +
                                                " CASE WHEN rdc.porch = '' THEN '' ELSE ' п.' + rdc.porch END + " +
                                                " CASE WHEN rdc.code = '' THEN '' ELSE ' код' + rdc.code END + " +
                                                " CASE WHEN rdc.[floor] = '' THEN '' ELSE ' эт.' + rdc.[floor] END AS xaddr, " +
                                                " b.[sum] billSum, " +
                                                " rdt.xprice xtariff, " +
                                                " rp.name AS printerName, " +
		                                        " 'reports\\deliveryOrder.rpt' AS reportPath " +
                                        " FROM bills b " +
                                        " INNER JOIN users u ON u.id = b.user_open " +
                                        " INNER JOIN bills_info_delivery bid ON bid.bills = b.id " +
                                        " INNER JOIN ref_delivery_drivers rdd ON rdd.id = bid.ref_driver " +
                                        " INNER JOIN ref_delivery_tariff rdt ON rdt.id = bid.ref_delivery_tariff " +
                                        " INNER JOIN ref_delivery_clients rdc ON rdc.id = bid.ref_delivery_client " +
                                        " INNER JOIN ref_city rc ON rc.id = rdc.ref_city " +
                                        " LEFT JOIN unit un ON un.branch = b.branch AND un.ref_printers_type = @ref_printers_type " +
                                        " LEFT JOIN ref_printers rp ON rp.id = un.ref_printers " +
                                        " LEFT JOIN ref_reports rr ON rr.ref_printers_type = un.ref_printers_type AND rr.logName = 'bill' " +
                                        " WHERE b.id = @bId AND b.branch = @branch AND b.season = @season ";

                command.CommandType = CommandType.Text;

                command.Parameters.Clear();
                command.Parameters.Add("bId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = 3;
                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("season", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dsResult.Tables["deliveryOrder"].Load(dr);
                }
            }

            return dsResult;
        }

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

        #region ------------------------------------------------------------ Закрытие смен

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

        #endregion

        internal void dishRefuse(string pDbType, DTO_DBoard.Bill pBill, DTO_DBoard.Dish pDish, int pNewCount)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DishToBill_Refuse";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pDish2BillId", SqlDbType.Int).Value = pDish.id;
                command.Parameters.Add("pUser", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;
                command.Parameters.Add("pNewCount", SqlDbType.Int).Value = pNewCount;
                command.Parameters.Add("pDateTime", SqlDbType.DateTime).Value = DateTime.Now;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
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

        internal void addRefuse2Bill(string pDbType, DTO_DBoard.Bill pBill, DTO_DBoard.Dish pDish)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "DishToBill_AddRefuse";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pId", SqlDbType.Int).Value = pDish.id;
                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pDishId", SqlDbType.Int).Value = pDish.carteDishes;
                command.Parameters.Add("pRefDishes", SqlDbType.Int).Value = pDish.refDishes;
                command.Parameters.Add("dishesName", SqlDbType.NVarChar).Value = pDish.name;
                command.Parameters.Add("pCount", SqlDbType.Decimal).Value = pDish.count;
                command.Parameters.Add("dishesPrice", SqlDbType.Decimal).Value = pDish.price;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = DashboardEnvironment.gUser.id;
                command.Parameters.Add("pDateAdd", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("pNote", SqlDbType.Int).Value = pDish.refNotes;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal Report REP_xOrder(string pDbType)
        {
            Report oReport = new Report();
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.Connection = con;

                command.CommandText = "REP_xOrder";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeasonId", SqlDbType.Int).Value = DashboardEnvironment.gSeasonBranch.seasonID;
                command.Parameters.Add("repPath", SqlDbType.NVarChar, 128);
                command.Parameters["repPath"].Direction = ParameterDirection.Output;
                command.Parameters.Add("printerName", SqlDbType.NVarChar, 128);
                command.Parameters["printerName"].Direction = ParameterDirection.Output;
                command.Parameters.Add("pConType", SqlDbType.NVarChar, 8).Value = pDbType;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                dtResult.TableName = "xReport";
                oReport = new Report() { repPath = command.Parameters["repPath"].Value.ToString(),
                                         printName = command.Parameters["printerName"].Value.ToString(),
                                         dtReport = dtResult};
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }

            return oReport;
        }

        internal DTO.DiscountInfo getMifareDiscountInfo(string pDbType, string pKey)
        {
            DTO.DiscountInfo oDiscountInfo = new DTO.DiscountInfo();

            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                dtResult = getRefer.getDiscountUsers(pDbType, pKey);
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                oDiscountInfo = new DTO.DiscountInfo();
                oDiscountInfo.id = (int)dtResult.Rows[i]["id"];
                oDiscountInfo.fio = dtResult.Rows[i]["fio"].ToString();
                oDiscountInfo.xKey = dtResult.Rows[i]["xkey"].ToString();
                oDiscountInfo.discount = (decimal)dtResult.Rows[i]["discount"];
                oDiscountInfo.isExpDate = (int)dtResult.Rows[i]["isExpDate"];
                oDiscountInfo.refStatus = (int)dtResult.Rows[i]["ref_status"];
                oDiscountInfo.dateStart = (DateTime)dtResult.Rows[i]["date_start"];
                if (oDiscountInfo.isExpDate == 1) oDiscountInfo.dateEnd = (DateTime)dtResult.Rows[i]["date_start"];
                oDiscountInfo.photo = Image.FromStream(new MemoryStream((byte[])dtResult.Rows[i]["photo"]));
            }

            return oDiscountInfo;
        }
    }

    internal class Report
    {
        public string repPath;
        public string printName;
        public DataTable dtReport;
    }
}
