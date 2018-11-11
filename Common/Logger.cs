using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Common
{
    public static class Logger
    {
        private const int SwHide = 0;
        private const int SwShow = 5;

        public static bool ArgumentDebug = false;

        public static string CurrentDateTime = "";

        /*
         * Functions for hiding and showing the console window, I like the live logging.
         */
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static void SetConsoleEnabled(bool enabled)
        {
            ShowWindow(GetConsoleWindow(), enabled ? SwShow : SwHide);
        }

        public static void Log(string text)
        {
            // Console is shown by default, if this is release and it hasnt got my special argument, then hide it.
            if (Constants.Isrelease && !ArgumentDebug)
                SetConsoleEnabled(false);

            var file =
                "BHLogs\\Bountiful-Harvest-" +
                CurrentDateTime +
                ".txt";
            Directory.CreateDirectory("BHLogs");
            var writer = new StreamWriter(file, true);

            var output = DateTime.Now.ToString(Constants.DateTimeFormat) +
                         " " +
                         text;

            //writer.WriteLine(output); disabled now
            writer.Close();

            Console.WriteLine(output);
        }
    }
}