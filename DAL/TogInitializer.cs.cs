
using System;
using System.Collections.Generic;

namespace GruppeInnlevering1.DAL
{
    public class TogInitializer : System.Data.Entity.DropCreateDatabaseAlways<TogContext>
    {
        protected override void Seed(TogContext context)
        {
            //i vår databasen har vi flere tog og hvert tog har sine stasjoner 

            var togListe = new List<Tog>
            {
            new Tog{TogNavn = "Oslo_Skien"},
            new Tog{TogNavn = "Oslo_Skien2"},
            new Tog{TogNavn = "Oslo_Skien2Retur"},
            new Tog{TogNavn = "TrondHeim_Bødo"},
            new Tog{TogNavn = "TrondHeim_Bødo2"},
            new Tog{TogNavn="Bødo_Trondheim"},
            new Tog{TogNavn = "Oslo_Trondheim"},
            new Tog{TogNavn = "Oslo_Trondheim2"},
            new Tog{TogNavn = "TrondHeim_OsloRetur"}
            };
            togListe.ForEach(tog => context.TogTabell.Add(tog));
            context.SaveChanges();


            var stasjonerOsloSkien = new List<Stasjon>
            {
                new Stasjon {StasjonNavn = "Oslo" },
                new Stasjon {StasjonNavn = "Drammen"},
                new Stasjon {StasjonNavn = "Holmestrand"},
                new Stasjon {StasjonNavn = "Tønsberg"},
                new Stasjon {StasjonNavn = "Sandefjord"},
                new Stasjon {StasjonNavn = "Larvik" },
                new Stasjon {StasjonNavn ="Porsgrunn"},
                new Stasjon {StasjonNavn = "Skien"}

            };
            stasjonerOsloSkien.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();
            var stajonerTrondheimBødo = new List<Stasjon>
            {
                new Stasjon {StasjonNavn = "Verdal" },
                new Stasjon {StasjonNavn = "Værnes"},
                new Stasjon {StasjonNavn = "Stjørdal"},
                new Stasjon {StasjonNavn = "Steinkjær"},
                new Stasjon {StasjonNavn = "Mosjøen"},
                new Stasjon {StasjonNavn = "Mo i Rana" },
                new Stasjon {StasjonNavn ="Fauske"},
                new Stasjon {StasjonNavn = "Bodø"}

            };

            stajonerTrondheimBødo.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();

            var stajonerOslotrondheim = new List<Stasjon>
            {
                new Stasjon {StasjonNavn = "Lillestrøm" },
                new Stasjon {StasjonNavn = "Gardermoen"},
                new Stasjon {StasjonNavn = "Eidsvoll"},
                new Stasjon {StasjonNavn = "Elverum"},
                new Stasjon {StasjonNavn = "Koppang"},
                new Stasjon {StasjonNavn = "Tynset" },
                new Stasjon {StasjonNavn ="Røros"},
                new Stasjon {StasjonNavn = "Trondheim"}

            };

            stajonerOslotrondheim.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();


            //avganger Til Tog1 oslo_Skien tur

            var avgangerTilTog1 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stasjonerOsloSkien[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stasjonerOsloSkien[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stasjonerOsloSkien[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stasjonerOsloSkien[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stasjonerOsloSkien[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stasjonerOsloSkien[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stasjonerOsloSkien[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stasjonerOsloSkien[7]},
            };

            //avganger Til Tog2 oslo_Skien tur

            var avgangerTilTog2 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stasjonerOsloSkien[0]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stasjonerOsloSkien[1]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stasjonerOsloSkien[2]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stasjonerOsloSkien[3]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stasjonerOsloSkien[4]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stasjonerOsloSkien[5]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stasjonerOsloSkien[6]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stasjonerOsloSkien[7]},
            };

            //avganger Til Tog3  Skien_oslo  Retur
            var avgangerTilTog3 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stasjonerOsloSkien[7]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stasjonerOsloSkien[6]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stasjonerOsloSkien[5]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stasjonerOsloSkien[4]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stasjonerOsloSkien[3]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stasjonerOsloSkien[2]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stasjonerOsloSkien[1]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stasjonerOsloSkien[0]},
            };

            togListe[0].Avganger = avgangerTilTog1;
            togListe[1].Avganger = avgangerTilTog2;
            togListe[2].Avganger = avgangerTilTog3;




            var avgangerTilTog4 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stajonerTrondheimBødo[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stajonerTrondheimBødo[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stajonerTrondheimBødo[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stajonerTrondheimBødo[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stajonerTrondheimBødo[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stajonerTrondheimBødo[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stajonerTrondheimBødo[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stajonerTrondheimBødo[7]},
            };

            var avgangerTilTog5 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stajonerTrondheimBødo[0]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stajonerTrondheimBødo[1]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stajonerTrondheimBødo[2]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stajonerTrondheimBødo[3]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stajonerTrondheimBødo[4]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stajonerTrondheimBødo[5]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stajonerTrondheimBødo[6]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stajonerTrondheimBødo[7]},
            };
            var avgangerTilTog6 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stajonerTrondheimBødo[7]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stajonerTrondheimBødo[6]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stajonerTrondheimBødo[5]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stajonerTrondheimBødo[4]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stajonerTrondheimBødo[3]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stajonerTrondheimBødo[2]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stajonerTrondheimBødo[1]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stajonerTrondheimBødo[0]},
            };





            togListe[3].Avganger = avgangerTilTog4;
            togListe[4].Avganger = avgangerTilTog5;
            togListe[5].Avganger = avgangerTilTog6;
            context.SaveChanges();


            var avgangerTilTog7 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stajonerOslotrondheim[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stajonerOslotrondheim[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stajonerOslotrondheim[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stajonerOslotrondheim[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stajonerOslotrondheim[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stajonerOslotrondheim[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stajonerOslotrondheim[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stajonerOslotrondheim[7]},
            };

            var avgangerTilTog8 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stajonerOslotrondheim[0]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stajonerOslotrondheim[1]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stajonerOslotrondheim[2]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stajonerOslotrondheim[3]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stajonerOslotrondheim[4]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stajonerOslotrondheim[5]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stajonerOslotrondheim[6]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stajonerOslotrondheim[7]},
            };

            var avgangerTilTog9 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stajonerOslotrondheim[7]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stajonerOslotrondheim[6]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stajonerOslotrondheim[5]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stajonerOslotrondheim[4]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stajonerOslotrondheim[3]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stajonerOslotrondheim[2]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stajonerOslotrondheim[1]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stajonerOslotrondheim[0]},
            };



            togListe[6].Avganger = avgangerTilTog7;
            togListe[7].Avganger = avgangerTilTog8;
            togListe[8].Avganger = avgangerTilTog9;



            context.SaveChanges();
            base.Seed(context);


          /*  var billett = new List <Billett>
            {
                new Billett{ BilletId=1, AvgangFra="Oslo", AvgangTil ="Drammen",
                             DatoRetur =""}
            }*/
          












































        }
    }
}