using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Little_Guys_In_Your_Computer_Server
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var components = new System.ComponentModel.Container();
            var icon = new NotifyIcon(components);

            icon.Icon = new System.Drawing.Icon("temp.ico");
            icon.Visible = true;

            var aTimer = new System.Timers.Timer(1000);

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            Application.Run();
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            lineChanger(cpu.NextValue() + "%", "stats.txt", 1);
        }
    }
}
