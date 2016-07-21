using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntryApplication
{
    public partial class MorePatronInfoForm : Form
    {
        // Simple constructor, set the values of each text field to the corresponding arguments. Then use the SqlConnection to fill in the blanks
        public MorePatronInfoForm()
        {
            InitializeComponent();
        }

        // When the close button is clicked, exit the window
        private void closeButtonClick(object sender, EventArgs e) => this.Close();
    }
}
