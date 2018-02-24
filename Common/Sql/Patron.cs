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

        [Column] public string MiddleInitial;

        [Column(IsPrimaryKey = true)] public int PatronId;

        [Column] public string PhoneNumber;

        [Column] public bool Senior;

        [Column] public bool Veteran;

        [Column] public bool VisitsEveryWeek;

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
    }
}