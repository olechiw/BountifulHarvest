using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
// LatinTextBox- A special type of WindowsForms TextBox that only accepts latin characters
//

namespace Common
{
    public class LatinTextBox : TextBox
    {
        public Keys[] Exceptions = { };

        // Constructor
        public LatinTextBox(Keys[] specialExceptions)
        {
            this.KeyDown += textBoxKeyDown;
            Exceptions = specialExceptions;
        }

        public LatinTextBox()
        {
            this.KeyDown += textBoxKeyDown;
        }

        // Whenever a key is pressed, make sure it is valid
        public void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;

            // Account for letters and numbers
            if (Keys.A <= key && key <= Keys.Z)
                return;
            else if (Keys.D0 <= key && key <= Keys.D9)
                return;

            // Special exceptions (backspace hardcoded) are ok
            else if (key == Keys.Back)
                return;

            foreach (Keys k in Exceptions)
                if (key == k)
                    return;

            e.SuppressKeyPress = true;
        }
    }
}
