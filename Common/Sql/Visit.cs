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
        public int TotalPounds;
        [Column]
        public DateTime DateOfVisit;
        [Column]
        public int PatronID;
        [Column]
        public bool Thanksgiving;
        [Column]
        public bool Christmas;
        [Column]
        public bool Winter;
        [Column]
        public bool Halloween;
        [Column]
        public bool School;
        [Column]
        public bool Easter;
        [Column(IsPrimaryKey =true)]
        public int VisitID;
    }
}
