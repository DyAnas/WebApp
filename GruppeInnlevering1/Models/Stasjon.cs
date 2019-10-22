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
    [Required(ErrorMessage ="Feltet Stasjonnavn er obligatorisk")]
  
   
    public string StasjonNavn { get; set; }


}