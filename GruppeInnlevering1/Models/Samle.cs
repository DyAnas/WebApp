using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{

    public class Samle
    {

        public IEnumerable<Stasjon> fraListe { get; set; }
        public IEnumerable<Stasjon> tilListe{ get; set; }

        public string Fra { get; set; }

        public string Til { get; set; }

        public TimeSpan tidFra { get; set; }

        public TimeSpan tidTil { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime dato { get; set; }

      public string antall1{ get; set; }
      public string antall2 { get; set; }

        public string  antall3 { get; set; }
        


    }
}