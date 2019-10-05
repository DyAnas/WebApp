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
        public IEnumerable<Stasjon> tilListe { get; set; }

        public string Fra { get; set; }

        public string Til { get; set; }

        public TimeSpan tidFra { get; set; }

        public TimeSpan tidTil { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime dato { get; set; }

        public int antall1 { get; set; }
        public int antall2 { get; set; }

        public int antall3 { get; set; }

        public string StudentType { get; set; }
        public string BarnType { get; set; }
        public string VoksenType { get; set; }

        public int pris { get; set; }

        public int stasjonIdFra { get; set; }

        public int stasjonIdTil { get; set; }



    }
}