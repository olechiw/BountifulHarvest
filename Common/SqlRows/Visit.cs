using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Common.Sql
{
    [Table(Name ="Visits")]
    class Visit
    {
        [Column]
        public string PatronName;
        [Column]
        public string TotalPounds;
        [Column]
        public string DateOfVisit;
        [Column]
        public string SizeOfFamily;
    }
}
