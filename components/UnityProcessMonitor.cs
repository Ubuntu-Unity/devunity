// System libraries
using System;
using System.Threading;
using System.Diagnostics;
using devunity.includes;

namespace devunity.components
{
    public class UnityProcessMonitor
    {
        // Definitions
        static Process[] processlist = Process.GetProcesses();

        // Main function
        public static void ProcessMonitor()
        {
            // Clear console
            Console.Clear();
            // Print info
            printInfo();
            // Start printing debug info
            for (;;)
            {
                printProcesses();
                Thread.Sleep(1000);
                Console.Clear();
                updateProcesses();
                printInfo();
            }
        }

        // Print info
        static void printInfo() 
        {
            // Save current color
            int origColor = (int) Console.ForegroundColor;
            // Print app info
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Devunity - by Rudra Saraswat");
            Console.WriteLine("============================");
            Console.WriteLine();
            Console.ForegroundColor = (ConsoleColor) origColor;
        }

        // Print processes
        static void printProcesses()
        {
            Table.PrintLine();
            Table.PrintRow("Process", "ID", "Time Started");
            Table.PrintLine();
            foreach(Process process in processlist)
            {
                if (process.ProcessName.Contains("unity"))
                {
                    Table.PrintRow(process.ProcessName, process.Id + "", process.StartTime.ToString("dd/MM/yyyy HH:mm:ss"));
                    Table.PrintLine();
                }
            }
        }

        static void updateProcesses()
        {
            processlist = Process.GetProcesses();
        }
    }
}
