using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace EntryApplication
{
    public partial class PrintVisitForm : Form
    {
        System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();

        private string firstName, lastName, allowedPortions, date;

        private bool successfullyPrinted = false;
        public bool SuccessfullyPrinted() => successfullyPrinted;

        // Constructor
        public PrintVisitForm(string patronFirstName, string patronLastName, int patronAllowedPortions, string date)
        {
            firstName = patronFirstName;
            lastName = patronLastName;
            allowedPortions = patronAllowedPortions.ToString();
            this.date = date;

            InitializeComponent();
            print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(screenPrintPrintPage);


            this.firstNameLabel.Text += firstName;
            this.lastNameLabel.Text += lastName;
            this.datelabel.Text += this.date;
        }

        // When the screenPrint document is about to be printed
        private void screenPrintPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Draw the report
            drawGenericText(e.Graphics, "First Name: " + firstName, 200, 0);
            drawGenericText(e.Graphics, "Last Name: " + lastName, 200, 50);
            drawGenericText(e.Graphics, "Date: " + date, 200, 100);
        }

        // Given arguments of coordinates, graphics, and text, draws a simple string
        private void drawGenericText(Graphics g, string text, int x, int y) =>
            g.DrawString(text, new Font(FontFamily.GenericSansSerif, 25, FontStyle.Regular), new SolidBrush(Color.Black), x, y);

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

        // Extra constructor, currently unimplemented
        private void PrintVisitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
