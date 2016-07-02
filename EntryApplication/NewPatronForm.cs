using System;
using System.IO;
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
        Patron newPatron;

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

        private void addRowButtonClick(object sender, EventArgs e) => relativesDataView.Rows.Add();

        private void submitButtonClick(object sender, EventArgs e)
        {

        }
    }
}
