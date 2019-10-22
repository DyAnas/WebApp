using System.ComponentModel.DataAnnotations;

namespace GruppeInnlevering1.Models
{
    public class Admin
    {


        public int id { get; set; }

        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]


        public string Fornavn { get; set; }
        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string Etternavn { get; set; }
        [Required(ErrorMessage = "Passord må oppgis")]
        public string passord { get; set; }

        [Required(ErrorMessage = "du må srive passord på nytt")]
        public string Gjentapassord { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email må oppgis")]
        [EmailAddress]
        public string Email { get; set; }


    }
    public class DbAdmin
    {

       
        public string Fornavn { get; set; }
        public string EtterFornavn { get; set; }
        [Key]
        [Required (ErrorMessage="Email er allereade registrert.")]
 
        public string Email { get; set; }
        public byte[] passord { get; set; }
        public string Salt { get; set; }

    }

}