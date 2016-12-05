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
    // Somewhere to put all of the SqlConstants neatly
    public static class Constants
    {
        // Available tables in the database
        public static class Tables
        {
            public static string Patrons = "Patrons";
            public static string Visits = "Visits";
        }


        #region Constant Names of All Sql Columns

        // Patrons table
        public static string FirstName = "FirstName";
        public static string LastName = "LastName";
        public static string MiddleInitial = "MiddleInitial";
        public static string Gender = "Gender";
        public static string Family = "Family";
        public static string DateOfLastVisit = "DateOfLastVisit";
        public static string DateOfBirth = "DateOfBirth";
        public static string Address = "Address";
        public static string PhoneNumber = "PhoneNumber";
        public static string Comments = "Comments";
        public static string DateOfInitialVisit = "DateOfInitialVisit";

        #endregion

        #region Constant Indexes of All SqlColumns, as Enums

        // Patrons table
        public enum PatronIndexes
        {
            FirstName,
            MiddleInitial,
            LastName,
            Gender,
            Family,
            DateOfLastVisit,
            DateOfBirth,
            Address,
            PhoneNumber,
            Comments,
            InitialVisitDate
        }

        #endregion

        public static bool IsBeforeDate(string date, string lastDate)
        {
            string[] previousDate = lastDate.Split('/');

            int prevMonth = Convert.ToInt32(previousDate[0]);
            int prevDay = Convert.ToInt32(previousDate[1]);
            int prevYear = Convert.ToInt32(previousDate[2]);

            string[] newDate = date.Split('/');

            int newMonth = Convert.ToInt32(newDate[0]);
            int newDay = Convert.ToInt32(newDate[1]);
            int newYear = Convert.ToInt32(newDate[2]);

            if (newYear < prevYear)
                return false;
            else if (newMonth < prevMonth)
                return false;
            else if (newDay < prevDay)
                return false;
            else
                return true;
        }
    }
}