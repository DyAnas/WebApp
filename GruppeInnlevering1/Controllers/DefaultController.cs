
using System;
using System.Collections.Generic;

using System.Web.Mvc;
using System.Web.Script.Serialization;

using GruppeInnlevering1.BLL;
using GruppeInnlevering1.Model;


namespace GruppeInnlevering.Controllers
{
    public class DefaultController : Controller
    {
        //  TogContext db = new TogContext();
        TogLogikk db1 = new TogLogikk();






        public ActionResult Index()
        {
            Samle ny = new Samle();

            List<StasjonV> alleStasjoner = db1.alleStasjoner();



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

            TogLogikk db1 = new TogLogikk();

            List<StasjonV> valgStasjon = db1.hentTilListe(stajonId);




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

           try
           {
                result = int.Parse(s.Fra);  //konvertere StajonId til Int 
                result1 = int.Parse(s.Til); //DestnasjonId
          }
       


            //Hvis Destinasjon ikke er valgt blir man sendt til Index siden
            catch (Exception feil)
            {

                Logging Err = new Logging();
                Err.FeilLog(Server.MapPath("./../ErrorLog/TextFile"), feil.Message + ": Har ikke valgt destinasjon");
                return RedirectToAction("Index");
            }
            StasjonV stasjonFra = db1.hentEStasjon(result);
            StasjonV stasjonTil = db1.hentEStasjon(result1);
            List<avgangs> ReturListe = new List<avgangs>();


            List<avgangs> turListe = db1.hentTurListe(result, result1);
            if(s.datoTilbake.GetHashCode() != 0) { 
          ReturListe = db1.hentReturListe(result, result1);
            }
         





            //sette Tur og Retur Avganger i en Liste og sende dem til Viewen

            List<avgangs> TurogRetur = new List<avgangs>();
            ny.datoTilbake = s.datoTilbake;
            ny.dato = s.dato;


            foreach (avgangs avgang in turListe)
            {
                avgang.StasjonnavnFra = stasjonFra;
                avgang.StasjonnavnTil = stasjonTil;
                TurogRetur.Add(avgang);
            }
            if (s.datoTilbake.GetHashCode() != 0)
            {
                foreach (avgangs avgang in ReturListe)
                {
                    avgang.StasjonnavnTil = stasjonFra;
                    avgang.StasjonnavnFra = stasjonTil;
                    TurogRetur.Add(avgang);
                }
            }
            Session["alle"] = ny;

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
            ny.Telefonnummer = Telefonnummer;
            ny.Email = Email;
            ny.Kortnummer = kortnummer;
            ny.Cvc = Cvc;




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



            //finner lengde mellom stasjoner til å regne prisen 
            var studentpris = 10;
            var voksenpris = 20;
            var barnpris = 5;
            //pris fakturer
            if (Session["Studentpris"] != null)
            {
                studentpris = (int)Session["Studentpris"];
            }
            if (Session["Voksenpris"] != null)
            {
                voksenpris = (int)Session["Voksenpris"];
            }
            if (Session["Barn"] != null)
            {
                barnpris = (int)Session["Barn"];
            }
            //ligge Billtter for StudentType til databasen

            bool ok = db1.setteAlleBilletter(ny, studentpris, voksenpris, barnpris,
             Telefonnummer, Email, kortnummer, Cvc);

            Session["alle"] = ny;
            if (ok)
            {
                return View();


            }
            else
            {
                return View("Error");
            }




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


        [HttpPost]
        public ActionResult Login(Admin innAdmin)
        {
            if (db1.Admin_i_db(innAdmin))
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
            bool ok = db1.nyAdmin(innAdmin);


            if (ok)
            {
                ViewBag.EmailFeil = true;
                return RedirectToAction("Registrer");
            }
            else
            {

                //    Logging Err = new Logging();
                //  Err.FeilLog(Server.MapPath("./../ErrorLog/TextFile"), feil.Message + ": kan ikke sette billett i databasen");


                ViewBag.EmailFeil = true;
                return View();
            }
        }


        public ActionResult Avganger()
        {
            Session["loggetInn"] = true;
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

                return RedirectToAction("Avganger");
            }

            return View();
        }
        public ActionResult SlettAvgang(int id)
        {


            bool OK = db1.slettAvgang(id);
            if (OK)
            {
                return RedirectToAction("Avganger");
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
            bool ok = db1.nyAvgang(innAvgang);
            if (ok)
            {
                ViewBag.FeilStrekning = false;
                Session["feilStrekning"] = ViewBag.FeilStrekning;
                return RedirectToAction("Avganger");
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

            ViewBag.leggStasjon = Session["leggStasjon"];
            List<StasjonV> alleStasjonerliste = db1.alleStasjoner();
            return View(alleStasjonerliste);
        }
        public ActionResult EndreStasjon(int id)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            Session["leggStasjon"] = true;
            StasjonV s = db1.hentEStasjon(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult EndreStasjon(StasjonV innStasjon)
        {
            Session["loggetInn"] = true;
            ViewBag.Innlogget = true;
            Session["leggStasjon"] = true;
            bool OK = db1.endreStasjon(innStasjon);
            if (OK)
            {
                ViewBag.FeilStasjon = false;
                return RedirectToAction("Stasjoner");
            }
            else
            {
                Session["leggStasjon"] = false;
                return RedirectToAction("Stasjoner");

            }


        }
        public ActionResult SlettStasjon(int id)
        {


            bool OK = db1.slettStasjon(id);
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
        /*  public ActionResult Endrebillett(int id)
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
          }*/
        public ActionResult SlettBillett(int id)
        {


            bool OK = db1.slettBillet(id);
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

                Session["togmelding"] = true;
                return RedirectToAction("TogListe");
            }
            else
            {

                Session["togmelding"] = false;
                return RedirectToAction("Togliste");
            }


        }
        public ActionResult SlettTog(int id)
        {


            bool OK = db1.slettTog(id);
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
            bool ok = db1.nyTog(innTog);
            if (ok)
            {
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
            if (!"".Equals(Studentpris))
            {
                Session["Studentpris"] = int.Parse(Studentpris);
                ViewBag.FeilPis = false;

            }


            if (!"".Equals(voksenpris))
            {
                Session["Voksenpris"] = int.Parse(voksenpris);
                ViewBag.FeilPis = false;
            }

            if (!"".Equals(barnpris))
            {
                Session["Barn"] = int.Parse(barnpris);
                ViewBag.FeilPis = false;
            }
            Session["Feilpris"] = ViewBag.FeilPis;

            return View("EndrePrisV");
        }





    }

}















