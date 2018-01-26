using System.Windows.Forms;

//
// LatinTextBox- A special type of WindowsForms TextBox that only accepts latin characters
//

namespace Common
{
    public class SafeTextBox : TextBox
    {
        public Keys[] Exceptions =
        {
            Keys.OemMinus,
            Keys.Space,
            Keys.Subtract,
            Keys.Oemcomma,
            Keys.OemPeriod,
            Keys.Decimal,
            Keys.Divide,
            Keys.OemBackslash
        };

        // Constructor
        public SafeTextBox(Keys[] specialExceptions)
        {
            KeyDown += textBoxKeyDown;
            Exceptions = specialExceptions;
        }

        public SafeTextBox()
        {
            KeyDown += textBoxKeyDown;
        }

        // Whenever a key is pressed, make sure it is valid
        public void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;

            // Account for letters and numbers
            if (Keys.A <= key && key <= Keys.Z)
                return;
            if (Keys.D0 <= key && key <= Keys.D9)
                return;

            // Account for numbers only
            if (Keys.D0 <= key && key <= Keys.D9)
                return;
            if (Keys.NumPad0 <= key && key <= Keys.NumPad9)
                return;

            // Special exceptions (backspace hardcoded) are ok
            if (key == Keys.Back)
                return;

            foreach (var k in Exceptions)
                if (key == k)
                    return;

            e.SuppressKeyPress = true;
        }
    }
}