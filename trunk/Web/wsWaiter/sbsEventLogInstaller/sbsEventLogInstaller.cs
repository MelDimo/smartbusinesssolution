using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;

namespace sbsEventLogInstaller
{
    [RunInstaller(true)]
    public class sbsEventLogInstaller : Installer
    {
        private EventLogInstaller myEventLogInstaller;

        public sbsEventLogInstaller()
        {
            //Create Instance of EventLogInstaller
            myEventLogInstaller = new EventLogInstaller();

            // Set the Source of Event Log, to be created.
            myEventLogInstaller.Source = "sbsWSWaiter";

            // Set the Log that source is created in
            myEventLogInstaller.Log = "Application";

            // Add myEventLogInstaller to the Installers Collection.
            Installers.Add(myEventLogInstaller);
        }
    }
}
