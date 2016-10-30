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
    class Constants
    {
        #region Constant Names of All Sql Columns

        // Patrons table
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string MiddleInitial = "MiddleInitial";
        public const string Gender = "Gender";
        public const string Family = "Family";
        public const string DateOfLastVisit = "LastVisit";
        public const string DateOfBirth = "DateOfBirth";
        public const string Address = "Address";
        public const string PhoneNumber = "PhoneNumber";
        public const string Comments = "Comments";
        public const string InitialVisitDate = "InitialVisitDate";

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