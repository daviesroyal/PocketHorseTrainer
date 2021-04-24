using PocketHorseTrainer.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage() => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (string.IsNullOrEmpty(AccessTokenSettings.AccessToken))
            {
                await Shell.Current.GoToAsync("//login").ConfigureAwait(false);
            }
            else
            {
                await Shell.Current.GoToAsync("//main").ConfigureAwait(false);
            }
        }
    }
}