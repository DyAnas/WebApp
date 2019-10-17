using System;
using System.ComponentModel.DataAnnotations;

namespace GruppeInnlevering1.Models
{
    public class Billet
    {
        public int BilletId { get; set; }
        public string Type { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime DatoTur { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime? DatoRetur { get; set; }
        public int Pris { get; set; }
        public int AvgangFra { get; set; }
        public int AvgangTil { get; set; }
        public string Telefonnummer { get; set; }
        public string Email { get; set; }
        public string Kortnummer { get; set; }
        public int Cvc { get; set; }









    }
}


public class BilletV
{

    public int BilletId { get; set; }
    public string Type { get; set; }
  
    public DateTime DatoTur { get; set; }
 
    public DateTime? DatoRetur { get; set; }
    public int Pris { get; set; }
    public int AvgangFra { get; set; }
    public int AvgangTil { get; set; }
    public string Telefonnummer { get; set; }
    public string Email { get; set; }
    public string Kortnummer { get; set; }
    public int Cvc { get; set; }





}