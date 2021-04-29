using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class AddGoalViewModel : BaseViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public AddGoalViewModel()
        {
            AddCommand = new Command(() => Add());
        }

        public string Name { get; set; }
        public Interval Interval { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TargetAreas AreaOfImprovement { get; set; }

        public ICommand AddCommand { get; set; }

        private async void Add()
        {
            var goal = new Goal
            {
                Name = Name,
                Interval = Interval,
                StartDate = StartDate,
                EndDate = EndDate,
                AreaOfImprovement = SelectedArea,
                Completed = false
            };

            var result = await apiServices.AddGoal(goal.Horse.Id, goal).ConfigureAwait(false);
            if (result)
            {
                _routingService.NavigateTo("//goals");
            }
            else
            {
                _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
            }
        }

        private List<TargetAreas> _areas = apiServices.GetAreas().Result;
        private TargetAreas _selectedArea;
        public List<TargetAreas> Areas
        {
            get
            {
                return _areas;
            }
            set
            {
                if (_areas != value)
                {
                    _areas = value;
                    OnPropertyChanged();
                }
            }
        }
        public TargetAreas SelectedArea
        {
            get
            {
                return _selectedArea;
            }
            set
            {
                if (_selectedArea != value)
                {
                    _selectedArea = value;
                    OnPropertyChanged();
                }
            }
        }
        //TODO: add picker for enum
    }
}
