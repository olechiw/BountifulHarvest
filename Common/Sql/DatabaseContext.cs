using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

using Common;

namespace Common
{
    [DatabaseAttribute(Name ="BountifulHarvest")]
    public class BountifulHarvestContext : DataContext
    {
        public BountifulHarvestContext(string connectionString) : base(connectionString) { }

        public Table<Patron> Patrons;
        public Table<Visit> Visits;
    }
}
