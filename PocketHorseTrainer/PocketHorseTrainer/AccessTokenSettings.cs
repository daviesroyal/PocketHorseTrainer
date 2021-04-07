using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace PocketHorseTrainer
{
    public static class AccessTokenSettings
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
            get => AppSettings.GetValueOrDefault("AccessToken", "");
            set => AppSettings.AddOrUpdateValue("AccessToken", value);
        }

        public static DateTime AccessTokenExpirationDate
        {
            get => AppSettings.GetValueOrDefault("AccessTokenExpirationDate", DateTime.UtcNow);
            set => AppSettings.AddOrUpdateValue("AccessTokenExpirationDate", value);
        }
    }
}
