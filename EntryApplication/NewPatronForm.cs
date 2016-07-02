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

        public NewPatronForm()
        {
            InitializeComponent();


            // Create a combobox with options as to what type of relative the given person is. Add this to the columns
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Relation Type";
            combo.Name = "combo";
            combo.MaxDropDownItems = 4;
            combo.Items.Add("Parent/Guardian");
            combo.Items.Add("Child");
            combo.Items.Add("Spouse");
            relativesDataView.Columns.Add(combo);


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

            // Iterate through all of the dataview, and record each entry
            for (int i = 0; i < relativesDataView.Rows.Count; ++i)
            {
                // Get the person's name
                string relative = relativesDataView.Rows[i].Cells[0].ToString();

                // Get the person's relation
                string relativeType = relativesDataView.Rows[i].Cells[1].ToString();
                if (relativeType == "Parent/Guardian")
                    newPatron.guardians.Add(relative);
                else if (relativeType == "Child")
                    newPatron.children.Add(relative);
                else if (relativeType == "Spouse")
                    newPatron.spouse = relative;
            }

            // Get the person's date of birth, in sql string format
            newPatron.dateOfBirth = yearTextBox.Text.ToString() + '-' + monthTextBox.Text.ToString() + '-' + dayTextBox.Text.ToString();
        }
    }
}
