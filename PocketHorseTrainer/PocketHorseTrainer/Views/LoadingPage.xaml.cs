using PocketHorseTrainer.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        private readonly static ApiServices apiServices = new ApiServices();

        public LoadingPage() => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            apiServices.RefreshTokenAsync(TokenSettings.AccessToken, TokenSettings.RefreshToken);

            if (!string.IsNullOrEmpty(TokenSettings.AccessToken) && !string.IsNullOrEmpty(TokenSettings.RefreshToken))
            {
                await Shell.Current.GoToAsync("//main").ConfigureAwait(false); //breakpoint is triggering, navigation isn't
            }
            else
            {
                await Shell.Current.GoToAsync("//login").ConfigureAwait(false);
            }
        }
    }
}