using ProjectAO_Wagenpark.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectAO_Wagenpark.DataAccesLayer
{
    public class WagenparkContext : DbContext
    {
        public WagenparkContext() : base ("WagenparkContext")
        {

        }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Onderhoud> Onderhouds { get; set; }
        public DbSet<Werkplaats> Werkplaats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}