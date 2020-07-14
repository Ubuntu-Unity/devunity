// System libraries
using System;
using System.Threading;
using System.Diagnostics;
using devunity.components;

namespace devunity
{
    class Program
    {
        // Definitions
        static Process[] processlist = Process.GetProcesses();

        // Main function
        static int Main(string[] args)
        {
            // Clear console
            Console.Clear();

            // Save current color
            int origColor = (int) Console.ForegroundColor;

            // Print app info
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Devunity - by Rudra Saraswat");
            Console.WriteLine("============================");
            Console.WriteLine();
            Console.ForegroundColor = (ConsoleColor) origColor;

            // Parse arguments
            if (!(args.Length == 0))
                foreach (string arg in args) {
                    switch (arg) {
                        case "-pm": case "--process-monitor":
                            UnityProcessMonitor.ProcessMonitor();
                            break;

                        case "-rb": case "--report-bug":
                            UnityBugReporter.BugReporter();
                            break;

                        case "-ru": case "--restart-unity":
                            UnityRestart.RestartUnity();
                            break;

                        case "-rl": case "--restart-lightdm":
                            UnityLightDMControl.LightDMRestart();
                            break;

                        case "-sl": case "--stop-lightdm":
                            UnityLightDMControl.LightDMStop();
                            break;

                        case "-gp": case "--get-process-status":
                            UnityProcessStatus.ProcessStatus();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: NO SUCH COMMAND");
                            return 127;
                    }
                }
            else
            {
                Console.WriteLine("Devunity is a program for debugging Unity7.\n\nSYNTAX:\n\n\tdevunity ARGUMENT\n\nwhere ARGUMENT stands for one of the following:\n\n\t-pm | --process-monitor: Unity Process Monitor\n\n\t-rb | --report-bug: Unity Bug Report Generator\n\n\t-ru | --restart-unity: Restart Unity\n\n\t-gp | --get-process-status: Detailed Process Status\n\n\t-rl | --restart-lightdm: Restart Lightdm\n\n\t-sl | --stop-lightdm: Stop LightDM");return 1;
            }

            return 0;
        }
    }
}
