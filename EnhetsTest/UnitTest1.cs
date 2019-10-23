using System;
using System.Web.Mvc;
using GruppeInnlevering1.BLL;
using GruppeInnlevering1.Controllers;
using GruppeInnlevering1.DAL;
using GruppeInnlevering1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnhetsTest
{
    [TestClass]
    public class T
    {
        [TestMethod]
        public void Registrer()
        {
            var kontroller = new DefaultController(new TogBLL(new TogSub()));

            var actionRes = (ViewResult)  kontroller.Registrer();

            Assert.AreEqual(actionRes.ViewName, "");
        }

        // ikke ferdig spør hvordan skal vi teste den metoden 
        [TestMethod]
        public void Regirer_skjekk()
        {
            var kontroller = new DefaultController(new TogBLL(new TogSub()));
              
        
        }
        [TestMethod] 
        public void skjekkStasjon()
        {
            var kontroller = new DefaultController(new TogBLL(new TogSub()));
// ikke ferdig 
          //   var actionRes = (StasjonV)kontroller.Stasjoner();
            var forventstasjon = new StasjonV()
            {
                StasjonId = 1,
                StasjonNavn = "Oslo"
            };

        }

    }
}
