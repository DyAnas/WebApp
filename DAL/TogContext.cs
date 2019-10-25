using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace GruppeInnlevering1.DAL

{
    public class DbAdmin 
    {


        public string Fornavn { get; set; }
        public string EtterFornavn { get; set; }
        [Key]
        [Required(ErrorMessage = "Email er allereade registrert.")]

        public string Email { get; set; }
        public byte[] passord { get; set; }
        public string Salt { get; set; }

    }
    public class Avgang
    {
        public int AvgangId { get; set; }
        public TimeSpan Tid { get; set; }
        public virtual Tog Tog { get; set; }
        public virtual Stasjon Stasjon { get; set; }

    }

    public class Billett
    {    [Key]
        public int BilletId { get; set; }
        public string Type { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime DatoTur { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime? DatoRetur { get; set; }
        public int Pris { get; set; }
        public int AvgangFra { get; set; }
        public int AvgangTil { get; set; }
        public string Telefonnummer { get; set; }
        public string Email { get; set; }
        public string Kortnummer { get; set; }
        public int Cvc { get; set; }
        public string gyldig { get; set; }

    }
    public class Stasjon
    {

        public int StasjonId { get; set; }
        [Required]
        public string StasjonNavn { get; set; }
        public virtual List<Avgang> Avganger { get; set; }

    }
    public class Tog
    {
        public int TogId { get; set; }
        [Required]
        public string TogNavn { get; set; }
        public virtual List<Avgang> Avganger { get; set; }
    }
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
        public DbSet<Billett> Billeter { get; set; }
        public DbSet<Avgang> Avganger { get; set; }
        public DbSet<Tog> TogTabell { get; set; }
        public DbSet<DbAdmin> Admins { get; set; }



    }
}



     
