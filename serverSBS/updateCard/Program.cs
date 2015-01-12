using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Threading;
using com.sbs.serverdll;
using com.sbs.iserver;
using System.Diagnostics.Eventing;

namespace com.sbs.server
{
    public class UpdateCard: iserver.IServerSBS
    {
        public void entryPoint()
        {
            start();
        }

        private void start()
        {
            Thread workingThread = new Thread(new ParameterizedThreadStart(mainThread));
            workingThread.IsBackground = true;
            workingThread.Start(null);
        }

        private void mainThread(object pObject)
        {
            WriteLog wtLog = new WriteLog();

            DBAccess_UpdateCard dbAccess = new DBAccess_UpdateCard();

            string retVal = string.Empty;

            while (true)
            {
                Console.WriteLine("updateCardHolders");
                try
                {
                    retVal = dbAccess.updateCardHolders();
                }
                catch (Exception exc)
                {
                    wtLog.writeLog(exc.Message);
                }
                finally
                {
                    if (!string.Empty.Equals(retVal))
                    {
                        wtLog.writeLog(retVal);
                    }
                }

                Thread.Sleep(3600000); // - 3600000 - 1 час
            }
        }
    }
}
