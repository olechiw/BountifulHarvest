using System;
using System.IO;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Packaging;
using System.Drawing.Printing;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Windows.Forms;

namespace EntryApplication
{
    public partial class NewPatronForm : System.Windows.Forms.Form
    {
        System.Drawing.Bitmap currentScreen;
        System.Drawing.Printing.PrintDocument screenPrint = new System.Drawing.Printing.PrintDocument();

        public NewPatronForm()
        {
            InitializeComponent();

            screenPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(screenPrintPrintPage);
        }

        private void CaptureScreen()
        {
            
            currentScreen = new System.Drawing.Bitmap(this.Size.Width, this.Size.Height, this.CreateGraphics());
            var g = System.Drawing.Graphics.FromImage(currentScreen);
            g.CopyFromScreen(this.Location.X, this.Location.Y, 10, 10, this.Size);
            
        }

        // When the screenPrint document is about to be printed
        private void screenPrintPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(currentScreen, 0, 0);
        }


        object missing = System.Reflection.Missing.Value;


        private void testPrintButtonClick(object sender, EventArgs e)
        {
            using (PrintDialog pD = new PrintDialog())
            {

                pD.Document = screenPrint;

                if (pD.ShowDialog()==DialogResult.OK)
                {
                    CaptureScreen();
                    screenPrint.Print();
                }
            }
        }

        private void findAndReplace(string findText, string replaceText, ref string contentText)
        {
            Regex regexText = new Regex(findText);
            contentText = regexText.Replace(contentText, replaceText);
        }
    }
}
