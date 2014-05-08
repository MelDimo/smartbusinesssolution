using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Data;

[Serializable]
public class DBAccess
{
    private SqlConnection con;
    private SqlCommand command = null;
    //private SqlTransaction tx = null;

    private DataTable dtResult;

    public List<DTO.Bill> getBills(int pWaiterId, int pSeasonId)
    {
        dtResult = new DataTable();

        //DTO.Bill oBill = new DTO.Bill();

        List<DTO.Bill> lBill = new List<DTO.Bill>();

        con = new DBCon().getConnection(GValues.DBMode);


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