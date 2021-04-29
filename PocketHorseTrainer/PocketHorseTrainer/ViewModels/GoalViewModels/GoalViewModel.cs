using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class GoalViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public Goal Goal { get; set; }

        public GoalViewModel(Goal goal)
        {
            Goal = goal;
            DeleteCommand = new Command(() => Delete());
        }

        public GoalViewModel() { }

        public ICommand DeleteCommand { get; set; }

        private void Delete()
        {
           var result = apiServices.DeleteGoal(Goal.Id).Result;

           if (result)
           {
               _routingService.GoTo(new GoalListPage(Goal.Horse));
           }
           else
           {
               _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
           }
        }
    }
}
