using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Common
{
    [Database(Name = "BountifulHarvest")]
    public class BountifulHarvestContext : DataContext
    {
        // ReSharper disable once UnassignedField.Global
        public Table<Patron> Patrons;

        // ReSharper disable once UnassignedField.Global
        public Table<Visit> Visits;

        public BountifulHarvestContext(string connectionString) : base(connectionString)
        {
            Logger.Log("Connecting to database: " + connectionString);
        }
    }
}