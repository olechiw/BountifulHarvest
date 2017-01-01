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
        // The database handler, responsible for all sql operations
        private Common.VisitsSqlHandler sqlHandler;

        // The second one, for accessing another table
        private Common.PatronsSqlHandler patronsHandler;

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
            sqlHandler = new Common.VisitsSqlHandler(connString);
            patronsHandler = new Common.PatronsSqlHandler(connString);


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
            Patron p = patronsHandler.GetRow(v.PatronID);

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
                TotalPounds = Constants.SafeConvertInt(totalPoundsSpinner.Value.ToString()),
                DateOfVisit = DateTime.Today,
                PatronID = Constants.SafeConvertInt(patronIDTextBox.Text)
            };

            sqlHandler.AddRow(v);
            AddDataRow(v);

            totalPoundsSpinner.Value = 0;
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            int id = Constants.GetSelectedInt(outputDataView, (int)Constants.VisitIndexes.VisitID);

            sqlHandler.DeleteRow(id);

            LoadAllVisits();
        }

        private void patronIDChanged(object sender, EventArgs e)
        {
            outputDataView.Rows.Clear();

            int id = Constants.SafeConvertInt(patronIDTextBox.Text.ToString());

            VisitList rows = sqlHandler.GetPatronsRows(id);

            for (int i = 0; i < rows.Count(); ++i)
            {
                AddDataRow(rows.AsEnumerable().ElementAt(i));
            }

        }
    }
}
