using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.sbs.dll;
using System.Threading;
using System.Data;
using System.IO;
using System.Security.Policy;
using System.Reflection;
using com.sbs.server;
using System.Security;
using com.sbs.iserver;
using System.Diagnostics;

namespace com.sbs.server
{
    class Program 
    {
        static void Main(string[] args)
        {
            string consoleLine;
            bool close = false;

            Console.Write(string.Format("{0} Read config file...", DateTime.Now));
            Config conf = new Config();
            if (!conf.loadConfig()) return;
            if (!conf.loadConString()) return;
            Console.WriteLine(" - Ok ");

            reloadModules();

            Console.WriteLine(string.Format("{0} Load assemblies completed.", DateTime.Now));

            while (!close)
            {
                consoleLine = Console.ReadLine();

                switch (consoleLine)
                { 
                    case "help":
                        Console.WriteLine("Available next command:" + Environment.NewLine +
                                            "\thelp or ?\t - show list available command;" + Environment.NewLine +
                                            "\texit or e\t - close application;" + Environment.NewLine +
                                            "\treload or r\t - reload modules.");
                        break;

                    case "?":
                        Console.WriteLine("Available next command:" + Environment.NewLine +
                                            "\thelp or ?\t - show list available command;" + Environment.NewLine +
                                            "\texit or e\t - close application;" + Environment.NewLine +
                                            "\treload or r\t - reload modules.");
                        break;

                    case "exit":
                        close = true;
                        break;

                    case "e":
                        close = true;
                        break;

                    //case "reload":
                    //    reloadModules();
                    //    break;

                    //case "r":
                    //    reloadModules();
                    //    break;

                }
            }
        }

        private static void reloadModules()
        {
            foreach (string str in Directory.GetFiles(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "modules", "*.dll"))
            {
                FindPlugins(str);
            }
        }

        private static void FindPlugins(string file)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile  (file);

                foreach (Type type in assembly.GetTypes())
                {
                    Type iface = type.GetInterface("IServerSBS");
                    if (iface != null)
                    {
                        IServerSBS plugin = (IServerSBS)Activator.CreateInstance(type);
                        plugin.entryPoint();
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("Exception: {0}", exc.Message));
            }
        }
    }

}
