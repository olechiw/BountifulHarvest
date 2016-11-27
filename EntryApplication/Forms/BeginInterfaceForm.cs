//
// Bountiful Harvest Alpha Version 1.0 - Jakob Olechiw, 10/12/2016
//
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

//
// BeginInterfaceForm - This form's main entry point for the "entry" application. This will be responsible for directly accessing patron data at the entry desk
//

namespace EntryApplication
{
    // Index of specific items in the datagridview
    public enum OutputDataColumns
    {
        FirstName,
        MiddleInitial,
        LastName,
        Gender,
        DateOfLastVisit,
        DateOfBirth,
        Family,
        PatronID
    }

    public partial class BeginInterfaceForm : Common.DialogForm
    {
        // The type of date we want to display: mm/dd/yy
        private const string dateCode = "d";

        // The date
        private string date;

        // The connection to the local sql database
        private SqlConnection sqlConnection;

        // The database handler, responsible for all sql operations
        Common.SqlHandler sqlHandler;



        // Constructor
        public BeginInterfaceForm()
        {
            InitializeComponent();

            // Manual initialization
            outputDataView.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            outputDataView.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            outputDataView.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            // Setup the dataview
            outputDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Show the date on the datemessage
            DateTime today = DateTime.Today;
            date = today.ToString(dateCode);
            dateLabel.Text = "Today's Date is: " + date;



            // Connect to the SQL database
            sqlHandler = new Common.SqlHandler("Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id=sa; Password=potato");

            LoadAllPatrons();
        }



        // A second constructor, currently unused
        private void BeginInterfaceForm_Load(object sender, EventArgs e)
        {

        }



        // Load all patrons
        private void LoadAllPatrons()
        {
            outputDataView.Rows.Clear();

            // Initialize all of the patrons into the list
            PatronList patrons = sqlHandler.GetTopRows(100);

            // Read all of the patrons into the data
            foreach (Patron p in patrons)
            {
                AddDataRow(p);
            }
        }



        // Shorthand for adding a set of values to the outputDataView
        private void AddDataRow(Patron p)
        {
            this.outputDataView.Rows.Add(
                p.FirstName,
                p.MiddleInitial,
                p.LastName,
                p.Gender,
                p.DateOfLastVisit,
                p.DateOfBirth,
                p.Family,
                p.PatronID);
        }



        // Whenever a letter is added to or removed from the search box
        private void searchBoxChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Length>2)
            {
                UpdateResults(searchBox.Text);
            }
        }



        // Whenever a key is pressed in the search box
        private void searchBoxKeyDown(object sender, KeyEventArgs e)
        {
            // Highlight everything if a space was entered. No spaces in last names
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                LoadAllPatrons();

                if (!String.IsNullOrEmpty(searchBox.Text))
                {
                    searchBox.SelectionStart = 0;
                    searchBox.SelectionLength = searchBox.Text.Length;
                }
            }

            // Backspace also updates the searchbox
            else if ((e.KeyCode == Keys.Back) && (searchBox.Text.Length >= 2))
                searchBoxChanged(null, null);
        }



        // Update the data table with the results given the search box text
        private void UpdateResults(string query)
        {
            outputDataView.Rows.Clear();

            PatronList results = sqlHandler.GetRowsSimilar(query);


            foreach (Patron p in results)
                AddDataRow(p);
        }



        // When the button to enter a new patron is clicked
        private void addPatronButtonClick(object sender, EventArgs e)
        {
            NewPatronForm form = new NewPatronForm();
            form.ShowDialog();

            Patron p = form.GetResults();

            sqlHandler.AddRow(p);
        }



        // When the button to edit an existing patron is clicked
        private void editPatronButtonClick(object sender, EventArgs e)
        {
            int patronId = Convert.ToInt32(
                outputDataView.SelectedRows[0].Cells[(int)OutputDataColumns.PatronID]
                .ToString()
                );

            Patron p = sqlHandler.GetRow(patronId);

            // Get new data passing the old data on
            NewPatronForm form = new NewPatronForm(p);
            form.ShowDialog();

            if (form.Saved())
            {
                Patron updatedP = form.GetResults();
                Patron.Copy(p, updatedP);
            }

            LoadAllPatrons();
        }



        // When the button to print a report is clicked
        private void printVisitButtonClick(object sender, EventArgs e)
        {
            DataGridViewRow row = outputDataView.SelectedRows[0];

            string firstName = row.Cells[(int)OutputDataColumns.FirstName].Value.ToString();
            string lastName = row.Cells[(int)OutputDataColumns.LastName].Value.ToString();
            string middleInitial = row.Cells[(int)OutputDataColumns.MiddleInitial].Value.ToString();

            int limitsAllowed, family;
            // Calculate the amount of limits Allowed
            if (row.Cells[6].Value.ToString()!="")
            {
                family = 1;
                limitsAllowed = 1;
            }
            else
            {
                // Get the number of family members
                family = row.Cells[(int)OutputDataColumns.Family].Value.ToString().Split(',').Length;

                if (family < 4)
                    limitsAllowed = 1;

                else if (family < 6)
                    limitsAllowed = 2;
                else
                    limitsAllowed = 3;
            }
            DateTime today = DateTime.Today;

            // Show the form
            PrintVisitForm printForm = new PrintVisitForm(firstName, middleInitial, lastName, limitsAllowed, family, today.ToString(dateCode));
            printForm.ShowDialog();
        }



        // When the button to view more information about a patron is clicked
        private void morePatronInfoButtonClick(object sender, EventArgs e)
        {
            DataGridViewRow row = outputDataView.SelectedRows[0];

            int id = Convert.ToInt32(outputDataView.SelectedRows[0].Cells[(int)OutputDataColumns.PatronID]);
            Patron p = sqlHandler.GetRow(id);

            MoreInfoForm form = new MoreInfoForm(p.FirstName + ' ' + p.MiddleInitial + ' ' + p.LastName, p.DateOfBirth.ToString(), p.Address, p.PhoneNumber, p.DateOfLastVisit.ToString(), p.DateOfInitialVisit.ToString(), p.Family, p.Comments);
            form.ShowDialog();
        }
    }
}
