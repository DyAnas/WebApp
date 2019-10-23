
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GruppeInnlevering1.Models
{
  

public class TogV
{

    public int TogId { get; set; }

    [Required(ErrorMessage = "Feltet Tognavn er obligatorisk")]
    public string TogNavn { get; set; }

}

}

