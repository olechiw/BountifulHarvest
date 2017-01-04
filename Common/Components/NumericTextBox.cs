using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class NumericTextBox : TextBox
    {
        public Keys[] Exceptions = { };

        // Constructor
        public NumericTextBox(Keys[] specialExceptions)
        {
            this.KeyDown += textBoxKeyDown;
            Exceptions = specialExceptions;
        }

        public NumericTextBox()
        {
            this.KeyDown += textBoxKeyDown;
        }

        // Whenever a key is pressed, make sure it is valid
        public void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;

            // Account for numbers only
            if (Keys.D0 <= key && key <= Keys.D9)
                return;
            else if (Keys.NumPad0 <= key && key <= Keys.NumPad9)
                return;

            // Special exceptions (backspace) are ok
            else if (key == Keys.Back)
                return;


            foreach (Keys k in Exceptions)
                if (key == k)
                    return;

            e.SuppressKeyPress = true;
        }
    }
}
