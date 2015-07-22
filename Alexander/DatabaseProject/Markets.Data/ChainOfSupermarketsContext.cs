using Markets.Data.Migrations;

namespace Markets.Data
{
    using Markets.Model;
    using System.Data.Entity;

    public class ChainOfSupermarketsContext : DbContext
    {
        public ChainOfSupermarketsContext()
            : base("name=ChainOfSupermarketsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChainOfSupermarketsContext, Configuration>());
        }

        public IDbSet<Vendor> Vendors { get; set; }
        public IDbSet<Measure> Measures { get; set; }
        public IDbSet<Product> Products { get; set; }
    }
}