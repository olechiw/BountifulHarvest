using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Logger
    {
        /*
         * Functions for hiding and showing the console window, I like the live logging.
         */
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public static Boolean ArgumentDebug = false;
        public static String CurrentDateTime = "";

        public static void Log(string text)
        {
            // Console is shown by default, if this is release and it hasnt got my special argument, then hide it.
            if (Constants.ISRELEASE && !ArgumentDebug)
                ShowWindow(GetConsoleWindow(), SW_HIDE);

            string file = 
                "BHLogs\\Bountiful-Harvest-" +
                CurrentDateTime +
                ".txt";
            System.IO.Directory.CreateDirectory("BHLogs");
            System.IO.StreamWriter writer = new System.IO.StreamWriter(file, true);

            String output = DateTime.Now.ToString(Constants.DateTimeFormat) +
                " " +
                text;

            writer.WriteLine(output);
            writer.Close();

            Console.WriteLine(output);
        }
    }
}
