using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class AddGoalViewModel : BaseViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public AddGoalViewModel(Horse horse)
        {
            Horse = horse;
            AddCommand = new Command(() => Add());
        }

        public AddGoalViewModel()
        {
        }

        public string Name { get; set; }

        public Horse Horse { get; set; }
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
                Horse = Horse,
                Interval = SelectedInterval,
                StartDate = StartDate,
                EndDate = EndDate,
                AreaOfImprovement = SelectedArea,
                Completed = false
            };

            var result = await apiServices.AddGoal(goal.Horse.Id, goal).ConfigureAwait(false);
            if (result)
            {
                _routingService.GoTo(new GoalListPage(Horse));
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

        private Interval _selectedInterval;
        public Interval SelectedInterval
        {
            get
            {
                return _selectedInterval;
            }
            set
            {
                SetProperty(ref _selectedInterval, value);
            }
        }

        public List<string> IntervalNames
        {
            get
            {
                return Enum.GetNames(typeof(Interval)).ToList();
            }
        }
    }
}
