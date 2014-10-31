using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;

/// <summary>
/// 
///     Данное придожение призвано отрабатывать в шедулере и очищать спулер
///     Работает только в системах <= Windows XP SP3
/// 
/// </summary>
namespace restartSpooler
{
    class Program
    {
        static void Main(string[] args)
        {
            string sSource = "SBS";
            string sLog = "Spooler";
            //string sEvent = "ShedulerReport";

            try
            {
                restartSpooler();
            }
            catch (Exception exc) 
            {
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, sLog);

                EventLog.WriteEntry(sSource, exc.Message, EventLogEntryType.Error, 234);
            }
        }

        private static void restartSpooler()
        {
            ServiceController service = new ServiceController();
            service.ServiceName = "Spooler";
            service.MachineName = System.Windows.Forms.SystemInformation.ComputerName;

            if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||
                (service.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                service.Start();
            }
            else
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
                service.Start();
            }
        }
    }
}
