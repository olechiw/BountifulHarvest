using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EntryApplication
{
    static class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BeginInterfaceForm());
        }
    }
}