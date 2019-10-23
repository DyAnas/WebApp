using GruppeInnlevering1.Models;
using GruppeInnlevering1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace GruppeInnlevering1.DAL
{
    public class DbTogstasjonDAL : DAL.TogRepo
    {
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
                        //  db.Billeter.Remove(item);
                        if (item.gyldig == "ja")
                            item.gyldig = "nei";
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
                var finnstasjon = db.Stasjoner.Where(s => s.StasjonNavn == innStasjon.StasjonNavn);

                if (finnstasjon.Count() != 0){
                    return false;
                }
                try
                {
                    var endretobjekt = db.Stasjoner.Find(innStasjon.StasjonId);
                    
                    endretobjekt.StasjonNavn = innStasjon.StasjonNavn;

                
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
                
            }

        }
        public bool SlettStasjon(int id)
        {
            using (var db = new TogContext())
            {
                try
                {


                    var endreBillett = from b in db.Billeter
                                where b.AvgangFra == id || b.AvgangTil == id
                                select new { b };
                    var slettavgang = from i in db.Avganger
                                      where i.Stasjon.StasjonId == id
                                      select new { i }; 

                   foreach(var item in slettavgang)
                    {
                        db.Avganger.Remove(item.i);
                    }
                    var slettstasjon = from s in db.Stasjoner
                                       where s.StasjonId == id
                                       select new { s };
 
                    foreach (var item in slettstasjon)
                    {
                        db.Stasjoner.Remove(item.s);
                    }
                    foreach (var item in endreBillett)
                    {
                       
                        if (item.b.gyldig == "ja")
                            item.b.gyldig = "nei";
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
                    Type = k.Type,
                    gyldig=k.gyldig
                }).ToList();
                return alleBillter;
            }
        }
        public BilletV hentBilett(int BilletId)
        {
            using (var db = new TogContext())
            {
                Billett enbillett = db.Billeter.Find(BilletId);
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
                    Cvc = enbillett.Cvc,
                    gyldig=enbillett.gyldig

                };
                return hentbilletts;
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
                var endretog = db.TogTabell.Where(t =>t.TogNavn==inntog.TogNavn);
                if(endretog.Count() != 0)
                {
                    return false;
                }
                try
                {

                    var endreobjekt = db.TogTabell.Find(inntog.TogId);
                    endreobjekt.TogNavn = inntog.TogNavn;

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
                    var slettAvgang = from i in db.Avganger
                                         where i.Tog.TogId==id
                                      select new { i };
                    foreach(var item in slettAvgang)
                    {
                        db.Avganger.Remove(item.i);
                    }

                    var sletttog = from k in db.TogTabell
                                   where k.TogId==id
                                   select new { k }  ;
                    foreach (var item in sletttog)
                    {
                        db.TogTabell.Remove(item.k);
                    }
                    var endreBillet = from b in db.Billeter
                                      from i in db.TogTabell
                                      from a in db.Avganger
                                      where i.TogId == id
                                       & a.Tog.TogId== id
                                  
                                select new { b,i,a };
                    foreach (var item in endreBillet)
                    {
                       
                        if (item.b.gyldig == "ja")
                            item.b.gyldig = "nei";
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


        // admin metoder 
        private static string lagsalt()
        {
            byte[] random = new byte[12];
            string randomStr;

            var str = new RNGCryptoServiceProvider();
            str.GetBytes(random);
            randomStr = Convert.ToBase64String(random);
            return randomStr;
        }


        private static byte[] hash(String innPass)
        {
            byte[] innData, utData;
            var algo = SHA256.Create();
            innData = Encoding.UTF8.GetBytes(innPass);
            utData = algo.ComputeHash(innData);
            return utData;
        }


        public bool Admin_i_db(Admin innAdmin)
        {
            using (var DB = new TogContext())
            {
                DbAdmin funnetAdmin = DB.Admins.FirstOrDefault(b => b.Email == innAdmin.Email);
                if (funnetAdmin != null)
                {
                    byte[] passordForTest = hash(innAdmin.passord + funnetAdmin.Salt);
                    bool riktigBruker = funnetAdmin.passord.SequenceEqual(passordForTest);  // merk denne testen!
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }
   
        public bool nyAdmin(Admin innAdmin)
        {

            using( var db = new TogContext())
                {
                try {
                    string salt = lagsalt();
                    var passSalt = innAdmin.passord + salt;
                    byte[] passDb = hash(passSalt);
                   
                   // byte[] array = Encoding.ASCII.GetBytes(innAdmin.passord);
                    var nyAdmin = new DbAdmin()
                {
                    Fornavn = innAdmin.Fornavn,
                    EtterFornavn = innAdmin.Etternavn,
                    Email = innAdmin.Email,
                    passord = passDb,
                    Salt=salt
                    };
                db.Admins.Add(nyAdmin);
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




      
        
    
