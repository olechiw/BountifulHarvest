using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Common;

namespace EntryApplication
{
    static class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        [STAThread]
        static void Main(string[] args)
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
        }
    }
}