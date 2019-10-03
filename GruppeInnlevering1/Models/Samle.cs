using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
  public class TypeogAntall
    {
      public  string type { get; set; }
      public int antall { get; set; }
    }
    public class Samle
    {

        public IEnumerable<Stasjon> fraListe { get; set; }
        public IEnumerable<Stasjon> tilListe{ get; set; }

        public string Fra { get; set; }

        public string Til { get; set; }

        public TimeSpan tid { get; set; }

        public DateTime dato { get; set; }

      public List<TypeogAntall> typeogantall { get; set; }
        


    }
}