using Matcha.BackgroundService;
using PocketHorseTrainer.Services;
using System;
using System.Threading.Tasks;

namespace PocketHorseTrainer
{
    public class PeriodicRefreshTokenCall : IPeriodicTask
    {
        private readonly static ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();

        public TimeSpan Interval { get; set; }
        public PeriodicRefreshTokenCall(int minutes)
        {
            Interval = TimeSpan.FromMinutes(minutes);
        }

        public async Task<bool> StartJob()
        {
            apiServices.RefreshTokenAsync(TokenSettings.AccessToken, TokenSettings.RefreshToken);
            if (string.IsNullOrEmpty(TokenSettings.AccessToken) || string.IsNullOrEmpty(TokenSettings.RefreshToken))
            {
                _routingService.NavigateTo("//login");
            }
            return true;
        }
    }
}
