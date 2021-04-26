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

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }
        public Markings Markings { get; set; }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await apiServices.DeleteHorse(Id).ConfigureAwait(false);

                    if (result)
                    {
                        _ = Task.Run(async () => await Shell.Current.Navigation.PushAsync(new HorseListPage($"{Name} has been removed from your barn.")).ConfigureAwait(false));
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
