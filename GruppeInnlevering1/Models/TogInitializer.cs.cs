using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
    public class TogInitializer : System.Data.Entity.DropCreateDatabaseAlways<TogContext>
    {
        protected override void Seed(TogContext context)
        {
            

            var togListe = new List<Tog>
            {
            new Tog{TogNavn = "Oslo_Skien"},
             new Tog{TogNavn = "Oslo_Skien2"},

            new Tog{TogNavn = "TrondHeim_Bødo"},
            new Tog{TogNavn = "TrondHeim_Bødo2"},
            new Tog{TogNavn = "Oslo_Trondheim"},
            new Tog{TogNavn = "Oslo_Trondheim2"}
            };
            togListe.ForEach(tog => context.TogTabell.Add(tog));
            context.SaveChanges();


            var stasjonerTilTog12 =new List<Stasjon>
            {
                new Stasjon {StasjonNavn = "Oslo" },
                new Stasjon {StasjonNavn = "Drammen"},
                new Stasjon {StasjonNavn = "Holmenstrand"},
                new Stasjon {StasjonNavn = "TønesBerg"},
                new Stasjon {StasjonNavn = "Sandfjord"},
                new Stasjon {StasjonNavn = "Larvik" },
                new Stasjon {StasjonNavn ="Porskrun"},
                new Stasjon {StasjonNavn = "Skien"}
               
            };
            stasjonerTilTog12.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();
            var stasjonerTilTog23 = new List<Stasjon>
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

            stasjonerTilTog23.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();

            var stasjonerTilTog45 = new List<Stasjon>
            {
                new Stasjon {StasjonNavn = "Lillestrøm" },
                new Stasjon {StasjonNavn = "Gardermoen"},
                new Stasjon {StasjonNavn = "Eidsvoll"},
                new Stasjon {StasjonNavn = "Elverum"},
                new Stasjon {StasjonNavn = "Koppang"},
                new Stasjon {StasjonNavn = "Tynset" },
                new Stasjon {StasjonNavn ="Rødros"},
                new Stasjon {StasjonNavn = "Trondheim"}

            };

            stasjonerTilTog45.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();




            var avganger1 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stasjonerTilTog12[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stasjonerTilTog12[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stasjonerTilTog12[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stasjonerTilTog12[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stasjonerTilTog12[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stasjonerTilTog12[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stasjonerTilTog12[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stasjonerTilTog12[7]},
            };


            var avganger12 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stasjonerTilTog12[0]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stasjonerTilTog12[1]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stasjonerTilTog12[2]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stasjonerTilTog12[3]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stasjonerTilTog12[4]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stasjonerTilTog12[5]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stasjonerTilTog12[6]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stasjonerTilTog12[7]},
            };

            togListe[0].Avganger = avganger1;
            togListe[1].Avganger = avganger12;




            var avganger2 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stasjonerTilTog23[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stasjonerTilTog23[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stasjonerTilTog23[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stasjonerTilTog23[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stasjonerTilTog23[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stasjonerTilTog23[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stasjonerTilTog23[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stasjonerTilTog23[7]},
            };

            var avganger23 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stasjonerTilTog23[0]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stasjonerTilTog23[1]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stasjonerTilTog23[2]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stasjonerTilTog23[3]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stasjonerTilTog23[4]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stasjonerTilTog23[5]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stasjonerTilTog23[6]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stasjonerTilTog23[7]},
            };
            togListe[2].Avganger = avganger2;
            togListe[3].Avganger = avganger23;
            context.SaveChanges();


            var avganger31 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stasjonerTilTog45[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stasjonerTilTog45[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stasjonerTilTog45[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stasjonerTilTog45[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stasjonerTilTog45[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stasjonerTilTog45[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stasjonerTilTog45[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stasjonerTilTog45[7]},
            };

            var avganger32= new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(17,00,00),Stasjon=stasjonerTilTog45[0]},
                new Avgang{Tid= new TimeSpan(18,00,00),Stasjon=stasjonerTilTog45[1]},
                new Avgang{Tid= new TimeSpan(19,00,00),Stasjon=stasjonerTilTog45[2]},
                new Avgang{Tid= new TimeSpan(20,00,00),Stasjon=stasjonerTilTog45[3]},
                new Avgang{Tid= new TimeSpan(21,00,00),Stasjon=stasjonerTilTog45[4]},
                new Avgang{Tid= new TimeSpan(22,00,00),Stasjon=stasjonerTilTog45[5]},
                new Avgang{Tid= new TimeSpan(23,00,00),Stasjon=stasjonerTilTog45[6]},
                new Avgang{Tid= new TimeSpan(00,00,00),Stasjon=stasjonerTilTog45[7]},
            };
            togListe[4].Avganger = avganger31;
            togListe[5].Avganger = avganger32;


            context.SaveChanges();
            base.Seed(context);
















































        }
    }
}