using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Podaj nazwe użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Podaj hasło użytkownika")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}