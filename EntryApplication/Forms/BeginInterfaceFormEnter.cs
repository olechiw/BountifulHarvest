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
        Common.PatronsSqlHandler sqlHandler;



        // Constructor
        public BeginInterfaceForm()
        {
            InitializeComponent();

            Constants.InitializeDataView(outputDataView);

            InitializeSQL();

            dateLabel.Text = "Today's Date is: " + Constants.ConvertDateTime(DateTime.Today);

            print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(screenPrintPrintPage);
            print.EndPrint += previewEndPrint;
        }

        // Setup the sql connection
        private void InitializeSQL()
        {
            string connString = (Constants.ISRELEASE) ? Constants.releaseServerConnectionString : Constants.debugConnectionString;

            // Connect to the SQL database
            sqlHandler = new Common.PatronsSqlHandler(connString);

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

            // Read all of the patrons into the data
            foreach (Patron p in sqlHandler.GetTopRows(100))
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
                Constants.ConvertDateTime(p.DateOfBirth),
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

                AddDataRows(sqlHandler.GetRowsSimilar(query));
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

            sqlHandler.AddRow(p);

            if (p.DateOfBirth.Date != new DateTime().Date)
                Print(p);

            LoadAllPatrons();
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

            Patron p = sqlHandler.GetRow(patronId);

            // Get new data passing the old data on
            NewPatronForm form = new NewPatronForm(p);
            form.ShowDialog();

            if (!form.Saved())
                return;

            Patron updatedP = form.GetResults();
            Patron.Copy(p, updatedP);

            p.Calculate();

            sqlHandler.Update();

            LoadAllPatrons();
        }



        // When the button to print a report is clicked
        private void printVisitButtonClick(object sender, EventArgs e)
        {
            int selectedPatronID = Constants.GetSelectedInt(outputDataView, (int)Constants.OutputDataColumnsPatrons.PatronID);

            Patron selectedPatron = sqlHandler.GetRow(selectedPatronID);

            // Show the form
            Print(selectedPatron);
        }

        private void previewEndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (e.PrintAction == System.Drawing.Printing.PrintAction.PrintToPrinter)
            {
                patron.DateOfLastVisit = DateTime.Today;
            }
        }

        /*
         * PRINTING THINGS
         */
        int limitsAllowed;
        int numberInFamily;
        Patron patron;

        // Coordinates for where to draw each label. I'm a hack
        private readonly Point namePoint = new Point(75, 780);
        private readonly Point limitsPoint = new Point(135, 890);
        private readonly Point familyPoint = new Point(130, 930);
        private readonly Point datePoint = new Point(5, 970);
        private readonly Point idPoint = new Point(5, 1020);


        // When the screenPrint document is about to be printed, draw what we want
        private void screenPrintPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Create the full name of the person
            string name = Constants.ConjuncName(patron.FirstName, patron.MiddleInitial, patron.LastName);

            // The patrin id
            string id = "Patron #" + patron.PatronID.ToString();

            Graphics g = e.Graphics;
            //
            // This is removed because forms will be pre-printed:
            //

            // Load the form image
            Bitmap loadedImage = new Bitmap((Constants.ISRELEASE) ? Constants.releaseFormImage : Constants.printFormImage);

            // Draw the image and the text which fills it out
            g.DrawImage(loadedImage, new Point(0, 0));

            CalculateValues();

            DrawGenericText(g, name, namePoint.X, namePoint.Y);
            DrawGenericText(g, limitsAllowed.ToString(), limitsPoint.X, limitsPoint.Y);
            DrawGenericText(g, numberInFamily.ToString(), familyPoint.X, familyPoint.Y);
            DrawGenericText(g, Constants.ConvertDateTime(DateTime.Today), datePoint.X, datePoint.Y);
            DrawGenericText(g, id, idPoint.X, idPoint.Y);
        }
        private System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();

        public void Print(Patron p)
        {
            patron = p;
            CalculateValues();
            if ((patron.DateOfLastVisit.Month == DateTime.Today.Month) && (patron.DateOfLastVisit != DateTime.Today))
            {
                string previousVisits = "";

                VisitsSqlHandler visits = new VisitsSqlHandler((Constants.ISRELEASE) ? Constants.releaseServerConnectionString : Constants.debugConnectionString);

                VisitList all = visits.GetPatronsRows(patron.PatronID);

                // Latest two visits
                VisitList top = all.OrderByDescending(v => v.PatronID).Take(2);

                foreach (Visit v in top)
                    previousVisits += v.DateOfVisit.ToString("d") + ',';

                if (previousVisits != "")
                    previousVisits = previousVisits.Substring(0, previousVisits.Length - 1);

                string times = "";
                switch (top.Count())
                {
                    case (1):
                        times = "Once";
                        break;
                    case (2):
                        times = "Twice";
                        break;
                }

                string message =
                    "This person has already visited in " +
                    DateTime.Today.ToString("MMMM") +
                    " already. " + times + " on " + previousVisits + "." +
                    " This person " +
                    ((patron.VisitsEveryWeek) ? "CAN " : "CANNOT ") +
                    "visit every week. Is this ok?";
                var result = MessageBox.Show(message, "Visited Already", MessageBoxButtons.OKCancel);


                if (result != DialogResult.OK)
                {
                    return;
                }
            }

            using (PrintPreviewDialog pD = new PrintPreviewDialog())
            {
                pD.Document = print;
                DialogResult result = pD.ShowDialog();
            }
            return;
        }

        // Given arguments of coordinates, graphics, and text, draws a simple string
        private void DrawGenericText(Graphics g, string text, int x, int y) =>
            g.DrawString(text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular), new SolidBrush(Color.Black), x, y);
        // Figure out the size of the family and allowed limits
        private void CalculateValues()
        {
            int c = patron.Family.Split(',').Length;

            if (c < 4)
                limitsAllowed = 1;
            else if (c < 6)
                limitsAllowed = 2;
            else
                limitsAllowed = 3;

            numberInFamily = (c == 1) ? c : c + 1;
        }

        // When the button to view more information about a patron is clicked. This is ugly but I'm currently too lazy to fix it
        private void morePatronInfoButtonClick(object sender, EventArgs e)
        {
            DataGridViewRow row = outputDataView.SelectedRows[0];

            int id = Constants.GetSelectedInt(outputDataView, (int)Constants.OutputDataColumnsPatrons.PatronID);
            Patron p = sqlHandler.GetRow(id);

            MoreInfoForm form = new MoreInfoForm(p);

            form.ShowDialog();
        }

        private void clearButtonClick(object sender, EventArgs e)
        {
            searchBox.Text = "";
            LoadAllPatrons();
            searchBox.Focus();
        }
    }
}