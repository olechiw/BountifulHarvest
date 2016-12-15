﻿using System;
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
            return
                (
               from p in database.Patrons

               where p.PatronID == id

               select p).First<Patron>(); // The can only be one!!
        }



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

        // Get the newest rows. 
        // TODO: Update to use DateTime. This is CURRENTLY BROKEN
        public PatronList GetNewestRows(string lastDate)
        {
            return from p in database.Patrons
                   where Constants.IsBeforeDate(p.DateOfLastVisit.Date.ToString(), lastDate)
                   select p;
        }


        // Get the top x rows
        public PatronList GetTopRows(int rowCount)
        {
            return database.Patrons.Take(rowCount);
        }


        // Add a completely new row
        public void AddRow(
            string firstName,
            string middleInitial,
            string lastName,
            string gender,
            string family,
            DateTime lastVisit,
            DateTime birth,
            string address,
            string phoneNumber,
            string comments,
            DateTime initialVisit)
        {
            Patron row = new Patron
            {
                FirstName = firstName,
                MiddleInitial = middleInitial,
                LastName = lastName,
                Gender = gender,
                Family = family,
                DateOfLastVisit = lastVisit,
                DateOfBirth = birth,
                Address = address,
                PhoneNumber = phoneNumber,
                Comments = comments,
                DateOfInitialVisit = initialVisit
            };

            Patron latestPatron = database.Patrons.OrderByDescending(s => s.PatronID).First();
            if (latestPatron != null)
                row.PatronID = database.Patrons.OrderByDescending(s => s.PatronID).First().PatronID + 1;

            // Account for first entry
            else
                row.PatronID = 1;

            database.Patrons.InsertOnSubmit(row);
            database.SubmitChanges();
        }

        
        public void AddRow(Patron p)
        {
            Patron latestPatron = database.Patrons.OrderByDescending(s => s.PatronID).First();
            if (latestPatron != null)
                p.PatronID = database.Patrons.OrderByDescending(s => s.PatronID).First().PatronID + 1;

            // Account for first entry
            else
                p.PatronID = 1;

            database.Patrons.InsertOnSubmit(p);

            
            try
            {
                database.SubmitChanges();
            }
            catch (SqlTypeException)
            {
                MessageBox.Show("Invalid Date Entered.");
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
