using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
    public class Tog
    {
        public int TogId { get; set; }

        public string TogNavn { get; set; }

        public virtual List<Avgang> Avganger { get; set; }
    }
}