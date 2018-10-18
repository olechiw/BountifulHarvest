using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;

namespace EntryApplication.Forms
{
    public partial class DuplicateForm : Form
    {
        public DuplicateForm(IEnumerable<Patron> duplicatePatrons)
        {
            InitializeComponent();

            foreach (var p in duplicatePatrons)
                duplicatesDataGridView.Rows.Add(Constants.ConjuncName(p.FirstName, p.MiddleInitial, p.LastName),
                    p.Family);
        }

        public bool Cancel { get; private set; }

        private void allowButtonClick(object sender, EventArgs e)
        {
            Cancel = false;
            Close();
        }

        private void cancelButtonClick(object sender, EventArgs e)
        {
            Cancel = true;
            Close();
        }
    }
}