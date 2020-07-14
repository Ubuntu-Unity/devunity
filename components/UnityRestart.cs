// System libraries
using System;
using System.Diagnostics;

namespace devunity.components
{
    public class UnityRestart
    {
        // Main function
        public static void RestartUnity()
        {
            Console.Write("Are you sure? This may disrupt some running apps. In a dual monitor setup, some apps might move to the other display. To proceed, press ENTER, and to cancel, press ^C.");
            Console.ReadLine();

            new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "unity",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            }.Start();
        }
    }
}
