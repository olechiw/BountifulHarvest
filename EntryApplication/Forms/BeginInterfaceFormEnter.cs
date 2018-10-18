using System;
using System.Linq;
using System.Windows.Forms;
using Common;
using EntryApplication.Forms;
using PatronList = System.Linq.IQueryable<Common.Patron>;
using VisitList = System.Linq.IQueryable<Common.Visit>;

//
// BeginInterfaceForm - This form's main entry point for the "entry" application. This will be responsible for directly accessing patron data at the entry desk
//

namespace EntryApplication
{
    public partial class BeginInterfaceForm : DialogForm
    {
        // The type of date we want to display: mm/dd/yy
        private const string dateCode = "d";

        // The database handler, responsible for all sql operations
        // Common.PatronsSqlHandler sqlHandler;

        // The database context
        private BountifulHarvestContext database;


        // Constructor
        public BeginInterfaceForm()
        {
            Logger.Log("Setting Up Components");
            InitializeComponent();

            Constants.InitializeDataView(outputDataView);

            Logger.Log("Setting Up SQL");
            InitializeSQL();

            dateLabel.Text = "Today's Date is: " + Constants.ConvertDateTime(DateTime.Today);

            Logger.Log("Entry Application Running!");
        }

        // Setup the sql connection
        private void InitializeSQL()
        {
            var connString = Constants.ISRELEASE
                ? Constants.loadReleaseServerString()
                : Constants.debugConnectionString;

            // Connect to the SQL database
            // sqlHandler = new Common.PatronsSqlHandler(connString);

            database = new BountifulHarvestContext(connString);

            try
            {
                LoadAllPatrons();
            }
            catch (Exception e)
            {
                Logger.Log("Failed to load all patrons: " + e.Message);
                Logger.Log(e.StackTrace);
            }
        }


        // Load all patrons
        private void LoadAllPatrons()
        {
            outputDataView.Rows.Clear();

            try
            {
                // Read all of the patrons into the data
                foreach (var p in database.Patrons.Take(200))
                    AddDataRow(p);
            }
            catch (Exception e)
            {
                Logger.Log("Exception when loading all patrons: " + e.Message);
                Logger.Log(e.StackTrace);
                Constants.DatabaseFailed();
                Close();
            }
        }


        // Shorthand for adding a set of values to the outputDataView
        private void AddDataRow(Patron p)
        {
            outputDataView.Rows.Add(
                p.FirstName,
                p.MiddleInitial,
                p.LastName,
                p.Gender,
                p.DateOfBirth.ToString(Constants.DateFormat),
                DateTime.Today.Year - p.DateOfBirth.Year,
                p.Family,
                p.PatronId);
        }

        // Add a list of rows
        private void AddDataRows(PatronList ps)
        {
            foreach (var p in ps)
                AddDataRow(p);
        }


        // Select all of the text in the box
        private void SelectAll()
        {
            if (string.IsNullOrEmpty(searchBox.Text)) return;

            searchBox.SelectionStart = 0;
            searchBox.SelectionLength = searchBox.Text.Length;
        }

        // Whenever a key is pressed in the search box
        private void searchBoxKeyDown(object sender, KeyEventArgs e)
        {
        }


        // Update the data table with the results given the search box text
        private void UpdateResults()
        {
            var query = searchBox.Text;

            if (query == "")
            {
                LoadAllPatrons();
            }

            else
            {
                outputDataView.Rows.Clear();


                var q = "%" + query + "%";

                try
                {
                    AddDataRows(database.Patrons.Where(p => p.FirstName.Contains(query) || p.LastName.Contains(query)));
                }
                catch (Exception e)
                {
                    Logger.Log("Exception when updating search results: " + e.Message);
                    Logger.Log(e.StackTrace);
                }
            }
        }


        // When the button to enter a new patron is clicked
        private void addPatronButtonClick(object sender, EventArgs e)
        {
            var form = new NewPatronForm();
            form.ShowDialog();

            if (!form.Saved())
                return;

            var p = form.GetResults();

            p.PatronId = Constants.GetLatestPatronID(database);


            /*
             * Validate the patron by checking the names
             */
            var valid = CheckPatronDuplicates(p);
            if (!valid) return;


            try
            {
                database.Patrons.InsertOnSubmit(p);
                database.SubmitChanges();
            }
            catch (Exception error)
            {
                Logger.Log("Exception when adding a new patron: " + error.Message);
                Logger.Log(error.StackTrace);
            }

            if (form.Print())
                showPrintDialog(p);

            UpdateResults();
        }

        private bool CheckPatronDuplicates(Patron p)
        {
            var patronName = p.FirstName + ' ' + p.LastName;
            var similarQuery = String.Format(Constants.DuplicatePatronsQuery(), p.Family + ',' + patronName);
            // Family Duplicates (exact matches only), including main patron's name
            var similars = database.ExecuteQuery<Patron>(similarQuery);

            // Name Duplicates
            var names = database.Patrons.Where(p1 => p1.FirstName.Equals(p.FirstName) &&
                                                     p1.LastName.Equals(p.LastName));

            // Get only unique values
            var duplicatePatrons = similars.ToArray();

            if (!duplicatePatrons.Any()) return true;
            var form = new DuplicateForm(duplicatePatrons);
            form.ShowDialog();

            return !form.Cancel;
        }


        // When the button to edit an existing patron is clicked
        private void editPatronButtonClick(object sender, EventArgs e)
        {
            var patronId = Constants.SafeConvertInt(
                outputDataView.SelectedRows[0].Cells[(int) Constants.PatronIndexes.PatronID]
                    .Value.ToString()
            );

            if (patronId == Constants.InvalidID)
            {
                MessageBox.Show("Something went wrong, failed to turn the ID into an integer");
                Logger.Log("Failed when turning an ID into integer.");
                return;
            }

            try
            {
                var p = database.Patrons.First(patron => patron.PatronId == patronId);

                // Get new data passing the old data on
                var form = new NewPatronForm(p);
                form.ShowDialog();

                if (!form.Saved())
                    return;

                var updatedP = form.GetResults();
                Patron.Copy(p, updatedP);

                database.SubmitChanges();


                if (form.Print())
                    showPrintDialog(p);
            }
            catch (Exception error)
            {
                Logger.Log("Exception when editing a patron: " + error.Message);
                Logger.Log(error.StackTrace);
            }


            UpdateResults();
        }


        private void showPrintDialog(Patron patron = null)
        {
            try
            {
                Patron selectedPatron;
                if (patron == null)
                {
                    var selectedPatronID =
                        Constants.GetSelectedInt(outputDataView, (int) Constants.PatronIndexes.PatronID);

                    selectedPatron = database.Patrons.First(p => p.PatronId == selectedPatronID);
                }
                else
                {
                    selectedPatron = patron;
                }

                var pastYearVisits = database.Visits.Where(v => v.PatronID == selectedPatron.PatronId);

                var extrasVisit = new Visit();
                extrasVisit.Christmas = pastYearVisits.Any(v => v.Christmas);
                extrasVisit.Easter = pastYearVisits.Any(v => v.Easter);
                extrasVisit.Thanksgiving = pastYearVisits.Any(v => v.Thanksgiving);
                extrasVisit.Halloween = pastYearVisits.Any(v => v.Halloween);
                extrasVisit.School = pastYearVisits.Any(v => v.School);
                extrasVisit.Winter = pastYearVisits.Any(v => v.Winter);


                // Show the form
                var dialog = new PrintForm(selectedPatron, extrasVisit);
                dialog.ShowDialog();
            }
            catch (Exception error)
            {
                Logger.Log("Exception when loading a patron to print: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }

        // When the button to print a report is clicked
        private void printVisitButtonClick(object sender, EventArgs e)
        {
            try
            {
                showPrintDialog(); // Patron is figured out in print dialog
            }
            catch (Exception ex)
            {
                Logger.Log("Exception while trying to print: " + ex.Message);
                Logger.Log(ex.StackTrace);
            }
        }

        // When the button to view more information about a patron is clicked. This is ugly but I'm currently too lazy to fix it
        private void morePatronInfoButtonClick(object sender, EventArgs e)
        {
            var row = outputDataView.SelectedRows[0];

            try
            {
                var id = Constants.GetSelectedInt(outputDataView, (int) Constants.PatronIndexes.PatronID);
                var p = database.Patrons.Where(patron => patron.PatronId == id).First();

                var visits = from v in database.Visits where v.PatronID == p.PatronId select v;


                var form = new MoreInfoForm(p, visits);

                form.ShowDialog();
            }
            catch (Exception error)
            {
                Logger.Log("Exception when getting more info about patron: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }

        private void clearButtonClick(object sender, EventArgs e)
        {
            searchBox.Text = "";
            LoadAllPatrons();
            searchBox.Focus();
        }

        private void deletePatronButtonClick(object sender, EventArgs e)
        {
            var selectedRow = outputDataView.SelectedRows[0];
            var id = Constants.SafeConvertInt(
                selectedRow.Cells[(int) Constants.PatronIndexes.PatronID]
                    .Value.ToString());

            try
            {
                var deletePatron = (from p in database.Patrons where p.PatronId == id select p).First();


                database.Patrons.DeleteOnSubmit(deletePatron);
                database.SubmitChanges();

                outputDataView.Rows.Remove(selectedRow);
            }
            catch (Exception error)
            {
                Logger.Log("Exception when deleting patron: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }

        private void textChangedListener(object sender, EventArgs e)
        {
            UpdateResults();
        }
    }
}