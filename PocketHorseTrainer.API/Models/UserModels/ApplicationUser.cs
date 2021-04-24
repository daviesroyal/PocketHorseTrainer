using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace PocketHorseTrainer.API.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime DOB { get; set; }
        public List<HorseOwner> Horses { get; set; }
        public string RefreshToken { get; set; }
    }
}
