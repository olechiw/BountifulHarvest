using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;


//
// Constants - A class containing the constant value of all important things
//

namespace Common
{
    // Somewhere to put all of the SqlConstants neatly
    public partial class Constants
    {
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

        // Visits table indexes (SQL)
        public enum VisitIndexes
        {
            FirstName,
            MiddleInitial,
            LastName,
            TotalPounds,
            DateOfVisit,
            Extras,
            VisitID,
            PatronID
        }

        public const string DateFormat = "MM/dd/yyyy";
        public const string TimeFormat = "HH:mm:ss";
        public const string DateTimeFormat = "MM-dd-yyyy-HH-mm-ss";

        public const int InvalidID = -1;
        public const int InvalidHour = 10;

        // The sql connection debugging string
        public const string debugConnectionString =
            "Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id = sa; Password=potato";

        public static string loadReleaseServerString()
        {
            try
            {
                return File.ReadAllText("releaseAuthServer.cfg");
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to Load Authentication");
                return "";
            }
        }

        public static string loadReleaseExitString()
        {
            try
            {
                return File.ReadAllText("releaseAuthExit.cfg");
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to Load Authentication");
                return "";
            }
        }

        // The release image location
        public const string releaseFormImage = "form.png";

        // Coordinates for where to draw each label. I'm a hack
        public static readonly Point namePoint = new Point(75, 780);

        public static readonly Point limitsPoint = new Point(135, 890);
        public static readonly Point familyPoint = new Point(130, 930);
        public static readonly Point datePoint = new Point(5, 965);
        public static readonly Point veteranPoint = new Point(85, 990);
        public static readonly Point idPoint = new Point(5, 1020);
        public static readonly Point cfspPoint = new Point(5, 1045);
        public static readonly Point seniorsPoint = new Point(150, 1045);
        public static readonly Point everyWeekPoint = new Point(150, 1015);


        public static readonly Point easterPoint = new Point(690, 690);
        public static readonly Point thanksgivingPoint = new Point(735, 725);
        public static readonly Point winterPoint = new Point(688, 807);
        public static readonly Point schoolPoint = new Point(785, 830);
        public static readonly Point halloweenPoint = new Point(686, 857);
        public static readonly Point christmasPoint = new Point(723, 764);

        public static readonly CultureInfo DateCulture = CultureInfo.InvariantCulture;

        public static bool ISRELEASE = true;
    }
}