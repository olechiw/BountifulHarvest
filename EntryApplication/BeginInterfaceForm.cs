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
    public partial class BeginInterfaceForm : Form
    {
        private const string dateCode = "d";

        public BeginInterfaceForm()
        {
            InitializeComponent();

            // Manual initialization

            // Testing data
            addDataRow("Jakob", "Olechiw", "5/13/2016", 14);
            addDataRow("Claire", "Olechiw", "5/12/2016", 16);
            addDataRow("Theresa", "Olechiw", "5/12/2016", 50);
            addDataRow("Michael", "Olechiw", "5/13/2016", 50);

            // Setup the dataview
            outputDataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Show the date on the datemessage
            DateTime today = DateTime.Today;
            dateLabel.Text = "Today's Date is: " + today.ToString(dateCode);
        }

        private void BeginInterfaceForm_Load(object sender, EventArgs e)
        {

        }

        private void addDataRow(params object[] values)
        {
            this.outputDataView.Rows.Add(values);
        }

        private void searchBoxChanged(object sender, EventArgs e)
        {
            
        }

        private void searchBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                if (!String.IsNullOrEmpty(searchBox.Text))
                {
                    searchBox.SelectionStart = 0;
                    searchBox.SelectionLength = searchBox.Text.Length;
                }
            }
        }
    }
}
