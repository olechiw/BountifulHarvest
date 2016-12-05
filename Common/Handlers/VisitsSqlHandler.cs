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

namespace Common.Handlers
{
    class VisitsSqlHandler
    {
        // The actual database
        private BountifulHarvestContext database;

        public VisitsSqlHandler(string connectString)
        {
            database = new BountifulHarvestContext(connectString);
        }

        public Visit GetRow(int id)
        {
            return
            (
                from v in database.Visits

                where v.VisitID == id

                select v
            ).First<Visit>();
        }

        public VisitList GetNewestRows(string lastDate)
        {
            return from v in database.Visits
                   where Constants.IsBeforeDate(v.DateOfVisit.Date.ToString(), lastDate)
                   select v;
        }


        public VisitList GetTopRows(int rowCount)
        {
            return database.Visits.Take(rowCount);
        }


        public void AddRow(
            string patronName,
            string totalPounds,
            DateTime dateOfVisit,
            string sizeOfFamily)
        {
            Visit visit = new Visit
            {
                PatronName = patronName,
                TotalPounds = totalPounds,
                DateOfVisit = dateOfVisit,
                SizeOfFamily = sizeOfFamily
            };

            database.Visits.InsertOnSubmit(visit);
            database.SubmitChanges();
        }

        public void AddRow(Visit v)
        {
            database.Visits.InsertOnSubmit(v);
            database.SubmitChanges();
        }

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


