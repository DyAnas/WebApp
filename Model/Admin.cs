using System.ComponentModel.DataAnnotations;

namespace GruppeInnlevering1.Model
{
    public class Admin
    {


        public int id { get; set; }

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]


        public string Fornavn { get; set; }
        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string Etternavn { get; set; }
      
      // endre i passord til byte []  
        [Required(ErrorMessage = "Passord må oppgis")]
        public string passord { get; set; }

       


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email må oppgis")]
        [EmailAddress]
        public string Email { get; set; }
      
 

    }
   
}