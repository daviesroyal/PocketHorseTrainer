using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class EditGoalViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

        public Goal Goal { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () => await apiServices.EditGoal(Goal).ConfigureAwait(false));
            }
        }
    }
}
