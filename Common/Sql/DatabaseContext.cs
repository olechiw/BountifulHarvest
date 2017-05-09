using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Common
{
    [Database(Name = "BountifulHarvest")]
    public class BountifulHarvestContext : DataContext
    {
        public Table<Patron> Patrons;
        public Table<Visit> Visits;
        public BountifulHarvestContext(string connectionString) : base(connectionString) { }
    }
}