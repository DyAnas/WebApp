using System;
using System.ComponentModel.DataAnnotations;

namespace GruppeInnlevering1.Model
{
   




public class avgangs
{
    public int AvgangId { get; set; }
    [Required(ErrorMessage ="Feltet AvgangId er obligatorisk.")]
    [DataType(DataType.Time)]
    public TimeSpan Tid { get; set; }
    [Required(ErrorMessage = "Feltet Tid er obligatorisk.")]
    public int TogId { get; set; }
    [Required(ErrorMessage = "Feltet TogId er obligatorisk.")]
    public int StasjonId { get; set; }
    public StasjonV StasjonnavnFra { get; set; }

        public StasjonV StasjonnavnTil{ get; set; }

    }
}