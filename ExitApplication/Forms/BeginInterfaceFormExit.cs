using System;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Common;
using VisitList = System.Linq.IQueryable<Common.Visit>;
using PatronList = System.Linq.IQueryable<Common.Patron>;

namespace ExitApplication
{
    public partial class BeginInterfaceForm : DialogForm
    {
        // The database handler, responsible for all sql operations
        // private Common.VisitsSqlHandler sqlHandler;

        // The second one, for accessing another table
        // private Common.PatronsSqlHandler patronsHandler;

        private BountifulHarvestContext database;

        public BeginInterfaceForm()
        {
            // Setup the form
            Logger.Log("Initialiing Components");
            InitializeComponent();

            Constants.InitializeDataView(outputDataView);

            Logger.Log("Setting up SQL");
            SetupSQL();

            dateLabel.Text = "Today's Date is: " + Constants.ConvertDateTime(DateTime.Today);

            Logger.Log("Exit Application Running");

            var query = ((from p in database.Patrons select p));
            foreach (var v in query)
            {
                v.Calculate();
            }
            database.SubmitChanges();
            Logger.Log("Query Length: " + query.Count());
        }

        // Initialize the database in the gridview
        private void SetupSQL()
        {
            string connString = Constants.ISRELEASE
                ? Constants.releaseExitConnectionString
                : Constants.debugConnectionString;

            // Connect to the database
            // sqlHandler = new Common.VisitsSqlHandler(connString);
            // patronsHandler = new Common.PatronsSqlHandler(connString);
            database = new BountifulHarvestContext(connString);

            Logger.Log("Loading Initial Visits");
            LoadAllVisits();
        }

        // Load the initial list of visits for the day
        public void LoadAllVisits()
        {
            // Get all of the visits for the month
            outputDataView.Rows.Clear();

            try
            {
                VisitList monthVisits = from v in database.Visits
                    where v.DateOfVisit.Month == DateTime.Today.Month
                    select v;

                foreach (Visit v in monthVisits.OrderBy(visit => visit.DateOfVisit))
                    AddDataRow(v);
            }
            catch (Exception e)
            {
                Logger.Log("Exception in loading all visits: " + e.Message);
                Logger.Log(e.StackTrace);
                Constants.DatabaseFailed();
                Close();
            }
        }

        // Add a row to the output
        private void AddDataRow(Visit v)
        {
            PatronList query = from patron in database.Patrons where patron.PatronId == v.PatronID select patron;

            Patron p;
            if (query.Count() == 1)
                p = query.First();
            else
                return;

            try
            {
                var extras = "";
                var delim = ", ";

                // Load the output to show which extras were selected. A wee bit hacky.
                if (v.Christmas)
                    extras += "Christmas" + delim;
                if (v.Easter)
                    extras += "Easter" + delim;
                if (v.Winter)
                    extras += "Winter" + delim;
                if (v.School)
                    extras += "School" + delim;
                if (v.Thanksgiving)
                    extras += "Thanksgiving" + delim;
                if (v.Halloween)
                    extras += "Halloween" + delim;

                if (extras.Length > 0)
                    extras = extras.Remove(extras.Length - 2);

                outputDataView.Rows.Add(
                    p.FirstName,
                    p.MiddleInitial,
                    p.LastName,
                    v.TotalPounds,
                    Constants.ConvertDateTime(v.DateOfVisit),
                    extras,
                    v.VisitID,
                    p.PatronId);
            }
            catch (Exception error)
            {
                // Let the user know. This should probably never happen but better save than sorry
                MessageBox.Show("Failed to add row");

                Logger.Log("Exception when adding row: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }

        // Extra constructor. Currently unused, probably never will be at this point.
        private void BeginInterface_Load(object sender, EventArgs e) { }

        private void submitButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(patronIDTextBox.Text))
                return;

            PatronList rows = database.Patrons.Where(p => p.PatronId == Constants.SafeConvertInt(patronIDTextBox.Text));
            if (rows.Count() == 0)
                return;

            // Get all the info
            var v = new Visit
            {
                TotalPounds = Constants.SafeConvertInt(totalPoundsSpinner.Value.ToString()),
                DateOfVisit = DateTime.Today,
                PatronID = Constants.SafeConvertInt(patronIDTextBox.Text),
                Winter = winter.Checked,
                Easter = easter.Checked,
                Halloween = halloween.Checked,
                School = school.Checked,
                Thanksgiving = thanksgiving.Checked,
                Christmas = christmas.Checked,
                VisitID = Constants.GetLatestVisitID(database)
            };

            // Uncheck extras
            christmas.Checked = false;
            winter.Checked = false;
            easter.Checked = false;
            halloween.Checked = false;
            school.Checked = false;
            thanksgiving.Checked = false;

            // Submit
            try
            {
                database.Visits.InsertOnSubmit(v);
                database.SubmitChanges();
                AddDataRow(v);
            }
            catch (Exception error)
            {
                Logger.Log("Exception when submitting new visit: " + error.Message);
                Logger.Log(error.StackTrace);
            }

            totalPoundsSpinner.Value = 0;
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            int id = Constants.GetSelectedInt(outputDataView, (int) Constants.VisitIndexes.VisitID);

            Visit v = database.Visits.Where(visit => visit.VisitID == id).First();

            database.Visits.DeleteOnSubmit(v);


            try
            {
                database.SubmitChanges();
            }
            catch (Exception error)
            {
                Logger.Log("Exception when deleting item: " + error.Message);
                Logger.Log(error.StackTrace);
            }

            if (string.IsNullOrEmpty(patronIDTextBox.Text))
                LoadAllVisits();
            else
                patronIDChanged(null, null);
        }

        private void patronIDChanged(object sender, EventArgs e)
        {
            outputDataView.Rows.Clear();

            int id = Constants.SafeConvertInt(patronIDTextBox.Text);

            // Update the visits output with the new patronID
            VisitList rows = database.Visits.Where(v => v.PatronID == id);

            try
            {
                Logger.Log("Loading patron visits from ID: " + id);
                for (var i = 0; i < rows.Count(); ++i)
                    AddDataRow(rows.AsEnumerable().ElementAt(i));

                if (string.IsNullOrEmpty(patronIDTextBox.Text))
                    LoadAllVisits();
            }
            catch (Exception error)
            {
                Logger.Log("Exception when loading patron visits: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }


        private void outputDataView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Update the patron when the cells are done editing, to update totalpounds and dateofvisit.
            var poundsColumn = (int) Constants.VisitIndexes.TotalPounds;
            var dateColumn = (int) Constants.VisitIndexes.DateOfVisit;
            var visitIDColumn = (int) Constants.VisitIndexes.VisitID;
            Visit visit;


            DataGridViewRow row = outputDataView.Rows[e.RowIndex];

            int visitID = Constants.SafeConvertInt(row.Cells[visitIDColumn].Value.ToString());

            try
            {
                visit = (from v in database.Visits where v.VisitID == visitID select v).First();
            }
            catch
            {
                return;
            }

            if (e.ColumnIndex == poundsColumn)
            {
                int pounds = Constants.SafeConvertInt(row.Cells[poundsColumn].Value.ToString());
                if (pounds != 0)
                    visit.TotalPounds = pounds;
                database.SubmitChanges();
            }

            else if (e.ColumnIndex == dateColumn)
            {
                DateTime date = Constants.ConvertString2Date(row.Cells[dateColumn].Value.ToString());
                if (date.Hour != Constants.InvalidHour)
                    visit.DateOfVisit = date;

                try
                {
                    database.SubmitChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fatal error, failed to submit changes");
                }
            }
        }

        private void patronSearchTextBoxChanged(object sender, EventArgs e)
        {
            // Search the database for a patron LIKE the search
            if (patronSearchTextBox.Text.Length < 3)
                return;

            try
            {
                Expression<Func<Patron, bool>> predicate = PredicateBuilder.False<Patron>();
                string q = "%" + patronSearchTextBox.Text + "%";
                predicate = predicate.Or(p => SqlMethods.Like(p.FirstName, q));
                predicate = predicate.Or(p => SqlMethods.Like(p.MiddleInitial, q));
                predicate = predicate.Or(p => SqlMethods.Like(p.LastName, q));

                PatronList query = database.Patrons.Where(predicate);


                if (query.Count() > 0)
                {
                    searchDataView.Rows.Clear();
                    foreach (Patron p in query)
                        searchDataView.Rows.Add(
                            Constants.ConjuncName(p.FirstName, p.MiddleInitial, p.LastName),
                            p.PatronId);
                }
            }
            catch (Exception error)
            {
                Logger.Log("Exception occured in patron search box: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }
    }
}