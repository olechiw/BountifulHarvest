using System;
using System.Data.Linq.Mapping;
using System.Reflection;

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

        [Column] public int Toddler;

        [Column] public bool Veteran;

        [Column] public bool VisitsEveryWeek;

        [Column] public int Young;


        public DateTime DateOfBirth
        {
            get => Constants.ConvertString2Date(_DateOfBirth);
            set => _DateOfBirth = value.ToString(Constants.DateFormat);
        }

        // Copy the class
        public static void Copy(Patron n, Patron o)
        {
            Type typeN = n.GetType();
            PropertyInfo[] N = typeN.GetProperties();

            Type typeO = o.GetType();
            PropertyInfo[] O = typeO.GetProperties();

            for (var i = 0; i < N.Length; ++i)
                N[i] = O[i];
        }

        // Update all of the calculated columns
        public void Calculate()
        {
            // Genders
            int males = 0, females = 0;
            foreach (string s in FamilyGenders.Split(','))
                if (s == "Male")
                    males++;
                else if (s == "Female")
                    females++;
            Males = males;
            Females = females;

            if (Gender == "Male")
                Males++;
            else if (Gender == "Female")
                Females++;


            // Age groups
            int t = 0, y = 0, m = 0, o = 0;

            foreach (string s in FamilyDateOfBirths.Split(','))
            {
                string[] d = s.Split('/');
                if (d.Length == 3)
                {
                    int year = Constants.SafeConvertInt(d[2]);
                    if (year == Constants.InvalidID)
                        continue;


                    int age = DateTime.Today.Year - year;
                    if (age <= 5)
                        t++;
                    else if (age <= 17)
                        y++;
                    else if (age <= 59)
                        m++;
                    else
                        o++;
                }
            }

            int Age = DateTime.Today.Year - DateOfBirth.Year;

            if (Age <= 5)
                t++;
            else if (Age <= 17)
                y++;
            else if (Age <= 59)
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