using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.ViewModels.GoalViewModels
{
    public class GoalListViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();

        public static Horse Horse { get; set; }

        public List<Goal> Goals = apiServices.GetAllGoals(Horse.Id).Result;

        public GoalListViewModel(Horse horse)
        {
            Horse = horse;
        }

        public GoalListViewModel() { }
    }
}
