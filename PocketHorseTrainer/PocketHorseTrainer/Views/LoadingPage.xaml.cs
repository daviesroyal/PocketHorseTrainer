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

        public LoadingPage()
        {
            InitializeComponent();

            apiServices.RefreshTokenAsync(TokenSettings.AccessToken, TokenSettings.RefreshToken);

            if (!string.IsNullOrEmpty(TokenSettings.AccessToken) && !string.IsNullOrEmpty(TokenSettings.RefreshToken))
            {
                Shell.Current.GoToAsync("//main");
            }
            else
            {
                Shell.Current.GoToAsync("//login");
            }
        }
    }
}