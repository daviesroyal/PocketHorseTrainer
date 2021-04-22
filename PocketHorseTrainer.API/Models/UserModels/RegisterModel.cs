using System;

namespace PocketHorseTrainer.API.Models
{
    public class RegisterModel : LoginModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
