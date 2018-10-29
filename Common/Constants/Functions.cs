using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

//
// Constants - A class containing the constant value of all important things
//

namespace Common
{
    public static partial class Constants
    {
        public static void SetupLogger(string[] args)
        {
            Logger.CurrentDateTime = DateTime.Now.ToString(DateTimeFormat);
            if (args.Contains("--Debug") ||
                args.Contains("-d") ||
                args.Contains("--debug") ||
                args.Contains("-D"))
            {
                Logger.ArgumentDebug = true;
                Logger.Log("Launched with debugger mode!");
            }
            if (!args.Contains("--local")) return;

            Logger.Log("Launching in local Mode");
            Isrelease = false;
        }

        public static void DatabaseFailed()
        {
            MessageBox.Show("Error: Failed to load all patrons. Your DB connection is probably broken");
            MessageBox.Show("Check the internet connection on both devices!");
        }

        public static DateTime ConvertString2Date(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                s += " 00:00";
                try
                {
                    return DateTime.ParseExact(s, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
                }
                catch
                {
                    MessageBox.Show("Invalid date in converting a string to date. Offender " + s);
                    return new DateTime();
                }
            }

            var date = new DateTime(1900, 1, 1, InvalidHour, 1, 1);
            return date;
        }

        public static int SafeConvertInt(string s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception)
            {
                Logger.Log("Input SafeConvertInt string: '" + s + "' invalid!");
                return InvalidId;
            }
        }

        public static DateTime SafeConvertDate(string s)
        {
            var d = new DateTime();
            try
            {
                d = Convert.ToDateTime(s);
            }
            catch (Exception)
            {
            }
            return d;
        }

        public static string ConjuncDate(string mm, string dd, string yy)
        {
            return mm + '/' + dd + '/' + yy;
        }

        // Combine a first, last, and middle name
        public static string ConjuncName(string f, string m, string l)
        {
            var final = f;
            if (!string.IsNullOrEmpty(m))
                final += ' ' + m;
            if (!string.IsNullOrEmpty(l))
                final += ' ' + l;
            return final;
        }

        // Convert a datetime to the proper format of string
        public static string ConvertDateTime(DateTime d)
        {
            return d.Date.ToString(DateFormat);
        }

        // Get the designated column of the selected row of a data view as an integer
        public static int GetSelectedInt(DataGridView view, int index)
        {
            return SafeConvertInt(view.SelectedRows[0].Cells[index].Value.ToString());
        }


        // Initialize a datagridview
        public static void InitializeDataView(DataGridView view)
        {
            foreach (DataGridViewColumn c in view.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;

            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Check whether a patron's last visit date is valid
        public static bool CanVisit(DateTime date)
        {
            var t = DateTime.Today;

            if (date.Year != t.Year)
                return true;

            if (date.Month != t.Month)
                return true;

            // TODO: CHECK PROPER DAY
            // else if (date.Day )
            return false;
        }


        public static int GetLatestVisitId(BountifulHarvestContext databaseContext)
        {
            var id = 0;

            var query =
                (from v in databaseContext.Visits select v).OrderByDescending(visit => visit.VisitID);
            id = !query.Any() ? 1 : query.First().VisitID + 1;

            return id;
        }

        public static int GetLatestPatronId(BountifulHarvestContext databaseContext)
        {
            var id = 0;

            var query =
                (from p in databaseContext.Patrons select p).OrderByDescending(patron => patron.PatronId);
            id = !query.Any() ? 1 : query.First().PatronId + 1;

            return id;
        }

        public static int LevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
                return s.Length;

            var n = s.Length;
            var m = t.Length;
            var d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (var i = 0; i <= n; d[i, 0] = i++) ;
            for (var j = 1; j <= m; d[0, j] = j++) ;

            for (var i = 1; i <= n; i++)
            for (var j = 1; j <= m; j++)
            {
                var cost = t[j - 1] == s[i - 1] ? 0 : 1;
                var min1 = d[i - 1, j] + 1;
                var min2 = d[i, j - 1] + 1;
                var min3 = d[i - 1, j - 1] + cost;
                d[i, j] = Math.Min(Math.Min(min1, min2), min3);
            }
            return d[n, m];
        }

        /*
         * A more sophisticated query with the CSV Family columns is easier handled in pure SQL.
         * This function parses the CSV with TRANSACT-SQL XmlData, and then joins together a table
         * of all csv search terms. Use with String.Format or ExecuteQuery, to replace {0} with 
         * argument.
         */
        public static string DuplicatePatronsQuery()
        {
            return @"

DECLARE @SearchText VARCHAR(MAX) = '{0}'

;WITH SearchTable AS (
    SELECT LTRIM(O.splitdata) AS Searchdata
    FROM (
        SELECT CAST('<X>'+replace(@SearchText,',','</X><X>')+'</X>' AS XML) AS XmlData
        ) AS xT
     CROSS APPLY
     ( 
         SELECT xdata.D.value('.', 'VARCHAR(MAX)') AS splitdata 
         FROM xT.XmlData.nodes('X') as xdata(D)
     ) O
), SplitTable AS (

    SELECT xT.PatronID,
     LTRIM(O.splitdata) AS splitdata
    FROM (
        SELECT *, CAST('<X>'+replace(T.Family,',','</X><X>')+'</X>' AS XML) AS XmlData
        FROM Patrons AS T
        ) AS xT
     CROSS APPLY
     ( 
         SELECT xdata.D.value('.', 'VARCHAR(MAX)') AS splitdata 
         FROM xT.XmlData.nodes('X') as xdata(D)
     ) O

), DistinctOutput AS(
	SELECT DISTINCT CT.PatronID 
	FROM Patrons as CT
	INNER JOIN SplitTable as SplitT
		ON SplitT.PatronID = CT.PatronID
	INNER JOIN SearchTable as SrchT
		ON (SrchT.Searchdata LIKE SplitT.splitdata
		OR SrchT.SearchData LIKE CT.FirstName + ' '  + CT.LastName)
		AND NOT SrchT.SearchData = '')
SELECT Patrons.*
FROM DistinctOutput
INNER JOIN Patrons ON Patrons.PatronID = DistinctOutput.PatronID;";
        }
    }
}