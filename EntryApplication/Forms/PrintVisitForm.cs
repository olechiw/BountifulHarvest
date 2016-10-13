using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
// PrintVisitForm - A form which takes a patron's data and displays it to confirm. It then organizes and prints it.
//

namespace EntryApplication
{
    public partial class PrintVisitForm : Form
    {
        System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();

        private string firstName, lastName, middleInitial, limitsAllowed, numberInFamily, date;

        // Coordinates for where to draw each label
        private readonly Point namePoint = new Point(75, 780);
        private readonly Point limitsPoint = new Point(123, 882);
        private readonly Point familyPoint = new Point(123, 920);
        private readonly Point datePoint = new Point(540, 970);

        // Name of the form's image file
        private const string formImage = "Z:\\form2.png";

        // Constructor
        public PrintVisitForm(string patronFirstName, string patronMiddleInitial, string patronLastName, int patronLimitsAllowed, int patronNumberInFamily, string date)
        {
            firstName = patronFirstName;
            lastName = patronLastName;
            middleInitial = patronMiddleInitial;
            limitsAllowed = patronLimitsAllowed.ToString();
            numberInFamily = patronNumberInFamily.ToString();
            this.date = date;

            InitializeComponent();
            print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(screenPrintPrintPage);


            this.firstNameLabel.Text += firstName;
            this.lastNameLabel.Text += lastName;
            this.datelabel.Text += this.date;
            this.middleInitialLabel.Text += middleInitial;
            this.limitsAllowedLabel.Text += limitsAllowed;
        }

        // When the screenPrint document is about to be printed
        private void screenPrintPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Create the full name of the person
            string name = firstName + ' ' + middleInitial + ". " + lastName;

            // Load the form image
            Bitmap loadedImage = new Bitmap(formImage);

            // Draw the image and the text which fills it out
            Graphics g = e.Graphics;
            g.DrawImage(loadedImage, new Point(0, 0));
            DrawGenericText(g, name, namePoint.X, namePoint.Y);
            DrawGenericText(g, limitsAllowed, limitsPoint.X, limitsPoint.Y);
            DrawGenericText(g, numberInFamily, familyPoint.X, familyPoint.Y);
            DrawGenericText(g, date, datePoint.X, datePoint.Y);
        }

        // Given arguments of coordinates, graphics, and text, draws a simple string
        private void DrawGenericText(Graphics g, string text, int x, int y) =>
            g.DrawString(text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular), new SolidBrush(Color.Black), x, y);

        // When the print button is clicked
        private void printButtonClick(object sender, EventArgs e)
        {
            // Initialize a print dialog and print the document
            using (PrintDialog pD = new PrintDialog())
            {
                pD.Document = print;

                if (pD.ShowDialog() == DialogResult.OK)
                {
                    print.Print();
                }
            }

            this.Close();
        }

        // In case the user wants to cancel printing, close the window
        private void cancelButtonClick(object sender, EventArgs e) => this.Close();

        // Extra constructor, currently unimplemented
        private void PrintVisitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
