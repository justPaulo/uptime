using System;
using System.Diagnostics;
using System.Windows.Forms; // só para poder suportar a caixa de diálogo básica

namespace uptime
{
    class Program
    {
        public static string ConvertSecondsToDate(string seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(seconds));

             if (t.Days > 0)
                return t.ToString(@"d\d\,\ hh\:mm\:ss");

            return t.ToString(@"hh\:mm\:ss");
        }

        public static int getUpTime()
        {
            PerformanceCounter pc = new PerformanceCounter("System", "System Up Time");
            pc.NextValue();
            int uptime = (int)pc.NextValue();

            return uptime;
        }

        static void Main(string[] args)
        {
            Console.Title = "Welcome to Uptime system utility - the missing NT command...";

            if (args.Length > 0)
            {
                if (args[0] == "-g")
                    { DialogResult res = MessageBox.Show(ConvertSecondsToDate(getUpTime().ToString()), "Uptime", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                if (args[0] == "-t")
                    Console.WriteLine("Uptime: {0}", ConvertSecondsToDate(getUpTime().ToString()));
            }
            else
                Console.WriteLine("\nUSAGE: uptime [-g] ^ [-t]");
        }
    }
}