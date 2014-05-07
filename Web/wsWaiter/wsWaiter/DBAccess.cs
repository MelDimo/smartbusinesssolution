using System.Collections.Generic;
using System;

[Serializable]
public class DBAccess
{
    public List<DTO.Bill> getBills(int pWaiterId, int pSeasonId)
    {
        //DTO.Bill oBill = new DTO.Bill();

        List<DTO.Bill> lBill = new List<DTO.Bill>();

        lBill.Add(new DTO.Bill() { id = 1, season = 1 });
        lBill.Add(new DTO.Bill() { id = 2, season = 1 });
        lBill.Add(new DTO.Bill() { id = 3, season = 1 });
        lBill.Add(new DTO.Bill() { id = 4, season = 1 });

        return lBill;
    }
}