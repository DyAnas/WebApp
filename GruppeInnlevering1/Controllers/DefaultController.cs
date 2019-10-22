using GruppeInnlevering1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GruppeInnlevering1.Controllers
{
    public class DefaultController : Controller
    {
        TogContext db = new TogContext();
        DbTogstasjon db1 = new DbTogstasjon();


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

  

        public ActionResult Index()
        {
            Samle ny = new Samle();

            IEnumerable<Stasjon> alleStasjoner = hentStasjoner();

            ny.fraListe = alleStasjoner;

            Session["alle"] = ny;     //lagre objekt i Session til å kunne bruke det i andre sider
            if (Session["loggetInn"] == null)
            {
                Session["loggetInn"] = false;
              
                ViewBag.Innlogget = false;
               
            }
            else if ((bool)Session["loggetInn"] == true)
            {
                ViewBag.Innlogget = true;

               
            }
         return View(ny);   

         
        }




        // metode som begrenser valg i TilListe til kun de stasjonene som ligger i denne strekningen 
        // den skal retunere En Liste med Ajax-kall og json 

        public string hentListe(int stajonId)
        {
            IEnumerable<Stasjon> TilListe = hentTilListe(stajonId);


            List<Stasjon> valgStasjon = new List<Stasjon>();

            foreach (Stasjon i in TilListe)
            {
                valgStasjon.Add(new Stasjon { StasjonId = i.StasjonId, StasjonNavn = i.StasjonNavn });

            }

            Samle ny = (Samle)Session["alle"];
            ny.tilListe = valgStasjon;

            var jsonSeralizer = new JavaScriptSerializer();

            return jsonSeralizer.Serialize(ny.tilListe);

        }




        [HttpPost]
        public ActionResult Result(Samle s)
        {

            Samle ny = (Samle)Session["alle"];

            if (Session["loggetInn"] == null)
            {
                Session["loggetInn"] = false;

                ViewBag.Innlogget = false;

            }
            else if ((bool)Session["loggetInn"] == true)
            {
                ViewBag.Innlogget = true;

            }


            ny.antall1 = s.antall1;    //antall  StudentBilletter
            ny.antall2 = s.antall2;    //antall  VoksenBilletter
            ny.antall3 = s.antall3;    //antall  BarnBilletter





            if (Session["Studentpris"] != null)
            {
                ny.Studentpris = (int)Session["Studentpris"];
            }
            else
            {
                ny.Studentpris = 10;
            }

            if (Session["Voksenpris"] != null)
            {
                ny.Voksenpris = (int)Session["Voksenpris"];
            }
            else
            {
                ny.Voksenpris = 20;
            }

            if (Session["Barn"] != null)
            {
                ny.BarnPris = (int)Session["Barn"];
            }
            else
            {
                ny.BarnPris = 5;
            }



      


            ny.dato = s.dato;
            int result;
            int result1;
            IEnumerable<Avgang> turListe = null;
            try
            {
                result = int.Parse(s.Fra);  //konvertere StajonId til Int 
                result1 = int.Parse(s.Til); //DestnasjonId
            }

            //Hvis Destinasjon ikke er valgt blir man sendt til Index siden
            catch (Exception feil)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(feil.ToString()) + "')</script>");
                return RedirectToAction("Index");


            }
            IEnumerable<Avgang> ReturListe = null;

            //henter Tur og Retur Reiser avhenger av id til Stasjoner som ble valgt 
            if (result < result1)
            {

                turListe = db.Avganger.Where(b => b.Stasjon.StasjonId == result || b.Stasjon.StasjonId == result1);

                if (s.datoTilbake.GetHashCode() != 0)
                {
                    ny.datoTilbake = s.datoTilbake;

                    ReturListe = db.Avganger.Where(b => (b.Stasjon.StasjonId == result1) && b.Tog.TogId % 3 == 0
                    || (b.Stasjon.StasjonId == result) && b.Tog.TogId % 3 == 0);


                }
            }

            //henter Tur og Retur Reiser avhenger av id til Stasjoner som ble valgt 

            else if (result > result1)
            {
                turListe = db.Avganger.Where(b => (b.Stasjon.StasjonId == result1) && b.Tog.TogId % 3 == 0 ||
                (b.Stasjon.StasjonId == result) && b.Tog.TogId % 3 == 0);


                if (s.datoTilbake.GetHashCode() != 0)
                {
                    ny.datoTilbake = s.datoTilbake;

                    ReturListe = db.Avganger.Where(b => b.Stasjon.StasjonId == result || b.Stasjon.StasjonId == result1).Take(4);

                }


            }
            //sette Tur og Retur Avganger i en Liste og sende dem til Viewen

            List<Avgang> TurogRetur = new List<Avgang>();

            foreach (Avgang avgang in turListe)
            {
                TurogRetur.Add(avgang);
            }
            if (s.datoTilbake.GetHashCode() != 0)
            {
                foreach (Avgang avgang in ReturListe)
                {
                    TurogRetur.Add(avgang);
                }
            }

            return View(TurogRetur);
        }



        public ActionResult Bekrefte(string FraStasjon, string TilStasjon,
                                       TimeSpan Avgang, TimeSpan Ankomst,
                                       int StasjonfraId, int StasjonTilId)


        {

            Samle ny = (Samle)Session["alle"];     //henter objektet med Session for å bruke det i siden her 

            if (Session["loggetInn"] == null)
            {
                Session["loggetInn"] = false;

                ViewBag.Innlogget = false;

            }
            else if ((bool)Session["loggetInn"] == true)
            {
                ViewBag.Innlogget = true;

            }
            ny.Fra = FraStasjon;
            ny.Til = TilStasjon;
            ny.tidFra = Avgang;
            ny.tidTil = Ankomst;
            ny.stasjonIdTil = StasjonTilId;
            ny.stasjonIdFra = StasjonfraId;


            Session["alle"] = ny;

            return View(ny);
        }

        [HttpPost]
        public ActionResult Betaling(string Telefonnummer, string Email, string kortnummer, int Cvc)
        {

            Samle ny = (Samle)Session["alle"];


           

            if (Session["loggetInn"] == null)
            {
                Session["loggetInn"] = false;
              
                ViewBag.Innlogget = false;
            
            }
            else if ((bool)Session["loggetInn"] == true)
            {
                ViewBag.Innlogget = true;

            }
            //vi kunne bruke nullable til datoen, men vi synes at det  ikke  er logiskk å bruke det med datoen 


            if (ny.datoTilbake.GetHashCode() == 0)
            {

                ny.datoTilbake = null;
            }



            var lengde = ny.stasjonIdTil - ny.stasjonIdFra;    //finner lengde mellom stasjoner til å regne prisen 
            var studentpris = 10;
            var voksenpris = 20;
            var barnpris = 5;
            //pris fakturer
            if (Session["Studentpris"] != null)
            {
                studentpris = (int)Session["Studentpris"];
            }
            if(Session["Voksenpris"] != null)
            {
                voksenpris = (int)Session["Voksenpris"];
            }
            if(Session["Barn"] != null)
            {
                barnpris = (int)Session["Barn"];
            }
            //ligge Billtter for StudentType til databasen

            for (var i = 0; i < ny.antall1; i++)
            {
                var bnyBi = new Billet
                {
                    AvgangFra = ny.stasjonIdFra,
                    AvgangTil = ny.stasjonIdTil,
                    Type = "Student",
                    Pris = lengde * studentpris,
                    DatoTur = ny.dato,
                    DatoRetur = ny.datoTilbake,
                    Telefonnummer = Telefonnummer,
                    Email = Email,
                    Kortnummer = kortnummer,
                    Cvc = Cvc

                };
                try
                {
                    db.Billeter.Add(bnyBi);
                }
                catch (Exception)
                {
                    throw new Exception("kan ikke sette ny Billett i databasen");
                }

            }


            //ligge Billtter for VoksenType til databasen

            for (var i = 0; i < ny.antall2; i++)
            {
                var NyBillett = new Billet
                {
                    AvgangFra = ny.stasjonIdFra,
                    AvgangTil = ny.stasjonIdTil,
                    Type = "Voksen",
                    Pris = lengde * voksenpris,
                    DatoTur = ny.dato,
                    DatoRetur = ny.datoTilbake,
                    Telefonnummer = Telefonnummer,
                    Email = Email,
                    Kortnummer = kortnummer,
                    Cvc = Cvc

                };


                try
                {
                    db.Billeter.Add(NyBillett);
                }
                catch (Exception feil)
                {
                    throw new Exception("kan ikke sette ny Billett i databasen");

                }

            }




            //ligge Billtter for BarnType til databasen

            for (var i = 0; i < ny.antall3; i++)
            {
                var NyBillet = new Billet
                {
                    AvgangFra = ny.stasjonIdFra,
                    AvgangTil = ny.stasjonIdTil,
                    Type = "Barn",
                    Pris = lengde * barnpris,
                    DatoTur = ny.dato,
                    DatoRetur = ny.datoTilbake,
                    Telefonnummer = Telefonnummer,
                    Email = Email,
                    Kortnummer = kortnummer,
                    Cvc = Cvc
                };

                try
                {
                    db.Billeter.Add(NyBillet);
                }

                catch (Exception feil)
                {
                    throw new Exception("kan ikke sette ny Billett i databasen");

                }

            }

            db.SaveChanges();

             Session["alle"]=  ny;

            return View();

        }


        public IEnumerable<Stasjon> hentStasjoner()     //Henter Alle StasjonerListe til Select for Fra i Index Siden
        {
            IEnumerable<Stasjon> stasjoner = db.Stasjoner;

            return stasjoner;
        }

        public IEnumerable<Stasjon> hentTilListe(int id)
        {
            IEnumerable<Stasjon> tilListe = null;

            if (id > 0 && id < 9)
            {
                tilListe = db.Stasjoner.Where(p => p.StasjonId > 0 && p.StasjonId < 9);
            }
            else if (id > 8 && id < 17)
            {
                tilListe = db.Stasjoner.Where(p => p.StasjonId > 8 && p.StasjonId < 17);
            }

            else
            {
                tilListe = db.Stasjoner.Where(p => p.StasjonId > 16 && p.StasjonId < 25);
            }
            return tilListe;




        }


        // endre 
        private static string lagsalt()
        {
            byte[] random = new byte[12];
            string randomStr;

            var str = new RNGCryptoServiceProvider();
            str.GetBytes(random);
            randomStr = Convert.ToBase64String(random);
            return randomStr;
        }


        // endre 
        private static byte[] hash(String innPass)
        {
            byte[] innData, utData;
            var algo = SHA256.Create();
            innData = Encoding.UTF8.GetBytes(innPass);
            utData = algo.ComputeHash(innData);
            return utData;
        }

        // endre

        public ActionResult Login()
        {
            
            if (Session["loggetInn"] == null)
            {
                Session["loggetInn"] = false;
                ViewBag.Innlogget = false;
                ViewBag.feillogg = true;
                return View("Registrer");
            }
            else if ((bool)Session["loggetInn"] == true)
            {
                ViewBag.Innlogget = true;
                Session["feilStrekning"] = null;
                Session["leggStasjon"] = null;
                Session["togmelding"] = null;
                Session["Feilpris"] = null;
                Session["feilEndreAvgang"] = null;
                return View();

            }
            return View("Registrer");


        }
        private static bool Admin_i_db(Admin innAdmin)
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
        [HttpPost]
        public ActionResult Login(Admin innAdmin)
        {
            if (Admin_i_db(innAdmin))
            {



                Session["loggetInn"] = true;
                //ny
                ViewBag.Innlogget = true;
               
                return View();
            }
            else
            {
                Session["loggetInn"] = false;
                ViewBag.feillogg = true;
                ViewBag.Innlogget = false;
                return View("Registrer");

            }
        }

        public ActionResult Registrer()
        {
         
            ViewBag.Innlogget = false;
            Session["loggetInn"] = false;
            return View();
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Registrer(Admin innAdmin)
        {
            /*  if (!ModelState.IsValid)
              {
                  return View();
              }*/
            try
            {
                var nyAdmin = new DbAdmin();
                string salt = lagsalt();
                var passSalt = innAdmin.passord + salt;
                byte[] passDb = hash(passSalt);
                nyAdmin.Fornavn = innAdmin.Fornavn;
                nyAdmin.EtterFornavn = innAdmin.Etternavn;
                nyAdmin.Email = innAdmin.Email;
              
                nyAdmin.passord = passDb;
                nyAdmin.Salt = salt;
                db.Admins.Add(nyAdmin);
                db.SaveChanges();
                ViewBag.EmailFeil = true;
                return RedirectToAction("Registrer");

            }
            catch (Exception feil)
            {
                ViewBag.EmailFeil = true;
                return View();
            }
        }


        public ActionResult Strekning()
        {
            Session["loggetInn"] =true;
            ViewBag.Innlogget = true;
            ViewBag.FeilStrekning = Session["feilStrekning"];
          
                List<avgangs> avganger = db1.allavganger();

                return View(avganger);

        }

        
        public ActionResult EndreAvgang(int id)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            avgangs s = db1.hentAvgang(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult EndreAvgang(avgangs innAvgang)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
       
            bool OK = db1.endreAvgang(innAvgang);
            if (OK)
            {
                ViewBag.Feil = false;

                Session["feilStrekning"] = ViewBag.Feil;

               return RedirectToAction("Strekning");
            }
          
            return View();
        }
        public ActionResult SlettAvgang(int id)
        {
            
       
            bool OK = db1.SlettAvgan(id);
            if (OK)
            {
                return RedirectToAction("Strekning");
            }
            return View();
        }
        public ActionResult nyAvgang()
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            return View();
        }
        
        [HttpPost]
        public ActionResult nyAvgang(avgangs innAvgang)
        {
            ViewBag.Innlogget = true;
            bool  ok= db1.nyAvgang(innAvgang);
            if (ok) {
                ViewBag.FeilStrekning = false;
                Session["feilStrekning"] = ViewBag.FeilStrekning;
                return RedirectToAction("Strekning");
            }
            else
            {
                ViewBag.FeilStrekning = true;
                return View(); 
            }         
            }
        


        // stasjon Kontroller
        public ActionResult Stasjoner()
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;

            ViewBag.leggStasjon =Session["leggStasjon"];
            List<StasjonV> alleStasjonerliste = db1.alleStasjoner();
            return View(alleStasjonerliste);
        }
        public ActionResult EndreStasjon(int id)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            Session["leggStasjon"] = true;
            StasjonV s = db1.hentStasjon(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult EndreStasjon(StasjonV innStasjon)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            bool OK = db1.endreStasjon(innStasjon);
            if (OK)
            {
                ViewBag.FeilStasjon = false;
                return RedirectToAction("Stasjoner");
            }
            return View();
        }
        public ActionResult SlettStasjon(int id)
        {
          

            bool OK = db1.SlettStasjon(id);
            if (OK)
            {
                return RedirectToAction("Stasjoner");
            }
            return View("Login");
        }
        public ActionResult nyStasjon()
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            ViewBag.leggStasjon = true;

            return View();
        }
        [HttpPost]
        public ActionResult nyStasjon(StasjonV innStasjon)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;

            var ok = db1.nyStasjon(innStasjon);
            if (ok)
            {
                ViewBag.leggStasjon = true;
                Session["leggStasjon"] = ViewBag.leggStasjon;

                return RedirectToAction("Stasjoner");

            }
            else
            {
                ViewBag.leggStasjon = false;
                return View();

            }
        }
        // billett Kontroller         
        public ActionResult Billter()
        {
            //Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            List<BilletV> alleBillter = db1.alleBillter();
          
            
            return View(alleBillter);



        }
        public ActionResult Endrebillett(int id)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            BilletV s = db1.hentBilett(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Endrebillett(BilletV innBillett)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            bool OK = db1.endreBillett(innBillett);
            if (OK)
            {
                return RedirectToAction("Billter");
            }
            return View("Login");
        }
        public ActionResult SlettBillett(int id)
        {
          

            bool OK = db1.SlettSBillett(id);
            if (OK)
            {
                return RedirectToAction("Billter");
            }
            return View("Login");
        }

        // tog kontroller
        public ActionResult TogListe()
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            List<TogV> togListe = db1.alleTog();
            ViewBag.leggtog = Session["togmelding"];
            return View(togListe);

        }
        public ActionResult EndreTog(int id)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            TogV s = db1.hentTog(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Endretog(TogV innTog)
        {
            ViewBag.Innlogget = true;
            bool OK = db1.endreTog(innTog);
            if (OK)
            {
                ViewBag.leggtog = true;
                return RedirectToAction("TogListe");
            }
            ViewBag.leggtog = false;
            return View();
        }
        public ActionResult SlettTog(int id)
        {
           

            bool OK = db1.SlettTog(id);
            if (OK)
            {
                return RedirectToAction("TogListe");
            }
            return View("Login");
        }


        public ActionResult nyTog()
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            return View();
        }
        [HttpPost]
        public ActionResult nyTog(TogV innTog)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            bool ok =db1.nyTog(innTog);
            if (ok) {
                Session["togmelding"] = true;
                return RedirectToAction("TogListe");
            }
           ViewBag.TogFinnes = true;
            return View();

        }

        // metode for priser 
        public ActionResult EndrePrisV()
        {
            Session["loggetInn"] = true;

            ViewBag.Innlogget = true;
            ViewBag.FeilPis = null;
           
            return View();
        }
        [HttpPost]
        public ActionResult EndrePris(string Studentpris, string voksenpris, string barnpris)
        {
            Session["loggetInn"] = true;

            ViewBag.FeilPis = true;
            ViewBag.Innlogget = true;
            if (!"".Equals(Studentpris)) { Session["Studentpris"] = int.Parse(Studentpris);
                ViewBag.FeilPis = false;
                
            }


            if (!"".Equals(voksenpris)) { Session["Voksenpris"] = int.Parse(voksenpris);
                ViewBag.FeilPis = false;
            }

            if (!"".Equals(barnpris)) { Session["Barn"] = int.Parse(barnpris);
                ViewBag.FeilPis = false;
            }
            Session["Feilpris"] = ViewBag.FeilPis;

            return View("EndrePrisV");
        }
    }

}















