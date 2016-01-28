using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please, enter your login")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Value must be between 5 to 10 characters")]
        [Display(Name = "User name")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please, enter your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please, enter your last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Data")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please, enter your e-mail")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Incorrect e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Value must be between 3 to 15 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter confirm password")]
        [Display(Name = "Once Again")]
        [Compare("Password", ErrorMessage = "Mismatch")]
        public string ConfirmPassword { get; set; }
    }
}