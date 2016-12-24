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

            // Connect to the database
            sqlHandler = new Common.VisitsSqlHandler(Constants.debugConnectionString);

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
                Constants.ConvertDateTime(v.DateOfVisit),
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
                SizeOfFamily = Constants.SafeConvertInt(sizeOfFamilySpinner.Value.ToString()),
                DateOfVisit = DateTime.Today,
                PatronID = Constants.SafeConvertInt(patronIDTextBox.Value.ToString())
            };

            sqlHandler.AddRow(v);
            AddDataRow(v);
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            int id = Constants.GetSelectedInt(outputDataView, (int)Constants.VisitIndexes.VisitID);

            sqlHandler.DeleteRow(id);

            LoadAllVisits();
        }

        private void inputFormFocus(object sender, EventArgs e)
        {
            if (sender is LatinTextBox)
            {
                LatinTextBox s = (LatinTextBox)sender;
                s.SelectAll();
            }
            else if (sender is NumericUpDown)
            {
                // LOL, hipster 1-line code
                ((NumericUpDown)sender).Select(0,((NumericUpDown)sender).Text.Length);
            }
        }
    }
}
