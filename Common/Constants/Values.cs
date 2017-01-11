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
        public const bool ISRELEASE = false;

        // The sql connection debugging string
        public const string debugConnectionString = "Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id = sa; Password=potato";

        // Release ip address for the server
        public const string releaseServerConnectionString = "Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id = sa; Password=harvest";

        // Release ip address for the client
        public const string releaseExitConnectionString = "Server=192.168.2.4\\SQLEXPRESS;Database=BountifulHarvest;User ID = sa; Password=harvest";

        // The image of the form to print
        public const string printFormImage = "form2.png";
        // The release image location
        public const string releaseFormImage = "form.png";

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
            Age,
            Family,
            PatronID
        }
    }

}