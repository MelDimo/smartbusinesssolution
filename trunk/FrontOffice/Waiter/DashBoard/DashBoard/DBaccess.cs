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
        private SqlTransaction tx = null;

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

            return dtResult;
        }

        internal void openNewSeason(string pDbType)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO season (branch, date_open, user_open, ref_status) " +
                                        " VALUES(@branch, @date_open, @user_open, @ref_status)";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
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

        internal DataTable getAvaliableBills(string pDbType, ref Dictionary<int, List<oBillInfo>> BillInfo)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            
            try
            {
                con.Open();

                tx = con.BeginTransaction();

                command = con.CreateCommand();

                command.Transaction = tx; ;

                command.CommandText = "SELECT b.id, date_open, stat.name AS ref_status_name" +
                                        " FROM bills b" +
                                        " INNER JOIN ref_status stat ON stat.id = b.ref_status" +
                                        " WHERE b.branch = @branch AND b.season = @season AND user_open = @user_open AND b.ref_status = @ref_status";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("season", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("user_open", SqlDbType.Int).Value = UsersInfo.UserId;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 20;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                command.Parameters.Clear();

                command.CommandText = "SELECT bills, dishes, bi.dishes_name, bi.dishes_price, bi.xcount, bi.dishes_price * bi.xcount as suma, bi.ref_status, stat.name as ref_status_name, discount" +
                                        " FROM bills_info bi" +
                                        " INNER JOIN ref_status stat ON stat.id = bi.ref_status" +
                                        " WHERE bills = @bills";
                command.Parameters.Add("bills", SqlDbType.Int);

                BillInfo.Clear();

                foreach (DataRow dr in dtResult.Rows)
                {
                    command.Parameters["bills"].Value = (int)dr["id"];
                    using (SqlDataReader dreader = command.ExecuteReader())
                    {
                        List<oBillInfo> listBillInfo = new List<oBillInfo>();
                        while (dreader.Read())
                        {
                            oBillInfo billInfo = new oBillInfo();
                            billInfo.Bill = (int)dreader["bills"];
                            billInfo.Dishes = (int)dreader["dishes"];
                            billInfo.DishesName = dreader["dishes_name"].ToString();
                            billInfo.DishesPrice = double.Parse(dreader["dishes_price"].ToString());
                            billInfo.XCount = double.Parse(dreader["xcount"].ToString());
                            billInfo.Suma = double.Parse(dreader["suma"].ToString());
                            billInfo.RefStatus = (int)dreader["ref_status"];
                            billInfo.RefStatusName = dreader["ref_status_name"].ToString();
                            billInfo.Discount = double.Parse(dreader["discount"].ToString());
                            listBillInfo.Add(billInfo);
                        }

                        BillInfo.Add((int)dr["id"], listBillInfo);
                    }
                }

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }

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
                                        " WHERE branch = @branch AND ref_status = @ref_status";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
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

        /// <summary>
        /// Находим сотрудника, заполняем UserInfo
        /// </summary>
        /// <param name="pDbType"></param>
        /// <param name="pKeyId"></param>
        /// <returns></returns>
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
                                        " INNER JOIN users u ON u.id = upwd.users AND u.branch = @branch" +
                                        " INNER JOIN ref_post post ON post.id = u.ref_post" +
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

                command.CommandText = "INSERT INTO bills (branch, season, numb, date_open, user_open, ref_status) " +
                                        " VALUES(@branch, @season, dbo.nextBill(@season), @date_open, @user_open, @ref_status)";

                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("season", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("date_open", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("user_open", SqlDbType.Int).Value = UsersInfo.UserId;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 20;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void addDishToBill(string pDbType, oBill pBill, oDishes pDishes)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "DishToBill_Add";
                command.CommandType = CommandType.StoredProcedure;

                //@pSeason int, @pBillId int, @pDishId int, @pCount decimal(18,2), @pDiscount decimal(18,2), @pUserId int

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.BillId;
                command.Parameters.Add("pDishId", SqlDbType.Int).Value = pDishes.Id;
                command.Parameters.Add("pCount", SqlDbType.Int).Value = pDishes.Count;
                command.Parameters.Add("pDiscount", SqlDbType.Int).Value = pDishes.Discount;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void editDishToBill(string pDbType, oBillInfo pBillInfo, double pCount)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "DishToBill_Edit";
                command.CommandType = CommandType.StoredProcedure;

                //@pSeason int, @pBillId int, @pDishId int, @pCount decimal(18,2), @pDiscount decimal(18,2), @pUserId int

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBillInfo.Bill;
                command.Parameters.Add("pDishId", SqlDbType.Int).Value = pBillInfo.Dishes;
                command.Parameters.Add("pCount", SqlDbType.Int).Value = pCount;
                command.Parameters.Add("pDiscount", SqlDbType.Int).Value = pBillInfo.Discount;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal DataTable processBill(string pDbType, oBill bill)
        {
            dtResult = new DataTable("preOrder");

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                command = con.CreateCommand();

                command.CommandText = "SELECT d.name, bi.xcount, d.ref_printers_type, rp.name AS printerName, rr.xpath AS reportPath" +
                                        " FROM bills_info bi" +
                                        " INNER JOIN dishes d ON d.id = bi.dishes" +
                                        " INNER JOIN bills b ON b.id = bi.bills" +
                                        " LEFT JOIN unit u ON u.branch = b.branch AND u.ref_printers_type = d.ref_printers_type" +
                                        " LEFT JOIN ref_printers rp ON rp.id = u.ref_printers" +
                                        " LEFT JOIN ref_reports rr ON rr.ref_printers_type = d.ref_printers_type" +
                                        " WHERE bi.bills = @bills";

                command.Parameters.Add("bills", SqlDbType.Int).Value = bill.BillId;

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

        internal void changeBillInfoStatus(string pDbType, oBill pBill, int pStatus)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                tx = con.BeginTransaction();

                command = con.CreateCommand();

                command.Transaction = tx; ;

                command.CommandText = "DishToBill_changeStatus";
                command.CommandType = CommandType.StoredProcedure;

                //DishToBill_changeStatus(@pSeason int, @pBillId int, @pUserId int, @pStatusId int)
                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.BillId;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;
                command.Parameters.Add("pStatusId", SqlDbType.Int).Value = pStatus;

                command.ExecuteNonQuery();

                tx.Commit();

                con.Close();

            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }
        }

        internal DataTable closeBill(string pDbType, oBill pBill)
        {
            dtResult = new DataTable("order");

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                tx = con.BeginTransaction();

                command = con.CreateCommand();

                command.Transaction = tx; ;

                command.CommandText = "BillClose";
                command.CommandType = CommandType.StoredProcedure;

                //DishToBill_changeStatus(@pSeason int, @pBillId int, @pUserId int, @pStatusId int)

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.BillId;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;

                command.ExecuteNonQuery();

                command.CommandType = CommandType.Text;
                command.Parameters.Clear();

                command.CommandText = "SELECT bi.dishes_name AS name, bi.dishes_price AS price, bi.xcount,  rp.name AS printerName, rr.xpath AS reportPath"+
                                        " FROM bills_info bi"+
                                        " INNER JOIN bills b ON b.id = bi.bills"+
                                        " INNER JOIN unit u ON u.branch = b.branch AND u.ref_printers_type = @ref_printers_type"+
                                        " LEFT JOIN ref_printers rp ON rp.id = u.ref_printers"+
                                        " LEFT JOIN ref_reports rr ON rr.ref_printers_type = u.ref_printers_type"+
                                        " WHERE bi.bills = @bills";
                command.Parameters.Add("ref_printers_type", SqlDbType.Int).Value = 3;
                command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.BillId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                if (dtResult.Rows.Count == 0)
                {
                    throw new Exception("Не найдено данных для печати Счета. " + Environment.NewLine +"Операция закрытия Счета не выполнена.");
                }

                tx.Commit();
                con.Close();

            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }

            return dtResult;
        }

        internal void checkEmptyBill(string pDbType, oBill pBill)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                tx = con.BeginTransaction();

                command = con.CreateCommand();

                command.Transaction = tx; ;

                command.CommandText = "checkEmptyBill";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.BillId;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;

                command.ExecuteNonQuery();

                tx.Commit();

                con.Close();

            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }
        }

        internal DataTable getWaiters(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT b.id AS billId, b.numb AS billNumber, u.id AS userId, u.lname +' '+ u.fname +' '+ u.sname AS fio," +
                                        " sum(bi.dishes_price * xcount) AS suma," +
                                        " b.date_open, b.date_close, stat.id AS statId, stat.name" +
                                        " FROM bills b" +
                                        " INNER JOIN users u ON u.id = b.user_open" +
                                        " LEFT JOIN bills_info bi ON bi.bills = b.id" +
                                        " INNER JOIN ref_status stat ON stat.id = b.ref_status" +
                                        " WHERE b.season = @season AND stat.id not in(27)" +
                                        " GROUP BY b.id, b.numb, b.date_open, b.date_close, stat.name, u.id," +
                                        " u.lname, u.fname, u.sname, stat.id";

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

        internal DataTable getWaitersInfo(string pDbType)
        {
            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT b.id, b.numb, sum(bi.dishes_price * xcount) AS suma, "+
                                                " b.date_open, b.date_close, stat.name"+
                                            " FROM bills b"+
                                            " LEFT JOIN bills_info bi ON bi.bills = b.id"+
                                            " INNER JOIN ref_status stat ON stat.id = b.ref_status"+
                                        " WHERE b.season = @season AND b.user_open = @userOpen"+
                                        " GROUP BY b.id, b.numb, b.date_open, b.date_close, stat.name";

                command.Parameters.Add("season", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("userOpen", SqlDbType.Int).Value = UsersInfo.UserId;

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

        internal void BillToAnotherWaiter(string pDbType, int pBillId, int pUserId_from, int pUserId_to)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                tx = con.BeginTransaction();

                command = con.CreateCommand();

                command.Transaction = tx; ;

                command.CommandText = "BillToAnotherWaiter";
                command.CommandType = CommandType.StoredProcedure;

                //DishToBill_changeStatus(@pSeason int, @pBillId int, @pUserId int, @pStatusId int)

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBillId;
                command.Parameters.Add("pUserId_from", SqlDbType.Int).Value = pUserId_from;
                command.Parameters.Add("pUserId_to", SqlDbType.Int).Value = pUserId_to;

                command.ExecuteNonQuery();

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }
        }

        internal void seasonClose(string pDbType)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();

                tx = con.BeginTransaction();

                command = con.CreateCommand();

                command.Transaction = tx; ;

                command.CommandText = "SeasonClose";
                command.CommandType = CommandType.StoredProcedure;

                //DishToBill_changeStatus(@pSeason int, @pBillId int, @pUserId int, @pStatusId int)

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = GValues.openSeasonId;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = UsersInfo.UserId;

                command.ExecuteNonQuery();

                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) tx.Rollback(); con.Close(); }
        }
    }

    public class oBill
    {
        private int _billId;
        private DateTime _dateOpen;
        private int _table;
        private int _summa;

        public int Summa
        {
            get { return _summa; }
            set { _summa = value; }
        }
        
        public int Table
        {
            get { return _table; }
            set { _table = value; }
        }
        
        public DateTime DateOpen
        {
            get { return _dateOpen; }
            set { _dateOpen = value; }
        }
        
        public int BillId
        {
            get { return _billId; }
            set { _billId = value; }
        }
    }

    public class oDishes
    {
        private int _id;
        private double _count;
        private double _price;
        private int _discount;
        private string _name;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public double Count
        {
            get { return _count; }
            set { _count = value; }
        }
        
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
    }

    public class oBillInfo
    {
        private int _bill;
        private int _dishes;
        private string _dishesName;
        private double _dishesPrice;
        private double _xcount;
        private double _suma;
        private int _refStatus;
        private string _refStatusName;
        private double _discount;

        public double Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        

        public string RefStatusName
        {
            get { return _refStatusName; }
            set { _refStatusName = value; }
        }

        public int RefStatus
        {
            get { return _refStatus; }
            set { _refStatus = value; }
        }

        public double Suma
        {
            get { return _suma; }
            set { _suma = value; }
        }

        public double XCount
        {
            get { return _xcount; }
            set
            {
                _xcount = value;
                _suma = _xcount * _dishesPrice;
            }
        }

        public double DishesPrice
        {
            get { return _dishesPrice; }
            set { _dishesPrice = value; }
        }
        
        public string DishesName
        {
            get { return _dishesName; }
            set { _dishesName = value; }
        }

        public int Dishes
        {
            get { return _dishes; }
            set { _dishes = value; }
        }

        public int Bill
        {
            get { return _bill; }
            set { _bill = value; }
        }
        
    }
}
