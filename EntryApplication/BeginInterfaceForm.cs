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


namespace EntryApplication
{
    // Data about a patron
    public struct Patron
    {
        public string firstName,
            lastName,
            middleInitial,

            spouse,
            dateOfBirth;

        public List<string> guardians,
            children;
    }

    public partial class BeginInterfaceForm : Form
    {
        // Hardcoded strings for all of the column names in SQL
        private const string firstName = "FirstName";
        private const string lastName = "LastName";
        private const string middleInitial = "MiddleInitial";
        private const string Guardians = "Guardians";
        private const string childrens = "Children";
        private const string spouse = "Spouse";
        private const string dateOfLastVisit = "LastVisit";
        private const string dateOfBirth = "DateOfBirth";

        // The type of date we want to display: mm/dd/yy
        private const string dateCode = "d";

        // The connection to the local sql database
        private SqlConnection sqlConnection;

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
            dateLabel.Text = "Today's Date is: " + today.ToString(dateCode);

            // Start the SQL Server!

            // Connect to the local SQL Database
            sqlConnection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Patrons;User Id=sa; Password=potato");
            sqlConnection.Open();

            LoadAllPatrons();
        }

        // Initalize and start the SQL server
        private void InitializeSQLServer()
        {
            string serviceName = "MSQL$SQLEXPRESSS";
            string status;

            ServiceController controller = new ServiceController(serviceName);
            try
            {
                status = controller.Status.ToString();
            }
            catch (Exception ex)
            {
                // This should never happen!!
            }
            if (controller.Status.Equals(ServiceControllerStatus.Stopped) | controller.Status.Equals(ServiceControllerStatus.StopPending))
            {
                try
                {
                    // Start the service
                    controller.Start();
                    controller.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (Exception ex)
                {
                    // Failed to start. Also should never happen
                }
            }
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
            SqlCommand patronsCommand = new SqlCommand("SELECT * FROM Patrons;", sqlConnection);
            SqlDataReader patrons = null;

            // Read all of the patrons into the data
            patrons = patronsCommand.ExecuteReader();
            while (patrons.Read())
            {
                string lastVisit = SqlString2Std(patrons[dateOfLastVisit].ToString());
                AddDataRow(patrons[firstName].ToString(), patrons[middleInitial].ToString(),  patrons[lastName].ToString(), lastVisit, SqlString2Std(patrons[dateOfBirth].ToString()), patrons[Guardians], patrons[childrens], patrons[spouse]);
            }
            patrons.Close();
        }

        // For formatting purposes, convert an sql '-' delimited string to a more standard '/' delimited string
        private string SqlString2Std(string sqlString)
        {
            if (sqlString != "")
            {
                string[] split = sqlString.Split('-');
                string year = split[0];
                string month = split[1];
                string day = split[2];
                return month + '/' + day + '/' + year;
            }
            else
            {
                return "";
            }
        }

        // Shorthand for adding a set of values to the outputDataView
        private void AddDataRow(params object[] values)
        {
            this.outputDataView.Rows.Add(values);
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
        }

        // Update the data table with the results given the search box text
        private void UpdateResults(string query)
        {
            SqlCommand searchCommand = new SqlCommand("SELECT * FROM Patrons WHERE FirstName LIKE '" + query + "%' OR LastName LIKE '" + query + "%' OR Guardians LIKE '%" + query + "%' OR Children LIKE '%" + query + "%'", sqlConnection);

            SqlDataReader results = searchCommand.ExecuteReader();

            outputDataView.Rows.Clear();
            while (results.Read())
            {
                AddDataRow(results[firstName].ToString(), results[lastName].ToString(), SqlString2Std(results[dateOfLastVisit].ToString()), SqlString2Std(results[dateOfBirth].ToString()), results[Guardians], results[childrens], results[spouse]);
            }
            results.Close();
        }

        // When the button to enter a new patron is clicked
        private void addPatronButtonClick(object sender, EventArgs e)
        {
            NewPatronForm form = new NewPatronForm();
            form.ShowDialog();

            if (form.Saved())
            {
                Patron p = form.GetData();
                string data = "'" + p.firstName + "'" + ','
                    + "'" + p.middleInitial + "'" + ','
                    + "'" + p.lastName + "'" + ','
                    + "'" + p.spouse + "'" + ','
                    + "'" + p.guardians + "'" + ','
                    + "'" + p.children + "'" + ','
                    + "''" + ','
                    + "'" + p.dateOfBirth + "'";

                // Add in the values
                SqlCommand addCommand = new SqlCommand("INSERT INTO Patrons VALUES (" + data + ")", sqlConnection);
                addCommand.ExecuteNonQuery();
            }
        }

        // When the button to edit an existing patron is clicked
        private void editPatronButtonClick(object sender, EventArgs e)
        {
            DataGridViewRow row = outputDataView.SelectedRows[0];

            string firstName = row.Cells[0].Value.ToString();
            string lastName = row.Cells[2].Value.ToString();
            string middleInitial = row.Cells[1].Value.ToString();
            string dateOfBirth = row.Cells[4].Value.ToString();
            string guardians = row.Cells[5].Value.ToString();
            string children = row.Cells[6].Value.ToString();
            string spouse = row.Cells[7].Value.ToString();

            NewPatronForm form = new NewPatronForm(firstName, lastName, middleInitial, dateOfBirth, guardians, children, spouse);
            form.ShowDialog();

            if (form.Saved())
            {
                Patron p = form.GetData();
                string data = "'" + p.firstName + "'" + ','
                    + "'" + p.middleInitial + "'" + ','
                    + "'" + p.lastName + "'" + ','
                    + "'" + p.spouse + "'" + ','
                    + "'" + p.guardians + "'" + ','
                    + "'" + p.children + "'" + ','
                    + "''" + ','
                    + "'" + p.dateOfBirth + "'";

                // Remove old values
                string command = "DELETE FROM Patrons WHERE" +
                    patronFirstName + "='" + firstName + "' AND "
                    + patronLastName + "='" + lastName + "' AND "
                    + middleI + "='" + middleInitial + "' AND "
                    + childrens + "='" + children + "' AND "
                    + Guardians + "='" + guardians + "' AND "
                    + spouseColumn + "='" + spouse + "'";
                SqlCommand delCommand = new SqlCommand(command, sqlConnection);
                delCommand.BeginExecuteNonQuery();

                SqlCommand addCommand = new SqlCommand("INSERT INTO Patrons VALUES (" + data + ")");
                addCommand.BeginExecuteNonQuery();
            }
        }

        // When the button to print a report is clicked
        private void printVisitButtonClick(object sender, EventArgs e)
        {
            DataGridViewRow row = outputDataView.SelectedRows[0];

            string firstName = row.Cells[0].Value.ToString();
            string lastName = row.Cells[2].Value.ToString();
            string middleInitial = row.Cells[1].Value.ToString();

            int portionsAllowed;
            // Calculate the amount of portions allowed
            if (row.Cells[5].Value.ToString()!="")
            {
                // Is a child.
                portionsAllowed = 0;
            }
            else
            {
                // Get the number of children
                int providees = row.Cells[6].Value.ToString().Split(',').Length;

                // Check for a spouse
                if (row.Cells[7].Value.ToString() != "")
                    providees++;

                // 1 Limit
                if (providees <= 3)
                    portionsAllowed = 1;

                // 2 Limits
                else if (providees <= 5)
                    portionsAllowed = 2;

                // 3 Limits
                else
                    portionsAllowed = 3;
            }
            DateTime today = DateTime.Today;

            // Show the form
            PrintVisitForm printForm = new PrintVisitForm(firstName, middleInitial, lastName, portionsAllowed, today.ToString(dateCode));
            printForm.ShowDialog();
        }
    }
}
