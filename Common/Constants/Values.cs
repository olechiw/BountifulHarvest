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
    public static partial class Constants
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
            PatronId
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
            VisitId,
            PatronId
        }

        public const string DateFormat = "MM/dd/yyyy";
        public const string TimeFormat = "HH:mm:ss";
        public const string DateTimeFormat = "MM-dd-yyyy-HH-mm-ss";

        public const int InvalidId = -1;
        public const int InvalidHour = 10;

        // The sql connection debugging string
        public const string DebugConnectionString =
            "Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id = sa; Password=potato";

        // The release image location
        public const string ReleaseFormImage = "form.png";

        // Coordinates for where to draw each label. I'm a hack
        public static readonly Point NamePoint = new Point(75, 780);

        public static readonly Point LimitsPoint = new Point(135, 890);
        public static readonly Point FamilyPoint = new Point(130, 930);
        public static readonly Point DatePoint = new Point(5, 965);
        public static readonly Point VeteranPoint = new Point(85, 990);
        public static readonly Point IdPoint = new Point(5, 1020);
        public static readonly Point CfspPoint = new Point(5, 1045);
        public static readonly Point SeniorsPoint = new Point(150, 1045);
        public static readonly Point EveryWeekPoint = new Point(150, 1015);


        public static readonly Point EasterPoint = new Point(690, 690);
        public static readonly Point ThanksgivingPoint = new Point(735, 725);
        public static readonly Point WinterPoint = new Point(688, 807);
        public static readonly Point SchoolPoint = new Point(785, 830);
        public static readonly Point HalloweenPoint = new Point(686, 857);
        public static readonly Point ChristmasPoint = new Point(723, 764);

        public static readonly CultureInfo DateCulture = CultureInfo.InvariantCulture;

        public static bool Isrelease = true;

        public static string LoadReleaseServerString()
        {
            try
            {
                return File.ReadAllText("releaseAuthServer.cfg");
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Invalid Date of Birth Entered.");
                return "";
            }
        }

        public static string LoadReleaseExitString()
        {
            try
            {
                return File.ReadAllText("releaseAuthExit.cfg");
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Invalid Date of Birth Entered.");
                return "";
            }
        }
    }
}