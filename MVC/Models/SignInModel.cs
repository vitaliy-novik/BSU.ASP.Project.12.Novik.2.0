using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Enter your login")]
        [Display(Name = "User name")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Value must be between 5 to 10 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Value must be between 3 to 15 characters")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}