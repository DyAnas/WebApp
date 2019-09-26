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
       
          
            var stasjoner = new List<Stasjon>
            {
                new Stasjon{StasjonId=10,StasjonNavn="Oslo"},
                new Stasjon{StasjonId=11,StasjonNavn="Bergen"},
                new Stasjon{StasjonId=12,StasjonNavn="trondheim"}
                

            };
            stasjoner.ForEach(st => context.Stasjoner.Add(st));
            context.SaveChanges();

            var avganger = new List<Avgang>
            {
                new Avgang{AvgangId=1,
                           AvgangTid = new TimeSpan(1,30,00),
                           Dato =new DateTime(2019,9,1),
                           TogId =1,
                           Stasjon =stasjoner[0]},
                new Avgang{AvgangId=2,
                           AvgangTid = new TimeSpan(2,30,00),
                           Dato =new DateTime(2019,9,1),
                           TogId =1,Stasjon=stasjoner[1]},
              


            };
            avganger.ForEach(av => context.Avganger.Add(av));
            context.SaveChanges();

            var togListe = new List<Tog>
            {
                new Tog{TogId=3,TogNavn="Oslo_Bergen",Avganger=avganger},
                new Tog{TogId=4, TogNavn="Bergen_Oslo"},
                new Tog{TogId=5,TogNavn="Bergen_Trondheim"}

            };

            togListe.ForEach(t => context.TogTabell.Add(t));
            context.SaveChanges();







            var billeter = new List<Billet>
            {
                new Billet{BilletId=1,Pris=200,Type="Student",fra=avganger[0],Til=avganger[1]},
               
            };
            billeter.ForEach(bi => context.Billeter.Add(bi));
            context.SaveChanges();










        }
    }
}