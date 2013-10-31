using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace com.sbs.comunicate.CommunicateService_Console
{
    class Program
    {
        static void Main(string[] args)
        {

#if DEBUG
            Config conf = new Config();
            if (!conf.loadConfig()) return;
#endif
            workerSeasonInfo oWorker = new workerSeasonInfo();
            oWorker.run();
        }

        class workerSeasonInfo
        {
            SeasonInfo seasonInfo = new SeasonInfo();

            public void run() 
            {
                seasonInfo.runWatcher();
            }
        }
    }
}
