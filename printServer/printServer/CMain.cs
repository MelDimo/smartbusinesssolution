using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Data;
using com.sbs.dll.utilites;
using System.Threading;

namespace printServer
{
    public class CMain
    {

        public static void Main()
        {


            Config conf = new Config();
            if (!conf.loadConfig()) return;
            if (!conf.loadConString()) return;


            while (true)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(workThread));
                Thread.Sleep(30000);
            }

            
        }

        static void workThread(Object stateInfo)
        {
            DBAccess dbAccess = new DBAccess();

            DataTable dtPrinterData = new DataTable();

            try
            {
                dtPrinterData = dbAccess.getWatingRecords(GValues.DBMode);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ErrorMessage: {0}\nErrorStackTrace: {1}", exc.Message, exc.StackTrace));
            }

            if (dtPrinterData.Rows.Count > 0) printData(dtPrinterData);
        }

        private static void printData(DataTable dtPrinterData)
        {
            DBAccess dbAccess = new DBAccess();

            RawPrinterHelper rawHelper = new RawPrinterHelper();

            List<dtoResult> lDtoResult = new List<dtoResult>();

            int dwError = 0;
            int id = 0;
            string printerName = string.Empty;
            string sourceBody = string.Empty;
            int sourceType = 0;
            bool bSuccess = false;

            foreach (DataRow dr in dtPrinterData.Rows)
            {
                id = (int)dr["id"];
                printerName = dr["printerName"].ToString();
                sourceType = (int)dr["sourceType"];
                sourceBody = dr["sourceText"].ToString();

                switch (sourceType)
                { 
                    case 1:             //  1-raw
                        bSuccess = rawHelper.SendStringToPrinter(printerName, sourceBody, out dwError);
                        break;

                    case 2:             //  2-crystal
                        break;
                }


                if (!bSuccess)
                {
                    lDtoResult.Add(new dtoResult()
                    {
                        id = id,
                        errCode = dwError
                    });
                    Console.WriteLine(string.Format("Error: id:{0}\n ErrorCode: {1}", id, dwError));
                }
                else 
                {
                    lDtoResult.Add(new dtoResult()
                    {
                        id = id,
                        errCode = dwError
                    });
                }
            }

            try
            {
                dbAccess.updateRecords(GValues.DBMode, lDtoResult);
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("ErrorMessage: {0}\nErrorStackTrace: {1}", exc.Message, exc.StackTrace));
            }
        }
    }
}
