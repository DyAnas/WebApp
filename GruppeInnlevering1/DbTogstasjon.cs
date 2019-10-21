using GruppeInnlevering1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1
{
    public class DbTogstasjon
    {
        public List<TogV> alleTog()
        {

            using (var db = new TogContext())
            {
                List<TogV> alleTog = db.TogTabell.Select(k => new TogV
                {
                    TogId = k.TogId,
                    TogNavn = k.TogNavn


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
        public bool nyAvgang(avgangs innAvgang)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var nyavgang = new Avgang();
                    nyavgang.Tid = innAvgang.Tid;
                    var sjekkTogId = db.TogTabell.Find(innAvgang.TogId);

                    var sjekkStajonId = db.Stasjoner.Find(innAvgang.StasjonId);
                    if (sjekkTogId != null && sjekkStajonId != null)
                    {
                        nyavgang.Stasjon = sjekkStajonId;
                        nyavgang.Tog = sjekkTogId;
                        db.Avganger.Add(nyavgang);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
                catch (Exception feil)
                {
                    return false;
                }
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
                  return true;
                }
                catch (Exception feil)
                {

                    return false;
                }
             
            }
        }
        public bool SlettAvgan(int id)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var slettObjekt = db.Avganger.Find(id);
                    var slettBillett = db.Billeter.Where(k => k.AvgangFra==id || k.AvgangTil==id);
                   
                    foreach(var item in slettBillett)
                    {
                     db.Billeter.Remove(item);
                    }
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
        public bool lagreStasjon(Stasjon innStasjon)
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
        public bool nyStasjon(StasjonV innStasjon)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var nyStasjon = new Stasjon();
                    var funnetStasjon = db.Stasjoner.Where(k => k.StasjonNavn == innStasjon.StasjonNavn);
                    if(funnetStasjon.Count() == 0)
                    {
                        nyStasjon.StasjonNavn = innStasjon.StasjonNavn;

                        db.Stasjoner.Add(nyStasjon);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }
        public StasjonV hentStasjon(int StasjonId)
        {
            using (var db = new TogContext())
            {
                Stasjon enStasjon = db.Stasjoner.Find(StasjonId);
                var hentstasjon = new StasjonV()
                {
                    StasjonId = enStasjon.StasjonId,
                    StasjonNavn = enStasjon.StasjonNavn

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

                    endretobjekt.StasjonNavn = innStasjon.StasjonNavn;

                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }

        }
        public bool SlettStasjon(int id)
        {
            using (var db = new TogContext())
            {
                try
                {


                    var slett = from i in db.Avganger
                                from k in db.Stasjoner
                                from b in db.Billeter
                                where i.Stasjon.StasjonId == id
                                   & k.StasjonId == id
                                  || b.AvgangFra==id || b.AvgangTil==id
                                select new { i, k,b };
                    foreach (var item in slett)
                    {
                        db.Stasjoner.Remove(item.k);
                        db.Avganger.Remove(item.i);
                        db.Billeter.Remove(item.b);
                    }

                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        ///Billett metoder

        public List<BilletV> alleBillter()
        {
            using (var db = new TogContext())
            {
                List<BilletV> alleBillter = db.Billeter.Select(k => new BilletV
                {
                    AvgangFra = k.AvgangFra,
                    AvgangTil = k.AvgangTil,
                    BilletId = k.BilletId,
                    Cvc = k.Cvc,
                    DatoRetur = k.DatoRetur,
                    DatoTur = k.DatoTur,
                    Email = k.Email,
                    Kortnummer = k.Kortnummer,
                    Pris = k.Pris,
                    Telefonnummer = k.Telefonnummer,
                    Type = k.Type
                }).ToList();
                return alleBillter;
            }
        }
        public bool lagreBilleter(Billet innBillett)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var nyavgang = new Billet();
                    nyavgang.BilletId = innBillett.BilletId;
                    nyavgang.Pris = innBillett.Pris;
                    nyavgang.Telefonnummer = innBillett.Telefonnummer;
                    nyavgang.Type = innBillett.Type;
                    nyavgang.Kortnummer = nyavgang.Kortnummer;
                    nyavgang.Email = innBillett.Email;
                    nyavgang.DatoTur = innBillett.DatoTur;
                    nyavgang.Cvc = innBillett.Cvc;
                    nyavgang.AvgangTil = innBillett.AvgangTil;
                    nyavgang.AvgangFra = innBillett.AvgangFra;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }

            }

        }
        public BilletV hentBilett(int BilletId)
        {
            using (var db = new TogContext())
            {
                Billet enbillett = db.Billeter.Find(BilletId);
                var hentbilletts = new BilletV()
                {
                    BilletId = enbillett.BilletId,
                    Type = enbillett.Type,
                    DatoTur = enbillett.DatoTur,
                    DatoRetur = enbillett.DatoRetur,
                    Pris = enbillett.Pris,
                    AvgangFra = enbillett.AvgangFra,
                    AvgangTil = enbillett.AvgangTil,
                    Telefonnummer = enbillett.Kortnummer,
                    Email = enbillett.Email,
                    Kortnummer = enbillett.Kortnummer,
                    Cvc = enbillett.Cvc

                };
                return hentbilletts;
            }

        }

        public bool endreBillett(BilletV innBillett)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var endretobjekt = db.Billeter.Find(innBillett.BilletId);
                    endretobjekt.AvgangFra = innBillett.AvgangFra;
                    endretobjekt.AvgangTil = innBillett.AvgangTil;
                    endretobjekt.Cvc = innBillett.Cvc;
                    endretobjekt.DatoRetur = innBillett.DatoRetur;
                    endretobjekt.DatoTur = innBillett.DatoTur;
                    endretobjekt.Email = innBillett.Email;
                    endretobjekt.Kortnummer = innBillett.Kortnummer;
                    endretobjekt.Pris = innBillett.Pris;
                    endretobjekt.Telefonnummer = innBillett.Telefonnummer;
                    endretobjekt.Type = innBillett.Type;

                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }

        }
        public bool SlettSBillett(int id)
        {
            using (var db = new TogContext())
            {
                try
                {

                    var slettObjekt = db.Billeter.Find(id);
                     
                    db.Billeter.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        // Tog metoder
        public List<TogV> alleToger()
        {

            using (var db = new TogContext())
            {
                List<TogV> alleToger = db.TogTabell.Select(k => new TogV
                {
                    TogId = k.TogId,
                    TogNavn = k.TogNavn
                }).ToList();
                return alleToger;
            }

        }

      
        public bool nyTog(TogV innTog)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var nyTog = new Tog();
                    var sjekkToget = db.TogTabell.Where(k => k.TogNavn == innTog.TogNavn);
                    if (sjekkToget.Count() == 0)
                    {
                        nyTog.TogNavn = innTog.TogNavn;
                        db.TogTabell.Add(nyTog);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
               

                }
                catch (Exception feil)
                {

                    return false;
                }
            }

        }
        public TogV hentTog(int TogId)
        {
            using (var db = new TogContext())
            {
                Tog enTog = db.TogTabell.Find(TogId);
                var hentTog = new TogV()
                {
                    TogId = enTog.TogId,
                    TogNavn = enTog.TogNavn

                };
                return hentTog;
            }

        }
        public bool endreTog(TogV inntog)
        {
            using (var db = new TogContext())
            {
                try
                {
                    var endretobjekt = db.TogTabell.Find(inntog.TogId);

                    endretobjekt.TogNavn = inntog.TogNavn;

                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }

        }
        public bool SlettTog(int id)
        {
            using (var db = new TogContext())
            {
                try
                {
                    // var slettObjekt = db.Stasjoner.Find(id);
                    var slett = from i in db.Avganger
                                from k in db.TogTabell
                                from b in db.Billeter
                                where i.Tog.TogId == id
                                   & k.TogId == id
                                   ||  b.AvgangFra ==id
                                   || b.AvgangTil ==id
                                select new { i, k,b };
                    foreach (var item in slett)
                    {
                        db.TogTabell.Remove(item.k);
                        db.Avganger.Remove(item.i);
                        db.Billeter.Remove(item.b);
                    }
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




      
        
    
