using System.Collections.Generic;

namespace GruppeInnlevering1.Models
{
    public class Stasjon
    {

        public int StasjonId { get; set; }
        public string StasjonNavn { get; set; }
        public virtual List<Avgang> Avganger { get; set; }

    }
}