using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Diagnostics;
//using System.Configuration.Install;
using System.ComponentModel;
//using System.Diagnostics.Eventing;
using System.Diagnostics;

namespace com.sbs.iserver
{
    public interface IServerSBS
    {
        void entryPoint();
    }

    public class WriteLog
    {
        public void writeLog(/*string pLvl, string pEvent, */string pMessage)
        {
            if (!EventLog.SourceExists("serverSBS"))
            {
                EventLog.CreateEventSource("serverSBS", "MyNewLog");
            }

            EventLog myLog = new EventLog();
            myLog.Source = "serverSBS";

            myLog.WriteEntry("Writing to event log.");
        }
    }

    //[RunInstaller(true)]
    //public class MyEventLogInstaller : Installer
    //{
    //    private EventLogInstaller myEventLogInstaller;

    //    public MyEventLogInstaller()
    //    {
    //        // Create an instance of an EventLogInstaller.
    //        myEventLogInstaller = new EventLogInstaller();

    //        // Set the source name of the event log.
    //        myEventLogInstaller.Source = "NewLogSource";

    //        // Set the event log that the source writes entries to.
    //        myEventLogInstaller.Log = "MyNewLog";

    //        // Add myEventLogInstaller to the Installer collection.
    //        Installers.Add(myEventLogInstaller);
    //    }
    //}
}
