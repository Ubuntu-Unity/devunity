// System libraries
using System;
using System.Diagnostics;
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
                    Console.WriteLine("Please enter the affected Unity7 program (if you do not know, please type 'do not know'):");
                    string affectedProgram = Console.ReadLine();
                    file.WriteLine("AFFECTED PROGRAM -->");
                    file.WriteLine(affectedProgram);
                    Console.WriteLine("Please send the file (or its contents): " + fileToWrite + " when reporting the bug.");
                }
            } catch {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: FAILED");
                Environment.Exit(-1);
            }
        }
    }
}
