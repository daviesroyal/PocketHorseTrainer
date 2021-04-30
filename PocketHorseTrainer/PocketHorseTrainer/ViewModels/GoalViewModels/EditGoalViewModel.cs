using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Enums;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class EditGoalViewModel : BaseViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public Goal Goal { get; set; }

        public EditGoalViewModel()
        {
            EditCommand = new Command(() => Edit());
        }
        public ICommand EditCommand { get; set; }

        private async void Edit()
        {
            Goal.Name = Goal.Name;
            Goal.Interval = SelectedInterval;
            Goal.StartDate = Goal.StartDate;
            Goal.EndDate = Goal.EndDate;
            Goal.AreaOfImprovement = SelectedArea;
            Goal.Completed = Goal.Completed;

            var result = await apiServices.EditGoal(Goal).ConfigureAwait(false);

            if (result)
            {
                _routingService.GoTo(new GoalListPage(Goal.Horse));
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
    }
}
