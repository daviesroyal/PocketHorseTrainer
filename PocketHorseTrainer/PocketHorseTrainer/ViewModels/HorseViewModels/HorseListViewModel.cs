using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.ViewModels.HorseViewModels
{
    public class HorseListViewModel
    {
        private readonly static ApiServices apiServices = new ApiServices();

        public List<Horse> Horses = apiServices.GetAllHorses().Result;
    }
}
