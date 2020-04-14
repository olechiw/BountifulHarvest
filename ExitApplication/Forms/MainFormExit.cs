﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Common;
using VisitList = System.Linq.IQueryable<Common.Visit>;
using PatronList = System.Linq.IQueryable<Common.Patron>;
using System.Reflection;

namespace ExitApplication
{
    public partial class MainFormExit : DialogForm
    {
        // The database handler, responsible for all sql operations
        // private Common.VisitsSqlHandler sqlHandler;

        // The second one, for accessing another table
        // private Common.PatronsSqlHandler patronsHandler;

        private BountifulHarvestContext database;


        private string lastDateBeforeEdit;
        private string lastPoundsBeforeEdit;

        public MainFormExit()
        {
            // Setup the form
            Logger.Log("Initialiing Components");
            InitializeComponent();

            Constants.InitializeDataView(outputDataView);

            Logger.Log("Setting up SQL");
            setupSql();

            dateLabel.Text = "Today's Date is: " + Constants.ConvertDateTime(DateTime.Today);

            Logger.Log("Exit Application Running");

            // Double buffering can make DGV slow in remote desktop
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                //Set Double buffering on the Grid using reflection and the bindingflags enum.
                typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null,
                outputDataView, new object[] { true });
                //Set Double buffering on the Grid using reflection and the bindingflags enum.
                typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null,
                searchDataView, new object[] { true });

                searchDataView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                // or even better, use .DisableResizing. Most time consuming enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
            }
        }

        // Initialize the database in the gridview
        private void setupSql()
        {
            var connString = Constants.Isrelease
                ? Constants.LoadReleaseExitString()
                : Constants.DebugConnectionString;

            // Connect to the database
            database = new BountifulHarvestContext(connString);

            Logger.Log("Loading Initial Visits");
            outputDataView.Rows.Clear();
        }

        // Add a row to the output
        private void addDataRow(Visit v)
        {
            var query = from patron in database.Patrons where patron.PatronId == v.PatronID select patron;

            Patron p;
            if (query.Count() == 1)
                p = query.First();
            else
                return;

            try
            {
                var extras = "";
                const string delim = ", ";

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

                Logger.Log("Exception when adding row: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }

        private void submitButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(patronIDTextBox.Text))
                return;
            if (string.IsNullOrEmpty(totalPoundsSpinner.Value.ToString(CultureInfo.InvariantCulture)) || totalPoundsSpinner.Value == 0)
                return;

            // Check that patron exists
            var rows = database.Patrons.Where(p => p.PatronId == Constants.SafeConvertInt(patronIDTextBox.Text));
            if (!rows.Any())
                return;

            // Get all the info
            var v = new Visit
            {
                TotalPounds = Constants.SafeConvertInt(totalPoundsSpinner.Value
                .ToString(CultureInfo.InvariantCulture)),
                DateOfVisit = DateTime.Today,
                PatronID = Constants.SafeConvertInt(patronIDTextBox.Text),
                Winter = winter.Checked,
                Easter = easter.Checked,
                Halloween = halloween.Checked,
                School = school.Checked,
                Thanksgiving = thanksgiving.Checked,
                Christmas = christmas.Checked,
                Genders = genders(rows.First()),
                Ages = ageGroups(rows.First()),
                VisitID = Constants.GetLatestVisitId(database)
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
                addDataRow(v);
            }
            catch (Exception error)
            {
                Logger.Log("Exception when submitting new visit: " + error.Message);
                Logger.Log(error.StackTrace);
            }

            totalPoundsSpinner.Value = 0;
        }

        private static string ageGroups(Patron p)
        {
            // toddler, young, medium, old
            var ageGroups = new[] {0, 0, 0, 0};

            var patronAge = DateTime.Today.Year - p.DateOfBirth.Year;
            if (patronAge < 6)
                ageGroups[0]++;
            else if (5 < patronAge && patronAge < 18)
                ageGroups[1]++;
            else if (17 < patronAge && patronAge < 60)
                ageGroups[2]++;
            else
                ageGroups[3]++;

            var family = p.FamilyDateOfBirths;
            if (string.IsNullOrEmpty(family)) return string.Join(",", ageGroups);


            var familyArray = family.Split(',');
            foreach (var date in familyArray)
            {
                if (string.IsNullOrEmpty(date)) continue;

                var age = DateTime.Today.Year - Constants.SafeConvertDate(date).Year;
                if (age < 6)
                    ageGroups[0]++;
                else if (5 < age && age < 18)
                    ageGroups[1]++;
                else if (17 < age && age < 60)
                    ageGroups[2]++;
                else
                    ageGroups[3]++;
            }

            return string.Join(",", ageGroups);
        }

        private static string genders(Patron p)
        {
            var m = 0;
            var f = 0;
            if (p.Gender.Equals("Male"))
                m++;
            else if (p.Gender.Equals("Female"))
                f++;

            var family = p.FamilyGenders;
            if (string.IsNullOrEmpty(family)) return f + "," + m;
            foreach (var s in family.Split(','))
            {
                if (string.IsNullOrEmpty(s)) continue;

                if (s.Equals("Male"))
                    m++;
                else if (s.Equals("Female"))
                    f++;
            }

            return f + "," + m;
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            var id = Constants.GetSelectedInt(outputDataView, (int) Constants.VisitIndexes.VisitId);

            Logger.Log("Deleting patron visit with id: " + id);

            try
            {
                var v = database.Visits.First(visit => visit.VisitID == id);

                database.Visits.DeleteOnSubmit(v);
            }
            catch (Exception exception)
            {
                Logger.Log("Exception occured when loading visit from SQL for deletion");
                Logger.Log(exception.Message);
                Logger.Log(exception.StackTrace);
            }

            try
            {
                database.SubmitChanges();
            }
            catch (Exception error)
            {
                Logger.Log("Exception when deleting item: " + error.Message);
                Logger.Log(error.StackTrace);
            }

            patronIdChanged(null, null);
        }

        private void patronIdChanged(object sender, EventArgs e)
        {
            outputDataView.Rows.Clear();

            var id = Constants.SafeConvertInt(patronIDTextBox.Text);

            // Update the visits output with the new patronID
            var rows = database.Visits.Where(v => v.PatronID == id);

            try
            {
                Logger.Log("Loading patron visits from ID: " + id);
                foreach (var i in rows)
                    addDataRow(i);
                if (string.IsNullOrEmpty(patronIDTextBox.Text))
                    outputDataView.Rows.Clear();
            }
            catch (Exception error)
            {
                Logger.Log("Exception when loading patron visits: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }

        private void outputDataView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            lastDateBeforeEdit = outputDataView.Rows[e.RowIndex]
                .Cells[(int) Constants.VisitIndexes.DateOfVisit]
                .Value
                .ToString();
            lastPoundsBeforeEdit = outputDataView.Rows[e.RowIndex]
                .Cells[(int) Constants.VisitIndexes.TotalPounds]
                .Value
                .ToString();
        }

        private void outputDataView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Update the patron when the cells are done editing, to update totalpounds and dateofvisit.
            var poundsColumn = (int) Constants.VisitIndexes.TotalPounds;
            var dateColumn = (int) Constants.VisitIndexes.DateOfVisit;
            var visitIdColumn = (int) Constants.VisitIndexes.VisitId;
            Visit visit;


            var row = outputDataView.Rows[e.RowIndex];

            var visitId = Constants.SafeConvertInt(row.Cells[visitIdColumn].Value.ToString());

            try
            {
                visit = (from v in database.Visits where v.VisitID == visitId select v).First();
            }
            catch
            {
                return;
            }

            if (e.ColumnIndex == poundsColumn)
            {
                var pounds = Constants.SafeConvertInt(row.Cells[poundsColumn].Value.ToString());
                if (pounds != 0)
                    visit.TotalPounds = pounds;
                try
                {
                    database.SubmitChanges();
                }
                catch (Exception)
                {
                    row.Cells[e.ColumnIndex].Value = lastPoundsBeforeEdit ?? "";
                }
            }

            else if (e.ColumnIndex == dateColumn)
            {
                var date = Constants.ConvertString2Date(row.Cells[dateColumn].Value.ToString());
                if (date.Hour != Constants.InvalidHour)
                    visit.DateOfVisit = date;

                try
                {
                    database.SubmitChanges();
                }
                catch (Exception)
                {
                    // No error warning because the date-format function throws a box up
                    row.Cells[e.ColumnIndex].Value = lastDateBeforeEdit ?? "";
                }
            }
        }

        private void patronSearchTextBoxChanged(object sender, EventArgs e)
        {
            searchDataView.Rows.Clear();
            //if (patronSearchTextBox.Text.Length < 3) return;
            try
            {
                var queryString = patronSearchTextBox.Text;
                var query = database.Patrons.Where(p => p.FirstName.Contains(queryString) ||
                                                        p.LastName.Contains(queryString));

                if (!query.Any()) return;
                searchDataView.Rows.Clear();
                searchDataView.SelectionChanged -= onSearchSelectionChanged;
                foreach (var p in query)
                    searchDataView.Rows.Add(
                        Constants.ConjuncName(p.FirstName, p.MiddleInitial, p.LastName),
                        p.PatronId);
                searchDataView.SelectionChanged += onSearchSelectionChanged;
                var id = Constants.SafeConvertInt(
                    searchDataView.SelectedRows[0]
                        .Cells[1].Value.ToString());
                patronIDTextBox.Text = id == Constants.InvalidId ? "" : id.ToString();
            }
            catch (Exception error)
            {
                Logger.Log("Exception occured in patron search box: " + error.Message);
                Logger.Log(error.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Invalid Date of Birth Entered.");
            var visits = database.Visits.Select(p => p);
            foreach (var visit in visits)
                try
                {
                    var patron = database.Patrons.Where(p => p.PatronId == visit.PatronID)
                        .Select(p => p).First();
                    visit.Ages = ageGroups(patron);
                    visit.Genders = genders(patron);
                    database.SubmitChanges();
                }
                catch (Exception exception)
                {
                    Logger.Log("Exception in updating visit stats:" + exception.Message);
                    Logger.Log(exception.StackTrace);
                }

            MessageBox.Show(@"Invalid Date of Birth Entered.");
        }

        private void onCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = Constants.SafeConvertInt(
                    searchDataView.SelectedRows[0]
                        .Cells[1].Value.ToString());
                patronIDTextBox.Text = id == Constants.InvalidId ? "" : id.ToString();
            }
            catch (Exception)
            {
                // Selected a non-created row or something else, so we just clear everything
                patronIDTextBox.Text = "";
            }
        }

        private void onSearchSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var id = Constants.SafeConvertInt(
                    searchDataView.SelectedRows[0]
                        .Cells[1].Value.ToString());
                patronIDTextBox.Text = id == Constants.InvalidId ? "" : id.ToString();
            }
            catch (Exception)
            {
                // Selected a non-created row or something else, so we just clear everything
                patronIDTextBox.Text = "";
            }
        }
    }
}