using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


//
// Constants - A class containing the constant value of all important things
//

namespace Common
{
    // Somewhere to put all of the SqlConstants neatly
    public static partial class Constants
    {
        // The sql connection debugging string
        public const string debugConnectionString = "Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id = sa; Password=potato";

        // Available tables in the database
        public static class Tables
        {
            public static string Patrons = "Patrons";
            public static string Visits = "Visits";
        }

        // Patrons table indexes (SQL)
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

        // Visits table indexes (SQL)
        public enum VisitIndexes
        {
            FirstName,
            MiddleInitial,
            LastName,
            TotalPounds,
            DateOfVisit,
            VisitID
        }

        // Index of specific items in the datagridview for Patrons
        public enum OutputDataColumnsPatrons
        {
            FirstName,
            MiddleInitial,
            LastName,
            Gender,
            DateOfLastVisit,
            DateOfBirth,
            Family,
            PatronID
        }
    }

}