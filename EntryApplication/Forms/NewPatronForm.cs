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
        public readonly Patron newPatron = new Patron();
        public Patron GetResults() => newPatron;

        // A boolean used to see if the user actually saved the data
        private bool saved = false;
        public bool Saved() => saved;

        public bool Print() => printVisitCheckBox.Checked;

        public NewPatronForm()
        {
            InitializeComponent();

            InitializeComponentManual();
        }

        private void InitializeComponentManual()
        {
            System.Windows.Forms.Keys[] exceptionsDash = { System.Windows.Forms.Keys.OemMinus, System.Windows.Forms.Keys.Space };
            System.Windows.Forms.Keys[] exceptionsComma = { System.Windows.Forms.Keys.Oemcomma, System.Windows.Forms.Keys.Space };
            System.Windows.Forms.Keys[] exceptionsSpace = { System.Windows.Forms.Keys.Space };

            phoneNumberTextBox.Exceptions = exceptionsDash;
            addressTextBox1.Exceptions = exceptionsComma;
            addressTextBox2.Exceptions = exceptionsComma;

            patronFamilyGender.Items.Add("Male");
            patronFamilyGender.Items.Add("Female");

            genderComboBox.Items.Add("Male");
            genderComboBox.Items.Add("Female");
        }

        delegate string v(string otherValue);
        // An alternate constructor for editing patrons
        public NewPatronForm(Patron p)
        {
            // Standard init
            InitializeComponent();

            InitializeComponentManual();

            firstNameTextBox.Text = p.FirstName;
            lastNameTextBox.Text = p.LastName;
            middleInitialTextBox.Text = p.MiddleInitial;

            monthTextBox.Text = p.DateOfBirth.Month.ToString();
            dayTextBox.Text = p.DateOfBirth.Day.ToString();
            yearTextBox.Text = p.DateOfBirth.Year.ToString();

            if (p.Gender == "Male")
                genderComboBox.SelectedItem = genderComboBox.Items[0];
            else if (p.Gender == "Female")
                genderComboBox.SelectedItem = genderComboBox.Items[1];

            if (!string.IsNullOrEmpty(p.Address))
            {
                string[] address = p.Address.Split('\n');
                addressTextBox1.Text = address[0];
                if (address.Length > 1)
                    addressTextBox2.Text = address[1];
            }

            everyWeekCheckBox.Checked = (p.VisitsEveryWeek);

            phoneNumberTextBox.Text = p.PhoneNumber;

            InitializeFamily(p);

            newPatron = p;
        }

        private void InitializeFamily(Patron p)
        {
            // Load family
            if (!string.IsNullOrEmpty(p.Family) &&
                !string.IsNullOrEmpty(p.FamilyGenders) &&
                !string.IsNullOrEmpty(p.FamilyDateOfBirths))
            {
                string[] familyMembers = p.Family.Split(',');
                string[] familyGenders = p.FamilyGenders.Split(',');
                string[] dates = p.FamilyDateOfBirths.Split(',');

                for (int i = 0; i < familyMembers.Length; ++i)
                {
                    string name = "", gender = "", d = "", m = "", y = "";

                    if (string.IsNullOrEmpty(familyMembers[i]))
                        continue;

                    name = familyMembers[i];
                    gender = familyGenders[i];

                    string[] ds = dates[i].Split('/');
                    d = ds[0];
                    m = ds[1];
                    y = ds[2];

                    relativesDataView.Rows.Add(name, gender, d, m, y);
                }
            }

            // Fill a buffer of 10 empty spaces for user to add names into the family chart
            for (int i = 0; i < 10 - relativesDataView.Rows.Count; ++i)
                relativesDataView.Rows.Add();
        }

        // When the '+' button is clicked to add a row, add a row.
        private void addRowButtonClick(object sender, EventArgs e)
        {
            relativesDataView.Rows.Add();
        }

        private void ProcessFamily()
        {
            newPatron.Family = "";
            // Get all of the family members
            foreach (DataGridViewRow row in relativesDataView.Rows)
            {
                if (!(row.Cells[0] == null || row.Cells[0].Value == null || string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString())))
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
        private void submitButtonClick(object sender, EventArgs e)
        {
            // Fill the newPatron structure
            newPatron.FirstName = firstNameTextBox.Text.ToString();
            newPatron.LastName = lastNameTextBox.Text.ToString();
            newPatron.MiddleInitial = middleInitialTextBox.Text.ToString();


            int month = Common.Constants.SafeConvertInt(monthTextBox.Text.ToString());

            int day = Common.Constants.SafeConvertInt(dayTextBox.Text.ToString());

            int year = Common.Constants.SafeConvertInt(yearTextBox.Text.ToString());

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
            newPatron.DateOfLastVisit = DateTime.Today;

            newPatron.Gender = genderComboBox.Text.ToString();

            newPatron.Address = addressTextBox1.Text + "\n" + addressTextBox2.Text;

            newPatron.PhoneNumber = phoneNumberTextBox.Text;

            newPatron.VisitsEveryWeek = (everyWeekCheckBox.Checked);

            SaveFamily();

            saved = true;

            this.Close();
        }

        private void SaveFamily()
        {
            string family = "", familyGenders = "", familyDates = "";

            foreach (DataGridViewRow row in relativesDataView.Rows)
            {
                if (
                    !(row==null) &&
                    !(row.Cells==null) &&
                    !(row.Cells[0] == null) &&
                    !(row.Cells[0].Value == null) &&
                    !String.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    family += row.Cells[0].Value.ToString() + ',';

                    familyGenders += (row.Cells[1].Value == null) ?
                        " "
                        :
                        row.Cells[1].Value.ToString()

                        + ',';

                    string m = (row.Cells[2].Value == null) ? " " : row.Cells[2].Value.ToString();
                    string d = (row.Cells[3].Value == null) ? " " : row.Cells[3].Value.ToString();
                    string y = (row.Cells[4].Value == null) ? " " : row.Cells[4].Value.ToString();
                    if (!(string.IsNullOrEmpty(m) || string.IsNullOrEmpty(d) || string.IsNullOrEmpty(y)))
                        familyDates += m + '/' + d + '/' + y + ',';
                    else
                        familyDates += " ,";
                }
            }

            // remove the last value, a comma
            if (!String.IsNullOrEmpty(family))
                family = family.Substring(0, family.Length - 1);
            if (!String.IsNullOrEmpty(familyGenders))
                familyGenders = familyGenders.Substring(0, familyGenders.Length - 1);
            if (!String.IsNullOrEmpty(familyDates))
                familyDates = familyDates.Substring(0, familyDates.Length - 1);

            newPatron.Family = family;
            newPatron.FamilyGenders = familyGenders;
            newPatron.FamilyDateOfBirths = familyDates;

        }

        private void familyTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;

            // Account for letters and numbers
            if (Keys.A <= key && key <= Keys.Z)
                return;
            else if (Keys.D0 <= key && key <= Keys.D9)
                return;
            else if (Keys.NumPad0 <= key && key <= Keys.NumPad9)
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
