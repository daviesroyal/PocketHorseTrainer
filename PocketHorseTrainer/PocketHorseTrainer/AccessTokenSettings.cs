using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using Xamarin.Forms;

namespace PocketHorseTrainer
{
    public static class AccessTokenSettings
    {
        public static string AccessToken
        {
            get
            {
                return (string)Application.Current.Properties["accessToken"];
            }
        }

        public static string RefreshToken
        {
            get
            {
                return (string)Application.Current.Properties["refreshToken"];
            }
        }
    }
}
