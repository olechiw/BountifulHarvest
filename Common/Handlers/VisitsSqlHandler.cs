using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Data.Linq.SqlClient;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using Common;

using VisitList = System.Linq.IQueryable<Common.Visit>;

//
// SqlHandler - A class responsible for all communication with the SqlServer
//

namespace Common
{
    public class VisitsSqlHandler
    {
        // The actual database
        private BountifulHarvestContext database;

        // Constructor
        public VisitsSqlHandler(string connectString)
        {
            database = new BountifulHarvestContext(connectString);
        }

        // Get all the data about a specific row
        public Visit GetRow(int id)
        {
            return
            (
                from v in database.Visits

                where v.VisitID == id

                select v
            ).First<Visit>();
        }

        #region Kept for Historical Relevance
        /*
        // Return all the latest rows from a date
        // TODO: Update to use DateTime. THIS IS CURRENTLY BROKEN
        public VisitList GetNewestRows(string lastDate)
        {
            return from v in database.Visits
                   where Constants.IsBeforeDate(v.DateOfVisit.Date.ToString(), lastDate)
                   select v;
        }
        */
        #endregion

        // Return all the latest rows before a date
        public VisitList GetNewestRows(DateTime date)
        {
            return from v in database.Visits
                   where v.DateOfVisit < date
                   select v;
        }

        // Get the top x rows
        public VisitList GetTopRows(int rowCount)
        {
            return database.Visits.Take(rowCount);
        }

        

        public int GetLatestID()
        {
            int id;
            VisitList latestVisit = database.Visits.OrderByDescending(v => v.VisitID);
            try
            {
                id = latestVisit.First().VisitID;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }

        // A a new, unique row.
        public void AddRow(
            string patronFirstName,
            string patronMiddleInitial,
            string patronLastName,
            int totalPounds,
            DateTime dateOfVisit,
            int sizeOfFamily)
        {
            Visit visit = new Visit
            {
                PatronFirstName = patronFirstName,
                PatronMiddleInitial = patronMiddleInitial,
                PatronLastName = patronLastName,
                TotalPounds = totalPounds,
                DateOfVisit = dateOfVisit,
                SizeOfFamily = sizeOfFamily,
                VisitID = GetLatestID()
            };

            database.Visits.InsertOnSubmit(visit);
            database.SubmitChanges();
        }

        // Add a preloaded row
        public void AddRow(Visit visit)
        {
            visit.VisitID = GetLatestID();

            database.Visits.InsertOnSubmit(visit);
            database.SubmitChanges();
        }

        // Delete a specific row
        public void DeleteRow(int id)
        {
            Visit visit = (from v in database.Visits
                           where v.VisitID == id
                           select v).First<Visit>(); // There can only be one

            database.Visits.DeleteOnSubmit(visit);
            database.SubmitChanges();
        }

       // Forcibly updated the server, currently unused
        public void Update() => database.SubmitChanges();
    }
}


