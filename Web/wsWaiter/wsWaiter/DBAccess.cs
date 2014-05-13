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

        GValues.DBMode = "online";
    }

    public List<DTO.Bill> getBills(int pWaiterId, int pSeasonId)
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

        lBill.Add(new DTO.Bill() { id = 1, season = 1 });
        lBill.Add(new DTO.Bill() { id = 2, season = 1 });
        lBill.Add(new DTO.Bill() { id = 3, season = 1 });
        lBill.Add(new DTO.Bill() { id = 4, season = 1 });
        lBill.Add(new DTO.Bill() { id = 5, season = 1 });
        lBill.Add(new DTO.Bill() { id = 6, season = 1 });
        lBill.Add(new DTO.Bill() { id = 7, season = 1 });
        lBill.Add(new DTO.Bill() { id = 8, season = 1 });
        lBill.Add(new DTO.Bill() { id = 9, season = 1 });
        lBill.Add(new DTO.Bill() { id = 10, season = 1 });
        lBill.Add(new DTO.Bill() { id = 11, season = 1 });
        lBill.Add(new DTO.Bill() { id = 12, season = 1 });
        lBill.Add(new DTO.Bill() { id = 13, season = 1 });
        lBill.Add(new DTO.Bill() { id = 14, season = 1 });
        lBill.Add(new DTO.Bill() { id = 15, season = 1 });
        lBill.Add(new DTO.Bill() { id = 16, season = 1 });
        lBill.Add(new DTO.Bill() { id = 17, season = 1 });
        lBill.Add(new DTO.Bill() { id = 18, season = 1 });
        lBill.Add(new DTO.Bill() { id = 19, season = 1 });
        lBill.Add(new DTO.Bill() { id = 20, season = 1 });

        return lBill;
    }
}