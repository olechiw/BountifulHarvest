//
// Bountiful Harvest Alpha Version 1.0 - Jakob Olechiw, 10/12/2016
//
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

using Common;

//
// NewPatronForm - A form responsible for the editing of existing patron data, and creating new ones. Does not actually access SQL
//

namespace EntryApplication
{
    public partial class NewPatronForm : Common.DialogForm
    {
        private Patron newPatron = new Patron();
        public Patron GetResults() => newPatron;

        // A boolean used to see if the user actually saved the data
        private bool saved = false;
        public bool Saved() => saved;

        public NewPatronForm()
        {
            InitializeComponent();


            // Fill a buffer of 10 empty spaces for user to add names
            for (int i = 0; i < 10; ++i)
                relativesDataView.Rows.Add();
        }

        // An alternate constructor for editing patrons
        public NewPatronForm(Patron p)
        {
            // Standard init
            InitializeComponent();

            firstNameTextBox.Text = p.FirstName;
            lastNameTextBox.Text = p.LastName;
            middleInitialTextBox.Text = p.MiddleInitial;

            monthTextBox.Text = p.DateOfBirth.Month.ToString();
            dayTextBox.Text = p.DateOfBirth.Day.ToString();
            yearTextBox.Text = p.DateOfBirth.Year.ToString();
            
            // Load family
            if (p.Family != "")
            {
                string[] familyMembers = p.Family.Split(',');

                foreach (string member in familyMembers)
                    relativesDataView.Rows.Add(member);
            }

            // Fill a buffer of empty spaces for user to add names
            for (int i = 0; i < 10; ++i)
                addRowButtonClick(null, null);

            Patron.Copy(newPatron, p);
        }

        // When the '+' button is clicked to add a row, add a row.
        private void addRowButtonClick(object sender, EventArgs e)
        {
            //int count = relativesDataView.Rows.Count;
            relativesDataView.Rows.Add();
            //relativesDataView.Rows[count].Cells[0].
        }

        // Record all of the data, and close the window
        private void submitButtonClick(object sender, EventArgs e)
        {
            // Fill the newPatron structure
            newPatron.FirstName = firstNameTextBox.Text.ToString();
            newPatron.LastName = lastNameTextBox.Text.ToString();
            newPatron.MiddleInitial = middleInitialTextBox.Text.ToString();

           newPatron.Family = "";
            // Get all of the family members
            foreach (DataGridViewRow row in relativesDataView.Rows)
                if (!(row.Cells[0]==null || row.Cells[0].Value == null || string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString())))
                {
                    newPatron.Family += row.Cells[0].Value.ToString();
                    newPatron.Family += ',';
                }


            int month = Common.Constants.SafeConvertInt(monthTextBox.Text.ToString());

            int day = Common.Constants.SafeConvertInt(dayTextBox.Text.ToString());

            int year = Common.Constants.SafeConvertInt(yearTextBox.Text.ToString());

            newPatron.DateOfBirth = new DateTime();


            if (!(year == 0 || day == 0 || month == 0))
                newPatron.DateOfBirth = new DateTime(year, month, day);

            newPatron.DateOfInitialVisit = DateTime.Today;
            newPatron.DateOfLastVisit = DateTime.Today;

            newPatron.Gender = genderTextBox.Text.ToString();

            saved = true;

            this.Close();
        }

        private void familyTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;

            // Account for letters and numbers
            if (Keys.A <= key && key <= Keys.Z)
                return;
            else if (Keys.D0 <= key && key <= Keys.D9)
                return;

            // Special exceptions (backspace + space) are ok
            else if (key == Keys.Back)
                return;
            else if (key == Keys.Space)
                return;

            // Otherwise, nothing will happen
            else
                e.SuppressKeyPress = true;
        }

        private void relativesDataViewEditing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyDown += familyTextBoxKeyDown;
        }
    }
}
