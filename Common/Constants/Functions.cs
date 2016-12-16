using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// Constants - A class containing the constant value of all important things
//

namespace Common
{
    public static partial class Constants
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
    }
}
