using Matcha.BackgroundService;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketHorseTrainer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Task.Run(() =>
            {
                BackgroundAggregatorService.Add(() => new PeriodicRefreshTokenCall(30));
                BackgroundAggregatorService.StartBackgroundService();
            });
        }

        protected override void OnSleep()
        {
            BackgroundAggregatorService.StopBackgroundService();
        }

        protected override void OnResume()
        {
            Task.Run(() =>
            {
                BackgroundAggregatorService.Add(() => new PeriodicRefreshTokenCall(30));
                BackgroundAggregatorService.StartBackgroundService();
            });
        }
    }
}
