using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Common
{
    [Table(Name = "Patrons")]
    public class Patron
    {
        [Column]
        public string FirstName;
        [Column]
        public string MiddleInitial;
        [Column]
        public string LastName;
        [Column]
        public string Gender;
        [Column]
        public DateTime DateOfLastVisit;
        [Column]
        public DateTime DateOfBirth;
        [Column]
        public string Family;
        [Column]
        public string FamilyGenders;
        [Column]
        public string FamilyDateOfBirths;
        [Column]
        public string PhoneNumber;
        [Column]
        public string Address;
        [Column]
        public string Comments;
        [Column]
        public DateTime DateOfInitialVisit;
        [Column(IsPrimaryKey = true)]
        public int PatronID;


        // Copy the class
        public static void Copy(Patron n, Patron o)
        {
            Type typeN = n.GetType();
            PropertyInfo[] N = typeN.GetProperties();

            Type typeO = o.GetType();
            PropertyInfo[] O = typeO.GetProperties();

            for (int i = 0; i < N.Length; ++i)
                N[i] = O[i];

            /*
            n.FirstName = o.FirstName;
            n.MiddleInitial = o.MiddleInitial;
            n.LastName = o.LastName;
            n.Gender = o.Gender;
            n.DateOfLastVisit = o.DateOfLastVisit;
            n.DateOfBirth = o.DateOfBirth;
            n.Family = o.Family;
            n.PhoneNumber = o.PhoneNumber;
            n.Address = o.Address;
            n.Comments = o.Comments;
            n.DateOfInitialVisit = o.DateOfInitialVisit;
            */
        }
    }
}
