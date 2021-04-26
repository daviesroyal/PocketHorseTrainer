using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class EditHorseViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        public Horse Horse { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await apiServices.EditHorse(Horse).ConfigureAwait(false);

                    if (result)
                    {
                        _ = Task.Run(async () => await Shell.Current.Navigation.PushAsync(new HorseListPage($"{Horse.Name}'s info has been updated!")).ConfigureAwait(false));
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Uh oh!", "Something went wrong.", "OK").ConfigureAwait(false);
                    }
                });
            }
        }
    }
}
