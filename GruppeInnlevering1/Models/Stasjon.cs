using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GruppeInnlevering1.Models
{
    public class Stasjon
    {

        public int StasjonId { get; set; }
        [Required]
        public string StasjonNavn { get; set; }
        public virtual List<Avgang> Avganger { get; set; }

    }
}

public class StasjonV
{

    public int StasjonId { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
     ErrorMessage = "sjekk om du skriver Stasjonnavn riktig.")]
   
    public string StasjonNavn { get; set; }


}