using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
// SqlHandler - A class responsible for all communication with the SqlServer
//

namespace Common
{
    // Somewhere to put all of the SqlConstants neatly
    class Constants
    {
        #region Constants for Querying SQL Columns

        // Hardcoded strings for all of the column names in SQL
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
    }
}


namespace Common
{
    class SqlHandler
    {
    }
}
