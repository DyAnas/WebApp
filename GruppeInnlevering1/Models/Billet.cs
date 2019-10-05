using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GruppeInnlevering1.Models
{
    public class Billet
    {
        public int BilletId { get; set; }

        public string Type { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy/MM/dd}")]
        public DateTime Datokjop { get; set; }

       

     

     


        public int Pris { get; set; }

        public int AvgangFra { get; set; }

        public int AvgangTil { get; set; }









    }
}