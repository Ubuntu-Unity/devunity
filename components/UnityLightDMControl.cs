// System libraries
using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace devunity.components
{
    public class UnityLightDMControl
    {
        public static void LightDMStop()
        {
            Console.Write("Are you sure? This command assumes you are using LightDM. This operation will disrupt all running apps. To proceed, press ENTER, and to cancel, press ^C.");
            Console.ReadLine();

            new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "service",
                    Arguments = "lightdm stop",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            }.Start();
        }

        public static void LightDMRestart()
        {
            Console.Write("Are you sure? This command assumes you are using LightDM. This operation will disrupt all running apps. To proceed, press ENTER, and to cancel, press ^C.");
            Console.ReadLine();

            new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "service",
                    Arguments = "lightdm restart",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            }.Start();
        }
    }
}
