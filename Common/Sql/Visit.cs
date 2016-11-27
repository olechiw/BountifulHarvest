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
        public string PatronName;
        [Column]
        public string TotalPounds;
        [Column]
        public string DateOfVisit;
        [Column]
        public string SizeOfFamily;
    }
}
