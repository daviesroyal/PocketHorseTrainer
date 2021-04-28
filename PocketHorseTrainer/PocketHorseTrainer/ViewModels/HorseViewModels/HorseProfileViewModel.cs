using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Horses;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class HorseProfileViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public HorseProfileViewModel(Horse horse)
        {
            Horse = horse;
            EditCommand = new Command(() => Edit());
            DeleteCommand = new Command(() => Delete());
            GoalCommand = new Command(() => Goal());
            JournalCommand = new Command(() => Journal());
        }

        public Horse Horse { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand GoalCommand { get; set; }
        public ICommand JournalCommand { get; set; }

        private void Edit()
        {
            _routingService.GoTo(new EditHorsePage(Horse));
        }

        private async void Delete()
        {
            var result = await apiServices.DeleteHorse(Horse.Id).ConfigureAwait(false);

            if (result)
            {
                _routingService.GoTo(new HorseListPage($"{Horse.Name} has been removed from your barn."));
            }
            else
            {
                _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
            }
        }

        private void Goal()
        {
            _routingService.GoTo(new GoalListPage(Horse));
        }

        private void Journal()
        {
            _routingService.GoTo(new JournalEntriesPage(Horse));
        }
    }
}
