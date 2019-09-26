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
        // GET: Default
        public ActionResult Index()
        {


            TogContext db = new TogContext();

            
            db.SaveChanges();
            return View();
        }
    }
}