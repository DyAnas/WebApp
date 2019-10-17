using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime? datoTilbake { get; set; }
        public int antall1 { get; set; }
        public int antall2 { get; set; }
        public int antall3 { get; set; }
        public string StudentType { get; set; }
        public string BarnType { get; set; }
        public string VoksenType { get; set; }
        public int pris { get; set; }
        public int stasjonIdFra { get; set; }
        public int stasjonIdTil { get; set; }


        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Du må skrive ned Telefonummer")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"[0-9]{8}")]
        public string Telefonnummer { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email må oppgis")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Kortnummer")]
        [Required(ErrorMessage = "Kortnummer må oppgis (16 Tall)")]
        [RegularExpression(@"[0-9]{16}")]
        public string Kortnummer { get; set; }

        [Display(Name = "CVC")]
        [Required(ErrorMessage = "CVC må oppgis (3 Tall)")]
        [RegularExpression(@"[0-9]{3}")]
        public int Cvc { get; set; }



    }
}