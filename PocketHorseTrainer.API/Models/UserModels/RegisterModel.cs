using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class RegisterModel : LoginModel
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your birthday.")]
        //[DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Please enter a valid email.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation passowrd do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
