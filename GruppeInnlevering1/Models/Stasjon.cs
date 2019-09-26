using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
    public class Stasjon
    {

        public int StasjonId { get; set; }

        public String StasjonNavn { get; set; }


        public virtual List<Avgang> Avganger { get; set; }



    }
}