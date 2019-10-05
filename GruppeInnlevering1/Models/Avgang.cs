using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
    public class Avgang
    {
        public int AvgangId { get; set; }

        public TimeSpan Tid { get; set; }



        public virtual Tog Tog { get; set; }

        public virtual Stasjon Stasjon { get; set; }

       



    }
}