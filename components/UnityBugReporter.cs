// System libraries
using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace devunity.components
{
    public class UnityBugReporter
    {
        // Main function
        public static void BugReporter()
        {
            try {
                string fileToWrite = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString() + ".br";

                Console.WriteLine("Writing to file " + fileToWrite);

                using (StreamWriter file = new StreamWriter(fileToWrite, false))
                {
                    file.WriteLine("UNITY PROCESSES -->");
                    Process[] processlist = Process.GetProcesses();
                    foreach (Process process in processlist)
                    {
                        if (process.ProcessName.Contains("unity"))
                        {
                            file.WriteLine("Process Name: {0}; Memory usage: {1}", process.ProcessName, process.WorkingSet64);
                        }
                    }
                    file.WriteLine();
                    Console.WriteLine("Please type the bug details:");
                    string bugDetails = Console.ReadLine();
                    file.WriteLine("BUG DETAILS -->");
                    file.WriteLine(bugDetails);
                    file.WriteLine();
                    Console.WriteLine("Please enter the affected Unity7 program (if you do not know, please type 'dunno'):");
                    string affectedProgram = Console.ReadLine();
                    if (!affectedProgram.Contains("unity") && (!(affectedProgram == "dunno"))) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: NOT A UNITY BUG");
                        Environment.Exit(-1);
                    }
                    file.WriteLine("AFFECTED PACKAGE -->");
                    file.WriteLine(affectedProgram);
                    Console.WriteLine("Do you want to report the bug now? (^C to cancel - ENTER to proceed) ");
                    Console.ReadLine();
                    Console.WriteLine("Redirecting to the Bug Reporter in 5 seconds. Please attach this file: " + fileToWrite + " when reporting the bug. If it gives the error 'Lost something?', make sure you entered the correct package name.");
                    Thread.Sleep(5000);
                    openLaunchpad(affectedProgram);
                }
            }
            catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: FAILED: " + e.Message);
                Environment.Exit(-1);
            }
        }

        public static void openLaunchpad(string pName) {
            if (pName == "dunno")
            {
                Process.Start("xdg-open", "https://bugs.launchpad.net/ubuntu/+filebug?no-redirect");
            }
            else if (pName.Contains("unity"))
            {
                Process.Start("xdg-open", "https://bugs.launchpad.net/ubuntu/+source/" + pName + "/+filebug?no-redirect");
            }
        }
    }
}
