

using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GruppeInnlevering1.Model
{
  

public class TogV
{

    public int TogId { get; set; }

    [Required(ErrorMessage = "Feltet Tognavn er obligatorisk")]
    public string TogNavn { get; set; }

}

}

