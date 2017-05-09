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

        public PrintForm(Patron p)
        {
            patron = p;
            mVisit = new Visit();
            InitializeComponent();
            refresh();
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
            int c = patron.Family.Split(',').Length;

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
            string name = Constants.ConjuncName(patron.FirstName, patron.MiddleInitial, patron.LastName);

            // The patron id
            string id = "Patron #" + patron.PatronId;

            Graphics g = e.Graphics;
            //
            // This is removed because forms will be pre-printed:
            //

            // Load the form image
            var loadedImage = new Bitmap(Constants.ISRELEASE ? Constants.releaseFormImage : Constants.printFormImage);

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
                ? Constants.releaseServerConnectionString
                : Constants.debugConnectionString);

            VisitList lastVisit = (from v in database.Visits
                    where v.PatronID == p.PatronId
                    select v).OrderByDescending(v => v.VisitID)
                .Take(1);

            DateTime dateOfLastVisit =
                lastVisit.Any() ? lastVisit.First().DateOfVisit : new DateTime();


            if (dateOfLastVisit.Month == DateTime.Today.Month && !patron.VisitsEveryWeek)
            {
                var previousVisits = "";

                VisitList all = from v in database.Visits where v.PatronID == p.PatronId select v;

                // Latest two visits
                VisitList top = all.OrderByDescending(v => v.PatronID).Take(2);

                foreach (Visit v in top)
                    previousVisits += v.DateOfVisit.ToString("d") + ',';

                if (previousVisits != "")
                    previousVisits = previousVisits.Substring(0, previousVisits.Length - 1);

                var times = "";
                switch (top.Count())
                {
                    case 1:
                        times = "Once";
                        break;
                    case 2:
                        times = "Twice";
                        break;
                }

                string message =
                    "This person has already visited in " +
                    DateTime.Today.ToString("MMMM") +
                    " already. " + times + " on " + previousVisits + "." +
                    " This person " +
                    (patron.VisitsEveryWeek ? "CAN " : "CANNOT ") +
                    "visit every week. Is this ok?";
                DialogResult result = MessageBox.Show(message, "Visited Already", MessageBoxButtons.OKCancel);


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
            refresh();
        }

        private void refresh()
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