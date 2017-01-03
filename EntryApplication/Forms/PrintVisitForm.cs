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

//
// PrintVisitForm - A form which takes a patron's data and displays it to confirm. It then organizes and prints it.
//

namespace EntryApplication
{
    public partial class PrintVisitForm : Common.DialogForm
    {
        private System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();

        private Patron patron;
        private int limitsAllowed, numberInFamily;

        // Coordinates for where to draw each label. I'm a hack
        private readonly Point namePoint = new Point(75, 780);
        private readonly Point limitsPoint = new Point(135, 890);
        private readonly Point familyPoint = new Point(130, 930);
        private readonly Point datePoint = new Point(5, 970);
        private readonly Point idPoint = new Point(5, 1020);

        // Constructor
        public PrintVisitForm(Patron p)
        {
            patron = p;

            InitializeComponent();

            FillLabels();

            CalculateValues();
         
            print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(screenPrintPrintPage);
        }

        // Fill all of the forms
        private void FillLabels()
        {
            this.firstNameLabel.Text += patron.FirstName;
            this.middleInitialLabel.Text += patron.MiddleInitial;
            this.lastNameLabel.Text += patron.LastName;
            this.datelabel.Text += Common.Constants.ConvertDateTime(DateTime.Today);
            this.limitsAllowedLabel.Text += limitsAllowed;
        }

        // Figure out the size of the family and allowed limits
        private void CalculateValues()
        {
            if (string.IsNullOrEmpty(patron.Family))
            {
                numberInFamily = 1;
                limitsAllowed = 1;
            }
            else
            {
                int c = patron.Family.Split(',').Length;

                if (c < 4)
                    limitsAllowed = 1;
                else if (c < 6)
                    limitsAllowed = 2;
                else
                    limitsAllowed = 3;

                numberInFamily = c;
            }
        }

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
            //Bitmap loadedImage = new Bitmap(Constants.printFormImage);

            // Draw the image and the text which fills it out
            //g.DrawImage(loadedImage, new Point(0, 0));


            DrawGenericText(g, name, namePoint.X, namePoint.Y);
            DrawGenericText(g, limitsAllowed.ToString(), limitsPoint.X, limitsPoint.Y);
            DrawGenericText(g, numberInFamily.ToString(), familyPoint.X, familyPoint.Y);
            DrawGenericText(g, Constants.ConvertDateTime(DateTime.Today), datePoint.X, datePoint.Y);
            DrawGenericText(g, id, idPoint.X, idPoint.Y);
        }

        // Given arguments of coordinates, graphics, and text, draws a simple string
        private void DrawGenericText(Graphics g, string text, int x, int y) =>
            g.DrawString(text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular), new SolidBrush(Color.Black), x, y);

        // When the print button is clicked
        private void printButtonClick(object sender, EventArgs e)
        {
            if (patron.DateOfLastVisit.Month == DateTime.Today.Month)
            {
                string message =
                    "This person has already visited in " +
                    DateTime.Today.Month.ToString() +
                    " already. This person " +
                    ((patron.VisitsEveryWeek) ? "CAN " : "CANNOT ") +
                    "visit every week. Is this ok?";
                var result = MessageBox.Show(message);


                if (result != DialogResult.OK)
                    return;
            }

            // Initialize a print dialog and print the document
            using (PrintDialog pD = new PrintDialog())
            {
                pD.Document = print;

                if (pD.ShowDialog() == DialogResult.OK)
                {
                    //string name = Constants.ConjuncName(patron.FirstName, patron.MiddleInitial, patron.LastName);
                    print.Print();

                    patron.DateOfLastVisit = DateTime.Today;

                    // Manual drawing
                    //DebugPrintPreviewForm f = new DebugPrintPreviewForm();

                    // Load the form image
                    //Bitmap loadedImage = new Bitmap(Constants.printFormImage);

                    //Graphics g = Graphics.FromImage(loadedImage);
                    //DrawGenericText(g, name, namePoint.X, namePoint.Y);
                    //DrawGenericText(g, limitsAllowed.ToString(), limitsPoint.X, limitsPoint.Y);
                    //DrawGenericText(g, numberInFamily.ToString(), familyPoint.X, familyPoint.Y);
                    //DrawGenericText(g, Constants.ConvertDateTime(DateTime.Today), datePoint.X, datePoint.Y);

                    //f.Draw(loadedImage);
                    //f.ShowDialog();
                }
            }

            this.Close();
        }

        private void previewButtonClick(object sender, EventArgs e)
        {
            using (PrintPreviewDialog pD = new PrintPreviewDialog())
            {
                pD.Document = print;
                pD.ShowDialog();
            }
        }

        // In case the user wants to cancel printing, close the window
        private void cancelButtonClick(object sender, EventArgs e) => this.Close();

        // Extra constructor, currently unimplemented
        private void PrintVisitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
