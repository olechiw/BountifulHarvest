using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Table(Name ="Visits")]
    public class Visit
    {
        [Column]
        public string PatronFirstName;
        [Column]
        public string PatronMiddleInitial;
        [Column]
        public string PatronLastName;
        [Column]
        public int TotalPounds;
        [Column]
        public DateTime DateOfVisit;
        [Column]
        public int SizeOfFamily;
        [Column(IsPrimaryKey =true)]
        public int VisitID;
    }
}
