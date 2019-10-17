using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

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
        public DbSet<DbAdmin> Admins{ get; set; }


        public List<StasjonV> alleStasjoner()
        {

            using (var db = new TogContext())
            {
                List<StasjonV> alleStasjoner = db.Stasjoner.Select(k => new StasjonV
                {
                  StasjonId=k.StasjonId,
                  StasjonNavn =k.StasjonNavn


                }).ToList();
                return alleStasjoner;
            }




        }



        public List<BilletV> alleBillter()
        {

            using (var db = new TogContext())
            {
                List<BilletV> alleBillter = db.Billeter.Select(k => new BilletV
                {
             AvgangFra =k.AvgangFra,
             AvgangTil =k.AvgangTil,
             BilletId=k.BilletId,
             Cvc=k.Cvc,
             DatoRetur=k.DatoRetur,
             DatoTur=k.DatoTur,
             Email=k.Email,
             Kortnummer=k.Kortnummer,
             Pris = k.Pris,
             Telefonnummer=k.Telefonnummer,
             Type =k.Type
             


                }).ToList();
                return alleBillter;
            }




        }

        public List<TogV> alleTog()
        {

            using (var db = new TogContext())
            {
                List<TogV> alleTog = db.TogTabell.Select(k => new TogV
                {
                 TogId=k.TogId,
                 TogNavn=k.TogNavn


                }).ToList();
                return alleTog;
            }




        }






        public List<avgangs> allavganger()
        {
            using (var db = new TogContext())
            {
                List<avgangs> alleavganger = db.Avganger.Select(k => new avgangs
                {
                    AvgangId = k.AvgangId,
                    Stasjon = k.Stasjon.StasjonId,
                    Tid = k.Tid,
                    Tog = k.Tog.TogId

                }).ToList();
                return alleavganger;
            }
        }

        public bool lagreAvganger(Avgang innAvgang)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var nyavgang = new Avgang();
                    nyavgang.Stasjon = innAvgang.Stasjon;
                    nyavgang.Tid = innAvgang.Tid;
                    nyavgang.Tog = nyavgang.Tog;

                    /*  var skjekkTog = db.TogTabell.Find(innAvgang.Tog);
                      if (skjekkTog == null)
                      {
                          var tog = new Tog();
                          tog.TogNavn=innAvgang.
                      }*/
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }

            }


        }

        public Avgang hentAvgang(int id)
        {
            using (var db = new TogContext())
            {
                Avgang enAvgang = db.Avganger.Find(id);
                var hentAvgang = new Avgang()
                {
                    AvgangId = enAvgang.AvgangId,
                    Stasjon = enAvgang.Stasjon,
                    Tid = enAvgang.Tid,
                    Tog = enAvgang.Tog

                };
                return hentAvgang;
            }
        }
        public bool endreAvgang(Avgang innAvgang)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var endretobjekt = db.Avganger.Find(innAvgang.AvgangId);
                    endretobjekt.Stasjon = innAvgang.Stasjon;
                    endretobjekt.Tid = endretobjekt.Tid;
                    endretobjekt.Tog = innAvgang.Tog;
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }
        }
        public bool SlettAvgan(int id)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var slettObjekt = db.Avganger.Find(id);
                    db.Avganger.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }



    }
}

