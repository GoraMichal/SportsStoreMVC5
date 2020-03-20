using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Podaj nazwisko.")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Podaj swój adres zamieskania.")]
        public string Address { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Podaj nazwę miasta.")]
        public string City { get; set; }

        [Display(Name = "Województwo")]
        [Required(ErrorMessage = "Podaj nazwę województwa")]
        public string State { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string Zip { get; set; }

        [Display(Name = "Państwo")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Podaj nazwę kraju.")]
        public bool GiftWrap { get; set; }
    }
}
