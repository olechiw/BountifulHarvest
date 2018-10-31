using System;
using System.Linq;
using System.Windows.Forms;
using Common;
using VisitList = System.Linq.IQueryable<Common.Visit>;


//
// MoreInfoForm - A very simple form which displays information about a patron in a more comprehensive manner
//

namespace EntryApplication
{
    public partial class MoreInfoForm : DialogForm
    {
        // Simple constructor, set the values of each text field to the corresponding arguments. Then use the SqlConnection to fill in the blanks
        public MoreInfoForm(Patron p, VisitList visits)
        {
            InitializeComponent();

            // Load all of the labels
            nameLabel.Text += Constants.ConjuncName(p.FirstName, p.MiddleInitial, p.LastName);
            dateOfBirthLabel.Text += p.DateOfBirth.ToString(Constants.DateFormat);
            addressLabel.Text += p.Address;
            phoneNumberLabel.Text += p.PhoneNumber;
            firstVisitLabel.Text += p.DateOfInitialVisit.ToString("d");
            familyLabel.Text += p.Family;
            commentsLabel.Text += p.Comments;
            ageLabel.Text += DateTime.Today.Year - p.DateOfBirth.Year;

            foreach (var v in visits.OrderBy(v => v.DateOfVisit))
                addDataRow(p, v);


            if (visits.Any())
                initialVisitDate.Text += visits.OrderBy(v => v.DateOfVisit).First().DateOfVisit
                    .ToString(Constants.DateFormat);

            addFamilyRows(p);

            WindowState = FormWindowState.Maximized;
        }

        private void addDataRow(Patron p, Visit v)
        {
            outputDataView.Rows.Add(p.FirstName,
                p.MiddleInitial,
                p.LastName,
                v.TotalPounds,
                v.DateOfVisit.ToString(Constants.DateFormat),
                v.VisitID,
                v.PatronID);
        }

        private void addFamilyRows(Patron p)
        {
            var family = p.Family.Split(',');
            var familyDateOfBirths = p.FamilyDateOfBirths.Split(',');
            var familyGenders = p.FamilyGenders.Split(',');

            for (var i = 0; i < family.Length; ++i)
            {
                var age = "n/a";
                var gender = "";
                var dob = "";
                var name = family[i];

                try
                {
                    if (familyDateOfBirths.Length > i)
                    {
                        age = getAgeOf(familyDateOfBirths[i]);
                        dob = familyDateOfBirths[i];
                    }
                    if (familyGenders.Length > i)
                        gender = familyGenders[i];
                }
                catch (Exception e)
                {
                    Logger.Log(e.StackTrace);
                }
                familyDataView.Rows.Add(name, gender, age, dob);
            }
        }

        private string getAgeOf(string date)
        {
            var age = "n/a";
            try
            {
                var dateTime = Constants.SafeConvertDate(date);
                age = (DateTime.Today.Year - dateTime.Year).ToString();
            }
            catch (Exception e)
            {
                Logger.Log(e.StackTrace);
            }
            return age;
        }

        // When the close button is clicked, exit the window
        private void closeButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}