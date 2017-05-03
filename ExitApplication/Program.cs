using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExitApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Common.Constants.SetupLogger(args);

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
        }
    }
}
