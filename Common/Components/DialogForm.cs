using System.Windows.Forms;

//
// DialogForm - A simple 
//

namespace Common
{
    public class DialogForm : Form
    {
        // Constants for window size, may need to be tweaked
        private const int WindowWidth = 1920;

        private const int WindowHeight = 1280;

        public DialogForm()
        {
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            MinimizeBox = false;
            // This is currently broken:
            //this.MaximumSize = new Size(windowWidth, windowHeight);
            //this.MinimumSize = new Size(windowWidth, windowHeight);
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}