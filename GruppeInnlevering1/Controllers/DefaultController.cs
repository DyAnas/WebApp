using GruppeInnlevering1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GruppeInnlevering1.Controllers
{
    public class DefaultController : Controller
    {
        TogContext db = new TogContext();

        Samle ny = new Samle();

     



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();

            }
            base.Dispose(disposing);
           
        }
        public IEnumerable<Stasjon> hentStasjoner()
        {
            IEnumerable<Stasjon> stasjoner = db.Stasjoner;
            return stasjoner;
        }


        public ActionResult Index()
        {
            


            IEnumerable<Stasjon> alleStasjoner = hentStasjoner();

            ny.fraListe = alleStasjoner;
           
            

                return View(ny);
          
            
        }
        


        public string hentListe(int id) {
            IEnumerable<Stasjon> alt = null;
            if (id > 0 && id < 9)
            {
                alt = db.Stasjoner.Where(p=>p.StasjonId>0 && p.StasjonId<9) ;
            }
            else if(id>8 && id<17) {
                alt = db.Stasjoner.Where(p => p.StasjonId >8 && p.StasjonId < 17);
            }

            else
            {
                alt = db.Stasjoner.Where(p => p.StasjonId > 16 && p.StasjonId < 25);
            }
            List<Stasjon> valgStasjon = new List<Stasjon>();
            foreach (Stasjon i in alt) {
                valgStasjon.Add(new Stasjon { StasjonId=i.StasjonId,StasjonNavn=i.StasjonNavn});

}
            ny.tilListe = valgStasjon;








                var jsonSeralizer = new JavaScriptSerializer();
           

            return jsonSeralizer.Serialize(ny.tilListe);
            
            
            }
        
       [HttpPost]
        public ActionResult Result(Samle s)
        {
            ny.antall1 = s.antall1;
            ny.antall2 = s.antall2;
            ny.antall3 = s.antall3;
           
            ny.dato= s.dato;

            IEnumerable<Avgang> h = null;
            int result = Int32.Parse(s.Fra);
            int result1 = Int32.Parse(s.Til);
            if (result < result1)
            {

                 h = db.Avganger.Where(b => b.Stasjon.StasjonId == result || b.Stasjon.StasjonId == result1);

            }
            if (h == null)
            {
                return null;
            }
            List<Avgang> seno = new List<Avgang>();

           foreach(Avgang avgang in h)
            {
                seno.Add(avgang);
            }
          

            return View(seno);
        }
       
        public ActionResult Bekrefte(string FraStasjon,string TilStasjon,TimeSpan Avgang, TimeSpan Ankomst)
        {


           
            ny.Fra = FraStasjon;
            ny.Til = TilStasjon;
            ny.tidFra = Avgang;
            ny.tidTil = Ankomst;
         
       









            return View(ny);
        }

       
    }
}

        
