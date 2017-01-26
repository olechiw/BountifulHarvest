using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.ServiceProcess;
using System.Data.SqlTypes;

using Common;

using PatronList = System.Linq.IQueryable<Common.Patron>;
using VisitList = System.Linq.IQueryable<Common.Visit>;
using System.Data.Linq.SqlClient;

//
// BeginInterfaceForm - This form's main entry point for the "entry" application. This will be responsible for directly accessing patron data at the entry desk
//

namespace EntryApplication
{
    public partial class BeginInterfaceForm : Common.DialogForm
    {
        // The type of date we want to display: mm/dd/yy
        private const string dateCode = "d";

        // The database handler, responsible for all sql operations
        // Common.PatronsSqlHandler sqlHandler;

        // The database context
        BountifulHarvestContext database;


        // Constructor
        public BeginInterfaceForm()
        {
            InitializeComponent();

            Constants.InitializeDataView(outputDataView);

            InitializeSQL();

            dateLabel.Text = "Today's Date is: " + Constants.ConvertDateTime(DateTime.Today);
        }

        // Setup the sql connection
        private void InitializeSQL()
        {
            string connString = (Constants.ISRELEASE) ? Constants.releaseServerConnectionString : Constants.debugConnectionString;

            // Connect to the SQL database
            // sqlHandler = new Common.PatronsSqlHandler(connString);

            database = new BountifulHarvestContext(connString);

            LoadAllPatrons();
        }


        // Load all patrons
        private void LoadAllPatrons()
        {
            outputDataView.Rows.Clear();

            // Read all of the patrons into the data
            foreach (Patron p in database.Patrons.Take(200))
                AddDataRow(p);
        }



        // Shorthand for adding a set of values to the outputDataView
        private void AddDataRow(Patron p)
        {
            this.outputDataView.Rows.Add(
                p.FirstName,
                p.MiddleInitial,
                p.LastName,
                p.Gender,
                Constants.ConvertDateTime(p.DateOfLastVisit),
                p.DateOfBirth.ToString(Constants.DateFormat),
                DateTime.Today.Year - p.DateOfBirth.Year,
                p.Family,
                p.PatronID);
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
            if (!string.IsNullOrEmpty(searchBox.Text))
            {
                searchBox.SelectionStart = 0;
                searchBox.SelectionLength = searchBox.Text.Length;
            }
        }

        // Whenever a key is pressed in the search box
        private void searchBoxKeyDown(object sender, KeyEventArgs e)
        {
            // Highlight everything if a space was entered. No spaces in last names
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;

                SelectAll();
            }

            // Backspace also updates the searchbox
            else
                UpdateResults();
        }



        // Update the data table with the results given the search box text
        private void UpdateResults()
        {
            string query = searchBox.Text;

            if (query == "")
                LoadAllPatrons();

            else
            {
                outputDataView.Rows.Clear();

                var predicate = PredicateBuilder.False<Patron>();

                string q = "%" + query + "%";

                predicate = predicate.Or(p => SqlMethods.Like(p.FirstName, q));
                predicate = predicate.Or(p => SqlMethods.Like(p.LastName, q));
                predicate = predicate.Or(p => SqlMethods.Like(p.Family, q));

                AddDataRows(database.Patrons.Where(predicate));
            }
        }



        // When the button to enter a new patron is clicked
        private void addPatronButtonClick(object sender, EventArgs e)
        {
            NewPatronForm form = new NewPatronForm();
            form.ShowDialog();

            if (!form.Saved())
                return;

            Patron p = form.GetResults();

            p.Calculate();

            var lastPatronQuery = database.Patrons.OrderByDescending(patron => patron.PatronID).Take(1);

            if (lastPatronQuery.Count() == 1)
                p.PatronID = lastPatronQuery.First().PatronID + 1;
            else
                p.PatronID = 1;

            database.Patrons.InsertOnSubmit(p);
            database.SubmitChanges();

            if ((p.DateOfBirth.Date != new DateTime().Date) && form.Print())
                Print(p);

            UpdateResults();
        }



        // When the button to edit an existing patron is clicked
        private void editPatronButtonClick(object sender, EventArgs e)
        {
            int patronId = Constants.SafeConvertInt(
                outputDataView.SelectedRows[0].Cells[(int)Constants.OutputDataColumnsPatrons.PatronID]
                .Value.ToString()
                );

            if (patronId == 0)
            {
                MessageBox.Show("Something went wrong, failed to turn the ID into an integer");
                return;
            }

            Patron p = ((database.Patrons.Where(patron => patron.PatronID == patronId)).First());

            // Get new data passing the old data on
            NewPatronForm form = new NewPatronForm(p);
            form.ShowDialog();

            if (!form.Saved())
                return;

            Patron updatedP = form.GetResults();
            Patron.Copy(p, updatedP);

            p.Calculate();

            database.SubmitChanges();

            LoadAllPatrons();
        }



        // When the button to print a report is clicked
        private void printVisitButtonClick(object sender, EventArgs e)
        {
            int selectedPatronID = Constants.GetSelectedInt(outputDataView, (int)Constants.OutputDataColumnsPatrons.PatronID);

            Patron selectedPatron = ((database.Patrons.Where(p => p.PatronID == selectedPatronID)).First());

            // Show the form
            Print(selectedPatron);
        }

        // When the button to view more information about a patron is clicked. This is ugly but I'm currently too lazy to fix it
        private void morePatronInfoButtonClick(object sender, EventArgs e)
        {
            DataGridViewRow row = outputDataView.SelectedRows[0];

            int id = Constants.GetSelectedInt(outputDataView, (int)Constants.OutputDataColumnsPatrons.PatronID);
            Patron p = ((database.Patrons.Where(patron => patron.PatronID == id).First()));

            MoreInfoForm form = new MoreInfoForm(p);

            form.ShowDialog();
        }

        private void clearButtonClick(object sender, EventArgs e)
        {
            searchBox.Text = "";
            LoadAllPatrons();
            searchBox.Focus();
        }


        private void Print(Patron p)
        {
            PrintHandler printer = new PrintHandler();
            printer.Print(p);
        }

        private void deletePatronButtonClick(object sender, EventArgs e)
        {
            var selectedRow = outputDataView.SelectedRows[0];
            int id = Constants.SafeConvertInt(
                selectedRow.Cells[(int)Constants.OutputDataColumnsPatrons.PatronID]
                .Value.ToString());

            Patron deletePatron = ((from p in database.Patrons where p.PatronID == id select p)).First();


            database.Patrons.DeleteOnSubmit(deletePatron);
            database.SubmitChanges();

            outputDataView.Rows.Remove(selectedRow);
        }
    }
}