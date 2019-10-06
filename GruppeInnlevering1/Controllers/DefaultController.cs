using GruppeInnlevering1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GruppeInnlevering1.Controllers
{
    public class DefaultController : Controller
    {
        TogContext db = new TogContext();








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
            Samle ny = new Samle();


            IEnumerable<Stasjon> alleStasjoner = hentStasjoner();

            ny.fraListe = alleStasjoner;

            Session["alle"] = ny;

            return View(ny);


        }



        public string hentListe(int id)
        {
            IEnumerable<Stasjon> alt = null;
            if (id > 0 && id < 9)
            {
                alt = db.Stasjoner.Where(p => p.StasjonId > 0 && p.StasjonId < 9);
            }
            else if (id > 8 && id < 17)
            {
                alt = db.Stasjoner.Where(p => p.StasjonId > 8 && p.StasjonId < 17);
            }

            else
            {
                alt = db.Stasjoner.Where(p => p.StasjonId > 16 && p.StasjonId < 25);
            }
            List<Stasjon> valgStasjon = new List<Stasjon>();
            foreach (Stasjon i in alt)
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


            ny.antall1 = s.antall1;
            ny.antall2 = s.antall2;
            ny.antall3 = s.antall3;

            ny.dato = s.dato;


            IEnumerable<Avgang> h = null;
            int result = int.Parse(s.Fra);
            int result1 = int.Parse(s.Til);

            IEnumerable<Avgang> hRetur = null;

            if (result < result1)
            {

                h = db.Avganger.Where(b => b.Stasjon.StasjonId == result || b.Stasjon.StasjonId == result1);

                //     }
                //   else 
                //   {
                //       if (s.datoTilbake.GetHashCode() == 0)
                //        {

                //          h = db.Avganger.Where(b => (b.Stasjon.StasjonId == result1) && b.Tog.TogId %3==0 || (b.Stasjon.StasjonId == result) && b.Tog.TogId %3==0
                //  );
                //      }
                //    }
                if (s.datoTilbake.GetHashCode() != 0)
                {
                    ny.datoTilbake = s.datoTilbake;

                    hRetur = db.Avganger.Where(b => (b.Stasjon.StasjonId == result1) && b.Tog.TogId % 3 == 0 || (b.Stasjon.StasjonId == result) && b.Tog.TogId % 3 == 0
                  );


                }
            }
            else if (result > result1)
            {
                h = db.Avganger.Where(b => (b.Stasjon.StasjonId == result1) && b.Tog.TogId % 3 == 0 || (b.Stasjon.StasjonId == result) && b.Tog.TogId % 3 == 0);
                if (s.datoTilbake.GetHashCode() != 0)
                {
                    ny.datoTilbake = s.datoTilbake;

                    hRetur = db.Avganger.Where(b => b.Stasjon.StasjonId == result || b.Stasjon.StasjonId == result1).Take(4);



                }


            }

            List<Avgang> seno = new List<Avgang>();

            foreach (Avgang avgang in h)
            {
                seno.Add(avgang);
            }
            if (s.datoTilbake.GetHashCode() != 0)
            {
                foreach (Avgang avgang in hRetur)
                {
                    seno.Add(avgang);
                }
            }

            return View(seno);
        }

        public ActionResult Bekrefte(string FraStasjon, string TilStasjon, TimeSpan Avgang, TimeSpan Ankomst, int StasjonfraId, int StasjonTilId)
        {

            Samle ny = (Samle)Session["alle"];


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



            if (ny.datoTilbake.GetHashCode() == 0)
            {

                ny.datoTilbake = new DateTime(9999, 9, 9);
            }



            var lengde = ny.stasjonIdTil - ny.stasjonIdFra;
            for (var i = 0; i < ny.antall1; i++)
            {
                var bnyBi = new Billet
                {
                    AvgangFra = ny.stasjonIdFra,
                    AvgangTil = ny.stasjonIdTil,
                    Type = "Student",
                    Pris = lengde * 10,
                    DatoTur = ny.dato,
                    DatoRetur = ny.datoTilbake,
                    Telefonnummer = Telefonnummer,
                    Email = Email,
                    Kortnummer = kortnummer,
                    Cvc = Cvc

                };
                db.Billeter.Add(bnyBi);


            }


            for (var i = 0; i < ny.antall2; i++)
            {
                var bnyBi = new Billet
                {
                    AvgangFra = ny.stasjonIdFra,
                    AvgangTil = ny.stasjonIdTil,
                    Type = "Voksen",
                    Pris = lengde * 20,
                    DatoTur = ny.dato,
                    DatoRetur = ny.datoTilbake,
                    Telefonnummer = Telefonnummer,
                    Email = Email,
                    Kortnummer = kortnummer,
                    Cvc = Cvc
                };
                db.Billeter.Add(bnyBi);


            }

            for (var i = 0; i < ny.antall3; i++)
            {
                var bnyBi = new Billet
                {
                    AvgangFra = ny.stasjonIdFra,
                    AvgangTil = ny.stasjonIdTil,
                    Type = "Barn",
                    Pris = lengde * 5,
                    DatoTur = ny.dato,
                    DatoRetur = ny.datoTilbake,
                    Telefonnummer = Telefonnummer,
                    Email = Email,
                    Kortnummer = kortnummer,
                    Cvc = Cvc
                };
                db.Billeter.Add(bnyBi);


            }

            db.SaveChanges();

            return View();

        }








    }







}







