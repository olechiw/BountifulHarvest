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
using System.Data.SqlTypes;


namespace EntryApplication
{
    public partial class BeginInterfaceForm : Form
    {
        // Hardcoded strings for all of the column names in SQL
        private const string firstName = "FirstName";
        private const string lastName = "LastName";
        private const string middleInitial = "MiddleInitial";
        private const string guardians = "Guardians";
        private const string children = "Children";
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

            // Setup the dataview
            outputDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Show the date on the datemessage
            DateTime today = DateTime.Today;
            dateLabel.Text = "Today's Date is: " + today.ToString(dateCode);

            // Connect to the local SQL Database
            sqlConnection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Patrons;Integrated Security=True;");
            sqlConnection.Open();

            // Testcode. This will display all the patrons in the list
            SqlCommand patronsCommand = new SqlCommand("SELECT * FROM Patrons;", sqlConnection);
            SqlDataReader patrons = null;

            // Read all of the patrons into the data
            patrons = patronsCommand.ExecuteReader();
            while (patrons.Read())
            {
                string lastVisit = patrons[dateOfLastVisit].ToString();
                addDataRow(patrons[firstName].ToString(), patrons[lastName].ToString(), lastVisit);
            }
            patrons.Close();
        }

        // A second constructor, not really neccesary atm
        private void BeginInterfaceForm_Load(object sender, EventArgs e)
        {

        }

        // For formatting purposes, convert an sql '-' delimited string to a more standard '/' delimited string
        private string SqlString2Std(string sqlString)
        {
            string[] split = sqlString.Split('-');
            string year = split[0];
            string month = split[1];
            string day = split[2];
            return month + '/' + day + '/' + year;
        }

        // Shorthand for adding a set of values to the outputDataView
        private void addDataRow(params object[] values)
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
            SqlCommand searchCommand = new SqlCommand("SELECT * FROM Patrons WHERE FirstName LIKE '" + query + "%' OR LastName LIKE '" + query + "%'", sqlConnection);

            SqlDataReader results = searchCommand.ExecuteReader();

            outputDataView.Rows.Clear();
            while (results.Read())
            {
                addDataRow(results[firstName].ToString(), results[lastName].ToString(), results[dateOfLastVisit].ToString());
            }
            results.Close();
        }
    }
}
