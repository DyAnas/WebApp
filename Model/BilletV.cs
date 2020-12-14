using System;


namespace GruppeInnlevering1.Model
{
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
        public string gyldig { get; set; }
    }
}