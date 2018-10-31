using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common;
using EntryApplication.Forms;
using PatronList = System.Linq.IQueryable<Common.Patron>;
using VisitList = System.Linq.IQueryable<Common.Visit>;

//
// MainFormEntry - This form's main entry point for the "entry" application. This will be responsible for directly accessing patron data at the entry desk
//

namespace EntryApplication
{
    public partial class MainFormEntry : DialogForm
    {
        // The type of date we want to display: mm/dd/yy
        private const string DateCode = "d";

        // The database handler, responsible for all sql operations
        // Common.PatronsSqlHandler sqlHandler;

        // The database context
        private BountifulHarvestContext database;


        // Constructor
        public MainFormEntry()
        {
            Logger.Log("Setting Up Components");
            InitializeComponent();

            Constants.InitializeDataView(outputDataView);

            Logger.Log("Setting Up SQL");
            initializeSql();

            dateLabel.Text = @"Today's Date is: " + Constants.ConvertDateTime(DateTime.Today);

            Logger.Log("Entry Application Running!");
        }

        // Setup the sql connection
        private void initializeSql()
        {
            var connString = Constants.Isrelease
                ? Constants.LoadReleaseServerString()
                : Constants.DebugConnectionString;

            // Connect to the SQL database
            // sqlHandler = new Common.PatronsSqlHandler(connString);

            database = new BountifulHarvestContext(connString);

            try
            {
                loadAllPatrons();
            }
            catch (Exception e)
            {
                Logger.Log("Failed to load all patrons: " + e.Message);
                Logger.Log(e.StackTrace);
            }
        }


        // Load all patrons
        private void loadAllPatrons()
        {
            outputDataView.Rows.Clear();

            try
            {
                // Read all of the patrons into the data
                foreach (var p in database.Patrons.Take(50))
                    addDataRow(p);
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
        private void addDataRow(Patron p)
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
        private void addDataRows(IEnumerable<Patron> ps)
        {
            foreach (var p in ps)
                addDataRow(p);
        }


        // Select all of the text in the box
        private void selectAll()
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
        private void updateResults()
        {
            var query = searchBox.Text;

            if (query == "")
            {
                loadAllPatrons();
            }

            else
            {
                outputDataView.Rows.Clear();


                var q = "%" + query + "%";

                try
                {
                    addDataRows(database.Patrons.Where(
                        p => p.FirstName.Contains(query) || p.LastName.Contains(query) || p.Family.Contains(query)));
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

            p.PatronId = Constants.GetLatestPatronId(database);


            /*
             * Validate the patron by checking the names
             */
            var valid = checkPatronDuplicates(p);
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

            updateResults();
        }

        private bool checkPatronDuplicates(Patron p)
        {
            var patronName = p.FirstName + ' ' + p.LastName;
            var similarQuery = string.Format(Constants.DuplicatePatronsQuery(), p.Family + ',' + patronName);
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
                outputDataView.SelectedRows[0].Cells[(int) Constants.PatronIndexes.PatronId]
                    .Value.ToString()
            );

            if (patronId == Constants.InvalidId)
            {
                MessageBox.Show(@"Invalid Date of Birth Entered.");
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


            updateResults();
        }


        private void showPrintDialog(Patron patron = null)
        {
            try
            {
                Patron selectedPatron;
                if (patron == null)
                {
                    var selectedPatronId =
                        Constants.GetSelectedInt(outputDataView, (int) Constants.PatronIndexes.PatronId);

                    selectedPatron = database.Patrons.First(p => p.PatronId == selectedPatronId);
                }
                else
                {
                    selectedPatron = patron;
                }

                var pastYearVisits = database.Visits.Where(v => v.PatronID == selectedPatron.PatronId);

                var extrasVisit = new Visit
                {
                    Christmas = pastYearVisits.Any(v => v.Christmas),
                    Easter = pastYearVisits.Any(v => v.Easter),
                    Thanksgiving = pastYearVisits.Any(v => v.Thanksgiving),
                    Halloween = pastYearVisits.Any(v => v.Halloween),
                    School = pastYearVisits.Any(v => v.School),
                    Winter = pastYearVisits.Any(v => v.Winter)
                };


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
                var id = Constants.GetSelectedInt(outputDataView, (int) Constants.PatronIndexes.PatronId);
                var p = database.Patrons.First(patron => patron.PatronId == id);

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
            loadAllPatrons();
            searchBox.Focus();
        }

        private void deletePatronButtonClick(object sender, EventArgs e)
        {
            // Multiselect disabled, has to be the first row
            var selectedRow = outputDataView.SelectedRows[0];
            // Get the selected patron's id
            var id = Constants.SafeConvertInt(
                selectedRow.Cells[(int) Constants.PatronIndexes.PatronId]
                    .Value.ToString());

            try
            {
                // Get patron object
                var deletePatron = (from p in database.Patrons where p.PatronId == id select p).First();

                // Delete the patron
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
            updateResults();
        }
    }
}