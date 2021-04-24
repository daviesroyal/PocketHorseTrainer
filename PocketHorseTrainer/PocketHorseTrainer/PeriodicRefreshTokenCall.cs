using Matcha.BackgroundService;
using PocketHorseTrainer.Services;
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
            var tokens = await apiServices.RefreshTokenAsync(AccessTokenSettings.AccessToken, AccessTokenSettings.RefreshToken).ConfigureAwait(false);
            if (!string.IsNullOrEmpty(tokens.AccessToken) && !string.IsNullOrEmpty(tokens.RefreshToken))
            {
                AccessTokenSettings.AccessToken = tokens.AccessToken;
                AccessTokenSettings.RefreshToken = tokens.RefreshToken;
                //await Application.Current.SavePropertiesAsync().ConfigureAwait(false);
            }
            else
            {
                await Shell.Current.GoToAsync("//login").ConfigureAwait(false);
            }
            return true;
        }
    }
}
