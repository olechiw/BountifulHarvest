﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common;

using VisitList = System.Linq.IQueryable<Common.Visit>;


//
// MoreInfoForm - A very simple form which displays information about a patron in a more comprehensive manner
//

namespace EntryApplication
{
    public partial class MoreInfoForm : Common.DialogForm
    {
        // Simple constructor, set the values of each text field to the corresponding arguments. Then use the SqlConnection to fill in the blanks
        public MoreInfoForm(Common.Patron p, VisitList visits)
        {
            InitializeComponent();

            // Load all of the labels
            nameLabel.Text += Common.Constants.ConjuncName(p.FirstName, p.MiddleInitial, p.LastName);
            dateOfBirthLabel.Text += p.DateOfBirth.ToString(Common.Constants.DateFormat);
            addressLabel.Text += p.Address;
            phoneNumberLabel.Text += p.PhoneNumber;
            firstVisitLabel.Text += p.DateOfInitialVisit.ToString("d");
            familyLabel.Text += p.Family;
            commentsLabel.Text += p.Comments;


            foreach (var v in visits.OrderBy(v => v.DateOfVisit))
                AddDataRow(p, v);


            if (visits.Count() > 0)
                initialVisitDate.Text += visits.OrderBy(v => v.DateOfVisit).First().DateOfVisit.ToString(Common.Constants.DateFormat);


            this.WindowState = FormWindowState.Maximized;
        }

        private void AddDataRow(Common.Patron p, Common.Visit v)
        {
            outputDataView.Rows.Add(p.FirstName,
                p.MiddleInitial,
                p.LastName,
                v.TotalPounds,
                v.DateOfVisit.ToString(Common.Constants.DateFormat),
                v.VisitID,
                v.PatronID);
        }

        // When the close button is clicked, exit the window
        private void closeButtonClick(object sender, EventArgs e) => this.Close();
    }
}
