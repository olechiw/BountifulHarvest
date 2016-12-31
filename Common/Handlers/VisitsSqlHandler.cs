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
            try
            {
                return
            (
            from v in database.Visits

            where v.VisitID == id

            select v
            ).First<Visit>();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to find Visit with ID " + id);
                return null;
            }
        }

        // Get all of a patron's vists
        public VisitList GetPatronsRows(int id) =>
                from v in database.Visits

                where v.PatronID == id

                select v;

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
        public VisitList GetNewestRows(DateTime date) =>
            from v in database.Visits
                   where v.DateOfVisit < date
                   select v;

        // Get the top x rows
        public VisitList GetTopRows(int rowCount) => 
            database.Visits.Take(rowCount);

        // Get the rows for this month
        public VisitList GetMonthRows() =>
            from v in database.Visits
                   where v.DateOfVisit.Month == DateTime.Now.Month
                   select v;

        

        public int GetLatestID()
        {
            int id;
            VisitList latestVisit = database.Visits.OrderByDescending(v => v.VisitID);
            try
            {
                id = latestVisit.First().VisitID + 1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
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


