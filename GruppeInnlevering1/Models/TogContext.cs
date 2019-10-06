using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GruppeInnlevering1.Models
{
    public class TogContext : DbContext
    {
        public TogContext() : base("name=ModelContext")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new TogInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Stasjon> Stasjoner { get; set; }

        public DbSet<Billet> Billeter { get; set; }

        public DbSet<Avgang> Avganger { get; set; }


        public DbSet<Tog> TogTabell { get; set; }





    }
}