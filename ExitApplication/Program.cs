using System;
using System.Windows.Forms;
using Common;

namespace ExitApplication
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Constants.SetupLogger(args);

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BeginInterfaceForm());
            }
            catch (Exception e)
            {
                Logger.Log("Exception in general application: " + e.Message);
                Logger.Log(e.StackTrace);
            }

            if (!Constants.ISRELEASE)
                Console.ReadLine();
        }
    }
}