using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GruppeInnlevering1.Models
{
    public class Tog
    {
        public int TogId { get; set; }
        [Required]
        public string TogNavn { get; set; }
        public virtual List<Avgang> Avganger { get; set; }
    }
}

public class TogV
{

    public int TogId { get; set; }

    [Required(ErrorMessage ="Feltet Tognavn er obligatorisk")]
    public string TogNavn { get; set; }

}


