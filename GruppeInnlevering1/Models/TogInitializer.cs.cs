using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
    public class TogInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TogContext>
    {
        protected override void Seed(TogContext context)
        {
            

            var togListe = new List<Tog>
            {
            new Tog{TogNavn = "Oslo_Skien"},
            new Tog{TogNavn = "TrondHeim_Bødo"},
            new Tog{TogNavn = "Oslo_Trondheim"}
            };
            togListe.ForEach(tog => context.TogTabell.Add(tog));
            context.SaveChanges();


            var stasjonerTilTog1 =new List<Stasjon>
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
            stasjonerTilTog1.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();
            var stasjonerTilTog2 = new List<Stasjon>
            {
                new Stasjon {StasjonNavn = "Trondheim" },
                new Stasjon {StasjonNavn = "Værnes"},
                new Stasjon {StasjonNavn = "Stjørdal"},
                new Stasjon {StasjonNavn = "Steinkjær"},
                new Stasjon {StasjonNavn = "Mosjøen"},
                new Stasjon {StasjonNavn = "Mo i Rana" },
                new Stasjon {StasjonNavn ="Fauske"},
                new Stasjon {StasjonNavn = "Bodø"}

            };

            stasjonerTilTog2.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();

            var stasjonerTilTog3 = new List<Stasjon>
            {
                new Stasjon {StasjonNavn = "Oslo" },
                new Stasjon {StasjonNavn = "Gardermoen"},
                new Stasjon {StasjonNavn = "Eidsvoll"},
                new Stasjon {StasjonNavn = "Elverum"},
                new Stasjon {StasjonNavn = "Koppang"},
                new Stasjon {StasjonNavn = "Tynset" },
                new Stasjon {StasjonNavn ="Rødros"},
                new Stasjon {StasjonNavn = "Trondheim"}

            };

            stasjonerTilTog3.ForEach(stasjon => context.Stasjoner.Add(stasjon));
            context.SaveChanges();




            var avganger1 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stasjonerTilTog1[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stasjonerTilTog1[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stasjonerTilTog1[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stasjonerTilTog1[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stasjonerTilTog1[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stasjonerTilTog1[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stasjonerTilTog1[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stasjonerTilTog1[7]},
            };

           foreach(Avgang av in avganger1){
                togListe[0].Avganger.Add(av);
            }
           
            context.SaveChanges();

            var avganger2 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stasjonerTilTog2[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stasjonerTilTog2[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stasjonerTilTog2[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stasjonerTilTog2[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stasjonerTilTog2[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stasjonerTilTog2[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stasjonerTilTog2[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stasjonerTilTog2[7]},
            };
            foreach (Avgang av in avganger2)
            {
                togListe[1].Avganger.Add(av);
            }
            context.SaveChanges();


            var avganger3 = new List<Avgang>
            {
                new Avgang{Tid= new TimeSpan(9,00,00),Stasjon=stasjonerTilTog3[0]},
                new Avgang{Tid= new TimeSpan(10,00,00),Stasjon=stasjonerTilTog3[1]},
                new Avgang{Tid= new TimeSpan(11,00,00),Stasjon=stasjonerTilTog3[2]},
                new Avgang{Tid= new TimeSpan(12,00,00),Stasjon=stasjonerTilTog3[3]},
                new Avgang{Tid= new TimeSpan(13,00,00),Stasjon=stasjonerTilTog3[4]},
                new Avgang{Tid= new TimeSpan(14,00,00),Stasjon=stasjonerTilTog3[5]},
                new Avgang{Tid= new TimeSpan(15,00,00),Stasjon=stasjonerTilTog3[6]},
                new Avgang{Tid= new TimeSpan(16,00,00),Stasjon=stasjonerTilTog3[7]},
            };
            foreach (Avgang av in avganger3)
            {
                togListe[2].Avganger.Add(av);
            }

            context.SaveChanges();
            base.Seed(context);
















































        }
    }
}