
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using GruppeInnlevering1.BLL;
using GruppeInnlevering1.Models;

namespace GruppeInnlevering1.Controllers
{
    public class DefaultController : Controller
    {
     
        TogBLL db1 = new TogBLL();

        private TogLogikk togbll;


        public DefaultController()
        {
            togbll = new TogBLL();
        }
        public DefaultController(TogLogikk stub)
        {
            togbll = stub;
        }
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
        public ActionResult Registrer(Admin innAdmin)
        {
           
            try
            {
               
                db1.nyAdmin(innAdmin);
                ViewBag.EmailFeil = true;
                return RedirectToAction("Registrer");

            }
            catch (Exception feil)
            {
                ViewBag.EmailFeil = true;
                return View();
            }
        }


        public ActionResult Avganger()
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

               return RedirectToAction("Avganger");
            }
          
            return View();
        }
        public ActionResult SlettAvgang(int id)
        {
            
       
            bool OK = db1.SlettAvgan(id);
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
            bool  ok= db1.nyAvgang(innAvgang);
            if (ok) {
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
             
                Session["togmelding"] = true;
                return RedirectToAction("TogListe");
            }
            else
            {
             
                Session["togmelding"] =false;
                return RedirectToAction("Togliste");
            }
           
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















