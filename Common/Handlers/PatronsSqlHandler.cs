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

using PatronList = System.Linq.IQueryable<Common.Patron>;

//
// SqlHandler - A class responsible for all communication with the SqlServer
//


namespace Common
{
    public class SqlHandler
    {
        // The database
        private BountifulHarvestContext database;



        public SqlHandler(string ip, string user, string pass)
        {
            string connectString = "server=" + ip + ";table= Patrons;User Id=" + user + ";Password=" + pass;
            database = new BountifulHarvestContext(connectString);
        }



        // Get the entire row based on a specific patron id. This is a REFERENCE OBJECT
        public Patron GetRow(int id)
        {
            Patron result =
                (
               from p in database.Patrons

               where p.PatronID == id

               select p).First<Patron>(); // The can only be one!!

            return result;
        }



        // Get a row based on a query of similar values
        public PatronList GetRowsSimilar(string query)
        {
            string q = "%" + query + "%";


            return from p in database.Patrons
                   where SqlMethods.Like(p.FirstName, q)
                   where SqlMethods.Like(p.LastName, q)
                   where SqlMethods.Like(p.Family, q)
                   select p;
        }


        public PatronList GetNewestRows(string lastDate)
        {
            return from p in database.Patrons
                   where IsBeforeDate(p.DateOfLastVisit, lastDate)
                   select p;
        }



        public PatronList GetTopRows(int rowCount)
        {
            return database.Patrons.Take(rowCount);
        }



        private static bool IsBeforeDate(string date, string lastDate)
        {
            string[] previousDate = lastDate.Split('/');

            int prevMonth = Convert.ToInt32(previousDate[0]);
            int prevDay = Convert.ToInt32(previousDate[1]);
            int prevYear = Convert.ToInt32(previousDate[2]);

            string[] newDate = date.Split('/');

            int newMonth = Convert.ToInt32(newDate[0]);
            int newDay = Convert.ToInt32(newDate[1]);
            int newYear = Convert.ToInt32(newDate[2]);

            if (newYear < prevYear)
                return false;
            else if (newMonth < prevMonth)
                return false;
            else if (newDay < prevDay)
                return false;
            else
                return true;
        }



        public void AddRow(
            string firstName,
            string middleInitial,
            string lastName,
            string gender,
            string family,
            string lastVisit,
            string birth,
            string address,
            string phoneNumber,
            string comments,
            string initialVisit)
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

            database.Patrons.InsertOnSubmit(row);
            database.SubmitChanges();
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
