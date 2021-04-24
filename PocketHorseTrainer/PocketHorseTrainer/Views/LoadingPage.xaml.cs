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

            //Application.Current.Properties["accessToken"] = null;
            //Application.Current.Properties["refreshToken"] = null;
            //await Application.Current.SavePropertiesAsync().ConfigureAwait(false);

            var tokens = await apiServices.RefreshTokenAsync(AccessTokenSettings.AccessToken, AccessTokenSettings.RefreshToken).ConfigureAwait(false);

            AccessTokenSettings.AccessToken = tokens.AccessToken;
            AccessTokenSettings.RefreshToken = tokens.RefreshToken;
            //await Application.Current.SavePropertiesAsync().ConfigureAwait(false);

            if (!string.IsNullOrEmpty(AccessTokenSettings.AccessToken) && !string.IsNullOrEmpty(AccessTokenSettings.RefreshToken))
            {
                await Shell.Current.GoToAsync("//main").ConfigureAwait(false);
            }
            else
            {
                await Shell.Current.GoToAsync("//login").ConfigureAwait(false);
            }
        }
    }
}