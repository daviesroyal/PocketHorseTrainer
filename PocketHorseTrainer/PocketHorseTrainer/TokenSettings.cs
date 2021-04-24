using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using Xamarin.Forms;

namespace PocketHorseTrainer
{
    public static class TokenSettings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", null);
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }

        public static string RefreshToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("RefreshToken", null);
            }
            set
            {
                AppSettings.AddOrUpdateValue("RefreshToken", value);
            }
        }
    }
}
