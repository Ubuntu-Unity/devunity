// System libraries
using System;
using System.Diagnostics;

namespace devunity.components
{
    public class UnityProcessStatus
    {
        // Main function
        public static void ProcessStatus()
        {
            Console.Write("Process to get status of: ");
            string pName = Console.ReadLine();
            if (pName.Contains("unity"))
            {
                try
                {
                    Process[] pArray = Process.GetProcessesByName(pName);
                    foreach (Process p in pArray)
                    {
                        Console.WriteLine($"{pName}:");
                        Console.WriteLine();
                        Console.WriteLine($"  Process ID                : {p.Id}");
                        Console.WriteLine($"  Physical memory usage     : {p.WorkingSet64}");
                        Console.WriteLine($"  User processor time       : {p.UserProcessorTime}");
                        Console.WriteLine($"  Privileged processor time : {p.PrivilegedProcessorTime}");
                        Console.WriteLine($"  Total processor time      : {p.TotalProcessorTime}");
                        Console.WriteLine("   -----------------------------------------------------");
                        Console.WriteLine();
                    }
                    
                } catch {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: NO SUCH PROCESS");
                    Environment.Exit(127);
                }
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: NOT A UNITY PROCESS");
                Environment.Exit(-1);
            }
        }
    }
}
