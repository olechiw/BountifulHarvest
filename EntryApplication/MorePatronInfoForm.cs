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
    public partial class MoreInfoForm : Form
    {
        // Simple constructor, set the values of each text field to the corresponding arguments. Then use the SqlConnection to fill in the blanks
        public MoreInfoForm(string name, string dateOfBirth, string address, string phoneNumber, string lastVisit, string firstVisit, string family, string comments)
        {
            InitializeComponent();

            // Load all of the labels
            nameLabel.Text += name;
            dateOfBirthLabel.Text += dateOfBirth;
            addressLabel.Text += address;
            phoneNumberLabel.Text += address;
            lastVisitLabel.Text += lastVisit;
            firstVisitLabel.Text += firstVisit;
            familyLabel.Text += family;
            commentsLabel.Text += comments;
        }

        // When the close button is clicked, exit the window
        private void closeButtonClick(object sender, EventArgs e) => this.Close();
    }
}
