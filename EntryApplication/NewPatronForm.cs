using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Packaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;

namespace EntryApplication
{
    public partial class NewPatronForm : System.Windows.Forms.Form
    {
        private Patron newPatron = new Patron();
        public Patron GetData() => newPatron;

        // A boolean used to see if the user actually saved the data
        private bool saved = false;
        public bool Saved() => saved;

        public NewPatronForm()
        {
            InitializeComponent();


            // Fill a buffer of empty spaces for user to add names
            for (int i = 0; i < 10; ++i)
                relativesDataView.Rows.Add();
        }

        // An alternate constructor for editing patrons
        public NewPatronForm(string firstName, string lastName, string middleInitial, string gender, string dateOfBirth, string family, string address, string phoneNumber, string comments)
        {
            // Standard init
            InitializeComponent();

            firstNameTextBox.Text = firstName;
            lastNameTextBox.Text = lastName;
            middleInitialTextBox.Text = middleInitial;

            // Load the date of birth
            if (dateOfBirth != "")
            {
                string[] date = dateOfBirth.Split('-');
                yearTextBox.Text = date[0];
                monthTextBox.Text = date[1];
                dayTextBox.Text = date[2];
            }
            
            // Load family
            if (family != "")
            {
                string[] familyMembers = family.Split(',');

                foreach (string member in familyMembers)
                    relativesDataView.Rows.Add(member);
            }

            // Fill a buffer of empty spaces for user to add names
            for (int i = 0; i < 10; ++i)
                relativesDataView.Rows.Add();
        }

        // When the '+' button is clicked to add a row, add a row.
        private void addRowButtonClick(object sender, EventArgs e) => relativesDataView.Rows.Add();

        // Record all of the data, and close the window
        private void submitButtonClick(object sender, EventArgs e)
        {
            // Fill the newPatron structure
            newPatron.firstName = firstNameTextBox.Text.ToString();
            newPatron.lastName = lastNameTextBox.Text.ToString();
            newPatron.middleInitial = middleInitialTextBox.Text.ToString();

           newPatron.family = "";
            // Get all of the family members
            foreach (DataGridViewRow row in relativesDataView.Rows)
                if (row.Cells[0]!=null && row.Cells[0].Value!=null)
                    newPatron.family += row.Cells[0].Value.ToString();

            // Get the person's date of birth, in sql string format
            newPatron.dateOfBirth = yearTextBox.Text.ToString() + '-' + monthTextBox.Text.ToString() + '-' + dayTextBox.Text.ToString();

            // If the user failed to enter a date, make it NULL
            if ((yearTextBox.Text.ToString() == "") || (monthTextBox.Text.ToString() == "") || (dayTextBox.Text.ToString() == ""))
                newPatron.dateOfBirth = "";

            saved = true;

            this.Close();
        }
    }
}
