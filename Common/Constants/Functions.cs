using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
// Constants - A class containing the constant value of all important things
//

namespace Common
{
    public partial class Constants
    {
        #region Kept for Historical Relevance
        /*
        public static bool IsBeforeDate(string date, string lastDate)
        {
            string[] previousDate = lastDate.Split('/');

            int prevMonth = SafeConvertInt(previousDate[0]);
            int prevDay = SafeConvertInt(previousDate[1]);
            int prevYear = SafeConvertInt(previousDate[2]);

            string[] newDate = date.Split('/');

            int newMonth = SafeConvertInt(newDate[0]);
            int newDay = SafeConvertInt(newDate[1]);
            int newYear = SafeConvertInt(newDate[2]);

            if (newYear < prevYear)
                return false;
            else if (newMonth < prevMonth)
                return false;
            else if (newDay < prevDay)
                return false;
            else
                return true;
        }
        */
        #endregion

        public static DateTime ConvertString2Date(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s += " 00:00";
                return DateTime.ParseExact(s, "MM/dd/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }

            else

                return new DateTime();
        }

        public static int SafeConvertInt(string s)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(s);
            }
            catch (Exception)
            {

            }
            return i;
        }

        public static DateTime SafeConvertDate(string s)
        {
            DateTime d = new DateTime();
            try
            {
                d = Convert.ToDateTime(s);
            }
            catch (Exception)
            {

            }
            return d;
        }

        public static string ConjuncDate(string mm, string dd, string yy) =>
            (mm + '/' + dd + '/' + yy);

        // Combine a first, last, and middle name
        public static string ConjuncName(string f, string m, string l)
        {
            string final = f;
            if (!string.IsNullOrEmpty(m))
                final += ' ' + m;
            if (!string.IsNullOrEmpty(l))
                final += ' ' + l;
            return final;
        }

        // Convert a datetime to the proper format of string
        public static string ConvertDateTime(DateTime d) => d.Date.ToString("d");

        // Get the designated column of the selected row of a data view as an integer
        public static int GetSelectedInt(System.Windows.Forms.DataGridView view, int index) =>
            Constants.SafeConvertInt(view.SelectedRows[0].Cells[index].Value.ToString());



        // Initialize a datagridview
        public static void InitializeDataView(DataGridView view)
        {
            foreach (DataGridViewColumn c in view.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Check whether a patron's last visit date is valid
        public static bool CanVisit(DateTime date)
        {
            DateTime t = DateTime.Today;

            if (date.Year != t.Year)
                return true;

            else if (date.Month != t.Month)
                return true;


            // TODO: CHECK PROPER DAY
            // else if (date.Day )
            else
                return false;
        }
    }
}
