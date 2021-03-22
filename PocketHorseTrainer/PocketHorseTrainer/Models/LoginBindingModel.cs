using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.Models
{
    class LoginBindingModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
