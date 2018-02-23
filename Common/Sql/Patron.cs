using System;
using System.Data.Linq.Mapping;

namespace Common
{
    [Table(Name = "Patrons")]
    public class Patron
    {
        [Column(Name = "DateOfBirth")] public string _DateOfBirth;

        [Column] public string Address;

        [Column] public string Comments;

        [Column] public DateTime DateOfInitialVisit;

        [Column] public string Family;

        [Column] public string FamilyDateOfBirths;

        [Column] public string FamilyGenders;

        [Column] public int Females;

        [Column] public string FirstName;

        [Column] public string Gender;

        [Column] public string LastName;

        [Column] public int Males;

        [Column] public int Medium;

        [Column] public string MiddleInitial;

        [Column] public int Old;

        [Column(IsPrimaryKey = true)] public int PatronId;

        [Column] public string PhoneNumber;

        [Column] public bool Senior;

        [Column] public int Toddler;

        [Column] public bool Veteran;

        [Column] public bool VisitsEveryWeek;

        [Column] public int Young;

        [Column] public int ZipCode;


        public DateTime DateOfBirth
        {
            get => Constants.ConvertString2Date(_DateOfBirth);
            set => _DateOfBirth = value.ToString(Constants.DateFormat);
        }

        // Copy the class
        public static void Copy(Patron n, Patron o)
        {
            var typeN = n.GetType();
            var N = typeN.GetProperties();

            var typeO = o.GetType();
            var O = typeO.GetProperties();

            for (var i = 0; i < N.Length; ++i)
                N[i] = O[i];
        }

        // Update all of the calculated columns
        public void Calculate()
        {
            // Genders
            int males = 0, females = 0;
            foreach (var s in FamilyGenders.Split(','))
                switch (s)
                {
                    case "Male":
                        males++;
                        break;
                    case "Female":
                        females++;
                        break;
                }
            Males = males;
            Females = females;

            if (Gender == "Male")
                Males++;
            else if (Gender == "Female")
                Females++;


            // Age groups
            int t = 0, y = 0, m = 0, o = 0;

            // Family ages
            foreach (var s in FamilyDateOfBirths.Split(','))
            {
                var dateTime = Constants.SafeConvertDate(s);

                var age = DateTime.Today.Year - dateTime.Year;
                if (age <= 5)
                    t++;
                else if (age <= 18)
                    y++;
                else if (age <= 59)
                    m++;
                else
                    o++;
            }

            var patronAge = DateTime.Today.Year - DateOfBirth.Year;

            if (patronAge <= 5)
                t++;
            else if (patronAge <= 17)
                y++;
            else if (patronAge <= 59)
                m++;
            else
                o++;

            Toddler = t;
            Old = o;
            Medium = m;
            Young = y;
        }
    }
}