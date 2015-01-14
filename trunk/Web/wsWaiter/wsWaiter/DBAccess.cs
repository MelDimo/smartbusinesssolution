using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll;
using System.Web.Services;

[Serializable]
public class DBAccess
{
    private SqlConnection con;
    private SqlCommand command = null;
    //private SqlTransaction tx = null;

    private DataTable dtResult;

    public DBAccess()
    {
        Config conf = new Config();
        if (!conf.loadConfig()) return;
        if (!conf.loadConString()) return;
        conf.initAdditionData(GValues.DBMode);

        GValues.DBMode = "online";
    }

    public DTO.GValuesEx getGValuesEx()
    {
        return new DTO.GValuesEx() { branch = GValues.branchId };
    }

    public List<DTO.Bill> getBills(int pBranchId, int pSeasonId)
    {
        dtResult = new DataTable();

        //DTO.Bill oBill = new DTO.Bill();

        List<DTO.Bill> lBill = new List<DTO.Bill>();
        /*
        try
        {
            con.Open();

            command = con.CreateCommand();

            command.CommandText = "SeasonBrowser_GetSeason";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("pBranch", SqlDbType.Int).Value = pFilter.branch;
            command.Parameters.Add("pConType", SqlDbType.NVarChar).Value = GValues.DBMode;
            command.Parameters.Add("pDateOpen", SqlDbType.DateTime).Value = pFilter.dateStart;
            command.Parameters.Add("pDateClose", SqlDbType.DateTime).Value = pFilter.dateEnd;

            using (SqlDataReader dr = command.ExecuteReader())
            {
                dtResult.Load(dr);
            }

            con.Close();

        }
        catch (Exception exc) { throw new Exception("", exc); }
        finally { if (con.State == ConnectionState.Open) con.Close(); }

        foreach (DataRow dr in dtResult.Rows)
        {
            oSeasonBranch = new DTO_DBoard.SeasonBranch();
            oSeasonBranch.seasonID = (int)dr["season_id"];
            oSeasonBranch.dateOpen = (DateTime)dr["date_open"];
            oSeasonBranch.dateClose = DBNull.Value.Equals(dr["date_close"]) ? (DateTime?)null : (DateTime)dr["date_close"];
            oSeasonBranch.userID = (int)dr["user_open"];
            oSeasonBranch.refStatus = (int)dr["ref_status"];
            oSeasonBranch.refStatusName = dr["ref_status_name"].ToString();

            lSeasonBranch.Add(oSeasonBranch);
        }
        
        con = new DBCon().getConnection(GValues.DBMode);
        */

        lBill.Add(new DTO.Bill() { id = 1, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 1, table = 1, sum = new decimal(11.78) });
        lBill.Add(new DTO.Bill() { id = 2, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 2, table = 2, sum = new decimal(20.5) });
        lBill.Add(new DTO.Bill() { id = 3, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 3, table = 3, sum = new decimal(25.3) });
        lBill.Add(new DTO.Bill() { id = 4, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 4, table = 4, sum = new decimal(9.5) });
        lBill.Add(new DTO.Bill() { id = 5, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 5, table = 5, sum = new decimal(125.1) });
        lBill.Add(new DTO.Bill() { id = 6, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 6, table = 6, sum = new decimal(250.3) });
        lBill.Add(new DTO.Bill() { id = 7, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 7, table = 7, sum = new decimal(127.5) });
        lBill.Add(new DTO.Bill() { id = 8, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 8, table = 8, sum = new decimal(128.57) });
        lBill.Add(new DTO.Bill() { id = 9, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 9, table = 9, sum = new decimal(125.5) });
        lBill.Add(new DTO.Bill() { id = 10, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 10, table = 10, sum = new decimal(167.5) });
        lBill.Add(new DTO.Bill() { id = 11, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 11, table = 11, sum = new decimal(128.87) });
        lBill.Add(new DTO.Bill() { id = 12, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 12, table = 12, sum = new decimal(1258.5) });
        lBill.Add(new DTO.Bill() { id = 13, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 13, table = 13, sum = new decimal(854.5) });
        lBill.Add(new DTO.Bill() { id = 14, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 14, table = 14, sum = new decimal(457.8) });
        lBill.Add(new DTO.Bill() { id = 15, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 15, table = 15, sum = new decimal(589.5) });
        lBill.Add(new DTO.Bill() { id = 16, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 16, table = 16, sum = new decimal(123.34) });
        lBill.Add(new DTO.Bill() { id = 17, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 17, table = 17, sum = new decimal(1478.5) });
        lBill.Add(new DTO.Bill() { id = 18, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 18, table = 18, sum = new decimal(324.2) });
        lBill.Add(new DTO.Bill() { id = 19, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 19, table = 19, sum = new decimal(258.98) });
        lBill.Add(new DTO.Bill() { id = 20, season = 1, dateBill = DateTime.Now.ToString("dd.MM.yyyy hh:mm"), numBill = 20, table = 20, sum = new decimal(110.5) });

        return lBill;
    }

    public DTO.Bill createBill(DTO.Bill pBill)
    { 
        DTO.Bill oBill = pBill;

        oBill.id = 1;
        oBill.season = pBill.season;
        oBill.dateBill = DateTime.Now.ToString();
        oBill.numBill = 2;
        oBill.table = pBill.table;
        oBill.sum = 0;

        return oBill;
    }
}