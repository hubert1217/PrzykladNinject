using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrzykladNinject.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }


        [Required(ErrorMessage = "Proszę podać nazwę produktu.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }


        [DataType(DataType.MultilineText), Display(Name = "Opis")]
        [Required(ErrorMessage = "Prosze podać opis.")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Prosze podać dodatnią cenę")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Proszę określić kategorię.")]
        public string Category { get; set; }

    }
}