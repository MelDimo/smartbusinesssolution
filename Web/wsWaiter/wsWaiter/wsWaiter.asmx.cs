using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Diagnostics;

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
        public List<DTO.Bill> getBills(int pUserId, int pSeasonId)
        {
            List<DTO.Bill> lBill = new List<DTO.Bill>();

            lBill = dbAccess.getBills(pUserId, pSeasonId);

            return lBill;
        }

        [WebMethod(EnableSession = true)]
        public List<DTO.BillInfo> getBillsInfo(int pSeasonId, int pBillId)
        {
            return dbAccess.getBillsInfo(pSeasonId, pBillId);
        }

        [WebMethod(EnableSession = true)]
        public void addDishToBill(int pBranch, int pSeasonId, int pBillsId, int pRefDishes, decimal pDishCount, int pUserId)
        {
            dbAccess.addDishToBill(pBranch, pSeasonId, pBillsId, pRefDishes, pDishCount, pUserId);
        }

        [WebMethod(EnableSession = true)]
        public void DishToBill_refuse(int pBranch, int pSeason, int pBillId, int pRefDishes, int pUser, decimal pNewCount)
        {
            dbAccess.DishToBill_refuse(pBranch, pSeason, pBillId, pRefDishes, pUser, pNewCount);
        }

        [WebMethod(EnableSession = true)]
        public List<int> openBill(int pBranch, int pSeason, int pxTable, int pUserOpen)
        {
            return dbAccess.openBill(pBranch, pSeason, pxTable, pUserOpen);
        }

        [WebMethod(EnableSession = true)]
        public void closeBill(int pBillId, int pBranch, int pSeason, int pPaymentType, int pUserId)
        { 

        }

        [WebMethod(EnableSession = true)]
        public List<DTO.MenuDishes> commitBill(int pId, int pNumb, int pTable, int pBranch, int pSeason, int pUserId, string pUserName)
        {
            return dbAccess.commitBill(pId, pNumb, pTable, pBranch, pSeason, pUserId, pUserName);
        }

        [WebMethod(EnableSession = true)]
        public List<DTO.Menu> getMenu(int pBranchId)
        {
            return dbAccess.getMenu(pBranchId);
        }

        [WebMethod(EnableSession = true)]
        public void setComment(int pBillId, int pBranch, int pSeason, int pRefDishes, int pNotes)
        {
            dbAccess.setComment(pBillId, pBranch, pSeason, pRefDishes, pNotes);
        }

        [WebMethod(EnableSession = true)]
        public List<DTO.GetReferences> getReferences(int pBranch)
        {
            return dbAccess.getReferences(pBranch);
        }



        private void WriteToEventLog(string strLogEntry, EventLogEntryType eType)
        {
            string strSource = "sbsWSWaiter"; //name of the source
            string strLogType = "Application"; //type of the log
            string strMachine = "."; //machine name

            EventLog eLog = new EventLog(strLogType, strMachine, strSource);
            eLog.WriteEntry(strLogEntry, eType, 1000);
        }
    }
}