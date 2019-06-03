using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCC.ViewModels
{
    public class PlantViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Description { get; set; }
        [Display(Name = "Ativo")]
        public bool Active { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int IdCategory { get; set; }
        [Display(Name = "Umidade Minima")]
        public decimal MinMoisture { get; set; }
        [Display(Name = "Umidade Maxima")]
        public decimal MaxMoisture { get; set; }

        public SelectList Category { get; set; }
    }
}