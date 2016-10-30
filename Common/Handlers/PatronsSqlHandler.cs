using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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


        public Patron GetDataRow(string firstName, string middleInitial, string lastName, string dateOfBirth)
        {
            Patron result =
                (    
               from p in database.Patrons

                where p.FirstName == firstName
                where p.LastName == lastName
                where p.MiddleInitial == middleInitial
                where p.DateOfBirth == dateOfBirth

                 select p).First<Patron>(); // The can (should) only be one!!

            return result;
        }


        public void AddRow(params SqlPair[] data)
        {

        }



        // Delete an item from the table, given the following values
        public void DeleteRow(params SqlPair[] data)
        {

        }
}
