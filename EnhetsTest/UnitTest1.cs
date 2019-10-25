

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GruppeInnlevering1.BLL;
using GruppeInnlevering1.Controllers;
using GruppeInnlevering1.DAL;
using GruppeInnlevering1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;

// spør om catshing har test
// spør hvordan skal vi teste den metoden 


namespace GruppeInnlevering1.EnhetsTest
{
    [TestClass]
    public class T
    {


        [TestMethod]
        public void skjekkloggetInn_session()
        {
            var kontroller = new DefaultController();
            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(kontroller);

            kontroller.Session["loggetInn"] = false;
            var res = (ViewResult)kontroller.Registrer();
            Assert.AreEqual("", res.ViewName);
            kontroller.Session["loggetInn"] = true;
            var res1 = (ViewResult)kontroller.Login();
            Assert.AreEqual("", res1.ViewName);
            // spør hvis vi skal teste følgende 
            /* 
             *       Session["feilStrekning"] = null;
                   Session["leggStasjon"] = null;
                   Session["togmelding"] = null;
                   Session["Feilpris"] = null;
                   Session["feilEndreAvgang"] = null;
             */





             /*
        }
        [TestMethod]
        public void skjekk_login_Admin_i_db()
        {
            var kontroller = new DefaultController(new TogBLL(new TogSub()));
            var admin = new Admin();

            var res = (ViewResult)kontroller.Login(admin);

            var res1 = (ViewResult)kontroller.Registrer();
            Assert.AreEqual(res.ViewName, "");
            Assert.AreEqual(res1.ViewName, "hei@gmail.com");
            Assert.AreEqual(true, res.ViewBag["Innlogget"]);

            Assert.AreEqual(true, res1.ViewBag["feillogg"]);
            Assert.AreEqual(false, res1.ViewBag["Innlogget"]);
        }

        [TestMethod]
        public void Registrer()
        {
            var kontroller = new DefaultController(new TogBLL(new TogSub()));

            var actionRes = (ViewResult)kontroller.Registrer();

            Assert.AreEqual(actionRes.ViewName, "");
        }

        [TestMethod]
        public void Registrer_skjekk()
        {
            var kontroller = new DefaultController(new TogBLL(new TogSub()));
            var innadmin = new Admin();

            innadmin.id = 1;
            innadmin.Email = "hei@gmail.com";
            innadmin.Fornavn = "Sara";
            innadmin.Etternavn = "Karlos";
            innadmin.passord = "hei";

            var res = (RedirectToRouteResult)kontroller.Registrer(innadmin);

            Assert.AreEqual(res.RouteName, "");
            Assert.AreEqual(res.RouteValues.Values.First(), "Registrer");
            var res1 = (ViewResult)kontroller.Registrer();
            Assert.AreEqual(res1.ViewName, "");
            Assert.AreEqual(true, res1.ViewBag["Innlogget"]);

        }
        [TestMethod]
        public void skjekk_billeter_liste()
        {
            var kontroller = new DefaultController(new TogBLL(new TogSub()));
            var res = (ViewResult)kontroller.Billter();
            Assert.AreEqual(res.ViewName, "");
            Assert.AreEqual(true, res.ViewBag["Innlogget"]);


            DateTime retur = new DateTime(2020, 1, 1);
            DateTime tur = new DateTime(2019, 11, 1);
            var forventres = new List<BilletV>();
            var billett = new BilletV()
            {
                AvgangFra = 1,
                AvgangTil = 2,
                BilletId = 1,
                Cvc = 123,
                DatoRetur = retur,
                DatoTur = tur,
                Email = "perhansen@gmail.com",
                gyldig = "ja",
                Kortnummer = "1234567890123456",
                Pris = 12,
                Telefonnummer = "12345678",
                Type = "Student"

            };
            forventres.Add(billett);
            forventres.Add(billett);
            forventres.Add(billett);

            var resultatlist = (List<BilletV>)res.Model;

            Assert.AreEqual(res.ViewName, "");

            for (var i = 0; i < resultatlist.Count; i++)
            {

                Assert.AreEqual(forventres[i].BilletId, resultatlist[i].BilletId);
                Assert.AreEqual(forventres[i].AvgangFra, resultatlist[i].AvgangFra);
                Assert.AreEqual(forventres[i].AvgangTil, resultatlist[i].AvgangTil);
                Assert.AreEqual(forventres[i].Cvc, resultatlist[i].Cvc);
                Assert.AreEqual(forventres[i].DatoRetur, resultatlist[i].DatoRetur);
                Assert.AreEqual(forventres[i].DatoTur, resultatlist[i].DatoTur);
                Assert.AreEqual(forventres[i].Email, resultatlist[i].Email);
                Assert.AreEqual(forventres[i].gyldig, resultatlist[i].gyldig);
                Assert.AreEqual(forventres[i].Kortnummer, resultatlist[i].Kortnummer);
                Assert.AreEqual(forventres[i].Pris, resultatlist[i].Pris);
            }


        }
        [TestMethod]
        public void skjekk_billeter_slett()
        {
            var kontroller = new DefaultController(new TogBLL(new TogSub()));
            var Actres = (ViewResult)kontroller.SlettBillett(1);
            var res = (RedirectToRouteResult)kontroller.Billter();

            Assert.AreEqual(res.RouteName, "");
            Assert.AreEqual(res.RouteValues.First(), "Billter");
        }



    }
}
*/