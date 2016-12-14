using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
// StringTextBox - A special type of WindowsForms TextBox that only accepts latin characters
//

namespace Common
{
    public class StringTextBox : TextBox
    {
        // Constructor
        public StringTextBox()
        {
            this.KeyDown += textBoxKeyDown;
        }

        // Whenever a key is pressed, make sure it is valid
        public void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;

            // Account for letters and numbers
            if (char.IsLetterOrDigit((char)key))
                return;

            // Special exceptions (backspace) are ok
            else if (key == Keys.Back)
                return;

            // Otherwise, nothing will happen
            else
                e.SuppressKeyPress = true;
        }
    }
}
