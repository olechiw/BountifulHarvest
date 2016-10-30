using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public string DateOfLastVisit;
        [Column]
        public string DateOfBirth;
        [Column]
        public string Family;
        [Column]
        public string PhoneNumber;
        [Column]
        public string Address;
        [Column]
        public string DateOfInitialVisit;
    }
}
