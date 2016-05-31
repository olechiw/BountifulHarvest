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

        // Constructor
        public PrintVisitForm(string patronFirstName, string patronLastName, int patronAllowedPortions, string date)
        {
            firstName = patronFirstName;
            lastName = patronLastName;
            allowedPortions = patronAllowedPortions.ToString();


            InitializeComponent();
            print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(screenPrintPrintPage);
        }

        // When the screenPrint document is about to be printed
        private void screenPrintPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            drawGenericText(e.Graphics, "First Name", 0, 0);
            drawGenericText(e.Graphics, "Last Name", 200, 0);
            drawGenericText(e.Graphics, "Middle Name", 100, 0);
        }

        // Given arguments of coordinates, graphics, and text, draws a simple string
        private void drawGenericText(Graphics g, string text, int x, int y)
        {
            g.DrawString(text, new Font(FontFamily.GenericSansSerif, 30, FontStyle.Regular), new SolidBrush(Color.Black), 0, 0);
        }

        // When the print button is clicked
        private void printButtonClick(object sender, EventArgs e)
        {
            using (PrintDialog pD = new PrintDialog())
            {
                pD.Document = print;

                if (pD.ShowDialog() == DialogResult.OK)
                {
                    print.Print();
                }
            }
        }

        // Extra constructor, currently unimplemented
        private void PrintVisitForm_Load(object sender, EventArgs e)
        {

        }
    }
}
