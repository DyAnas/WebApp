using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
  
    public class Samle
    {

        public IEnumerable<Stasjon> fraListe { get; set; }
        public IEnumerable<Stasjon> tilListe{ get; set; }

        public Stasjon Fra { get; set; }

        public Stasjon Til { get; set; }

        public TimeSpan tid { get; set; }

        public DateTime dato { get; set; }

        public string Type { get; set; }

        public int antall { get; set; }


    }
}