using Matcha.BackgroundService;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketHorseTrainer
{
    public class PeriodicRefreshTokenCall : IPeriodicTask
    {
        private readonly static ApiServices apiServices = new ApiServices();
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
                await Shell.Current.GoToAsync("//login").ConfigureAwait(false);
            }
            return true;
        }
    }
}
