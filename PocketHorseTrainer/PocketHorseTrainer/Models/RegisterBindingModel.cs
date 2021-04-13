using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.Models
{
    public class RegisterBindingModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
