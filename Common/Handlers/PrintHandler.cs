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

using Common;

using VisitList = System.Linq.IQueryable<Common.Visit>;

namespace Common
{
    public class PrintHandler
    {

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

            numberInFamily = c + 1;
        }

        /*
         * PRINTING THINGS
         */
        int limitsAllowed;
        int numberInFamily;
        Patron patron;


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

            DrawGenericText(g, name, Constants.namePoint.X, Constants.namePoint.Y);
            DrawGenericText(g, limitsAllowed.ToString(), Constants.limitsPoint.X, Constants.limitsPoint.Y);
            DrawGenericText(g, numberInFamily.ToString(), Constants.familyPoint.X, Constants.familyPoint.Y);
            DrawGenericText(g, Constants.ConvertDateTime(DateTime.Today), Constants.datePoint.X, Constants.datePoint.Y);
            DrawGenericText(g, id, Constants.idPoint.X, Constants.idPoint.Y);
        }
        private System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();

        public void Print(Patron p)
        {

            print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(screenPrintPrintPage);

            patron = p;
            CalculateValues();

            BountifulHarvestContext database = new BountifulHarvestContext((Constants.ISRELEASE) ? Constants.releaseServerConnectionString : Constants.debugConnectionString);

            var lastVisit = ((
                from v in database.Visits
                where (v.PatronID == p.PatronID)
                select v
                )).OrderByDescending(v => v.VisitID)
                .Take(1);
            DateTime dateOfLastVisit;
            if (lastVisit.Count() > 0)
                dateOfLastVisit = lastVisit.First().DateOfVisit;
            else
                dateOfLastVisit = new DateTime();


            if ((dateOfLastVisit.Month == DateTime.Today.Month) && (!patron.VisitsEveryWeek))
            {
                string previousVisits = "";

                VisitList all = ((from v in database.Visits where v.PatronID == p.PatronID select v));

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
    }
}
