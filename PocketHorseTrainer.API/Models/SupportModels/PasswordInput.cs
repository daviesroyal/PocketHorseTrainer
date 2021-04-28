using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class PasswordInput
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
