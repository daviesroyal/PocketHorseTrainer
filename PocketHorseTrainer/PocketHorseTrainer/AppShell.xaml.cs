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
                    _ = await apiServices.Logout().ConfigureAwait(false);
                    Application.Current.Properties["accessToken"] = string.Empty;
                    Application.Current.Properties["refreshToken"] = string.Empty;
                    await Application.Current.SavePropertiesAsync().ConfigureAwait(false);
                    await Current.GoToAsync("//login").ConfigureAwait(false);
                });
            }
        }
    }
}
