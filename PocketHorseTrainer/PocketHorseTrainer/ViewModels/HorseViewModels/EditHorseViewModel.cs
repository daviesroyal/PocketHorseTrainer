using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class EditHorseViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        public Horse Horse { get; set; }

        private readonly string accessToken = AccessTokenSettings.AccessToken;

        public ICommand EditCommand
        {
            get
            {
                return new Command(async() => await apiServices.EditHorse(Horse, accessToken).ConfigureAwait(false));
            }
        }
    }
}
