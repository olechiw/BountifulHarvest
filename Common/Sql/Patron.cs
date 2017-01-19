﻿using System;
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
        [Column(Name = "DateOfBirth")]
        public string _DateOfBirth;
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
        [Column]
        public bool VisitsEveryWeek;
        [Column(IsPrimaryKey = true)]
        public int PatronID;
        [Column]
        public int Males;
        [Column]
        public int Females;
        [Column]
        public int Young;
        [Column]
        public int Medium;
        [Column]
        public int Old;


        public DateTime DateOfBirth
        {
            get
            {
                return Constants.ConvertString2Date(_DateOfBirth);
            }
            set
            {
                _DateOfBirth = value.ToString(Constants.DateFormat);
            }
        }

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

        // Update all of the calculated columns
        public void Calculate()
        {

            // Genders
            int males = 0, females = 0;
            foreach (var s in FamilyGenders.Split(','))
            {
                if (s == "Male")
                    males++;
                else if (s == "Female")
                    females++;
            }
            Males = males;
            Females = females;

            if (Gender == "Male")
                Males++;
            else if (Gender == "Female")
                Females++;


            // Age groups
            int y = 0, m = 0, o = 0;

            foreach (var s in FamilyDateOfBirths.Split(','))
            {

                var d = s.Split('/');
                if (d.Length==3)
                {
                    int age = DateTime.Today.Year - Constants.SafeConvertInt(d[2].ToString());
                    if (age <= 17)
                        y++;
                    else if (age <= 59)
                        m++;
                    else
                        o++;
                }
            }

            int Age = DateTime.Today.Year - DateOfBirth.Year;

            if (Age <= 17)
                y++;
            else if (Age <= 59)
                m++;
            else
                o++;

            Old = o;
            Medium = m;
            Young = y;
        }
    }
}
