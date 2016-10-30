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
    }
}