using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
// MoreInfoForm - A very simple form which displays information about a patron in a more comprehensive manner
//

namespace EntryApplication
{
    public partial class MoreInfoForm : Common.DialogForm
    {
        // Simple constructor, set the values of each text field to the corresponding arguments. Then use the SqlConnection to fill in the blanks
        public MoreInfoForm(Common.Patron p)
        {
            InitializeComponent();

            // Load all of the labels
            nameLabel.Text += Common.Constants.ConjuncName(p.FirstName, p.MiddleInitial, p.LastName);
            dateOfBirthLabel.Text += p.DateOfBirth;
            addressLabel.Text += p.Address;
            phoneNumberLabel.Text += p.PhoneNumber;
            lastVisitLabel.Text += p.DateOfLastVisit.ToString("d");
            firstVisitLabel.Text += p.DateOfInitialVisit.ToString("d");
            familyLabel.Text += p.Family;
            commentsLabel.Text += p.Comments;

            this.WindowState = FormWindowState.Maximized;
        }

        // When the close button is clicked, exit the window
        private void closeButtonClick(object sender, EventArgs e) => this.Close();
    }
}
