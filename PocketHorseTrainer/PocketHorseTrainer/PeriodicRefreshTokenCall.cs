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
            if (string.IsNullOrEmpty(AccessTokenSettings.AccessToken))
            {
                var token = await apiServices.RefreshTokenAsync().ConfigureAwait(false);
                if (token != null)
                {
                    Application.Current.Properties["accessToken"] = token;
                    await Application.Current.SavePropertiesAsync().ConfigureAwait(false);
                }
                else
                {
                    await Shell.Current.GoToAsync("//login").ConfigureAwait(false);
                }
            }
            return true;
        }
    }
}
