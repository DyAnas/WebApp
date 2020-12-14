using GruppeInnlevering.Controllers;
using GruppeInnlevering1.BLL;
using GruppeInnlevering1.DAL;
using GruppeInnlevering1.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;




namespace GruppeInnlevering1.EnhetsTest
{
    [TestClass]
    public class T
    {

        [TestMethod]
        public void login1Test()
        {
        
            var kontroller = new DefaultController();
            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(kontroller);

            kontroller.Session["loggetInn"] = null;
            var res = (ViewResult)kontroller.Login();
            Assert.AreEqual("Registrer", res.ViewName);
            Assert.AreEqual(false, res.ViewData["Innlogget"]);
            Assert.AreEqual(true, res.ViewData["feillogg"]);

        }






        [TestMethod]
        public void Login1TestLogget()
        {   
            var kontroller = new DefaultController();
            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(kontroller);

            kontroller.Session["loggetInn"] = true;
            kontroller.Session["feilStrekning"] = null;
            kontroller.Session["leggStasjon"] = null;
            kontroller.Session["togmelding"] = null;
            kontroller.Session["Feilpris"] = null;
            kontroller.Session["feilEndreAvgang"] = null;
            var res = (ViewResult)kontroller.Login();
            Assert.AreEqual("", res.ViewName);
            Assert.AreEqual(true, res.ViewData["Innlogget"]);



        }


        [TestMethod]
        public void LoginPostTestElse()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var sessionMock = new TestControllerBuilder();


            sessionMock.InitializeController(kontroller);
            var admin = new Admin();
            admin.Email = "";
            var res = (ViewResult)kontroller.Login(admin);
            var result = (ViewResult)kontroller.Login(admin);
            kontroller.Session["loggetInn"] = false;

            Assert.AreEqual("Registrer", res.ViewName);
            Assert.AreEqual(false, res.ViewData["Innlogget"]);
            Assert.AreEqual(true, res.ViewData["feillogg"]);
            Assert.AreEqual("Registrer", result.ViewName);
        }



        [TestMethod]

        public void LoginPostTestIf()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var sessionMock = new TestControllerBuilder();


            sessionMock.InitializeController(kontroller);
            var admin = new Admin()
            {
                Email = "asdasd@gmail.com"
            };

            var res = (ViewResult)kontroller.Login(admin);

            kontroller.Session["loggetInn"] = true;

            Assert.AreEqual("", res.ViewName);
            Assert.AreEqual(true, res.ViewData["Innlogget"]);


        }

        [TestMethod]

        public void RegistrerTest()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var sessionMock = new TestControllerBuilder();
            sessionMock.InitializeController(kontroller);
            kontroller.Session["loggetInn"] = false;
            var res = (ViewResult)kontroller.Registrer();
            Assert.AreEqual(res.ViewName, "");
            Assert.AreEqual(false, res.ViewData["Innlogget"]);

        }



        [TestMethod]

        public void RegistrerTestPostOK()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var innAdmin = new Admin()
            {
                Email = "asdasda@gmail.com",
                Fornavn = "Saso",
                Etternavn = "Naso",
                id = 123213,
                passord = "2asdasdas"
            };
            var result = (RedirectToRouteResult)kontroller.Registrer(innAdmin);
            Assert.AreEqual(result.RouteValues.Values.First(), "Registrer");

        }

        [TestMethod]

        public void RegistrerTestPostFeil()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var innAdmin = new Admin();
            innAdmin.Email = "";

            var result = (ViewResult)kontroller.Registrer(innAdmin);

            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(true, result.ViewData["EmailFeil"]);

        }

        [TestMethod]

        public void AvgangerList()
        {
            var controller1 = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller1);
            var forventetResultat1 = new List<avgangs>();
            TimeSpan s = new TimeSpan(10, 1, 2);
            var avgang = new avgangs()
            {
                AvgangId = 1,
                Tid = s,
                StasjonId = 3,
                TogId = 1
            };
            forventetResultat1.Add(avgang);
            forventetResultat1.Add(avgang);
            forventetResultat1.Add(avgang);

            var resultat1 = (ViewResult)controller1.Avganger();
            var resultatList1 = (List<avgangs>)resultat1.Model;
            controller1.Session["loggetInn"] = true;
            //Assert
            Assert.AreEqual(resultat1.ViewName, "");
            Assert.AreEqual(true, resultat1.ViewData["Innlogget"]);
            Assert.AreEqual(null, resultat1.ViewData["FeilStrekning"]);

            for (var i = 0; i < resultatList1.Count; i++)
            {
                Assert.AreEqual(forventetResultat1[i].AvgangId, resultatList1[i].AvgangId);
                Assert.AreEqual(forventetResultat1[i].Tid, resultatList1[i].Tid);
                Assert.AreEqual(forventetResultat1[i].StasjonId, resultatList1[i].StasjonId);
                Assert.AreEqual(forventetResultat1[i].TogId, resultatList1[i].TogId);
            }
        }

        [TestMethod]
        public void EndreAvgang()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(kontroller);
            kontroller.Session["loggetInn"] = true;
            var res = (ViewResult)kontroller.EndreAvgang(1);
            Assert.AreEqual(true, res.ViewData["Innlogget"]);
            Assert.AreEqual(res.ViewName, "");
        }

        [TestMethod]
        public void EndreAvgangPostFeil()
        {
       
            var controller2 = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller2);
            controller2.Session["loggetInn"] = true;
            var avgang = new avgangs();
            avgang.AvgangId = 0;
            //Act
            var resultat2 = (ViewResult)controller2.EndreAvgang(avgang);
            //Assert
            Assert.AreEqual(resultat2.ViewName, "");
            Assert.AreEqual(true, resultat2.ViewData["Innlogget"]);
        }

        [TestMethod]
        public void EndreAvgangPostOk()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(kontroller);

            kontroller.Session["feilStrekning"] = false;
            kontroller.Session["loggetInn"] = true;
            TimeSpan s = new TimeSpan(10, 1, 2);
            var avgang = new avgangs()
            {
                AvgangId = 2,
                Tid = s,
                StasjonId = 3,
                TogId = 1

            };

            var res = (RedirectToRouteResult)kontroller.EndreAvgang(avgang);
            Assert.AreEqual(res.RouteName, "");
            Assert.AreEqual(res.RouteValues.Values.First(), "Avganger");
        }



        [TestMethod]
        public void SlettAvgang()
        {

            var controller6 = new DefaultController(new TogLogikk(new Togstub()));
            avgangs s = new avgangs();
            s.AvgangId = 1;

            var resultat6 = (RedirectToRouteResult)controller6.SlettAvgang(s.AvgangId);

            Assert.AreEqual(resultat6.RouteName, "");
            Assert.AreEqual(resultat6.RouteValues.Values.First(), "Avganger");
        }
        [TestMethod]
        public void SlettAvgangerFeil()
        {

         
            //Arrange
            var controller7 = new DefaultController(new TogLogikk(new Togstub()));
            var avgang = new avgangs();
            avgang.AvgangId = 0;
            //Act
            var ActionResult = (ViewResult)controller7.SlettAvgang(avgang.AvgangId);
            //Assert
            Assert.AreEqual(ActionResult.ViewName, "");
        }



        [TestMethod]
        public void nyAvgang()
        {

            var SessionMock = new TestControllerBuilder();
            var controller = new DefaultController();
            SessionMock.InitializeController(controller);
            controller.Session["loggetInn"] = true;
            var res = (ViewResult)controller.nyAvgang();
            Assert.AreEqual(res.ViewName, "");
            Assert.AreEqual(true, res.ViewData["Innlogget"]);
        }
        [TestMethod]
        public void nyAvgangPostOk()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new DefaultController(new TogLogikk(new Togstub()));
            SessionMock.InitializeController(controller);
            TimeSpan s = new TimeSpan(10, 1, 2);
            var avgang = new avgangs()
            {
                AvgangId = 1,
                Tid = s,
                StasjonId = 3,
                TogId = 1
            };
            //Act
            controller.Session["FeilStrekning"] = null;
            var resultat = (RedirectToRouteResult)controller.nyAvgang(avgang);

            //Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Avganger");

        }

        [TestMethod]
        public void nyAvgangPostFeil()
        {
         
            var controller = new DefaultController(new TogLogikk(new Togstub()));

            var avgang = new avgangs();
            avgang.AvgangId = 0;
            var resultat = (ViewResult)controller.nyAvgang(avgang);
            //Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(true, resultat.ViewData["FeilStrekning"]);

        }


        [TestMethod]
        public void Stasjoner()
        {
            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();
            SessionMock.InitializeController(kontroller);
            kontroller.Session["loggetInn"] = true;

            var forventrsultat = new List<StasjonV>();
            var stasjon = new StasjonV
            {
                StasjonId = 1,
                StasjonNavn = "Oslo"
            };
            forventrsultat.Add(stasjon);
            forventrsultat.Add(stasjon);
            forventrsultat.Add(stasjon);

            var resultat = (ViewResult)kontroller.Stasjoner();
            var resultatlist = (List<StasjonV>)resultat.Model;

            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(true, resultat.ViewData["Innlogget"]);

            for (var i = 0; i < resultatlist.Count; i++)
            {
                Assert.AreEqual(forventrsultat[i].StasjonId, resultatlist[i].StasjonId);
                Assert.AreEqual(forventrsultat[i].StasjonNavn, resultatlist[i].StasjonNavn);
            }

        }

        [TestMethod]
        public void EndreStasjon()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(kontroller);
            kontroller.Session["loggetInn"] = true;
            var res = (ViewResult)kontroller.EndreStasjon(1);
            Assert.AreEqual(true, res.ViewData["Innlogget"]);
            Assert.AreEqual(res.ViewName, "");
        }

        [TestMethod]
        public void EndreStasjonPostOk()
        {
            var kontroller = new DefaultController(new TogLogikk(new Togstub()));

            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(kontroller);


            kontroller.Session["loggetInn"] = true;
            kontroller.Session["leggStasjon"] = true;


            var stasjon = new StasjonV()
            {
                StasjonId = 1,
                StasjonNavn = "Oslo"

            };

            var res = (RedirectToRouteResult)kontroller.EndreStasjon(stasjon);
            Assert.AreEqual(res.RouteName, "");

            Assert.AreEqual(res.RouteValues.Values.First(), "Stasjoner");

        }

        [TestMethod]
        public void EndreStasjonPostFeil()
        {
           
            var controller2 = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller2);
            controller2.Session["loggetInn"] = true;
            controller2.Session["leggStasjon"] = false;
            var stasjon = new StasjonV();
            stasjon.StasjonId = 0;
     
            var res = (RedirectToRouteResult)controller2.EndreStasjon(stasjon);
            Assert.AreEqual(res.RouteName, "");
            Assert.AreEqual(res.RouteValues.Values.First(), "Stasjoner");

        }

        [TestMethod]
        public void SlettStasjon()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var stasjon = new StasjonV()
            {
                StasjonId = 1,
                StasjonNavn = "Oslo"
            };

            var res = (RedirectToRouteResult)kontroller.SlettStasjon(stasjon.StasjonId);
            Assert.AreEqual(res.RouteName, "");
            Assert.AreEqual(res.RouteValues.Values.First(), "Stasjoner");

        }

        [TestMethod]
        public void SlettStasjonFeil()
        {

            var kontroller = new DefaultController(new TogLogikk(new Togstub()));
            var stasjon = new StasjonV();
            stasjon.StasjonId = 0;
            var result = (ViewResult)kontroller.SlettStasjon(stasjon.StasjonId);
            Assert.AreEqual(result.ViewName, "Login");
        }



        [TestMethod]
        public void nyStasjon()
        {
         
            var SessionMock = new TestControllerBuilder();
            var controller = new DefaultController();
            SessionMock.InitializeController(controller);
            controller.Session["loggetInn"] = true;
            var result = (ViewResult)controller.nyStasjon();
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(true, result.ViewData["Innlogget"]);
            Assert.AreEqual(true, result.ViewData["leggStasjon"]);

        }



        [TestMethod]
        public void nyStasjonPostOk()
        {

            var controller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller);
            controller.Session["leggStasjon"] = null;
            var stasjon = new StasjonV()
            {
                StasjonId = 1,
                StasjonNavn = "Oslo"

            };
            var resultat = (RedirectToRouteResult)controller.nyStasjon(stasjon);
          
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "Stasjoner");
        }

        [TestMethod]
        public void nyStasjonPostFeil()
        {
            var controller = new DefaultController(new TogLogikk(new Togstub()));
            var stasjon = new StasjonV();
            stasjon.StasjonNavn = "";
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller);
            var resultat = (ViewResult)controller.nyStasjon(stasjon);

            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(false, resultat.ViewData["leggStasjon"]);
            Assert.AreEqual(true, resultat.ViewData["Innlogget"]);
        }

        [TestMethod]
        public void BilletterList()
        {

            DateTime retur = new DateTime(2020, 1, 1);
            DateTime tur = new DateTime(2019, 11, 1);
            var controller12 = new DefaultController(new TogLogikk(new Togstub()));
            var forventetResultat12 = new List<BilletV>();
            var alleBilletter = new BilletV()
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
            forventetResultat12.Add(alleBilletter);
            forventetResultat12.Add(alleBilletter);
            forventetResultat12.Add(alleBilletter);
            forventetResultat12.Add(alleBilletter);
          
            var resultat12 = (ViewResult)controller12.Billter();
            var resultatList12 = (List<BilletV>)resultat12.Model;
      
            Assert.AreEqual(resultat12.ViewName, "");
            Assert.AreEqual(true, resultat12.ViewData["Innlogget"]);
            for (var i = 0; i < resultatList12.Count; i++)
            {
                Assert.AreEqual(forventetResultat12[i].AvgangFra, resultatList12[i].AvgangFra);
                Assert.AreEqual(forventetResultat12[i].AvgangTil, resultatList12[i].AvgangTil);
                Assert.AreEqual(forventetResultat12[i].BilletId, resultatList12[i].BilletId);
                Assert.AreEqual(forventetResultat12[i].Cvc, resultatList12[i].Cvc);
                Assert.AreEqual(forventetResultat12[i].DatoRetur, resultatList12[i].DatoRetur);
                Assert.AreEqual(forventetResultat12[i].DatoTur, resultatList12[i].DatoTur);
                Assert.AreEqual(forventetResultat12[i].Email, resultatList12[i].Email);
                Assert.AreEqual(forventetResultat12[i].gyldig, resultatList12[i].gyldig);
                Assert.AreEqual(forventetResultat12[i].Kortnummer, resultatList12[i].Kortnummer);
                Assert.AreEqual(forventetResultat12[i].Pris, resultatList12[i].Pris);
                Assert.AreEqual(forventetResultat12[i].Telefonnummer, resultatList12[i].Telefonnummer);
                Assert.AreEqual(forventetResultat12[i].Type, resultatList12[i].Type);
            }
        }


        [TestMethod]
        public void SlettBillettOK()
        {

            var controller13 = new DefaultController(new TogLogikk(new Togstub()));
            var BilletId = 1;
            //Act
            var resultat13 = (RedirectToRouteResult)controller13.SlettBillett(BilletId);
            //Assert
            Assert.AreEqual(resultat13.RouteName, "");
            Assert.AreEqual(resultat13.RouteValues.Values.First(), "Billter");
        }
        [TestMethod]
        public void SlettBillettFeil()
        {

            var controller13 = new DefaultController(new TogLogikk(new Togstub()));
            BilletV b = new BilletV();
            b.BilletId = 0;
 
            var resultat13 = (ViewResult)controller13.SlettBillett(b.BilletId);

            Assert.AreEqual(resultat13.ViewName, "Login");
        }

        [TestMethod]
        public void TogListe1()
        {

            var controller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();


            SessionMock.InitializeController(controller);
            controller.Session["loggetInn"] = true;
            var forventetResultat = new List<TogV>();
            var togliste = new TogV()
            {
                TogId = 1,
                TogNavn = "Osloskien"
            };
            forventetResultat.Add(togliste);
            forventetResultat.Add(togliste);
            forventetResultat.Add(togliste);

            var resultat = (ViewResult)controller.TogListe();
            var resultatListe = (List<TogV>)resultat.Model;


            Assert.AreEqual(true, resultat.ViewData["Innlogget"]);

            for (var i = 0; i < resultatListe.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].TogId, resultatListe[i].TogId);
                Assert.AreEqual(forventetResultat[i].TogNavn, resultatListe[i].TogNavn);
            }
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(null, resultat.ViewData["leggtog"]);
        }

        [TestMethod]
        public void Endretog()
        {


            var SessionMock = new TestControllerBuilder();

            var controller = new DefaultController(new TogLogikk(new Togstub()));
            SessionMock.InitializeController(controller);
            controller.Session["loggetInn"] = true;
            //Act
            var result = (ViewResult)controller.EndreTog(1);

            //Assert
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(true, result.ViewData["Innlogget"]);
        }


        [TestMethod]
        public void EndretogPostOk()
        {

            var controller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller);

            controller.Session["togmelding"] = true;
            var tog = new TogV()
            {

                TogId = 1,
                TogNavn = "Osloskien"
            };
            //Act
            var resultat13 = (RedirectToRouteResult)controller.Endretog(tog);
            //Assert
            Assert.AreEqual(resultat13.RouteName, "");
            Assert.AreEqual(resultat13.RouteValues.Values.First(), "TogListe");

        }
        [TestMethod]
        public void EndretogPostFeil()
        {
            var controller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller);

            controller.Session["togmelding"] = false;
            var tog = new TogV();

            //Act
            var resultat13 = (RedirectToRouteResult)controller.Endretog(tog);
            //Assert
            Assert.AreEqual(resultat13.RouteName, "");
            Assert.AreEqual(resultat13.RouteValues.Values.First(), "Togliste");





        }


        [TestMethod]
        public void slettTogOk()
        {

            var controller13 = new DefaultController(new TogLogikk(new Togstub()));
            var tog = new TogV
            {
                TogId = 1,
                TogNavn = "Osloskien"

            };


            var resultat13 = (RedirectToRouteResult)controller13.SlettTog(tog.TogId);
            //Assert
            Assert.AreEqual(resultat13.RouteName, "");
            Assert.AreEqual(resultat13.RouteValues.Values.First(), "TogListe");
        }
        [TestMethod]
        public void slettTogFeil()
        {

            var controller13 = new DefaultController(new TogLogikk(new Togstub()));
            var tog = new TogV();



            var resultat13 = (ViewResult)controller13.SlettTog(tog.TogId);

            Assert.AreEqual(resultat13.ViewName, "Login");

        }


        [TestMethod]
        public void nyTog()
        {

            var SessionMock = new TestControllerBuilder();
            var controller = new DefaultController();
            SessionMock.InitializeController(controller);
            controller.Session["loggetInn"] = true;
            var res = (ViewResult)controller.nyTog();
            Assert.AreEqual(res.ViewName, "");
            Assert.AreEqual(true, res.ViewData["Innlogget"]);
        }


        [TestMethod]
        public void nyTogPostOk()
        {
            var controller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller);
            controller.Session["loggetInn"] = true;
            controller.Session["togmelding"] = true;
            var tog = new TogV();
            tog.TogNavn = "asdasd";


            var resultat13 = (RedirectToRouteResult)controller.nyTog(tog);
            //Assert
            Assert.AreEqual(resultat13.RouteName, "");
            Assert.AreEqual(resultat13.RouteValues.Values.First(), "TogListe");

        }
        [TestMethod]
        public void nyTogPostFeil()
        {
            var controller = new DefaultController(new TogLogikk(new Togstub()));
            var SessionMock = new TestControllerBuilder();

            SessionMock.InitializeController(controller);
            controller.Session["loggetInn"] = true;
            controller.Session["togmelding"] = true;
            var tog = new TogV();
            tog.TogNavn = "";


            var resultat = (ViewResult)controller.nyTog(tog);
            //Assert
            Assert.AreEqual(resultat.ViewName, "");

            Assert.AreEqual(true, resultat.ViewData["TogFinnes"]);

        }

    }
}

