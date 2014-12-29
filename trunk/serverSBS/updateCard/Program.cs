using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Threading;

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

        static void mainThread(object pObject)
        {
            while (true)
            {
                try
                {

                }
                catch (Exception exc)
                { }
            }
        }
    }
}
