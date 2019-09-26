using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
    public class Billet
    {
        public int BilletId { get; set; }

        public string Type { get; set; }

     

     


        public int Pris { get; set; }

        public virtual Avgang fra { get; set; }

        public virtual Avgang Til { get; set; }

       

     



    }
}