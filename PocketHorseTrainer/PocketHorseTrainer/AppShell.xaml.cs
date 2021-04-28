using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System.Threading.Tasks;
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

            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("register", typeof(RegisterPage));
            Routing.RegisterRoute("main", typeof(MainPage));
            Routing.RegisterRoute("horses", typeof(HorseListPage));
            Routing.RegisterRoute("profile", typeof(UserProfilePage));

            BindingContext = this;
        }

        public ICommand ExecuteLogout
        {
            get
            {
                return new Command(async () =>
                {
                    _ = await apiServices.Logout().ConfigureAwait(false);

                    _ = Task.Run(async () => await Current.GoToAsync("//login").ConfigureAwait(false));
                });
            }
        }
    }
}
