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
        private readonly RoutingService _routingService = new RoutingService();

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("register", typeof(RegisterPage));
            Routing.RegisterRoute("main", typeof(MainPage));
            Routing.RegisterRoute("horses", typeof(HorseListPage));
            Routing.RegisterRoute("profile", typeof(UserProfilePage));
            Routing.RegisterRoute("goals", typeof(GoalListPage));
            Routing.RegisterRoute("journal", typeof(JournalEntriesPage));

            BindingContext = this;
        }

        public ICommand ExecuteLogout
        {
            get
            {
                return new Command(async () =>
                {
                    _ = await apiServices.Logout().ConfigureAwait(false);

                    _routingService.NavigateTo("//login");
                });
            }
        }
    }
}
