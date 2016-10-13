//
// Bountiful Harvest Alpha Version 1.0 - Jakob Olechiw, 10/12/2016
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
// StringTextBox - A special type of WindowsForms TextBox that only accepts latin characters
//

namespace EntryApplication
{
    public class StringTextBox : TextBox
    {
        // Constructor
        public StringTextBox()
        {
            this.KeyDown += textBoxKeyDown;
        }

        // Whenever a key is pressed, make sure it is valid
        private void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;

            // Latin characters are ok
            if ((key >= Keys.A) && (key <= Keys.Z))
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
