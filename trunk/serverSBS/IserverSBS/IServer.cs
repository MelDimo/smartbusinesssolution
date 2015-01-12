using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace com.sbs.iserver
{
    public interface IServerSBS
    {
        void entryPoint();
    }

    public class WriteLog
    {
        public void writeLog(string pMessage)
        {
            if (!EventLog.SourceExists("serverSBS"))
            {
                EventLog.CreateEventSource("serverSBS", "SBS");
            }

            EventLog myLog = new EventLog();
            myLog.Source = "serverSBS";

            myLog.WriteEntry(pMessage);
        }
    }
}
