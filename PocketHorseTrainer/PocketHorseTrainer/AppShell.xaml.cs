using PocketHorseTrainer.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer
{
    public partial class AppShell : Shell
    {
        private readonly ApiServices apiServices = new ApiServices();

        public AppShell()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public ICommand ExecuteLogout
        {
            get
            {
                return new Command(async () =>
                {
                    _ = await apiServices.Logout(AccessTokenSettings.AccessToken).ConfigureAwait(false);
                    await Current.GoToAsync("//login").ConfigureAwait(false);
                });
            }
        }
    }
}
