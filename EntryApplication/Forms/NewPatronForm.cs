﻿using System;
using System.Windows.Forms;
using Common;

/*
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Packaging;
using System.Drawing.Printing;
*/
// using System.Drawing;

//
// NewPatronForm - A form responsible for the editing of existing patron data, and creating new ones. Does not actually access SQL
//

namespace EntryApplication
{
    public partial class NewPatronForm : DialogForm
    {
        private readonly Patron newPatron = new Patron();

        // A boolean used to see if the user actually saved the data
        private bool saved;

        public NewPatronForm()
        {
            Logger.Log("Creating new patron form");
            InitializeComponent();

            InitializeComponentManual();
        }

        // An alternate constructor for editing patrons
        public NewPatronForm(Patron p)
        {
            Logger.Log("Creating new patron form");

            // Standard init
            InitializeComponent();

            InitializeComponentManual();

            firstNameTextBox.KeyDown += FamilyTextBoxKeyDown;
            lastNameTextBox.KeyDown += FamilyTextBoxKeyDown;
            middleInitialTextBox.KeyDown += FamilyTextBoxKeyDown;

            // Load the existing patron information into the form.
            firstNameTextBox.Text = p.FirstName;
            lastNameTextBox.Text = p.LastName;
            middleInitialTextBox.Text = p.MiddleInitial;


            monthTextBox.Text = p.DateOfBirth.Month.ToString();
            dayTextBox.Text = p.DateOfBirth.Day.ToString();
            yearTextBox.Text = p.DateOfBirth.Year.ToString();

            veteranCheckBox.Checked = p.Veteran;
            seniorCheckBox.Checked = p.Senior;


            switch (p.Gender)
            {
                case "Male":
                    genderComboBox.SelectedItem = genderComboBox.Items[0];
                    break;
                case "Female":
                    genderComboBox.SelectedItem = genderComboBox.Items[1];
                    break;
                default:
                    genderComboBox.SelectedItem = genderComboBox.Items[0];
                    break;
            }


            if (!string.IsNullOrEmpty(p.Address))
            {
                var address = p.Address.Split('\n');
                addressTextBox1.Text = address[0];
                if (address.Length > 1)
                    addressTextBox2.Text = address[1];
            }

            everyWeekCheckBox.Checked = p.VisitsEveryWeek;

            phoneNumberTextBox.Text = p.PhoneNumber;

            commentsRichTextBox.Text = p.Comments;

            zipCodeUpDown.Value = p.ZipCode;

            InitializeFamily(p);

            newPatron = p;
        }

        public Patron GetResults()
        {
            return newPatron;
        }

        public bool Saved()
        {
            return saved;
        }

        public bool Print()
        {
            return printVisitCheckBox.Checked;
        }

        private void InitializeComponentManual()
        {
            // Do the manual combobox updating
            patronFamilyGender.Items.Add("Male");
            patronFamilyGender.Items.Add("Female");

            genderComboBox.Items.Add("Male");
            genderComboBox.Items.Add("Female");
        }

        private void InitializeFamily(Patron p)
        {
            // Load family into the datagridview. Messy but it works.
            if (!string.IsNullOrEmpty(p.Family))
            {
                var familyMembers = p.Family.Split(',');
                var familyGenders = p.FamilyGenders.Split(',');
                var dates = p.FamilyDateOfBirths.Split(',');

                for (var i = 0; i < familyMembers.Length; ++i)
                {
                    string name = "", gender = "", d = "", m = "", y = "";

                    if (string.IsNullOrEmpty(familyMembers[i]))
                        continue;

                    try
                    {
                        name = familyMembers[i];
                    }
                    catch (Exception)
                    {
                        name = "";
                    }
                    try
                    {
                        gender = familyGenders[i];
                    }
                    catch (Exception)
                    {
                        gender = "";
                    }

                    var ds = dates[i].Split('/');
                    d = ds[0];
                    m = ds[1];
                    y = ds[2];

                    relativesDataView.Rows.Add(name, gender, d, m, y);
                }
            }

            // Fill a buffer of 10 empty spaces for user to add names into the family chart
            for (var i = 0; i < 10 - relativesDataView.Rows.Count; ++i)
                relativesDataView.Rows.Add();
        }

        // When the '+' button is clicked to add a row, add a row.
        private void AddRowButtonClick(object sender, EventArgs e)
        {
            relativesDataView.Rows.Add();
        }

        private void ProcessFamily()
        {
            newPatron.Family = "";
            // Get all of the family members
            foreach (DataGridViewRow row in relativesDataView.Rows)
                if (row.Cells[0]?.Value != null && !string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                {
                    newPatron.Family += row.Cells[0].Value.ToString();
                    newPatron.Family += ',';

                    newPatron.FamilyGenders += row.Cells[1].Value.ToString();
                    newPatron.FamilyGenders += ',';

                    newPatron.FamilyDateOfBirths += Constants.ConjuncDate(
                        row.Cells[2].Value.ToString(),
                        row.Cells[3].Value.ToString(),
                        row.Cells[4].Value.ToString());
                }

            // Cut off the last character, a floating comma. But lets not have it be -1
            if (newPatron.Family.Length != 0)
                newPatron.Family = newPatron.Family.Substring(0, newPatron.Family.Length - 1);

            if (newPatron.FamilyGenders.Length != 0)
                newPatron.FamilyGenders = newPatron.FamilyGenders.Substring(0, newPatron.FamilyGenders.Length - 1);

            if (newPatron.FamilyDateOfBirths.Length != 0)
                newPatron.FamilyGenders = newPatron.FamilyGenders.Substring(0, newPatron.FamilyGenders.Length - 1);
        }

        // Record all of the data, and close the window
        private void SubmitButtonClick(object sender, EventArgs e)
        {
            // Fill the newPatron structure
            newPatron.FirstName = firstNameTextBox.Text;
            newPatron.LastName = lastNameTextBox.Text;
            newPatron.MiddleInitial = middleInitialTextBox.Text;


            var month = Constants.SafeConvertInt(monthTextBox.Text);

            var day = Constants.SafeConvertInt(dayTextBox.Text);

            var year = Constants.SafeConvertInt(yearTextBox.Text);

            newPatron.DateOfBirth = new DateTime();


            if (!(year == 0 || day == 0 || month == 0))
                try
                {
                    newPatron.DateOfBirth = new DateTime(year, month, day);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Date of Birth Entered.");
                    return;
                }

            newPatron.DateOfInitialVisit = DateTime.Today;

            newPatron.Gender = genderComboBox.Text;

            newPatron.Address = addressTextBox1.Text + "\n" + addressTextBox2.Text;

            newPatron.PhoneNumber = phoneNumberTextBox.Text;

            newPatron.VisitsEveryWeek = everyWeekCheckBox.Checked;
            newPatron.Veteran = veteranCheckBox.Checked;
            newPatron.Senior = seniorCheckBox.Checked;

            newPatron.Comments = commentsRichTextBox.Text;

            var zip = Convert.ToInt32(zipCodeUpDown.Value);
            if (zip == 0)
            {
                MessageBox.Show("Please enter a Zip Code");
                return;
            }
            newPatron.ZipCode = zip;

            SaveFamily();

            saved = true;

            Close();
        }

        private void SaveFamily()
        {
            // Load the information from the UI about the family. Also messy.
            string family = "", familyGenders = "", familyDates = "";

            foreach (DataGridViewRow row in relativesDataView.Rows)
                if (
                    !string.IsNullOrEmpty(row?.Cells?[0]?.Value?.ToString()))
                {
                    family += row.Cells[0].Value.ToString() + ',';

                    familyGenders += row.Cells[1].Value == null
                        ? " "
                        : row.Cells[1].Value.ToString()
                          + ',';

                    // Load the dob information. I promise it works??? :(
                    var m = row.Cells[2].Value?.ToString() ?? " ";
                    var d = row.Cells[3].Value?.ToString() ?? " ";
                    var y = row.Cells[4].Value?.ToString() ?? " ";
                    if (!(string.IsNullOrEmpty(m) || string.IsNullOrEmpty(d) || string.IsNullOrEmpty(y)))
                        familyDates += m + '/' + d + '/' + y + ',';
                    else
                        familyDates += " ,";
                }

            // remove the last value, a comma
            if (!string.IsNullOrEmpty(family))
                family = family.Substring(0, family.Length - 1);
            if (!string.IsNullOrEmpty(familyGenders))
                familyGenders = familyGenders.Substring(0, familyGenders.Length - 1);
            if (!string.IsNullOrEmpty(familyDates))
                familyDates = familyDates.Substring(0, familyDates.Length - 1);

            newPatron.Family = family;
            newPatron.FamilyGenders = familyGenders;
            newPatron.FamilyDateOfBirths = familyDates;
        }

        private void FamilyTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            // Locks out input so that you cant hit random shit in the family text box.
            var key = e.KeyCode;

            // Account for letters and numbers
            if (Keys.A <= key && key <= Keys.Z)
                return;
            if (Keys.D0 <= key && key <= Keys.D9)
                return;
            if (Keys.NumPad0 <= key && key <= Keys.NumPad9)
                return;

            // Special exceptions (backspace + space) are ok
            switch (key)
            {
                case Keys.Back:
                case Keys.Space:
                case Keys.OemPeriod:
                case Keys.Decimal:
                    return;
                default:
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
            }
        }

        private void RelativesDataViewEditing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Have to do this for every control, so its inside the datagridview editing handler.
            e.Control.KeyDown += FamilyTextBoxKeyDown;
        }

        private void nameKeyPress(object sender, KeyPressEventArgs e)
        {
            // Locks out input so that you cant hit random shit in the family text box.
            var key = e.KeyChar;

            if (char.IsLetter(key)) return;
            if (char.IsNumber(key)) return;

            // Special exceptions (backspace + space) are ok
            switch (key)
            {
                case (char) Keys.Back:
                case (char) Keys.Left:
                case (char) Keys.Right:
                case (char) Keys.Up:
                case (char) Keys.Down:
                case (char) Keys.Space:
                case (char) Keys.OemPeriod:
                case (char) Keys.ControlKey:
                case (char) Keys.Decimal:
                case '.':
                    return;
                default:
                    e.Handled = true;
                    break;
            }
        }
    }
}