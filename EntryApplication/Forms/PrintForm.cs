using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Common;
using VisitList = System.Linq.IQueryable<Common.Visit>;
using PatronList = System.Linq.IQueryable<Common.Patron>;

namespace EntryApplication
{
    public partial class PrintForm : DialogForm
    {
        /*
         * PRINTING THINGS
         */
        private int limitsAllowed;

        private Visit mVisit;
        private int numberInFamily;
        private Patron patron;

        public PrintForm(Patron p, Visit extrasVisitObject)
            // The visit will only contain which extras were already done in the past year
        {
            patron = p;
            mVisit = extrasVisitObject;
            InitializeComponent();

            // Update the checkboxes for any of the extras that have been obtained this year
            easter.Checked = mVisit.Easter;
            christmas.Checked = mVisit.Christmas;
            thanksgiving.Checked = mVisit.Thanksgiving;
            school.Checked = mVisit.School;
            winter.Checked = mVisit.Winter;
            halloween.Checked = mVisit.Halloween;

            refreshDocumentPreview();
        }

        // Given arguments of coordinates, graphics, and text, draws a simple string
        private static void DrawGenericText(Graphics g, string text, int x, int y)
        {
            g.DrawString(text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular),
                new SolidBrush(Color.Black), x, y);
        }

        // Figure out the size of the family and allowed limits
        private void CalculateValues()
        {
            var c = patron.Family.Split(',').Length;

            if (c < 4)
                limitsAllowed = 1;
            else if (c < 6)
                limitsAllowed = 2;
            else
                limitsAllowed = 3;

            if (string.IsNullOrEmpty(patron.Family.Split(',')[0]))
                numberInFamily = 1;
            else
                numberInFamily = c + 1;
        }

        // When the screenPrint document is about to be printed, draw what we want
        private void ScreenPrintPrintPage(object sender, PrintPageEventArgs e)
        {
            // Create the full name of the person
            var name = Constants.ConjuncName(patron.FirstName, patron.MiddleInitial, patron.LastName);

            // The patron id
            var id = "Patron #" + patron.PatronId;

            var g = e.Graphics;
            //
            // This is removed because forms will be pre-printed:
            //

            // Load the form image
            Bitmap loadedImage = null;
            try
            {
                loadedImage = new Bitmap(Constants.releaseFormImage);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load " + Constants.releaseFormImage + ", check your installation!");
                return;
            }

            // Draw the image and the text which fills it out
            g.DrawImage(loadedImage, new Point(0, 0));

            CalculateValues();

            DrawGenericText(g, name, Constants.namePoint.X, Constants.namePoint.Y);
            DrawGenericText(g, limitsAllowed.ToString(), Constants.limitsPoint.X, Constants.limitsPoint.Y);
            DrawGenericText(g, numberInFamily.ToString(), Constants.familyPoint.X, Constants.familyPoint.Y);
            DrawGenericText(g, Constants.ConvertDateTime(DateTime.Today), Constants.datePoint.X, Constants.datePoint.Y);
            DrawGenericText(g, id, Constants.idPoint.X, Constants.idPoint.Y);

            DrawDel drawExtra = p => DrawGenericText(g, "X", p.X, p.Y);

            if (mVisit.Easter) drawExtra(Constants.easterPoint);
            if (mVisit.Halloween) drawExtra(Constants.halloweenPoint);
            if (mVisit.Christmas) drawExtra(Constants.christmasPoint);
            if (mVisit.Thanksgiving) drawExtra(Constants.thanksgivingPoint);
            if (mVisit.Winter) drawExtra(Constants.winterPoint);
            if (mVisit.School) drawExtra(Constants.schoolPoint);


            if (patron.Veteran) drawExtra(Constants.veteranPoint);
            if (patron.Senior) DrawGenericText(g, "CFSP DONE", Constants.cfspPoint.X, Constants.cfspPoint.Y);
            if (patron.VisitsEveryWeek)
                DrawGenericText(g, "Visits Every Week", Constants.everyWeekPoint.X, Constants.everyWeekPoint.Y);
            /*
            if (patron.Old > 0)
                DrawGenericText(g, "Seniors in household: " + patron.Old, Constants.seniorsPoint.X,
                    Constants.seniorsPoint.Y);
                    */
            // "Seniors" in the household
            var patronAge = DateTime.Today.Year - patron.DateOfBirth.Year;
            var seniors = (patronAge > 59) ? 1 : 0;
            foreach (var dob in patron.FamilyDateOfBirths.Split(','))
            {
                if (string.IsNullOrEmpty(dob)) continue;
                try
                {
                    var date = Constants.SafeConvertDate(dob);
                    if (DateTime.Today.Year - date.Year > 59)
                    {
                        seniors++;
                    }
                }
                catch (Exception exception)
                {
                    Logger.Log(exception.StackTrace);
                }
            }
            if (seniors > 0)
                DrawGenericText(g, "Seniors in household: " + seniors, Constants.seniorsPoint.X,
                    Constants.seniorsPoint.Y);
        }

        public void Print(Patron p)
        {
            Logger.Log(
                "Printing patron: " +
                Constants.ConjuncName(
                    p.FirstName,
                    p.MiddleInitial,
                    p.LastName));

            var print = new PrintDocument();

            print.PrintPage += ScreenPrintPrintPage;

            patron = p;
            CalculateValues();

            var database = new BountifulHarvestContext(Constants.ISRELEASE
                ? Constants.loadReleaseServerString()
                : Constants.debugConnectionString);

            var visitsThisMonth = from v in database.Visits
                where v.PatronID == p.PatronId && v.DateOfVisit.Month == DateTime.Today.Month
                      && v.DateOfVisit.Year == DateTime.Today.Year
                select v;

            // Check if they have visited three times this month
            if (visitsThisMonth.Count() >= 3 && !patron.VisitsEveryWeek)
            {
                var previousVisits = "";

                // Latest two visits
                var top = visitsThisMonth.OrderByDescending(v => v.PatronID).Take(3);

                foreach (var v in top)
                    previousVisits += v.DateOfVisit.ToString("d") + ',';

                if (previousVisits != "") // Remove last comma
                    previousVisits = previousVisits.Substring(0, previousVisits.Length - 1);

                var message =
                    "This person has already visited in " +
                    DateTime.Today.ToString("MMMM") +
                    " 3 times: On " + previousVisits + "." +
                    " This person CANNOT visit every week. Is this okay?";
                var result = MessageBox.Show(message, "Visited Already", MessageBoxButtons.OKCancel);


                if (result != DialogResult.OK)
                    return;
            }

            using (var pD = new PrintDialog())
            {
                pD.Document = print;
                if (pD.ShowDialog() == DialogResult.OK)
                {
                    print.Print();
                    Close();
                }
            }
        }

        private void checkChanged(object sender, EventArgs e)
        {
            mVisit = new Visit
            {
                Halloween = halloween.Checked,
                Thanksgiving = thanksgiving.Checked,
                School = school.Checked,
                Winter = winter.Checked,
                Christmas = christmas.Checked,
                Easter = easter.Checked
            };
            refreshDocumentPreview();
        }

        private void refreshDocumentPreview()
        {
            var document = new PrintDocument();
            document.PrintPage += ScreenPrintPrintPage;
            printPreviewControl.Document = document;
            printPreviewControl.Refresh();
        }

        private void printButtonClick(object sender, EventArgs e)
        {
            Print(patron);
        }

        private delegate void DrawDel(Point p);
    }
}