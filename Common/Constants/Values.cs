using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Globalization;
using System.Drawing;


//
// Constants - A class containing the constant value of all important things
//

namespace Common
{
    // Somewhere to put all of the SqlConstants neatly
    public partial class Constants
    {
        // Coordinates for where to draw each label. I'm a hack
        public static readonly Point namePoint = new Point(75, 780);
        public static readonly Point limitsPoint = new Point(135, 890);
        public static readonly Point familyPoint = new Point(130, 930);
        public static readonly Point datePoint = new Point(5, 970);
        public static readonly Point idPoint = new Point(5, 1020);

        public const bool ISRELEASE = false;

        public const string DateFormat = "MM/dd/yyyy";
        public const string TimeFormat = "HH:mm:ss";
        public const string DateTimeFormat = "MM-dd-yyyy-HH-mm-ss";

        public const int InvalidID = -1;
        public const int InvalidHour = 10;

        public static readonly CultureInfo DateCulture = CultureInfo.InvariantCulture;

        // The sql connection debugging string
        public const string debugConnectionString = "Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id = sa; Password=potato";

        // Release ip address for the server
        public const string releaseServerConnectionString = "Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id = sa; Password=harvest";

        // Release ip address for the client
        public const string releaseExitConnectionString = "Server=192.168.1.99\\SQLEXPRESS;Database=BountifulHarvest;User ID = sa; Password=harvest";

        // The image of the form to print
        public const string printFormImage = "form2.png";
        // The release image location
        public const string releaseFormImage = "form.png";

        // Visits table indexes (SQL)
        public enum VisitIndexes
        {
            FirstName,
            MiddleInitial,
            LastName,
            TotalPounds,
            DateOfVisit,
            VisitID,
            PatronID
        }

        // Index of specific items in the datagridview for Patrons
        public enum PatronIndexes
        {
            FirstName,
            MiddleInitial,
            LastName,
            Gender,
            DateOfBirth,
            Age,
            Family,
            PatronID
        }
    }

}