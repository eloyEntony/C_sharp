using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_01_start
{
    class Program
    {
        static void Main(string[] args)
        {
            //process - воконувана програма
            //   PID, Prioryti, status(type), Machine, 
            //tread - потоки
            //
            // BCL - System.Diagnostic
            // Assemblies

            //Process.Start("calc.exe");
            //Process.Start("chrome.exe", "https://google.com");

            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = "chrome.exe";
            //startInfo.WindowStyle = ProcessWindowStyle.Normal;
            //startInfo.Arguments = "https://stackoverflow.com";           

            //Process.Start(startInfo);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "chrome.exe";

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            Console.WriteLine($"ID {process.Id}, " +
                $"Priority {process.BasePriority}" +
                $"Name {process.ProcessName}" +
                $"Main Modul {process.MainModule}" +
                $"Machine {process.MachineName}" +
                $"Start time {process.StartTime}");

            Thread.Sleep(2000);
            process.Kill();


            Process.GetProcesses();

            foreach (var proc in Process.GetProcesses())
            {
                Console.WriteLine($"ID {proc.Id}");
            }
        }
    }
}
