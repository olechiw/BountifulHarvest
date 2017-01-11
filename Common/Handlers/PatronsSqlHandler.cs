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

using PatronList = System.Linq.IQueryable<Common.Patron>;

//
// SqlHandler - A class responsible for all communication with the SqlServer
//


namespace Common
{
    public class PatronsSqlHandler
    {
        // The database
        private BountifulHarvestContext database;



        public PatronsSqlHandler(string connectString)
        {
            database = new BountifulHarvestContext(connectString);
        }



        // Get the entire row based on a specific patron id. This is a REFERENCE OBJECT
        public Patron GetRow(int id)
        {
            try
            {
            var results =
                (
               from p in database.Patrons

               where p.PatronID == id

               select p); 

               return results.First<Patron>(); // There can only be one!!
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to find Patron with ID " + id);
                MessageBox.Show(e.ToString());
                return new Common.Patron();
            }
        }

        // Get all the rows with a specific id (get the iqueryable)
        public PatronList GetRows(int id) =>
            from p in database.Patrons

            where p.PatronID == id

            select p;



        // Get a row based on a query of similar values
        public PatronList GetRowsSimilar(string query)
        {
            var predicate = PredicateBuilder.False<Patron>();

            string q = "%" + query + "%";

            predicate = predicate.Or(p => SqlMethods.Like(p.FirstName, q));
            predicate = predicate.Or(p => SqlMethods.Like(p.LastName, q));
            predicate = predicate.Or(p => SqlMethods.Like(p.Family, q));

            return database.Patrons.Where(predicate);
        }

        #region Kept for Historical Relevance
        /*
        // Get the newest rows. 
        // TODO: Update to use DateTime. This is CURRENTLY BROKEN
        public PatronList GetNewestRows(string lastDate)
        {
            return from p in database.Patrons
                   where Constants.IsBeforeDate(p.DateOfLastVisit.Date.ToString(), lastDate)
                   select p;
        }
        */
        #endregion

        public PatronList GetNewestRows(DateTime date)
        {
            return from p in database.Patrons
                   where p.DateOfLastVisit < date
                   select p;
        }


        // Get the top x rows
        public PatronList GetTopRows(int rowCount)
        {
            return database.Patrons.Take(rowCount);
        }


        public int GetLatestID()
        {
            int id;

            PatronList latestPatron = database.Patrons.OrderByDescending(s => s.PatronID);
            try
            {
                id = latestPatron.First().PatronID + 1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }



        bool failedLast = false;
        public void AddRow(Patron p)
        {
            p.PatronID = GetLatestID();

            if (!failedLast)
                database.Patrons.InsertOnSubmit(p);
            
            try
            {
                database.SubmitChanges();
                failedLast = false;
            }
            catch (SqlTypeException)
            {
                MessageBox.Show("Invalid Date of Birth entered.");
                failedLast = true;
            }
        }



        // Delete an item from the table, given the following values
        public void DeleteRow(int id)
        {
            Patron patron =
                (from p in database.Patrons
                 where p.PatronID == id
                 select p).First<Patron>(); // There can only be one

            database.Patrons.DeleteOnSubmit(patron);
            database.SubmitChanges();
        }


        // Send the changes to the sql server
        public void Update() => database.SubmitChanges();
    }
}
