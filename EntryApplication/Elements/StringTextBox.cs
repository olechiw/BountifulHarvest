using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntryApplication
{
    public class StringTextBox : TextBox
    {
        // Constructor
        public StringTextBox()
        {
            this.KeyDown += textBoxKeyDown;
        }

        private void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;

            if ((key >= Keys.A) && (key <= Keys.Z))
                return;

            // Special exceptions (backspace)
            else if (key == Keys.Back)
                return;
            else
                e.SuppressKeyPress = true;
        }
    }
}
