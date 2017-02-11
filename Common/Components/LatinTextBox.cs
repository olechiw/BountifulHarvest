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
    public class SafeTextBox : TextBox
    {
        public Keys[] Exceptions = {
                Keys.OemMinus,
                Keys.Space,
                Keys.Subtract,
                Keys.Oemcomma,
                Keys.OemPeriod,
                Keys.Decimal,
            Keys.Divide,
            Keys.OemBackslash};

        // Constructor
        public SafeTextBox(Keys[] specialExceptions)
        {
            this.KeyDown += textBoxKeyDown;
            Exceptions = specialExceptions;
        }

        public SafeTextBox()
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

            // Account for numbers only
            else if (Keys.D0 <= key && key <= Keys.D9)
                return;
            else if (Keys.NumPad0 <= key && key <= Keys.NumPad9)
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
