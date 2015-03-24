using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll;
using System.Web.Services;
using com.sbs.reportForPrintServer;
using System.Diagnostics;

[Serializable]
public class DBAccess
{
    private SqlConnection con;
    private SqlCommand command = null;
    //private SqlTransaction tx = null;

    private DataTable dtResult;

    public DBAccess()
    {
        try
        {
            GValues.DBMode = "offline";
            Config conf = new Config();
            if (!conf.loadConfig()) return;
            if (!conf.loadConString()) return;
            conf.initAdditionData(GValues.DBMode);
        }
        catch (Exception exc)
        {
            WriteToEventLog(exc.Message, EventLogEntryType.Error);
            throw exc;
        }
    }

    private void WriteToEventLog(string strLogEntry, EventLogEntryType eType)
    {
        string strSource = "sbsWSWaiter"; //name of the source
        string strLogType = "Application"; //type of the log
        string strMachine = "."; //machine name

        EventLog eLog = new EventLog(strLogType, strMachine, strSource);
        eLog.WriteEntry(strLogEntry, eType, 1000);

    }

    public List<DTO.GValuesEx> getGValuesEx(int pDeviceId)
    {
        List<DTO.GValuesEx> lGValuesEx = new List<DTO.GValuesEx>();
        dtResult = new DataTable();

        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "mobile_GetGValues";

            command.Parameters.Add("pDeviceId", SqlDbType.Int).Value = pDeviceId;

            using (SqlDataReader dr = command.ExecuteReader()) { dtResult.Load(dr); }

            con.Close();
        }
        catch (Exception exc) {
            WriteToEventLog(exc.Message, EventLogEntryType.Error);
            throw exc; 
        }
        finally { if (con.State == ConnectionState.Open) con.Close(); }

        foreach (DataRow dr in dtResult.Rows)
        { 
            lGValuesEx.Add(new DTO.GValuesEx() { 
            branch = GValues.branchId,
            season = (int)dr["season"],
            userId = (int)dr["userID"],
            fio = dr["fio"].ToString()
            });
        }

        return lGValuesEx;
    }

    public List<DTO.Menu> getMenu(int pBranchId)
    {
        List<DTO.Menu> lMenu = new List<DTO.Menu>();
        
        dtResult = new DataTable();

        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT id, code, name, branch, ref_status " + 
                                    " FROM carte " + 
                                    " WHERE branch = @branch AND ref_status = @ref_status " + 
                                    " ORDER by name";

            command.Parameters.Add("branch", SqlDbType.Int).Value = pBranchId;
            command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;

            dtResult = new DataTable();
            using (SqlDataReader dr = command.ExecuteReader()) { dtResult.Load(dr); }

            foreach (DataRow dr in dtResult.Rows)
            {
                lMenu.Add(new DTO.Menu() 
                { 
                    id = (int)dr["id"], 
                    name = dr["name"].ToString() 
                });
            }

            command.Parameters.Clear();

            command.CommandText = "SELECT id, id_parent, carte, name, ref_status " +
                                    " FROM carte_dishes_group " + 
                                    " WHERE carte = @carte AND ref_status = @ref_status" + 
                                    " ORDER BY id_parent, id, name";
            
            command.Parameters.Add("carte", SqlDbType.Int);
            command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;

            foreach (DTO.Menu menu in lMenu)
            {
                dtResult = new DataTable();
                command.Parameters["carte"].Value = menu.id;
                using (SqlDataReader dr = command.ExecuteReader()) { dtResult.Load(dr); }

                foreach (DataRow dr in dtResult.Rows)
                {
                    menu.oMenuGroup.Add(new DTO.MenuGroup()
                    {
                        id = (int)dr["id"],
                        id_parent = (int)dr["id_parent"],
                        name = dr["name"].ToString()
                    });
                }
            }

            dtResult = new DataTable();
            command.Parameters.Clear();

            command.CommandText = "SELECT id, carte_dishes_group, ref_dishes, name, price, isvisible, avalHall, avalDelivery, ref_printers_type, ref_status, minStep " +
                        " FROM carte_dishes " +
                        " WHERE carte_dishes_group = @carte_dishes_group "+
                        "       AND ref_status = @ref_status AND avalHall = @avalHall" +
                        " ORDER BY name";

            command.Parameters.Add("carte_dishes_group", SqlDbType.Int);
            command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;
            command.Parameters.Add("avalHall", SqlDbType.Int).Value = 1;

            foreach (DTO.Menu menu in lMenu)
            {
                foreach (DTO.MenuGroup group in menu.oMenuGroup)
                {
                    dtResult = new DataTable();
                    command.Parameters["carte_dishes_group"].Value = group.id;
                    using (SqlDataReader dr = command.ExecuteReader()) { dtResult.Load(dr); }

                    foreach (DataRow dr in dtResult.Rows)
                    {
                        menu.oMenuDishes.Add(new DTO.MenuDishes()
                        {
                            id = (int)dr["id"],
                            refDishes = (int)dr["ref_dishes"],
                            groupId = (int)dr["carte_dishes_group"],
                            name = dr["name"].ToString(),
                            price = (decimal) dr["price"],
                            minStep = (decimal) dr["minStep"],
                            isVisible = (int)dr["isvisible"]
                        });
                    }
                }
            }

            dtResult = new DataTable();
            command.Parameters.Clear();

            command.CommandText = "SELECT id, ref_notes_type, note, ref_status" +
                        " FROM ref_notes " +
                        " WHERE ref_notes_type = @ref_notes_type AND ref_status = @ref_status" +
                        " ORDER BY note";

            command.Parameters.Add("ref_notes_type", SqlDbType.Int).Value = 2;
            command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;

            dtResult = new DataTable();
            using (SqlDataReader dr = command.ExecuteReader()) { dtResult.Load(dr); }

            foreach (DTO.Menu menu in lMenu)
            {
                foreach (DataRow dr in dtResult.Rows)
                {
                    menu.oRefNotes.Add(new DTO.RefNotes() { 
                        id = (int)dr["id"],
                        note = dr["note"].ToString(),
                        refNotesType = (int)dr["ref_notes_type"],
                        refStatus = (int)dr["ref_status"]
                    });
                }
            }

            con.Close();
        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw exc; }
        finally { if (con.State == ConnectionState.Open) con.Close(); }

        return lMenu;
    }

    public List<DTO.Bill> getBills(int pUserId, int pSeasonId)
    {
        dtResult = new DataTable();

        DTO.Bill oBill = new DTO.Bill();

        List<DTO.Bill> lBill = new List<DTO.Bill>();

        con = new DBCon().getConnection(GValues.DBMode);

        try
        {
            con.Open();

            command = con.CreateCommand();

            command.CommandText = "mobile_GetBills";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("pUserId", SqlDbType.Int).Value = pUserId;
            command.Parameters.Add("pSeasonId", SqlDbType.Int).Value = pSeasonId;

            using (SqlDataReader dr = command.ExecuteReader())
            {
                dtResult.Load(dr);
            }

            con.Close();

        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw new Exception("", exc); }
        finally { if (con.State == ConnectionState.Open) con.Close(); }

        foreach (DataRow dr in dtResult.Rows)
        {
            oBill = new DTO.Bill();
            oBill.id = (int)dr["id"];
            oBill.season = (int)dr["season"];
            oBill.dateBill = dr["dateBill"].ToString();
            oBill.numBill = (int)dr["numbBill"];
            oBill.table = (int)dr["table"];
            oBill.sum = (decimal)dr["sum"];
            lBill.Add(oBill);
        }
        
        return lBill;
    }

    public List<int> openBill(int pBranch, int pSeason, int pxTable, int pUserOpen)
    {
        dtResult = new DataTable();

        List<int> outParam = new List<int>();

        con = new DBCon().getConnection(GValues.DBMode);

        try
        {
            con.Open();

            command = con.CreateCommand();

            command.CommandText = "mobile_OpenBill";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("pBranch", SqlDbType.Int).Value = pBranch;
            command.Parameters.Add("pSeason", SqlDbType.Int).Value = pSeason;
            command.Parameters.Add("pxTable", SqlDbType.Int).Value = pxTable;
            command.Parameters.Add("pUserOpen", SqlDbType.Int).Value = pUserOpen;

            command.Parameters.Add("pBillId", SqlDbType.Int);
            command.Parameters["pBillId"].Value = 0;
            command.Parameters["pBillId"].Direction = ParameterDirection.InputOutput;
            command.Parameters.Add("pNumber", SqlDbType.Int);
            command.Parameters["pNumber"].Value = 0;
            command.Parameters["pNumber"].Direction = ParameterDirection.InputOutput;

            command.ExecuteNonQuery();

            outParam.Add((int)command.Parameters["pBillId"].Value);
            outParam.Add((int)command.Parameters["pNumber"].Value);

            con.Close();

        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw new Exception("", exc); }
        finally { if (con.State == ConnectionState.Open) con.Close(); }

        return outParam;
    }

    public void closeBill(int pBillId, int pBranch, int pSeason, int pPaymentType, int pUserId)
    {
        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "mobile_CloseBill";

            command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBillId;
            command.Parameters.Add("pBranch", SqlDbType.Int).Value = pBranch;
            command.Parameters.Add("pSeason", SqlDbType.Int).Value = pSeason;
            command.Parameters.Add("pPaymentType", SqlDbType.Int).Value = pPaymentType;
            command.Parameters.Add("pUserId", SqlDbType.Decimal).Value = pUserId;

            command.ExecuteNonQuery();

            con.Close();
        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw exc; }
        finally { if (con.State == ConnectionState.Open) con.Close(); }
    }

    public List<DTO.BillInfo> getBillsInfo(int pSeasonId, int pBillId)
    {
        dtResult = new DataTable();

        DTO.BillInfo oBillInfo = new DTO.BillInfo();

        List<DTO.BillInfo> lBillInfo = new List<DTO.BillInfo>();

        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "mobile_BillsInfo_Get";

            command.Parameters.Add("pSeasonId", SqlDbType.Int).Value = pSeasonId;
            command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBillId;

            using (SqlDataReader dr = command.ExecuteReader()) { dtResult.Load(dr); }

            con.Close();
        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw exc; }
        finally { if (con.State == ConnectionState.Open) con.Close(); }

        foreach (DataRow dr in dtResult.Rows)
        {
            oBillInfo = new DTO.BillInfo();
            oBillInfo.bills = (int)dr["bills"];
            oBillInfo.ref_dishes = (int)dr["ref_dishes"];
            oBillInfo.dishes_name = dr["dishes_name"].ToString();
            oBillInfo.dishes_price = (decimal)dr["dishes_price"];
            oBillInfo.xcount = (decimal)dr["xcount"];
            oBillInfo.ref_status = (int)dr["ref_status"];
            oBillInfo.ref_notes = (int)dr["ref_notes"];
            oBillInfo.refNotesName = dr["refNotesName"].ToString();

            lBillInfo.Add(oBillInfo);
        }

        return lBillInfo;
    }

    public void addDishToBill(int pBranch, int pSeasonId, int pBillsId, int pRefDishes, decimal pDishCount, int pUserId)
    {
        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "mobile_BillsInfo_Add";

            command.Parameters.Add("pBranch", SqlDbType.Int).Value = pBranch;
            command.Parameters.Add("pSeasonId", SqlDbType.Int).Value = pSeasonId;
            command.Parameters.Add("pBillsId", SqlDbType.Int).Value = pBillsId;
            command.Parameters.Add("pRefDishes", SqlDbType.Int).Value = pRefDishes;
            command.Parameters.Add("pDishCount", SqlDbType.Decimal).Value = pDishCount;
            command.Parameters.Add("pUserId", SqlDbType.Decimal).Value = pUserId;

            command.ExecuteNonQuery();

            con.Close();
        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw exc; }
        finally { if (con.State == ConnectionState.Open) con.Close(); }
    }

    public void DishToBill_refuse(int pBranch, int pSeason, int pBillId, int pRefDishes, int pUser, decimal pNewCount)
    { 
        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "mobile_BillsInfo_refuse";

            command.Parameters.Add("pBranch", SqlDbType.Int).Value = pBranch;
            command.Parameters.Add("pSeason", SqlDbType.Int).Value = pSeason;
            command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBillId;
            command.Parameters.Add("pRefDishes", SqlDbType.Int).Value = pRefDishes;
            command.Parameters.Add("pUser", SqlDbType.Int).Value = pUser;
            command.Parameters.Add("pNewCount", SqlDbType.Decimal).Value = pNewCount;

            command.ExecuteNonQuery();

            con.Close();
        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw exc; }
        finally { if (con.State == ConnectionState.Open) con.Close(); }
    }

    public List<DTO.MenuDishes> commitBill(int pId, int pNumb, int pTable, int pBranch, int pSeason, int pUserId, string pUserName)
    {
        report4PrintServer ps = new report4PrintServer();
        ps.commitDish(GValues.DBMode, new DTO_DBoard.Bill() { id = pId, numb = pNumb, table = pTable }, pSeason, pUserId, pUserName);

        dtResult = new DataTable();

        DTO.MenuDishes oMenuDishes = new DTO.MenuDishes();

        List<DTO.MenuDishes> lMenuDishes = new List<DTO.MenuDishes>();
        
        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "mobile_BillsDeals";

            command.Parameters.Add("pBranch", SqlDbType.Int).Value = pBranch;
            command.Parameters.Add("pSeason", SqlDbType.Int).Value = pSeason;
            command.Parameters.Add("pBill", SqlDbType.Int).Value = pId;
            command.Parameters.Add("pTable", SqlDbType.Int).Value = pTable;


            using (SqlDataReader dr = command.ExecuteReader()) { dtResult.Load(dr); }

            con.Close();
        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw exc; }
        finally { if (con.State == ConnectionState.Open) con.Close(); }

        foreach (DataRow dr in dtResult.Rows)
        {
            oMenuDishes = new DTO.MenuDishes();
            oMenuDishes.id = (int)dr["id"];
            oMenuDishes.refDishes = (int)dr["ref_dishes"];
            oMenuDishes.groupId = (int)dr["carte_dishes_group"];
            oMenuDishes.name = dr["name"].ToString();
            oMenuDishes.minStep = (decimal)dr["minStep"];
            oMenuDishes.price = (decimal)dr["price"];

            lMenuDishes.Add(oMenuDishes);
        }

        return lMenuDishes;
    }

    internal void setComment(int pBillId, int pBranch, int pSeason, int pRefDishes, int pNotes)
    {
        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "mobile_setComment";

            command.Parameters.Add("pBranch", SqlDbType.Int).Value = pBranch;
            command.Parameters.Add("pSeason", SqlDbType.Int).Value = pSeason;
            command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBillId;
            command.Parameters.Add("pRefDishes", SqlDbType.Int).Value = pRefDishes;
            command.Parameters.Add("pNotes", SqlDbType.Int).Value = pNotes;

            command.ExecuteNonQuery();

            con.Close();
        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw exc; }
        finally { if (con.State == ConnectionState.Open) con.Close(); }
    }

    internal List<DTO.GetReferences> getReferences(int pBranch)
    {
        List<DTO.GetReferences> lReferences = new List<DTO.GetReferences>();
        DTO.GetReferences oReferences = new DTO.GetReferences();

        dtResult = new DataTable();

        try
        {
            con = new DBCon().getConnection(GValues.DBMode);
            con.Open();

            command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "mobile_GetPaymentType";

            command.Parameters.Add("pBranch", SqlDbType.Int).Value = pBranch;


            using (SqlDataReader dr = command.ExecuteReader()) { dtResult.Load(dr); }

            con.Close();
        }
        catch (Exception exc) { WriteToEventLog(exc.Message, EventLogEntryType.Error); throw exc; }
        finally { if (con.State == ConnectionState.Open) con.Close(); }

        foreach (DataRow dr in dtResult.Rows)
        {
            oReferences.oBranchPayment.Add(new DTO.BranchPayment()
            {
                branch = (int)dr["branch"],
                color = (string)dr["color"],
                name = (string)dr["name"],
                refPaymentType = (int)dr["ref_payment_type"]
            });
        }
        lReferences.Add(oReferences);

        return lReferences;
    }
}