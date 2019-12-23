using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace IsProcessRunning
{
    class Program
    {
        static int Main(string[] args)
        {
            // show quick help.
            if ((args.Length != 2 && args.Length != 1) || (args[0] == "/?" || args[0] == "-h"))
            {
                return ShowHelpAndExit();
            }

            // collect arguments.
            string processName = args[0].ToLower();
            string processArgs = args.Length == 2 ? args[1].ToLower() : "";

            // loop over and collect matching processes.
            List<Process> procList = new List<Process>();
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.ToLower().Contains(processName))
                {
                    string cmdLine = Program.GetCommandLine(proc);
                    // remove the process name.
                    cmdLine = cmdLine.Replace(proc.MainModule.FileName, "").ToLower();
                    // now check the args.
                    if (string.IsNullOrEmpty(processArgs) || cmdLine.Contains(processArgs))
                    {
                        // if no args or ig args make sure they match the process.
                        procList.Add(proc);
                    }
                }
            }

            // check if their were any matches.
            if (procList.Count > 0)
            {
                Console.WriteLine("The following processes matches your query.\n");
                // one or more matches.
                foreach (Process proc in procList)
                {
                    string cmdLine = Program.GetCommandLine(proc);
                    Console.WriteLine($"{proc.Id}\t{proc.ProcessName}\n{cmdLine}\n");
                }
                return 1;
            }
            // no matches.
            return 0;
        }

        // get the command line used to start a process.
        private static string GetCommandLine(Process process)
        {
            string cmd = "";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
            {
                using (ManagementObjectCollection objects = searcher.Get())
                {
                    cmd = objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
                }
            }
            return cmd;
        }

        // prints help infomation and returns the exit code!
        private static int ShowHelpAndExit()
        {
            Console.WriteLine("Min 1 args are required.");
            Console.WriteLine("ipr.exe \"Partial Process Name\" [\"Partial arguments list\"]");
            Console.WriteLine("---");
            Console.WriteLine("Exit codes.");
            Console.WriteLine("0: no error, not matches to the process query.");
            Console.WriteLine("1: Processes running on this system matches, see output.");
            Console.WriteLine("2: Missing arguments.");
            return 2;
        }
    }
}
