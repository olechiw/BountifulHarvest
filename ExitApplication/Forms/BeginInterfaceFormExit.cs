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

namespace ExitApplication
{
    public partial class BeginInterfaceForm : Common.DialogForm
    {
        private const string connectionString = "Server=localhost\\SQLEXPRESS;Database=BountifulHarvest;User Id=sa; Password=potato";

        private const string dateCode = "d";

        // The date
        private string date;

        // The most recent patron id submitted
        private int lastVisitID;


        // The database handler, responsible for all sql operations
        private Common.VisitsSqlHandler sqlHandler;

        public BeginInterfaceForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;


            // Show the date on the datemessage
            DateTime today = DateTime.Today;
            date = today.ToString(dateCode);
            dateLabel.Text = "Today's Date is: " + date;

            // Connect to the database
            sqlHandler = new Common.VisitsSqlHandler(connectionString);

            LoadAllVisits();
        }


        // Load the initial list of visits for the day
        public void LoadAllVisits()
        {
            // Get all of the visits for the month
            outputDataView.Rows.Clear();

            foreach (Visit v in sqlHandler.GetMonthRows())
                AddDataRow(v);
        }
        
        // Add a row to the output
        private void AddDataRow(Visit v)
        {
            outputDataView.Rows.Add(
                v.PatronFirstName,
                v.PatronMiddleInitial,
                v.PatronLastName,
                v.TotalPounds,
                v.DateOfVisit.Date.ToString("d"),
                v.VisitID);
        }

        // Load the top 100 visits. May go unused, here for consistency
        private void LoadTopRows()
        {
            VisitList rows = sqlHandler.GetTopRows(100);
        }

        // Extra constructor. Currently unused
        private void BeginInterface_Load(object sender, EventArgs e)
        {

        }

        private void submitButtonClick(object sender, EventArgs e)
        {
            Visit v = new Visit
            {
                PatronFirstName = patronFirstNameTextBox.Text.ToString(),
                PatronMiddleInitial = patronMiddleInitialTextBox.Text.ToString(),
                PatronLastName = patronLastNameTextBox.Text.ToString(),
                TotalPounds = Constants.SafeConvertInt(totalPoundsSpinner.Value.ToString()),
                SizeOfFamily = Constants.SafeConvertInt((sizeOfFamilySpinner.Value.ToString())),
                DateOfVisit = DateTime.Today
            };

            sqlHandler.AddRow(v);
            AddDataRow(v);
            lastVisitID = v.VisitID;
        }

        private void undoButtonClick(object sender, EventArgs e)
        {
            for (int i = 0; i < outputDataView.Rows.Count-1; ++i)
            {
                if (Constants.SafeConvertInt(outputDataView.Rows[(int)Common.Constants.VisitIndexes.VisitID].ToString())==lastVisitID)
                {
                    outputDataView.Rows.RemoveAt(i);
                }
            }

            sqlHandler.DeleteRow(lastVisitID);
        }
    }
}
