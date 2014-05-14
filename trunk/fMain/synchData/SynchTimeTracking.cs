using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace com.sbs.dll.synchdata
{
    class SynchTimeTracking
    {
        private SqlConnection conLocal = null;
        private SqlConnection conMain = null;
        private SqlCommand commandLocal = null;
        private SqlCommand commandMain = null;
        private SqlTransaction txLocal = null;
        private SqlTransaction txMain = null;

        DataTable dtSeason;

        Thread chkBillThread;

        public void run()
        {
            chkBillThread = new Thread(send2MainDB);
            chkBillThread.IsBackground = true;
            chkBillThread.Start();

            return;
        }

        public void send2MainDB()
        {
            if (GValues.DBMode.Equals("online")) return; // Мы уже работаем в режиме онлайн

            while (true)
            {
                sendSeasonData();
                Thread.Sleep(300000);
            }
        }

    }
}
