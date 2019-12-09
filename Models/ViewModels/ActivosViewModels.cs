using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models.ViewModels
{
    public class ActivosViewModels
    {
        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Serial")]
        public string Serial { get; set; }

  
        [Required]
        [Display(Name = "Observaciones")]
        public string Observaciones{ get; set; }


    }
    public class EditActivosViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Serial")]
        public string Serial { get; set; }


        [Required]
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }


    }
}