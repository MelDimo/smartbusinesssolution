using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

namespace com.sbs.comunicate.CommunicateService_Console
{
    class SeasonInfo
    {
        DBAccess dbAccess = new DBAccess();
        DataTable dtSeason;
        DataTable dtBills;
        DataTable dtBillsInfo;

        public void runWatcher()
        {
            while (true)
            {
                dtSeason = getSeason();
                if (dtSeason.Rows.Count > 0)
                {
                    dtBills = getBills();
                    if (dtBills.Rows.Count > 0) dtBillsInfo = getBiilsInfo();
                }


                sendSeasonInfo();

                Thread.Sleep(1000);
            }
        }

        private void sendSeasonInfo()
        {
            dbAccess.sendSeasonInfo(dtSeason, dtBills, dtBillsInfo);
        }

        private DataTable getBiilsInfo()
        {
            dtBillsInfo = new DataTable();

            try
            {
                dtBillsInfo = dbAccess.getBillsInfo("offline", dtBills);
            }
            catch { }

            return dtBillsInfo;
        }

        private DataTable getBills()
        {
            dtBills = new DataTable();

            try
            {
                dtBills = dbAccess.getBills("offline", dtSeason);
            }
            catch { }

            return dtBills;
        }

        public DataTable getSeason()
        {
            dtSeason = new DataTable();

            try
            {
                dtSeason = dbAccess.getSeason("offline");
            }
            catch { }

            return dtSeason;
        }
    }
}
