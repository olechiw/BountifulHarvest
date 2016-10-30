using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

//
// DialogForm - A simple 
//

namespace Common
{
    public class DialogForm : Form
    {
        // Constants for window size, may need to be tweaked
        const int windowWidth = 1920;
        const int windowHeight = 1280;

        public DialogForm()
        {
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // This is currently broken:
            //this.MaximumSize = new Size(windowWidth, windowHeight);
            //this.MinimumSize = new Size(windowWidth, windowHeight);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}
