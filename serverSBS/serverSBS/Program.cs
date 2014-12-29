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

namespace com.sbs.server
{
    class Program
    {
        static AppDomain modulesDomain;

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

            Console.Write(string.Format("{0} Load assemblies completed.", DateTime.Now));

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

                    case "reload":
                        reloadModules();
                        break;

                    case "r":
                        reloadModules();
                        break;

                }
            }
        }

        private static void reloadModules()
        {
            
            if (modulesDomain != null)
            {
                Console.Write(string.Format("{0} Unload AppDomain...", DateTime.Now));
                AppDomain.Unload(modulesDomain);
                Console.WriteLine(" - Ok ");
            }

            Console.Write(string.Format("{0} Create AppDomain...", DateTime.Now));

            //AppDomainSetup domaininfo = new AppDomainSetup();
            //domaininfo.ApplicationBase = System.Environment.CurrentDirectory;
            //domaininfo.
            //Evidence adevidence = AppDomain.CurrentDomain.Evidence;
            //modulesDomain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);

            //Type type = typeof(Proxy);
            //var value = (Proxy)modulesDomain.CreateInstanceAndUnwrap(
            //    type.Assembly.FullName,
            //    type.FullName);

            //modulesDomain = AppDomain.CreateDomain("modulesDomain",
            //                            new Evidence(),
            //                            new AppDomainSetup()
            //                            {
            //                                ApplicationBase = System.Environment.CurrentDirectory,
            //                                ShadowCopyDirectories = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "modules"
            //                            }, new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted),
            //                            new System.Security.Policy.StrongName[] { });
            Console.WriteLine(" - Ok ");

            foreach (string str in Directory.GetFiles(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "modules", "*.dll"))
            {
                Console.Write(string.Format("{0} Load assembly {1};", DateTime.Now, Path.GetFileName(str)));

                FindPlugins(str);

                Console.WriteLine(" - Ok");
            }
        }

        private static void FindPlugins(string file)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(file);

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
                Console.WriteLine("Ok");
            }
        }
    }

}
