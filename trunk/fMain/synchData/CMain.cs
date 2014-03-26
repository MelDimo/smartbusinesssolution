using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll.synchdata
{
    class CMain
    {
        static void Main(string[] args)
        {
            Config conf = new Config();
            if (!conf.loadConfig()) return;

            SynchData synchData = new SynchData();
            synchData.send2MainDB();

        }
    }
}
