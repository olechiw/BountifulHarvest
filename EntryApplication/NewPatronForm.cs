using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace EntryApplication
{
    public partial class NewPatronForm : Form
    {
        Bitmap currentScreen;
        PrintDocument screenPrint = new PrintDocument();

        public NewPatronForm()
        {
            InitializeComponent();

            screenPrint.PrintPage += new PrintPageEventHandler(screenPrintPrintPage);
        }

        private void CaptureScreen()
        {
            
            currentScreen = new Bitmap(this.Size.Width, this.Size.Height, this.CreateGraphics());
            Graphics g = Graphics.FromImage(currentScreen);
            g.CopyFromScreen(this.Location.X, this.Location.Y, 10, 10, this.Size);
            
        }

        // When the screenPrint document is about to be printed
        private void screenPrintPrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(currentScreen, 0, 0);
        }

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
    }
}
