using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
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





        //Stasjoner metoder

        public List<avgangs> allavganger()
        {
            using (var db = new TogContext())
            {
                List<avgangs> alleavganger = db.Avganger.Select(k => new avgangs
                {
                    AvgangId = k.AvgangId,
                    StasjonId = k.Stasjon.StasjonId,
                    Tid = k.Tid,
                    TogId = k.Tog.TogId

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

                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }

            }


        }
        public avgangs hentAvgang(int AvgangId)
        {
            using (var db = new TogContext())
            {
                Avgang enAvgang = db.Avganger.Find(AvgangId);
                var hentAvgang = new avgangs()
                {
                    AvgangId = enAvgang.AvgangId,
                    StasjonId = enAvgang.Stasjon.StasjonId,
                    Tid = enAvgang.Tid,
                   TogId = enAvgang.Tog.TogId

                };
                return hentAvgang;
            }
        }
        public bool endreAvgang(avgangs innAvgang)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var endretobjekt = db.Avganger.Find(innAvgang.AvgangId);
               
                    endretobjekt.Tid = innAvgang.Tid;
                   
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


        //Stasjoner metoder

        public List<StasjonV> alleStasjoner()
        {

            using (var db = new TogContext())
            {
                List<StasjonV> alleStasjoner = db.Stasjoner.Select(k => new StasjonV
                {
                    StasjonId = k.StasjonId,
                    StasjonNavn = k.StasjonNavn


                }).ToList();
                return alleStasjoner;
            }




        }
        public bool lagreStasjon (Stasjon innStasjon)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var nyavgang = new Stasjon();
                    nyavgang.StasjonId = innStasjon.StasjonId;
                    nyavgang.StasjonNavn = innStasjon.StasjonNavn;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }

            }

        }
        public StasjonV hentStasjon (int StasjonId)
        {
            using (var db = new TogContext())
            {
                Stasjon enStasjon= db.Stasjoner.Find(StasjonId);
                var hentstasjon = new StasjonV()
                {
                    StasjonId= enStasjon.StasjonId,
                    StasjonNavn=enStasjon.StasjonNavn

                };
                return hentstasjon;
            }

        }
        public bool endreStasjon(StasjonV innStasjon)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var endretobjekt = db.Stasjoner.Find(innStasjon.StasjonId);

                    endretobjekt.StasjonNavn= innStasjon.StasjonNavn;

                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }

        }
        public bool SlettStasjon (int id)
        {
            using (var db = new TogContext())
            {
                try
                {
               
                    var slettObjekt = db.Stasjoner.Find(id);

                    db.Stasjoner.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        ///
    }
}

