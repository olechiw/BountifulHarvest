using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common;
using VisitList = System.Linq.IQueryable<Common.Visit>;
using PatronList = System.Linq.IQueryable<Common.Patron>;

namespace ExitApplication
{
    public partial class BeginInterfaceForm : Common.DialogForm
    {
        // The database handler, responsible for all sql operations
        // private Common.VisitsSqlHandler sqlHandler;

        // The second one, for accessing another table
        // private Common.PatronsSqlHandler patronsHandler;

        private BountifulHarvestContext database;

        public BeginInterfaceForm()
        {
            InitializeComponent();

            Constants.InitializeDataView(outputDataView);

            SetupSQL();

            dateLabel.Text = "Today's Date is: " + Constants.ConvertDateTime(DateTime.Today);

        }

        // Initialize the database in the gridview
        private void SetupSQL()
        {
            string connString = (Constants.ISRELEASE) ? Constants.releaseExitConnectionString : Constants.debugConnectionString;

            // Connect to the database
            // sqlHandler = new Common.VisitsSqlHandler(connString);
            // patronsHandler = new Common.PatronsSqlHandler(connString);
            database = new BountifulHarvestContext(connString);

            LoadAllVisits();
        }

        // Load the initial list of visits for the day
        public void LoadAllVisits()
        {
            // Get all of the visits for the month
            outputDataView.Rows.Clear();



            VisitList monthVisits = ((from v in database.Visits
                                      where v.DateOfVisit.Month == DateTime.Today.Month
                                      select v));

            foreach (Visit v in monthVisits)
                AddDataRow(v);
        }
        
        // Add a row to the output
        private void AddDataRow(Visit v)
        {
            var query = (database.Patrons.Where(patron => patron.PatronID == v.VisitID));

            Patron p;
            if (query.Count() == 1)
                p = query.First();
            else
                return;

            try
            {
                outputDataView.Rows.Add(
                    p.FirstName,
                    p.MiddleInitial,
                    p.LastName,
                    v.TotalPounds,
                    Constants.ConvertDateTime(v.DateOfVisit),
                    v.VisitID,
                    p.PatronID);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to add row");
            }
        }

        // Extra constructor. Currently unused
        private void BeginInterface_Load(object sender, EventArgs e)
        {

        }

        private void submitButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(patronIDTextBox.Text))
                return;

            PatronList rows = (database.Patrons.Where(p => p.PatronID == Constants.SafeConvertInt(patronIDTextBox.Text)));
            if (rows.Count()==0)
                return;

            Visit v = new Visit
            {
                TotalPounds = Constants.SafeConvertInt(totalPoundsSpinner.Value.ToString()),
                DateOfVisit = DateTime.Today,
                PatronID = Constants.SafeConvertInt(patronIDTextBox.Text)
            };

            if (v.PatronID == 0)
                return;

            database.Visits.InsertOnSubmit(v);
            database.SubmitChanges();
            AddDataRow(v);

            totalPoundsSpinner.Value = 0;
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            int id = Constants.GetSelectedInt(outputDataView, (int)Constants.VisitIndexes.VisitID);

            Visit v = database.Visits.Where(visit => visit.VisitID == id).First();

            database.Visits.DeleteOnSubmit(v);



            database.SubmitChanges();

            if (string.IsNullOrEmpty(patronIDTextBox.Text))
                LoadAllVisits();
            else
                patronIDChanged(null, null);
        }

        private void patronIDChanged(object sender, EventArgs e)
        {
            outputDataView.Rows.Clear();

            int id = Constants.SafeConvertInt(patronIDTextBox.Text.ToString());

            VisitList rows = database.Visits.Where(v => v.VisitID == id);

            for (int i = 0; i < rows.Count(); ++i)
            {
                AddDataRow(rows.AsEnumerable().ElementAt(i));
            }

        }


        private void outputDataView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int poundsColumn = (int)Constants.VisitIndexes.TotalPounds;
            int visitIDColumn = (int)Constants.VisitIndexes.VisitID;
            if (e.ColumnIndex == poundsColumn)
            {
                var row = outputDataView.Rows[e.RowIndex];

                int visitID = Constants.SafeConvertInt(row.Cells[visitIDColumn].Value.ToString());
                Visit visit = ((from v in database.Visits where v.VisitID == visitID select v)).First();

                int pounds = Constants.SafeConvertInt(row.Cells[poundsColumn].Value.ToString());
                if (pounds != 0)
                    visit.TotalPounds = pounds;
                database.SubmitChanges();
            }
        }
    }
}
