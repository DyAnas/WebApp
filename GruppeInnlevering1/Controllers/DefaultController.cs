using GruppeInnlevering1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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


        public ActionResult Index()
        {
         


                IEnumerable<Stasjon> stasjoner = db.Stasjoner;



                return View(stasjoner);
          
            
        }

        public ActionResult Result()
        {



            return View();
        }

        public ActionResult Bekrefte()
        {



            return View();
        }

       
    }
}

        
