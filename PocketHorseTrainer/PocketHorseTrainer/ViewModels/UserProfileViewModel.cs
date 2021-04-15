using PocketHorseTrainer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.ViewModels
{
    public class UserProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime DOB { get; set; }
        public List<Horse> Horses { get; set; }
    }
}
