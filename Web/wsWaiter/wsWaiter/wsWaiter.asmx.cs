using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace com.sbs.ws.waiter
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://sbswaiter.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class wsWaiter : System.Web.Services.WebService
    {
        DBAccess dbAccess = new DBAccess();

        [WebMethod(EnableSession = true)]
        public List<DTO.GValuesEx> getGValuesEx(int pDeviceId)
        {
            return dbAccess.getGValuesEx(pDeviceId);
        }

        [WebMethod(EnableSession = true)]
        public List<DTO.Bill> getBills(int pBranchId, int pSeasonId)
        {
            List<DTO.Bill> lBill = new List<DTO.Bill>();

            lBill = dbAccess.getBills(pBranchId, pSeasonId);

            return lBill;
        }

        [WebMethod(EnableSession = true)]
        public string getCounter()
        {
            if (Session["HitCounter"] == null) Session["HitCounter"] = 1;
            else Session["HitCounter"] = ((int)Session["HitCounter"]) + 1;

            return Session["HitCounter"].ToString();
        }

        [WebMethod(EnableSession = true)]
        public DTO.Bill createBill(DTO.Bill pBill)
        {
            return dbAccess.createBill(pBill);
        }


    }
}